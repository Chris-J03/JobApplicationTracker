namespace JobApp.Model;
public class EmailData
{
    public string Id { get; set; } = "";

    public string Sender { get; set; } = "";

    public string Subject { get; set; } = "";

    public string Body { get; set; } = "";

    public DateTimeOffset Date { get; set; }
}