using Biblioteca.Entidades;
using Biblioteca.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace Biblioteca.Datos
{
    public class LibroMapper
    {
        public List<Libro> TraerTodos()
        {
            string json2 = WebHelper.Get("/Biblioteca/Libros"); // trae un texto en formato json de una web
            List<Libro> resultado = MapList(json2);
            return resultado;
        }

        public TransactionResult Insert(Libro libro)
        {
            NameValueCollection obj = ReverseMap(libro);

            string result = WebHelper.Post("/Biblioteca/Libros", obj);

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
            n.Add("id", libro.Id.ToString()); // INT 
            n.Add("Titulo", libro.Titulo);
            n.Add("Autor", libro.Autor);
            n.Add("Edicion", libro.Edicion.ToString()); // INT
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
    }
}
