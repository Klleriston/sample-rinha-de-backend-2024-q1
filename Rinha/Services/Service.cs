using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RINHABACKEND.Data;
using RINHABACKEND.Model;

namespace RINHABACKEND.Services
{
    public class Service
    {
        private readonly Databasecontext _databasecontext;
        public Service(Databasecontext databasecontext)
        {
            _databasecontext = databasecontext;
        }

        public Saldo GetSaldo(int id)
        {
            var conta = _databasecontext.Saldos.Include(s => s.Transacoes).FirstOrDefault(c => c.Id == id);
            return conta!;
        }

 
        public Saldo CriarTransacao(int id, Transacao transacao)
        {
            var saldo = _databasecontext.Saldos.FirstOrDefault(c => c.Id == id);

            if (transacao.Tipo == "c")
            {
              
                int novoTotal = saldo.Limite - transacao.Valor;
                saldo.Limite = novoTotal;
                saldo.Transacoes.Add(transacao);

                _databasecontext.SaveChanges();
                return saldo;
            } else if (transacao.Tipo == "d")
            {
                int novoTotal = saldo.Total -= transacao.Valor;
                saldo.Total = novoTotal;
                saldo.Transacoes.Add(transacao);

                _databasecontext.SaveChanges();
                return saldo;
            } else
            {
                throw new NotImplementedException();
            }
        }

    };
}
