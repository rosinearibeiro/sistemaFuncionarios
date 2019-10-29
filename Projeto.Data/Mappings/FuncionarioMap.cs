using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Data.Entities; //classes de entidade
using System.Data.Entity.ModelConfiguration; //mapeamento ORM

namespace Projeto.Data.Mappings
{
    //Classe de mapeamento para a entidade -> Funcionario
    public class FuncionarioMap : EntityTypeConfiguration<Funcionario>
    {
        //método construtor -> ctor + 2x[tab]
        public FuncionarioMap()
        {
            //nome da tabela
            ToTable("Funcionario");

            //chave primária
            HasKey(f => f.IdFuncionario);

            //mapear os demais campos da tabela Funcionario..
            Property(f => f.IdFuncionario)
                .HasColumnName("IdFuncionario") //nome do campo na tabela
                .IsRequired(); //not null

            Property(f => f.Nome)
               .HasColumnName("Nome") //nome do campo na tabela
               .HasMaxLength(150) //tamanho do campo texto
               .IsRequired(); //not null

            Property(f => f.Salario)
               .HasColumnName("Salario") //nome do campo na tabela
               .HasPrecision(18,2) //tamanho do campo decimal
               .IsRequired(); //not null

            Property(f => f.DataAdmissao)
               .HasColumnName("DataAdmissao") //nome do campo na tabela
               .IsRequired(); //not null
        }
    }
}
