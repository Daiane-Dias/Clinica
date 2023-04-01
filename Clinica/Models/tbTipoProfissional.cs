namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbTipoProfissional")]
    public partial class tbTipoProfissional
    {
        [Key]
        public int IdTipoProfissional { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }
    }
}
