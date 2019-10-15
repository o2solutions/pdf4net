using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Samples;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class CertifyingSignature
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\SupportFiles\\";
            
            X509Certificate2 certificate = new X509Certificate2(supportPath + "O2SolutionsDemoCertificate.pfx", "P@ssw0rd!", X509KeyStorageFlags.Exportable);
            FileStream formStream = File.OpenRead(supportPath + "formfill.pdf");

            SampleOutputInfo[] output = O2S.Components.PDF4NET.Samples.CertifyingSignature.Run(formStream, certificate);
            
            formStream.Close();

            for (int i = 0; i < output.Length; i++)
            {
                FileStream outStream = new FileStream(output[i].FileName, FileMode.Create, FileAccess.ReadWrite, FileShare.Read); 
                output[i].Document.Save(outStream, output[i].SecurityHandler);
				outStream.Flush();
				outStream.Dispose();
            }

            Console.WriteLine("File(s) saved with success to current folder.");
        }
    }
}
