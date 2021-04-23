using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Kargo
    {
        public int KargoId { get; set; }

        [DisplayName("Kargo Takip Kodu")]
        public string TakipKodu { get; set; }

        [DisplayName("Açıklama")]
        public string Aciklama { get; set; }
        public string Personel { get; set; }

        [DisplayName("Alıcı")]
        public string Alici { get; set; }
        public DateTime Tarih { get; set; }
    }
}