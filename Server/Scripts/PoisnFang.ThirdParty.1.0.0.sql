/*  
Create PoisnFangThirdParty table
*/

CREATE TABLE [dbo].[PoisnFangThirdParty](
	[ThirdPartyId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
  CONSTRAINT [PK_PoisnFangThirdParty] PRIMARY KEY CLUSTERED 
  (
	[ThirdPartyId] ASC
  )
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[PoisnFangThirdParty]  WITH CHECK ADD  CONSTRAINT [FK_PoisnFangThirdParty_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].Module ([ModuleId])
ON DELETE CASCADE
GO