// Service that will access user email and read the content of the email to extract job application information
// This will be an automatic service that will update database with new job applications from the user's email
using MailKit.Net.Imap;
using MailKit.Security;
using Microsoft.Identity.Client;

namespace JobSearchEmailReader.Services;
 // 4b0cd060-1ab7-4e31-8b56-3f537deb2963
 
public class EmailService
{
    private readonly string _clientId;
    private readonly string _emailAddress;

    public EmailService(string clientId, string emailAddress)
    {
        _clientId = clientId;
        _emailAddress = emailAddress;
    }

    private async Task<AuthenticationResult> GetAccessTokenAsync()
    {
        var options = new PublicClientApplicationOptions
        {
            ClientId = _clientId,
            TenantId = "consumers",
            RedirectUri = "http://localhost"
        };

        var app = PublicClientApplicationBuilder
            .CreateWithApplicationOptions(options)
            .Build();

        string[] scopes =
        [
            "email",
            "offline_access",
            "https://outlook.office.com/IMAP.AccessAsUser.All"
        ];

        var accounts = await app.GetAccountsAsync();

        try
        {
            return await app
                .AcquireTokenSilent(scopes, accounts.FirstOrDefault())
                .ExecuteAsync();
        }
        catch (MsalUiRequiredException)
        {
            return await app
                .AcquireTokenInteractive(scopes)
                .ExecuteAsync();
        }
    }

    public async Task TestConnectionAsync()
    {
        var authenticationResult = await GetAccessTokenAsync();

        using var client = new ImapClient();

        await client.ConnectAsync(
            "outlook.office365.com",
            993,
            SecureSocketOptions.SslOnConnect
        );

        var oauth2 = new SaslMechanismOAuth2(
            authenticationResult.Account.Username,
            authenticationResult.AccessToken
        );

        await client.AuthenticateAsync(oauth2);

        Console.WriteLine("Successfully connected to Outlook!");

        await client.DisconnectAsync(true);
    }
}