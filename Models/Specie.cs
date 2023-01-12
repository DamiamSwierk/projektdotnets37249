using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projekt.Models
{

    [Table("Species")]
    public class Specie
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nazwa Gatunku")]
        public string? Gatuenk { get; set; }


        [Display(Name = "Ryby należace do tego gatunku")]
        public ICollection<Fish>? Ryby { get; set; }




        [Display(Name = "Zbiorniki w który, wsytepuje gatunek")]
        public ICollection<Fishery>? Zbiornik { get; set; }
    }
}
