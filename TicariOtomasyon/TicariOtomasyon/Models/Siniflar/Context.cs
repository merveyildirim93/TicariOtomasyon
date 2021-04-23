﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Context: DbContext
    {
        [Key]
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cari> Caris { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<SatisHareketleri> SatisHareketleris { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<UrunDetaylari> UrunDetaylaris { get; set; }
        public DbSet<Yapilacaklar> Yapilacaklars { get; set; }
        public DbSet<Kargo> Kargoes { get; set; }
        public DbSet<KargoTakip> KargoTakips { get; set; }
        public DbSet<Mesajlar> Mesajlars { get; set; }
    }
}