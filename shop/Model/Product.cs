using System.ComponentModel.DataAnnotations;

namespace shop.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Este campo é obrigatório")]
        [MaxLength(60,ErrorMessage="Este campo deve conter no maximo 60 caracteres")]
        [MinLength(3,ErrorMessage="Este campo deve conter no minimo 3 caracteres")]

        public string Title { get; set; }
        
        [MaxLength(1024,ErrorMessage="Este campo deve conter no maximo 1024 caracteres")]
        public string Description  { get; set; }
        
        [Required(ErrorMessage="Este campo é obrigatório")]
        [Range(1, int.MaxValue,ErrorMessage="O preço deve ser maior que zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage="Este campo é obrigatório")]
        [Range(1, int.MaxValue,ErrorMessage="Categoria Invalida")]
        public int CategoryId { get; set; }
        
        public Category category { get; set; }
          
        
    }
}