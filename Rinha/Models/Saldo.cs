using System.ComponentModel.DataAnnotations;

namespace RINHABACKEND.Model
{
    public class Saldo
    {
        public int Id { get; set; }
        public List<Transacao>? UltimasTransacoes { get; set; }
        public int Total { get; set; }
        public DateTime Data_extrato { get; set; }
        public int limite { get; set; }

        public void atualizarSaldo(int novototal)
        {
            Total = novototal;
        }
    }
}
