namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbPaciente")]
    public partial class tbPaciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbPaciente()
        {
            tbAntropometria = new HashSet<tbAntropometria>();
            tbEscalaBristol_Paciente_Consulta = new HashSet<tbEscalaBristol_Paciente_Consulta>();
            tbExame_X_Pacientes = new HashSet<tbExame_X_Pacientes>();
            tbHistoriaPatologica = new HashSet<tbHistoriaPatologica>();
            tbHistoricoAlimentarNutricional = new HashSet<tbHistoricoAlimentarNutricional>();
            tbHistoricoDoencaAtual = new HashSet<tbHistoricoDoencaAtual>();
            tbHistoricoSocialAlimentar = new HashSet<tbHistoricoSocialAlimentar>();
            tbHoraPaciente_Profissional = new HashSet<tbHoraPaciente_Profissional>();
            tbMedico_Paciente = new HashSet<tbMedico_Paciente>();
        }

        [Key]
        public int IdPaciente { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(15)]
        public string RG { get; set; }

        [Required]
        [StringLength(15)]
        public string CPF { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataNascimento { get; set; }

        [StringLength(100)]
        public string NomeResponsavel { get; set; }

        [Required]
        [StringLength(1)]
        public string Sexo { get; set; }

        public int Etnia { get; set; }

        [StringLength(100)]
        public string Endereco { get; set; }

        [StringLength(50)]
        public string Bairro { get; set; }

        public int? IdCidade { get; set; }

        [StringLength(25)]
        public string TelResidencial { get; set; }

        [StringLength(25)]
        public string TelComercial { get; set; }

        [StringLength(25)]
        public string TelCelular { get; set; }

        [StringLength(30)]
        public string Profissao { get; set; }

        public bool? FlgAtleta { get; set; }

        public bool? FlgGestante { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbAntropometria> tbAntropometria { get; set; }

        public virtual tbCidade tbCidade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEscalaBristol_Paciente_Consulta> tbEscalaBristol_Paciente_Consulta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbExame_X_Pacientes> tbExame_X_Pacientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistoriaPatologica> tbHistoriaPatologica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistoricoAlimentarNutricional> tbHistoricoAlimentarNutricional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistoricoDoencaAtual> tbHistoricoDoencaAtual { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistoricoSocialAlimentar> tbHistoricoSocialAlimentar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHoraPaciente_Profissional> tbHoraPaciente_Profissional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbMedico_Paciente> tbMedico_Paciente { get; set; }
    }
}
