using System.Reflection;

[assembly: AssemblyDescription("Simplifies logging using log4net")]
[assembly: AssemblyCompany("Stugo Ltd")]
[assembly: AssemblyProduct("Stugo.Logging")]
[assembly: AssemblyCopyright("Copyright © Stugo Ltd 2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#else
[assembly: AssemblyConfiguration("RELEASE")]
#endif
