﻿using Repository.DTO;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IOpcaoRepository
    {
        Task<bool> InserirOpcao(OpcaoDTO opcao);
        Task<bool> DeletarOpcao(int idOpcao);
        Task<bool> AlterarOpcao(OpcaoDTO opcao);
        Task<IEnumerable<Opcao>> BuscarOpcoes(int pagina, int quantidade);
    }
}
