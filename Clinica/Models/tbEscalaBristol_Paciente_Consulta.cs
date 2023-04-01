namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbEscalaBristol_Paciente_Consulta
    {
        [Key]
        public int IdEscalaBristol_Paciente_Consulta { get; set; }

        public int IdEscalaBristol { get; set; }

        public int IdPaciente { get; set; }

        public int IdHora_Paciente_Profissional { get; set; }

        public virtual tbEscalaBristol tbEscalaBristol { get; set; }

        public virtual tbHoraPaciente_Profissional tbHoraPaciente_Profissional { get; set; }

        public virtual tbPaciente tbPaciente { get; set; }
    }
}
