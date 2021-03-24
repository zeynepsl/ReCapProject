CREATE TABLE [dbo].[Brand] (
    [BrandId] INT          NOT NULL,
    [Name]    VARCHAR (20) NULL,
    CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED ([BrandId] ASC),
    CONSTRAINT [FK_Brand_Brand] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brand] ([BrandId])
);

