using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class Enum
    {
        public enum Plan
        {
            MedicoTotal = 1,
            MedicoParcial = 2,
            Nutricional = 3,
            Especial = 4
        }
      
    }
}