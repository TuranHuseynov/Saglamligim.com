using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AzmanAzWebPage.Models;

namespace AzmanAzWebPage.Viewmodel
{

  

    public class MyModel
    {
        
        public List<Adresim> _adresim { get; set; }
        public List<Elaqe> _elaqe { get; set; }
        public List<Endirim> _endirim { get; set; }
        public List<Galereya> _galereya { get; set; }
        public List<Karusel> _karusel { get; set; }
        public List<Kategoriya> _kategoriya { get; set; }
        [AllowHtml]
        public List<Mallar> _mallar { get; set; }
        [AllowHtml]
        public List<Servi> _servis { get; set; }
        public List<Slayder> _slayder { get; set; }
        public List<Zakazim> _zakazim { get; set; }
        public List<Kampanya> _kampanyalar { get; set; }

    }
}