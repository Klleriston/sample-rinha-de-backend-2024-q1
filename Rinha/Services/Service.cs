using Microsoft.AspNetCore.Mvc;
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
            var conta = _databasecontext.Saldos.FirstOrDefault(c => c.Id == id);
            return conta!;
        }


        public Saldo CriarTransacao(int id, Transacao transacao)
        {
            var saldo = _databasecontext.Saldos.FirstOrDefault(c => c.Id == id);

            if (transacao.Tipo == "c")
            {
                int novoTotal = saldo.limite - transacao.Valor;
                saldo.limite = novoTotal;

                _databasecontext.SaveChanges();
                return saldo;
            } else if (transacao.Tipo == "d")
            {
                int novoTotal = saldo.Total -= transacao.Valor;
                saldo.Total = novoTotal;

                _databasecontext.SaveChanges();
                return saldo;
            } else
            {
                throw new NotImplementedException();
            }
        }

    };
}
