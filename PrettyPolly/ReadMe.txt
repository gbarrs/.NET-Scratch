All binaries have been removed from this solution as requested.

In order to compile the solution and run the tests you should copy nunit.framwork.dll into the ReferencedAssemblies folder (Product Version 2.5.1.9198 was used during the development of this solution). Alternatively, you could change the project references to point to a copy of the dll elsewhere on your local machine if you have it installed already.

If you don't have NUnit but would still like to run the application then you can remove the test projects (those with references to nunit.framework.dll) from the solution and then build and run the application.