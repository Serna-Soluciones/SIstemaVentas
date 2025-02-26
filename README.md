# SistemaVentas

## 0002
Se generó el conjunto: ProductoRepository, ProductoService, IProductoService y ProdutoController.
Las excepciones se mantienen registradas correctamente en archivos de LOG.
Atención al momento de implementarlos. Estaba marcando un error de referencia circular, debido a que el servicio estaba consumiéndose a sí mismo, por lo que hay que prestar atención a que se utilice el repositorio.

## 0001
El archivo docker-compose.yml instala MongoDB, Mongo Express, PostgreSQL y PgAdmin dentro de un contenedor compuesto. Cuando intenté abrir PgAdmin, resultó que no lo tenía instalado, por lo que se agregó al compose, y para iniciar sesión se utilizaron las credenciales definidas en el mismo archivo. Una vez dentro de PgAdmin, se agregó un servidor para poder administrarlo, el servidor definido para la BD del proyecto. La conexión se hizo hacia el contenedor con base en su nombre en vez de "localhost" como se haría si no estuviera dentro de un contenedor de Docker.

La solución en .NET está hecha con NET Core 8, maneja una estructura de Infrastructure-Application-Domain-API.

Se actualizó "docker-compose.yml" y se agregó "docker-compose.override.yml" para agregar al "compose" la API generada por la solución. También se actualizó la configuración en appsettings.json de la API para agregar la cadena de conexión.

Para correr las migraciones y aplicarlas a la BD, la cadena de conexión debe ser "localhost", ya que todo está en el compose de Docker.

