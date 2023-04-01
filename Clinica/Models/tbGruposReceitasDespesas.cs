namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbGruposReceitasDespesas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbGruposReceitasDespesas()
        {
            tbLancarReceitasDespesas = new HashSet<tbLancarReceitasDespesas>();
        }

        [Key]
        public int IdReceitaDespesa { get; set; }

        public int Tipo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbLancarReceitasDespesas> tbLancarReceitasDespesas { get; set; }
    }
}
