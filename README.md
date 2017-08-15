This is README file for the GoppaTestingFraimwork package.

Author: Anahit


TESTING FRAMEWORK

The GoppaTestingFramwork is written for testing https://goppa.benivo.com web application.

USED TOOLS/LANGUAGES and TECNOLOGES

Microsoft Visual Studio 2017
C#
Selenium(v3.5.0)
NUnit framework(v3.7.1)
NUnit3 Test Adapter v3.8.0(allows to run NUnit tests inside Visual Studio)
GeckoDriver(Selenium IDE no longer supports the last versions of Firfox browser)
Tests are runing on latest Fierfox(v55.0.1)


All the methods using in test classes are defined in GoppaTestingFrameWork/src/Lib/BaseMethods.cs class.

The following test cases are implemented and placed under the GoppaTestingFrameWork/src/TestCases folder - LoginToGoppa.cs, SignUpToGoppa.cs, OpenContentInHomePage.cs

NOTE: There are only verifications for the login/signup and open functionality without checking pages content for the all cases.


