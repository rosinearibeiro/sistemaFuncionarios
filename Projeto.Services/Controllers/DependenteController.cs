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
    [RoutePrefix("api/Dependente")]
    public class DependenteController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(DependenteCadastroModel model)
        {
            if (ModelState.IsValid) //verifica se os campos passaram nas validações
            {
                try
                {
                    Dependente dependente = new Dependente();
                    dependente.Nome = model.Nome;
                    dependente.DataNascimento = model.DataNascimento;
                    dependente.IdFuncionario = model.IdFuncionario;

                    DependenteRepository repository = new DependenteRepository();
                    repository.Inserir(dependente);

                    return Request.CreateResponse(HttpStatusCode.OK, "Dependente cadastrado com sucessso.");
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

        [HttpPut]
        public HttpResponseMessage Put(DependenteEdicaoModel model)
        {
            if (ModelState.IsValid) //verifica se os campos passaram nas validações
            {
                try
                {
                    Dependente dependente = new Dependente();
                    dependente.IdDependente = model.IdDependente;
                    dependente.Nome = model.Nome;
                    dependente.DataNascimento = model.DataNascimento;
                    dependente.IdFuncionario = model.IdFuncionario;

                    DependenteRepository repository = new DependenteRepository();
                    repository.Alterar(dependente);

                    return Request.CreateResponse(HttpStatusCode.OK, "Dependente atualizado com sucessso.");
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
                //buscar o dependente pelo id
                DependenteRepository repository = new DependenteRepository();
                Dependente dependente = repository.ObterPorId(id);

                //excluindo o funcionario
                repository.Excluir(dependente);

                return Request.CreateResponse(HttpStatusCode.OK, "Dependente excluído com sucesso.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                List<DependenteConsultaModel> lista = new List<DependenteConsultaModel>();

                //consultando os dependentes no banco de dados
                DependenteRepository repository = new DependenteRepository();
                foreach (var item in repository.ObterTodos())
                {
                    DependenteConsultaModel model = new DependenteConsultaModel();
                    model.IdDependente = item.IdDependente;
                    model.Nome = item.Nome;
                    model.DataNascimento = item.DataNascimento;
                    model.IdFuncionario = item.IdFuncionario;

                    lista.Add(model); //adicionar na lista
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
