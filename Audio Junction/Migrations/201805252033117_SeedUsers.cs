namespace Audio_Junction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a0762fed-4f0b-426d-996e-16953b18252d', N'guest@audiojunction.com', 0, N'AHKeDmtDfxyRPk9arxBNtpYpiXAAFtAvAHbGcdMVV04cr1trWQ5eEVqksZ2a4wqjMw==', N'd6f249cc-29ca-4e0a-ac4a-fe08595849e4', NULL, 0, 0, NULL, 1, 0, N'guest@audiojunction.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b0675a6d-084b-44ce-aadd-b359181b3758', N'admin@audiojunction.com', 0, N'AOmmRLYwKL8Q6YOgh6cYw2jRNXwKmJii677vCViamKUVD0E8SaDcWGSOdoKe0NLrQQ==', N'0d6480bc-1bf1-40d5-9a28-d9f075fa2d7a', NULL, 0, 0, NULL, 1, 0, N'admin@audiojunction.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f12fefc8-8b8b-42b0-8c12-45dc7d6b1bc9', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b0675a6d-084b-44ce-aadd-b359181b3758', N'f12fefc8-8b8b-42b0-8c12-45dc7d6b1bc9')


");
        }
        
        public override void Down()
        {
        }
    }
}
