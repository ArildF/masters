# makefile for building thesis

TOOLS=../tools
DOCBOOK=$(TOOLS)/docbook-xsl
HTMLXSLT=$(TOOLS)/html-stylesheet.xsl
CHUNKEDHTMLXSLT=$(TOOLS)/chunk-stylesheet.xsl
FOXSLT=$(TOOLS)/fo-stylesheet.xsl
CSS=$(TOOLS)/styles.css
IMAGES=*.png
FOP=cmd.exe /c fop.bat

SOURCES=thesis.xml chapter_1.xml chapter_2.xml chapter_3.xml bibliography.xml \
    chapter_4.xml

# use xsltproc regardless, since Transform has problems with some of the sources
SUBMAKEFILE=Makefile.xsltproc

include $(SUBMAKEFILE)

showhtml: html
	-cp $(TOOLS)/styles.css $(CURDIR)/html
	$(BROWSER) $(CURDIR)/html/generics.html &
	
all: html pdf fo ps

html: htmldir html/thesis.html
chunked-html: chunked-htmldir chunked-html/index.html
pdf: pdfdir pdf/thesis.pdf
fo: fodir fo/thesis.fo
ps: psdir ps/thesis.ps

htmldir: 
	-mkdir html
	
chunked-htmldir:
	-mkdir chunked-html

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
	-rm -rf chunked-html




