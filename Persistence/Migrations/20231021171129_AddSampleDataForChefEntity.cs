using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSampleDataForChefEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("02956bac-0bbe-4c15-a17c-4e6f2a522feb"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("1fef46c3-43f6-4655-b59c-a80a7cb45435"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("2340d1ba-a8e0-424a-a766-a58237276fdc"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("2934d1c2-8a26-4fe5-9f09-893ca0d9ea34"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("378dd1b0-6093-4f09-9263-dab7f7cb6c33"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("49f78a61-6df7-42cb-94d0-550395bc3496"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("4e602db6-caff-49b5-bb75-7df95d768b07"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("53caeba3-e329-4047-b690-9eb249cef0a8"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("81954452-ec22-4ef5-9d41-b21adb17ba27"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("8b0457eb-63d6-428b-948e-785fe240586f"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("f9f8fae5-4a6d-4cc4-9ebe-7f49cff0d50d"));

            migrationBuilder.DeleteData(
                table: "Chef",
                keyColumn: "Id",
                keyValue: new Guid("43dce280-ea22-42ba-b222-c13a4c60c8d9"));

            migrationBuilder.DeleteData(
                table: "Chef",
                keyColumn: "Id",
                keyValue: new Guid("d57b28eb-64fe-4080-909f-ccf2334902df"));

            migrationBuilder.DeleteData(
                table: "Chef",
                keyColumn: "Id",
                keyValue: new Guid("e77983ed-d25d-4da3-8870-0575809559c1"));

            migrationBuilder.DeleteData(
                table: "Chef",
                keyColumn: "Id",
                keyValue: new Guid("f03d1f11-823c-4a47-96e7-0dc20108253c"));

            migrationBuilder.DeleteData(
                table: "Chef",
                keyColumn: "Id",
                keyValue: new Guid("f05a66c7-8afb-4f5f-adb6-32b678ee82fb"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("1943384f-15e6-49f3-95ee-8d8dbb7342fc"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("1a244d93-176f-46c0-9d61-88fa18ab76e2"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("403ec21a-1c56-48cb-9b3d-1ba7592cbcca"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("73e6bb46-5c0e-4645-bf62-f9ad613bc89d"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("943c6bdf-94a9-49b9-8953-7bf70c7c3548"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("012aca4f-c4d5-46d9-99b3-e4401225e0e6"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("38aa379e-6afc-45a4-aae3-55c95fc61fa0"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("3cc53ffd-c6e1-4799-b92a-a00eee75a819"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("4175020c-de24-442f-a41f-ec0905a1e104"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("7029db3b-50ed-438b-bafb-65586980044a"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("828c7efb-be6c-4857-ab21-18cdf9904e72"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("92993ec9-77d2-4ff6-90b8-c0e3a6427cc9"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("ab8126b8-1f2d-4d4c-9abb-2f30b904ad9e"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("b33ca62c-381c-4347-8f2a-2db885ac4f77"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("d3bb63ce-dc1c-4cc8-b3ce-2911db427220"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 22, 0, 11, 29, 267, DateTimeKind.Local).AddTicks(8968),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 21, 23, 57, 23, 98, DateTimeKind.Local).AddTicks(6494));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Dish",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 22, 0, 11, 29, 267, DateTimeKind.Local).AddTicks(1993),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 21, 23, 57, 23, 97, DateTimeKind.Local).AddTicks(8693));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 22, 0, 11, 29, 266, DateTimeKind.Local).AddTicks(3577),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 21, 23, 57, 23, 96, DateTimeKind.Local).AddTicks(9153));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Campaign",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 22, 0, 11, 29, 265, DateTimeKind.Local).AddTicks(6062),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 21, 23, 57, 23, 95, DateTimeKind.Local).AddTicks(9393));

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "ActiveStatus", "Bio", "CreatedBy", "CreatedDate", "DateOfBirth", "Email", "FirstName", "Gender", "LastModifiedDate", "LastName", "ModifiedBy", "Password", "PhoneNumber", "ProfilePicture", "Roles", "Username" },
                values: new object[,]
                {
                    { new Guid("180070e0-1b3a-4758-9892-a4de860f3d37"), 1, "Passionate about baking and pastry creations. Join me on my baking adventures as I explore the art of sweets and treats!", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1978), new DateTime(1989, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "baker@example.com", "Olivia", 1, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1978), "Miller", null, "bakeitup", "5678901234", "/profile/olivia_miller.jpg", 0, "baking_enthusiast" },
                    { new Guid("1890281f-fe26-40ba-aaad-3b3c74e65c32"), 1, "Bio information for Truong Le Tuan Kiet.", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1760), new DateTime(2002, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "kiethathayvai@gmail.com", "Truong", 0, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1761), "Le Tuan Kiet", null, "Kiethocgioihayhat", "0123456789", "/profile/kiettlt.jpg", 2, "truongletuankiet" },
                    { new Guid("18b56e56-6ff5-4089-a4ac-2496bac13879"), 1, "Bio information for Nguyen Duc Binh.", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1773), new DateTime(2002, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ducbinhnguyen@gmail.com", "Nguyen", 0, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1773), "Duc Binh", null, "binhleader", "0123456789", "/profile/binhnd.jpg", 2, "ducbinhnguyen" },
                    { new Guid("1e1f19be-3c5f-413f-b5cc-2e4f21e8132f"), 1, "Fitness enthusiast", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1869), new DateTime(1983, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5@user5.com", "Daniel", 0, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1870), "Brown", null, "password5", "5678901234", "/profile/profile5.jpg", 1, "user5" },
                    { new Guid("2631d4d8-ffb0-4a27-9057-e0838efcf758"), 1, "I love exploring new cuisines and trying out different recipes. Excited to be a part of this culinary community!", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1917), new DateTime(1988, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.customer@example.com", "John", 0, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1918), "Smith", null, "customer123", "1234567890", "/profile/john_smith.jpg", 0, "johncustomer" },
                    { new Guid("2a117f10-93c8-4cc7-aee3-dbe85b3fa773"), 1, "Bio information for Nguyen Phat.", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1748), new DateTime(2002, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "khoatruong@gmail.com", "Truong", 0, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1749), "Khoa", null, "Khoa2k17", "0123456789", "/profile/phatnt.jpg", 2, "khoatruong" },
                    { new Guid("42ce4c18-119b-4cf9-aeb1-2224b3d54bc2"), 1, "Bio information for Le Thi Thu Trang.", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1767), new DateTime(2002, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "trangxinhgai@gmail.com", "Le", 1, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1768), "Thi Thu Trang", null, "trangxinhxinhhihi", "0123456789", "/profile/trangltt.jpg", 2, "trangxinhgai" },
                    { new Guid("44472ea7-1744-424d-a95d-122e0420897b"), 1, "Bio information for John Doe.", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1664), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", 0, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1678), "Doe", null, "securepassword1", "1234567890", "/profile/john_doe.jpg", 1, "john_doe" },
                    { new Guid("4c66f0e4-4ca0-4b6a-803f-9efb2b9914a0"), 1, "Bio information for Nguyen Phat.", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1743), new DateTime(2002, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenphat2711@gmail.com", "Nguyen", 0, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1744), "Phat", null, "Phat@2711", "0812400096", "/profile/phatnt.jpg", 2, "fatnofat" },
                    { new Guid("566d3f29-ea8f-425c-a7c7-53c79a656109"), 1, "Tech enthusiast", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1857), new DateTime(1988, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@user3.com", "Michael", 0, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1858), "Smith", null, "password3", "3456789012", "/profile/profile3.jpg", 1, "user3" },
                    { new Guid("57716c51-dc6e-40b3-a05c-a8f75a7b6dad"), 1, "A food lover who enjoys exploring different cuisines and local delicacies during my travels. Food brings people together!", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1972), new DateTime(1982, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "foodexplorer@example.com", "Daniel", 0, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1973), "Baker", null, "foodlover", "4567890123", "/profile/daniel_baker.jpg", 0, "traveling_foodie" },
                    { new Guid("97439595-a2f4-4542-8e2d-6d4b0d0790cb"), 1, "Avid reader", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1845), new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@user1.com", "John", 0, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1846), "Doe", null, "password1", "1234567890", "/profile/profile1.jpg", 1, "user1" },
                    { new Guid("a8348939-3a49-41b9-8ecb-38450738b427"), 1, "Traveler", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1862), new DateTime(1992, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@user4.com", "Emily", 1, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1863), "Davis", null, "password4", "4567890123", "/profile/profile4.jpg", 1, "user4" },
                    { new Guid("ac2cd922-1e8e-4290-bf43-812f337d8ee1"), 1, "Bio information for Nguyen Van Dung.", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1754), new DateTime(2002, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dungkinaysinhviengioi@gmail.com", "Nguyen", 0, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1755), "Van Dung", null, "Dunghocgioivcl", "0123456789", "/profile/dungnv.jpg", 2, "vandung" },
                    { new Guid("af953084-bf02-4575-9d01-cc66e64c20a8"), 1, "Food enthusiast and home cook. I enjoy experimenting with flavors and creating delightful dishes for my family and friends.", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1923), new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.foodie@example.com", "Emily", 0, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1924), "Johnson", null, "emily1234", "2345678901", "/profile/emily_johnson.jpg", 0, "emily_foods" },
                    { new Guid("b4d4ee62-73f8-4840-9b49-2af666463a68"), 1, "Bio information for Jane Smith.", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1689), new DateTime(1990, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", 1, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1690), "Smith", null, "p@ssw0rd", "9876543210", "/profile/jane_smith.jpg", 2, "jane_smith" },
                    { new Guid("b88631cd-ae6c-4556-8064-9187f1929796"), 1, "Bio information for Sara Wilson.", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1731), new DateTime(1992, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.wilson@example.com", "Sara", 1, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1732), "Wilson", null, "sara123", "1112223333", "/profile/sara_wilson.jpg", 2, "sara_wilson" },
                    { new Guid("d2dcddd7-2b61-4ff1-8c82-97334a4515b5"), 1, "Passionate about healthy living and clean eating. Sharing my journey towards a healthier lifestyle through nutritious meals.", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1929), new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "healthymeals@example.com", "Alice", 1, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1929), "Green", null, "healthyeats", "3456789012", "/profile/alice_green.jpg", 0, "healthy_eater" },
                    { new Guid("e152821d-70bf-47af-8746-5c5486ca552a"), 1, "Nature lover", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1851), new DateTime(1985, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@user2.com", "Alice", 1, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1852), "Johnson", null, "password2", "2345678901", "/profile/profile2.jpg", 1, "user2" },
                    { new Guid("f0797d34-f3bf-41f1-aad6-d227cff1a99e"), 1, "Bio information for Mike Jackson.", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1737), new DateTime(1980, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mike.jackson@example.com", "Mike", 0, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1738), "Jackson", null, "mikepass", "3334445555", "/profile/mike_jackson.jpg", 2, "mike_jackson" },
                    { new Guid("f0db6432-7483-4d2c-82b0-bcef1fdb1d04"), 1, "Bio information for Bob Jones.", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1696), new DateTime(1988, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.jones@example.com", "Bob", 0, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1697), "Jones", null, "strongpass123", "5556667777", "/profile/bob_jones.jpg", 2, "bob_jones" }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActived", "LastModifiedDate", "ModifiedBy", "Name" },
                values: new object[] { new Guid("6724c547-1b11-48ad-8bf0-4c1e8bf54ab8"), null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1997), "Thanh toan qua vi dien tu momo", (byte)1, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1998), null, "Momo" });

            migrationBuilder.InsertData(
                table: "Chef",
                columns: new[] { "Id", "AccountId", "Awards", "CreatedBy", "CreatedDate", "Experience", "LastModifiedDate", "ModifiedBy" },
                values: new object[,]
                {
                    { new Guid("0e8417e4-32a4-4e34-bfcb-a1babceef173"), new Guid("97439595-a2f4-4542-8e2d-6d4b0d0790cb"), "Best Chef 2022", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1816), "Experienced Chef", new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1817), null },
                    { new Guid("36251f06-e1a8-447a-a14c-06c217215a06"), new Guid("a8348939-3a49-41b9-8ecb-38450738b427"), "Culinary Excellence Award 2022", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1827), "Gourmet Chef", new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1828), null },
                    { new Guid("5849ced6-f47f-4d3b-a46f-2a40c0d711fc"), new Guid("1e1f19be-3c5f-413f-b5cc-2e4f21e8132f"), "Michelin Star Chef 2022", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1830), "Executive Chef", new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1830), null },
                    { new Guid("70d7faf7-74f2-4144-b537-32d84b03bad4"), new Guid("e152821d-70bf-47af-8746-5c5486ca552a"), "Best Chef 2022", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1819), "Experienced Chef", new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1820), null },
                    { new Guid("9cf3c8f4-db9f-4f2e-9aa8-1107c8a44494"), new Guid("566d3f29-ea8f-425c-a7c7-53c79a656109"), "Top Chef 2022", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1823), "Master Chef", new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1823), null }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "AccountId", "Address", "CreatedBy", "CreatedDate", "LastModifiedDate", "ModifiedBy", "RewardsPoints" },
                values: new object[,]
                {
                    { new Guid("0db1a7a2-153f-4194-9281-93f2fb351e7f"), new Guid("57716c51-dc6e-40b3-a05c-a8f75a7b6dad"), "101 Pine St", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1898), new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1899), null, 250 },
                    { new Guid("53b1274c-c23d-4aa2-9442-fc4baf75843f"), new Guid("d2dcddd7-2b61-4ff1-8c82-97334a4515b5"), "789 Oak St", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1894), new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1894), null, 150 },
                    { new Guid("b9f14590-70fb-4379-a3e3-616d8da859f4"), new Guid("180070e0-1b3a-4758-9892-a4de860f3d37"), "202 Maple St", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1901), new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1902), null, 300 },
                    { new Guid("d0d1e6dd-fae7-42ab-a912-4db59222e87c"), new Guid("2631d4d8-ffb0-4a27-9057-e0838efcf758"), "123 Main St", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1888), new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1888), null, 100 },
                    { new Guid("e6244496-049b-471c-950f-366beac0e4e2"), new Guid("af953084-bf02-4575-9d01-cc66e64c20a8"), "456 Elm St", null, new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1891), new DateTime(2023, 10, 22, 0, 11, 29, 264, DateTimeKind.Local).AddTicks(1891), null, 200 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("1890281f-fe26-40ba-aaad-3b3c74e65c32"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("18b56e56-6ff5-4089-a4ac-2496bac13879"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("2a117f10-93c8-4cc7-aee3-dbe85b3fa773"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("42ce4c18-119b-4cf9-aeb1-2224b3d54bc2"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("44472ea7-1744-424d-a95d-122e0420897b"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("4c66f0e4-4ca0-4b6a-803f-9efb2b9914a0"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("ac2cd922-1e8e-4290-bf43-812f337d8ee1"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("b4d4ee62-73f8-4840-9b49-2af666463a68"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("b88631cd-ae6c-4556-8064-9187f1929796"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("f0797d34-f3bf-41f1-aad6-d227cff1a99e"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("f0db6432-7483-4d2c-82b0-bcef1fdb1d04"));

            migrationBuilder.DeleteData(
                table: "Chef",
                keyColumn: "Id",
                keyValue: new Guid("0e8417e4-32a4-4e34-bfcb-a1babceef173"));

            migrationBuilder.DeleteData(
                table: "Chef",
                keyColumn: "Id",
                keyValue: new Guid("36251f06-e1a8-447a-a14c-06c217215a06"));

            migrationBuilder.DeleteData(
                table: "Chef",
                keyColumn: "Id",
                keyValue: new Guid("5849ced6-f47f-4d3b-a46f-2a40c0d711fc"));

            migrationBuilder.DeleteData(
                table: "Chef",
                keyColumn: "Id",
                keyValue: new Guid("70d7faf7-74f2-4144-b537-32d84b03bad4"));

            migrationBuilder.DeleteData(
                table: "Chef",
                keyColumn: "Id",
                keyValue: new Guid("9cf3c8f4-db9f-4f2e-9aa8-1107c8a44494"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("0db1a7a2-153f-4194-9281-93f2fb351e7f"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("53b1274c-c23d-4aa2-9442-fc4baf75843f"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("b9f14590-70fb-4379-a3e3-616d8da859f4"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("d0d1e6dd-fae7-42ab-a912-4db59222e87c"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("e6244496-049b-471c-950f-366beac0e4e2"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "Id",
                keyValue: new Guid("6724c547-1b11-48ad-8bf0-4c1e8bf54ab8"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("180070e0-1b3a-4758-9892-a4de860f3d37"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("1e1f19be-3c5f-413f-b5cc-2e4f21e8132f"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("2631d4d8-ffb0-4a27-9057-e0838efcf758"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("566d3f29-ea8f-425c-a7c7-53c79a656109"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("57716c51-dc6e-40b3-a05c-a8f75a7b6dad"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("97439595-a2f4-4542-8e2d-6d4b0d0790cb"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("a8348939-3a49-41b9-8ecb-38450738b427"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("af953084-bf02-4575-9d01-cc66e64c20a8"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("d2dcddd7-2b61-4ff1-8c82-97334a4515b5"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("e152821d-70bf-47af-8746-5c5486ca552a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 21, 23, 57, 23, 98, DateTimeKind.Local).AddTicks(6494),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 22, 0, 11, 29, 267, DateTimeKind.Local).AddTicks(8968));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Dish",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 21, 23, 57, 23, 97, DateTimeKind.Local).AddTicks(8693),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 22, 0, 11, 29, 267, DateTimeKind.Local).AddTicks(1993));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 21, 23, 57, 23, 96, DateTimeKind.Local).AddTicks(9153),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 22, 0, 11, 29, 266, DateTimeKind.Local).AddTicks(3577));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Campaign",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 21, 23, 57, 23, 95, DateTimeKind.Local).AddTicks(9393),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 22, 0, 11, 29, 265, DateTimeKind.Local).AddTicks(6062));

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "ActiveStatus", "Bio", "CreatedBy", "CreatedDate", "DateOfBirth", "Email", "FirstName", "Gender", "LastModifiedDate", "LastName", "ModifiedBy", "Password", "PhoneNumber", "ProfilePicture", "Roles", "Username" },
                values: new object[,]
                {
                    { new Guid("012aca4f-c4d5-46d9-99b3-e4401225e0e6"), 1, "Passionate about baking and pastry creations. Join me on my baking adventures as I explore the art of sweets and treats!", null, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(142), new DateTime(1989, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "baker@example.com", "Olivia", 1, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(143), "Miller", null, "bakeitup", "5678901234", "/profile/olivia_miller.jpg", 0, "baking_enthusiast" },
                    { new Guid("02956bac-0bbe-4c15-a17c-4e6f2a522feb"), 1, "Bio information for John Doe.", null, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9857), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", 0, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9870), "Doe", null, "securepassword1", "1234567890", "/profile/john_doe.jpg", 1, "john_doe" },
                    { new Guid("1fef46c3-43f6-4655-b59c-a80a7cb45435"), 1, "Bio information for Truong Le Tuan Kiet.", null, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9924), new DateTime(2002, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "kiethathayvai@gmail.com", "Truong", 0, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9925), "Le Tuan Kiet", null, "Kiethocgioihayhat", "0123456789", "/profile/kiettlt.jpg", 2, "truongletuankiet" },
                    { new Guid("2340d1ba-a8e0-424a-a766-a58237276fdc"), 1, "Bio information for Nguyen Van Dung.", null, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9919), new DateTime(2002, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dungkinaysinhviengioi@gmail.com", "Nguyen", 0, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9920), "Van Dung", null, "Dunghocgioivcl", "0123456789", "/profile/dungnv.jpg", 2, "vandung" },
                    { new Guid("2934d1c2-8a26-4fe5-9f09-893ca0d9ea34"), 1, "Bio information for Jane Smith.", null, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9879), new DateTime(1990, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", 1, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9880), "Smith", null, "p@ssw0rd", "9876543210", "/profile/jane_smith.jpg", 2, "jane_smith" },
                    { new Guid("378dd1b0-6093-4f09-9263-dab7f7cb6c33"), 1, "Bio information for Nguyen Duc Binh.", null, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9973), new DateTime(2002, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ducbinhnguyen@gmail.com", "Nguyen", 0, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9974), "Duc Binh", null, "binhleader", "0123456789", "/profile/binhnd.jpg", 2, "ducbinhnguyen" },
                    { new Guid("38aa379e-6afc-45a4-aae3-55c95fc61fa0"), 1, "Traveler", null, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(68), new DateTime(1992, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@user4.com", "Emily", 1, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(69), "Davis", null, "password4", "4567890123", "/profile/profile4.jpg", 1, "user4" },
                    { new Guid("3cc53ffd-c6e1-4799-b92a-a00eee75a819"), 1, "Passionate about healthy living and clean eating. Sharing my journey towards a healthier lifestyle through nutritious meals.", null, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(131), new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "healthymeals@example.com", "Alice", 1, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(132), "Green", null, "healthyeats", "3456789012", "/profile/alice_green.jpg", 0, "healthy_eater" },
                    { new Guid("4175020c-de24-442f-a41f-ec0905a1e104"), 1, "Food enthusiast and home cook. I enjoy experimenting with flavors and creating delightful dishes for my family and friends.", null, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(125), new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.foodie@example.com", "Emily", 0, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(126), "Johnson", null, "emily1234", "2345678901", "/profile/emily_johnson.jpg", 0, "emily_foods" },
                    { new Guid("49f78a61-6df7-42cb-94d0-550395bc3496"), 1, "Bio information for Nguyen Phat.", null, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9907), new DateTime(2002, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenphat2711@gmail.com", "Nguyen", 0, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9908), "Phat", null, "Phat@2711", "0812400096", "/profile/phatnt.jpg", 2, "fatnofat" },
                    { new Guid("4e602db6-caff-49b5-bb75-7df95d768b07"), 1, "Bio information for Sara Wilson.", null, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9895), new DateTime(1992, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.wilson@example.com", "Sara", 1, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9896), "Wilson", null, "sara123", "1112223333", "/profile/sara_wilson.jpg", 2, "sara_wilson" },
                    { new Guid("53caeba3-e329-4047-b690-9eb249cef0a8"), 1, "Bio information for Le Thi Thu Trang.", null, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9965), new DateTime(2002, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "trangxinhgai@gmail.com", "Le", 1, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9966), "Thi Thu Trang", null, "trangxinhxinhhihi", "0123456789", "/profile/trangltt.jpg", 2, "trangxinhgai" },
                    { new Guid("7029db3b-50ed-438b-bafb-65586980044a"), 1, "I love exploring new cuisines and trying out different recipes. Excited to be a part of this culinary community!", null, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(119), new DateTime(1988, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.customer@example.com", "John", 0, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(120), "Smith", null, "customer123", "1234567890", "/profile/john_smith.jpg", 0, "johncustomer" },
                    { new Guid("81954452-ec22-4ef5-9d41-b21adb17ba27"), 1, "Bio information for Mike Jackson.", null, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9901), new DateTime(1980, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mike.jackson@example.com", "Mike", 0, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9902), "Jackson", null, "mikepass", "3334445555", "/profile/mike_jackson.jpg", 2, "mike_jackson" },
                    { new Guid("828c7efb-be6c-4857-ab21-18cdf9904e72"), 1, "Fitness enthusiast", null, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(74), new DateTime(1983, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5@user5.com", "Daniel", 0, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(75), "Brown", null, "password5", "5678901234", "/profile/profile5.jpg", 1, "user5" },
                    { new Guid("8b0457eb-63d6-428b-948e-785fe240586f"), 1, "Bio information for Bob Jones.", null, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9889), new DateTime(1988, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.jones@example.com", "Bob", 0, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9890), "Jones", null, "strongpass123", "5556667777", "/profile/bob_jones.jpg", 2, "bob_jones" },
                    { new Guid("92993ec9-77d2-4ff6-90b8-c0e3a6427cc9"), 1, "Tech enthusiast", null, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(62), new DateTime(1988, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@user3.com", "Michael", 0, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(63), "Smith", null, "password3", "3456789012", "/profile/profile3.jpg", 1, "user3" },
                    { new Guid("ab8126b8-1f2d-4d4c-9abb-2f30b904ad9e"), 1, "A food lover who enjoys exploring different cuisines and local delicacies during my travels. Food brings people together!", null, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(137), new DateTime(1982, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "foodexplorer@example.com", "Daniel", 0, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(137), "Baker", null, "foodlover", "4567890123", "/profile/daniel_baker.jpg", 0, "traveling_foodie" },
                    { new Guid("b33ca62c-381c-4347-8f2a-2db885ac4f77"), 1, "Avid reader", null, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(50), new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@user1.com", "John", 0, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(51), "Doe", null, "password1", "1234567890", "/profile/profile1.jpg", 1, "user1" },
                    { new Guid("d3bb63ce-dc1c-4cc8-b3ce-2911db427220"), 1, "Nature lover", null, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(56), new DateTime(1985, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@user2.com", "Alice", 1, new DateTime(2023, 10, 21, 23, 57, 23, 94, DateTimeKind.Local).AddTicks(57), "Johnson", null, "password2", "2345678901", "/profile/profile2.jpg", 1, "user2" },
                    { new Guid("f9f8fae5-4a6d-4cc4-9ebe-7f49cff0d50d"), 1, "Bio information for Nguyen Phat.", null, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9913), new DateTime(2002, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "khoatruong@gmail.com", "Truong", 0, new DateTime(2023, 10, 21, 23, 57, 23, 93, DateTimeKind.Local).AddTicks(9914), "Khoa", null, "Khoa2k17", "0123456789", "/profile/phatnt.jpg", 2, "khoatruong" }
                });

            migrationBuilder.InsertData(
                table: "Chef",
                columns: new[] { "Id", "AccountId", "Awards", "CreatedBy", "CreatedDate", "Experience", "LastModifiedDate", "ModifiedBy" },
                values: new object[,]
                {
                    { new Guid("43dce280-ea22-42ba-b222-c13a4c60c8d9"), new Guid("b33ca62c-381c-4347-8f2a-2db885ac4f77"), "Best Chef 2022", null, null, "Experienced Chef", null, null },
                    { new Guid("d57b28eb-64fe-4080-909f-ccf2334902df"), new Guid("828c7efb-be6c-4857-ab21-18cdf9904e72"), "Michelin Star Chef 2022", null, null, "Executive Chef", null, null },
                    { new Guid("e77983ed-d25d-4da3-8870-0575809559c1"), new Guid("92993ec9-77d2-4ff6-90b8-c0e3a6427cc9"), "Top Chef 2022", null, null, "Master Chef", null, null },
                    { new Guid("f03d1f11-823c-4a47-96e7-0dc20108253c"), new Guid("38aa379e-6afc-45a4-aae3-55c95fc61fa0"), "Culinary Excellence Award 2022", null, null, "Gourmet Chef", null, null },
                    { new Guid("f05a66c7-8afb-4f5f-adb6-32b678ee82fb"), new Guid("d3bb63ce-dc1c-4cc8-b3ce-2911db427220"), "Best Chef 2022", null, null, "Experienced Chef", null, null }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "AccountId", "Address", "CreatedBy", "CreatedDate", "LastModifiedDate", "ModifiedBy", "RewardsPoints" },
                values: new object[,]
                {
                    { new Guid("1943384f-15e6-49f3-95ee-8d8dbb7342fc"), new Guid("7029db3b-50ed-438b-bafb-65586980044a"), "123 Main St", null, null, null, null, 100 },
                    { new Guid("1a244d93-176f-46c0-9d61-88fa18ab76e2"), new Guid("4175020c-de24-442f-a41f-ec0905a1e104"), "456 Elm St", null, null, null, null, 200 },
                    { new Guid("403ec21a-1c56-48cb-9b3d-1ba7592cbcca"), new Guid("3cc53ffd-c6e1-4799-b92a-a00eee75a819"), "789 Oak St", null, null, null, null, 150 },
                    { new Guid("73e6bb46-5c0e-4645-bf62-f9ad613bc89d"), new Guid("ab8126b8-1f2d-4d4c-9abb-2f30b904ad9e"), "101 Pine St", null, null, null, null, 250 },
                    { new Guid("943c6bdf-94a9-49b9-8953-7bf70c7c3548"), new Guid("012aca4f-c4d5-46d9-99b3-e4401225e0e6"), "202 Maple St", null, null, null, null, 300 }
                });
        }
    }
}
