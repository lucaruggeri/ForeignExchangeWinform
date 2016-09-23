using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ForeignExchange.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Windows.Forms;
using System.Resources;

namespace ForeignExchange.FixerForeignExchangeRates
{
    public static class FixerForeignExchangeRates
    {
        private const string uri = "http://api.fixer.io/";

        public static async Task GetRates(DateTime date, DataGridView lstRates)
        {
            string testResponse = await CallRemoteApi_LoadExchangeRates(date);

            //deserialize response
            if (testResponse != null)
            {
                RootobjectForeignExchange g = new RootobjectForeignExchange();
                g = JsonConvert.DeserializeObject<RootobjectForeignExchange>(testResponse.ToString());

                //use response
                if (g != null)
                {
                    List<RateItem> rates = new List<RateItem>();
                    rates.Add(new RateItem { ID = "AUD", Name = "Australian Dollar", Value = g.rates.AUD });
                    rates.Add(new RateItem { ID = "BGN", Name = "Bulgarian Lev", Value = g.rates.BGN });
                    rates.Add(new RateItem { ID = "BRL", Name = "Brazilian Real", Value = g.rates.BRL });
                    rates.Add(new RateItem { ID = "CAD", Name = "Canadian Dollar", Value = g.rates.CAD });
                    rates.Add(new RateItem { ID = "CHF", Name = "Swiss Franc", Value = g.rates.CHF });
                    rates.Add(new RateItem { ID = "CNY", Name = "Chinese Yuan Renminbi", Value = g.rates.CNY });
                    rates.Add(new RateItem { ID = "CZK", Name = "Czech Koruna", Value = g.rates.CZK });
                    rates.Add(new RateItem { ID = "DKK", Name = "Danish Krone", Value = g.rates.DKK });
                    rates.Add(new RateItem { ID = "GBP", Name = "British Pound", Value = g.rates.GBP });
                    rates.Add(new RateItem { ID = "HKD", Name = "Hong Kong Dollar", Value = g.rates.HKD });
                    rates.Add(new RateItem { ID = "HRK", Name = "Croatian Kuna", Value = g.rates.HRK });
                    rates.Add(new RateItem { ID = "HUF", Name = "Hungarian Forint", Value = g.rates.HUF });
                    rates.Add(new RateItem { ID = "IDR", Name = "Indonesian Rupiah", Value = g.rates.IDR });
                    rates.Add(new RateItem { ID = "ILS", Name = "Israeli Shekel", Value = g.rates.ILS });
                    rates.Add(new RateItem { ID = "INR", Name = "Indian Rupee", Value = g.rates.INR });
                    rates.Add(new RateItem { ID = "JPY", Name = "Japanese Yen", Value = g.rates.JPY });
                    rates.Add(new RateItem { ID = "KRW", Name = "South Korean Won", Value = g.rates.KRW });
                    rates.Add(new RateItem { ID = "MXN", Name = "Mexican Peso", Value = g.rates.MXN });
                    rates.Add(new RateItem { ID = "MYR", Name = "Malaysian Ringgit", Value = g.rates.MYR });
                    rates.Add(new RateItem { ID = "NOK", Name = "Norwegian Krone", Value = g.rates.NOK });
                    rates.Add(new RateItem { ID = "NZD", Name = "New Zealand Dollar", Value = g.rates.NZD });
                    rates.Add(new RateItem { ID = "PHP", Name = "Philippine Peso", Value = g.rates.PHP });

                    rates = rates.OrderBy(x => x.Value).ToList();

                    if (rates != null)
                    {
                        lstRates.DataSource = rates;
                        //lstRates.Sort(lstRates.Columns[2], System.ComponentModel.ListSortDirection.Descending);
                    }
                }
            }
        }

        public class RateItem
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public float Value { get; set; }
        }

        private static async Task<string> CallRemoteApi_LoadExchangeRates(DateTime date)
        {
            string strMonth = date.Month.ToString();
            if (strMonth.Length == 1)
            {
                strMonth = "0" + strMonth;
            }
            string strDay = date.Day.ToString();
            if (strDay.Length == 1)
            {
                strDay = "0" + strDay;
            }
            string strDate = date.Year.ToString() + "-" + strMonth + "-" + strDay;
            string completeUri = uri + strDate;

            HttpClient client = WebAPI.WebAPI.CreateHttpClient(completeUri);

            HttpResponseMessage response = await client.GetAsync(completeUri);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = string.Empty;

                string lineSeparator = ((char)0x2028).ToString();
                string paragraphSeparator = ((char)0x2029).ToString();

                jsonResponse = await response.Content.ReadAsStringAsync();
                jsonResponse = jsonResponse.Replace("\r\n", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(lineSeparator, string.Empty).Replace(paragraphSeparator, string.Empty);

                return jsonResponse;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
