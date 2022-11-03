using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace Doviz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DovizController : ControllerBase
    {
       
        [HttpPost]
        public ResponseData Run(RequestData request)
        {
            ResponseData result = new ResponseData();
            try
            {


                string mblink = /*string.Format(*/"https://www.tcmb.gov.tr/kurlar/today.xml";//, (request.IsBugun) ? "today" : string.Format("{2}{1}/{0}{1}{2}",
                                                                                             // request.gun.ToString().PadLeft(2, '0'), request.ay.ToString().PadLeft(2, '0'), request.yil)

                //  ); 
                result.Data = new List<ResponseDataKur>();
                var doc = new XmlDocument();

                doc.Load(mblink);
                DateTime tarih = Convert.ToDateTime(doc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
                //  string USD = doc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;

                if (doc.SelectNodes("Tarih_Date").Count < 1)
                {
                    result.Hata = "Kur bilgisi bulunamadı";
                    return result;
                }

                foreach (XmlNode node in doc.SelectNodes("Tarih_Date")[0].ChildNodes)
                {
                    ResponseDataKur kur = new ResponseDataKur();
                    kur.kodu = node.Attributes["Kod"].Value;
                    kur.birimi = int.Parse(node["Unit"].InnerText);
                    kur.adi = node["Isim"].InnerText;
                    kur.alisKuru = Convert.ToDecimal(node["ForexBuying"].InnerText.Replace(".", ","));
                    kur.satisKuru = Convert.ToDecimal(node["ForexSelling"].InnerText.Replace(".", ","));
                    kur.efektifAlisKuru = Convert.ToDecimal(node["BanknoteBuying"].InnerText.Replace(".", ","));
                    kur.efektifSatisKuru = Convert.ToDecimal(node["BanknoteSelling"].InnerText.Replace(".", ","));

                    result.Data.Add(kur);
                }

            }


            catch (Exception ex)
            {
                result.Hata = ex.Message;
            }
            return result;
        }
    }
}

