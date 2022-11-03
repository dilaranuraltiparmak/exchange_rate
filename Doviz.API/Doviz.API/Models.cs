using System.Collections.Generic;

namespace Doviz.API
{
   
        public class RequestData
        {
            public int gun { get; set; }
            public int ay { get; set; }
            public int yil { get; set; }
            public bool IsBugun { get; set; }
        }
        public class ResponseDataKur
        {
            public string kodu { get; set; }
            public string adi { get; set; }
            public int birimi { get; set; }
            public decimal alisKuru { get; set; }
            public decimal satisKuru { get; set; }
            public decimal efektifAlisKuru { get; set; }
            public decimal efektifSatisKuru { get; set; }


        }
        public class ResponseData
        {
            public List<ResponseDataKur> Data { get; set; }
            public string Hata { get; set; }
        }
    }

