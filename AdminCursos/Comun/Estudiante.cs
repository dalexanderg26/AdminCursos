using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Estudiante : Persona
    {
        private string codigo;
        private bool estado;
        private int id;
        private string correoElectronico;
        private string nombresCompletos;

        public string Codigo { get => codigo; set => codigo = value; }
        public bool Estado { get => estado; set => estado = value; }
        public int Id { get => id; set => id = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }
        public string NombresCompletos { get => nombresCompletos; set => nombresCompletos = value; }

        public Estudiante()
        {
        }

        public Estudiante(int id)
        {
            this.Id = id;
        }

        public Estudiante(int id, string numeroDocumento, string primerApellido, string segundoApellido, string primerNombre, string segundoNombre)
        {
            this.Id = id;
            this.NumeroDocumento = numeroDocumento;
            this.PrimerApellido = primerApellido;
            this.SegundoApellido = segundoApellido;
            this.PrimerNombre = primerNombre;
            this.SegundoNombre = segundoNombre;
        }

        public Estudiante(DataRow fila)
        {
            StringBuilder nombresCompletos = new StringBuilder();
            this.Id = int.Parse(fila["Id"].ToString());
            this.TipoDocumento = new TipoDocumento(int.Parse(fila["IdTipoDocumento"].ToString()), fila["NombreTD"].ToString());
            this.NumeroDocumento = fila["NumeroDocumento"].ToString();
            this.PrimerNombre = fila["PrimerNombre"].ToString();
            this.SegundoNombre = fila["SegundoNombre"].ToString();
            this.PrimerApellido = fila["PrimerApellido"].ToString();
            this.SegundoApellido = fila["SegundoApellido"].ToString();
            this.CorreoElectronico = fila["CorreoElectronico"].ToString();
            this.estado = fila["Eliminado"].ToString().Equals("0");
            nombresCompletos.Append(this.PrimerApellido);
            nombresCompletos.Append(" ");
            nombresCompletos.Append(this.SegundoApellido);
            nombresCompletos.Append(" ");
            nombresCompletos.Append(this.PrimerNombre);
            nombresCompletos.Append(" ");
            nombresCompletos.Append(this.SegundoNombre);
            this.NombresCompletos = nombresCompletos.ToString();
        }

        public Resultado Guardar(Estudiante pEstudiante)
        {
            Resultado resultado = new Resultado();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            bool insertado = true;
            AccesoDatos acceso = new AccesoDatos();
            parametro.Nombre = "IdTipoDocumento";
            parametro.Valor = pEstudiante.TipoDocumento.Id;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "NumeroDocumento";
            parametro.Valor = pEstudiante.NumeroDocumento;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "PrimerNombre";
            parametro.Valor = pEstudiante.PrimerNombre;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "SegundoNombre";
            parametro.Valor = pEstudiante.SegundoNombre;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "PrimerApellido";
            parametro.Valor = pEstudiante.PrimerApellido;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "SegundoApellido";
            parametro.Valor = pEstudiante.SegundoApellido;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "CorreoElectronico";
            parametro.Valor = pEstudiante.CorreoElectronico;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "Celular";
            parametro.Valor = pEstudiante.Celular;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "Eliminado";
            parametro.Valor = pEstudiante.Estado;
            parametros.Add(parametro);

            insertado = acceso.Insertar("AgregarEstudiante", parametros);

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

        public Resultado Actualizar(Estudiante pEstudiante)
        {
            Resultado resultado = new Resultado();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            bool actualizado = true;
            AccesoDatos acceso = new AccesoDatos();
            parametro.Nombre = "EstudianteId";
            parametro.Valor = pEstudiante.Id;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "IdTipoDocumento";
            parametro.Valor = pEstudiante.TipoDocumento.Id;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "NumeroDocumento";
            parametro.Valor = pEstudiante.NumeroDocumento;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "PrimerNombre";
            parametro.Valor = pEstudiante.PrimerNombre;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "SegundoNombre";
            parametro.Valor = pEstudiante.SegundoNombre;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "PrimerApellido";
            parametro.Valor = pEstudiante.PrimerApellido;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "SegundoApellido";
            parametro.Valor = pEstudiante.SegundoApellido;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "CorreoElectronico";
            parametro.Valor = pEstudiante.CorreoElectronico;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "Celular";
            parametro.Valor = pEstudiante.Celular;
            parametros.Add(parametro);
            parametro = new Parametro();
            parametro.Nombre = "Eliminado";
            parametro.Valor = pEstudiante.Estado;
            parametros.Add(parametro);

            actualizado = acceso.Actualizar("ActualizarEstudiante", parametros);

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

        public List<Estudiante> Consultar(Estudiante pEstudiante)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            AccesoDatos acceso = new AccesoDatos();
            parametro.Nombre = "IdEstudiante";
            parametro.Valor = pEstudiante.Id;
            parametros.Add(parametro);
            DataTable tabla = acceso.Obtener("ObtenerEstudiante", parametros);

            if (tabla.Rows.Count > 0)
            {
                estudiantes = (from fila in tabla.AsEnumerable()
                               select new Estudiante(fila)).ToList();
            }

            return estudiantes;
        }


    }
}
    