namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbMedicamento")]
    public partial class tbMedicamento
    {
        [Key]
        public int IdMedicamento { get; set; }

        public int IdCategoriaMedicamento { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public string Bula { get; set; }

        public byte[] BulaArquivo { get; set; }

        public virtual tbCategoriaMedicamento tbCategoriaMedicamento { get; set; }
    }
}
