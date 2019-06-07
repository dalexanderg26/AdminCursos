using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;

namespace Modelo
{
    [Serializable]
    [DataContract(Namespace = "http://AdminCursos.Modalidad/")]
    public class Modalidad
    {
        private int id;
        private string nombre;

        [DataMember(IsRequired = false)]
        public int Id { get => id; set => id = value; }

        [DataMember(IsRequired = false)]
        public string Nombre { get => nombre; set => nombre = value; }

        public Modalidad()
        {
        }

        public Modalidad(DataRow fila)
        {
            this.Id = int.Parse(fila["id"].ToString());
            this.Nombre = fila["nombre"].ToString();
        }

        public Modalidad(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public Resultado Guardar(Modalidad pModalidad)
        {
            Resultado resultado = new Resultado();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            bool insertado = true;
            AccesoDatos acceso = new AccesoDatos();
            parametro.Nombre = "Nombre";
            parametro.Valor = pModalidad.Nombre;
            parametros.Add(parametro);
            insertado = acceso.Insertar("AgregarModalidad", parametros);

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

        public Resultado Actualizar(Modalidad pModalidad)
        {
            Resultado resultado = new Resultado();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            bool insertado = true;
            AccesoDatos acceso = new AccesoDatos();
            parametro.Nombre = "Nombre";
            parametro.Valor = pModalidad.Nombre;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "Id";
            parametro.Valor = pModalidad.Id;
            parametros.Add(parametro);
            insertado = acceso.Actualizar("ActualizarModalidad", parametros);

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

        public List<Modalidad> Consultar(Modalidad pModalidad)
        {
            List<Modalidad> modalidades = new List<Modalidad>();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            AccesoDatos acceso = new AccesoDatos();
            parametro.Nombre = "pId";
            parametro.Valor = pModalidad.Id;
            parametros.Add(parametro);
            DataTable tabla = acceso.Obtener("ObtenerModalidad", parametros);

            if (tabla.Rows.Count > 0)
            {
                modalidades = (from fila in tabla.AsEnumerable()
                               select new Modalidad(fila)).ToList();
            }

            return modalidades;
        }

    }
}
