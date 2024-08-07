using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace Conversor
{
    public class ExchangeRateData
    {
        public Dictionary<string, double> rates { get; set; }
    }
    public class Metodos
    {
       

        public async Task<float> ConvertMoeda(string antes, string apos, float valor)
        {
            float exchangeRate = await GetExchangeRate(antes, apos);
            return valor * exchangeRate;
        }

        private async Task<float> GetExchangeRate(string fromCurrency, string toCurrency)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://api.exchangerate-api.com/v4/latest/{fromCurrency}";
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<ExchangeRateData>();
                    return (float)data.rates[toCurrency];
                }
                else
                {
                    return -1;
                }
            }
        }

        public float ConvertMoedaGeneric(string antes, string apos, float valor)
        {
            double newvalor = 0;
            switch (antes)
            {
                case "EUR":
                    switch (apos)
                    {
                        case "EUR":
                            return valor;
                        case "USD":
                            newvalor = valor * 1.09;
                            return (float)newvalor;
                        case "BRL":
                            newvalor = valor * 6.13;
                            return (float)newvalor;
                        case "GBP":
                            newvalor = valor * 0.8595;
                            return (float)newvalor;
                    }
                    break;
                case "USD":
                    switch (apos)
                    {
                        case "EUR":
                            newvalor = valor *0.9145;
                            return (float)newvalor;
                        case "USD":
                            return valor;
                        case "BRL":
                            newvalor = valor * 5.72;
                            return (float)newvalor;
                        case "GBP":
                            newvalor = valor * 0.786;
                            return (float)newvalor;
                    }
                    break;
                case "BRL":
                    switch (apos)
                    {
                        case "EUR":
                            newvalor = valor * 0.1631;
                            return (float)newvalor;
                        case "USD":
                            newvalor = valor * 0.1784;
                            return (float)newvalor;
                        case "BRL":
                            return valor;
                        case "GBP":
                            newvalor = valor * 0.16;
                            return (float)newvalor;
                    }
                    break;
                case "GBP":
                    switch (apos)
                    {
                        case "EUR":
                            newvalor = valor * 1.17;
                            return (float)newvalor;
                        case "USD":
                            newvalor = valor * 1.3;
                            return (float)newvalor;
                        case "BRL":
                            newvalor = valor * 6;
                            return (float)newvalor;
                        case "GBP":
                            return valor;
                    }
                    break;
            }
            return 0;
        }

        public float ReceiveOptionsEnergia(string antes, string apos, float valor)
        {
            double newvalor = 0;
            switch (antes)
            {
                case "Joules":
                    switch(apos)
                    {
                        case "Joules":
                            newvalor =valor;
                            return (float)newvalor;
                        case "Calorias":
                            newvalor = valor/4.184;
                            return (float)newvalor;
                        case "KiloWatts hora":
                            newvalor = valor/3600000;
                            return (float)newvalor;
                    }
                    break;
                case "Calorias":
                    newvalor = valor*4.184;
                    return (float)newvalor;
                case "KiloWatts hora":
                    newvalor = valor*3600000;
                    return (float)newvalor;
            }
            return 0;
        }
        public float ReceiveOptionsTempo(string antes, string apos, float valor)
        {
            double newvalor = 0;
            switch (antes)
            {
                case "Anos":
                    switch (apos)
                    {
                        case "Anos":
                            newvalor = valor;
                            return (float)newvalor;
                        case "Meses":
                            newvalor = valor *12;
                            return (float)newvalor;
                        case "Dias":
                            newvalor = valor * 365.25;
                            return (float)newvalor;
                        case "Horas":
                            newvalor = valor * 365.25*24;
                            return (float)newvalor;
                        case "Minutos":
                            newvalor = valor * 365.25*24*60;
                            return (float)newvalor;
                        case "Segundos":
                            newvalor = valor * 365.25*24*60*60;
                            return (float)newvalor;
                    }
                    break;
                case "Meses":
                    switch (apos)
                    {
                        case "Anos":
                            newvalor = valor/12;
                            return (float)newvalor;
                        case "Meses":
                            newvalor = valor;
                            return (float)newvalor;
                        case "Dias":
                            newvalor = valor*30.44;
                            return (float)newvalor;
                        case "Horas":
                            newvalor = valor * 30.44 * 24;
                            return (float)newvalor;
                        case "Minutos":
                            newvalor = valor * 30.44 * 24 * 60;
                            return (float)newvalor;
                        case "Segundos":
                            newvalor = valor * 30.44 * 24 * 60 * 60;
                            return (float)newvalor;
                    }
                    break;
                case "Dias":
                    switch (apos)
                    {
                        case "Anos":
                            newvalor = valor/365;
                            return (float)newvalor;
                        case "Meses":
                            newvalor = valor/30.44;
                            return (float)newvalor;
                        case "Dias":
                            newvalor = valor;
                            return (float)newvalor;
                        case "Horas":
                            newvalor = valor*24;
                            return (float)newvalor;
                        case "Minutos":
                            newvalor = valor *24 * 60;
                            return (float)newvalor;
                        case "Segundos":
                            newvalor = valor * 24 * 60 * 60;
                            return (float)newvalor;
                    }
                    break;
                case "Horas":
                    switch (apos)
                    {
                        case "Anos":
                            newvalor = valor / 8766;
                            return (float)newvalor;
                        case "Meses":
                            newvalor = valor / (30.44*24);
                            return (float)newvalor;
                        case "Dias":
                            newvalor = valor;
                            return (float)newvalor/24;
                        case "Horas":
                            newvalor = valor;
                            return (float)newvalor;
                        case "Minutos":
                            newvalor = valor  * 60;
                            return (float)newvalor;
                        case "Segundos":
                            newvalor = valor  * 60 * 60;
                            return (float)newvalor;
                    }
                    break;
                case "Minutos":
                    switch (apos)
                    {
                        case "Anos":
                            newvalor = valor / 525960;
                            return (float)newvalor;
                        case "Meses":
                            newvalor = valor / (30.44 * 24*60);
                            return (float)newvalor;
                        case "Dias":
                            newvalor = valor;
                            return (float)newvalor / (24*60);
                        case "Horas":
                            newvalor = valor;
                            return (float)newvalor/60;
                        case "Minutos":
                            newvalor = valor;
                            return (float)newvalor;
                        case "Segundos":
                            newvalor = valor * 60;
                            return (float)newvalor;
                    }
                    break;
                case "Segundos":
                    switch (apos)
                    {
                        case "Anos":
                            newvalor = valor / (527040*60);
                            return (float)newvalor;
                        case "Meses":
                            newvalor = valor / (30.44 * 24*60*60);
                            return (float)newvalor;
                        case "Dias":
                            newvalor = valor;
                            return (float)newvalor / (24*60*60);
                        case "Horas":
                            newvalor = valor;
                            return (float)newvalor/(60*60);
                        case "Minutos":
                            newvalor = valor;
                            return (float)newvalor/60;
                        case "Segundos":
                            newvalor = valor;
                            return (float)newvalor;
                    }
                    break;
            }
            return 0;
        }

        public float ReceiveOptionsComprimentos(string antes, string apos, float valor)
        {
            double newvalor = 0;
            switch (antes)
            {
                case "Milha":
                    newvalor = valor * 1.60934;
                    return (float)newvalor;
                case "Metros":
                    switch (apos)
                    {
                        case "Milha":
                            newvalor = valor/1.60934;
                            return (float)newvalor;
                        case "Polegadas":
                            newvalor = valor/39.3701;
                            return (float)newvalor ;
                        case "Centimetros":
                            newvalor = valor;
                            return (float)newvalor * 100;
                        case "Metros":
                            newvalor = valor;
                            return (float)newvalor;
                    }
                    break;
                case "Centimetros":
                    switch (apos)
                    {
                        case "Milha":
                            newvalor = valor / (1.60934*100);
                            return (float)newvalor;
                        case "Polegadas":
                            newvalor = valor / 0.393701;
                            return (float)newvalor;
                        case "Centimetros":
                            newvalor = valor;
                            return (float)newvalor;
                        case "Metros":
                            newvalor = valor;
                            return (float)newvalor/100;
                    }
                    break;
                case "Polegadas":
                    newvalor = valor * 2.54;
                    return (float)newvalor;
            }
            return 0;
        }
    }

   
}
