This sample C# ASP.NET application can be used as a SAML Identity Provider for the Google Apps Single Sign-On service.

See this article at the Google Code website for an introduction to the Google Apps Single Sign-On service:

http://code.google.com/apis/apps/sso/saml_reference_implementation.html


Building the sample application with Microsoft Visual Studio 2005
-----------------------------------------------------------------

1.  Extract the .zip file to a local directory, e.g. C:\projects\Google.Apps.SingleSignOn.  The contents are:

    key - test certificates
    src - C# source code
    web - ASP.NET source code
    VS2005.sln - Visual Studio 2005 solution file.

2.  Open the C:\projects\Google.Apps.SingleSignOn\VS2005.sln solution file in Visual Studio 2005.

3.  Build the solution.

4.  The executables are in C:\projects\Google.Apps.SingleSignOn\web\bin


Installing the sample application in Internet Information Services
------------------------------------------------------------------

1.  Open the IIS management console.

2.  Create a new Virtual Directory to C:\projects\Google.Apps.SingleSignOn\web, e.g. GoogleAppsSso

3.  Run the Permissions Wizard on the GoogleAppsSso Virtual Directory to set it up as a public website.


Creating and installing a certificate
-------------------------------------

1.  Run these commands from a command prompt.  If Visual Studio 2005 is installed in a different location, change the commands accordingly.

    cd \projects\Google.Apps.SingleSignOn\key

    "C:\Program Files\Microsoft Visual Studio 8\Common7\Tools\Bin\makecert.exe" -r -pe -n "CN=My Domain" -sky exchange -sv mycert.pvk mycert.cer

    "C:\Program Files\Microsoft Visual Studio 8\Common7\Tools\Bin\pvk2pfx.exe" -pvk mycert.pvk -spc mycert.cer -pfx mycert.pfx

    makecert.exe will generate two files:

       mycert.cer - certificate which contains the public key
       mycert.pvk - contains the private key

    pvk2pfx.exe will generate one file:

       mycert.pfx - contains the private key, usable by .NET framework

    Read about these utilities on MSDN:

       makecert.exe
       http://msdn2.microsoft.com/en-us/library/bfsktky3(VS.80).aspx

       pvk2pfx.exe
       http://msdn2.microsoft.com/en-us/library/aa387764.aspx

2.  Verify, and grant if necessary, read permission to the ASP.NET user to read the mycert.pfx file.  One way to do this is through the file properties Security tab.  If you have the xcacls utility installed,

    "C:\Program Files\Support Tools\xcacls.exe" mycert.pfx /e /g MYCOMPUTERNAME\ASPNET:R

3.  Go to the Google Apps control panel for your domain.  In the Advanced tools Single sign-on section, upload mycert.cer as Verification certificate.

4.  Also in the Advanced tools Single Sign-On section, set the Sign-in page URL to http://localhost/GoogleAppsSso/Prompt.aspx.  The localhost URL is for testing.  Substitute your server's domain name after testing.

5.  Edit C:\projects\Google.Apps.SingleSignOn\web\Web.config and set the correct path for Google.Apps.SingleSignOn.PfxFile as created in step 1.


Testing the sample application
------------------------------

1.  Open a browser to Google Apps email http://mail.google.com/a/<your domain name>

2.  Verify that the browser redirects to the sample application  http://localhost/GoogleAppsSso/Prompt.aspx

3.  Enter a valid Google Apps username and any value for password.  (See below for customizing the authentication and authorization logic.)

4.  Verify that after you sign in you are able access Google Apps email.


Customizing authentication and authorization logic
--------------------------------------------------

Edit the Page_Load method in C:\projects\Google.Apps.SingleSignOn\web\SingleSignOn.aspx.cs to place restrictions on who can log in to Google Apps for this domain.  The sample application does not verify the credentials.

It may be helpful in development to view the SAML request, SAML response, and RelayState values.  To see this information, edit C:\projects\Google.Apps.SingleSignOn\web\Web.config and set the Google.Apps.SingleSignOn.Url to SingleSignOnDebug.aspx instead of SingleSignOn.aspx.


Acknowledgements
----------------

This sample application is derived from a more complete SSO/Provisioning application written by Bill Mers <bmers@ltech.com>.  We thank him for his contribution to this open-source project.


Bugs/Feedback
-------------

Join the Google Apps APIs group and let us know ways we can improve the sample code.

http://groups.google.com/group/google-apps-apis
