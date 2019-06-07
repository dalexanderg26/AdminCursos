using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Modelo
{
    public class TipoDocumento
    {
        private int id;
        private string nombre;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public TipoDocumento()
        {
        }

        public TipoDocumento(DataRow fila)
        {
            this.Id = int.Parse(fila["id"].ToString());
            this.Nombre = fila["nombre"].ToString();
        }

        public TipoDocumento(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public Resultado Guardar(TipoDocumento pTipoDocumento)
        {
            Resultado resultado = new Resultado();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            bool insertado = true;
            AccesoDatos acceso = new AccesoDatos();
            parametro.Nombre = "pTipoDocumento";
            parametro.Valor = pTipoDocumento.Nombre;
            parametros.Add(parametro);
            insertado = acceso.Insertar("AgregarTipoDocumento", parametros);

            if (insertado == true)
            {
                resultado.Error = false;
                resultado.Mensaje = string.Empty;
            }
            else
            {
                resultado.Error = true;
                resultado.Mensaje = "Error al crear el registro";
            }

            return resultado;
        }

        public Resultado Actualizar(TipoDocumento pTipoDocumento)
        {
            Resultado resultado = new Resultado();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            bool insertado = true;
            AccesoDatos acceso = new AccesoDatos();
            parametro.Nombre = "pTipoDocumento";
            parametro.Valor = pTipoDocumento.Nombre;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "pId";
            parametro.Valor = pTipoDocumento.Id;
            parametros.Add(parametro);
            insertado = acceso.Actualizar("ActualizarTipoDocumento", parametros);

            if (insertado == true)
            {
                resultado.Error = false;
                resultado.Mensaje = string.Empty;
            }
            else
            {
                resultado.Error = true;
                resultado.Mensaje = "Error al actualizar el registro";
            }

            return resultado;
        }

        public List<TipoDocumento> Consultar(TipoDocumento pTipoDocumento)
        {
            List<TipoDocumento> tiposDocumento = new List<TipoDocumento>();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            AccesoDatos acceso = new AccesoDatos();
            parametro.Nombre = "pId";
            parametro.Valor = pTipoDocumento.Id;
            parametros.Add(parametro);
            DataTable tabla = acceso.Obtener("ObtenerTipoDocumento", parametros);

            if (tabla.Rows.Count > 0)
            {
                tiposDocumento = (from fila in tabla.AsEnumerable()
                                  select new TipoDocumento(fila)).ToList();
            }

            return tiposDocumento;
        }

    }
}