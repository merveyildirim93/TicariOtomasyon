using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Cari
    {
        [Key]
        public int CariId { get; set; }

        [DisplayName("Cari Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz.")]
        public string CariAdi { get; set; }

        [DisplayName("Cari Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz.")]
        public string CariSoyadi { get; set; }

        [DisplayName("Şehir")]
        [Column(TypeName = "Varchar")]
        [StringLength(13, ErrorMessage = "En fazla 13 karakter girebilirsiniz.")]
        public string CariSehir { get; set; }

        [DisplayName("Mail Adresi")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz.")]
        public string CariMail { get; set; }

        [DisplayName("Şifre")]
        public string CariSifre { get; set; }
        public bool Durum { get; set; }
        public ICollection<SatisHareketleri> SatisHareketleris { get; set; }

    }
}