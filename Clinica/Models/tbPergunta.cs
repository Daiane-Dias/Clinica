namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbPergunta")]
    public partial class tbPergunta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbPergunta()
        {
            tbRastreamentoResposta = new HashSet<tbRastreamentoResposta>();
        }

        [Key]
        public int IdPergunta { get; set; }

        public int IdProfissional { get; set; }

        [Required]
        [StringLength(500)]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public virtual tbProfissional tbProfissional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbRastreamentoResposta> tbRastreamentoResposta { get; set; }
    }
}
