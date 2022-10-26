using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models

{
    public class Filmes
    {
        [Required(ErrorMessage = "O campo titulo é obrigatório!")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor é obrigatório!")]
        public string Diretor { get; set; }
        [StringLength(50, ErrorMessage = "O tamanho máximo do texto é 50 caracteres")]
        public string Genero { get; set; }
        [Range(1,600, ErrorMessage = "A duração deve ter no mínimo 1 e no máximo 600 minutos")]
        public int Duracao { get; set; }
        public int Id { get; set; }
    }
}
