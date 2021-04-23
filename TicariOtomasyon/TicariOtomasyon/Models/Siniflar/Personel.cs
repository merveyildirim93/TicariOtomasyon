using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonalId { get; set; }

        [DisplayName("Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonalAdi { get; set; }

        [DisplayName("Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonalSoyadi { get; set; }

        [DisplayName("Profil Fotoğrafı")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ProfilFotografi { get; set; }
        public ICollection<SatisHareketleri> SatisHareketleris { get; set; }
        public int DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }

        [DisplayName("Mail Adresi")]
        public string PersonelMail { get; set; }

        [DisplayName("Şifre")]
        public string PersonelSifre { get; set; }
    }
}