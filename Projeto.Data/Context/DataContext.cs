using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; //importando
using System.Data.Entity; //importando
using Projeto.Data.Entities; //importando
using Projeto.Data.Mappings; //importando

namespace Projeto.Data.Context
{
    //REGRA 1) Herdar a classe DbContext do EntityFramework
    public class DataContext : DbContext
    {
        //REGRA 2) Criar um construtor que deverá ler o caminho da string de conexão
        //mapeada no arquivo Web.config.xml e envia-la para a superclasse (DbContext)
        public DataContext() 
            : base(ConfigurationManager.ConnectionStrings["projeto"].ConnectionString)
        {

        }

        //REGRA 3) Sobrescrever (OVERRIDE) o método OnModelCreating de forma que possamos
        //adicionar dentro do método as classes de mapeamento criadas (Map)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //adicionar cada classe de mapeamento..
            modelBuilder.Configurations.Add(new FuncionarioMap());
            modelBuilder.Configurations.Add(new DependenteMap());
        }

        //REGRA 4) Declarar uma propriedade DbSet para cada entidade
        public DbSet<Funcionario> Funcionario { get; set; } //LAMBDA
        public DbSet<Dependente> Dependente { get; set; } //LAMBDA
    }
}
