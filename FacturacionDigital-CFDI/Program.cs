using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace FacturacionDigital_CFDI
{
    class Program
    {
        static void Main(string[] args)
        {
            Comprobante compr = new Comprobante();

            compr.Folio = "666";//Numero de factura

            ////////EMISOR////////////////////////////////////
            ComprobanteEmisor emisor = new ComprobanteEmisor();

            emisor.Rfc = "POWE870601DM7";
            emisor.Nombre = "una razón";
            emisor.RegimenFiscal = c_RegimenFiscal.Item605;

            ////////RESEPTOR////////////////////////////////////
            ComprobanteReceptor receptor = new ComprobanteReceptor();
            receptor.Nombre = "Test";
            receptor.Rfc = "TEST1234566546";

            compr.Emisor = emisor;

            compr.Receptor = receptor;


            //Serializamos////////////////////////////////////////////////////////
            string pathXML = @"C:\Users\ivanr\Documents\github\FacturacionDigital-CFDI\FacturacionDigital-CFDI\xml\myFirstXML.xml";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Comprobante));

            string Sxml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xmlSerializer.Serialize(writer, compr);
                    Sxml = sww.ToString();
                }
            }

            ///////GUARDAMOS EL STRING EN UN ARCHIVO//////////////////////////

            File.WriteAllText(pathXML, Sxml);


        }
    }
}
