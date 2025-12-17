🚀 Blogy - AI Destekli Modern Blog Platformu
Blogy, .NET Core teknolojileri ve N-Katmanlı Mimari (N-Layer Architecture) prensipleri kullanılarak geliştirilmiş kapsamlı bir içerik yönetim sistemidir.

Bu projeyi diğerlerinden ayıran en önemli özellik; Google Gemini AI entegrasyonu sayesinde kullanıcı yorumlarının yapay zeka tarafından analiz edilerek, hakaret veya zararlı içerik barındıran yorumların otomatik olarak filtrelenmesidir.

🌟 Öne Çıkan Özellikler
🤖 Yapay Zeka Destekli Moderasyon: Google Gemini API kullanılarak yorumlar anlık analiz edilir. "Toxic" (Zararlı) içerikler veritabanına kaydedilmeden reddedilir.

🏗️ N-Katmanlı Mimari: Sürdürülebilir, test edilebilir ve gevşek bağlı (loosely coupled) kod yapısı.

👥 Rol Bazlı Yönetim (Areas): * Admin Paneli: Tüm site yönetimi, kullanıcı, rol ve kategori işlemleri.

Writer Paneli: Yazarların kendi bloglarını oluşturup düzenleyebileceği özel alan.

🔐 Güvenlik: ASP.NET Core Identity ile üyelik, giriş ve yetkilendirme işlemleri.

🧩 ViewComponents: Tekrar eden arayüz parçaları (Yorum listesi, Sidebar, vb.) için modüler yapı.

💾 Entity Framework Core: Code-First yaklaşımı ile veritabanı yönetimi.

🔄 DTO & AutoMapper: Veri transferi ve nesne dönüşümleri için profesyonel yapı.

🛠️ Teknolojiler ve Araçlar
Backend: ASP.NET Core, C#

ORM: Entity Framework Core

AI Entegrasyonu: Google Generative AI SDK (Gemini)

Frontend: HTML5, CSS3, Bootstrap 5, JQuery

Diğer Kütüphaneler: AutoMapper, FluentValidation

📂 Mimari Yapı
Proje 4 ana katmandan oluşmaktadır:

Entity Layer: Veritabanı tablolarına karşılık gelen somut sınıflar.

DataAccess Layer: Veritabanı CRUD işlemleri ve Context yapılandırması.

Business Layer: İş kuralları, validasyonlar ve AI servis entegrasyonu.

WebUI (Presentation): Kullanıcı arayüzü, Controller'lar ve View'lar.
