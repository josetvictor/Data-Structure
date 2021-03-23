# Estrutura de Dados

## Instalação .NET no linux

  Antes da instalação do dotnet é preciso:
  * Registrar a chave da Microsoft
  * Registrar o repositorio do produto
  * Instale as dependências necessárias

  Digite no terminal os seguintes comandos

  ```bash
  wget -q https://packages.microsoft.com/config/ubuntu/19.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb

  sudo dpkg -i packages-microsoft-prod.deb
  ```
  ### Instalar o SDK do .NET core

  ```bash
  sudo apt-get update
  
  sudo apt-get install apt-transport-https

  sudo apt-get install dotnet-sdk-3.1
  ```

## Comandos dotnet

### Criar um novo projeto

```bash
dotnet new console -o <diretorio>
```
### Rodando projeto criado

```bash
dotnet run
```