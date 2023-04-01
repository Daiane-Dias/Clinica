namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbExame")]
    public partial class tbExame
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbExame()
        {
            tbExame_X_Pacientes = new HashSet<tbExame_X_Pacientes>();
        }

        [Key]
        public int IdExame { get; set; }

        public int Grupo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(250)]
        public string Descricao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbExame_X_Pacientes> tbExame_X_Pacientes { get; set; }
    }
}
