namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbHistoricoDoencaAtual")]
    public partial class tbHistoricoDoencaAtual
    {
        [Key]
        public int IdHDA { get; set; }

        public int IdPaciente { get; set; }

        public int? IdPatologia { get; set; }

        [StringLength(1000)]
        public string Historico { get; set; }

        public int? Cirurgia { get; set; }

        public int? Trauma { get; set; }

        public int? Infeccao { get; set; }

        public int? Neoplasia { get; set; }

        public int? Metastase { get; set; }

        public int? Queimadura { get; set; }

        [StringLength(250)]
        public string ObsNeoplasia { get; set; }

        [StringLength(250)]
        public string ObsMetastase { get; set; }

        [StringLength(250)]
        public string ObsQueimadura { get; set; }

        [StringLength(250)]
        public string Outros { get; set; }

        public virtual tbPaciente tbPaciente { get; set; }

        public virtual tbPatologia tbPatologia { get; set; }
    }
}
