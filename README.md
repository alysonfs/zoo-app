# Sistema de Gestão de Zoológico

## Instruções

Implemente um sistema que gerencie animais e visitantes no zoológico. Cada animal e visitante deve ter características específicas, e o sistema deve permitir interações entre eles.

## Requisitos

### 1. Classes de Animais:

- Crie uma classe base `Animal` com propriedades comuns como ID (int), Nome (string), Espécie (string), DataDeNascimento (DateTime) e métodos como `EmitirSom()`.
- Implemente subclasses para tipos específicos de animais (por exemplo, `Leao`, `Elefante`, `Macaco`), cada uma com um som específico (`EmitirSom`).

### 2. Classes de Visitantes:

- Crie uma classe `Visitante` com propriedades como ID (int), Nome (string), Idade (int) e métodos como `InteragirComAnimal(Animal animal)`.

### 3. Interações:

- O método `InteragirComAnimal` deve simular uma interação entre o visitante e o animal, podendo incluir a emissão do som do animal e uma mensagem de resposta do visitante.
- Exemplo: Se o visitante interagir com um leão, o leão deve rugir e o visitante pode responder com uma mensagem como “Uau, que rugido incrível!”.

### 4. Gestão de Zoológico:

- Crie uma classe `Zoologico` que gerencie a lista de animais e visitantes.
- O sistema deve permitir adicionar novos animais e visitantes ao zoológico.
- O sistema deve permitir listar todos os animais e visitantes presentes no zoológico.
- O sistema deve permitir que um visitante interaja com um animal específico.

## Regras e Considerações

- Utilize boas práticas de programação orientada a objetos.
- Implemente testes unitários para garantir o funcionamento correto do sistema.
- Documente o código e adicione comentários explicativos onde achar necessário.

## Exemplos de Uso

- Adicionar um novo leão ao zoológico com o nome “Simba” e a data de nascimento “01/01/2015”.
- Adicionar um novo visitante com o nome “Alice” e a idade 10 anos.
- Listar todos os animais e visitantes no zoológico.
- Fazer com que “Alice” interaja com “Simba” e exibir o resultado da interação.


# Zoo App Monorepo
## Estrutura do Projeto

```
/zoo-app-monorepo
  ├── /src
  │   ├── /ZooApp.WebAPI             # Projeto .NET Core WebAPI para o backend
  │   ├── /ZooApp.Frontend           # Aplicação Angular para o frontend
  │   └── /zoo-app.sln               # Solução .NET para os projetos dentro de src
  ├── /tests
  |   ├── /http                      # Requisições de teste, para facilar o uso
  │   └── /ZooApp.WebAPITests        # Testes para o projeto .NET Core WebAPI usando NUnit
  ├── README.md                      # Documentação inicial do monorepo
  └── zoo-app-monorepo.sln           # Solução principal que referencia os projetos individuais
```

### Pacotes de referência do projeto 'ZooApp.WebAPITests'
```
   [net8.0]: 
   Top-level Package             Requested   Resolved
   > coverlet.collector          6.0.0       6.0.0   
   > Microsoft.NET.Test.Sdk      17.8.0      17.8.0  
   > NUnit                       3.14.0      3.14.0  
   > NUnit.Analyzers             3.9.0       3.9.0   
   > NUnit3TestAdapter           4.5.0       4.5.0   
```

### Pacotes de referência do projeto 'ZooApp.WebAPI'
```
   [net8.0]: 
   Top-level Package                   Requested   Resolved
   > Microsoft.AspNetCore.OpenApi      8.0.6       8.0.6   
   > Swashbuckle.AspNetCore            6.4.0       6.4
```

### Informações sobre o ambiente Angular
```
Angular CLI: 18.1.3
Node: 20.16.0
Package Manager: npm 10.8.1
OS: darwin x64

Angular: 

Package                      Version
@angular-devkit/architect    0.1801.3 (cli-only)
@angular-devkit/core         18.1.3 (cli-only)
@angular-devkit/schematics   18.1.3 (cli-only)
@schematics/angular          18.1.3 (cli-only)
```

Para adicionar um certificado SSL para desenvolvimento, execute o seguinte comando:
```
dotnet dev-certs https --trust
```