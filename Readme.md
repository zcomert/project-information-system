# Project Information System (PIS)

## Proje Tanımı

Bu repo, ASP.NET Core MVC ile geliştirilen bir Proje Bilgi Sisteminin katmanlı yapısını ortaya koyar. Uygulama, `Controllers/` üzerinden gelen HTTP taleplerini `Services/` katmanında işleyip `Repositories/` katmanıyla veri erişimine taşır; `Models/` ise alan modellerini ve ilişkileri tanımlar. 

Yönetim tarafı `Areas/Admin/` altında ayrı bir alan (Area) olarak kurgulanmış; burada projeler, kategoriler ve kullanıcılar için CRUD akışları ile bir gösterge paneli (Dashboard) bulunur. Ön yüz Razor görünümleriyle `Views/` altında düzenlenmiş, statik varlıklar `wwwroot/` içerisinde tutulmuş, veri kalıcılığı EF Core ve SQLite ile sağlanmış, kimlik doğrulama/rol yönetimi ise ASP.NET Core Identity üzerinden yapılandırılmıştır. 

`Options/`, `Migrations/` ve `UMLs/` klasörleri sırasıyla yapılandırma, veritabanı evrimi ve tasarım dokümantasyonunu destekler.

## Teknolojiler

- **ASP.NET Core MVC** - Web uygulama çatısı
- **C#** - Programlama dili
- **.NET 8.0** - Framework
- **Entity Framework Core** - ORM (Object-Relational Mapping)
- **SQLite** - Veritabanı
- **ASP.NET Core Identity** - Kimlik doğrulama ve yetkilendirme
- **Razor Views** - Görünüm motoru
- **Bootstrap** - CSS framework
- **jQuery** - JavaScript kütüphanesi
- **jQuery Validation** - Form doğrulama

## Teknik Kazanımlar

- **Mimari ve katmanlama**: Controller-Service-Repository ayrımıyla sorumlulukların netleştirilmesi, arayüz (contract) odaklı geliştirme ve bağımlılık enjeksiyonu (DI) kullanımı.
- **Veri erişimi ve ORM**: EF Core `DbContext`, `DbSet`, ilişkisel modelleme (Project-Category), SQLite kalıcılığı, seed veriler ve migration yaklaşımı.
- **Kimlik doğrulama ve yetkilendirme**: ASP.NET Core Identity ile kullanıcı/rol yönetimi, admin-user ayrımı, cookie tabanlı oturum ve yetkisiz erişim yönlendirmeleri.
- **MVC ve UI akışları**: Razor View'lar, ViewModel kullanımı, form doğrulamaları (DataAnnotations) ve Area tabanlı yönlendirme yapısı.
- **Yapılandırma ve uygulama altyapısı**: `appsettings` üzerinden bağlantı ayarları, Options pattern ile admin kimlik bilgileri, statik dosya yönetimi ve temel yönlendirme kuralları.

## Eğitimin Seviyesi ve Niteliği

Bu proje, **YZM201 - Yazılım Tasarımı ve Modelleme** dersi kapsamında geliştirilmiştir ve **lisans düzeyinde** bir öğrenme deneyimi sunmaktadır. Eğitim programı, teorik bilgilerin pratik uygulamalarla pekiştirilmesini hedefler ve öğrencilere şu becerileri kazandırmayı amaçlar:

- **Yazılım mimarisi ve tasarım desenleri** bilgisini gerçek dünya senaryolarında uygulama
- **Katmanlı mimari** yaklaşımıyla ölçeklenebilir ve sürdürülebilir sistemler geliştirme
- **Modern web teknolojileri** ve framework'leri kullanarak profesyonel standartlarda kod yazma
- **Veritabanı tasarımı** ve ORM araçlarıyla veri yönetimi konusunda yetkinlik kazanma
- **Güvenlik ve kimlik doğrulama** mekanizmalarını entegre etme
- **Kod dokümantasyonu** ve UML diyagramları ile tasarım süreçlerini görselleştirme

Proje, sadece teknik becerilerin geliştirilmesinin ötesinde, öğrencilerin **analitik düşünme**, **problem çözme** ve **mühendislik disiplini** kazanmalarını destekleyen akademik bir yaklaşımla yapılandırılmıştır.

## Akademik Perspektif

Doç. Dr. Zafer CÖMERT, araştırmacı kimliğiyle problem tanımı, yöntem seçimi ve bilimsel düşünme disiplinini merkeze alan bir yaklaşımı teşvik eder. Akademisyen yönüyle ise öğrenciyi sadece "çalışan" yazılıma değil, tasarım kararlarının gerekçelendirilmesine, sürdürülebilir mimari kurmaya ve öğrenme sürecini sistematik biçimde yönetmeye yönlendirir. 

Bu projede benimsenen katmanlı mimari, rol bazlı yetkilendirme ve veri odaklı karar mekanizmaları, bu akademik perspektifin uygulamaya yansıyan örnekleridir.


