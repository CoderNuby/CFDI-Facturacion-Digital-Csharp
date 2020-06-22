using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System;
using System.Collections.Generic;

namespace FacturacionDigital_CFDI
{
    class Program
    {
        static void Main(string[] args)
        {
            Comprobante comprobante = new Comprobante();


            ////////////Comprobante/////////////////////
            comprobante.Version = "3.3";
            comprobante.Serie = "S";
            comprobante.Folio = "1";
            comprobante.Fecha = DateTime.Now;//CAMBIAR LA FECHA A FORMATO ORIGINAL
            comprobante.Sello = "Falta";//EL SELLO FALTA DE IMPLEMENTARCE
            comprobante.FormaPago = "99";
            comprobante.NoCertificado = "23456789998765432123";//FALTA EN NUMERO DE CERTIFICADO
            comprobante.Certificado = "";//FALTA EL CERTIFICADO
            comprobante.SubTotal = 100;
            comprobante.Descuento = 1;
            comprobante.Moneda = "MXN";
            comprobante.Total = 99;
            comprobante.TipoDeComprobante = "I";
            comprobante.MetodoPago = "PUE";
            comprobante.LugarExpedicion = "20131";




            ////////EMISOR////////////////////////////////////
            ComprobanteEmisor emisor = new ComprobanteEmisor();

            emisor.Rfc = "POWE870601DM7";
            emisor.Nombre = "una razón";
            emisor.RegimenFiscal = "605";

            ////////RESEPTOR////////////////////////////////////
            ComprobanteReceptor receptor = new ComprobanteReceptor();
            receptor.Nombre = "Test";
            receptor.Rfc = "TEST1234566546";
            receptor.UsoCFDI = "P01";

            //Asignacion de emisor y reseptor al a los atributos del objeto Comprobante
            comprobante.Emisor = emisor;
            comprobante.Receptor = receptor;

            //Creacion de lista ComproboanteConcepto 
            List<ComprobanteConcepto> conceptos = new List<ComprobanteConcepto>();
            ComprobanteConcepto compConcepto = new ComprobanteConcepto();

            compConcepto.Importe = 10;
            compConcepto.ClaveProdServ = "92111704";
            compConcepto.Cantidad = 1;
            compConcepto.ClaveUnidad = "C81";
            compConcepto.Descripcion = "Un misil para la guerra";
            compConcepto.ValorUnitario = 100;
            compConcepto.Descuento = 1;

            
            
            conceptos.Add(compConcepto);

            comprobante.Conceptos = conceptos.ToArray();

            //Serializamos////////////////////////////////////////////////////////
            string pathXML = @"C:\Users\ivanr\Documents\github\FacturacionDigital-CFDI\FacturacionDigital-CFDI\xml\myFirstXML.xml";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Comprobante));

            string Sxml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xmlSerializer.Serialize(writer, comprobante);
                    Sxml = sww.ToString();
                }
            }

            ///////GUARDAMOS EL STRING EN UN ARCHIVO//////////////////////////

            File.WriteAllText(pathXML, Sxml);


        }
    }
}
