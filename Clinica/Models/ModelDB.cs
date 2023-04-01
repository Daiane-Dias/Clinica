using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Clinica.Models
{
    public partial class ModelDB : DbContext
    {
        public ModelDB()
            : base("name=ModelDB")
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<tbAlimento> tbAlimento { get; set; }
        public virtual DbSet<tbAntropometria> tbAntropometria { get; set; }
        public virtual DbSet<tbCategoriaMedicamento> tbCategoriaMedicamento { get; set; }
        public virtual DbSet<tbCidade> tbCidade { get; set; }
        public virtual DbSet<tbContrato> tbContrato { get; set; }
        public virtual DbSet<tbEscalaBristol> tbEscalaBristol { get; set; }
        public virtual DbSet<tbEscalaBristol_Paciente_Consulta> tbEscalaBristol_Paciente_Consulta { get; set; }
        public virtual DbSet<tbEstado> tbEstado { get; set; }
        public virtual DbSet<tbExame> tbExame { get; set; }
        public virtual DbSet<tbExame_X_Pacientes> tbExame_X_Pacientes { get; set; }
        public virtual DbSet<tbExameFisico> tbExameFisico { get; set; }
        public virtual DbSet<tbGrupoPatologico> tbGrupoPatologico { get; set; }
        public virtual DbSet<tbGrupoPatologico_X_Patologia> tbGrupoPatologico_X_Patologia { get; set; }
        public virtual DbSet<tbGruposReceitasDespesas> tbGruposReceitasDespesas { get; set; }
        public virtual DbSet<tbHistoriaPatologica> tbHistoriaPatologica { get; set; }
        public virtual DbSet<tbHistoricoAlimentarNutricional> tbHistoricoAlimentarNutricional { get; set; }
        public virtual DbSet<tbHistoricoDoencaAtual> tbHistoricoDoencaAtual { get; set; }
        public virtual DbSet<tbHistoricoSocialAlimentar> tbHistoricoSocialAlimentar { get; set; }
        public virtual DbSet<tbHoraPaciente_Profissional> tbHoraPaciente_Profissional { get; set; }
        public virtual DbSet<tbLancarReceitasDespesas> tbLancarReceitasDespesas { get; set; }
        public virtual DbSet<tbMedicamento> tbMedicamento { get; set; }
        public virtual DbSet<tbMedico_Paciente> tbMedico_Paciente { get; set; }
        public virtual DbSet<tbPaciente> tbPaciente { get; set; }
        public virtual DbSet<tbPais> tbPais { get; set; }
        public virtual DbSet<tbPatologia> tbPatologia { get; set; }
        public virtual DbSet<tbPergunta> tbPergunta { get; set; }
        public virtual DbSet<tbPlano> tbPlano { get; set; }
        public virtual DbSet<tbProfissional> tbProfissional { get; set; }
        public virtual DbSet<tbRastreamentoMetabolico> tbRastreamentoMetabolico { get; set; }
        public virtual DbSet<tbRastreamentoResposta> tbRastreamentoResposta { get; set; }
        public virtual DbSet<tbReceitaAlimentarPadrao> tbReceitaAlimentarPadrao { get; set; }
        public virtual DbSet<tbReceitaAlimentarPadrao_X_Alimento> tbReceitaAlimentarPadrao_X_Alimento { get; set; }
        public virtual DbSet<tbReceitaMedicaPadrao> tbReceitaMedicaPadrao { get; set; }
        public virtual DbSet<tbSubstancia> tbSubstancia { get; set; }
        public virtual DbSet<tbSuplemento> tbSuplemento { get; set; }
        public virtual DbSet<tbTipoAcesso> tbTipoAcesso { get; set; }
        public virtual DbSet<tbTipoProfissional> tbTipoProfissional { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<tbAlimento>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbAlimento>()
                .HasMany(e => e.tbReceitaAlimentarPadrao_X_Alimento)
                .WithRequired(e => e.tbAlimento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbCategoriaMedicamento>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbCategoriaMedicamento>()
                .Property(e => e.InformacaoComplementar)
                .IsUnicode(false);

            modelBuilder.Entity<tbCategoriaMedicamento>()
                .HasMany(e => e.tbMedicamento)
                .WithRequired(e => e.tbCategoriaMedicamento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbCidade>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbCidade>()
                .HasMany(e => e.tbProfissional)
                .WithRequired(e => e.tbCidade)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbContrato>()
                .HasMany(e => e.tbProfissional)
                .WithRequired(e => e.tbContrato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbEscalaBristol>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbEscalaBristol>()
                .HasMany(e => e.tbEscalaBristol_Paciente_Consulta)
                .WithRequired(e => e.tbEscalaBristol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbEstado>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbEstado>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<tbExame>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbExame>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<tbExame>()
                .HasMany(e => e.tbExame_X_Pacientes)
                .WithRequired(e => e.tbExame)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbExame_X_Pacientes>()
                .Property(e => e.Resultado)
                .IsUnicode(false);

            modelBuilder.Entity<tbExameFisico>()
                .Property(e => e.TipoAtividadeFisica)
                .IsUnicode(false);

            modelBuilder.Entity<tbExameFisico>()
                .Property(e => e.PA)
                .IsUnicode(false);

            modelBuilder.Entity<tbExameFisico>()
                .Property(e => e.Obs)
                .IsUnicode(false);

            modelBuilder.Entity<tbGrupoPatologico>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbGrupoPatologico>()
                .HasMany(e => e.tbGrupoPatologico_X_Patologia)
                .WithRequired(e => e.tbGrupoPatologico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbGruposReceitasDespesas>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbGruposReceitasDespesas>()
                .HasMany(e => e.tbLancarReceitasDespesas)
                .WithRequired(e => e.tbGruposReceitasDespesas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbHistoriaPatologica>()
                .Property(e => e.Obs)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoAlimentarNutricional>()
                .Property(e => e.DescIntoleranciaAlimentar)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoAlimentarNutricional>()
                .Property(e => e.DescDietas)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoAlimentarNutricional>()
                .Property(e => e.DescMedicamentos)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoAlimentarNutricional>()
                .Property(e => e.DescExercicios)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoAlimentarNutricional>()
                .Property(e => e.DescOutros)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoAlimentarNutricional>()
                .Property(e => e.Obs)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoDoencaAtual>()
                .Property(e => e.Historico)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoDoencaAtual>()
                .Property(e => e.ObsNeoplasia)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoDoencaAtual>()
                .Property(e => e.ObsMetastase)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoDoencaAtual>()
                .Property(e => e.ObsQueimadura)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoDoencaAtual>()
                .Property(e => e.Outros)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoSocialAlimentar>()
                .Property(e => e.Profissao)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoSocialAlimentar>()
                .Property(e => e.RendaFamiliar)
                .HasPrecision(12, 2);

            modelBuilder.Entity<tbHistoricoSocialAlimentar>()
                .Property(e => e.Escolaridade)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoSocialAlimentar>()
                .Property(e => e.EstadoCivil)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoSocialAlimentar>()
                .Property(e => e.NomeCompraAlimento)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoSocialAlimentar>()
                .Property(e => e.NomeCozinhaAlimento)
                .IsUnicode(false);

            modelBuilder.Entity<tbHistoricoSocialAlimentar>()
                .Property(e => e.NomeRealizaRefeicao)
                .IsUnicode(false);

            modelBuilder.Entity<tbHoraPaciente_Profissional>()
                .Property(e => e.HoraInicioIndividual)
                .HasPrecision(0);

            modelBuilder.Entity<tbHoraPaciente_Profissional>()
                .Property(e => e.HoraFimIndividual)
                .HasPrecision(0);

            modelBuilder.Entity<tbHoraPaciente_Profissional>()
                .Property(e => e.Motivo)
                .IsUnicode(false);

            modelBuilder.Entity<tbHoraPaciente_Profissional>()
                .Property(e => e.Resumo)
                .IsUnicode(false);

            modelBuilder.Entity<tbHoraPaciente_Profissional>()
                .Property(e => e.Valor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<tbHoraPaciente_Profissional>()
                .HasMany(e => e.tbAntropometria)
                .WithRequired(e => e.tbHoraPaciente_Profissional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbHoraPaciente_Profissional>()
                .HasMany(e => e.tbEscalaBristol_Paciente_Consulta)
                .WithRequired(e => e.tbHoraPaciente_Profissional)
                .HasForeignKey(e => e.IdHora_Paciente_Profissional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbHoraPaciente_Profissional>()
                .HasMany(e => e.tbRastreamentoMetabolico)
                .WithRequired(e => e.tbHoraPaciente_Profissional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbMedicamento>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbMedicamento>()
                .Property(e => e.Bula)
                .IsUnicode(false);

            modelBuilder.Entity<tbMedico_Paciente>()
                .Property(e => e.InformacaoResumida)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.RG)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.CPF)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.NomeResponsavel)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.Sexo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.Bairro)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.TelResidencial)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.TelComercial)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.TelCelular)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .Property(e => e.Profissao)
                .IsUnicode(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbAntropometria)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbEscalaBristol_Paciente_Consulta)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbExame_X_Pacientes)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbHistoriaPatologica)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbHistoricoAlimentarNutricional)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbHistoricoDoencaAtual)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbHistoricoSocialAlimentar)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbHoraPaciente_Profissional)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPaciente>()
                .HasMany(e => e.tbMedico_Paciente)
                .WithRequired(e => e.tbPaciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPais>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbPais>()
                .Property(e => e.Sigla)
                .IsUnicode(false);

            modelBuilder.Entity<tbPais>()
                .HasMany(e => e.tbEstado)
                .WithRequired(e => e.tbPais)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPatologia>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbPatologia>()
                .Property(e => e.InformacaoComplementar)
                .IsUnicode(false);

            modelBuilder.Entity<tbPatologia>()
                .HasMany(e => e.tbGrupoPatologico_X_Patologia)
                .WithRequired(e => e.tbPatologia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPergunta>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbPergunta>()
                .HasMany(e => e.tbRastreamentoResposta)
                .WithRequired(e => e.tbPergunta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbPlano>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbPlano>()
                .Property(e => e.Valor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<tbPlano>()
                .HasMany(e => e.tbContrato)
                .WithRequired(e => e.tbPlano)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.CPF)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.CRM_CRN)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Especialidade)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Logradouro)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Bairro)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.DDD1)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.DDD2)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Telefone1)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Telefone2)
                .IsUnicode(false);

            modelBuilder.Entity<tbProfissional>()
                .Property(e => e.Salario)
                .HasPrecision(10, 2);

            modelBuilder.Entity<tbProfissional>()
                .HasMany(e => e.tbHoraPaciente_Profissional)
                .WithRequired(e => e.tbProfissional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbProfissional>()
                .HasMany(e => e.tbMedico_Paciente)
                .WithRequired(e => e.tbProfissional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbProfissional>()
                .HasMany(e => e.tbPergunta)
                .WithRequired(e => e.tbProfissional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbProfissional>()
                .HasMany(e => e.tbReceitaMedicaPadrao)
                .WithRequired(e => e.tbProfissional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbRastreamentoMetabolico>()
                .Property(e => e.ObsGeral)
                .IsUnicode(false);

            modelBuilder.Entity<tbRastreamentoResposta>()
                .Property(e => e.Obs)
                .IsUnicode(false);

            modelBuilder.Entity<tbRastreamentoResposta>()
                .HasMany(e => e.tbRastreamentoMetabolico)
                .WithRequired(e => e.tbRastreamentoResposta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbReceitaAlimentarPadrao>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbReceitaAlimentarPadrao>()
                .Property(e => e.InformacaoComplementar)
                .IsUnicode(false);

            modelBuilder.Entity<tbReceitaAlimentarPadrao>()
                .HasMany(e => e.tbReceitaAlimentarPadrao_X_Alimento)
                .WithRequired(e => e.tbReceitaAlimentarPadrao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbReceitaAlimentarPadrao_X_Alimento>()
                .Property(e => e.Periodicidade)
                .IsUnicode(false);

            modelBuilder.Entity<tbReceitaAlimentarPadrao_X_Alimento>()
                .Property(e => e.QuantoTempo)
                .IsUnicode(false);

            modelBuilder.Entity<tbReceitaMedicaPadrao>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbReceitaMedicaPadrao>()
                .Property(e => e.InformacaoComplementar)
                .IsUnicode(false);

            modelBuilder.Entity<tbSubstancia>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbSubstancia>()
                .Property(e => e.InformacaoComplementar)
                .IsUnicode(false);

            modelBuilder.Entity<tbSuplemento>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbTipoAcesso>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<tbTipoProfissional>()
                .Property(e => e.Nome)
                .IsUnicode(false);
        }
    }
}
