#Housing App
##Aplicación web de gestión de reservas de productos inmobiliarios
####Trabajo final para la Academia Novit 2024

El presente proyecto fué realizado con las siguientes tecnologías:
#####Backend
Se utilizó .NET con una WebAPI (minimal API) y como ORM Entity Framework Core.
#####Frontend
Compuesto por Angular con Angular Material UI y HTML y CSS puro.
#####Base de datos
La persistencia de datos fué hecha en SQLite.
#####Extras
Posee archivos Dockerfile y tests de KarateLabs.

La aplicación cuenta con un inicio de sesión para todos los usuarios, existiendo roles de vendedor, comercial y administrador.
Los usuarios con rol vendedor pueden:
- Realizar operaciones CRUD sobre productos.
- Generar y cancelar reservas sobre dichos productos.
En cuanto a los usuarios con rol comercial:
- Pueden aprobar o rechazar reservas.
- Visualizar un reporte gráfico de ventas de cada vendedor.

#####Reglas de negocio
- De cada producto se informa un código (alfanumérico), un barrio, el precio y un enlace a una imagen ilustrativa.
- Los posibles estados de un producto son disponible, reservado y vendido.
- Los posibles estados de una reserva son ingresada, cancelada, aprobada y rechazada.
- Cuando se realiza una reserva esta tiene un estado de ingresada, mientras que el estado del producto será reservado.
- Si una reserva se encuentra en estado de ingresada tiene 2 opciones:
    - Que la reserva pase aprobada, lo cual indica que el producto pasa de estado reservado a vendido.
    - Que la reserva pase cancelada, lo cual indica que el producto pasa de estado reservado a disponible.
- Cada reserva tiene asociado el nombre del cliente y el producto. Al momento de crear una reserva existe la opción de solicitar la aprobación (por parte de comercial) o cancelar la reserva.
- En los siguientes casos las reservas no requieren aprobación alguna (se auto aprueban):
    - Pertenece al Barrio X y su precio es menor a 100.000
    - Es el último producto disponible del Barrio X
- En el caso de que el vendedor tenga hasta 3 reservas ingresadas no se le permite realizar una nueva reserva.
