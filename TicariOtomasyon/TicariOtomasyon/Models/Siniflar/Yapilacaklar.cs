using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Yapilacaklar
    {
        public int Id { get; set; }

        [DisplayName("Başlık")]
        public string Baslik { get; set; }

        public bool Durum { get; set; }
    }
}