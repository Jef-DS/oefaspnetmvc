using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using oef5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oef5.Services
{
    public class BestellingService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BestellingService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        public WinkelWagen GetWinkelWagen()
        {
            ISession session = _httpContextAccessor.HttpContext.Session;
            WinkelWagen wagen = session.GetObjectFromJson<WinkelWagen>("winkelwagen");
            if (wagen == null)
            {
                wagen = new WinkelWagen();
                session.SetObjectAsJSon("winkelwagen", wagen);
            }
            return wagen;
        }
        public void BewaarWinkelWagen(WinkelWagen wagen)
        {
            ISession session = _httpContextAccessor.HttpContext.Session;
            session.SetObjectAsJSon("winkelwagen", wagen);
        }
    }
    public static class SessionExtensions
    {
        public static void SetObjectAsJSon(this ISession session, String key, WinkelWagen value)
        {
            String json = JsonConvert.SerializeObject(value);
            session.SetString(key, json);
        }
        public static T GetObjectFromJson<T>(this ISession session, String key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }

}
