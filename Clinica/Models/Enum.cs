using System;
using System.Collections.Generic;
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
        public enum TiposProfissionais
        {
            Gerente = 01,
            Medico = 02,
            Nutricionista = 03
        }
    }
}