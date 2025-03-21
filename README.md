# 📌 **Gestión de Tareas - Angular & .NET API**  

Este proyecto es una aplicación web para gestionar tareas (**CRUD**) utilizando **Angular** en el frontend y **.NET Minimal APIs** en el backend.  

---

## 📌 **1. Requisitos Previos**  

Antes de ejecutar el proyecto, asegúrate de tener instalado:  

🔹 **.NET SDK 8+** → [Descargar aquí](https://dotnet.microsoft.com/en-us/download)  
🔹 **Node.js 18+** → [Descargar aquí](https://nodejs.org/)  
🔹 **Angular CLI** → Instalar con:  
   ```sh
   npm install -g @angular/cli
   ```  
🔹 **Git (Opcional)** → [Descargar aquí](https://git-scm.com/)  
🔹 **Visual Studio o Visual Studio Code**  

---

## 🏗️ **2. Clonar el Proyecto**  
Si el código está en un repositorio de GitHub:  
```sh
git clone https://github.com/tu-usuario/tu-repositorio.git
cd tu-repositorio
```
Si descargaste el código manualmente, entra a la carpeta del proyecto.

---

# 🎯 **3. Ejecutar la API en .NET**
## **📌 3.1. Instalar Dependencias**
1. **Abre una terminal y entra a la carpeta del backend**:  
   ```sh
   cd TaskAPI
   ```
2. **Restaura las dependencias del proyecto:**  
   ```sh
   dotnet restore
   ```
3. **Compila la API:**  
   ```sh
   dotnet build
   ```

---

## **📌 3.2. Configurar la Base de Datos (Opcional)**
Si usas una base de datos en memoria, puedes omitir este paso.  
Si necesitas **migraciones con Entity Framework Core**, ejecuta:  
```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## **📌 3.3. Ejecutar la API**
Ejecuta la API con:  
```sh
dotnet run
```
📍 **Verifica la salida en consola**, debería mostrar algo como:  
```
Now listening on: https://localhost:7019
Now listening on: http://localhost:5191
```
📌 **Abrir Swagger para probar la API:**  
🔗 [https://localhost:7019/swagger](https://localhost:7019/swagger)  

---

# 🖥️ **4. Ejecutar el Frontend en Angular**  
## **📌 4.1. Instalar Dependencias**
1. **Abre una nueva terminal y ve a la carpeta del frontend:**  
   ```sh
   cd task-manager
   ```
2. **Instala las dependencias de Angular:**  
   ```sh
   npm install
   ```

---

## **📌 4.2. Configurar la Conexión con la API**  
📄 **Archivo:** `src/app/services/task.service.ts`  
Verifica que la URL de la API es la correcta:  
```ts
private apiUrl = 'https://localhost:7019/api/tasks'; // O ajusta según el puerto de la API
```
Si la API usa `http://localhost:5191`, cambia la URL a:  
```ts
private apiUrl = 'http://localhost:5191/api/tasks';
```

---

## **📌 4.3. Ejecutar el Servidor Angular**
Ejecuta Angular con:  
```sh
ng serve --ssl
```
📍 Abre en el navegador:  
🔗 [https://localhost:4200](https://localhost:4200)  

---

# 🚀 **5. Prueba Final**  
1️⃣ **Abre `https://localhost:7019/swagger`** para probar la API.  
2️⃣ **Abre `https://localhost:4200/`** para ver la aplicación en acción.  
3️⃣ **Crea, edita y elimina tareas desde Angular.**  

---

# 📤 **6. Desplegar el Proyecto (Opcional)**  
## **📌 6.1. Desplegar Angular en GitHub Pages**  
1. **Compila el proyecto:**  
   ```sh
   ng build --base-href="/task-manager/"
   ```
2. **Publica en GitHub Pages:**  
   ```sh
   npx angular-cli-ghpages --dir=dist/task-manager
   ```
📍 **Tu frontend estará en GitHub Pages.**  

---

## **📌 6.2. Desplegar .NET en Azure**  
1. **Iniciar sesión en Azure:**  
   ```sh
   az login
   ```
2. **Desplegar la API en Azure:**  
   ```sh
   az webapp up --name TaskAPI --runtime DOTNET:8
   ```
📍 **Tu API estará en Azure y podrá ser consumida por Angular.**  

---

🎉 **¡Listo! Ahora puedes ejecutar la aplicación localmente y desplegarla.** 🚀  
Si necesitas más ayuda, dime. 😃
