namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbSuplemento")]
    public partial class tbSuplemento
    {
        [Key]
        public int IdSuplemento { get; set; }

        public int IdTipoQuantidade { get; set; }

        public int Tipo { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        public double DoseMinima { get; set; }

        public double DoseMaxima { get; set; }

        public double Carboidrato { get; set; }

        public double VitaminaA { get; set; }

        public double VitaminaB { get; set; }
    }
}
