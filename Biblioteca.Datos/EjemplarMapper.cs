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
    public class EjemplarMapper
    {
        public List<Ejemplar> TraerTodos()
        {
            string json2 = WebHelper.Get("/Biblioteca/Ejemplares"); // trae un texto en formato json de una web
            List<Ejemplar> resultado = MapList(json2);
            return resultado;
        }

        public List<Ejemplar> TraerPorLibro(int idLibro)
        {
            string json2 = WebHelper.Get(string.Format("/Biblioteca/Ejemplares/{0}", idLibro)); // trae un texto en formato json de una web
            List<Ejemplar> resultado = MapList(json2);
            return resultado;
        }

        public TransactionResult Insert(Ejemplar ejemplar)
        {
            NameValueCollection obj = ReverseMap(ejemplar);

            string result = WebHelper.Post("/Biblioteca/Ejemplares", obj);

            TransactionResult resultadoTransaccion = MapResultado(result);

            return resultadoTransaccion;
        }

        private List<Ejemplar> MapList(string json)
        {
            List<Ejemplar> lst = JsonConvert.DeserializeObject<List<Ejemplar>>(json);
            return lst;
        }

        private NameValueCollection ReverseMap(Ejemplar ejemplar)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("id", ejemplar.Id.ToString()); // LONG 
            n.Add("id_Libro", ejemplar.IdLibro.ToString());
            n.Add("Observaciones", ejemplar.Observaciones);
            n.Add("Precio", ejemplar.Precio.ToString()); // INT
            n.Add("FechaAlta", ejemplar.FechaAlta.ToString());
            return n;
        }

        private TransactionResult MapResultado(string json)
        {
            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);
            return lst;
        }

    }
}
