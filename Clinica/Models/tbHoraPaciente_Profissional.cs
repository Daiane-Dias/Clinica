namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbHoraPaciente_Profissional
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbHoraPaciente_Profissional()
        {
            tbAntropometria = new HashSet<tbAntropometria>();
            tbEscalaBristol_Paciente_Consulta = new HashSet<tbEscalaBristol_Paciente_Consulta>();
            tbExameFisico = new HashSet<tbExameFisico>();
            tbRastreamentoMetabolico = new HashSet<tbRastreamentoMetabolico>();
        }

        [Key]
        public int IdHoraPaciente_Profissional { get; set; }

        public int IdPaciente { get; set; }

        public int IdProfissional { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataConsulta { get; set; }

        public TimeSpan HoraInicioIndividual { get; set; }

        public TimeSpan HoraFimIndividual { get; set; }

        public bool PrimeiraConculta { get; set; }

        public bool Compareceu { get; set; }

        [StringLength(5000)]
        public string Motivo { get; set; }

        [StringLength(5000)]
        public string Resumo { get; set; }

        public decimal? Valor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbAntropometria> tbAntropometria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEscalaBristol_Paciente_Consulta> tbEscalaBristol_Paciente_Consulta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbExameFisico> tbExameFisico { get; set; }

        public virtual tbPaciente tbPaciente { get; set; }

        public virtual tbProfissional tbProfissional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbRastreamentoMetabolico> tbRastreamentoMetabolico { get; set; }
    }
}
