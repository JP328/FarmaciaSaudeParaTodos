using Farmacia_SaudeParaTodos.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Farmacia_SaudeParaTodos.Model
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "int")]
        public int Estoque { get; set; } = 0;

        [Column(TypeName = "date")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateTime DataFabricacao { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; } = decimal.Zero;

        public virtual Categoria? Categoria { get; set; }
    }
}
