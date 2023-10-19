using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("3f2c2327-3b07-4fa9-9bff-e5e1857710ba"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("5800c4f2-1bce-41a7-a909-92b0336f8b37"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("65d650ab-7e48-4f34-927e-b99a4768a1cf"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("67abe55d-4cac-4c23-9d32-2395f181fae1"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("8da4e108-36a0-4135-9987-ae45ad0a2182"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("9a757dcc-dc7c-45e2-90f7-059e8eec4f0f"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("a7929b50-8471-455e-9768-05bc9dc3014c"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("a8aadcaf-92cc-4bf7-abd1-4b9ce4646505"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("ed855c6c-63e4-46c4-b713-576aeabcd011"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("f29edd2d-34a9-43cc-bea8-66ead19921c8"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("f82e0e64-c90b-4426-89de-7edae9fcd661"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 18, 14, 11, 10, 440, DateTimeKind.Local).AddTicks(6214),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 8, 16, 33, 19, 21, DateTimeKind.Local).AddTicks(8843));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Dish",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 18, 14, 11, 10, 439, DateTimeKind.Local).AddTicks(4377),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 8, 16, 33, 19, 20, DateTimeKind.Local).AddTicks(5064));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 18, 14, 11, 10, 438, DateTimeKind.Local).AddTicks(3464),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 8, 16, 33, 19, 18, DateTimeKind.Local).AddTicks(7670));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Campaign",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 18, 14, 11, 10, 436, DateTimeKind.Local).AddTicks(3764),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 8, 16, 33, 19, 16, DateTimeKind.Local).AddTicks(1655));

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "ActiveStatus", "Bio", "CreatedBy", "CreatedDate", "DateOfBirth", "Email", "FirstName", "Gender", "LastModifiedDate", "LastName", "ModifiedBy", "Password", "PhoneNumber", "ProfilePicture", "Roles", "Username" },
                values: new object[,]
                {
                    { new Guid("00937687-83ec-47f1-9637-960a28105814"), 1, "Bio information for Nguyen Phat.", null, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1804), new DateTime(2002, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenphat2711@gmail.com", "Nguyen", 0, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1805), "Phat", null, "Phat@2711", "0812400096", "/profile/phatnt.jpg", 2, "fatnofat" },
                    { new Guid("3dbf76b7-eeee-4486-b7d0-c430bcc88602"), 1, "Bio information for Bob Jones.", null, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1704), new DateTime(1988, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.jones@example.com", "Bob", 0, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1705), "Jones", null, "strongpass123", "5556667777", "/profile/bob_jones.jpg", 2, "bob_jones" },
                    { new Guid("8f657bac-bc92-44ae-867f-7ad7833de1e7"), 1, "Bio information for Le Thi Thu Trang.", null, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1835), new DateTime(2002, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "trangxinhgai@gmail.com", "Le", 1, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1836), "Thi Thu Trang", null, "trangxinhxinhhihi", "0123456789", "/profile/trangltt.jpg", 2, "trangxinhgai" },
                    { new Guid("911e020c-1a4d-4076-ac6d-207f8f13b547"), 1, "Bio information for John Doe.", null, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1657), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", 0, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1668), "Doe", null, "securepassword1", "1234567890", "/profile/john_doe.jpg", 1, "john_doe" },
                    { new Guid("91b8c88c-ae6e-45d6-be11-def8b575c5de"), 1, "Bio information for Mike Jackson.", null, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1795), new DateTime(1980, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mike.jackson@example.com", "Mike", 0, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1796), "Jackson", null, "mikepass", "3334445555", "/profile/mike_jackson.jpg", 2, "mike_jackson" },
                    { new Guid("94d842db-bc47-4096-b97e-4d469f9157fb"), 1, "Bio information for Jane Smith.", null, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1695), new DateTime(1990, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", 1, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1697), "Smith", null, "p@ssw0rd", "9876543210", "/profile/jane_smith.jpg", 2, "jane_smith" },
                    { new Guid("a0df0eaf-792c-431b-a30a-741a58e7dc5f"), 1, "Bio information for Nguyen Van Dung.", null, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1820), new DateTime(2002, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dungkinaysinhviengioi@gmail.com", "Nguyen", 0, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1821), "Van Dung", null, "Dunghocgioivcl", "0123456789", "/profile/dungnv.jpg", 2, "vandung" },
                    { new Guid("a78417e7-e75e-46d1-a282-cd49c3cd1173"), 1, "Bio information for Sara Wilson.", null, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1728), new DateTime(1992, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.wilson@example.com", "Sara", 1, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1729), "Wilson", null, "sara123", "1112223333", "/profile/sara_wilson.jpg", 2, "sara_wilson" },
                    { new Guid("bfbe2c0f-2963-47b1-bd69-95e4d1e03f28"), 1, "Bio information for Nguyen Phat.", null, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1811), new DateTime(2002, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "khoatruong@gmail.com", "Truong", 0, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1812), "Khoa", null, "Khoa2k17", "0123456789", "/profile/phatnt.jpg", 2, "khoatruong" },
                    { new Guid("c8f957db-d796-4ce1-b5b1-587b22101689"), 1, "Bio information for Truong Le Tuan Kiet.", null, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1826), new DateTime(2002, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "kiethathayvai@gmail.com", "Truong", 0, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1827), "Le Tuan Kiet", null, "Kiethocgioihayhat", "0123456789", "/profile/kiettlt.jpg", 2, "truongletuankiet" },
                    { new Guid("cdb21f5d-2fad-415b-bac1-a90a7ffb40e5"), 1, "Bio information for Nguyen Duc Binh.", null, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1840), new DateTime(2002, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ducbinhnguyen@gmail.com", "Nguyen", 0, new DateTime(2023, 10, 18, 14, 11, 10, 435, DateTimeKind.Local).AddTicks(1841), "Duc Binh", null, "binhleader", "0123456789", "/profile/binhnd.jpg", 2, "ducbinhnguyen" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("00937687-83ec-47f1-9637-960a28105814"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("3dbf76b7-eeee-4486-b7d0-c430bcc88602"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("8f657bac-bc92-44ae-867f-7ad7833de1e7"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("911e020c-1a4d-4076-ac6d-207f8f13b547"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("91b8c88c-ae6e-45d6-be11-def8b575c5de"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("94d842db-bc47-4096-b97e-4d469f9157fb"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("a0df0eaf-792c-431b-a30a-741a58e7dc5f"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("a78417e7-e75e-46d1-a282-cd49c3cd1173"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("bfbe2c0f-2963-47b1-bd69-95e4d1e03f28"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("c8f957db-d796-4ce1-b5b1-587b22101689"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("cdb21f5d-2fad-415b-bac1-a90a7ffb40e5"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Order");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 8, 16, 33, 19, 21, DateTimeKind.Local).AddTicks(8843),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 18, 14, 11, 10, 440, DateTimeKind.Local).AddTicks(6214));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Dish",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 8, 16, 33, 19, 20, DateTimeKind.Local).AddTicks(5064),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 18, 14, 11, 10, 439, DateTimeKind.Local).AddTicks(4377));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 8, 16, 33, 19, 18, DateTimeKind.Local).AddTicks(7670),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 18, 14, 11, 10, 438, DateTimeKind.Local).AddTicks(3464));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Campaign",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 8, 16, 33, 19, 16, DateTimeKind.Local).AddTicks(1655),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 18, 14, 11, 10, 436, DateTimeKind.Local).AddTicks(3764));

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
        }
    }
}
