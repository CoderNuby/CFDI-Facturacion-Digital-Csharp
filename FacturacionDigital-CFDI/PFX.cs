using System;
using System.IO;
using System.Diagnostics;

namespace FacturacionDigital_CFDI
{
    
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class PFX
    {
        string cer;
        string key;
        string clavePrivada = "";
        string archivoPFX;
        string archivoKPEM;
        string archivoCPEM;

        public string error = "";
        public string mensajeExito = "";



        public PFX(string cer_, string key_, string clavePrivada_, string archivoPfx_, string pathTemp)
        {
            cer = cer_;
            key = key_;
            clavePrivada = clavePrivada_;

            archivoKPEM = pathTemp + "kpem.pem";
            archivoCPEM = pathTemp + "cpem.pem";

            archivoPFX = archivoPfx_;
        }


        public bool crearPFX()
        {
            bool exito = false;


            //Validacion
            if (!File.Exists(cer))
            {
                error = "No existe el archivo cer en el sistema";
                return false;
            }

            if (!File.Exists(key))
            {
                error = "No existe el archivo key en el sistema";
                return false;
            }

            if (clavePrivada.Trim().Equals(""))
            {
                error = "No existe una clave privada aun en el sistema";
                return false;
            }

            //Creamos objetos process
            Process proc1 = new Process();
            Process proc2 = new Process();
            Process proc3 = new Process();

            proc1.EnableRaisingEvents = false;
            proc2.EnableRaisingEvents = false;
            proc3.EnableRaisingEvents = false;

            //openssl x509 -inform DER  -in certificado.cer -out certificado.pem
            proc1.StartInfo.FileName = "openss1";
            /*
             CODIGO PENDIENTE
             https://www.youtube.com/watch?v=qu9kNr63DJs&list=PLWYKfSbdsjJiQwcGNZmICkes0iJHN_7XJ&index=2
             VER VIDEO DE YOUTUBE PARA VER MAS ACERCA DE LA IMPLEMENTACION DE ESTE MENTODO

             */
            return false;//QUITAR AL IMPLEMENTAR OPENSSL!!!!!!!!!!!!!!
        }
    }

}
