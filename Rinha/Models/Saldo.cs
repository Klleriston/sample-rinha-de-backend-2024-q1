using System.ComponentModel.DataAnnotations;

namespace RINHABACKEND.Model
{
    public class Saldo
    {
         public int Id { get; set; }
        public List<Transacao> Transacoes { get; set; }
        public int Total { get; set; }
        public string Data_extrato => DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.ffffffZ");
        public int Limite { get; set; }

        public Saldo()
        {
            Transacoes = new List<Transacao>();
        }

    }
}
