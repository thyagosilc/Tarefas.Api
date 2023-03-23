# Tarefas.Api
Como rodar o projeto local.


1 PASSO: 

Selecionar o ambiente de execução: (IIS-DEV) ou (Tarefas.Api)
![image](https://user-images.githubusercontent.com/9157652/227241106-4c027458-5660-45a5-ba58-f43ad26c9c63.png)
 


2 PASSO: 

 Verificar se o appsettings.json está apontando para localdb 
![image](https://user-images.githubusercontent.com/9157652/227243855-1774f28b-97f8-4e7b-bdc5-fd62ec6e5569.png)



3 PASSO: 

Criar o conteiner docker para o rabbitmq. 
![image](https://user-images.githubusercontent.com/9157652/227244365-447ce055-1b7a-4a71-aa9e-9933d1ecd5f7.png)


Executar esse comando no cmd:   docker run --rm -it -p 15672:15672 -p 5672:5672 rabbitmq:3-management

![image](https://user-images.githubusercontent.com/9157652/227245143-e72c00c8-521c-4aee-8b58-0f71e1bac349.png)

http://localhost:15672/

Usuário: guest Senha: guest 

4 PASSO:
Start no projeto

![image](https://user-images.githubusercontent.com/9157652/227245963-df7a8481-10d5-4727-8046-af24700729ed.png)


Resultado:
![image](https://user-images.githubusercontent.com/9157652/227246423-fadaca1b-6d09-4b85-bc85-32442d76e8dd.png)
