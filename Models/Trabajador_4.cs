using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenT1.Models
{
    public class Trabajador_4
    {
        public string idTrabajador { get; set; }
        public string apeTrabajador { get; set; }
        public string nomTrabajador { get; set; }
        public string cargoTrabajador { get; set; }
        public Boolean discapacidad { get; set; }
        public DateTime fecContrato { get; set; }

        //método sueldo básico
        public int sueldoBasico()
        {
            switch (cargoTrabajador)
            {
                case "administrativo":
                    return 1000;

                case "ejecutivo":
                    return 3500;

                default:
                    return 6000;
            }

        }

        //método bonificación 
        public decimal bonificacion(bool tieneDiscapacidad, decimal sueldoBasico)
        {
            if (tieneDiscapacidad)
            {
                return sueldoBasico * 0.15m;
            }
            else
            {
                return 0;
            }
        }

        // método monto()
       






    }
}