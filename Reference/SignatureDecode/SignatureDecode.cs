using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.DigitalSignatures;
using O2S.Components.PDF4NET.DigitalSignatures.Asn1;
using O2S.Components.PDF4NET.Forms;
using O2S.Components.PDF4NET.Samples;
using O2S.Components.PDF4NET.Utilities;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class SaveSignedCopy
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\SupportFiles\\";

            PDFFixedDocument document = new PDFFixedDocument(supportPath + "PDF4NET.pdf");
            PDFSignatureField signature1Field = document.Form.Fields["Signature1"] as PDFSignatureField;

            PDFComputedDigitalSignature signature1 = signature1Field.Signature as PDFComputedDigitalSignature;

            Asn1Object[] asn1Signature = signature1.DecodeSignature();
            DumpSignature(asn1Signature[0], 0);
        }

        private static void DumpSignature(Asn1Object asn1Obj, int level)
        {
            string padding = "".PadLeft(level * 2);
            string items = "";
            Asn1ContextSpecificSequence asn1CtxSeq = asn1Obj as Asn1ContextSpecificSequence;
            if (asn1CtxSeq != null)
            {
                items = asn1CtxSeq.Count == 1 ? "item" : "items";
                Console.WriteLine("{0}[{1}] ({2} {3})", padding, (int)asn1CtxSeq.Tag & 0x1F, asn1CtxSeq.Count, items);
                for (int i = 0; i < asn1CtxSeq.Count; i++)
                {
                    DumpSignature(asn1CtxSeq[i], level + 1);
                }
            }
            else
            {
                switch (asn1Obj.Tag)
                {
                    case Asn1Tag.BitString:
                        Console.WriteLine("{0}BITSTRING {1}", padding, asn1Obj);
                        break;
                    case Asn1Tag.Boolean:
                        Console.WriteLine("{0}BOOLEAN {1}", padding, asn1Obj);
                        break;
                    case Asn1Tag.IA5String:
                        Console.WriteLine("{0}IA5STRING {1}", padding, asn1Obj);
                        break;
                    case Asn1Tag.Integer:
                        Console.WriteLine("{0}INTEGER {1}", padding, asn1Obj);
                        break;
                    case Asn1Tag.Null:
                        Console.WriteLine("{0}{1}", padding, asn1Obj);
                        break;
                    case Asn1Tag.ObjectIdentifier:
                        Asn1ObjectIdentifier oid = asn1Obj as Asn1ObjectIdentifier;
                        Console.WriteLine("{0}OBJECT IDENTIFIER {1} {2}", padding, oid, oid.FriendlyName);
                        break;
                    case Asn1Tag.OctetString:
                        Console.WriteLine("{0}OCTET STRING {1}", padding, asn1Obj);
                        break;
                    case Asn1Tag.PrintableString:
                        Console.WriteLine("{0}PRINTABLESTRING {1}", padding, asn1Obj);
                        break;
                    case Asn1Tag.Sequence:
                        Asn1Sequence asn1Seq = asn1Obj as Asn1Sequence;
                        items = asn1Seq.Count == 1 ? "item" : "items";
                        Console.WriteLine("{0}SEQUENCE ({1} {2})", padding, asn1Seq.Count, items);
                        for (int i = 0; i < asn1Seq.Count; i++)
                        {
                            DumpSignature(asn1Seq[i], level + 1);
                        }
                        break;
                    case Asn1Tag.Set:
                        Asn1Set asn1Set = asn1Obj as Asn1Set;
                        items = asn1Set.Count == 1 ? "item" : "items";
                        Console.WriteLine("{0}SET ({1} {2})", padding, asn1Set.Count, items);
                        for (int i = 0; i < asn1Set.Count; i++)
                        {
                            DumpSignature(asn1Set[i], level + 1);
                        }
                        break;
                    case Asn1Tag.UtcTime:
                        Console.WriteLine("{0}UTCTIME {1}", padding, asn1Obj);
                        break;
                    case Asn1Tag.Utf8String:
                        Console.WriteLine("{0}UTF8STRING {1}", padding, asn1Obj);
                        break;
                }
            }
        }

    }
}
