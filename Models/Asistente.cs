using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenT1.Models
{
    public class Asistente : Trabajador
    {

        [Display(Name = "N° de  Hijos")]
        public int nro_hijos { get; set; }

        [Display(Name = "Nivel de Edución")]
        public string grado_educacion { get; set; }

        public int sueldo_basico()
        {
            if (grado_educacion == "secundaria")
            {
                return 950;
            }
            else 
            {
                return 1500;
            }
           
        }

        //CUADNO CREO TU METODO EN EL HIJO LE AGREGAS EL OVERRIDE PARA QUE SE ENLACE CON EL PADRE O SEA PARA QUE SE ENTIENDA QUE
        //ES EL MISMO METODO

        public override double bonificacion()
        {
            return 0;
        }

        public double bonif_escolaridad()
        {
            return nro_hijos * 95;
        }

        public double bonif_especial()
        {
            DateTime fecha_actual = DateTime.Now;
            int anos = fecha_actual.Year - fecContrato.Year;

            if (fecha_actual < fecContrato.AddYears(anos))
            {
                anos--;
            }
            if (anos <= 1)
            {
                return basico() * 0.05;
            }
            else
                return basico() * 0.10;
        }

        public override double monto()
        { 
        return sueldo_basico() + bonificacion() + bonif_escolaridad() + bonif_especial();
        }
    }
}