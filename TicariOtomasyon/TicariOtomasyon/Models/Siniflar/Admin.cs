using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string KullaniciAdi { get; set; }

        [DisplayName("Şifre")]
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Sifre { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Yetki { get; set; }
    }
}