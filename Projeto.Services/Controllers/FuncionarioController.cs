using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Data.Entities; //importando
using Projeto.Data.Repositories; //importando
using Projeto.Services.Models; //importando

namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/Funcionario")]
    public class FuncionarioController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(FuncionarioCadastroModel model)
        {
            if(ModelState.IsValid) //verifica se os campos passaram nas validações
            {
                try
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.Nome = model.Nome;
                    funcionario.Salario = model.Salario;
                    funcionario.DataAdmissao = model.DataAdmissao;

                    FuncionarioRepository repository = new FuncionarioRepository();
                    repository.Inserir(funcionario);

                    return Request.CreateResponse(HttpStatusCode.OK, "Funcionário cadastrado com sucessso.");
                }
                catch(Exception e)
                {
                    //INTERNAL SERVER ERROR -> Status HTTP 500
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                //BAD REQUEST -> Status HTTP 400 
                return Request.CreateResponse(HttpStatusCode.BadRequest, 
                    "Ocorreram erros de validação.");
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(FuncionarioEdicaoModel model)
        {
            if (ModelState.IsValid) //verifica se os campos passaram nas validações
            {
                try
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.IdFuncionario = model.IdFuncionario;
                    funcionario.Nome = model.Nome;
                    funcionario.Salario = model.Salario;
                    funcionario.DataAdmissao = model.DataAdmissao;

                    FuncionarioRepository repository = new FuncionarioRepository();
                    repository.Alterar(funcionario);

                    return Request.CreateResponse(HttpStatusCode.OK, "Funcionário atualizado com sucessso.");
                }
                catch (Exception e)
                {
                    //INTERNAL SERVER ERROR -> Status HTTP 500
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                //BAD REQUEST -> Status HTTP 400 
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    "Ocorreram erros de validação.");
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                //buscar o funcionario pelo id
                FuncionarioRepository repository = new FuncionarioRepository();
                Funcionario funcionario = repository.ObterPorId(id);

                //excluindo o funcionario
                repository.Excluir(funcionario);

                return Request.CreateResponse(HttpStatusCode.OK, "Funcionário excluído com sucesso.");
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                List<FuncionarioConsultaModel> lista = new List<FuncionarioConsultaModel>();

                //consultando os funcionários no banco de dados
                FuncionarioRepository repository = new FuncionarioRepository();
                foreach (var item in repository.ObterTodos())
                {
                    FuncionarioConsultaModel model = new FuncionarioConsultaModel();
                    model.IdFuncionario = item.IdFuncionario;
                    model.Nome = item.Nome;
                    model.Salario = item.Salario;
                    model.DataAdmissao = item.DataAdmissao;

                    lista.Add(model); //adicionar na lista
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
