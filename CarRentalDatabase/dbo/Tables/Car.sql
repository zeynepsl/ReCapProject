CREATE TABLE [dbo].[Car] (
    [Id]         INT        NOT NULL,
    [BrandId]    INT        NULL,
    [ColorId]    INT        NULL,
    [ModelYear]  DATETIME   NULL,
    [DailyPrice] FLOAT (53) NULL,
    CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Car_Car] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Color] ([Id])
);

