using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Modelo
{
    public class Curso
    {
        private int id;
        private string nombre;
        private string descripcion;
        private Modalidad modalidad;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private DateTime? fechaLimiteInscripcion;
        private int horas;
        private int totalCupos;
        private bool cerrado;

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Modalidad Modalidad { get => modalidad; set => modalidad = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public DateTime? FechaLimiteInscripcion { get => fechaLimiteInscripcion; set => fechaLimiteInscripcion = value; }
        public int Horas { get => horas; set => horas = value; }
        public int TotalCupos { get => totalCupos; set => totalCupos = value; }
        public bool Cerrado { get => cerrado; set => cerrado = value; }

        public Curso()
        {
        }

        public Curso(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public Curso(DataRow fila)
        {
            this.Id = int.Parse(fila["Id"].ToString());
            this.Nombre = fila["Nombre"].ToString();
            this.Descripcion = fila["Descripcion"].ToString();
            this.Modalidad = new Modalidad(int.Parse(fila["IdModalidad"].ToString()), fila["NombreModalidad"].ToString());
            this.FechaInicio = Convert.ToDateTime(fila["FechaInicio"].ToString());
            this.FechaFin = Convert.ToDateTime(fila["FechaFin"].ToString());
            this.FechaLimiteInscripcion = Convert.ToDateTime(fila["FechaLimiteInscripcion"].ToString());
            this.Horas = int.Parse(fila["Horas"].ToString());
            this.TotalCupos = int.Parse(fila["TotalCupos"].ToString());
            this.Cerrado = fila["Eliminado"].ToString().Equals("0") == false;
        }

        public Resultado Guardar(Curso pCurso)
        {
            Resultado resultado = new Resultado();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            bool insertado = true;
            AccesoDatos acceso = new AccesoDatos();
            parametro.Nombre = "Nombre";
            parametro.Valor = pCurso.Nombre;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "Descripcion";
            parametro.Valor = pCurso.Descripcion;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "FechaInicio";
            parametro.Valor = pCurso.FechaInicio;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "FechaFin";
            parametro.Valor = pCurso.FechaFin;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "FechaLimiteInscripcion";
            parametro.Valor = pCurso.FechaLimiteInscripcion;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "Horas";
            parametro.Valor = pCurso.Horas;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "TotalCupos";
            parametro.Valor = pCurso.TotalCupos;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "Eliminado";
            parametro.Valor = pCurso.Cerrado;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "IdModalidad";
            parametro.Valor = pCurso.Modalidad.Id;
            parametros.Add(parametro);

            insertado = acceso.Insertar("AgregarCurso", parametros);

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

        public Resultado Actualizar(Curso pCurso)
        {
            Resultado resultado = new Resultado();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            bool actualizado = true;
            AccesoDatos acceso = new AccesoDatos();
            parametro.Nombre = "CursoId";
            parametro.Valor = pCurso.Id;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "Nombre";
            parametro.Valor = pCurso.Nombre;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "Descripcion";
            parametro.Valor = pCurso.Descripcion;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "FechaInicio";
            parametro.Valor = pCurso.FechaInicio;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "FechaFin";
            parametro.Valor = pCurso.FechaFin;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "FechaLimiteInscripcion";
            parametro.Valor = pCurso.FechaLimiteInscripcion;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "Horas";
            parametro.Valor = pCurso.Horas;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "TotalCupos";
            parametro.Valor = pCurso.TotalCupos;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "Eliminado";
            parametro.Valor = pCurso.Cerrado;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "IdModalidad";
            parametro.Valor = pCurso.Modalidad.Id;
            parametros.Add(parametro);

            actualizado = acceso.Actualizar("ActualizarCurso", parametros);

            if (actualizado == true)
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

        public List<Curso> Consultar(Curso pCurso)
        {
            List<Curso> cursos = new List<Curso>();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            AccesoDatos acceso = new AccesoDatos();
            parametro.Nombre = "IdCurso";
            parametro.Valor = pCurso.Id;
            parametros.Add(parametro);
            DataTable tabla = acceso.Obtener("ObtenerCursos", parametros);

            if (tabla.Rows.Count > 0)
            {
                cursos = (from fila in tabla.AsEnumerable()
                          select new Curso(fila)).ToList();
            }

            return cursos;
        }


    }
}