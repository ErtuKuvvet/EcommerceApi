# 🛒 E-Ticaret Backend REST API (.NET 9)

Bu proje, **.NET 9** kullanılarak geliştirilmiş, **Katmanlı Mimari (N-Layer Architecture)** prensiplerine dayanan bir E-Ticaret REST API uygulamasıdır. SOLID prensiplerine uygun olarak tasarlanmış olup, veri tutarlılığı, hata yönetimi ve modern backend standartlarını içermektedir.

---

## 1. Proje Açıklaması

Bu API, bir e-ticaret sisteminin temel backend işlemlerini gerçekleştirir. Proje, hem klasik **Controller** yapısını hem de .NET'in yeni özelliği olan **Minimal API** yapısını hibrit olarak kullanır.

**Temel Özellikler:**
* **Ürün ve Kategori Yönetimi:** İlişkisel veritabanı yapısıyla ürün ve kategori takibi.
* **Sipariş Sistemi:** Stok kontrolü yapılarak sipariş oluşturulur ve stok otomatik düşülür.
* **Teknoloji Stack:** .NET 9, Entity Framework Core, SQLite.
* **Standart Response:** Tüm cevaplar `success`, `message` ve `data` içeren standart bir formatta döner.
* **Hata Yönetimi:** Global Exception Handling Middleware ile merkezi hata yönetimi.

---

## 2. Mimari Diagram

Proje, sorumlulukların ayrılması (SoC) ilkesine göre katmanlara ayrılmıştır. Veri akışı istemciden veritabanına şu şekilde ilerler:

```text
[ İSTEMCİ / SWAGGER ]
         ⬇
[ ECOMMERCE.API ] (Sunum Katmanı - Controllers & Minimal Endpoints)
         ⬇
[ ECOMMERCE.SERVICE ] (İş Mantığı - Validations - DTO Mapping)
         ⬇
[ ECOMMERCE.DATA ] (Veri Katmanı - EF Core - Migrations)
         ⬇
[ SQLITE DATABASE ]

3. Endpoint Listesi
Projede aşağıdaki API uç noktaları (endpoints) bulunmaktadır:

📦 Ürünler (Products)
Yöntem: Controller API

GET /api/Products -> Tüm ürünleri kategori isimleriyle birlikte listeler.

POST /api/Products -> Yeni ürün ekler. (Başarılı ise 201 Created döner).

📂 Kategoriler (Categories)
Yöntem: Minimal API (.NET 9 Modern Yöntem)

GET /api/categories -> Tüm kategorileri listeler.

POST /api/categories -> Yeni kategori ekler. (Başarılı ise 201 Created döner).

🛒 Siparişler (Orders)
Yöntem: Controller API

GET /api/Orders -> Tüm siparişleri listeler.

POST /api/Orders -> Sipariş oluşturur. (Sistem otomatik olarak stok kontrolü yapar ve stoğu düşer).


4. API Response Örnekleri
API'den dönen tüm cevaplar standart bir formatta (Wrapper Pattern) sunulmaktadır.

A) Başarılı Yanıt Örneği (Success):
{
  "success": true,
  "message": "İşlem başarıyla tamamlandı.",
  "data": {
    "id": 1,
    "name": "Oyuncu Bilgisayarı",
    "price": 35000,
    "stock": 4,
    "categoryName": "Teknoloji"
  }
}

B) İş Mantığı Hatası Örneği (Stok Yetersiz - 400 Bad Request):
{
  "success": false,
  "message": "Yetersiz stok! Mevcut stok: 3",
  "data": null
}

C) Sunucu Hatası Örneği (Global Exception Handler - 500 Internal Server Error): Sistemde beklenmeyen bir hata oluştuğunda Middleware devreye girer.
{
  "success": false,
  "message": "Sunucu tarafında beklenmeyen bir hata oluştu. Lütfen daha sonra tekrar deneyin.",
  "errorDetail": "Hata detayı loglanmıştır."
}

5. Kurulum Talimatları
Projeyi bilgisayarınızda çalıştırmak için terminali açıp sırasıyla şu komutları uygulayın:

git clone https://github.com/ErtuKuvvet/EcommerceApi.git

cd EcommerceApi

dotnet restore

dotnet ef database update --project Ecommerce.Data --startup-project Ecommerce.Api

dotnet run --project Ecommerce.Api

