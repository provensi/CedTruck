# CedTruck

Considerações:

Foi usado para a validação do formulário o framework FluentValidation, separado na pasta /Validators.

Migrate configurado para rodar automaticamente.

O contexto está configurado no arquivo /Models/DataContext.cs.

A tabela TruckModel com os valores FH e FM, como descrito no caso de uso, é populada automaticamente pelo DataContext.

Não foi aplicado nenhuma melhoria no estilo das páginas, ficando assim no padrão MVC default.

Os testes foram feitos com o XUnit e estão no projeto /XUnit.CedTruck.Tests

