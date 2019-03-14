CREATE TABLE [dbo].[Todo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Task] [nvarchar](200) NOT NULL,
	[TaskStatusId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifyDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Todo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Todo]  WITH CHECK ADD  CONSTRAINT [FK_Todo_TaskStatus] FOREIGN KEY([TaskStatusId])
REFERENCES [dbo].[TaskStatus] ([Id])
GO

ALTER TABLE [dbo].[Todo] CHECK CONSTRAINT [FK_Todo_TaskStatus]
GO
