using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa
{
   public class Doctores
    {
       public string IdDoctor { get; set; }
       public string NombreComplet { get; set; }
       public string Nombre { get; set; }
       public string Apellido_Paterno { get; set; }
       public string Apellido_Materno { get; set; }
       public string Telefono { get; set; }
       public string Celular { get; set; }
       public string Direccion { get; set; }
       public string Colonia { get; set; }
       public string Ciudad { get; set; }
       public string Estado { get; set; }
       public string Pais { get; set; }
       public string Zona { get; set; } 
       public string Aseguranza { get; set; }
       

       //Un constructor para poder crear objetos
       public Doctores() { }

       //Con este constructor asiganmos todos los campos a la clase.
       public Doctores(string pIdDoctor,string pNombre, string pApellido_Paterno, string pApellido_Materno, string pDireccion, string pColonia,
           string pCiudad, string pEstado, string pPais, string pZona, string pTelefono, string pCelular, string pAseguranza, string NombreC)
       {
           this.IdDoctor = pIdDoctor;
           this.Nombre = pNombre;
           this.Apellido_Paterno = pApellido_Paterno;
           this.Apellido_Materno = pApellido_Materno;
           this.Direccion = pDireccion;
           this.Colonia = pColonia;
           this.Ciudad = pCiudad;
           this.Estado = pEstado;
           this.Pais = pPais;
           this.Zona = pZona;
           this.Telefono = pTelefono;
           this.Celular = pCelular;
           this.Aseguranza = pAseguranza;
           this.NombreComplet = NombreC;
       }
    }
    
}
