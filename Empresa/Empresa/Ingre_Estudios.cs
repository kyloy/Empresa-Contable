using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa
{
    class Ingre_Estudios
    {
        public string Fecha { get; set; }  
        public string idDoctor { get; set; }
        public string Nombre_Doctor { get; set; }
        public string Nombre_Estudio { get; set; }
        public string Nombre_Paciente { get; set; }        
        public string idEstudio { get; set; }        
        public int Precio_Pesos { get; set; }
        public int Precio_Dolar { get; set; }   
        public int Adeudo { get; set; }
        public int idIngreso_Estudio { get; set; }
        public string Empresa { get; set; }
              

        //Un constructor para poder crear objetos
        public Ingre_Estudios() { }

        //Con este constructor asiganmos todos los campos a la clase.
        public Ingre_Estudios(int pAdeudo, string pNombre_Doctor, string pNombre_Estudio, string pNombre_Paciente, string pidDoctor, string pidEstudio, string pFecha, int pPrecio_Pesos, int pPrecio_Dolar, string pEmpresa)
        {
            this.Nombre_Paciente = pNombre_Paciente;
            this.Nombre_Doctor = pNombre_Doctor;
            this.Nombre_Estudio = pNombre_Estudio;
            this.idDoctor = pidDoctor;
            this.idEstudio = pidEstudio;
            this.Fecha = pFecha;
            this.Precio_Pesos = pPrecio_Pesos;
            this.Precio_Dolar = pPrecio_Dolar;
            this.Adeudo = pAdeudo;
            this.Empresa = pEmpresa;
        }
    }
}
