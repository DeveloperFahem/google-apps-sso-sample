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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;

using Google.Apps.SingleSignOn;

namespace Google.Apps.SingleSignOn.Web
{
    /// <summary>
    /// Summary description for SingleSignOn.
    /// </summary>
    public partial class SingleSignOnDebug : System.Web.UI.Page
    {

        protected string actionUrl = string.Empty;

        protected string ActionUrl
        {
            get { return actionUrl; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Request.Form["Username"];
            string password = Request.Form["Password"];
            // validate credentials before proceeding
            if (username == null)
            {
                username = "appstester";
            }
            SetupGoogleLoginForm(username);
        }

        private void SetupGoogleLoginForm(string userName)
        {
            string samlRequest = Request.QueryString["SAMLRequest"];
            if (samlRequest == null)
            {
                samlRequest = Request.Form["SAMLRequest"];
            }
            string relayState = Request.QueryString["RelayState"];
            if (relayState == null)
            {
                relayState = Request.Form["RelayState"];
            }

            if (samlRequest != null && relayState != null)
            {
                XmlDocument samlRequestUnpacked = SamlParser.UnpackRequest(samlRequest);

                string responseXml;
                string actionUrl;

                SamlParser.CreateSignedResponse(
                    samlRequest, userName, out responseXml, out actionUrl);

                this.actionUrl = actionUrl;

                LiteralAssertionUrl.Text = actionUrl;

                TextAreaSamlRequestEncoded.Value = samlRequest;
                TextAreaSamlRequestDecoded.Value = FormatXml(samlRequestUnpacked);

                SAMLResponse.Value = responseXml;
                RelayState.Value = relayState;
            }
        }

        /// <summary>
        /// Formats an Xml string with proper indentation.
        /// </summary>
        /// <param name="doc">The source XmlDocument to be formatted.</param>
        public static string FormatXml(XmlDocument doc)
        {
            string xml;

            using (StringWriter stringWriter = new StringWriter())
            {
                XmlNodeReader xmlReader = new XmlNodeReader(doc);
                XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter);

                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.Indentation = 2;
                xmlWriter.IndentChar = ' ';

                xmlWriter.WriteNode(xmlReader, true);

                xml = stringWriter.ToString();
            }

            return xml;
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        }
        #endregion
    }
}
