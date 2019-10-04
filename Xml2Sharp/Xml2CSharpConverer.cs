using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Xml2Sharp
{
    public class Xml2CSharpConverer
    {
        public IEnumerable<Class> Convert(string xml)
        {
            try
            {
                var xElement = XElement.Parse(xml);

                return xElement.ExtractClassInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
