namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbRastreamentoResposta")]
    public partial class tbRastreamentoResposta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbRastreamentoResposta()
        {
            tbRastreamentoMetabolico = new HashSet<tbRastreamentoMetabolico>();
        }

        [Key]
        public int IdRastreamentoResposta { get; set; }

        public int IdPergunta { get; set; }

        public int VlrRespota { get; set; }

        public int IdParteCorpo { get; set; }

        [Required]
        [StringLength(500)]
        public string Obs { get; set; }

        public virtual tbPergunta tbPergunta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbRastreamentoMetabolico> tbRastreamentoMetabolico { get; set; }
    }
}
