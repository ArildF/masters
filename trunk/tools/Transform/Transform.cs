using System;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.IO;


namespace Transform
{
	/// <summary>
	/// Summary description for Transform.
	/// </summary>
	/// 

	public class Transform
	{
		public Transform()
		{
			
		}

        public static void Main( string[] args )
        {
            if ( args.Length < 1 )
            {
                PrintUsage();
                Environment.Exit( 0 );
            }

            Config config = new Config();

            ParseCommandline( args, config );

            try
            {

                XslTransform transform = new XslTransform();
            
                transform.Load( config.XslInputFile );
       
                XPathDocument doc = new XPathDocument( config.XmlInputFile );
                transform.Transform( doc, new XsltArgumentList(), config.Output ); 
            }
            catch( XmlException ex )
            {
                Console.Error.WriteLine( "Error encountered during XML parsing: ");
                ShowError( ex );
            }
            catch ( XsltException ex )
            {
                Console.Error.WriteLine( "Error encountered during XSL transformation: " );
                ShowError( ex );
            }
        }

        private static void ShowError( Exception ex )
        {
            Console.Error.WriteLine ( ex.Message );
            if ( ex.InnerException != null )
                ShowError( ex.InnerException );
        }


        /// <summary>
        /// parse the command line arguments
        /// </summary>
        /// <param name="args">an array containing the command line</param>
        /// <param name="config">an object that holds config information</param>
        private static void ParseCommandline( string[] args, Config config )
        {
            try
            {
                //want any help with this?
                if ( args[ 0 ] == "-?" || args[ 0 ] == "--help" )
                {
                    PrintUsage();
                    Environment.Exit( 0 );
                }

                //parse the arguments given
                int current = 0;
                while( current < args.Length )
                {
                    switch( args[ current ] )
                    {
                        case "-xml":
                            config.XmlInputFile = args[ ++current ];
                            break;
                        case "-xsl":                        
                            config.XslInputFile = args[ ++current ];
                            break;
                        case "-out":
                            config.Output = new StreamWriter( args[ ++current ] );
                            break;
                    }
                    ++current;
                }

                //make sure we got all the arguments
                if ( config.XmlInputFile == null )
                {
                    Console.Error.WriteLine( "XML file expected" );
                    Environment.Exit( 1 );
                }
                if ( config.XslInputFile == null )
                {
                    Console.Error.WriteLine( "XSL file expected" );
                    Environment.Exit( 1 );
                }


            }

            //apparently some error on the command line
            catch( IndexOutOfRangeException)
            {
                Console.Error.WriteLine( "Expected parameter" );
                System.Environment.Exit( 1 );
            }
        }

        /// <summary>
        /// print out usage info for the program
        /// </summary>
        private static void PrintUsage()
        {
            Console.WriteLine( @"XSL transform utility
Usage: transform -xml xmlfile -xsl xslfile [-out outfile]" );
        }


        private class Config
        {
            public TextWriter Output;
            public string XmlInputFile;
            public string XslInputFile;

            /// <summary>
            /// constructor defaults to using standard out for output
            /// </summary>
            public Config()
            {
                Output = Console.Out;
            }
        }
	}
}

