// Copyright 2006 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Configuration;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.Web;

namespace Google.Apps.SingleSignOn
{
    /// <summary>
    /// Provides methods to digital sign Xml documents.
    /// </summary>
    internal static class XmlDocumentSigner
    {
        public static void Sign(XmlDocument doc)
        {
            Sign(doc, LoadRsaKey());
        }

        // code outline borrowed from: http://blogs.msdn.com/shawnfa/archive/2003/11/12/57030.aspx
        public static void Sign(XmlDocument doc, RSA key)
        {
            SignedXml signer = new SignedXml(doc);

            // setup the key used to sign 
            signer.KeyInfo = new KeyInfo();
            signer.KeyInfo.AddClause(new RSAKeyValue(key));
            signer.SigningKey = key;

            // create a reference to the root of the document 
            Reference orderRef = new Reference("");
            orderRef.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            signer.AddReference(orderRef);

            // add transforms that only select the order items, type, and 
            // compute the signature, and add it to the document 
            signer.ComputeSignature();
            doc.DocumentElement.PrependChild(signer.GetXml());
        }

        // RSA PEM parser: http://www.jensign.com/opensslkey/
        public static RSACryptoServiceProvider LoadRsaKey()
        {
            string xml;
            xml = ConfigurationManager.AppSettings["Google.Apps.SingleSignOn.PfxFile"];
            xml = HttpUtility.HtmlDecode(xml);

            X509Certificate2 cert = new X509Certificate2(xml, "");
            RSACryptoServiceProvider crypto = cert.PrivateKey as RSACryptoServiceProvider;

            return crypto;
        }
    }
}
