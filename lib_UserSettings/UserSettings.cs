/*
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |  User-Settings Class   |   http://lxml.codeplex.com   |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace DDPro.Software.Net20.Library
{
    /// <summary>Class to Handle (User-)Settings</summary>
    public class UserSettings
    {

        // ToDo: find a way to enable saving of double.MaxValue with this Class...

        #region internal fields and objects

        /// <summary>internal reminder for the Path</summary>
        private string _filePath = "";
        /// <summary>internal reminder for the FileName</summary>
        private string _fileName = "";
        /// <summary>internal reminder fr the ThrowException-Setting</summary>
        /// <remarks>This supresses all exceptions that are regularly thrown by the Class</remarks>
        private bool _throwExceptions = true;

        private bool _initDone = false;
        /// <summary>internal XML-Document for the Data</summary>
        private System.Xml.XmlDocument _intXml = new System.Xml.XmlDocument();

        #endregion

        #region public objects and types

        /// <summary>Enumeration to define the Root-Directory of the Settings-File</summary>
        public enum RootFolder
        {
            /// <summary>local Application-Data of current User</summary>
            LocalAppData = 100,
            /// <summary>Application-Data of System</summary>
            CommonAppData = 200,
            /// <summary>MyDocuments of current User</summary>
            MyDocuments = 300
        }

        #endregion

        #region other properties

        /// <summary>get / set if the Class throws Exceptions or just returns false</summary>
        public bool ThrowExceptions
        {
            get
            {
                return _throwExceptions;
            }
            set
            {
                _throwExceptions = value;
            }
        }

        /// <summary>get the DLL-Version</summary>
        public System.Version DllVersion
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        #endregion 

        #region constructor (overloaded)

        /// <summary>create a new instance with Directory to use (FileName "user_set.xml")</summary>
        /// <param name="ToolPath">Name of Directory to use in LocalApplicationData - no "\" ("\\") at start or end needed...</param>
        public UserSettings(string ToolPath)
        {
            _createNew( ToolPath, "user_set.xml", RootFolder.LocalAppData );
        }

        /// <summary>create a new instance with Directory and RootDirectory to use (FileName "user_set.xml")</summary>
        /// <param name="ToolPath">Name of Directory to use in selected RootDirectory - no "\" ("\\") at start or end needed...</param>
        /// <param name="RootDir">The Root-Directory to use for Settings</param>
        public UserSettings( string ToolPath, RootFolder RootDir )
        {
            _createNew( ToolPath, "user_set.xml", RootDir );
        }

        /// <summary>create a new instance with Directory and File to use</summary>
        /// <param name="ToolPath">Name of Directory to use in LocalApplicationData - no "\" ("\\") at start or end needed...</param>
        /// <param name="FileName">Name for the Config-File to use</param>
        public UserSettings( string ToolPath, string FileName )
        {
            _createNew( ToolPath, FileName, RootFolder.LocalAppData );
        }

        /// <summary>create a new instance with Directory, File and RootDirectory to use</summary>
        /// <param name="ToolPath">Name of Directory to use in selected RootDirectory - no "\" ("\\") at start or end needed...</param>
        /// <param name="FileName">Name for the Config-File to use</param>
        /// <param name="RootDir">The RootDirectory to use for Settings</param>
        public UserSettings( string ToolPath, string FileName, RootFolder RootDir )
        {
            _createNew( ToolPath, FileName, RootDir );
        }

        #endregion

        #region file-handling

        /// <summary>clear all Settings in Memory</summary>
        public void InitializeConfig()
        {
            _initializeXML();
        }

        /// <summary>load the Configuration from File</summary>
        /// <returns>TRUE on success, FALSE on error</returns>
        public bool LoadConfig()
        {
            return _LoadFromFile();
        }

        /// <summary>save the Configuration to File</summary>
        /// <returns>TRUE on success, FALSE on error</returns>
        public bool SaveConfig()
        {
            return _SaveToFile();
        }

        /// <summary>delete the Configuration-File</summary>
        /// <returns>TRUE on success and if not present, FALSE on error</returns>
        public bool DeleteConfig()
        {
            return _DeleteConfigFile();
        }

        /// <summary>Is the configured file already existing?</summary>
        public bool ConfigFileExists
        {
            get
            {
                return System.IO.File.Exists( _filePath + "\\" + _fileName );
            }
        }

        /// <summary>the File-Path for the current Configuration-File</summary>
        public string ConfigFilePath
        {
            get
            {
                return _filePath + "\\" + _fileName;
            }
        }

        #endregion

        #region data-handling

        #region get / read value

        /// <summary>get a Value from the Configuration as String</summary>
        /// <param name="Name">the Name for the Value to get...</param>
        /// <param name="Default">Default-Value to return if not found / other error occured...</param>
        /// <returns>the requested Value - if existing (or the Default-Data) ...</returns>
        public string GetValue( string Name, string Default )
        {
            return _ReadValue( Name, Default );
        }

        /// <summary>get a Value from the Configuration as Boolean</summary>
        /// <param name="Name">the Name for the Value to get...</param>
        /// <param name="Default">Default-Value to return if not found / other error occured...</param>
        /// <returns>the requested Value - if existing (or the Default-Data) ...</returns>
        public bool GetValue( string Name, bool Default )
        {
            bool _res = Default;
            if( bool.TryParse( _ReadValue( Name, Default.ToString() ), out _res ) )
            {
                return _res;
            }
            else
            {
                return Default;
            }
        }

        /// <summary>get a Value from the Configuration as Integer</summary>
        /// <param name="Name">the Name for the Value to get...</param>
        /// <param name="Default">Default-Value to return if not found / other error occured...</param>
        /// <returns>the requested Value - if existing (or the Default-Data) ...</returns>
        public int GetValue( string Name, int Default )
        {
            int _res = Default;
            if( int.TryParse( _ReadValue( Name, Default.ToString() ), out _res ) )
            {
                return _res;
            }
            else
            {
                return Default;
            }
        }

        /// <summary>get a Value from the Configuration as Long</summary>
        /// <param name="Name">the Name for the Value to get...</param>
        /// <param name="Default">Default-Value to return if not found / other error occured...</param>
        /// <returns>the requested Value - if existing (or the Default-Data) ...</returns>
        public long GetValue( string Name, long Default )
        {
            long _res = Default;
            if( long.TryParse( _ReadValue( Name, Default.ToString() ), out _res ) )
            {
                return _res;
            }
            else
            {
                return Default;
            }
        }

        /// <summary>! BETA ! get a Value from the Configuration as Double</summary>
        /// <param name="Name">the Name for the Value to get...</param>
        /// <param name="Default">Default-Value to return if not found / other error occured...</param>
        /// <returns>the requested Value - if existing (or the Default-Data) ...</returns>
        /// <remarks><b>! BETA ! Can NOT handle MaxValue of Double, but smaller ones that can be saved without exponential notation...</b></remarks>
        public double GetValue( string Name, double Default )
        {
            double _res = Default;
            string _tmp = _ReadValue( Name, Default.ToString( System.Globalization.CultureInfo.InvariantCulture.NumberFormat ) );
            bool _wasEx = false;
            try
            {
                _res = double.Parse( _tmp, System.Globalization.CultureInfo.InvariantCulture.NumberFormat );
                
            }
            catch( Exception ) // invariant culture did not work
            {
                _wasEx = true;
            }



            if( _wasEx ) // first way did not work - try second
            {
                // try with exchange of thousands and decimal separators
                string _tmpVal = _tmp.Replace( System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator, "" ); // remove thousand-separator(s)
                _tmpVal = _tmpVal.Replace( ".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator ); // change decimal-spaparator
                if( double.TryParse( _tmpVal, out _res ) ) // try default
                {
                    return _res;
                }
                // third way
                try
                {
                    // get decimal-separator of current system and insert in string --> try to parse that
                    _res = double.Parse( _tmp, System.Globalization.NumberStyles.Any );
                }
                catch( Exception )
                {
                    _wasEx = true;
                }
            }



            
            
            
            
            
            
            
            
            // invariant culture worked
            return _res;
        }

        /// <summary>get a Value from the Configuration as DateTime</summary>
        /// <param name="Name">the Name for the Value to get...</param>
        /// <param name="Default">Default-Value to return if not found / other error occured...</param>
        /// <returns>the requested Value - if existing (or the Default-Data) ...</returns>
        public DateTime GetValue( string Name, DateTime Default )
        {
            DateTime _res = Default;
            string _tmp = _ReadValue( Name, Default.ToString() );
            if( clsIvCultureDate.TryParse( _tmp, out _res ) ) // TryParse of custom class worked
            {
                return _res;
            }
            else // TryParse of custom class did not work - try DateTime-Method...
            {
                if( DateTime.TryParse( _tmp, out _res ) ) // TryParse worked
                {
                    return _res;
                }
                else // TryParse failed
                {
                    return Default;
                }
            }
        }

        #endregion

        #region save / add value

        /// <summary>save a Value in Configuration-Data</summary>
        /// <param name="Name">the Name for the Value to save...</param>
        /// <param name="Value">the Value to save (String)</param>
        /// <returns>TRUE on success, FALSE on error</returns>
        public bool SaveValue( string Name, string Value )
        {
            return _SaveValue( Name, Value );
        }

        /// <summary>save a Value in Configuration-Data</summary>
        /// <param name="Name">the Name for the Value to save...</param>
        /// <param name="Value">the Value to save (String)</param>
        /// <returns>TRUE on success, FALSE on error</returns>
        public bool SaveValue( string Name, bool Value )
        {
            return _SaveValue( Name, Value.ToString() );
        }

        /// <summary>save a Value in Configuration-Data</summary>
        /// <param name="Name">the Name for the Value to save...</param>
        /// <param name="Value">the Value to save (String)</param>
        /// <returns>TRUE on success, FALSE on error</returns>
        public bool SaveValue( string Name, int Value )
        {
            return _SaveValue( Name, Value.ToString() );
        }

        /// <summary>save a Value in Configuration-Data</summary>
        /// <param name="Name">the Name for the Value to save...</param>
        /// <param name="Value">the Value to save (String)</param>
        /// <returns>TRUE on success, FALSE on error</returns>
        public bool SaveValue( string Name, long Value )
        {
            return _SaveValue( Name, Value.ToString() );
        }

        /// <summary>save a Value in Configuration-Data</summary>
        /// <param name="Name">the Name for the Value to save...</param>
        /// <param name="Value">the Value to save (String)</param>
        /// <returns>TRUE on success, FALSE on error</returns>
        public bool SaveValue( string Name, double Value )
        {
            return _SaveValue( Name, Value.ToString( System.Globalization.CultureInfo.InvariantCulture.NumberFormat ) );
        }

        /// <summary>save a Value in Configuration-Data</summary>
        /// <param name="Name">the Name for the Value to save...</param>
        /// <param name="Value">the Value to save (String)</param>
        /// <returns>TRUE on success, FALSE on error</returns>
        public bool SaveValue( string Name, DateTime Value )
        {
            return _SaveValue( Name, Value.ToString( System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat ) );
        }

        #endregion

        // delete value

        /// <summary>delete a Value from Configuration-Data</summary>
        /// <param name="Name">the Name for the Value to delete...</param>
        /// <returns>TRUE on success, FALSE on error</returns>
        public bool DeleteValue( string Name )
        {
            return _DeleteValue( Name );
        }

        #endregion

        #region implementation - internal worker

        /// <summary>init a new instance with Directory and File to use</summary>
        /// <param name="ToolPath">Name of Directory to use in selected Root-Directory - no "\" ("\\") at start or end needed...</param>
        /// <param name="FileName">Name for the Config-File to use</param>
        /// <param name="RootDir">The Root-Directory to use for Settings</param>
        private void _createNew( string ToolPath, string FileName, RootFolder RootDir )
        {
            if( ToolPath.Trim() == "" ) // check for sub-folder
            {
                _initDone = false;
                throw new Exception( "no valid subfolder (ToolPath) passed..." );
            }
            if( FileName.Trim() == "" ) // check for file-name
            {
                _initDone = false;
                throw new Exception( "no filename (FileName) passed..." );
            }
            string _root = "";
            switch( RootDir )
            {
                case RootFolder.LocalAppData:
                    _root = Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData );
                    break;
                case RootFolder.MyDocuments:
                    _root = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );
                    break;
                case RootFolder.CommonAppData:
                    _root = Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData );
                    break;
            }

            _filePath = _root + "\\" + ToolPath;
            _fileName = FileName;
            // check path (is valid path - not if file exists) - else throw exception
            string _check = "";
            try
            {
                _check = System.IO.Path.GetFullPath( _filePath + "\\" + _fileName );
            }
            catch( Exception ex )
            {
                _initDone = false;
                throw new Exception( "no valid file-path configured...", ex );
            }
            // init internal XmlDocument
            _initializeXML();
            _initDone = true;
        }

        /// <summary>prepare internal XmlDocument with basic Document-Root</summary>
        private void _initializeXML()
        {
            System.Xml.XmlDocument _tmpdoc = new System.Xml.XmlDocument();
            System.Xml.XmlDeclaration _tmpdec = _tmpdoc.CreateXmlDeclaration( "1.0", "UTF-8", "yes" );
            System.Xml.XmlElement _tmproot = _tmpdoc.CreateElement( "UserSettings" );
            _tmpdoc.AppendChild( _tmpdec );
            _tmpdoc.AppendChild( _tmproot );
            _intXml = _tmpdoc;
        }

        /// <summary>read a Value from Data</summary>
        /// <returns>the Value if found or passed Default</returns>
        private string _ReadValue(string Name, string Default)
        {
            if( !_CheckForInit() )
                return Default;
            // <Setting Name="" Value="" />
            System.Xml.XmlElement _docRoot = _intXml[ "UserSettings" ];
            if( _docRoot == null ) // no root found
            {
                return Default;
            }
            if(! _docRoot.HasChildNodes ) // there are no elements inside
            {
                return Default;
            }
            // check the content
            foreach( System.Xml.XmlElement _xElement in _docRoot.ChildNodes )
            {
                if( _xElement.Name == "Setting" )
                {
                    if( _xElement.GetAttribute( "Name" ) == Name )
                    {
                        return _xElement.GetAttribute( "Value" );
                    }
                }
            }

            return Default; 
        }

        /// <summary>save a (new) Value to the Settings</summary>
        /// <param name="Name">Name for the Value (unique)</param>
        /// <param name="Value">Content for the Value</param>
        /// <returns>TRUE on success</returns>
        private bool _SaveValue( string Name, string Value )
        {
            if( !_CheckForInit() )
                return false;
            // <Setting Name="" Value="" />
            System.Xml.XmlElement _docRoot = _intXml[ "UserSettings" ];
            bool _create = true;
            if( _docRoot == null ) // no root found
            {
                _initializeXML();
                _docRoot = _intXml[ "UserSettings" ];
            }
            else
            {
                if( _docRoot.HasChildNodes ) // there are elements inside
                {
                    foreach( System.Xml.XmlElement _xElement in _docRoot.ChildNodes )
                    {
                        if( _xElement.Name == "Setting" )
                        {
                            if( _xElement.GetAttribute( "Name" ) == Name )
                            {
                                _xElement.SetAttribute( "Value", Value );
                                _create = false;
                                break;
                            }
                        }
                    }
                }
            }
            
            // must be created
            if( _create )
            {
                System.Xml.XmlElement _newElement = _intXml.CreateElement( "Setting" );
                _newElement.SetAttribute( "Name", Name );
                _newElement.SetAttribute( "Value", Value );
                _docRoot.AppendChild( _newElement );
            }
            return true;
        }

        /// <summary>delete a Value from Configuration-Data</summary>
        /// <param name="Name">the Name for the Value to delete...</param>
        /// <returns>TRUE on success, FALSE on error</returns>
        private bool _DeleteValue( string Name)
        {
            if( !_CheckForInit() )
                return false;
            // <Setting Name="" Value="" />
            System.Xml.XmlElement _docRoot = _intXml[ "UserSettings" ];
            if( _docRoot == null ) // no root found
            {
                return false;
            }
            if( !_docRoot.HasChildNodes ) // there are no elements inside
            {
                return false;
            }
            // check the content for item
            System.Xml.XmlElement _delItem = null;
            foreach( System.Xml.XmlElement _xElement in _docRoot.ChildNodes )
            {
                if( _xElement.Name == "Setting" )
                {
                    if( _xElement.GetAttribute( "Name" ) == Name )
                    {
                        _delItem = _xElement;
                        break;
                    }
                }
            }
            if( _delItem != null ) // item found
            {
                try
                {
                    _docRoot.RemoveChild( _delItem );
                }
                catch( Exception ex)
                {
                    if( _throwExceptions )
                    {
                        throw new Exception( "Could not delete XML-Node...", ex );
                    }
                    else
                    {
                        return false;
                    }
                    
                }
                return true; // all ok - deleted
            }
            else // not found
            {
                return false;
            }
        }

        private bool _LoadFromFile()
        {
            if( !_CheckForInit() )
                return false;
            if( System.IO.File.Exists( _filePath + "\\" + _fileName ) )
            {
                try
                {
                    _intXml.Load( _filePath + "\\" + _fileName );
                }
                catch( Exception ex )
                {
                    if( _throwExceptions )
                    {
                        throw new Exception( "Could not load Config-XML-File...", ex );
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool _SaveToFile()
        {
            if( !_CheckForInit() )
                return false;
            if( !System.IO.Directory.Exists( _filePath ) ) // Directory is not present
            {
                try
                {
                    System.IO.Directory.CreateDirectory( _filePath );
                }
                catch( Exception ex )
                {
                    if( _throwExceptions )
                    {
                        throw new Exception( "Could not create Directory for Config-XML-File...", ex );
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            // directory present or created
            try
            {
                _intXml.Save( _filePath + "\\" + _fileName ); // try to save
            }
            catch( Exception ex )
            {
                if( _throwExceptions )
                {
                    throw new Exception( "Could not save Config-XML-File...", ex );
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
 
        private bool _DeleteConfigFile()
        {
            if( !_CheckForInit() )
                return false;
            if( System.IO.File.Exists( _filePath + "\\" + _fileName ) )
            {
                try
                {
                    System.IO.File.Delete( _filePath + "\\" + _fileName );
                }
                catch( Exception ex )
                {
                    if( _throwExceptions )
                    {
                        throw new Exception( "Could not delete Config-XML-File...", ex );
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
 
        private bool _CheckForInit()
        {
            if( !_initDone ) // Class not initialized correctly
            {
                if( _throwExceptions )
                {
                    throw new Exception( "Error during Class Initialize" );
                }
                return false;
            }
            return true;
        }

        #endregion 

    }
}