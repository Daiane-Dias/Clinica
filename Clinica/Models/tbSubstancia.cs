namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbSubstancia")]
    public partial class tbSubstancia
    {
        [Key]
        public int IdSubstancia { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(5000)]
        public string InformacaoComplementar { get; set; }
    }
}
