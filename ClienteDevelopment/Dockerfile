# Utiliza una imagen base de Node
FROM node:latest AS build
WORKDIR /app
# Copio los archivos de mi aplicacion
COPY package.json package-lock.json ./
# Instala las dependencias
RUN npm install
# Copia el resto de los archivos al directorio de trabajo
COPY . .
# Construye la aplicacion
RUN npm run build
# Utiliza una imagen mas pequeña para la ejecucion
FROM nginx:alpine
# Copia los archivos construidos desde la imagen de construccion
COPY --from=build /app/dist /usr/share/nginx/html
# Expone el puerto en el que Nginx servira la aplicacion react
EXPOSE 80
# Comando para iniciar Nginx
CMD [ "nginx", "-g", "daemon off;" ]