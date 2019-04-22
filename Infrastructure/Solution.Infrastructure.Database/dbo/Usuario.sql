CREATE TABLE [dbo].[Usuario](
	[Codigo]			[int] IDENTITY(1,1) NOT NULL,
	[Nome]				[varchar](20) NOT NULL,
	[Sobrenome]			[varchar](20) NOT NULL,
	[Status]			[int] DEFAULT (1) NOT NULL,
	[DataNascimento]	[smalldatetime]       NULL,
    CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
