﻿using CarZone.Data;
using CarZone.Models;
using CarZone.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarZone.Repositorio
{
    public class VendasRepositorio : IVendasRepositorio
    {
        private readonly BancoContext _bancoContext;
        public VendasRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<Venda> ObterTodos()
        {
            return _bancoContext.VendasDB.ToList();
        }

        public Venda ObterPorId(int id)
        {
            return _bancoContext.VendasDB.FirstOrDefault(x => x.Id == id);
        }

        public Venda Adicionar(Venda vendidos)
        {
            _bancoContext.VendasDB.Add(vendidos);
            _bancoContext.SaveChanges();
            return vendidos;
        }

        public Venda Atualizar(Venda vendidos)
        {
            Venda sellDB = ObterPorId(vendidos.Id);
            if (sellDB == null) throw new Exception("Houve erro na atualização da venda");

            sellDB.PagamentoId = vendidos.PagamentoId;
            sellDB.Meses = vendidos.Meses;
            sellDB.ModeloId = vendidos.ModeloId;
            sellDB.ClienteId = vendidos.ClienteId;

            _bancoContext.VendasDB.Update(sellDB);
            _bancoContext.SaveChanges();

            return sellDB;

        }

        public bool Apagar(int id)
        {
            Venda vendas = ObterPorId(id);
            if (vendas == null) throw new Exception("Houve erro na exclusão da Marca");

            _bancoContext.VendasDB.Remove(vendas);
            _bancoContext.SaveChanges();
            return true;
        }

        public bool VendaRelacionada(int vendaId)
        {

            return _bancoContext.VendasDB.Any(v => v.ClienteId == vendaId);
          
        }
    }
}
