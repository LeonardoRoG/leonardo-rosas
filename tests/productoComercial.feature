Feature: CASOS PETICIONES PRODUCTO CON USUARIO COMERCIAL

Background:
* def pagina = 'http://localhost:5267/api/Producto'
* configure headers = { Accept-Encoding: 'gzip, deflate, br, zstd', Accept: '*/*', Authorization: 'bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiQ29tZXJjaWFsIiwicm9sZSI6ImNvbWVyY2lhbCIsImV4cCI6MTcxMjg4NDk0MH0.Ab9TBqQRNini29ACEY7AtFTIwJ12tcoyeR4UVKLOEMH-q0nryw4xNu2u7bNLz1BFRcD2h3HLzObtkEBWtzaP2w'}

Scenario: CONSULTA DE PRODUCTOS TIPO GET

Given url pagina
When method GET
Then status 403

Scenario: CONSULTA DE UN PRODUCTO POR ID

Given url pagina+'/1'
When method GET
Then status 403

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
Then status 403

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
Then status 403

Scenario: ELIMINAR UN PRODUCTO

Given url pagina+'/22'
When method DELETE
Then status 403