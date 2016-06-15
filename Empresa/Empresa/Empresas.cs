using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa
{
    //Creamos la clase Empresa que contiene los campos de la tabla empresa en la base datos
    public class Empresas
    {
       public int IdEmpresa { get; set; }       
       public string Razon_Social { get; set; }
       public string Giro { get; set; }
       public string Domicilio { get; set; }
       public string Ciudad { get; set; }
       public string Municipio { get; set; }
       public string Estado { get; set; }
       public string RFC { get; set; }
       public string CURP { get; set; }
       public string Reg_imss { get; set; }
       public string Nombre_Gerente { get; set; }
       public string Nombre_Contador { get; set; }
       public string Representante_Legal { get; set; }

       //Un constructor para poder crear objetos
       public Empresas() { }

       //Con este constructor asiganmos todos los campos a la clase.
       public Empresas(int pIdEmpresa, string pRazon_Social, string pGiro, string pDomicilio, string pCiudad,
           string pMunicipio, string pEstado, string pRFC, string pCURP, string pReg_imss, string pNombre_Gerente, string pNombre_Contador,
           string pRepresentante_Legal)
       {
           this.IdEmpresa = pIdEmpresa;           
           this.Razon_Social = pRazon_Social;
           this.Giro = pGiro;
           this.Domicilio = pDomicilio;
           this.Ciudad = pCiudad;
           this.Municipio = pMunicipio;
           this.Estado = pEstado;
           this.RFC = pRFC;
           this.CURP = pCURP;
           this.Reg_imss = pReg_imss;
           this.Nombre_Gerente = pNombre_Gerente;
           this.Nombre_Contador = pNombre_Contador;
           this.Representante_Legal = pRepresentante_Legal;
       }
    }
}
