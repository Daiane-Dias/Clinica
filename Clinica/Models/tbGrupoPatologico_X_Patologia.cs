namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbGrupoPatologico_X_Patologia
    {
        [Key]
        public int IdPatologia_X_GrupoPatologico { get; set; }

        public int IdGrupoPatologico { get; set; }

        public int IdPatologia { get; set; }

        public virtual tbGrupoPatologico tbGrupoPatologico { get; set; }

        public virtual tbPatologia tbPatologia { get; set; }
    }
}
