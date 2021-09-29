# pi3
Projeto Integrador III

# Subindo codigo para github
```
git add .
git commit -m "descricao commit"
git pull origin main
git push origin main

```
# Instalação
```
git clone https://github.com/Ferreiramg/pi3.git
```
```cmd
cd pi3

dotnet build
>Build succeeded.
    0 Warning(s)
    0 Error(s)

dotnet run
>info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
```
# Trello
[Tarefas](https://trello.com/b/Msk3qZXR/modelo-de-projeto-scrum)

## Problemas
>It was not possible to find any compatible framework version
The framework 'Microsoft.AspNetCore.App', version '3.1.0' was not found.

 Abra o arquivo `cadastro-estudante.csproj` e alterar a tag para ``netcoreapp3.1`` 
```
<TargetFramework>netcoreapp5.0</TargetFramework>
```

