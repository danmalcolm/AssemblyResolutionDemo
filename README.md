Introduction
------------

Microsoft .Net Framework demo. Uses the AppDomain.AssemblyResolve event to "redirect" to a different version of a referenced assembly at runtime.

A very simple demo written while researching an answer to this question on Stack Overflow:

http://stackoverflow.com/questions/24048277/can-i-have-my-assembly-reference-any-version-of-another-assembly


The main application App.exe references ThirdPartyLibrary version 2.0.0.0.

It also references MyLibrary, which references an older version of ThirdPartyLibrary version 1.0.0.0.

The AppDomain.AssemblyResolve event is used to redirect to the version used by the application when version 1.0.0.0 fails to load. Note that we need to bind to the event handler in advance of the assembly loading. 

How to Run
----------

Open the Visual Studio Solution AssemblyResolutionDemo.sln (compatible with Visual Studio 2012 and upwards).
Add a breakpoint somewhere within MyLibrary.MyUtil.ResolveThirdPartyLibrary so that you can see what is going on.
Set the App console app as your startup project and hit F5.
Try commenting out the call to MyUtil.Initialise in Program.cs and run the app again to see what would happen if we didn't resolve the missing assembly.

You don't need to open ThirdPartyLibrary.sln - this was used to build 2 different versions of ThirdPartyLibrary.dll.