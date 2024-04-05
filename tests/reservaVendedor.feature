Feature: CASOS PETICIONES RESERVA CON USUARIO VENDEDOR

Background:
* def pagina = 'http://localhost:5267/api/Reserva'
* configure headers = { Accept-Encoding: 'gzip, deflate, br, zstd', Accept: '*/*', Authorization: 'bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiVmVuZGVkb3IiLCJyb2xlIjoidmVuZGVkb3IiLCJleHAiOjE3MTI4Njk4MTV9.RxuphAb0p74dhs9iYTotSn1mZt7NZdTMtlu0NOlO9SWF9ct_dOXFuwtq4nhEND6EhZCIxQjkqAhOR0CQnDSisA'}

Scenario: CONSULTA DE RESERVAS TIPO GET

Given url pagina
When method GET
Then status 200

Scenario: CONSULTA DE RESERVA POR ID

Given url pagina+'/1'
When method GET
Then status 200

Scenario: CONSULTA DE RESERVA POR ID ERRONEO

Given url pagina+'/AAA'
When method GET
Then status 404

Scenario: CREAR UNA NUEVA RESERVA A UN PRODUCTO EN ESTADO DISPONIBLE

Given url pagina+'/20'
* request
"""
{
  "cliente": {
    "nombre": "Maria"
  },
  "estadoReserva": 0,
  "solicitarAprobacion": false,
  "usuario": {
    "username": "Vendedor"
  }
}
"""
When method POST
Then status 200

Scenario: CREAR UNA NUEVA RESERVA A UN PRODUCTO EN ESTADO RESERVADO

Given url pagina+'/20'
* request
"""
{
  "cliente": {
    "nombre": "Maria"
  },
  "estadoReserva": 0,
  "solicitarAprobacion": false,
  "usuario": {
    "username": "Vendedor"
  }
}
"""
When method POST
Then status 500

Scenario: CANCELAR UNA RESERVA EN ESTADO INGRESADA

Given url pagina+'/16/Cancelar'
When method PUT
Then status 200

Scenario: RECHAZAR UNA RESERVA

Given url pagina+'/16/Rechazar'
When method PUT
Then status 403

Scenario: APROBAR UNA RESERVA

Given url pagina+'/16/Aprobar'
When method PUT
Then status 403