using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    class ClassOtrosEgre
    {        
        public string Fecha { get; set; }        
        public string Clave { get; set; }        
        public string Concepto { get; set; }
        public int Pesos { get; set; }
        public int Dolar { get; set; }
        public int idOtros { get; set; }
        public string Empresa { get; set; }


        //Un constructor para poder crear objetos
        public ClassOtrosEgre() { }

        //Con este constructor asiganmos todos los campos a la clase.
        public ClassOtrosEgre(int pidOtros, string pClave, string pConcepto, int pPesos, int pDolar, string pFecha, string pEmpresa)
        {
            this.idOtros = pidOtros;
            this.Clave = pClave;            
            this.Concepto = pConcepto;
            this.Pesos = pPesos;
            this.Dolar = pDolar;
            this.Fecha = pFecha;
            this.Empresa = pEmpresa;
        }
    }
}
