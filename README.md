# Developer Social Analytics API

Developer Social Analytics API tem como objetivo de quantificar as principais métricas disponibilizadas pelas redes sociais.

## GitHub
A quantificação das seguintes métricas estão disponível:

* Commits;
* Followers;
* Following;
* Repositories;
* Stargazers.

### Quantificar o total de commits por perfil

* Verbo HTTP suportado: Post

* Url: http://socialanalyticsdev.azurewebsites.net/api/v1/github/commits/count

* Para obter o total de commits, você deve passar um raw de e-mail como parâmetro. Exemplo:
 
[
  { "email": "joao@gmail.com" },
  { "email": "tiago@hotmail.com" },
  { "email": "fabio@yahoo.com" },
  { "email": "master@gmail.com" }
]

* Exemplo de retorno:

[
    {
        "Email": "joao@gmail.com",
        "Count": 377
    },
    {
        "Email": "tiago@hotmail.com",
        "Count": 0
    },
    {
        "Email": "fabio@yahoo.com",
        "Count": 0
    },
    {
        "Email": "master@gmail.com",
        "Count": 343
    }
]


