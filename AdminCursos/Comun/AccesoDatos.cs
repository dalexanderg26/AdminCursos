using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Modelo
{
    public class AccesoDatos : IDAL
    {
        private MySqlConnection conexion;
        private string servidor;
        private string baseDatos;
        private string usuario;
        private string password;

        public AccesoDatos()
        {
            servidor = "localhost";
            baseDatos = "admincursos";
            usuario = "root";
            password = "Wrojas7351";
            StringBuilder cadena = new StringBuilder();
            cadena.Append("SERVER=");
            cadena.Append(servidor);
            cadena.Append(";");
            cadena.Append("DATABASE=");
            cadena.Append(baseDatos);
            cadena.Append(";");
            cadena.Append("UID=");
            cadena.Append(usuario);
            cadena.Append(";");
            cadena.Append("PASSWORD=");
            cadena.Append(password);
            cadena.Append(";");
            cadena.Append("SslMode=");
            cadena.Append("None");
            cadena.Append(";");

            conexion = new MySqlConnection(cadena.ToString());
        }

        private Resultado AbrirConexion()
        {
            Resultado resultado = new Resultado();
            try
            {
                conexion.Open();
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        resultado.Mensaje = "No puede conectarse al servidor";
                        break;

                    case 1045:
                        resultado.Mensaje = "Invalid username/password, please try again";
                        break;
                }

                resultado.Error = true;
            }

            return resultado;
        }

        //Close connection
        private bool CerrarConexion()
        {
            try
            {
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                // MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool Insertar(string pNombreProcedimiento, List<Parametro> pParametros)
        {
            return EjecutarConsulta(pNombreProcedimiento, pParametros);
        }

        public bool Actualizar(string pNombreProcedimiento, List<Parametro> pParametros)
        {
            return EjecutarConsulta(pNombreProcedimiento, pParametros);
        }

        public DataTable Obtener(string pNombreProcedimiento, List<Parametro> pParametros)
        {
            return ObtenerTabla(pNombreProcedimiento, pParametros);
        }

        private bool EjecutarConsulta(string pNombreProcedimiento, List<Parametro> pParametros)
        {
            int registrosAfectados = 0;
            Resultado resultado = new Resultado();
            resultado = AbrirConexion();

            if (resultado.Error == false)
            {
                MySqlCommand consulta = PrepararProcedimiento(pNombreProcedimiento, pParametros);
                registrosAfectados = consulta.ExecuteNonQuery();
                this.CerrarConexion();
            }

            return registrosAfectados > 0;
        }

        private DataTable ObtenerTabla(string pNombreProcedimiento, List<Parametro> pParametros)
        {
            DataTable tabla = new DataTable();

            Resultado resultado = new Resultado();
            resultado = AbrirConexion();

            if (resultado.Error == false)
            {
                MySqlCommand consulta = PrepararProcedimiento(pNombreProcedimiento, pParametros);
                MySqlDataReader rdr = consulta.ExecuteReader(CommandBehavior.CloseConnection);
                tabla.Load(rdr);
                this.CerrarConexion();
            }

            return tabla;
        }

        private MySqlCommand PrepararProcedimiento(string pNombreProcedimiento, List<Parametro> pParametros)
        {
            MySqlCommand consulta = new MySqlCommand(pNombreProcedimiento, conexion);
            consulta.CommandType = CommandType.StoredProcedure;

            foreach (Parametro parametro in pParametros)
            {
                consulta.Parameters.Add(new MySqlParameter(parametro.Nombre, parametro.Valor));
            }

            return consulta;
        }
    }
}
