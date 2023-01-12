

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projekt.Models
{
    [Table("Fish")]
    public class Fish
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Złapania")]
        public DateTime? Data_z { get; set; }

        
        [Range(0, double.MaxValue)]
        [Display(Name = "Waga Ryby")]
        public float? Waga { get; set; }


        [Range(0, 6000)]
        [Display(Name = "Rozmiar")]
        public int? Rozmiar { get; set; }


        [Display(Name = "Gatunek")]
        public int? GatunekId { get; set; }
        [ForeignKey("GatunekId")]
        [Display(Name = "Gatunek")]
        public Specie? Gatunek { get; set; }





        [Display(Name = "Zbiornik")]
        public int? ZbiornikId { get; set; }
        [ForeignKey("ZbiornikId")]
        [Display(Name = "Zbiornik")]
        public Fishery? Zbiornik { get; set; }

    }
}
