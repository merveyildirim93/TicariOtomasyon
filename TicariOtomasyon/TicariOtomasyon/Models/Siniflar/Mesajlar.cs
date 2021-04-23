using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajId { get; set; }

        [DisplayName("Gönderici")]
        public string Gonderici { get; set; }

        [DisplayName("Alıcı")]
        public string Alici { get; set; }

        public string Konu { get; set; }

        [DisplayName("İçerik")]
        public string Icerik { get; set; }

        public DateTime Tarih { get; set; }
    }
}