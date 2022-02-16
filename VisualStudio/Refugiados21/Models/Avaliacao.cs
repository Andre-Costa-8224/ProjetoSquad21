using System.ComponentModel.DataAnnotations;

namespace Refugiados1.Models
{
    public class Avaliacao
    {
        [Key]
        public int IdAvaliacao { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]

        public string Tipo { get; set; }

        [Required]

        public string Avaliacoes { get; set; }
    }
}
