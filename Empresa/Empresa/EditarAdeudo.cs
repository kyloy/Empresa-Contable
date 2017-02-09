using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    class EditarAdeudo
    {
        public string Fecha { get; set; }  
        public string Nombre_Doctor { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string idDoctor { get; set; }
        public string Celular { get; set; }
        public string Colonia { get; set; }
        public string Zona { get; set; }
        public string Nombre_Paciente { get; set; }
        public string Descripcion { get; set; }
        public int Adeudo { get; set; }
        public string Empresa { get; set; }
        
        //Un constructor para poder crear objetos
        public EditarAdeudo() { }

        //Con este constructor asiganmos todos los campos a la clase.
        public EditarAdeudo(string pFecha, string pNombre_Doctor, string pDireccion, string pTelefono, string pIdDoctor, string pCelular, string pColonia, string pZona, string pNombre_Paciente, string pDescripcion, int pAdeudo, string pEmpresa)
        {
            this.Fecha = pFecha;
            this.Nombre_Doctor = pNombre_Doctor;
            this.Direccion = pDireccion;
            this.Telefono = pTelefono;
            this.idDoctor = pIdDoctor;
            this.Celular = pCelular;
            this.Colonia = pColonia;
            this.Zona = pZona;
            this.Nombre_Paciente = pNombre_Paciente;
            this.Descripcion = pDescripcion;
            this.Adeudo = pAdeudo;
            this.Empresa = pEmpresa;
        }
    }
}
