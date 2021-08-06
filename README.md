# CedTruck

Considerações:

Foi usado para a validação do formulário o framework FluentValidation, separado na pasta /Validators.

Migrate configurado para rodar automaticamente.

O contexto está configurado no arquivo /Models/DataContext.cs.

A tabela TruckModel com os valores FH e FM, como descrito no caso de uso, é populada automaticamente pelo DataContext.

Não foi aplicado nenhuma melhoria no estilo das páginas, ficando assim no padrão MVC default.

Foi feito apenas um modelo de teste unitário no projeto com o test result gerado pela biblioteca Run Coverlet Report.

Em outro projeto de Test eu apresento um modelo padrão de Test gerado pelo Nunit automaticamente para a classe TruckController, mas sem a implementação dos metodos de teste.

