using System;
using System.IO;
using System.Net;
using System.Reflection;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.DigitalSignatures;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class DocumentTimeStamp
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\SupportFiles\\";

            FileStream formStream = File.OpenRead(supportPath + "formfill.pdf");

            SampleOutputInfo[] output = O2S.Components.PDF4NET.Samples.DocumentTimeStamp.Run(formStream, OnSignatureTimeStamp);

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

        private static void OnSignatureTimeStamp(PDFTimeStampEventData eventData)
        {
            HttpWebRequest tsaReq = (HttpWebRequest)WebRequest.Create("<enter your timestamp server address here>");

            tsaReq.ContentType = "application/timestamp-query";
            tsaReq.Method = "POST";
            Stream tsaReqStream = tsaReq.GetRequestStream();
            tsaReqStream.Write(eventData.TimeStampRequest, 0, eventData.TimeStampRequest.Length);

            HttpWebResponse tsaResp = (HttpWebResponse)tsaReq.GetResponse();
            Stream tsaRespStream = tsaResp.GetResponseStream();

            byte[] buffer = new byte[65536];
            int responseSize = tsaRespStream.Read(buffer, 0, buffer.Length);

            eventData.TimeStampResponse = new byte[responseSize];
            Array.Copy(buffer, 0, eventData.TimeStampResponse, 0, responseSize);
        }

    }
}
