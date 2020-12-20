/*
* Copyright 2008 - BitLaboratory
*
* Permission is hereby granted, free of charge, to any person obtaining a copy 
* of this software and associated documentation files (the "Software"), to 
* deal in the Software without restriction, including without limitation the
* rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
* sell copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE. 
 */
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Permissions;

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
#if BETA
	[assembly: AssemblyTitle("BitLaboratory.Windows.WizardFramework.v1.0 [Beta]")]
#else
[assembly: AssemblyTitle("BitLaboratory.Windows.WizardFramework.v1.0")]
#endif

[assembly: AssemblyDescription("Easy Wizard Framework")]

#if DEBUG
	[assembly: AssemblyConfiguration("Debug")]
#else
	[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyCompany("BitLaboratory")]
[assembly: AssemblyProduct("BitLaboratory.Windows.WizardFramework")]
[assembly: AssemblyCopyright("Copyright(c) 2004- BitLaboratory")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]		

[assembly: System.CLSCompliant(true)]		
[assembly: System.Security.AllowPartiallyTrustedCallers()]		 
[assembly: System.Runtime.InteropServices.ComVisible(false)]
[assembly: System.Security.SecurityRules(System.Security.SecurityRuleSet.Level1)]

[assembly: System.Resources.SatelliteContractVersion("1.0.0")]
 

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

#if DEBUG
	[assembly: AssemblyVersion("1.0.*")]
#else
	[assembly: AssemblyVersion("1.0.0")]
#endif                

//
// In order to sign your assembly you must specify a key to use. Refer to the 
// Microsoft .NET Framework documentation for more information on assembly signing.
//
// Use the attributes below to control which key is used for signing. 
//
// Notes: 
//   (*) If no key is specified, the assembly is not signed.
//   (*) KeyName refers to a key that has been installed in the Crypto Service
//       Provider (CSP) on your machine. KeyFile refers to a file which contains
//       a key.
//   (*) If the KeyFile and the KeyName values are both specified, the 
//       following processing occurs:
//       (1) If the KeyName can be found in the CSP, that key is used.
//       (2) If the KeyName does not exist and the KeyFile does exist, the key 
//           in the KeyFile is installed into the CSP and used.
//   (*) In order to create a KeyFile, you can use the sn.exe (Strong Name) utility.
//       When specifying the KeyFile, the location of the KeyFile should be
//       relative to the project output directory which is
//       %Project Directory%\obj\<configuration>. For example, if your KeyFile is
//       located in the project directory, you would specify the AssemblyKeyFile 
//       attribute as [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]
//   (*) Delay Signing is an advanced option - see the Microsoft .NET Framework
//       documentation for more information on this.
//


#if !DEBUG
	[assembly: AssemblyDelaySign(true)]
	[assembly: AssemblyKeyFile(@YOUR_KEY.snk")]
#else
	[assembly: AssemblyDelaySign(false)]
	[assembly: AssemblyKeyFile("")]
#endif

[assembly: AssemblyKeyName("")]
