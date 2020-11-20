using Biblioteca.Entidades;
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
    public class PrestamoMapper
    {
        public List<Prestamo> TraerTodos()
        {
            string json2 = WebHelper.Get("/Biblioteca/Prestamos"); // trae un texto en formato json de una web
            List<Prestamo> resultado = MapList(json2);
            return resultado;
        }

        public TransactionResult Insert(Prestamo prestamo)
        {
            NameValueCollection obj = ReverseMap(prestamo);

            string result = WebHelper.Post("/Biblioteca/Prestamos", obj);

            TransactionResult resultadoTransaccion = MapResultado(result);

            return resultadoTransaccion;
        }

        public TransactionResult Delete(Prestamo prestamo)
        {
            NameValueCollection obj = ReverseMap(prestamo);

            string result = WebHelper.Delete("/Biblioteca/Prestamos", obj);

            TransactionResult resultadoTransaccion = MapResultado(result);

            return resultadoTransaccion;
        }

        public TransactionResult Put(Prestamo prestamo)
        {
            NameValueCollection obj = ReverseMap(prestamo);

            string result = WebHelper.Put("/Biblioteca/Prestamos", obj);

            TransactionResult resultadoTransaccion = MapResultado(result);

            return resultadoTransaccion;
        }

        private List<Prestamo> MapList(string json)
        {
            List<Prestamo> lst = JsonConvert.DeserializeObject<List<Prestamo>>(json);
            return lst;
        }

        private NameValueCollection ReverseMap(Prestamo prestamo)
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
            n.Add("id", prestamo.Id.ToString()); // INT 
            n.Add("idEjemplar", prestamo.IdEjemplar.ToString());
            n.Add("idCliente", prestamo.IdCliente.ToString());
            n.Add("Usuario", usuarioUtilizado);
            n.Add("Abierto", prestamo.EstaAbierto.ToString());
            n.Add("FechaPrestamo", prestamo.FechaAlta.ToString());
            n.Add("FechaDevolucionTentativa", prestamo.FechaBaja.ToString()); // INT
            n.Add("FechaDevolucionReal", prestamo.FechaBajaReal.ToString());
            return n;
        }

        private TransactionResult MapResultado(string json)
        {
            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);
            return lst;
        }
    }
}
