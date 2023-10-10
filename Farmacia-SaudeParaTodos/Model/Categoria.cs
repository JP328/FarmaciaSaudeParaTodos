using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Farmacia_SaudeParaTodos.Model
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Titulo { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(2000)]
        public string Descricao { get; set; } = string.Empty;

        [InverseProperty("Categoria")]
        public virtual ICollection<Produto>? Produto { get; set; }
    }
}
