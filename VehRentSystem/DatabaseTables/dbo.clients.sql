CREATE TABLE [dbo].[clients] (
    [personalNumber] BIGINT        NOT NULL,
    [name]           VARCHAR (50)  NOT NULL,
    [surename]       VARCHAR (100) NOT NULL,
    [dateOfBirth]    DATE          NOT NULL,
    [address]        VARCHAR (255) NOT NULL,
    [city]           VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([personalNumber] ASC),
    UNIQUE NONCLUSTERED ([personalNumber] ASC)
);

