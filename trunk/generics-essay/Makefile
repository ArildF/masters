# makefile for building generics essay

TOOLS=../tools
DOCBOOK=$(TOOLS)/docbook-xsl
HTMLXSLT=$(TOOLS)/html-stylesheet.xsl
FOXSLT=$(DOCBOOK)/fo/docbook.xsl
FOP=cmd.exe /k fop.bat


# are we running on linux?
ifneq ($(shell uname -o),Cygwin)
	SUBMAKEFILE=Makefile.xsltproc
	BROWSER=opera
else
	SUBMAKEFILE=Makefile.Transform
	BROWSER=opera
endif


include $(SUBMAKEFILE)

showhtml: html
	-cp $(TOOLS)/styles.css $(CURDIR)/html
	$(BROWSER) $(CURDIR)/html/generics.html &

html: htmldir html/generics.html
pdf: pdfdir pdf/generics.pdf
fo: fodir fo/generics.fo
ps: psdir ps/generics.ps

htmldir: 
	-mkdir html

pdfdir:
	-mkdir pdf

fodir:
	-mkdir fo

psdir:
	-mkdir ps


clean:
	-rm -rf html
	-rm -rf fo
	-rm -rf ps
	-rm -rf pdf




