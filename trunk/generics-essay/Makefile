# makefile for building generics essay

XSLT=../tools/docbook-xsl
HTMLXSLT=$(XSLT)/xhtml/docbook.xsl
FOXSLT=$(XSLT)/fo/docbook.xsl
FOP=cmd.exe /k fop.bat

# are we running on linux?
ifneq ($(shell uname -o),Cygwin)
	TRANSFORM=mono ../tools/Transform/Transform.exe
else
	TRANSFORM=../tools/Transform/Transform.exe
endif

html: htmldir html/generics.html
pdf: pdfdir pdf/generics.pdf
fo: fodir fo/generics.fo

htmldir: 
	-mkdir html

pdfdir:
	-mkdir pdf

fodir:
	-mkdir fo

clean:
	-rm -rf html
	-rm -rf fo


html/%.html: %.xml
	$(TRANSFORM) -xml $< -xsl $(HTMLXSLT) -out $@

fo/%.fo: %.xml
	$(TRANSFORM) -xml $< -xsl $(FOXSLT) -out $@

pdf/%.pdf: %.xml
	$(FOP) -xml $< -xsl $(FOXSLT) -out $@
