using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class UrunDetaylari
    {
        [Key]
        public int Id { get; set; }

        public int UrunId { get; set; }

        [DisplayName("Açıklama")]
        public string UrunAciklama { get; set; }

    }
}