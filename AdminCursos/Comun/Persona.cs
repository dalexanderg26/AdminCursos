
namespace Modelo
{
    public class Persona
    {
        private string documento;
        private TipoDocumento tipoDocumento;
        private string primerNombre;
        private string segundoNombre;
        private string primerApellido;
        private string segundoApellido;
        private string genero;
        private string celular;

        public string NumeroDocumento { get => documento; set => documento = value; }
        public TipoDocumento TipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
        public string PrimerNombre { get => primerNombre; set => primerNombre = value; }
        public string SegundoNombre { get => segundoNombre; set => segundoNombre = value; }
        public string PrimerApellido { get => primerApellido; set => primerApellido = value; }
        public string SegundoApellido { get => segundoApellido; set => segundoApellido = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Genero { get => genero; set => genero = value; }


        public Persona()
        {
        }
    }
}