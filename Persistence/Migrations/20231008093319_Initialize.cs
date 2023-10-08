using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ActiveStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Roles = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    isActived = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DishCategoryId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActived = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PaymentId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chef",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Awards = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chef_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RewardsPoints = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MediaURLs = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    IsEdited = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PostId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 10, 8, 16, 33, 19, 16, DateTimeKind.Local).AddTicks(1655)),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChefID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaign_Chef_ChefID",
                        column: x => x.ChefID,
                        principalTable: "Chef",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ChefID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssuingAuthority = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CertificationDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EffectiveDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificationURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsValid = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CertificationId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certification_Chef_ChefID",
                        column: x => x.ChefID,
                        principalTable: "Chef",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 10, 8, 16, 33, 19, 21, DateTimeKind.Local).AddTicks(8843)),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpectedDeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    NumberOfItems = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Discount = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("OrderId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DisplayIndex = table.Column<int>(type: "int", nullable: true),
                    ParentCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    ISEdited = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 10, 8, 16, 33, 19, 18, DateTimeKind.Local).AddTicks(7670)),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CommentId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Comment_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("LikeId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Like_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Like_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    IsEdited = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DishName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DishCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    DishImage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DishIngredients = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 10, 8, 16, 33, 19, 20, DateTimeKind.Local).AddTicks(5064)),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DishId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dish_DishCategory_DishCategoryId",
                        column: x => x.DishCategoryId,
                        principalTable: "DishCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dish_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DishId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UnitPrice = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    IsCancelled = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("OrderDetailId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "ActiveStatus", "Bio", "CreatedBy", "CreatedDate", "DateOfBirth", "Email", "FirstName", "Gender", "LastModifiedDate", "LastName", "ModifiedBy", "Password", "PhoneNumber", "ProfilePicture", "Roles", "Username" },
                values: new object[,]
                {
                    { new Guid("3f2c2327-3b07-4fa9-9bff-e5e1857710ba"), 1, "Bio information for Nguyen Phat.", null, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9395), new DateTime(2002, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "khoatruong@gmail.com", "Truong", 0, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9396), "Khoa", null, "Khoa2k17", "0123456789", "/profile/phatnt.jpg", 2, "khoatruong" },
                    { new Guid("5800c4f2-1bce-41a7-a909-92b0336f8b37"), 1, "Bio information for Nguyen Phat.", null, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9385), new DateTime(2002, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenphat2711@gmail.com", "Nguyen", 0, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9387), "Phat", null, "Phat@2711", "0812400096", "/profile/phatnt.jpg", 2, "fatnofat" },
                    { new Guid("65d650ab-7e48-4f34-927e-b99a4768a1cf"), 1, "Bio information for Sara Wilson.", null, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9363), new DateTime(1992, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.wilson@example.com", "Sara", 1, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9365), "Wilson", null, "sara123", "1112223333", "/profile/sara_wilson.jpg", 2, "sara_wilson" },
                    { new Guid("67abe55d-4cac-4c23-9d32-2395f181fae1"), 1, "Bio information for John Doe.", null, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9249), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", 0, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9263), "Doe", null, "securepassword1", "1234567890", "/profile/john_doe.jpg", 1, "john_doe" },
                    { new Guid("8da4e108-36a0-4135-9987-ae45ad0a2182"), 1, "Bio information for Jane Smith.", null, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9278), new DateTime(1990, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", 1, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9281), "Smith", null, "p@ssw0rd", "9876543210", "/profile/jane_smith.jpg", 2, "jane_smith" },
                    { new Guid("9a757dcc-dc7c-45e2-90f7-059e8eec4f0f"), 1, "Bio information for Truong Le Tuan Kiet.", null, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9429), new DateTime(2002, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "kiethathayvai@gmail.com", "Truong", 0, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9430), "Le Tuan Kiet", null, "Kiethocgioihayhat", "0123456789", "/profile/kiettlt.jpg", 2, "truongletuankiet" },
                    { new Guid("a7929b50-8471-455e-9768-05bc9dc3014c"), 1, "Bio information for Nguyen Van Dung.", null, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9418), new DateTime(2002, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dungkinaysinhviengioi@gmail.com", "Nguyen", 0, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9419), "Van Dung", null, "Dunghocgioivcl", "0123456789", "/profile/dungnv.jpg", 2, "vandung" },
                    { new Guid("a8aadcaf-92cc-4bf7-abd1-4b9ce4646505"), 1, "Bio information for Bob Jones.", null, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9292), new DateTime(1988, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.jones@example.com", "Bob", 0, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9294), "Jones", null, "strongpass123", "5556667777", "/profile/bob_jones.jpg", 2, "bob_jones" },
                    { new Guid("ed855c6c-63e4-46c4-b713-576aeabcd011"), 1, "Bio information for Nguyen Duc Binh.", null, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9449), new DateTime(2002, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ducbinhnguyen@gmail.com", "Nguyen", 0, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9450), "Duc Binh", null, "binhleader", "0123456789", "/profile/binhnd.jpg", 2, "ducbinhnguyen" },
                    { new Guid("f29edd2d-34a9-43cc-bea8-66ead19921c8"), 1, "Bio information for Mike Jackson.", null, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9374), new DateTime(1980, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mike.jackson@example.com", "Mike", 0, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9376), "Jackson", null, "mikepass", "3334445555", "/profile/mike_jackson.jpg", 2, "mike_jackson" },
                    { new Guid("f82e0e64-c90b-4426-89de-7edae9fcd661"), 1, "Bio information for Le Thi Thu Trang.", null, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9439), new DateTime(2002, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "trangxinhgai@gmail.com", "Le", 1, new DateTime(2023, 10, 8, 16, 33, 19, 14, DateTimeKind.Local).AddTicks(9440), "Thi Thu Trang", null, "trangxinhxinhhihi", "0123456789", "/profile/trangltt.jpg", 2, "trangxinhgai" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_ChefID",
                table: "Campaign",
                column: "ChefID");

            migrationBuilder.CreateIndex(
                name: "IX_Certification_ChefID",
                table: "Certification",
                column: "ChefID");

            migrationBuilder.CreateIndex(
                name: "IX_Chef_AccountId",
                table: "Chef",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AccountId",
                table: "Comment",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentCommentId",
                table: "Comment",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AccountId",
                table: "Customer",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_DishCategoryId",
                table: "Dish",
                column: "DishCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_MenuId",
                table: "Dish",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_AccountId",
                table: "Like",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_PostId",
                table: "Like",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_CampaignId",
                table: "Menu",
                column: "CampaignId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentId",
                table: "Order",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_DishId",
                table: "OrderDetail",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_AccountID",
                table: "Post",
                column: "AccountID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certification");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Dish");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "DishCategory");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Chef");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
