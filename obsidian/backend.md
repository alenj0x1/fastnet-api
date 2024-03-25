
# Rútas

## /authentication
✅

| ruta | descripción           | params | query | body             | metodo | rol necesario |
| ---- | --------------------- | ------ | ----- | ---------------- | ------ | ------------- |
| /    | Autenticar un usuario | -      | -     | userId, password | post   | -             |

## /users
✅

| ruta                  | descripción                         | params | query | body            | metodo | rol necesario |
| --------------------- | ----------------------------------- | ------ | ----- | --------------- | ------ | ------------- |
| /                     | Todos los usuarios de la aplicación | -      | -     | -               | get    | -             |
| /:userId              | Obtener un usuario                  | userId | -     | -               | get    | -             |
| /assignCash/          | Asignar una caja a un cajero        | -      | -     | userId, cashId  | post   | gestor        |
| /createCajero         | Crea un nuevo cajero                | -      | -     | username, email | post   | gestor        |
| /removeCajero/:userId | Remueve un cajero                   | userId | -     | -               | delete | gestor        |

### /cash
✅

| ruta                       | descripción                           | params | query | body | metodo | rol necesario |
| -------------------------- | ------------------------------------- | ------ | ----- | ---- | ------ | ------------- |
| /                          | Obtener todas las cajas               |        | -     | -    | get    | -             |
| /:cashId                   | Obtener una caja por su ID            | cashId | -     | -    | get    | -             |
| /getCashByCajeroId/:userId | Obtener una caja por la ID del cajero | userId | -     | -    | get    | -             |


## /attention
✅

| ruta                              | descripción                       | params      | query | body            | metodo | rol necesario |
| --------------------------------- | --------------------------------- | ----------- | ----- | --------------- | ------ | ------------- |
| /getAttentionByClientId/:clientId | Obtiene la atención actual        | clientId    | -     | -               | -      | -             |
| /getAttentionById/:attentionId    | Obtiene una atención por Id       | atentionId  | -     | -               | get    | -             |
| /new                              | Crear una nueva atención          | -           | -     | userId          | post   | -             |
| /closeAttention/:attentionId      | Finalizar la atención del cliente | attentionId | -     | userId (cajero) | get    | -             |
| /                                 | Obtener todas las atenciones      | -           | -     | -               | -      | cajero        |
## /turn

| ruta              | descripción                                     | params | query              | body | metodo | rol necesario |
| ----------------- | ----------------------------------------------- | ------ | ------------------ | ---- | ------ | ------------- |
| /                 | Obtiene información actual del turno del cajero | -      | -                  | -    | get    | cajero        |
| /getAll           | Obtiene todos los turnos del cajero en ese día  | -      | excludeActualTurn? | -    | get    | cajero        |
| /takeTurn/:turnId | Toma un turno                                   | turnId | -                  |      | get    | cajero        |
| /nextTurn         | Salta al siguiente turno, de haber uno          | -      | -                  | -    | get    | cajero        |
## /contracts

| ruta                             | descripción                                             | params     | query | body                 | metodo | rol necesario |
| -------------------------------- | ------------------------------------------------------- | ---------- | ----- | -------------------- | ------ | ------------- |
| /:contractId                     | Obtiene un contrato por usu ID                          | contractId | -     | -                    | get    | cajero        |
| /getContractByClientId/:clientId | Obtiene el contrato de un cliente por su id, de tenerlo | clientId   | -     | -                    | get    | cajero        |
| /new                             | Crea un nuevo contrato                                  | -          | -     | serviceId, clientId? | post   | gestor        |
| /update/:contractId              | Actualiza un contrato                                   | contractId | -     |                      |        |               |
## /services

| ruta               | descripción                             | params    | query | body                        | metodo | rol necesario |
| ------------------ | --------------------------------------- | --------- | ----- | --------------------------- | ------ | ------------- |
| /                  | Obtiene todos los servicios disponibles | -         | -     | -                           | get    | cajero        |
| /:serviceId        | Obtiene un servicio por su Id           | serviceId | -     | -                           | get    | cajero        |
| /new               | Crea un nuevo servicio                  | -         | -     | name, description, price    | post   | gestor        |
| /remove/:serviceId | Remueve un servicio existente           | serviceId | -     | -                           | delete | gestor        |
| /update/:serviceId | Actualiza un servicio existente         | serviceId | -     | name?, description?, price? | put    | gestor        |
## /roles

| ruta           | descripción                      | params | query | body | metodo | rol necesario |
| -------------- | -------------------------------- | ------ | ----- | ---- | ------ | ------------- |
| /              | Obtiene todos los roles actuales | -      | -     | -    | get    | cajero        |
| /:rolId        | Obtiene un rol por su Id         | rolId  | -     | -    | get    | cajero        |
| /new           | Crea un nuevo rol                | -      | -     | name | post   | gestor        |
| /update/:rolId | Actualiza un rol existente       | rolId  | -     | name | put    | gestor        |
| /remove/:rolId | Remueve un rol existente         | rolId  | -     | -    | delete | gestor        |
## /clients

| ruta              | descripción                   | params   | query | body                                                                                 | metodo | rol necesario |
| ----------------- | ----------------------------- | -------- | ----- | ------------------------------------------------------------------------------------ | ------ | ------------- |
| /                 | Obtiene todos los clientes    | -        | -     | -                                                                                    | get    | cajero        |
| /:clientId        | Obtiene un cliente por su id  | clientId | -     | -                                                                                    | get    | cajero        |
| /new              | Crea un nuevo cliente         | -        | -     | name, lastname, identification, email, phonenumber, address, referenceaddress?       | post   | cajero        |
| /update/:clientId | Actualiza un client existente | clientId | -     | name?, lastname?, identification?, email?, phonenumber?, address?, referenceaddress? | put    | cajero        |
| /remove/:clientId | Remueve cliente existente     | clientId | -     |                                                                                      | delete | cajero        |
|                   |                               |          |       |                                                                                      |        |               |
