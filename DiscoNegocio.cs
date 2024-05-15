using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DiscosApp
{
    internal class DiscoNegocio
    {
        public List<Disco> Listar()
        {
            List<Disco> lista = new List<Disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select D.Id, Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion as Estilo, T.Descripcion as Edicion From DISCOS D, ESTILOS E, TIPOSEDICION T Where D.IdEstilo = E.Id And D.IdTipoEdicion = T.Id";
                comando.Connection = conexion;

                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)lector["Id"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaLanzamiento = new DateTime();
                    aux.FechaLanzamiento = (DateTime)lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)lector["CantidadCanciones"];
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    aux.Estilo = new Estilo();
                    aux.Estilo.Descripcion = (string)lector["Estilo"];
                    aux.Edicion = new TipoEdicion();
                    aux.Edicion.Descripcion = (string)lector["Edicion"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
