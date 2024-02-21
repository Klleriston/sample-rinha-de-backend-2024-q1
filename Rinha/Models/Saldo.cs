using System.ComponentModel.DataAnnotations;

namespace RINHABACKEND.Model
{
    public class Saldo
    {
        public int Id { get; set; }
        [Required]
      
        public Transacao Transacao { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        public DateTime Data_extrato { get; set; }
        [Required]
        public int limite { get; set; }

    }
}
