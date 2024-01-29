# API REST 
### API SIMPLES DE CADASTRO DE CLIENTES.

#### Características do sistema:

- Designer pattern: MVC
- JDBC: PostGreSQL
- Operações: CRUD Basic



#### BUSCAR TODOS OS CLIENTES
##### Endpoint: GET api/client 

        response
        [
            {
                "id": "...",
                "nome": "...",
                "cnpj"; "...",
                "telefone": "...",
                "uf": "...",
                "cidade": "...",
                "bairro": "...",
                "rua": "...",
                "nEndereco": ...,
                "cep": "..."
            },
            ...
        ]


#### BUSCAR CLIENTE POR ID (IDENTIFICADOR)
##### Endpoint: GET api/client/{id}

        response
        
            {
                "id": "...",
                "nome": "...",
                "cnpj"; "...",
                "telefone": "...",
                "uf": "...",
                "cidade": "...",
                "bairro": "...",
                "rua": "...",
                "nEndereco": ...,
                "cep": "..."
            }
            
        


#### CRIAR CLIENTE
##### Endpoint: POST api/client

    body {
        "nome": "USEALL SOFTWARE LTDA",
        "cnpj": "03.907.818/0001-80",
        "telefone": "554834425001",
        "uf": "SC",
        "cidade": "CRICIUMA",
        "bairro": "SANTA BARBARA",
        "rua": "Rua Viscondi de Cairu",
        "nEndereco": 630,
        "cep": "88804-320"
    }


#### ATUALIZAR DADOS DO CLIENTE
##### Endpoint: PUT api/client/{id}
    
    
    Obs: Nome e CNPJ não poderam ser atualizados pois são dados imutável, sendo necessário deletar o cliente e fazer um novo registro ou realizar a mudança diretamente no banco de dados.

    body {
        "telefone": "new",
        "uf": "new",
        "cidade": "new",
        "bairro": "Próspera",
        "rua": "Belém",
        "nEndereco": 306,
        "cep": "88804-320"
    }

#### DELETAR CLIENTE
##### Endpoint: DELETE api/client/{id}

    {
        ...
    }

#### String de conexão PostGreSQL
Host=localhost;
Database=intelligenceEnergy;
Username=postgres;
Password=postgres