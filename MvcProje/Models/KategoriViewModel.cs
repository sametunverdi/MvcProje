using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProje.Models
{
    public class KategoriViewModel
    {
        public int KATEGORIID { get; set; }
        public string KATEGORIAD { get; set; } // Türkçe Kategori Adı
        public string KATEGORI_EN { get; set; } // İngilizce Kategori Adı
    }
}