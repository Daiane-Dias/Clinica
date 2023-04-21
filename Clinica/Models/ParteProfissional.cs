namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class ParteProfissional
    {
       

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(15)]
        public string CPF { get; set; }

        [Required]
        [StringLength(100)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(10)]
        public string CEP { get; set; }

    }
}
