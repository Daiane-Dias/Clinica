namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbPatologia")]
    public partial class tbPatologia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbPatologia()
        {
            tbGrupoPatologico_X_Patologia = new HashSet<tbGrupoPatologico_X_Patologia>();
            tbHistoriaPatologica = new HashSet<tbHistoriaPatologica>();
            tbHistoricoDoencaAtual = new HashSet<tbHistoricoDoencaAtual>();
        }

        [Key]
        public int IdPatologia { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(5000)]
        public string InformacaoComplementar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbGrupoPatologico_X_Patologia> tbGrupoPatologico_X_Patologia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistoriaPatologica> tbHistoriaPatologica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistoricoDoencaAtual> tbHistoricoDoencaAtual { get; set; }
    }
}
