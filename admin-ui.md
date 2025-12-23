# Gelişmiş Admin Arayüzü (_AdminLayout.cshtml) Tasarım ve Uygulama Betimlemesi

Bu belge, projenin "Admin" alanı için oluşturulacak olan `_AdminLayout.cshtml` dosyasının detaylı yapısını, görsel tasarımını ve teknik gereksinimlerini betimler. Amaç, standart `_Layout.cshtml`'den ayrı, modern, kullanışlı ve kapsamlı bir yönetici paneli arayüzü oluşturmaktır.

## 1. Genel Konsept ve Yapı

Oluşturulacak arayüz, solda sabit bir navigasyon menüsü (sidebar), üstte bir başlık çubuğu (header/topbar) ve merkezde dinamik içeriğin yükleneceği bir ana alan olmak üzere üç ana bölümden oluşacaktır. Tasarım, Bootstrap 5 bileşenleri üzerine inşa edilecek ve mobil uyumlu (responsive) olacaktır.

**Hedeflenen Görünüm:**

*   **Sol Taraf (Sidebar):** Proje logosu, panel başlığı ve ikonlarla desteklenmiş menü linkleri (Dashboard, Projeler, Kategoriler vb.). Bu menü, daraltılıp genişletilebilir bir yapıda olacaktır.
*   **Üst Taraf (Header):** Sidebar'ı açıp kapatacak bir "hamburger" menü butonu, genel bir arama çubuğu ve kullanıcı adı/profili ile çıkış yapma gibi seçenekleri içeren bir dropdown menü.
*   **İçerik Alanı (Main Content):** `@RenderBody()` ile render edilecek olan asıl sayfa içeriğinin (listeler, formlar, detaylar) gösterileceği, temiz ve ferah bir alan.

## 2. Dosya Yapısı ve Konumlandırma

1.  **Layout Dosyası:**
    *   **Konum:** `Areas/Admin/Views/Shared/_AdminLayout.cshtml`
    *   **Amaç:** Admin alanındaki tüm view'lar için ana şablon görevi görecek.

2.  **ViewStart Dosyası:**
    *   **Konum:** `Areas/Admin/Views/_ViewStart.cshtml`
    *   **İçerik:**
        ```csharp
        @{
            Layout = "_AdminLayout";
        }
        ```
    *   **Amaç:** Admin alanı içindeki tüm view'ların varsayılan olarak `_AdminLayout.cshtml` dosyasını kullanmasını sağlamak.

3.  **Yardımcı Statik Dosyalar:**
    *   **CSS:** `wwwroot/css/admin-layout.css` (Panele özel tüm stiller bu dosyada toplanacak).
    *   **JS:** `wwwroot/js/admin-layout.js` (Sidebar'ı açma/kapama gibi interaktif işlevler için gerekli JavaScript kodları burada yer alacak).

## 3. Teknik ve HTML Yapısı (`_AdminLayout.cshtml`)

Aşağıda, `_AdminLayout.cshtml` dosyasının temel HTML iskeleti ve bileşenleri detaylandırılmıştır.

```html
<!DOCTYPE html>
<html lang="tr">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"] - Admin Paneli</title>
    
    <!-- Bootstrap & İkon Kütüphanesi -->
    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css">

    <!-- Özel Admin Stil Dosyası -->
    <link rel="stylesheet" href="~/css/site.css" />
    <link rel="stylesheet" href="~/css/admin-layout.css" />
</head>
<body>
    <div class="d-flex" id="wrapper">
        <!-- 1. Sidebar -->
        <div class="border-end bg-light" id="sidebar-wrapper">
            <div class="sidebar-heading border-bottom bg-light">
                <i class="bi bi-shield-lock"></i> Admin Paneli
            </div>
            <div class="list-group list-group-flush">
                <a class="list-group-item list-group-item-action p-3" asp-area="Admin" asp-controller="Home" asp-action="Index">
                    <i class="bi bi-speedometer2 me-2"></i> Dashboard
                </a>
                <a class="list-group-item list-group-item-action p-3" asp-area="Admin" asp-controller="Projects" asp-action="Index">
                    <i class="bi bi-kanban me-2"></i> Projeler
                </a>
                <a class="list-group-item list-group-item-action p-3" asp-area="Admin" asp-controller="Categories" asp-action="Index">
                    <i class="bi bi-tags me-2"></i> Kategoriler
                </a>
                <a class="list-group-item list-group-item-action p-3" asp-area="" asp-controller="Home" asp-action="Index">
                    <i class="bi bi-box-arrow-left me-2"></i> Siteye Dön
                </a>
            </div>
        </div>

        <!-- 2. Sayfa İçeriği Wrapper -->
        <div id="page-content-wrapper">
            <!-- Header / Top Nav -->
            <nav class="navbar navbar-expand-lg navbar-light bg-light border-bottom">
                <div class="container-fluid">
                    <button class="btn btn-primary" id="sidebarToggle"><i class="bi bi-list"></i></button>

                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>

                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav ms-auto mt-2 mt-lg-0">
                            <li class="nav-item dropdown">
                                <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <i class="bi bi-person-circle me-1"></i> Yönetici
                                </a>
                                <div class="dropdown-menu dropdown-menu-end" aria-labelledby="navbarDropdown">
                                    <a class="dropdown-item" href="#">Profil</a>
                                    <div class="dropdown-divider"></div>
                                    <a class="dropdown-item" href="#">Çıkış Yap</a>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>

            <!-- Ana İçerik Alanı -->
            <main class="container-fluid p-4">
                @RenderBody()
            </main>
        </div>
    </div>

    <!-- Gerekli Script Dosyaları -->
    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <script src="~/js/admin-layout.js"></script>
    @await RenderSectionAsync("Scripts", required: false)
</body>
</html>

```

## 4. Stil Detayları (`admin-layout.css`)

Bu dosya, layout'un iskeletini fonksiyonal hale getirecek ve görsel estetiği sağlayacak CSS kurallarını içerir.

```css
/* Gerekli temel stiller ve sidebar'ın gizlenip gösterilmesi */
#wrapper {
    overflow-x: hidden;
}

#sidebar-wrapper {
    min-height: 100vh;
    margin-left: -15rem; /* Sidebar'ı başlangıçta gizle */
    transition: margin 0.25s ease-out;
}

#sidebar-wrapper .sidebar-heading {
    padding: 0.875rem 1.25rem;
    font-size: 1.2rem;
    font-weight: bold;
}

#sidebar-wrapper .list-group {
    width: 15rem;
}

#page-content-wrapper {
    min-width: 100vw;
}

/* Sidebar aktif (görünür) olduğunda uygulanacak stiller */
#wrapper.toggled #sidebar-wrapper {
    margin-left: 0;
}

/* Sidebar'ın içeriği itmesi için medya sorgusu */
@media (min-width: 768px) {
    #sidebar-wrapper {
        margin-left: 0;
    }

    #page-content-wrapper {
        min-width: 0;
        width: 100%;
    }

    #wrapper.toggled #sidebar-wrapper {
        margin-left: -15rem;
    }
}

/* Menü linkleri için hover efekti */
.list-group-item-action:hover {
    background-color: #e9ecef;
    color: #0d6efd;
    font-weight: bold;
}
.list-group-item i {
    font-size: 1.1rem;
}
```

## 5. JavaScript İşlevselliği (`admin-layout.js`)

Sidebar'ın açılıp kapanmasını sağlayacak basit JavaScript (jQuery ile) kodu.

```javascript
$(document).ready(function() {
    // Sidebar'ı açma/kapama butonu için event listener
    $("#sidebarToggle").on("click", function() {
        $("#wrapper").toggleClass("toggled");
    });
});
```

## 6. Uygulama Adımları Özeti

1.  **Dosyaları Oluştur:** Yukarıda belirtilen `_AdminLayout.cshtml`, `_ViewStart.cshtml`, `admin-layout.css` ve `admin-layout.js` dosyalarını ilgili konumlarda oluşturun.
2.  **İçerikleri Kopyala:** Bu belgede verilen kod bloklarını ilgili dosyalara yapıştırın.
3.  **İkon Kütüphanesini Ekle:** `_AdminLayout.cshtml`'in `<head>` bölümüne Bootstrap Icons CDN linkinin eklendiğinden emin olun.
4.  **Projeyi Derle ve Çalıştır:** Projeyi çalıştırın ve `/Admin` yoluna giderek yeni layout'un doğru bir şekilde görünüp görünmediğini, sidebar'ın açılıp kapandığını ve linklerin çalıştığını test edin.

Bu yapı, gelecekte eklenecek yeni özellikler (bildirimler, daha karmaşık menüler vb.) için genişletilebilir ve sağlam bir temel sunar.
