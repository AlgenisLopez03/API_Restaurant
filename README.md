Objetivo general
 ● Hice una api para una aplicación de comida de un restaurante, utilizando asp net core
 mvc 5.
 <h1>Funcionalidades generales</h1>
 <h2>Login y Seguridad</h2>
 <br><br>
 Este sistema tendrá dos roles un rol administrador y un rol mesero, la seguridad en losendpoints del api deben de validarse a través del uso de JWT El sistema debe crear por defectos estos roles y crear un usuario con el roladministrador, otro con el rol mesero y un super administrador con los dos roles.
 El sistema tiene que tener un controlador para el manejo de las
 cuentas(AccountController) que tenga las siguientes funcionalidades:
 <br><br>
 ● Login: (Permite autenticarse y obtener el token JWT para poder usar las demás
 funcionalidades de la aplicación)<br><br>
 ● Registro de usuario mesero: (Permite crear usuario con el rol de mesero)<br><br>
 ● Registro de usuario administrador: (Permite crear usuario con el rol de
 administrador este debe tener la seguridad de que debe haber un usuario loqueago y
 que debe ser de tipo administrador para poder usar este endpoint)
 <br><br>
 Los usuarios se crean activos por lo cual no hay que hacer proceso de confirmación de
 cuenta.
 Si un usuario no está logueado no puede acceder a las funcionalidades ni del
 administrador ni del mesero. Cuando intente entrar a esos enlaces y no esté logueado
 debe mostrarle un mensaje de que no tiene autorización y el status code de la
 respuesta debe ser 401.
 <br><br>
También se debe validar que si el usuario logueado es un mesero no puede ingresar a
 las opciones del administrador y viceversa que si un administrador está logueado no
 pueda entrar a las funcionalidades de los meseros, si intenta acceder a una sección que
 no tiene autorizado a entrar debe retornar una respuesta con el mensaje de acceso
 denegado y status code debe ser 403.
 <br><br>
 Todas estas validaciones deben realizarse usando los filtros de authorize que
 implementa identity con el uso de JWT.
 
 <h1> Requerimientos técnico</h1>
 orden con sus platos, formato json) 204 HTTP (sin contenido) Se elimina la orden con sus platos interno del servidor) 404 (no existe la orden) 500 (error interno del servidor) Mesero
 <br><br>
 * Deben utilizar viewmodels y las validaciones se deben realizar desde los  mismos.<br><br>
 * Se debe usar Entity framework con code first para la persistencia de los datos.<br><br>
 * El proyecto debe usar la arquitectura ONION (Esta se debe aplicar correctamente al
 100%, en caso de algún error en la misma se considerará que esta incorrecta).<br><br>
 * Se deben utilizar repositorio y servicio genéricos.<br><br>
 * Se deben usar identity para el manejo de los usuarios y de la seguridad de api con
 JWT.<br><br>
 * Se deben usar automapper para el mapeo de los viewmodels,  entities y dtos

 ![image](https://github.com/AlgenisLopez03/API_Restaurant/assets/141606823/cfe30efa-ef0e-4e92-a454-1461ed2dfc16)
![image](https://github.com/AlgenisLopez03/API_Restaurant/assets/141606823/7e180432-1b70-4622-84ee-397506b1ff1a)
