namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbMedico_Paciente
    {
        [Key]
        public int IdMedico_Paciente { get; set; }

        public int IdPaciente { get; set; }

        public int IdProfissional { get; set; }

        [StringLength(5000)]
        public string InformacaoResumida { get; set; }

        public virtual tbPaciente tbPaciente { get; set; }

        public virtual tbProfissional tbProfissional { get; set; }
    }
}
