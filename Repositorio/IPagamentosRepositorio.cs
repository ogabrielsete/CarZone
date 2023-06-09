﻿using CarZone.Models;

namespace CarZone.Repositorio
{
    public interface IPagamentosRepositorio
    {
        List<Pagamento> GetAll();
        Pagamento ListarPorId(int id);
        Pagamento Adicionar(Pagamento pgto);
        Pagamento Atualizar(Pagamento pgto);
        bool Apagar(int id);
    }
}
