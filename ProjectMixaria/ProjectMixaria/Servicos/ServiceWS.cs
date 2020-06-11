using Newtonsoft.Json;
using ProjectMixaria.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMixaria.Servicos
{
    public class ServiceWS
    {
        #region CAMPOS
        public static ObservableCollection<tbPromocao> produtos;
        public static ObservableCollection<tbEstab> estabs;
        public static ObservableCollection<tbTop30> top30;

        #endregion

        public static async Task<ObservableCollection<tbPromocao>> GetProdutos(int Estab)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // envia a requisição GET
                    var uri = "http://52.179.98.74:8080/api/promocao/" + Estab;
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


        public static async Task<ObservableCollection<tbEstab>> GetMercados()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // envia a requisição GET
                    var uri = "http://52.179.98.74:8080/api/estab";
                    var result = await client.GetStringAsync(uri);
                    estabs = JsonConvert.DeserializeObject<ObservableCollection<tbEstab>>(result);
                }

                return estabs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }

        public static async Task<ObservableCollection<tbTop30>> GetTopProdutos()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // envia a requisição GET
                    var uri = "http://52.179.98.74:8080/api/TopProdutos";
                    var result = await client.GetStringAsync(uri);
                    top30 = JsonConvert.DeserializeObject<ObservableCollection<tbTop30>>(result);
                }

                return top30;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }

    }
}
