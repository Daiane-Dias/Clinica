namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbHistoriaPatologica")]
    public partial class tbHistoriaPatologica
    {
        [Key]
        public int IdHistoriaPatologica { get; set; }

        public int IdPaciente { get; set; }

        public int? IdPatologia { get; set; }

        public bool? FlgHAS { get; set; }

        public bool? FlgAVC { get; set; }

        public bool? FlgDoencasPulmonares { get; set; }

        public bool? FlgDoencasCardiacas { get; set; }

        public bool? FlgDoencaRenal { get; set; }

        public bool? FlgDoencaHepatica { get; set; }

        public bool? FlgNeoplasia { get; set; }

        public bool? FlgHipercolesterolemia { get; set; }

        public bool? FlgHipertrigliciridemia { get; set; }

        public bool? FlgHiperuricemia { get; set; }

        public bool? FlgAnemias { get; set; }

        public bool? FlgCirurgias { get; set; }

        public bool? FlgDoencasAutoImunes { get; set; }

        public bool? FlgDiabetes { get; set; }

        [StringLength(500)]
        public string Obs { get; set; }

        public virtual tbPaciente tbPaciente { get; set; }

        public virtual tbPatologia tbPatologia { get; set; }
    }
}
