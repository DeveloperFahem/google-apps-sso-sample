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
<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Prompt.aspx.cs" Inherits="Google.Apps.SingleSignOn.Web.Prompt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Google Apps Single Sign-On</title>
</head>
<body>
    <form id="form1" method="post" action="SignIn.aspx">
        Username:
        <input type="text" id="Username" name="Username" size="50" maxlength="50" /><br />
        Password:
        <input type="password" id="Password" name="Password" size="50" maxlength="50" /><br />
        <input type="submit" value="Sign in" /><br />
        <textarea id="SAMLRequest" name="SAMLRequest" cols="130" rows="15" runat="server"></textarea><br />
        <textarea id="RelayState" name="RelayState" cols="130" rows="5" runat="server"></textarea><br />
    </form>
</body>
</html>
