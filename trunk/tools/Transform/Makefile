# makefile for building Transform.exe

# are we running on linux?
ifeq ($(shell uname -o),Linux)
	CSC=mcs
	FLAGS=-g
else
	CSC=csc
	FLAGS=
endif


Transform.exe: Transform.cs AssemblyInfo.cs App.ico
	$(CSC) $(FLAGS) -r:System.Xml.dll -r:System.dll -out:$@ -target:exe $<

clean:
	rm *.exe

