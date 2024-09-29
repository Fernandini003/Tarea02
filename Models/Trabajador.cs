using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ExamenT1.Models
{
    public class Trabajador

    {

        //
        [Display(Name = "N° de DNI")]
        public string dniTrab { get; set; }

        [Display(Name = "Apellidos")]
        public string apeTrab { get; set; }

        [Display(Name = "Nombre")]
        public string nomTrab { get; set; }

        [Display(Name = "Fecha de Contrato")]
        public DateTime fecContrato { get; set; }

        [Display(Name = "Categoria ")]
        public string categoriaTrab  { get; set; }
       
        //MÉTODO BASICO
        public int basico()
        { 
            DateTime f_actual = DateTime.Now;
            int anos_trabajando = f_actual.Year - fecContrato.Year;
            if (anos_trabajando <= 3)
            {
                return 1000;
            }
            else if (anos_trabajando > 3 && anos_trabajando <= 5)
            {
                return 1500;
            }
            else if (anos_trabajando > 5 && anos_trabajando <= 10)
            {
                return 2500;
            }
            else 
            {
                return 3500;
            }
        }

        // CLASE PADRE, ESTE MISMO METODO TAL CUAL EL MISMO NOMBRE LO DEBES LLAMAR EN EL HIJO
        // PARA QUE ESTA CLASE SE PUEDA LLAMAR EN EL HIJO LE TIENE QUE AGREGAR LA PALABRA (VIRTUAL)
        public virtual double bonificacion() 
        {
            if (categoriaTrab == "A" || categoriaTrab == "B" || categoriaTrab == "C")
            {
                return basico() * 0.10;
            }
            else
            {
                return basico() * 0.15;
            }

        }

        public  virtual double monto()
        { 
        return  basico() + bonificacion();
        }
    }
}