# makefile for building Transform.exe

# are we running on linux?
ifneq ($(shell uname -o),Cygwin)
	CSC=mcs
else
	CSC=csc
endif


Transform: Transform.cs AssemblyInfo.cs App.ico
	$(CSC) -r:System.Xml.dll -r:System.dll -out:$@ -target:exe $<

clean:
	rm *.exe

