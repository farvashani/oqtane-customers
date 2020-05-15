/*  
Create TresCustomer table
*/

CREATE TABLE [dbo].[TresCustomer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[Address1] [nvarchar](50) NULL,
	[Address2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[UsState] [nvarchar](50) NULL,
	[ZipCode] [nvarchar](50) NULL,
	[Email] [nvarchar](256) NULL,
	[Phone] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
  CONSTRAINT [PK_TresCustomer] PRIMARY KEY CLUSTERED 
  (
	[CustomerId] ASC
  )
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[TresCustomer]  WITH CHECK ADD  CONSTRAINT [FK_TresCustomer_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].Module ([ModuleId])
ON DELETE CASCADE
GO