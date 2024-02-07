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

        public void CriarConta(Saldo saldo)
        {
            _databasecontext.Add(saldo);
            _databasecontext.SaveChanges();
        }

        public Saldo CriarTransacao(int id, Transacao transacao)
        {
            var saldo = _databasecontext.Saldos.FirstOrDefault(c => c.Id == id);

            int novoTotal = transacao.Tipo == "c"
            ? saldo.Total + (int)(transacao.Valor * 100)
            : saldo.Total - (int)(transacao.Valor * 100);

            saldo.Total = novoTotal;

            _databasecontext.SaveChanges();
            return saldo;
        }

        public void AtualizarSaldo(Saldo saldo)
        {
            _databasecontext.Update(saldo);
            _databasecontext.SaveChanges();
        }
    };
}
