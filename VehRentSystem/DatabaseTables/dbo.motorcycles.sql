CREATE TABLE [dbo].[motorcycles] (
    [motoNumber]     VARCHAR (255) NOT NULL,
    [clientNumber]   BIGINT        NULL,
    [brand]          VARCHAR (255) NOT NULL,
    [model]          VARCHAR (255) NOT NULL,
    [engine]         VARCHAR (255) NOT NULL,
    [color]          VARCHAR (255) NULL,
    [year]           INT           NOT NULL,
    [rentPrice]      FLOAT (53)    NOT NULL,
    [rentStatus]     BIT           DEFAULT ((0)) NOT NULL,
    [techServiceExp] DATE          NOT NULL,
    [insuranceExp]   DATE          NOT NULL,
    [rentFrom]       DATE          NULL,
    PRIMARY KEY CLUSTERED ([motoNumber] ASC),
    UNIQUE NONCLUSTERED ([motoNumber] ASC),
    FOREIGN KEY ([clientNumber]) REFERENCES [dbo].[clients] ([personalNumber])
);

