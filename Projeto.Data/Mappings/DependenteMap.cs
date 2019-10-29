using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.Data.Mappings
{
    public class DependenteMap : EntityTypeConfiguration<Dependente>
    {
        //construtor ctor + 2x[tab]
        public DependenteMap()
        {
            ToTable("Dependente");

            HasKey(d => d.IdDependente);

            Property(d => d.IdDependente)
                .HasColumnName("IdDependente")
                .IsRequired();

            Property(d => d.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            Property(d => d.DataNascimento)
                .HasColumnName("DataNascimento")
                .IsRequired();

            Property(d => d.IdFuncionario)
                .HasColumnName("IdFuncionario")
                .IsRequired();

            //Criando um relacionamento de Dependente com Funcionario
            HasRequired(d => d.Funcionario) //Dependente TEM 1 Funcionario
                .WithMany(f => f.Dependentes) //Funcionario TEM MUITOS Dependentes
                .HasForeignKey(d => d.IdFuncionario); //Chave estrangeira
        }
    }
}
