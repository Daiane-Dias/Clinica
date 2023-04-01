namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbCidade")]
    public partial class tbCidade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbCidade()
        {
            tbPaciente = new HashSet<tbPaciente>();
            tbProfissional = new HashSet<tbProfissional>();
        }

        [Key]
        public int IdCidade { get; set; }

        public int? IdEstado { get; set; }

        [StringLength(100)]
        public string nome { get; set; }

        public virtual tbEstado tbEstado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbPaciente> tbPaciente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbProfissional> tbProfissional { get; set; }
    }
}
