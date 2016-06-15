using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    class ClassEgresos
    {
        public string Fecha { get; set; }        
        public string Clave { get; set; }
        public string Cheque { get; set; }
        public string Concepto { get; set; }
        public int Pesos { get; set; }
        public int Dolar { get; set; }
        public int IdEgresos { get; set; }
        public string Empresa { get; set; }


        //Un constructor para poder crear objetos
        public ClassEgresos() { }

        //Con este constructor asiganmos todos los campos a la clase.
        public ClassEgresos(int pIdEgresos, string pClave, string pCheque, string pConcepto, int pPesos, int pDolar, string pFecha, string pEmpresa)
        {
            this.IdEgresos = pIdEgresos;
            this.Clave = pClave;
            this.Cheque = pCheque;
            this.Concepto = pConcepto;
            this.Pesos = pPesos;
            this.Dolar = pDolar;
            this.Fecha = pFecha;
            this.Empresa = pEmpresa;
        }
    }
}
