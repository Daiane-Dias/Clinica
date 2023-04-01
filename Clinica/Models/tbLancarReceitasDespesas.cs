namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbLancarReceitasDespesas
    {
        [Key]
        public int IdLancamento { get; set; }

        public int IdReceitaDespesa { get; set; }

        public DateTime Data { get; set; }

        public virtual tbGruposReceitasDespesas tbGruposReceitasDespesas { get; set; }
    }
}
