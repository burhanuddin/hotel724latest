using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using H724.Web.ExpediaService;
using H724.Web.Infra;
using System.Net;
using System.IO;
using System.Data;

namespace H724.Web.Controllers
{
    public class HotelsController : MController
    {
        private const string ApiKey = "rs3m6mzwdz2sxuxtmsqtup8r";
        private const string Secret = "ubks2axK";
        private const int Cid = 55505;

        // GET: Hotels
        [ChildActionOnly]
        public void HotelListView()
        {
            try
            {
                string url = "https://api.eancdn.com/ean-services/rs/hotel/v3/list?cid=55505&minorRev=99&apiKey=rs3m6mzwdz2sxuxtmsqtup8r&locale=en_US&currencyCode=USD&xml=%3CHotelListRequest%3E%0A%20%20%20%20%3Ccity%3ESeattle%3C%2Fcity%3E%0A%20%20%20%20%3CstateProvinceCode%3EWA%3C%2FstateProvinceCode%3E%0A%20%20%20%20%3CcountryCode%3EUS%3C%2FcountryCode%3E%0A%20%20%20%20%3CarrivalDate%3E7%2F16%2F2014%3C%2FarrivalDate%3E%0A%20%20%20%20%3CdepartureDate%3E7%2F18%2F2014%3C%2FdepartureDate%3E%0A%20%20%20%20%3CRoomGroup%3E%0A%20%20%20%20%20%20%20%20%3CRoom%3E%0A%20%20%20%20%20%20%20%20%20%20%20%20%3CnumberOfAdults%3E2%3C%2FnumberOfAdults%3E%0A%20%20%20%20%20%20%20%20%3C%2FRoom%3E%0A%20%20%20%20%3C%2FRoomGroup%3E%0A%20%20%20%20%3CnumberOfResults%3E25%3C%2FnumberOfResults%3E%0A%3C%2FHotelListRequest%3E";
                WebRequest request = WebRequest.Create(url);
                request.ContentType = "text/xml";
                request.Timeout = 400000;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                response.Close();
            }
            catch (Exception ex)
            {
            
            }
        }

        private HotelListRequest SetHotelListRequest()
        {
            var sig = (ApiKey + Secret + (Int32)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).Md5GenerateHash();

            return new HotelListRequest
            {
                apiKey = ApiKey,
                cid = Cid,
                sig = sig,
                minorRev = 26
            };
        }
    }
}