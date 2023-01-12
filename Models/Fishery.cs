using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projekt.Models
{
    [Table("Fisheries")]
    public class Fishery
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nazwa Łowiska")]
        public string? nazwa { get; set; }



        [Display(Name = "Ryby złowione w tym zbiorniku")] 
        public ICollection<Fish>? Ryby { get; set; }

        [Display(Name = "Okręg")]
        public int? OkregId { get; set; }
        [ForeignKey("OkregId")]
        [Display(Name = "Okreg")]
        public District? Okreg { get; set; }


        [Display(Name = "Gatunki występujące w tym zbiorniku")]
        public ICollection<Specie>? Gatunek { get; set; }
    }
}
