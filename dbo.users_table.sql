CREATE TABLE [dbo].[users_table] (
    [Id]       INT           NOT NULL,
    [Username] NVARCHAR (50) NULL,
    [Password] NVARCHAR (50) NULL,
	[Firstname] NVARCHAR (50) NULL,
	[Lastname] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

