using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa
{
    public class Estudios
    {
       public int IdEstudios { get; set; }       
       public string Descripcion { get; set; }
       public int Precio_Pesos { get; set; }
       public int Precio_Dolar { get; set; }
       public int Adeudo { get; set; }
       
       //Un constructor para poder crear objetos
       public Estudios() { }

       //Con este constructor asiganmos todos los campos a la clase.
       public Estudios(int pIdEstudios, string pDescripcion, int pPrecio_Pesos, int pPrecio_Dolar, int pAdeudo)
       {
           this.IdEstudios = pIdEstudios;
           this.Descripcion = pDescripcion;
           this.Precio_Pesos = pPrecio_Pesos;
           this.Precio_Dolar = pPrecio_Dolar;
           this.Adeudo = pAdeudo;
       }
    }
}
