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
<%@ Page Language="c#" Codebehind="SingleSignOnDebug.aspx.cs" AutoEventWireup="True"
    Inherits="Google.Apps.SingleSignOn.Web.SingleSignOnDebug" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Google Apps Single Sign-On</title>
    <style type="text/css">
      body { font-family: Tahoma; font-size: 10pt; }
      td { font-family: Tahoma; font-size: 10pt; }
      td.label { font-weight: bold; text-align: right; vertical-align: top; }
      input.button {
        background-color: #cccccc;
        color: black;
        font-weight: bold;
        font-size: 90%;
        font-family: sans-serif;
        text-align: center;
        border-style: outset;
        border-width: 2px;
        margin: 3px;
        padding: 2px;
        cursor: hand;
        vertical-align: middle;
      }
    </style>
</head>
<body>
    <font size="5"><b>Google Apps Single Sign-On Debug</b><br />
    </font>
    <form id="FormSamlResponse" method="post" action="<%= ActionUrl %>">
        <fieldset>
            <legend>Google ACS Parameters</legend>
            <br />
            <b>SAML Response</b><br />
            <textarea id="SAMLResponse" name="SAMLResponse" cols="130" rows="15" runat="server"></textarea><br />
            <p />
            <b>Relay State</b><br />
            <textarea id="RelayState" name="RelayState" cols="130" rows="5" runat="server"></textarea><br />
            <p />
            <b>Assertion URL</b><br />
            <asp:Literal ID="LiteralAssertionUrl" runat="server" />
            <p />
            <input type="submit" value="Submit SAML Response" class="button" />
        </fieldset>
    </form>
    <fieldset>
        <legend>SAML Request</legend>
        <br />
        <b>SAML Request (Encoded)</b><br />
        <textarea id="TextAreaSamlRequestEncoded" cols="130" rows="5" runat="server" name="TextAreaSamlRequestEncoded"></textarea><br />
        <p />
        <b>SAML Request (Decoded)</b><br />
        <textarea id="TextAreaSamlRequestDecoded" cols="130" rows="8" runat="server" name="TextAreaSamlRequestDecoded"></textarea><br />
        <p />
    </fieldset>
</body>
</html>
