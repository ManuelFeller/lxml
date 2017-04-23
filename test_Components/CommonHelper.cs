using System;
using System.Collections.Generic;
using System.Text;

namespace DDPro.Software.Net20.Tests
{
    /// <summary>/// Class for (static) Functions used by all tests...</summary>
    public class CommonHelper
    {
        /// <summary>Class to read String with Date-Value in Invariant Culture ( Example-Value: "11/30/2009 17:45:00" )</summary>
        public class clsIvCultureDate
        {

            /// <summary>convert a Date-String in Format of invariant Cultrure to Date</summary>
            /// <param name="DateValue">the String-Value to parse</param>
            /// <returns>the Date-Value if the String is in valid Format</returns>
            /// <exception cref="Exception">Thrown if the Value could not be converted to a Date - Details in Message-Text...</exception>
            public static DateTime Parse( string DateValue )
            {
                string _intDate = DateValue.Trim(); // remove spaces around
                short[] _singlevalues = { new short(), new short(), new short(), new short(), new short(), new short() };
                // 11/30/2009 17:00:00
                if( !_intDate.Contains( "/" ) )
                {
                    throw new Exception( "Data of Value \"" + DateValue + "\" does not match the Content of a Date-String in invariant Culture-Format (MM/dd/yyyy HH:mm:ss) ..." );
                }
                if( _intDate.Length == 19 ) // Lenght match
                {
                    // read values
                    _singlevalues[ 0 ] = short.Parse( _intDate.Substring( 0, 2 ) ); // get month
                    _singlevalues[ 1 ] = short.Parse( _intDate.Substring( 3, 2 ) ); // get day
                    _singlevalues[ 2 ] = short.Parse( _intDate.Substring( 6, 4 ) ); // get year
                    _singlevalues[ 3 ] = short.Parse( _intDate.Substring( 11, 2 ) ); // get hour
                    _singlevalues[ 4 ] = short.Parse( _intDate.Substring( 14, 2 ) ); // get minute
                    _singlevalues[ 5 ] = short.Parse( _intDate.Substring( 17, 2 ) ); // get second
                    // check values if valid
                    if( ( _singlevalues[ 0 ] < 1 ) || ( _singlevalues[ 0 ] > 12 ) )
                    {
                        throw new Exception( "Value \"" + _singlevalues[ 0 ].ToString() + "\" not valid as Month..." );
                    }
                    if( ( _singlevalues[ 1 ] < 1 ) || ( _singlevalues[ 1 ] > 31 ) )
                    {
                        throw new Exception( "Value \"" + _singlevalues[ 1 ].ToString() + "\" not valid as Day..." );
                    }
                    if( ( _singlevalues[ 2 ] < 1 ) || ( _singlevalues[ 2 ] > 2999 ) )
                    {
                        throw new Exception( "Value \"" + _singlevalues[ 2 ].ToString() + "\" not valid as Year..." );
                    }
                    if( ( _singlevalues[ 3 ] < 0 ) || ( _singlevalues[ 3 ] > 23 ) )
                    {
                        throw new Exception( "Value \"" + _singlevalues[ 3 ].ToString() + "\" not valid as Hour..." );
                    }
                    if( ( _singlevalues[ 4 ] < 0 ) || ( _singlevalues[ 4 ] > 59 ) )
                    {
                        throw new Exception( "Value \"" + _singlevalues[ 4 ].ToString() + "\" not valid as Minute..." );
                    }
                    if( ( _singlevalues[ 5 ] < 0 ) || ( _singlevalues[ 5 ] > 59 ) )
                    {
                        throw new Exception( "Value \"" + _singlevalues[ 5 ].ToString() + "\" not valid as Second..." );
                    }
                    // return new date from value
                    return new DateTime( _singlevalues[ 2 ], _singlevalues[ 0 ], _singlevalues[ 1 ], _singlevalues[ 3 ], _singlevalues[ 4 ], _singlevalues[ 5 ] );
                }
                else
                {
                    throw new Exception( "Length of Value \"" + DateValue + "\" does not Match Length of a Date-String in invariant Culture-Format (MM/dd/yyyy HH:mm:ss) ..." );
                }
            }

            /// <summary>try to convert a Date-String in Format of invariant Cultrure to Date</summary>
            /// <param name="DateValue">the String-Value to parse</param>
            /// <param name="result">Date-Object for the result</param>
            /// <returns>TRUE on success, FALSE on error</returns>
            public static bool TryParse( string DateValue, out DateTime result )
            {
                try
                {
                    result = Parse( DateValue );
                }
                catch( Exception )
                {
                    result = DateTime.Now;
                    return false;
                }
                return true;

            }

        }


    }
}
