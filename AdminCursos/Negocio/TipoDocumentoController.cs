using Interfaces;
using Modelo;

namespace Controladores
{
    public class TipoDocumentoController : IOperaciones
    {
        public object Guardar(object pTipoDocumento)
        {
            TipoDocumento tipoDocumento = new TipoDocumento();
            return tipoDocumento.Guardar((TipoDocumento)pTipoDocumento);
        }

        public object Actualizar(object pTipoDocumento)
        {
            TipoDocumento tipoDocumento = new TipoDocumento();
            return tipoDocumento.Actualizar((TipoDocumento)pTipoDocumento);
        }

        public object Consultar(object pTipoDocumento)
        {
            TipoDocumento tipoDocumento = new TipoDocumento();
            return tipoDocumento.Consultar((TipoDocumento)pTipoDocumento);
        }
    }
}

