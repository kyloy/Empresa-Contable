using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    class CatagOtrosEgre
    {
        public int idCatalogo_OtrosEgresos { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }

        public CatagOtrosEgre() { }

        public CatagOtrosEgre(int pidegreso, string pClave, string pDescripcion)
        {
            this.idCatalogo_OtrosEgresos = pidegreso;
            this.Clave = pClave;
            this.Descripcion = pDescripcion;
        }
    }
}
