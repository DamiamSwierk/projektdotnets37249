using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projekt.Models
{

    [Table("Districts")]
    public class District
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nazwa Okręgu")]
        public string? nazwa { get; set; }





        [Display(Name = "Zbiorniki które należą do okręgu")]
        public ICollection<Fishery>? Zbiornik { get; set; }
    }
}
