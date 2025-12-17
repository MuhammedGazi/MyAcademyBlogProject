<div align="center">

<img src="https://capsule-render.vercel.app/api?type=waving&color=gradient&height=300&section=header&text=Blogy&fontSize=90&animation=fadeIn&fontAlignY=38&desc=AI%20Powered%20.NET%20Blog%20Platform&descAlignY=51&descAlign=62" alt="Blogy Header"/>

<br/>

<img src="https://img.shields.io/badge/.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
<img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" />
<img src="https://img.shields.io/badge/Google%20Gemini-4285F4?style=for-the-badge&logo=google&logoColor=white" />
<img src="https://img.shields.io/badge/MSSQL-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" />
<img src="https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=.net&logoColor=white" />
<img src="https://img.shields.io/badge/Bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white" />

<br/><br/>

<h3>🚀 N-Katmanlı Mimari ve Yapay Zeka ile Güçlendirilmiş Modern Blog Deneyimi</h3>

<p>
  <strong>Blogy</strong>, kullanıcı yorumlarını <strong>Google Gemini AI</strong> ile analiz ederek zararlı içerikleri (küfür, hakaret) otomatik olarak engelleyen,
  Admin ve Yazar panelleri ayrılmış, güvenli ve ölçeklenebilir bir blog platformudur.
</p>

<br/>
</div>

<hr/>

## 🌟 Projenin Öne Çıkan Özellikleri

| Özellik | Açıklama | Teknoloji |
| :--- | :--- | :--- |
| **🤖 AI Moderasyon** | Yorumlar Gemini API ile analiz edilir, "Toxic" içerik engellenir. | `Google Generative AI` |
| **🏗️ N-Tier Mimari** | Sürdürülebilir, gevşek bağlı (loosely coupled) profesyonel yapı. | `Clean Architecture` |
| **👥 Rol Yönetimi** | **Admin** (Tam Yetki) ve **Writer** (İçerik Üretici) panelleri ayrılmıştır. | `ASP.NET Identity` & `Areas` |
| **🎨 Modern Arayüz** | ViewComponent yapısı ile modüler ve şık frontend tasarımı. | `Bootstrap 5` & `Razor` |

---


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
