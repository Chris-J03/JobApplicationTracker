CREATE TABLE JobAppsSQL (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    job_name TEXT NOT NULL,
    status TEXT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO JobAppsSQL (job_name, status) VALUES
('Data Import', 'Pending'),
('Data Export', 'Completed'),
('Report Generation', 'In Progress'),
('Backup', 'Failed');

SELECT * FROM JobAppsSQL;
