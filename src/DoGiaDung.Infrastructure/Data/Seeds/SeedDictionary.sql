-- ============================================================
-- SEED DATA: SYS_DICTIONARY — 3 ngôn ngữ (ES/EN/VI)
-- Dành cho DoGiaDung.vn (.NET 10)
-- ============================================================
-- Usage: chạy sau khi migration, hoặc thêm vào AppDbContext.OnModelCreating

-- ============================================================
-- 🇪🇸 ESPAÑOL (DEFAULT)
-- ============================================================
-- Navigation
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_HOME',          '0', 1, 'Inicio');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_PRODUCT',       '0', 2, 'Productos');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_CONTACT',       '0', 3, 'Contacto');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_ABOUT',         '0', 4, 'Sobre Nosotros');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_LOGIN',         '0', 5, 'Iniciar Sesión');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_REGISTER',      '0', 6, 'Registrarse');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_LOGOUT',        '0', 7, 'Cerrar Sesión');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_CART',          '0', 8, 'Carrito');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_DASHBOARD',     '0', 1, 'Panel');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_ADM_PRODUCTS',  '0', 2, 'Productos');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_ADM_CATALOGS',  '0', 3, 'Categorías');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_ADM_NEWS',      '0', 4, 'Noticias');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_ADM_SLIDES',    '0', 5, 'Sliders');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_ADM_TAGS',      '0', 6, 'Etiquetas');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_ADM_ORDERS',    '0', 7, 'Pedidos');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_ADM_USERS',     '0', 8, 'Usuarios');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_ADM_FEEDBACK',  '0', 9, 'Comentarios');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_VIEW_SITE',     '0', 1, 'Ver sitio');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'NAV_NEWS',          '0', 1, 'Noticias');

-- Buttons
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_ADD_TO_CART',  '0', 1, 'Añadir al Carrito');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_CHECKOUT',     '0', 2, 'Pagar');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_SUBMIT',       '0', 3, 'Enviar');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_CANCEL',       '0', 4, 'Cancelar');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_SEARCH',       '0', 5, 'Buscar');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_SAVE',         '0', 6, 'Guardar');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_EDIT',         '0', 7, 'Editar');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_DELETE',       '0', 8, 'Eliminar');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_VIEW',         '0', 9, 'Ver');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_BACK_HOME',    '0', 10, 'Volver a inicio');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_LOGIN',        '0', 11, 'Entrar');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_REGISTER',     '0', 12, 'Crear cuenta');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_FORGOT_PASS',  '0', 13, '¿Olvidaste tu contraseña?');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_SHOP_NOW',     '0', 14, 'Comprar ahora');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_CONTINUE_SHOP','0', 15, 'Seguir comprando');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_UPDATE',       '0', 16, 'Actualizar');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_NEW_PRODUCT',  '0', 17, '+ Nuevo Producto');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'BTN_PAY_STRIPE',   '0', 18, 'Pagar con Stripe');

-- Messages
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_WELCOME',          '0', 1, 'Bienvenido a DoGiaDung — tu tienda de artículos para el hogar.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_LOGIN_ERR',        '0', 2, 'Correo o contraseña inválidos.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_REGISTER_ERR',     '0', 3, 'Registro fallido.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_ORDER_SUCCESS',    '0', 4, '¡Pedido realizado con éxito!');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_EMPTY_CART',       '0', 5, 'Tu carrito está vacío.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_RESET_PASS',       '0', 6, 'Se ha enviado un correo para restablecer la contraseña.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_PASS_MIN',         '0', 7, 'mín. 8 caracteres');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_ALREADY_ACCOUNT',  '0', 8, 'Ya tengo cuenta');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_VAT_INCLUDED',     '0', 9, 'IVA incluido');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_IN_STOCK',         '0', 10, 'En stock');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_OUT_OF_STOCK',     '0', 11, 'Agotado');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_NO_PRODUCTS',     '0', 12, 'No hay productos disponibles.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_ORDER_THANKS',     '0', 13, 'Gracias por tu compra.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_ORDER_EMAIL',      '0', 14, 'Recibirás un correo con los detalles de tu pedido.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_ABOUT_US',         '0', 15, 'Somos una tienda especializada en artículos para el hogar en España.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_CONTACT_INFO',     '0', 16, 'Puedes contactarnos a través de nuestro formulario o correo electrónico.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_ERROR',            '0', 17, 'Error');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_ERROR_INFO',       '0', 18, 'Lo sentimos, ha ocurrido un error.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_DASHBOARD_WELCOME','0', 19, 'Bienvenido al panel de administración.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_CONFIRM_DELETE',   '0', 20, '¿Estás seguro de eliminar este elemento?');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_NO_RESULTS',       '0', 21, 'Sin resultados.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSG_NOT_FOUND',        '0', 22, 'No encontrado.');

-- Labels
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'LBL_EMAIL',             '0', 1, 'Correo electrónico');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'LBL_PASSWORD',          '0', 2, 'Contraseña');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'LBL_FULL_NAME',         '0', 3, 'Nombre completo');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'LBL_PHONE',             '0', 4, 'Teléfono');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'LBL_ADDRESS',           '0', 5, 'Dirección');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'LBL_PRICE',             '0', 6, 'Precio');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'LBL_QUANTITY',          '0', 7, 'Cantidad');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'LBL_TOTAL',             '0', 8, 'Total');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'LBL_STOCK',             '0', 9, 'Stock');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'LBL_CATALOG',           '0', 10, 'Categoría');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'LBL_DESCRIPTION',       '0', 11, 'Descripción');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'LBL_SHIPPING_ADDRESS',  '0', 12, 'Dirección de envío');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'LBL_ORDER_NOTE',        '0', 13, 'Nota del pedido');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'LBL_VAT_GENERAL',       '0', 14, 'General');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'LBL_VAT_REDUCED',       '0', 15, 'Reducido');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'LBL_VAT_SUPERREDUCED',  '0', 16, 'Superreducido');

-- Titles
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TTL_HOME',             '0', 1, 'Inicio');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TTL_PRODUCTS',         '0', 2, 'Productos');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TTL_ABOUT',            '0', 3, 'Sobre Nosotros');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TTL_CONTACT',          '0', 4, 'Contacto');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TTL_LOGIN',            '0', 5, 'Iniciar Sesión');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TTL_REGISTER',         '0', 6, 'Crear Cuenta');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TTL_CART',             '0', 7, 'Carrito');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TTL_CHECKOUT',         '0', 8, 'Finalizar Pedido');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TTL_ORDER_CONFIRMED',  '0', 9, 'Pedido Confirmado');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TTL_DASHBOARD',        '0', 10, 'Panel');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TTL_NEW_PRODUCT',      '0', 11, 'Nuevo Producto');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TTL_EDIT_PRODUCT',     '0', 12, 'Editar Producto');

-- Table columns
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TBL_PRODUCT_NAME', '0', 1, 'Nombre');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TBL_ORDER_DATE',   '0', 2, 'Fecha');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TBL_ORDER_STATUS', '0', 3, 'Estado');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TBL_ACTIONS',      '0', 4, 'Acciones');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TBL_USER_NAME',    '0', 5, 'Usuario');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'TBL_AMOUNT',       '0', 6, 'Monto');

-- Placeholders
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'PLH_EMAIL',           '0', 1, 'tu@email.com');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'PLH_SEARCH_PRODUCT',  '0', 2, 'Buscar productos...');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'PLH_SEARCH',          '0', 3, 'Buscar...');

-- Footer
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'FT_COPYRIGHT', '0', 1, '© 2026 DoGiaDung — Todos los derechos reservados');

-- Status codes (MSS) — order status
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSS1',   '0', 1, 'Pendiente');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSS2',   '0', 2, 'Confirmado');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSS3',   '0', 3, 'Pagado');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSS4',   '0', 4, 'Enviado');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('ES', 'MSS_N1',  '0', 5, 'Cancelado');

GO

-- ============================================================
-- 🇬🇧 ENGLISH
-- ============================================================
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_HOME',          '0', 1, 'Home');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_PRODUCT',       '0', 2, 'Products');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_CONTACT',       '0', 3, 'Contact');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_ABOUT',         '0', 4, 'About Us');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_LOGIN',         '0', 5, 'Login');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_REGISTER',      '0', 6, 'Register');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_LOGOUT',        '0', 7, 'Logout');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_CART',          '0', 8, 'Cart');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_DASHBOARD',     '0', 1, 'Dashboard');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_ADM_PRODUCTS',  '0', 2, 'Products');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_ADM_CATALOGS',  '0', 3, 'Categories');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_ADM_NEWS',      '0', 4, 'News');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_ADM_SLIDES',    '0', 5, 'Sliders');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_ADM_TAGS',      '0', 6, 'Tags');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_ADM_ORDERS',    '0', 7, 'Orders');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_ADM_USERS',     '0', 8, 'Users');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_ADM_FEEDBACK',  '0', 9, 'Feedback');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_VIEW_SITE',     '0', 1, 'View site');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'NAV_NEWS',          '0', 1, 'News');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_ADD_TO_CART',  '0', 1, 'Add to Cart');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_CHECKOUT',     '0', 2, 'Checkout');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_SUBMIT',       '0', 3, 'Submit');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_CANCEL',       '0', 4, 'Cancel');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_SEARCH',       '0', 5, 'Search');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_SAVE',         '0', 6, 'Save');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_EDIT',         '0', 7, 'Edit');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_DELETE',       '0', 8, 'Delete');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_VIEW',         '0', 9, 'View');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_BACK_HOME',    '0', 10, 'Back to Home');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_LOGIN',        '0', 11, 'Login');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_REGISTER',     '0', 12, 'Create Account');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_FORGOT_PASS',  '0', 13, 'Forgot Password?');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_SHOP_NOW',     '0', 14, 'Shop Now');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_CONTINUE_SHOP','0', 15, 'Continue Shopping');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_UPDATE',       '0', 16, 'Update');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_NEW_PRODUCT',  '0', 17, '+ New Product');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'BTN_PAY_STRIPE',   '0', 18, 'Pay with Stripe');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_WELCOME',          '0', 1, 'Welcome to DoGiaDung — your home goods store.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_LOGIN_ERR',        '0', 2, 'Invalid email or password.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_REGISTER_ERR',     '0', 3, 'Registration failed.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_ORDER_SUCCESS',    '0', 4, 'Order placed successfully!');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_EMPTY_CART',       '0', 5, 'Your cart is empty.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_RESET_PASS',       '0', 6, 'Password reset email has been sent.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_PASS_MIN',         '0', 7, 'min. 8 chars');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_ALREADY_ACCOUNT',  '0', 8, 'Already have an account');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_VAT_INCLUDED',     '0', 9, 'VAT included');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_IN_STOCK',         '0', 10, 'In stock');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_OUT_OF_STOCK',     '0', 11, 'Out of stock');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_NO_PRODUCTS',     '0', 12, 'No products available.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_ORDER_THANKS',     '0', 13, 'Thank you for your purchase.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_ORDER_EMAIL',      '0', 14, 'You will receive an email with your order details.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_ABOUT_US',         '0', 15, 'We are a store specialized in home goods in Spain.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_CONTACT_INFO',     '0', 16, 'Contact us through our form or email.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_ERROR',            '0', 17, 'Error');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_ERROR_INFO',       '0', 18, 'Sorry, an error occurred.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_DASHBOARD_WELCOME','0', 19, 'Welcome to the admin dashboard.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_CONFIRM_DELETE',   '0', 20, 'Are you sure to delete this item?');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_NO_RESULTS',       '0', 21, 'No results.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSG_NOT_FOUND',        '0', 22, 'Not found.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'LBL_EMAIL',             '0', 1, 'Email');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'LBL_PASSWORD',          '0', 2, 'Password');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'LBL_FULL_NAME',         '0', 3, 'Full Name');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'LBL_PHONE',             '0', 4, 'Phone');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'LBL_ADDRESS',           '0', 5, 'Address');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'LBL_PRICE',             '0', 6, 'Price');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'LBL_QUANTITY',          '0', 7, 'Quantity');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'LBL_TOTAL',             '0', 8, 'Total');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'LBL_STOCK',             '0', 9, 'Stock');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'LBL_CATALOG',           '0', 10, 'Category');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'LBL_DESCRIPTION',       '0', 11, 'Description');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'LBL_SHIPPING_ADDRESS',  '0', 12, 'Shipping Address');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'LBL_ORDER_NOTE',        '0', 13, 'Order Note');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'LBL_VAT_GENERAL',       '0', 14, 'General');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'LBL_VAT_REDUCED',       '0', 15, 'Reduced');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'LBL_VAT_SUPERREDUCED',  '0', 16, 'Super-Reduced');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TTL_HOME',             '0', 1, 'Home');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TTL_PRODUCTS',         '0', 2, 'Products');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TTL_ABOUT',            '0', 3, 'About Us');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TTL_CONTACT',          '0', 4, 'Contact');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TTL_LOGIN',            '0', 5, 'Login');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TTL_REGISTER',         '0', 6, 'Register');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TTL_CART',             '0', 7, 'Shopping Cart');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TTL_CHECKOUT',         '0', 8, 'Checkout');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TTL_ORDER_CONFIRMED',  '0', 9, 'Order Confirmed');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TTL_DASHBOARD',        '0', 10, 'Dashboard');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TTL_NEW_PRODUCT',      '0', 11, 'New Product');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TTL_EDIT_PRODUCT',     '0', 12, 'Edit Product');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TBL_PRODUCT_NAME', '0', 1, 'Name');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TBL_ORDER_DATE',   '0', 2, 'Date');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TBL_ORDER_STATUS', '0', 3, 'Status');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TBL_ACTIONS',      '0', 4, 'Actions');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TBL_USER_NAME',    '0', 5, 'User');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'TBL_AMOUNT',       '0', 6, 'Amount');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'PLH_EMAIL',           '0', 1, 'your@email.com');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'PLH_SEARCH_PRODUCT',  '0', 2, 'Search products...');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'PLH_SEARCH',          '0', 3, 'Search...');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'FT_COPYRIGHT', '0', 1, '© 2026 DoGiaDung — All rights reserved');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSS1',   '0', 1, 'Pending');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSS2',   '0', 2, 'Confirmed');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSS3',   '0', 3, 'Paid');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSS4',   '0', 4, 'Shipped');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('EN', 'MSS_N1',  '0', 5, 'Cancelled');

GO

-- ============================================================
-- 🇻🇳 TIẾNG VIỆT
-- ============================================================
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_HOME',          '0', 1, 'Trang chủ');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_PRODUCT',       '0', 2, 'Sản phẩm');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_CONTACT',       '0', 3, 'Liên hệ');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_ABOUT',         '0', 4, 'Giới thiệu');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_LOGIN',         '0', 5, 'Đăng nhập');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_REGISTER',      '0', 6, 'Đăng ký');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_LOGOUT',        '0', 7, 'Đăng xuất');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_CART',          '0', 8, 'Giỏ hàng');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_DASHBOARD',     '0', 1, 'Bảng điều khiển');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_ADM_PRODUCTS',  '0', 2, 'Sản phẩm');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_ADM_CATALOGS',  '0', 3, 'Danh mục');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_ADM_NEWS',      '0', 4, 'Tin tức');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_ADM_SLIDES',    '0', 5, 'Slider');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_ADM_TAGS',      '0', 6, 'Thẻ');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_ADM_ORDERS',    '0', 7, 'Đơn hàng');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_ADM_USERS',     '0', 8, 'Người dùng');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_ADM_FEEDBACK',  '0', 9, 'Phản hồi');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_VIEW_SITE',     '0', 1, 'Xem trang');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'NAV_NEWS',          '0', 1, 'Tin tức');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_ADD_TO_CART',  '0', 1, 'Thêm vào giỏ');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_CHECKOUT',     '0', 2, 'Thanh toán');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_SUBMIT',       '0', 3, 'Gửi');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_CANCEL',       '0', 4, 'Hủy');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_SEARCH',       '0', 5, 'Tìm kiếm');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_SAVE',         '0', 6, 'Lưu');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_EDIT',         '0', 7, 'Sửa');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_DELETE',       '0', 8, 'Xóa');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_VIEW',         '0', 9, 'Xem');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_BACK_HOME',    '0', 10, 'Về trang chủ');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_LOGIN',        '0', 11, 'Đăng nhập');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_REGISTER',     '0', 12, 'Tạo tài khoản');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_FORGOT_PASS',  '0', 13, 'Quên mật khẩu?');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_SHOP_NOW',     '0', 14, 'Mua ngay');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_CONTINUE_SHOP','0', 15, 'Tiếp tục mua');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_UPDATE',       '0', 16, 'Cập nhật');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_NEW_PRODUCT',  '0', 17, '+ Sản phẩm mới');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'BTN_PAY_STRIPE',   '0', 18, 'Thanh toán qua Stripe');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_WELCOME',          '0', 1, 'Chào mừng đến với DoGiaDung — cửa hàng đồ gia dụng của bạn.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_LOGIN_ERR',        '0', 2, 'Sai thông tin đăng nhập.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_REGISTER_ERR',     '0', 3, 'Đăng ký thất bại.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_ORDER_SUCCESS',    '0', 4, 'Đặt hàng thành công!');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_EMPTY_CART',       '0', 5, 'Giỏ hàng trống.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_RESET_PASS',       '0', 6, 'Email đặt lại mật khẩu đã được gửi.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_PASS_MIN',         '0', 7, 'tối thiểu 8 ký tự');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_ALREADY_ACCOUNT',  '0', 8, 'Đã có tài khoản');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_VAT_INCLUDED',     '0', 9, 'Đã bao gồm VAT');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_IN_STOCK',         '0', 10, 'Còn hàng');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_OUT_OF_STOCK',     '0', 11, 'Hết hàng');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_NO_PRODUCTS',     '0', 12, 'Không có sản phẩm.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_ORDER_THANKS',     '0', 13, 'Cảm ơn bạn đã mua hàng.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_ORDER_EMAIL',      '0', 14, 'Bạn sẽ nhận được email xác nhận đơn hàng.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_ABOUT_US',         '0', 15, 'Chúng tôi là cửa hàng chuyên đồ gia dụng tại Tây Ban Nha.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_CONTACT_INFO',     '0', 16, 'Liên hệ với chúng tôi qua form hoặc email.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_ERROR',            '0', 17, 'Lỗi');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_ERROR_INFO',       '0', 18, 'Rất tiếc, đã xảy ra lỗi.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_DASHBOARD_WELCOME','0', 19, 'Chào mừng đến với bảng điều khiển quản trị.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_CONFIRM_DELETE',   '0', 20, 'Bạn có chắc muốn xóa?');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_NO_RESULTS',       '0', 21, 'Không có kết quả.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSG_NOT_FOUND',        '0', 22, 'Không tìm thấy.');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'LBL_EMAIL',             '0', 1, 'Email');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'LBL_PASSWORD',          '0', 2, 'Mật khẩu');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'LBL_FULL_NAME',         '0', 3, 'Họ tên');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'LBL_PHONE',             '0', 4, 'Số điện thoại');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'LBL_ADDRESS',           '0', 5, 'Địa chỉ');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'LBL_PRICE',             '0', 6, 'Giá');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'LBL_QUANTITY',          '0', 7, 'Số lượng');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'LBL_TOTAL',             '0', 8, 'Tổng cộng');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'LBL_STOCK',             '0', 9, 'Tồn kho');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'LBL_CATALOG',           '0', 10, 'Danh mục');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'LBL_DESCRIPTION',       '0', 11, 'Mô tả');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'LBL_SHIPPING_ADDRESS',  '0', 12, 'Địa chỉ giao hàng');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'LBL_ORDER_NOTE',        '0', 13, 'Ghi chú đơn hàng');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'LBL_VAT_GENERAL',       '0', 14, 'Tiêu chuẩn');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'LBL_VAT_REDUCED',       '0', 15, 'Giảm');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'LBL_VAT_SUPERREDUCED',  '0', 16, 'Siêu giảm');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TTL_HOME',             '0', 1, 'Trang chủ');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TTL_PRODUCTS',         '0', 2, 'Sản phẩm');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TTL_ABOUT',            '0', 3, 'Giới thiệu');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TTL_CONTACT',          '0', 4, 'Liên hệ');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TTL_LOGIN',            '0', 5, 'Đăng nhập');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TTL_REGISTER',         '0', 6, 'Đăng ký');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TTL_CART',             '0', 7, 'Giỏ hàng');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TTL_CHECKOUT',         '0', 8, 'Thanh toán');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TTL_ORDER_CONFIRMED',  '0', 9, 'Đơn hàng đã xác nhận');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TTL_DASHBOARD',        '0', 10, 'Bảng điều khiển');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TTL_NEW_PRODUCT',      '0', 11, 'Sản phẩm mới');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TTL_EDIT_PRODUCT',     '0', 12, 'Sửa sản phẩm');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TBL_PRODUCT_NAME', '0', 1, 'Tên');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TBL_ORDER_DATE',   '0', 2, 'Ngày');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TBL_ORDER_STATUS', '0', 3, 'Trạng thái');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TBL_ACTIONS',      '0', 4, 'Hành động');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TBL_USER_NAME',    '0', 5, 'Người dùng');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'TBL_AMOUNT',       '0', 6, 'Số tiền');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'PLH_EMAIL',           '0', 1, 'email@cua.ban');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'PLH_SEARCH_PRODUCT',  '0', 2, 'Tìm sản phẩm...');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'PLH_SEARCH',          '0', 3, 'Tìm kiếm...');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'FT_COPYRIGHT', '0', 1, '© 2026 DoGiaDung — Đã đăng ký bản quyền');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSS1',   '0', 1, 'Chờ xử lý');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSS2',   '0', 2, 'Đã xác nhận');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSS3',   '0', 3, 'Đã thanh toán');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSS4',   '0', 4, 'Đã gửi');
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES ('VI', 'MSS_N1',  '0', 5, 'Đã hủy');
GO
