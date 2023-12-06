SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[highscores](
	[Score_ID] [int] NOT NULL,
	[Name] [varchar](6) NOT NULL,
	[Score] [int] NOT NULL
) ON [PRIMARY]
GO
