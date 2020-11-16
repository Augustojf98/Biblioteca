using Biblioteca.Entidades;
using Biblioteca.Datos;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            string usuarioUtilizado;
            string usuario1 = ConfigurationManager.AppSettings["Legajo1"];
            string usuario2 = ConfigurationManager.AppSettings["Legajo2"];
            string usuario3 = ConfigurationManager.AppSettings["Legajo3"];

            if (usuario1 != null)
                usuarioUtilizado = usuario1;
            else if (usuario2 != null)
                usuarioUtilizado = usuario2;
            else if (usuario3 != null)
                usuarioUtilizado = usuario3;
            else
                throw new Exception("El usuario de interacción con el servidor es incorrecto.");

            NameValueCollection n = new NameValueCollection();
            n.Add("id", libro.Id.ToString()); // INT 
            n.Add("Titulo", libro.Titulo);
            n.Add("Autor", libro.Autor);
            n.Add("Usuario", usuarioUtilizado);
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
