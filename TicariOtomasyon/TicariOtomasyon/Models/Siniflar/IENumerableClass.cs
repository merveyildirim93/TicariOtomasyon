using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class IENumerableClass
    {
        public IEnumerable<Urun> urun { get; set; }

        public IEnumerable<UrunDetaylari> urunDetaylari { get; set; }
    }
}