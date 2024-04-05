Feature: CASOS PETICIONES PRODUCTO CON USUARIO VENDEDOR

Background:
* def pagina = 'http://localhost:5267/api/Producto'
* configure headers = { Accept-Encoding: 'gzip, deflate, br, zstd', Accept: '*/*', Authorization: 'bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiVmVuZGVkb3IiLCJyb2xlIjoidmVuZGVkb3IiLCJleHAiOjE3MTI4Njk4MTV9.RxuphAb0p74dhs9iYTotSn1mZt7NZdTMtlu0NOlO9SWF9ct_dOXFuwtq4nhEND6EhZCIxQjkqAhOR0CQnDSisA'}

Scenario: CONSULTA DE PRODUCTOS TIPO GET

Given url pagina
When method GET
Then status 200

Scenario: CONSULTA DE UN PRODUCTO POR ID

Given url pagina+'/1'
When method GET
Then status 200

Scenario: AGREGAR UN NUEVO PRODUCTO

Given url pagina
* request
"""
{
  "codigo": "KARATE001",
  "barrio": {
    "nombre": "San Marco"
  },
  "precio": 34400,
  "urlImagen": "",
  "estado": 0
}
"""
When method POST
Then status 201

Scenario: MODIFICAR UN PRODUCTO

Given url pagina+'/20'
* request
"""
{
  "codigo": "KARATE010MODIF",
  "barrio": {
    "nombre": "San Marco"
  },
  "precio": 34400,
  "urlImagen": "",
  "estado": 0
}
"""
When method PUT
Then status 200

Scenario: ELIMINAR UN PRODUCTO

Given url pagina+'/22'
When method DELETE
Then status 204