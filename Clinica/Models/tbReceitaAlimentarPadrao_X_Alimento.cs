namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbReceitaAlimentarPadrao_X_Alimento
    {
        [Key]
        public int IdReceitaAlimentarPadrao_X_Alimento_X_QuantidadeAlimento { get; set; }

        public int IdReceitaAlimentarPadrao { get; set; }

        public int IdAlimento { get; set; }

        public int IdQuantidadeAlimento { get; set; }

        [StringLength(100)]
        public string Periodicidade { get; set; }

        [StringLength(100)]
        public string QuantoTempo { get; set; }

        public virtual tbAlimento tbAlimento { get; set; }

        public virtual tbReceitaAlimentarPadrao tbReceitaAlimentarPadrao { get; set; }
    }
}
