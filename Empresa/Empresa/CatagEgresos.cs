using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    class CatagEgresos
    {
        public int idCatalogo_Egresos { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }

        public CatagEgresos() { }

        public CatagEgresos(int pidegreso, string pClave, string pDescripcion) {
            this.idCatalogo_Egresos = pidegreso;
            this.Clave = pClave;
            this.Descripcion = pDescripcion;
        }

    }    
}
