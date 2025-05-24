<h1 align="center" id="title">SERVICIO SUSCRIPCIONES</h1>

<p align="center"><img src="https://github.com/vape2205/suscriptions-service" alt="project-image"></p>

<p id="description">Servicio para la gestión de suscripciones</p>
  
  
<h2>🧐 Features</h2>

Caracteristicas

*   Crear suscripciones
*   Activar suscripciones
*   Cancelar suscripciones
*   Listar suscripcionesp por usuario
*   Buscar suscripciones por id

<h2>🛠️ Installation Steps:</h2>

<p>1. Agregar archivo de environment</p>

Crear un archivo .env en la carpeta donde se encuentre el archivo docker-compose

```
SUSCRIPTIONS_DB_CONNECTIONSTRING=Data Source=<Nombre del la base de datos>
AUTH_RSA_PUBLICKEY=<Lllave publica RSA>
SUSCRIPTIONS_PORT=6001
SUSCRIPTIONS_DB_PORT=1433
SUSCRIPTIONS_DB_PASSWORD=Password DB

```

<p>2. Ejecutar Docker Compose</p>

```
docker compose up -d --build
```

<h2>💻 Built with</h2>

Tecnologias usadas en este proyecto:

*   ASP .NET 8
*   SQLLITE