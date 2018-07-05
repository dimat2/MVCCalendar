CREATE TABLE [dbo].[Events] (
    [EventId]     INT            IDENTITY (1, 1) NOT NULL,
    [Subject]     NVARCHAR (255) NOT NULL,
    [Description] NVARCHAR (300) NULL,
    [Start]       DATETIME       NOT NULL,
    [End]         DATETIME       NULL,
    [ThemeColor]  NVARCHAR (10)  NULL,
    [IsFullDay]   BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([EventId] ASC)
);
