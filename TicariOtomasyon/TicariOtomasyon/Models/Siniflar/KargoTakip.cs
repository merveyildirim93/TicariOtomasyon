using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class KargoTakip
    {
        public int KargoTakipId { get; set; }

        [DisplayName("Kargo Takip Kodu")]
        public string TakipKodu { get; set; }

        [DisplayName("Açıklama")]
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}