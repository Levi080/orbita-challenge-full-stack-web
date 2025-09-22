# Comentários do Projeto e Documentação Técnica

Este documento detalha as alterações, decisões de design e a estrutura geral do projeto, conforme implementado nas etapas de desenvolvimento. Ele serve como uma referência rápida para entender o código e as escolhas de arquitetura.

## 1. Estrutura do Projeto e Componentes

A aplicação segue a estrutura padrão do Vue 3, com componentes únicos (.vue) para cada tela e um sistema de roteamento para navegação.

- **`src/views/StudentListView.vue`**: Este componente é a tela de consulta de alunos, responsável por exibir a tabela de dados, a barra de pesquisa e os botões de ação.
- **`src/views/StudentForm.vue`**: Este componente é a tela de cadastro e edição de alunos, onde os dados do estudante são inseridos e salvos.
- **`src/components/ConfirmDialog.vue`**: Este componente de utilidade é um modal de diálogo genérico para confirmações, como a exclusão de um aluno.

## 2. Lógica de Negócio (Pinia)

A gestão do estado da aplicação, incluindo a lista de alunos e o aluno selecionado para edição, é centralizada no Pinia, a biblioteca de gerenciamento de estado oficial do Vue.js.

- **`src/stores/studentStore.js`**: Este store é responsável por toda a lógica de negócio relacionada aos alunos, incluindo:
  - **Estado (`state`)**: Armazena a lista de alunos (`students`) e o aluno selecionado para edição (`studentSelected`).
  - **Ações (`actions`)**: Funções assíncronas para criar, buscar, atualizar e deletar alunos.

## 3. Estilização e Design (Vuetify)

O Vuetify 3 é utilizado para a interface do usuário. As decisões de design visam a clareza, a consistência e a responsividade.

- **Fontes**: A fonte padrão do Vuetify, **Roboto**, é explicitamente importada via Google Fonts no arquivo `index.html`. Isso garante que a fonte seja renderizada de forma consistente em todos os navegadores, independentemente de estar instalada localmente no sistema do usuário.
- **Componentes de Botão**: Os botões de ação na aplicação utilizam a propriedade `variant="elevated"` para ter um fundo sólido. Os ícones são adicionados com o componente `v-icon` para melhorar a usabilidade e o visual.
- **Layout de Formulário**: O formulário de cadastro de aluno é estruturado com o sistema de grade (Grid System) do Vuetify, usando `v-row` e `v-col`. Cada campo de entrada (`v-text-field`) está em uma `v-col` com `cols="12"`, garantindo que os campos fiquem um abaixo do outro e ocupem a largura total do contêiner.
- **Largura da Tabela e Formulário**: A largura da tabela de alunos e do formulário de cadastro é controlada com o `v-container` e as classes de espaçamento (`pa-4`, `px-10`). Isso cria um layout centralizado e responsivo que evita que o conteúdo se estenda por toda a largura em telas grandes.

### Estrutura de pastas

- **`src/`**: O diretório principal que contém todo o código-fonte da aplicação.
- **`assets/`**: Armazena arquivos estáticos como imagens, ícones e fontes.
- **`components/`**: Pasta para componentes reutilizáveis, como botões customizados e diálogos.
- **`models/`**: Onde os modelos de dados são definidos para manter a estrutura de dados consistente.
- **`plugins/`**: Diretório utilizado para configurar e inicializar plugins externos.
- **`router/`**: Contém a configuração de rotas da aplicação, mapeando cada URL para uma visualização (view) específica.
- **`stores/`**: Esta é a pasta das stores do Pinia, que centralizam o gerenciamento do estado e a lógica de comunicação com a API de backend.
- **`views/`**: Contém os componentes que representam as telas principais da aplicação, como `StudentForm.vue` e `StudentList.vue`.
- **`App.vue`**: O componente raiz da aplicação, onde o layout principal e o `router-view` são definidos.
- **`main.js`**: O ponto de entrada da aplicação, responsável por criar a instância do Vue e montar o aplicativo no DOM.
- **`.env`**: Arquivo para variáveis de ambiente, como a URL da API, mantendo as configurações de ambiente separadas do código-fonte.
- **`package.json` e `package-lock.json`**: Gerenciam todas as dependências do projeto e scripts de execução.

---

## Documentação do Backend (ASP.NET Core)

Esta seção detalha a arquitetura, as funcionalidades e a estrutura do backend da aplicação de gestão de alunos, desenvolvido em C# com ASP.NET Core.

### 1. Estrutura do Projeto

O projeto segue a arquitetura em camadas, uma abordagem que promove a separação de responsabilidades, facilitando a manutenção, escalabilidade e testes. A solução é dividida em três projetos principais:

- **AmaisEducacao.API**: A camada de apresentação e interface com o cliente.  
  - **Responsabilidade**: Contém os controladores (como o `StudentController`) que expõem os endpoints da API RESTful. Gerencia a entrada de requisições HTTP e a saída de respostas, servindo como a porta de entrada para a aplicação.

- **AmaisEducacao.Data**: A camada de acesso a dados.  
  - **Responsabilidade**: Interage diretamente com a fonte de dados (banco de dados, por exemplo). É aqui que se encontram os repositórios (Repositories) e o contexto do banco de dados (DbContext), responsáveis por operações de CRUD (Create, Read, Update, Delete).

- **AmaisEducacao.Domain**: A camada de domínio e lógica de negócio.  
  - **Responsabilidade**: Contém as entidades de negócio (Models), como a classe `Student`, e a lógica de negócio central da aplicação (como validações e regras de negócio). Esta camada é independente das outras e não tem conhecimento da API ou da camada de dados.

### 2. Endpoints da API RESTful

O `StudentController` expõe os seguintes endpoints, permitindo que o frontend execute operações de CRUD (Create, Read, Update, Delete) nos dados dos alunos:

| Método HTTP | Endpoint              | Descrição                           | Parâmetros |
|-------------|-----------------------|-------------------------------------|------------|
| `GET`       | `/api/students`       | Retorna a lista de todos os alunos. | Nenhum     |
| `GET`       | `/api/students/{ra}`  | Retorna um aluno específico.        | `ra` (string) |
| `POST`      | `/api/students`       | Cria um novo aluno.                 | Corpo da requisição com os dados do aluno |
| `PUT`       | `/api/students`       | Atualiza os dados de um aluno.      | Corpo da requisição com os dados a serem atualizados |
| `DELETE`    | `/api/students/{ra}`  | Exclui um aluno.                    | `ra` (string) |

### 3. Pacotes Utilizados

- **Banco de dados**
  - Microsoft.EntityFrameworkCore.Design
  - Npgsql.EntityFrameworkCore.PostgreSQL
  - Microsoft.EntityFrameworkCore.Tools

- **Validação da requisição ao chegar na controller**
  - System.ComponentModel.DataAnnotations

### 4. Modelagem de Dados

A entidade `Student` é definida em uma classe C# que representa a estrutura de dados de um aluno, incluindo as seguintes propriedades:

```csharp
public class Student
{
    public string RA { get; set; }
    public string Name { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? DeletionDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}
```

### 5. Escopo de Melhorias e Implementações Futuras
- **1. Persistência de Logs**

   - Implementar logs em todos os blocos try/catch para registrar erros em um sistema de log. Isso permitirá investigação detalhada de falhas e criação de relatórios de erros.

- **2. Procedures + DAO/BUS**

    - Substituir queries diretas do Entity Framework por stored procedures quando houver operações complexas e de alto desempenho.

   - Adotar o padrão DAO (Data Access Object) para isolar o acesso ao banco de dados.

   - Introduzir o padrão BUS (Business Layer) para centralizar as regras de negócio, reduzindo a responsabilidade da API.

- **3. Testes Unitários**

   - Criar testes unitários para os repositórios e serviços.