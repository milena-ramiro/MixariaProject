using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomizeMais.Repositório
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> GetTodos();
        //IEnumerable<T> GetTodosJson();
        IEnumerable<T> GetAlguns(int id);
    }
}