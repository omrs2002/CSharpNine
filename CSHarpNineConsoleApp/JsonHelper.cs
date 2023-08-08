using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSHarpNineConsoleApp
{
    public static class JsonHelper
    {


        public static string QueryJson(string jString)
        {
            var jObject = JObject.Parse(jString);
            var trList = jObject["tbody"]["tr"];
            string[] names = trList.SelectMany(tr => tr.SelectTokens("td[0].a.#text", false))
                                   .Select(t => t.Value<string>())
                                   .ToArray();
            return "";
        }


    }
}
