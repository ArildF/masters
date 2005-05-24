<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version='1.0'>

  <xsl:import href="docbook-xsl/fo/docbook.xsl"/>

  <xsl:param name="bibliography.numbered">1</xsl:param>
  <xsl:param name="fop.extensions" select="1" />
  <xsl:param name="variablelist.as.blocks" select="1" />
  <xsl:attribute-set name="monospace.verbatim.properties">
    <xsl:attribute name="wrap-option">wrap</xsl:attribute>
    <xsl:attribute name="hyphenation-character">\</xsl:attribute>
    <xsl:attribute name="font-size">11pt</xsl:attribute>
  </xsl:attribute-set>
  
  <xsl:attribute-set name="section.title.level1.properties">
    <xsl:attribute name="font-size">22pt</xsl:attribute>
  </xsl:attribute-set>
  
   <xsl:attribute-set name="section.title.level2.properties">
    <xsl:attribute name="font-size">18pt</xsl:attribute>
  </xsl:attribute-set>
  
   <xsl:attribute-set name="section.title.level3.properties">
    <xsl:attribute name="font-size">16pt</xsl:attribute>
  </xsl:attribute-set>
  
  <xsl:attribute-set name="section.title.level4.properties">
    <xsl:attribute name="font-size">14pt</xsl:attribute>
  </xsl:attribute-set>
  
</xsl:stylesheet>
