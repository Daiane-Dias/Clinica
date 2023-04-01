namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbAlimento")]
    public partial class tbAlimento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbAlimento()
        {
            tbReceitaAlimentarPadrao_X_Alimento = new HashSet<tbReceitaAlimentarPadrao_X_Alimento>();
        }

        [Key]
        public int IdAlimento { get; set; }

        public int IdTipoQuantidade { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public double Carboidrato { get; set; }

        public double VitaminaA { get; set; }

        public double VitaminaB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbReceitaAlimentarPadrao_X_Alimento> tbReceitaAlimentarPadrao_X_Alimento { get; set; }
    }
}
