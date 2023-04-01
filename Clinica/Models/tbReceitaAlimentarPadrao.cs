namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbReceitaAlimentarPadrao")]
    public partial class tbReceitaAlimentarPadrao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbReceitaAlimentarPadrao()
        {
            tbReceitaAlimentarPadrao_X_Alimento = new HashSet<tbReceitaAlimentarPadrao_X_Alimento>();
        }

        [Key]
        public int IdReceitaAlimentarPadrao { get; set; }

        public int? IdProfissional { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(5000)]
        public string InformacaoComplementar { get; set; }

        public virtual tbProfissional tbProfissional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbReceitaAlimentarPadrao_X_Alimento> tbReceitaAlimentarPadrao_X_Alimento { get; set; }
    }
}
