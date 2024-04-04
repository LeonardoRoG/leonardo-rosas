Feature: CASOS ACADEMIA NOVIT

Background:
* def pagina = 'https://localhost:7068/api/Producto'

Scenario: CONSULTA TIPO GET

Given url pagina
    And headers {Authorization: 'bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiVmVuZGVkb3IiLCJyb2xlIjoidmVuZGVkb3IiLCJleHAiOjE3MTI3ODIwMTV9.quWpE-O1N6nMiw-zKQQjKHZz3C5Z9Zh0Q__eF6gd3MlmPapQesfuLtA0wBw1jMFIlEcVvmstEPhCtuW6OEXP-g'}
When method GET
Then status 401
