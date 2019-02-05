namespace VidlyOnNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'02d2e029-b470-4b0a-8128-48fd818c5a8a', N'admin@vidly.com', 0, N'AHTD2qEFZxJsSIl7HP4b5MbNBh/Bd/4beSCj7eBXjjH3pMnhUqkzFxyOJRh9wuKOfQ==', N'0a608d47-ab47-429a-85da-f940ad4cf746', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'70643623-2cc6-4f97-9c07-f94cf8d31805', N'guest@vidly.com', 0, N'AJds0jLVKYEQkcxcAZwEIwM8OzNsc3yu2BRRztV/SWzfKTeZzt8HGxCkOvX7js63Lw==', N'7be6847e-9986-4746-bfbe-bce34143754b', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'85f1ff01-68d7-4a55-815f-85a381e921d0', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'02d2e029-b470-4b0a-8128-48fd818c5a8a', N'85f1ff01-68d7-4a55-815f-85a381e921d0')

");
        }
        
        public override void Down()
        {
        }
    }
}
