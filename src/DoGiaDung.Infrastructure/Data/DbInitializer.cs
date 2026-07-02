using DoGiaDung.Domain.Entities;

namespace DoGiaDung.Infrastructure.Data;

/// <summary>
/// Seed dữ liệu ban đầu — chạy 1 lần khi app start.
/// </summary>
public static class DbInitializer
{
    public static async Task SeedAsync(AppDbContext db)
    {
        if (db.SysDictionaries.Any()) return; // đã seed rồi

        var seeds = new List<SysDictionary>
        {
            // === ES (default) ===
            new() { LngTp = "ES", ColCd = "NAV_HOME", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Inicio" },
            new() { LngTp = "ES", ColCd = "NAV_PRODUCT", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Productos" },
            new() { LngTp = "ES", ColCd = "NAV_CONTACT", ColCdTp = "0", SortSeq = 3, ColCdTpNm = "Contacto" },
            new() { LngTp = "ES", ColCd = "NAV_ABOUT", ColCdTp = "0", SortSeq = 4, ColCdTpNm = "Sobre Nosotros" },
            new() { LngTp = "ES", ColCd = "NAV_LOGIN", ColCdTp = "0", SortSeq = 5, ColCdTpNm = "Iniciar Sesión" },
            new() { LngTp = "ES", ColCd = "NAV_REGISTER", ColCdTp = "0", SortSeq = 6, ColCdTpNm = "Registrarse" },
            new() { LngTp = "ES", ColCd = "NAV_LOGOUT", ColCdTp = "0", SortSeq = 7, ColCdTpNm = "Cerrar Sesión" },
            new() { LngTp = "ES", ColCd = "NAV_CART", ColCdTp = "0", SortSeq = 8, ColCdTpNm = "Carrito" },
            new() { LngTp = "ES", ColCd = "NAV_DASHBOARD", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Panel" },
            new() { LngTp = "ES", ColCd = "NAV_ADM_PRODUCTS", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Productos" },
            new() { LngTp = "ES", ColCd = "NAV_ADM_CATALOGS", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Categorías" },
            new() { LngTp = "ES", ColCd = "BTN_ADD_TO_CART", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Añadir al Carrito" },
            new() { LngTp = "ES", ColCd = "BTN_CHECKOUT", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Pagar" },
            new() { LngTp = "ES", ColCd = "BTN_LOGIN", ColCdTp = "0", SortSeq = 3, ColCdTpNm = "Entrar" },
            new() { LngTp = "ES", ColCd = "BTN_SEARCH", ColCdTp = "0", SortSeq = 4, ColCdTpNm = "Buscar" },
            new() { LngTp = "ES", ColCd = "BTN_SAVE", ColCdTp = "0", SortSeq = 5, ColCdTpNm = "Guardar" },
            new() { LngTp = "ES", ColCd = "BTN_CANCEL", ColCdTp = "0", SortSeq = 6, ColCdTpNm = "Cancelar" },
            new() { LngTp = "ES", ColCd = "BTN_EDIT", ColCdTp = "0", SortSeq = 7, ColCdTpNm = "Editar" },
            new() { LngTp = "ES", ColCd = "BTN_DELETE", ColCdTp = "0", SortSeq = 8, ColCdTpNm = "Eliminar" },
            new() { LngTp = "ES", ColCd = "BTN_BACK_HOME", ColCdTp = "0", SortSeq = 9, ColCdTpNm = "Volver a inicio" },
            new() { LngTp = "ES", ColCd = "TTL_HOME", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Inicio" },
            new() { LngTp = "ES", ColCd = "TTL_PRODUCTS", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Productos" },
            new() { LngTp = "ES", ColCd = "TTL_LOGIN", ColCdTp = "0", SortSeq = 3, ColCdTpNm = "Iniciar Sesión" },
            new() { LngTp = "ES", ColCd = "TTL_REGISTER", ColCdTp = "0", SortSeq = 4, ColCdTpNm = "Crear Cuenta" },
            new() { LngTp = "ES", ColCd = "TTL_CART", ColCdTp = "0", SortSeq = 5, ColCdTpNm = "Carrito" },
            new() { LngTp = "ES", ColCd = "LBL_EMAIL", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Correo electrónico" },
            new() { LngTp = "ES", ColCd = "LBL_PASSWORD", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Contraseña" },
            new() { LngTp = "ES", ColCd = "LBL_PRICE", ColCdTp = "0", SortSeq = 3, ColCdTpNm = "Precio" },
            new() { LngTp = "ES", ColCd = "LBL_QUANTITY", ColCdTp = "0", SortSeq = 4, ColCdTpNm = "Cantidad" },
            new() { LngTp = "ES", ColCd = "LBL_TOTAL", ColCdTp = "0", SortSeq = 5, ColCdTpNm = "Total" },
            new() { LngTp = "ES", ColCd = "MSG_WELCOME", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Bienvenido a DoGiaDung — tu tienda de artículos para el hogar." },
            new() { LngTp = "ES", ColCd = "MSG_LOGIN_ERR", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Correo o contraseña inválidos." },
            new() { LngTp = "ES", ColCd = "MSG_ORDER_SUCCESS", ColCdTp = "0", SortSeq = 3, ColCdTpNm = "¡Pedido realizado con éxito!" },
            new() { LngTp = "ES", ColCd = "MSG_EMPTY_CART", ColCdTp = "0", SortSeq = 4, ColCdTpNm = "Tu carrito está vacío." },
            new() { LngTp = "ES", ColCd = "MSG_VAT_INCLUDED", ColCdTp = "0", SortSeq = 5, ColCdTpNm = "IVA incluido" },
            new() { LngTp = "ES", ColCd = "MSG_IN_STOCK", ColCdTp = "0", SortSeq = 6, ColCdTpNm = "En stock" },
            new() { LngTp = "ES", ColCd = "MSG_OUT_OF_STOCK", ColCdTp = "0", SortSeq = 7, ColCdTpNm = "Agotado" },
            new() { LngTp = "ES", ColCd = "MSG_ERROR", ColCdTp = "0", SortSeq = 8, ColCdTpNm = "Error" },
            new() { LngTp = "ES", ColCd = "MSG_DASHBOARD_WELCOME", ColCdTp = "0", SortSeq = 9, ColCdTpNm = "Bienvenido al panel de administración." },
            new() { LngTp = "ES", ColCd = "MSG_CONFIRM_DELETE", ColCdTp = "0", SortSeq = 10, ColCdTpNm = "¿Estás seguro de eliminar este elemento?" },
            new() { LngTp = "ES", ColCd = "FT_COPYRIGHT", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "© 2026 DoGiaDung — Todos los derechos reservados" },
            new() { LngTp = "ES", ColCd = "PLH_EMAIL", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "tu@email.com" },
            new() { LngTp = "ES", ColCd = "PLH_SEARCH", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Buscar..." },
            new() { LngTp = "ES", ColCd = "TBL_PRODUCT_NAME", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Nombre" },
            new() { LngTp = "ES", ColCd = "TBL_ACTIONS", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Acciones" },

            // === EN ===
            new() { LngTp = "EN", ColCd = "NAV_HOME", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Home" },
            new() { LngTp = "EN", ColCd = "NAV_PRODUCT", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Products" },
            new() { LngTp = "EN", ColCd = "NAV_CONTACT", ColCdTp = "0", SortSeq = 3, ColCdTpNm = "Contact" },
            new() { LngTp = "EN", ColCd = "NAV_ABOUT", ColCdTp = "0", SortSeq = 4, ColCdTpNm = "About Us" },
            new() { LngTp = "EN", ColCd = "NAV_LOGIN", ColCdTp = "0", SortSeq = 5, ColCdTpNm = "Login" },
            new() { LngTp = "EN", ColCd = "NAV_REGISTER", ColCdTp = "0", SortSeq = 6, ColCdTpNm = "Register" },
            new() { LngTp = "EN", ColCd = "NAV_LOGOUT", ColCdTp = "0", SortSeq = 7, ColCdTpNm = "Logout" },
            new() { LngTp = "EN", ColCd = "NAV_CART", ColCdTp = "0", SortSeq = 8, ColCdTpNm = "Cart" },
            new() { LngTp = "EN", ColCd = "NAV_DASHBOARD", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Dashboard" },
            new() { LngTp = "EN", ColCd = "NAV_ADM_PRODUCTS", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Products" },
            new() { LngTp = "EN", ColCd = "BTN_ADD_TO_CART", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Add to Cart" },
            new() { LngTp = "EN", ColCd = "BTN_CHECKOUT", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Checkout" },
            new() { LngTp = "EN", ColCd = "BTN_LOGIN", ColCdTp = "0", SortSeq = 3, ColCdTpNm = "Login" },
            new() { LngTp = "EN", ColCd = "BTN_SEARCH", ColCdTp = "0", SortSeq = 4, ColCdTpNm = "Search" },
            new() { LngTp = "EN", ColCd = "BTN_SAVE", ColCdTp = "0", SortSeq = 5, ColCdTpNm = "Save" },
            new() { LngTp = "EN", ColCd = "BTN_CANCEL", ColCdTp = "0", SortSeq = 6, ColCdTpNm = "Cancel" },
            new() { LngTp = "EN", ColCd = "TTL_HOME", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Home" },
            new() { LngTp = "EN", ColCd = "TTL_PRODUCTS", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Products" },
            new() { LngTp = "EN", ColCd = "TTL_CART", ColCdTp = "0", SortSeq = 3, ColCdTpNm = "Shopping Cart" },
            new() { LngTp = "EN", ColCd = "LBL_EMAIL", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Email" },
            new() { LngTp = "EN", ColCd = "LBL_PASSWORD", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Password" },
            new() { LngTp = "EN", ColCd = "LBL_PRICE", ColCdTp = "0", SortSeq = 3, ColCdTpNm = "Price" },
            new() { LngTp = "EN", ColCd = "MSG_WELCOME", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Welcome to DoGiaDung — your home goods store." },
            new() { LngTp = "EN", ColCd = "MSG_LOGIN_ERR", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Invalid email or password." },
            new() { LngTp = "EN", ColCd = "MSG_ORDER_SUCCESS", ColCdTp = "0", SortSeq = 3, ColCdTpNm = "Order placed successfully!" },
            new() { LngTp = "EN", ColCd = "MSG_EMPTY_CART", ColCdTp = "0", SortSeq = 4, ColCdTpNm = "Your cart is empty." },
            new() { LngTp = "EN", ColCd = "MSG_VAT_INCLUDED", ColCdTp = "0", SortSeq = 5, ColCdTpNm = "VAT included" },
            new() { LngTp = "EN", ColCd = "FT_COPYRIGHT", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "© 2026 DoGiaDung — All rights reserved" },
            new() { LngTp = "EN", ColCd = "PLH_EMAIL", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "your@email.com" },
            new() { LngTp = "EN", ColCd = "TBL_PRODUCT_NAME", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Name" },
            new() { LngTp = "EN", ColCd = "TBL_ACTIONS", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Actions" },

            // === VI ===
            new() { LngTp = "VI", ColCd = "NAV_HOME", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Trang chủ" },
            new() { LngTp = "VI", ColCd = "NAV_PRODUCT", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Sản phẩm" },
            new() { LngTp = "VI", ColCd = "NAV_CONTACT", ColCdTp = "0", SortSeq = 3, ColCdTpNm = "Liên hệ" },
            new() { LngTp = "VI", ColCd = "NAV_ABOUT", ColCdTp = "0", SortSeq = 4, ColCdTpNm = "Giới thiệu" },
            new() { LngTp = "VI", ColCd = "NAV_LOGIN", ColCdTp = "0", SortSeq = 5, ColCdTpNm = "Đăng nhập" },
            new() { LngTp = "VI", ColCd = "NAV_REGISTER", ColCdTp = "0", SortSeq = 6, ColCdTpNm = "Đăng ký" },
            new() { LngTp = "VI", ColCd = "NAV_LOGOUT", ColCdTp = "0", SortSeq = 7, ColCdTpNm = "Đăng xuất" },
            new() { LngTp = "VI", ColCd = "NAV_CART", ColCdTp = "0", SortSeq = 8, ColCdTpNm = "Giỏ hàng" },
            new() { LngTp = "VI", ColCd = "NAV_DASHBOARD", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Bảng điều khiển" },
            new() { LngTp = "VI", ColCd = "BTN_ADD_TO_CART", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Thêm vào giỏ" },
            new() { LngTp = "VI", ColCd = "BTN_CHECKOUT", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Thanh toán" },
            new() { LngTp = "VI", ColCd = "TTL_HOME", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Trang chủ" },
            new() { LngTp = "VI", ColCd = "TTL_PRODUCTS", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Sản phẩm" },
            new() { LngTp = "VI", ColCd = "LBL_EMAIL", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Email" },
            new() { LngTp = "VI", ColCd = "LBL_PASSWORD", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Mật khẩu" },
            new() { LngTp = "VI", ColCd = "LBL_PRICE", ColCdTp = "0", SortSeq = 3, ColCdTpNm = "Giá" },
            new() { LngTp = "VI", ColCd = "MSG_WELCOME", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Chào mừng đến với DoGiaDung!" },
            new() { LngTp = "VI", ColCd = "MSG_LOGIN_ERR", ColCdTp = "0", SortSeq = 2, ColCdTpNm = "Sai thông tin đăng nhập." },
            new() { LngTp = "VI", ColCd = "MSG_ORDER_SUCCESS", ColCdTp = "0", SortSeq = 3, ColCdTpNm = "Đặt hàng thành công!" },
            new() { LngTp = "VI", ColCd = "MSG_EMPTY_CART", ColCdTp = "0", SortSeq = 4, ColCdTpNm = "Giỏ hàng trống." },
            new() { LngTp = "VI", ColCd = "MSG_IN_STOCK", ColCdTp = "0", SortSeq = 5, ColCdTpNm = "Còn hàng" },
            new() { LngTp = "VI", ColCd = "MSG_OUT_OF_STOCK", ColCdTp = "0", SortSeq = 6, ColCdTpNm = "Hết hàng" },
            new() { LngTp = "VI", ColCd = "FT_COPYRIGHT", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "© 2026 DoGiaDung — Đã đăng ký bản quyền" },
            new() { LngTp = "VI", ColCd = "PLH_EMAIL", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "email@cua.ban" },
            new() { LngTp = "VI", ColCd = "TBL_PRODUCT_NAME", ColCdTp = "0", SortSeq = 1, ColCdTpNm = "Tên" },
        };

        db.SysDictionaries.AddRange(seeds);
        await db.SaveChangesAsync();
    }
}
