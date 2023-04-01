namespace Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbProfissional")]
    public partial class tbProfissional
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbProfissional()
        {
            tbHoraPaciente_Profissional = new HashSet<tbHoraPaciente_Profissional>();
            tbMedico_Paciente = new HashSet<tbMedico_Paciente>();
            tbPergunta = new HashSet<tbPergunta>();
            tbReceitaAlimentarPadrao = new HashSet<tbReceitaAlimentarPadrao>();
            tbReceitaMedicaPadrao = new HashSet<tbReceitaMedicaPadrao>();
        }

        [Key]
        public int IdProfissional { get; set; }

        public int? IdTipoProfissional { get; set; }

        public int IdContrato { get; set; }

        public int? IdTipoAcesso { get; set; }

        public int IdCidade { get; set; }

        [Required]
        [StringLength(128)]
        public string IdUser { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(15)]
        public string CPF { get; set; }

        [StringLength(20)]
        public string CRM_CRN { get; set; }

        [StringLength(100)]
        public string Especialidade { get; set; }

        [StringLength(100)]
        public string Logradouro { get; set; }

        [Required]
        [StringLength(10)]
        public string Numero { get; set; }

        [Required]
        [StringLength(100)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(10)]
        public string CEP { get; set; }

        [StringLength(100)]
        public string Cidade { get; set; }

        [StringLength(2)]
        public string Estado { get; set; }

        [StringLength(2)]
        public string DDD1 { get; set; }

        [StringLength(2)]
        public string DDD2 { get; set; }

        [StringLength(25)]
        public string Telefone1 { get; set; }

        [StringLength(25)]
        public string Telefone2 { get; set; }

        public decimal? Salario { get; set; }

        public virtual tbCidade tbCidade { get; set; }

        public virtual tbContrato tbContrato { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHoraPaciente_Profissional> tbHoraPaciente_Profissional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbMedico_Paciente> tbMedico_Paciente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbPergunta> tbPergunta { get; set; }

        public virtual tbTipoAcesso tbTipoAcesso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbReceitaAlimentarPadrao> tbReceitaAlimentarPadrao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbReceitaMedicaPadrao> tbReceitaMedicaPadrao { get; set; }
    }
}
