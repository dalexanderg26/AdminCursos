using System.Collections.Generic;
using System.Data;

namespace Modelo
{
    public interface IDAL
    {
        bool Insertar(string pNombreProcedimiento, List<Parametro> pParametros);
        bool Actualizar(string pNombreProcedimiento, List<Parametro> pParametros);
        DataTable Obtener(string pNombreProcedimiento, List<Parametro> pParametros);
    }
}
