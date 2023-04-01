namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbGrupoPatologico")]
    public partial class tbGrupoPatologico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbGrupoPatologico()
        {
            tbGrupoPatologico_X_Patologia = new HashSet<tbGrupoPatologico_X_Patologia>();
        }

        [Key]
        public int IdGrupoPatologico { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbGrupoPatologico_X_Patologia> tbGrupoPatologico_X_Patologia { get; set; }
    }
}
