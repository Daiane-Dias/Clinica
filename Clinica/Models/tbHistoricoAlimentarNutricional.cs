namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbHistoricoAlimentarNutricional")]
    public partial class tbHistoricoAlimentarNutricional
    {
        [Key]
        public int IdHistAlimentarNutricional { get; set; }

        public int IdPaciente { get; set; }

        public int? MotivacaoTratamento { get; set; }

        public int? ModismosAlimentares { get; set; }

        public bool? FlgIntoleanciaAlimentar { get; set; }

        [StringLength(250)]
        public string DescIntoleranciaAlimentar { get; set; }

        public int? FaseObesidadePerdaPeso { get; set; }

        public bool? FlgPerdaGanhoPeso { get; set; }

        public int? PesoMax { get; set; }

        public int? PesoMaxIdade { get; set; }

        public int? PesoMin { get; set; }

        public int? PesoMinIdade { get; set; }

        public bool? FlgDietas { get; set; }

        [StringLength(250)]
        public string DescDietas { get; set; }

        public bool? FlgMedicamentos { get; set; }

        [StringLength(250)]
        public string DescMedicamentos { get; set; }

        public bool? FlgExercicios { get; set; }

        [StringLength(250)]
        public string DescExercicios { get; set; }

        public bool? FlgOutros { get; set; }

        [StringLength(250)]
        public string DescOutros { get; set; }

        [StringLength(500)]
        public string Obs { get; set; }

        public virtual tbPaciente tbPaciente { get; set; }
    }
}
