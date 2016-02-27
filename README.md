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
 
[ { "Email": "joao@gmail.com" }, { "Email": "tiago@hotmail.com" }, { "Email": "fabio@yahoo.com" }, { "Email": "master@gmail.com" } ]

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

### Quantificar o total de followers por perfil

* Verbo HTTP suportado: Post

* Url: http://socialanalyticsdev.azurewebsites.net/api/v1/github/followers/count

* Para obter o total de followers, você deve passar um raw de e-mail como parâmetro. Exemplo:
 
[ { "Email": "joao@gmail.com" }, { "Email": "tiago@hotmail.com" }, { "Email": "fabio@yahoo.com" }, { "Email": "master@gmail.com" } ]

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

### Quantificar o total de following por perfil

* Verbo HTTP suportado: Post

* Url: http://socialanalyticsdev.azurewebsites.net/api/v1/github/following/count

* Para obter o total de following, você deve passar um raw de e-mail como parâmetro. Exemplo:
 
[ { "Email": "joao@gmail.com" }, { "Email": "tiago@hotmail.com" }, { "Email": "fabio@yahoo.com" }, { "Email": "master@gmail.com" } ]

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

### Quantificar o total de repositorios por perfil

* Verbo HTTP suportado: Post

* Url: http://socialanalyticsdev.azurewebsites.net/api/v1/github/repositories/count

* Para obter o total de repositorios, você deve passar um raw de e-mail como parâmetro. Exemplo:
 
[ { "Email": "joao@gmail.com" }, { "Email": "tiago@hotmail.com" }, { "Email": "fabio@yahoo.com" }, { "Email": "master@gmail.com" } ]

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

### Quantificar o total de stargazers por perfil

* Verbo HTTP suportado: Post

* Url: http://socialanalyticsdev.azurewebsites.net/api/v1/github/stargazers/count

* Para obter o total de stargazers, você deve passar um raw de e-mail como parâmetro. Exemplo:
 
[ { "Email": "joao@gmail.com" }, { "Email": "tiago@hotmail.com" }, { "Email": "fabio@yahoo.com" }, { "Email": "master@gmail.com" } ]

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
