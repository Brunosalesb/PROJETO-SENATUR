﻿using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IPacotesRepository
    {
        List<Pacotes> ListarPacotes();

        void CadastrarPacote(Pacotes pacote);

        void atualizarPacote(Pacotes pacote);
    }
}
