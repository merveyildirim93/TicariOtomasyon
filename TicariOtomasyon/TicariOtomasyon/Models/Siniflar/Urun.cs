using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        [DisplayName("Ürün Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string UrunAdi { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public bool Durum { get; set; }

        [DisplayName("Ürün Fotoğrafı")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunFotografi { get; set; }

        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareketleri> SatisHareketleris { get; set; }
    }
}