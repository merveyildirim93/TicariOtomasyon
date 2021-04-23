using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemId { get; set; }

        [DisplayName("Açıklama")]
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Aciklama { get; set; }
        public int Miktar { get; set; }

        [DisplayName("Birim Fiyatı")]
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }
        public Fatura Fatura { get; set; }

        public int FaturaId { get; set; }
    }
}