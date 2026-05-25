# 📌 Task Tracker CLI

Uma aplicação simples de linha de comando (CLI) para gerenciamento de tarefas, desenvolvida para praticar manipulação de arquivos, entrada de dados via terminal e organização de lógica de programação.

## 🚀 Sobre o Projeto

O Task Tracker CLI permite adicionar, atualizar, remover e acompanhar tarefas diretamente pelo terminal.
As tarefas são armazenadas em um arquivo .json, funcionando como um pequeno banco de dados local.

Este projet o foi desenvolvido com foco em:

Manipulação de arquivos JSON
Estruturação de aplicações CLI
Tratamento de erros
Organização de código
Prática com lógica de programação
### ⚙️ Funcionalidades

✅ Adicionar tarefas
✅ Atualizar tarefas
✅ Excluir tarefas
✅ Marcar tarefas como:

todo
in-progress
done

✅ Listar:

Todas as tarefas
Apenas tarefas pendentes
Apenas tarefas em andamento
Apenas tarefas concluídas
🛠️ Tecnologias Utilizadas
Linguagem: C#
.NET
Manipulação de arquivos JSON
CLI (Command Line Interface)

## 💻 Comandos Disponíveis
### ➕ Adicionar tarefa
task-cli add "Comprar mantimentos"

### Saída:
Task added successfully (ID: 1)

### ✏️ Atualizar tarefa
task-cli update 1 "Comprar mantimentos e cozinhar jantar"

### ❌ Excluir tarefa
task-cli delete 1
### 🔄 Marcar tarefa como em andamento
task-cli mark-in-progress 1
### ✅ Marcar tarefa como concluída
task-cli mark-done 1

### 📄 Listagem de Tarefas
##### Todas as tarefas
task-cli list
##### Apenas tarefas concluídas
task-cli list done
##### Apenas tarefas pendentes
task-cli list todo
##### Apenas tarefas em andamento
task-cli list in-progress

## Url do Projeto do RoadMap
https://roadmap.sh/projects/task-tracker