Feature: CASOS LOGIN Y REGISTER

Background:
* def pagina = 'http://localhost:5267/api/Account'

Scenario: LOGIN DE UN USUARIO REGISTRADO

Given url pagina+'/Login'
* request
"""
{
  "username": "Comercial",
  "password": "Pass123"
}
"""
When method POST
Then status 200

Scenario: LOGIN DE UN USUARIO NO REGISTRADO

Given url pagina+'/Login'
* request
"""
{
  "username": "UserNoRegistrado",
  "password": "Contraseña123"
}
"""
When method POST
Then status 500

Scenario: REGISTRO DE UN NUEVO USUARIO

Given url pagina+'/Register'
* request
"""
{
  "username": "Comercial10",
  "password": "Pass123",
  "role": "comercial"
}
"""
When method POST
Then status 200

Scenario: REGISTRO ERRÓNEO DE UN NUEVO USUARIO CON ROL INEXISTENTE

Given url pagina+'/Register'
* request
"""
{
  "username": "Vendedor10",
  "password": "Pass123",
  "role": "cliente"
}
"""
When method POST
Then status 400