#   Webservice  :computer:
## Webservice Asp .Net - Projeto Mixaria

### Sobre o Projeto
* O Webservice EconomizeMais foi feito para o cadastro dos mercados e seus produtos, dados que serão utilizados para o aplicativo mobile Mixaria.
* Criado utilizando os padrões da arquitetura MVC.
* Primeiramente o EconomizeMais foi hospedado na plataforma de serviços Google cloud. Posteriormente, por questões de didáticas (como também de custo),
hospedamos ele na plataforma de serviços Azure.

### Orientações
* Para que o Webservice se torne utilizável pelo o app Mixaria, orientamos que você hospede ele em alguma plataforma de serviço (Recomendo o Azure, uma vez que o mesmo possui um período gratuito para testes oferecendo vários recursos, inclusive o Windows Server).
* É importante também lembrar que este projeto está ligado à um banco de dados SQL Server, por isso a string de conexão deve ser alterada conforme o caminho de seu banco de dados dentro do arquivo Web.config

```
<connectionStrings><add name="dbWebMixariaEntities" connectionString="metadata=res://*/dbWebMixaria.csdl|res://*/dbWebMixaria.ssdl|res://*/dbWebMixaria.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=MIXARIAVM\SQLEXPRESS;initial catalog=dbWebMixaria;persist security info=True;user id=sa;password=SuaSenhaAqui;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" /></connectionStrings>
```


### Agradecimentos
* Agradeço ao meu colega de trabalho Pedro Martins pela ajuda na criação deste projeto.

[Clique aqui para acessar o app Mixaria](https://github.com/milena-ramiro/Mixaria)  :money_with_wings:
