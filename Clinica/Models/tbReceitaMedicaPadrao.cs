namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbReceitaMedicaPadrao")]
    public partial class tbReceitaMedicaPadrao
    {
        [Key]
        public int IdReceitaMedicaPadrao { get; set; }

        public int IdProfissional { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(5000)]
        public string InformacaoComplementar { get; set; }

        public virtual tbProfissional tbProfissional { get; set; }
    }
}
