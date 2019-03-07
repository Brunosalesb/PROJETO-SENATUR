using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class PacotesRepository : IPacotesRepository
    {
        public void atualizarPacote(Pacotes pacote) => throw new NotImplementedException();

        public void CadastrarPacote(Pacotes pacote) => throw new NotImplementedException();

        public List<Pacotes> ListarPacotes() => throw new NotImplementedException();
    }
}
