FROM node:12.16.1-alpine as build
WORKDIR /app
COPY package.json ./
RUN npm install
COPY . .
RUN npm run build

FROM nginx:1.17.9-alpine as prod
COPY --from=build /app/dist/DemoFrontEnd /usr/share/nginx/html
EXPOSE 80
CMD ["nginx","-g","daemon off;"]
