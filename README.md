# SIstemaVentas

El archivo docker-compose.yml instala MongoDB, Mongo Express, PostgreSQL y PgAdmin dentro de un contenedor compuesto. Cuando intenté abrir PgAdmin, resultó que no lo tenía instalado, por lo que se agregó al compose, y para iniciar sesión se utilizaron las credenciales definidas en el mismo archivo. Una vez dentro de PgAdmin, se agregó un servidor para poder administrarlo, el servidor definido para la BD del proyecto. La conexión se hizo hacia el contenedor con base en su nombre en vez de "localhost" como se haría si no estuviera dentro de un contenedor de Docker.

La solución en .NET está hecha con NET Core 8, maneja una estructura de Infrastructure-Application-Domain-API.

