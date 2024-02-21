using System.ComponentModel.DataAnnotations.Schema;

namespace RINHABACKEND.Model
{
    public class Transacao
    {
        public int TransacaoID { get; set; }
        public int Valor { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string Realizada_em => DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.ffffffZ");
        public int SaldoId { get; set; }

        public Transacao() { }

       
    }
}