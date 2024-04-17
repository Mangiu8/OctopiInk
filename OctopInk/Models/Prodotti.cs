namespace OctopInk.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Prodotti")]
    public partial class Prodotti
    {
        [Key]
        public int IdProdotto { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string Foto2 { get; set; }
        public string Foto3 { get; set; }
        public string Foto4 { get; set; }

        [NotMapped]
        public int? Quantita { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Prezzo { get; set; }
    }
}
