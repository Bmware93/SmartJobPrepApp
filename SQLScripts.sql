CREATE TABLE JobDescriptions (
    Id INT PRIMARY KEY IDENTITY(1, 1),
    Title VARCHAR(100),
    DescriptionText Text,
    CreatedAt DATETIME
);

CREATE Table Questions (
    Id INT PRIMARY KEY IDENTITY,
    QuestionText TEXT,
    CreatedAt DATETIME,
    JobDescriptionId INT FOREIGN KEY(JobDescriptionId) REFERENCES JobDescriptions(Id)
);



