<%--
Copyright 2006 Google Inc.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
--%>
<%@ Page Language="c#" Codebehind="SingleSignOn.aspx.cs" AutoEventWireup="True" Inherits="Google.Apps.SingleSignOn.Web.SingleSignOn" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Google Apps Single Sign-On</title>

    <script language="javascript"><!--
      function SubmitLoginForm() {
        document.forms[0].submit();
      }
    //-->
    </script>

</head>
<body onload="SubmitLoginForm();">
    <div style="display: none;">
        <form id="FormSamlResponse" method="post" action="<%= ActionUrl %>">
            <textarea id="SAMLResponse" name="SAMLResponse" cols="130" rows="15" runat="server"></textarea><br />
            <textarea id="RelayState" name="RelayState" cols="130" rows="5" runat="server"></textarea><br />
            <input type="submit" value="Submit SAML Response" />
        </form>
    </div>
    <i>Loading Google Application ...</i>
</body>
</html>
