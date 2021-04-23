using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Fatura
    {
        [Key]
        public int FaturaId { get; set; }

        [DisplayName("Fatura Seri No")]
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }

        [DisplayName("Fatura Sıra No")]
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FaturaSiraNo { get; set; }

        [DisplayName("Fatura Tarihi")]
        public DateTime FaturaTarihi { get; set; }

        [DisplayName("Fatura Saati")]
        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string FaturaSaati { get; set; }

        [DisplayName("Vergi Dairesi")]
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }

        [DisplayName("Teslim Eden")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }

        [DisplayName("Teslim Alan")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }

        public decimal Tutar { get; set; }
        public ICollection<FaturaKalem> FaturaKalems{ get; set; }
    }
}