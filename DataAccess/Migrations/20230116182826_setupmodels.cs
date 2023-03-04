using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class setupmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
-- Add all iPhone models
DECLARE @iPhoneDeviceTypeId TINYINT = 1;
DECLARE @iPadDeviceTypeId TINYINT = 2;

INSERT INTO dbo.Models
(Id, Name, ImageUrl, DeviceTypeId)
VALUES
(1, 'iPhone 6', 'you.com/proxy?url=https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.ggpmmncOv3hUZ-FEN20oxwHaHa%26pid%3DApi', @iPhoneDeviceTypeId),
(2, 'iPhone 6s', 'you.com/proxy?url=https%3A%2F%2Ftse4.mm.bing.net%2Fth%3Fid%3DOIP.84Qx22MvwgoCeOUsV0QpMwHaHa%26pid%3DApi', @iPhoneDeviceTypeId),
(3, 'iPhone 7', 'you.com/search?q=iphone%207&fromSearchBar=true&tbm=isch&activeImage=%7B%22name%22%3A%22Apple%20iPhone%207%2032GB%20128GB%20256GB%20A1778%20Factory%20Unlocked%20*Brand%20New%20...%22%2C%22description%22%3Anull%2C%22publisher%22%3A%5B%7B%22name%22%3A%22Alegre%22%2C%22parsed%22%3Atrue%7D%5D%2C%22sourceUrl%22%3A%22alegre.net.au%22%2C%22url%22%3A%22https%3A%2F%2Fwholesale.alegre.net.au%2Fassets%2Ffull%2FS-iPhone-7-ALL-NIB.jpg%3F20210309042950%22%2C%22thumbnailUrl%22%3A%22https%3A%2F%2Ftse4.mm.bing.net%2Fth%3Fid%3DOIP.CJzmFkBQa_9pO0a280cT6QHaHa%26pid%3DApi%22%2C%22hostPageUrl%22%3A%22https%3A%2F%2Fwholesale.alegre.net.au%2F~2641%22%2C%22width%22%3A1600%2C%22height%22%3A1600%2C%22imageInsightsToken%22%3A%22ccid_CJzmFkBQ*cp_4CBF286FB91583B3C4B2FB88F90BB8F2*mid_38BAC59AECF787D7A8B64A76835B3F9EA16BF0B7*simid_607999092871214980*thid_OIP.CJzmFkBQa!_9pO0a280cT6QHaHa%22%7D', @iPhoneDeviceTypeId),
(4, 'iPhone 7 Plus', 'you.com/search?q=iphone%207&fromSearchBar=true&tbm=isch&activeImage=%7B%22name%22%3A%22Refurbished%20Apple%20iPhone%207%20Plus%20128GB%2C%20Jet%20Black%20-%20Locked%20AT%26T%20...%22%2C%22description%22%3Anull%2C%22publisher%22%3A%5B%7B%22name%22%3A%22Walmart%22%2C%22parsed%22%3Atrue%7D%5D%2C%22sourceUrl%22%3A%22walmart.com%22%2C%22url%22%3A%22https%3A%2F%2Fi5.walmartimages.com%2Fasr%2F0d234958-39b5-419c-b646-16089e4fcc9e_1.de480d586a1b3278916cef420e567470.jpeg%3FodnWidth%3D1000%26odnHeight%3D1000%26odnBg%3Dffffff%22%2C%22thumbnailUrl%22%3A%22https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.NJYOOr9kSjHOVJww5aS5zAHaHa%26pid%3DApi%22%2C%22hostPageUrl%22%3A%22https%3A%2F%2Fwww.walmart.com%2Fip%2FRefurbished-Apple-iPhone-7-Plus-128GB-Jet-Black-Locked-AT-T%2F663999960%22%2C%22width%22%3A1000%2C%22height%22%3A1000%2C%22imageInsightsToken%22%3A%22ccid_NJYOOr9k*cp_2DBF1F2390962501857418ED0FDF0B12*mid_2B0816D6EE1E0B33D8F5AF45B65218F4B5B9F9DE*simid_608051860846883057*thid_OIP.NJYOOr9kSjHOVJww5aS5zAHaHa%22%7D', @iPhoneDeviceTypeId),
(5, 'iPhone 8', 'you.com/search?q=iphone%208&fromSearchBar=true&tbm=isch&activeImage=%7B%22name%22%3A%22Refurbished%20iPhone%208%2064GB%20-%20Red%20-%20T-Mobile%20%7C%20Back%20Market%22%2C%22description%22%3Anull%2C%22publisher%22%3A%5B%7B%22name%22%3A%22Backmarket%22%2C%22parsed%22%3Atrue%7D%5D%2C%22sourceUrl%22%3A%22backmarket.com%22%2C%22url%22%3A%22https%3A%2F%2Fd28i4xct2kl5lp.cloudfront.net%2Fproduct_images%2F1564757259.45.jpg%22%2C%22thumbnailUrl%22%3A%22https%3A%2F%2Ftse4.mm.bing.net%2Fth%3Fid%3DOIP.L1isamAQtr6qqBM6rf-hSQHaHa%26pid%3DApi%22%2C%22hostPageUrl%22%3A%22https%3A%2F%2Fwww.backmarket.com%2Ftested-and-certified-used-iphone-8-64-gb-red-t-mobile%2F40506.html%22%2C%22width%22%3A1200%2C%22height%22%3A1200%2C%22imageInsightsToken%22%3A%22ccid_L1isamAQ*cp_42B6793CE9FE80E1696FE660C689AF1D*mid_1D14170F1792FDF834B65FC1C224C3A9240D6EDF*simid_608016066582487171*thid_OIP.L1isamAQtr6qqBM6rf-hSQHaHa%22%7D', @iPhoneDeviceTypeId),
(6, 'iPhone 8 Plus', 'you.com/search?q=iphone%208%20plus&fromSearchBar=true&tbm=isch&activeImage=%7B%22name%22%3A%22Simple%20Mobile%20Prepaid%20Apple%20iPhone%208%20Plus%2064GB%2C%20Gold%20-%20Walmart.com%22%2C%22description%22%3Anull%2C%22publisher%22%3A%5B%7B%22name%22%3A%22Walmart%22%2C%22parsed%22%3Atrue%7D%5D%2C%22sourceUrl%22%3A%22walmart.com%22%2C%22url%22%3A%22https%3A%2F%2Fi5.walmartimages.com%2Fasr%2Fe84ab2e3-a979-4c60-97cf-b29bcd13fa66_1.73c9f51b0ff563a6aa7a675e0625e547.jpeg%22%2C%22thumbnailUrl%22%3A%22https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.cBpM0RiQu4kUhUQV82NPDQHaHa%26pid%3DApi%22%2C%22hostPageUrl%22%3A%22https%3A%2F%2Fwww.walmart.com%2Fip%2FSimple-Mobile-Prepaid-Apple-iPhone-8-Plus-64GB-Gold%2F511501106%22%2C%22width%22%3A2000%2C%22height%22%3A2000%2C%22imageInsightsToken%22%3A%22ccid_cBpM0RiQ*cp_3710177E3D0D12BBA78DC5B13EFCF951*mid_EF9727E05AC500373FC11220BD81DC083CE503D4*simid_608039839225943587*thid_OIP.cBpM0RiQu4kUhUQV82NPDQHaHa%22%7D', @iPhoneDeviceTypeId),
(7, 'iPhone X', 'you.com/search?q=iphone%20x&fromSearchBar=true&tbm=isch&activeImage=%7B%22name%22%3A%22Apple%20iPhone%20X%2064GB%20256GB%20Brand%20New%20Sealed%20Box%22%2C%22description%22%3Anull%2C%22publisher%22%3A%5B%7B%22name%22%3A%22Alegre%22%2C%22parsed%22%3Atrue%7D%5D%2C%22sourceUrl%22%3A%22alegre.net.au%22%2C%22url%22%3A%22https%3A%2F%2Fwholesale.alegre.net.au%2Fassets%2Ffull%2FS-IPHX-ALL-NIB.jpg%3F20201026105128%22%2C%22thumbnailUrl%22%3A%22https%3A%2F%2Ftse2.mm.bing.net%2Fth%3Fid%3DOIP.RzRHAUUfUTGFPDqmeD_4mQHaHa%26pid%3DApi%22%2C%22hostPageUrl%22%3A%22https%3A%2F%2Fwholesale.alegre.net.au%2Fapple-iphone-x-64gb-256gb-brand-new-sealed-box%22%2C%22width%22%3A1300%2C%22height%22%3A1300%2C%22imageInsightsToken%22%3A%22ccid_RzRHAUUf*cp_B3A770E07686144F5AB3DE4152B47499*mid_98663A09E668E30A40D6BFA4EE879622D2DE287F*simid_607997473670912563*thid_OIP.RzRHAUUfUTGFPDqmeD!_4mQHaHa%22%7D', @iPhoneDeviceTypeId),
(8, 'iPad Air 2', 'you.com/search?q=apple%20ipad%20air%202&fromSearchBar=true&tbm=isch&activeImage=%7B%22name%22%3A%22Apple%2016GB%20iPad%20Air%202%20(Wi-Fi%20%2B%204G%20LTE%2C%20Space%20Gray)%20MH2U2LL%2FA%20B%26H%22%2C%22description%22%3Anull%2C%22publisher%22%3A%5B%7B%22name%22%3A%22Bhphotovideo%22%2C%22parsed%22%3Atrue%7D%5D%2C%22sourceUrl%22%3A%22bhphotovideo.com%22%2C%22url%22%3A%22https%3A%2F%2Fwww.bhphotovideo.com%2Fimages%2Fimages2500x2500%2Fapple_mh2u2ll_a_16gb_ipad_air_2_1086703.jpg%22%2C%22thumbnailUrl%22%3A%22https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.tXoptUUKxqhns1c6fzSLTQHaHa%26pid%3DApi%22%2C%22hostPageUrl%22%3A%22https%3A%2F%2Fwww.bhphotovideo.com%2Fc%2Fproduct%2F1086703-REG%2Fapple_mh2u2ll_a_16gb_ipad_air_2.html%22%2C%22width%22%3A2500%2C%22height%22%3A2500%2C%22imageInsightsToken%22%3A%22ccid_tXoptUUK*cp_B34CD6193A95C0FC1BF4AB20AF67AE4E*mid_5C649081D28899A514953668D4F18CF875E291E4*simid_608026404562761705*thid_OIP.tXoptUUKxqhns1c6fzSLTQHaHa%22%7D', @iPadDeviceTypeId);
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DELETE FROM dbo.Models;
            ");
        }
    }
}
