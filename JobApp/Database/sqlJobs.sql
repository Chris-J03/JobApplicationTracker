-- CREATE TABLE Jobs (
--     id INTEGER PRIMARY KEY AUTOINCREMENT,
--     job_name TEXT NOT NULL,
--     status TEXT NOT NULL,
--     created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
--     updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
-- );

INSERT INTO Jobs (Company, Position, Status) VALUES
('Data Import', 'Data Analyst', 'Pending'),
('Data Export', 'Data Scientist', 'Completed'),
('Report Generation', 'Business Analyst', 'In Progress'),
('Backup', 'System Administrator', 'Failed');

-- SELECT * FROM Jobs;


-- CREATE FUNCTION GetJobStatus(job_name TEXT) RETURNS TEXT AS $$
-- BEGIN
--     DECLARE job_status TEXT;
--     SELECT status INTO job_status FROM JobAppsSQL WHERE job_name = job_name;
--     RETURN job_status;
-- END;$$ LANGUAGE plpgsql;
