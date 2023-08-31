using Microsoft.AspNetCore.Mvc;
using Repay_Bank.DTO.DTOS.CurrencyExchange;

namespace Repay_Bank.PresentationLayer.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index(Currency currency)
        {
            #region
            var client1 = new HttpClient();
            var request1 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=EUR&to=TRY&q=1.0"),
                Headers =
    {
        { "X-RapidAPI-Key", "a6c043aebcmshb432f617f8dd5c0p196a7cjsnf61c5cb36c7f" },
        { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
    },
            };
            using (var response1 = await client1.SendAsync(request1))
            {
                response1.EnsureSuccessStatusCode();
                var body = await response1.Content.ReadAsStringAsync();
                ViewBag.EUROtoTRY = body;
            }
            #endregion
            #region
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=USD&to=TRY&q=1.0"),
                Headers =
            {
                { "X-RapidAPI-Key", "a6c043aebcmshb432f617f8dd5c0p196a7cjsnf61c5cb36c7f" },
                { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ViewBag.usdtotry = body;
            }
            #endregion
            #region
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=JPY&to=TRY&q=1.0"),
                Headers =
            {
                { "X-RapidAPI-Key", "a6c043aebcmshb432f617f8dd5c0p196a7cjsnf61c5cb36c7f" },
                { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
            },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body = await response2.Content.ReadAsStringAsync();
                ViewBag.JPYtoTRY = body;
            }
            #endregion
            #region
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=RUB&to=TRY&q=1.0"),
                Headers =
            {
                { "X-RapidAPI-Key", "a6c043aebcmshb432f617f8dd5c0p196a7cjsnf61c5cb36c7f" },
                { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
            },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body = await response3.Content.ReadAsStringAsync();
                ViewBag.RUBtoTRY = body;
            }
            #endregion
            #region
            var client4 = new HttpClient();
            var request4 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=INR&to=TRY&q=1.0"),
                Headers =
            {
                { "X-RapidAPI-Key", "a6c043aebcmshb432f617f8dd5c0p196a7cjsnf61c5cb36c7f" },
                { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
            },
            };
            using (var response4 = await client4.SendAsync(request4))
            {
                response4.EnsureSuccessStatusCode();
                var body = await response4.Content.ReadAsStringAsync();
             
                ViewBag.INRtoTRY = body;
            }
            #endregion
            return View();
        }
    }
}
