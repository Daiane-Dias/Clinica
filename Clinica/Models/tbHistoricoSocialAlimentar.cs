namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbHistoricoSocialAlimentar")]
    public partial class tbHistoricoSocialAlimentar
    {
        [Key]
        public int IdHistSocialAlimentar { get; set; }

        public int IdPaciente { get; set; }

        [StringLength(100)]
        public string Profissao { get; set; }

        public int? CargaHoraria { get; set; }

        public int? NroPessoasRes { get; set; }

        public decimal? RendaFamiliar { get; set; }

        [StringLength(50)]
        public string Escolaridade { get; set; }

        [StringLength(30)]
        public string EstadoCivil { get; set; }

        [StringLength(100)]
        public string NomeCompraAlimento { get; set; }

        [StringLength(100)]
        public string NomeCozinhaAlimento { get; set; }

        public int? CompraFeita { get; set; }

        [StringLength(100)]
        public string NomeRealizaRefeicao { get; set; }

        public bool? FlgTabagismo { get; set; }

        public int? QtdTabagismoDia { get; set; }

        public bool? FlgEtilismo { get; set; }

        public int? QtdEtilismoDia { get; set; }

        public bool? FlgCafe { get; set; }

        public int? QtdCafeDia { get; set; }

        public bool? FlgPaiMaeHas { get; set; }

        public bool? FlgAvosHas { get; set; }

        public bool? FlgIrmaosHas { get; set; }

        public bool? FlgPaiMaeDiabetes { get; set; }

        public bool? FlgAvosDiabetes { get; set; }

        public bool? FlgIrmaosDiabetes { get; set; }

        public bool? FlgPaiMaeCancer { get; set; }

        public bool? FlgAvosCancer { get; set; }

        public bool? FlgIrmaosCancer { get; set; }

        public bool? FlgPaiMaeObesidade { get; set; }

        public bool? FlgAvosObesidade { get; set; }

        public bool? FlgIrmaosObesidade { get; set; }

        public virtual tbPaciente tbPaciente { get; set; }
    }
}
