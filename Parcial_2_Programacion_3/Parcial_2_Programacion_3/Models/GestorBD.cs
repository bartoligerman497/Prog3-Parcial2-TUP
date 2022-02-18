using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Parcial_2_Programacion_3.Models
{
    public class GestorBD
    {
        private SqlConnection conexión = new SqlConnection(@"Data Source =172.16.140.13;Initial Catalog=ParcialPro3Manana;User Id = alumno1w1;Password = alumno1w1");
        private SqlCommand comando = new SqlCommand();
        private SqlDataReader lector = null;

        public GestorBD()
        {
            comando = conexión.CreateCommand();
        }

        public List<Tipo> ObtenerTipos()
        {
            List<Tipo> tipos = new List<Tipo>();

            conexión.Open();

            comando.CommandText = "select * " +
                                  "from Tipos;";

            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                int id = lector.GetInt32(0);
                string nombre = lector.GetString(1);

                Tipo tipo = new Tipo(id, nombre);

                tipos.Add(tipo);
            }

            lector.Close();
            conexión.Close();

            return tipos;
        }

        public List<InstrumentoConTipo> ObtenerInstrumentosConTipo()
        {
            List<InstrumentoConTipo> instrumentosConTipo = new List<InstrumentoConTipo>();

            conexión.Open();

            comando.CommandText = "select * " +
                                  "from Instrumentos i join Tipos t on i.idTipo=t.id;";

            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                int id = lector.GetInt32(0);
                string nombre = lector.GetString(1);
                string descripcion = lector.GetString(2);
                int stock = lector.GetInt32(3);
                double precio = lector.GetDouble(4);
                string nombreTipo = lector.GetString(7);

                InstrumentoConTipo instrumentoConTipo = new InstrumentoConTipo(id, nombre, descripcion, stock, precio, nombreTipo);

                instrumentosConTipo.Add(instrumentoConTipo);
            }

            lector.Close();
            conexión.Close();

            return instrumentosConTipo;
        }

        public List<InstrumentoConTipo> ObtenerInstrumentosConTipoPercusion()
        {
            List<InstrumentoConTipo> instrumentosConTipo = new List<InstrumentoConTipo>();

            conexión.Open();

            comando.CommandText = "select * " +
                                  "from Instrumentos i join Tipos t on i.idTipo=t.id " +
                                  "where t.nombre = 'Percusion' " +
                                  "order by i.precio desc;";

            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                int id = lector.GetInt32(0);
                string nombre = lector.GetString(1);
                string descripcion = lector.GetString(2);
                int stock = lector.GetInt32(3);
                double precio = lector.GetDouble(4);
                string nombreTipo = lector.GetString(7);

                InstrumentoConTipo instrumentoConTipo = new InstrumentoConTipo(id, nombre, descripcion, stock, precio, nombreTipo);

                instrumentosConTipo.Add(instrumentoConTipo);
            }

            lector.Close();
            conexión.Close();

            return instrumentosConTipo;
        }

        public void InsertarInstrumento(Instrumento instrumento)
        {
            conexión.Open();

            comando.CommandText = "insert into Instrumentos " +
                                 "values (@nombre, @descripcion, @stock, @precio, @idTipo)";

            comando.Parameters.Add(new SqlParameter("@nombre", instrumento.Nombre));
            comando.Parameters.Add(new SqlParameter("@descripcion", instrumento.Descripcion));
            comando.Parameters.Add(new SqlParameter("@stock", instrumento.Stock));
            comando.Parameters.Add(new SqlParameter("@precio", instrumento.Precio));
            comando.Parameters.Add(new SqlParameter("@idTipo", instrumento.IdTipo));

            comando.ExecuteNonQuery();
            conexión.Close();
        }

        public void EliminarInstrumento(int id)
        {
            conexión.Open();

            comando.CommandText = "delete from Instrumentos where id=@id;";

            comando.Parameters.Add(new SqlParameter("@id", id));

            comando.ExecuteNonQuery();
            conexión.Close();
        }
    }
}