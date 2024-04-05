Feature: CASOS PETICIONES RESERVA CON USUARIO COMERCIAL

Background:
* def pagina = 'http://localhost:5267/api/Reserva'
* configure headers = { Accept-Encoding: 'gzip, deflate, br, zstd', Accept: '*/*', Authorization: 'bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiQ29tZXJjaWFsIiwicm9sZSI6ImNvbWVyY2lhbCIsImV4cCI6MTcxMjg4NDk0MH0.Ab9TBqQRNini29ACEY7AtFTIwJ12tcoyeR4UVKLOEMH-q0nryw4xNu2u7bNLz1BFRcD2h3HLzObtkEBWtzaP2w'}

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
    "username": "Comercial"
  }
}
"""
When method POST
Then status 403

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
    "username": "Comercial"
  }
}
"""
When method POST
Then status 403

Scenario: CANCELAR UNA RESERVA EN ESTADO INGRESADA

Given url pagina+'/16/Cancelar'
When method PUT
Then status 403

Scenario: RECHAZAR UNA RESERVA

Given url pagina+'/16/Rechazar'
When method PUT
Then status 200

Scenario: APROBAR UNA RESERVA

Given url pagina+'/16/Aprobar'
When method PUT
Then status 200