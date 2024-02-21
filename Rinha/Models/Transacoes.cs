using System.ComponentModel.DataAnnotations.Schema;

namespace RINHABACKEND.Model
{
    public class Transacao
    {
        public int transacaoID { get; set; }
        public int Valor { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public DateTime Realizada_em { get; set; }
        [ForeignKey("Saldo")]
        public int SaldoId { get; set; }
        public Saldo Saldo { get; set; }
        public Transacao(int SaldoID, int valor, string tipo, string descricao, DateTime realizada_em)
        {
            Valor = valor;
            Tipo = tipo;
            Descricao = descricao;
            Realizada_em = realizada_em.ToUniversalTime(); ;
        }
    }
}