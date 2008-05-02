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

using System;
using System.Xml;

namespace Google.Apps.SingleSignOn
{
    /// <summary>
    /// Container for arguments passed as part of a SAML Request document.
    /// </summary>
    public class SamlRequestArgs
    {
        public string Id;
        public string IssueInstant;
        public string ProviderName;
        public string AssertionConsumerServiceUrl;
        public bool IsPassive;

        public SamlRequestArgs(XmlDocument requestXml)
        {
            ParseRequestXml(requestXml);
        }

        private void ParseRequestXml(XmlDocument doc)
        {
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("samlp", "urn:oasis:names:tc:SAML:2.0:protocol");

            XmlNode root = doc.SelectSingleNode("/samlp:AuthnRequest", ns);

            this.Id =
                root.Attributes["ID"].Value;

            this.IssueInstant =
                root.Attributes["IssueInstant"].Value;

            this.ProviderName =
                root.Attributes["ProviderName"].Value;

            this.AssertionConsumerServiceUrl =
                root.Attributes["AssertionConsumerServiceURL"].Value;

            this.IsPassive =
                Convert.ToBoolean(root.Attributes["IsPassive"].Value);
        }
    }
}
