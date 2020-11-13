using Newtonsoft.Json;
using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Datos
{
    public class ClienteMapper
    {
        public List<Cliente> TraerTodos()
        {
            string json2 = WebHelper.Get("/cliente"); // trae un texto en formato json de una web
            List<Cliente> resultado = MapList(json2);
            return resultado;
        }

        public TransactionResult Insert(Cliente cliente)
        {
            NameValueCollection obj = ReverseMap(cliente);
            
            string result = WebHelper.Post("/cliente", obj);
            
            TransactionResult resultadoTransaccion = MapResultado(result);

            return resultadoTransaccion;
        }

        public TransactionResult Delete(Cliente cliente)
        {
            NameValueCollection obj = ReverseMap(cliente);

            string result = WebHelper.Delete("/cliente", obj);

            TransactionResult resultadoTransaccion = MapResultado(result);

            return resultadoTransaccion;
        }

        private List<Cliente> MapList(string json)
        {
            List<Cliente> lst = JsonConvert.DeserializeObject<List<Cliente>>(json);
            return lst;
        }

        private NameValueCollection ReverseMap(Cliente cliente)
        {
            NameValueCollection n = new NameValueCollection();
            //n.Add("Id", cliente.IdCliente.ToString());
            n.Add("Nombre", cliente.Nombre);
            n.Add("Apellido", cliente.Apellido);
            n.Add("Direccion", cliente.Direccion);
            n.Add("Usuario", ConfigurationManager.AppSettings["Legajo"]);
            //n.Add("Mail", cliente.Mail); // STRING
            n.Add("Telefono", cliente.Telefono.ToString()); // INT
            //n.Add("FechaAlta", cliente.FechaAlta.ToShortDateString()); // DateTime
            //n.Add("Activo", cliente.Activo.ToString()); // bool
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
