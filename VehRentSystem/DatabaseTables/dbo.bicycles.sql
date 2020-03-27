CREATE TABLE [dbo].[bicycles] (
    [bike_ID]      INT           IDENTITY (1, 1) NOT NULL,
    [clientNumber] BIGINT        NULL,
    [brand]        VARCHAR (255) NOT NULL,
    [model]        VARCHAR (255) NOT NULL,
    [color]        VARCHAR (255) NULL,
    [rentPrice]    FLOAT (53)    NOT NULL,
    [rentStatus]   BIT           DEFAULT ((0)) NOT NULL,
    [rentFrom]     DATE          NULL,
    PRIMARY KEY CLUSTERED ([bike_ID] ASC),
    FOREIGN KEY ([clientNumber]) REFERENCES [dbo].[clients] ([personalNumber])
);

