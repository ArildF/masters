# makefile for building thesis

TOOLS=../tools
DOCBOOK=$(TOOLS)/docbook-xsl
HTMLXSLT=$(TOOLS)/html-stylesheet.xsl
FOXSLT=$(TOOLS)/fo-stylesheet.xsl
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
	
all: html pdf fo ps

html: htmldir html/thesis.html
pdf: pdfdir pdf/thesis.pdf
fo: fodir fo/thesis.fo
ps: psdir ps/thesis.ps

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




