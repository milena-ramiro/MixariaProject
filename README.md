![GitHub language count](https://img.shields.io/github/languages/count/milena-ramiro/Mixaria)
![GitHub](https://img.shields.io/github/license/milena-ramiro/Mixaria)

# :money_with_wings: Mixaria
## Projeto Mixaria em Xamarin Forms

### Sobre o Projeto
* O Projeto Mixaria tem como intuito ajudar as pessoas economizarem, dando-lhes a capacidade de comparar os preços do mesmo produto em diferentes mercados.
* Interface simples e intuitiva para que qualquer pessoa consiga utilizá-lo sem grandes dificuldades.
* Conta com a arquitetura padrão do Xamarin Forms MVVM.

### Avisos
* O Aplicativo só possuirá sua funcionalidade completa se o Webservice estiver ligado.
* Necessário mudar o endereço do Webservice de acordo com o novo endereço gerado em sua máquina ou serviço de hospedagem. Portanto, atentar-se ao arquivo ServiceWS dentro da pasta Servicos.

 ```
public static async Task<ObservableCollection<tbPromocao>> GetProdutos(int Estab)
{
    try
    {
        using (var client = new HttpClient())
        {
            // envia a requisição GET
            var uri = "http://52.179.98.74:8080/api/promocao/" + Estab; //MUDAR ESTA LINHA!
            var result = await client.GetStringAsync(uri);
            produtos = JsonConvert.DeserializeObject<ObservableCollection<tbPromocao>>(result);
        }

        return produtos;

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        return null;
    }

}
 ```




![porquinho](https://github.com/milena-ramiro/Mixaria/blob/master/porquinho.gif)

[Clique aqui para acessar o Webservice](https://github.com/milena-ramiro/Webservice) :computer:
