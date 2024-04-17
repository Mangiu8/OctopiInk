namespace OctopInk.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Utenti")]
    public partial class Utenti
    {
        [Key]
        public int IdUtente { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Il campo Nome � obbligatorio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il campo Cognome � obbligatorio.")]
        [StringLength(50)]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Il campo Email � obbligatorio.")]
        [EmailAddress(ErrorMessage = "Inserisci un indirizzo email valido.")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Il campo Password � obbligatorio.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "La password deve essere lunga almeno 6 caratteri.")]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Psw { get; set; }

        public bool IsAdmin { get; set; }
    }
}
