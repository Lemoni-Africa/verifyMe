using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace VerifyMeIntegration.Helpers
{
    public class Computation
    {

        public static bool ValidateWebHookSignature(string jsonInput, string verifyMeSignature, string _apiSecret)
        {
            //string jsonInput = "YOUR_WEBHOOK_PAYLOAD"; //JSON webhook payload gotten from your request handler
            string inputstring = Convert.ToString(new JValue(jsonInput));
            string result = "";
            byte[] secretkeyBytes = Encoding.UTF8.GetBytes(_apiSecret);
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputstring);
            using (var hmac = new HMACSHA512(secretkeyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(inputBytes);
                result = BitConverter.ToString(hashValue).Replace("-", string.Empty); ;
            }
            Console.WriteLine(result);
            //string verifyMeSignature = ""; //put in the request's value for x-verifyme-signature

            if (result.ToLower().Equals(verifyMeSignature))
            {
                return true;
            }
            return false;

        }

        public static DateTime MyChangeToDateTime(string dateString)
        {
            if (dateString != null)
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime newDate = DateTime.ParseExact(dateString, new string[] { "dd/MM/yyyy hh:mm:ss tt", "dd-MM-yyyy hh:mm:ss tt", "MM/dd/yyyy hh:mm:ss tt", "M/dd/yyyy hh:mm:ss tt", "M-dd-yyyy hh:mm:ss tt",  "yyyy/MM/dd hh:mm:ss tt", "yyyy-MM-dd hh:mm:ss tt",
                    "d/M/yyyy h:m:s tt", "dd-MM-yyyy h:m:s tt", "d/M/yyyy h:m:s tt", "M/d/yyyy h:m:s tt", "M-dd-yyyy hh:mm:ss tt",  "yyyy/MM/dd hh:mm:ss tt", "yyyy-MM-dd hh:mm:ss tt",
                    "yyyy-MM-ddTHH:mm:ss.fffffffZ", "yyyy-MM-dd HH:mm:ss", "dd-MM-yyyy HH:mm:ss",  "dd/MM/yyyy HH:mm:ss", "yyyy-MM-ddTHH:mm:ss.fff", "dd/MM/yyyyTHH:mm:ss", "dd-MM-yyyyTHH:mm:ss", "dd.MM.yyyy", "dd/MM/yyyy", "dd-MM-yyyy", "MM.dd.yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd", "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd", "yyyy-dd-MM", "dd-MM-yy", "yy-MM-dd", "dd-MMM-yy", "yy-MMM-dd" }, provider, DateTimeStyles.None);
                return newDate;
            }
            return DateTime.Now;
        }
    }
}
