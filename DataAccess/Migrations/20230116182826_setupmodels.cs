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

INSERT INTO dbo.Models
(Id, Name, ImageUrl, DeviceTypeId)
VALUES
(1, 'iPhone 6', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPI616GGRUNLB_l.jpg', @iPhoneDeviceTypeId),
(2, 'iPhone 6 Plus', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPI6P64GGRUNLB_l.jpg', @iPhoneDeviceTypeId),
(3, 'iPhone 6s', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPI6S32GSGUNLB_l.jpg', @iPhoneDeviceTypeId),
(4, 'iPhone 6s Plus', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPI6SP32GSGUNLC_l.jpg', @iPhoneDeviceTypeId),
(5, 'iPhone 7', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPI732GBLUNLB_l.jpg', @iPhoneDeviceTypeId),
(6, 'iPhone 7 Plus', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPI7P32GBLUNLB_l.jpg', @iPhoneDeviceTypeId),
(7, 'iPhone 8', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPI864GGRUNLB_l.jpg', @iPhoneDeviceTypeId),
(8, 'iPhone 8 Plus', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPI8P64GGRUNLB_l.jpg', @iPhoneDeviceTypeId),
(9, 'iPhone XR', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPIXR64GBUNLB_l.jpg',  @iPhoneDeviceTypeId),
(10, 'iPhone X', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPIX64GGRUNLB_l.jpg', @iPhoneDeviceTypeId),
(11, 'iPhone XS', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPIXS64GSGUNLB_l.jpg', @iPhoneDeviceTypeId),
(12, 'iPhone XS Max', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPIXSM64GSGUNLB_l.jpg', @iPhoneDeviceTypeId),
(13, 'iPhone 11', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPI1164GBUNLB_l.jpg', @iPhoneDeviceTypeId),
(14, 'iPhone 11 Pro', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPI11P64GMGUNLB_l.jpg', @iPhoneDeviceTypeId),
(15, 'iPhone 11 Pro Max', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPI11PM64GSGUNLB_l.jpg', @iPhoneDeviceTypeId),
(16, 'iPhone 12', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPI1264GBUNLB_l.jpg', @iPhoneDeviceTypeId),
(17, 'iPhone 12 Pro', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPI12P128GPBUNLB_l.jpg', @iPhoneDeviceTypeId),
(18, 'iPhone 12 Pro Max', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPI12PM128GPBUNLB_l.jpg', @iPhoneDeviceTypeId),
(19, 'iPhone 12 Mini', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPI12M64GBLUNLB_l.jpg', @iPhoneDeviceTypeId),
(20, 'iPhone 13', 'https://uk.static.webuy.com/product_images/Phones/Phones%20iPhone/SAPPI13128GMUNLB_l.jpg', @iPhoneDeviceTypeId),
(21, 'iPhone 13 Mini', 'https://webuyanyphone.com/uploads/images/products/apple-iphone-13-mini-4919-0.png', @iPhoneDeviceTypeId),
(22, 'iPhone 13 Pro', 'https://webuyanyphone.com/uploads/images/products/apple-iphone-13-pro-1114-0.png', @iPhoneDeviceTypeId),
(23, 'iPhone 13 Pro Max', 'https://webuyanyphone.com/uploads/images/products/apple-iphone-13-pro-max-7735-0.png', @iPhoneDeviceTypeId),
(24, 'iPhone 14', 'https://webuyanyphone.com/uploads/images/products/apple-iphone-14-6250-0.png', @iPhoneDeviceTypeId),
(25, 'iPhone 14 Plus', 'https://webuyanyphone.com/uploads/images/products/apple-iphone-14-plus-6222-0.png', @iPhoneDeviceTypeId),
(26, 'iPhone 14 Pro', 'https://webuyanyphone.com/uploads/images/products/apple-iphone-14-pro-8350-0.png', @iPhoneDeviceTypeId),
(27, 'iPhone 14 Pro Max', 'https://webuyanyphone.com/uploads/images/products/apple-iphone-14-pro-max-7986-0.png', @iPhoneDeviceTypeId);
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
