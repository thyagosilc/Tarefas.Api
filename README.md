# Tarefas.Api
Aplicação REST usando .NET core 6
Como rodar o projeto local.


1 PASSO: 
Selecionar o ambiente de execução: (IIS-DEV) ou (Tarefas.Api)
![image](https://user-images.githubusercontent.com/9157652/227241106-4c027458-5660-45a5-ba58-f43ad26c9c63.png)
 

2 PASSO: 
 Verificar se o appsettings.json está apontando para localdb 

3 PASSO: 
Criar o conteiner docker para o rabbitmq. 
Executar o comando no cmd:  docker run --rm -it -p 15672:15672 -p 5672:5672 rabbitmq:3-management

 
Execução da API em localhost.
Criar o conteiner docker para execução local: docker run --rm -it -p 15672:15672 -p 5672:5672 rabbitmq:3-management
Caso necessario: Alterar url da API no app= TararefaAppAngula: arquivo Tarefas.Service.ts
