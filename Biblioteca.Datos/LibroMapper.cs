using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace Biblioteca.Datos
{
    class LibroMapper
    {
        public List<Libro> TraerTodos()
        {
            string json2 = WebHelper.Get("/Libros"); // trae un texto en formato json de una web
            List<Libro> resultado = MapList(json2);
            return resultado;
        }

        public TransactionResult Insert(Libro libro)
        {
            NameValueCollection obj = ReverseMap(libro);

            string result = WebHelper.Post("/Libro", obj);

            TransactionResult resultadoTransaccion = MapResultado(result);

            return resultadoTransaccion;
        }

        private List<Libro> MapList(string json)
        {
            List<Libro> lst = JsonConvert.DeserializeObject<List<Libro>>(json);
            return lst;
        }

        private NameValueCollection ReverseMap(Libro libro)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("Id", libro.Id.ToString()); // LONG 
            n.Add("Titulo", libro.Titulo);
            n.Add("Autor", libro.Autor);
            n.Add("Edicion", libro.Edicion.ToString()); // INT
            /*n.Add("Usuario", ConfigurationManager.AppSettings["Legajo"]); */
            n.Add("Editorial", libro.Editorial);
            n.Add("Paginas", libro.Paginas.ToString()); // INT
            n.Add("Tema", libro.Tema);
            return n;
        }

        private TransactionResult MapResultado(string json)
        {
            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);
            return lst;
        }


        //private Cliente MapObj(string json)
        //{
        //    var lst = JsonConvert.DeserializeObject<Cliente>(json);
        //    return lst;
        //}
        //public Cliente TraerPorCodigo(int codigo)
        //{
        //    string json2 = WebHelper.Get("/api/v1/cliente/" + codigo.ToString()); // trae un texto en formato json de una web
        //    Cliente resultado = MapObj(json2);
        //    return resultado;
        //}
    }
}
