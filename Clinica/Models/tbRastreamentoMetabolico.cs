namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbRastreamentoMetabolico")]
    public partial class tbRastreamentoMetabolico
    {
        [Key]
        public int IdRastreamentoMetabolico { get; set; }

        public int IdRastreamentoResposta { get; set; }

        public int IdHoraPaciente_Profissional { get; set; }

        [StringLength(1000)]
        public string ObsGeral { get; set; }

        public int? Total { get; set; }

        public virtual tbHoraPaciente_Profissional tbHoraPaciente_Profissional { get; set; }

        public virtual tbRastreamentoResposta tbRastreamentoResposta { get; set; }
    }
}
