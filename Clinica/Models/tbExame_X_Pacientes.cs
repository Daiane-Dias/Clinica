namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbExame_X_Pacientes
    {
        [Key]
        public int IdExame_X_Paciente { get; set; }

        public int IdExame { get; set; }

        public int IdPaciente { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Data { get; set; }

        [StringLength(1000)]
        public string Resultado { get; set; }

        public virtual tbExame tbExame { get; set; }

        public virtual tbPaciente tbPaciente { get; set; }
    }
}
