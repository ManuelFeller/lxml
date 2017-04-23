/*
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |  User-List-XML Class   |   http://lxml.codeplex.com   |
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
using System.Data;

namespace DDPro.Software.Net20.Library
{
    /// <summary>Class to Handle a User-List for Applications in ciphered XML</summary>
    /// <remarks>CUX = ciphered User XML --> needs Rijndael.dll</remarks>
    public class UserList
    {

        #region public Objects and Structures

        /// <summary>
        /// Class for the complete User-Data
        /// </summary>
        public class UserData
        {
            /// <summary>
            /// the User-ID (auto-generated)
            /// </summary>
            public int ID;
            /// <summary>
            /// the Username (optional if not Index)
            /// </summary>
            public string Username;
            /// <summary>
            /// the Password for the User (optional)
            /// </summary>
            public string Password;
            /// <summary>
            /// the First name of the User (optional)
            /// </summary>
            public string FirstName;
            /// <summary>
            /// Last Name of the User (optional)
            /// </summary>
            public string LastName;
            /// <summary>
            /// the NT-User for the User (optional if not Index)
            /// </summary>
            public string NT_User;

            /// <summary>
            /// create e new instance
            /// </summary>
            public UserData()
            {
                ID = -1;
                Username = "";
                Password = "";
                FirstName = "";
                LastName = "";
                NT_User = "";
            }
        }

        /// <summary>
        /// Class for the basic User-Data
        /// </summary>
        public class UserInfo
        {
            /// <summary>
            /// the User-ID
            /// </summary>
            public int ID;
            /// <summary>
            /// the Username
            /// </summary>
            public string Username;
            /// <summary>
            /// the NT-User for the User
            /// </summary>
            public string NT_User;

            /// <summary>
            /// create e new instance
            /// </summary>
            public UserInfo()
            {
                ID = -1;
                Username = "";
                NT_User = "";
            }
        
        }

        /// <summary>
        /// enumeration to Define the Index-Column to use (unique)
        /// </summary>
        public enum IndexColumn
        {
            /// <summary>
            /// only AutoID
            /// </summary>
            None = 0,
            /// <summary>
            /// AutoID and Username Column
            /// </summary>
            Username = 100,
            /// <summary>
            /// AutoID and NT-User Column
            /// </summary>
            NT_User = 200,
            /// <summary>
            /// AutoID, Username and NT-User Column
            /// </summary>
            UserAndNT = 300
        }

        #endregion

        #region internal Objects and Fields

        /// <summary>
        /// internal DataSet
        /// </summary>
        private DataSet _int_DataSet;

        /// <summary>
        /// internal reminder for the Path to the DataFile
        /// </summary>
        private string _int_Path;

        /// <summary>
        /// non-public reminder for the Index-Mode that is in Use
        /// </summary>
        private IndexColumn _set_IdxMode;

        /// <summary>
        /// Version of current File
        /// </summary>
        private string _set_Version;

        /// <summary>
        /// internal reminder for the CipherPhrase
        /// </summary>
        private string _set_DataCipherPhrase = "LaNgua93-XmL&U5ErLi$t_Pa5$pHra53";

        #endregion

        #region Properties
/*
        // USE THIS CODE ONLY FOR DEBUG !!! ELSE ALL PASSWORDS CAN BE READ !!!
        /// <summary>
        /// get / set the internal DataSet used to handle the Data
        /// </summary>
        public DataSet DEBUG_FullData
        {
            get
            {
                return _int_DataSet.Copy();
            }
            set
            {
                _int_DataSet = value.Copy();
            }
        }
*/

        /// <summary>
        /// has the internal UserData unsaved changes?
        /// </summary>
        public bool HasChanges
        {
            get
            {
                return _int_DataSet.HasChanges();
            }
        }

        /// <summary>
        /// get / set the Data-File to use (full path to .cux-File)
        /// </summary>
        public string File
        {
            get
            {
                return _int_Path.ToString();
            }
            set
            {
                _int_Path = value.ToString();
            }
        }

        /// <summary>
        /// set a new CipherPhrase for Data-Encryption - use only if you know what you are doing!
        /// </summary>
        /// <remarks>Using a diffrent CipherPhrase will result in unreadable Files for all Applications that use the Library with default-CipherPhrase. Use this only if you plan to create a new "infrastucture" / "subnet" within the existing one(s)...</remarks>
        public string NewCipherPhrase
        {
            set
            {
                _set_DataCipherPhrase = value;
            }
        }

        /// <summary>
        /// get the DLL-Version
        /// </summary>
        public System.Version DllVersion
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        /// <summary>
        /// get the File-Version
        /// </summary>
        public string FileVersion
        {
            get
            {
                if( _set_Version != "" )
                {
                    return _set_Version;
                }
                else
                {
                    return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
                }
                
            }
        }

        /// <summary>
        /// get the Index-Mode for the current Instance / File
        /// </summary>
        public IndexColumn FileIndex
        {
            get
            {
                return _set_IdxMode;
            }
        }

        #endregion

        #region overloaded constructor

        /// <summary>
        /// initialize a new Instance with Username as Index
        /// </summary>
        public UserList()
        {
            _initializeDataSet(IndexColumn.Username);
            _int_Path = "";
            _set_Version = "";
        }

        /// <summary>
        /// initialize a new Instance with defined Index
        /// </summary>
        /// <param name="Index">the IndexColumn to use for this Instance</param>
        public UserList( IndexColumn Index )
        {
            _initializeDataSet( Index );
            _int_Path = "";
            _set_Version = "";
        }

        /// <summary>
        /// initialize a new Instance including Path and Username as Index
        /// </summary>
        /// <param name="File">full Path to the .cux-File to use</param>
        public UserList(string File)
        {
            _initializeDataSet( IndexColumn.Username );
            _int_Path = File;
            _set_Version = "";
        }

        /// <summary>
        /// initialize a new Instance including defined Index and Path
        /// </summary>
        /// <param name="Index">the IndexColumn to use for this Instance</param>
        /// <param name="File">full Path to the .cux-File to use</param>
        public UserList( IndexColumn Index, string File )
        {
            _initializeDataSet( Index );
            _int_Path = File;
            _set_Version = "";
        }

        #endregion

        #region public Methods and Functions

        // basic Load / Save
        /// <summary>
        /// (initial) load Data from File / DataSource
        /// </summary>
        /// <returns>TRUE on success, FALSE on error</returns>
        public bool Load()
        {
            return _loadData( _int_Path );
        }
        /// <summary>
        /// (initial) load Data from File, optional without changing the internal FileName
        /// </summary>
        /// <param name="FileName">the Full path to the .cux-File</param>
        /// <param name="NoInternalChange">set TRUE to keep class-internal FileName unchanged</param>
        /// <returns>TRUE on success, FALSE on error</returns>
        public bool Load( string FileName, bool NoInternalChange )
        {
            if( !NoInternalChange ) // change Filename if not set to keep it unchanged
            {
                _int_Path = FileName;
            }
            return _loadData( FileName );
        }

        /// <summary>
        /// save Data to File
        /// </summary>
        /// <returns>TRUE on success, FALSE on error</returns>
        public bool Save()
        {
            return _SaveToFile( _int_Path, _set_Version );
        }
        /// <summary>
        /// save Data to defined File, optional without changing the internal FileName
        /// </summary>
        /// <param name="FileName">the Full path for the .cux-File</param>
        /// <param name="NoInternalChange">set TRUE to keep class-internal FileName unchanged</param>
        /// <returns>TRUE on success, FALSE on error</returns>
        public bool Save(string FileName, bool NoInternalChange)
        {
            if( !NoInternalChange ) // change Filename if not set to keep it unchanged
            {
                _int_Path = FileName;
            }
            return _SaveToFile( FileName, _set_Version );
        }

        // user-handling

        /// <summary>
        /// get the Users in current Data
        /// </summary>
        /// <returns>List of UserInfo-Elements</returns>
        public List<UserInfo> GetUsers()
        {
            return _GetUsers();
        }

        /// <summary>
        /// add a new User to current Data
        /// </summary>
        /// <param name="NewUser">User-Object containing the Data for new User - ID is ignored</param>
        /// <returns>ID for new User on success or -1 on error</returns>
        public int AddUser(UserData NewUser)
        {
            return _AddUser( NewUser );
        }
        /// <summary>
        /// edit / update User in current Data
        /// </summary>
        /// <param name="User">>User-Object containing the Data for User</param>
        /// <returns>TRUE on success, FALSE on error</returns>
        public bool EditUser( UserData User )
        {
            return _EditUser( User );
        }
        /// <summary>
        /// delete a User from current Data
        /// </summary>
        /// <param name="UserID">User-ID to use for the "request"</param>
        /// <returns>TRUE if deleted, FALSE on error</returns>
        public bool DeleteUser( int UserID )
        {
            return _DeleteUser( UserID );
        }
 
        // get User-Data
        /// <summary>
        /// get the first name for a User-ID
        /// </summary>
        /// <param name="ID">User-ID to use for the "request"</param>
        /// <returns>the FirstName for the User or null / nothing if not found</returns>
        public String GetUserFirstName( int ID )
        {
            return _GetUserField( ID, "f_name" );
        }
        /// <summary>
        /// get the last name for a User-ID
        /// </summary>
        /// <param name="ID">User-ID to use for the "request"</param>
        /// <returns>the LastName for the User or null / nothing if not found</returns>
        public String GetUserLastName( int ID )
        {
            return _GetUserField( ID, "l_name" );
        }
        /// <summary>
        /// get the Username for a User-ID
        /// </summary>
        /// <param name="ID">User-ID to use for the "request"</param>
        /// <returns>the Username for the User or null / nothing if not found</returns>
        public String GetUserName( int ID )
        {
            return _GetUserField( ID, "u_name" );
        }
        /// <summary>
        /// get the NT-User for a User-ID
        /// </summary>
        /// <param name="ID">User-ID to use for the "request"</param>
        /// <returns>the NT-User for the User or null / nothing if not found</returns>
        public String GetUserNtName( int ID )
        {
            return _GetUserField( ID, "nt_name" );
        }

        // validate User-Password
        /// <summary>
        /// validate the Password for a User-ID
        /// </summary>
        /// <param name="ID">User-ID to use for the "request"</param>
        /// <param name="Password">the Password to validate</param>
        /// <returns>TRUE if Password is OK, FALSE on error (no match)</returns>
        public bool CheckUserPassword( int ID, string Password )
        {
            return _CheckUserPassword( ID, Password );
        }

        #endregion

        #region inner worker (implementation)

        /// <summary>
        /// initialize the internal DataSet for the Class
        /// </summary>
        /// <param name="Index">the Index-Column(s) to use (set to unique)</param>
        private void _initializeDataSet(IndexColumn Index)
        {
            // save internal Index-Mode
            _set_IdxMode = Index;
            // basic DataSet
            DataSet _tds = new DataSet("UserNameList"); // internal DataSet
            // Table-Defninition
            DataTable _tabUsr = new DataTable( "UserData" ); // internal Table for Users

            // Column-Definition for basic User-Table
            // ======================================
            //
            // AutoID-Column (always Index)
            DataColumn _col1 = new DataColumn( "colID", System.Type.GetType("System.Int32") );
            _col1.AutoIncrement = true;
            _col1.AutoIncrementSeed = 0;
            _col1.AutoIncrementStep = 1 ;
            _col1.Unique = true;
            _col1.ReadOnly = true;
            _col1.AllowDBNull = true;
            // other Base-Data:
            // ================
            //
            // Display-Name / Username
            DataColumn _col2 = new DataColumn( "colUsername", System.Type.GetType( "System.String" ) );
            if( (Index == IndexColumn.Username) || (Index == IndexColumn.UserAndNT) )
            {
                _col2.Unique = true;
            }
            // Password for User
            DataColumn _col3 = new DataColumn( "colPassword", System.Type.GetType( "System.String" ) );
            // User full Name
            DataColumn _col4 = new DataColumn( "colFirstName", System.Type.GetType( "System.String" ) );
            DataColumn _col5 = new DataColumn( "colLastName", System.Type.GetType( "System.String" ) );
            // NT-Username of User (unique)
            DataColumn _col6 = new DataColumn( "colNtUser", System.Type.GetType( "System.String" ) );
            if( ( Index == IndexColumn.NT_User ) || ( Index == IndexColumn.UserAndNT ) )
            {
                _col6.Unique = true;
            }
            //
            // add Columns to Table
            _tabUsr.Columns.Add( _col1 );
            _tabUsr.Columns.Add( _col2 );
            _tabUsr.Columns.Add( _col3 );
            _tabUsr.Columns.Add( _col4 );
            _tabUsr.Columns.Add( _col5 );
            _tabUsr.Columns.Add( _col6 );
            // add Table to DataSet
            _tds.Tables.Add( _tabUsr );
            // Save DataSet to internal Object
            _int_DataSet = _tds;
            _int_DataSet.AcceptChanges();
        }

        #region User-Handling

        /// <summary>
        /// get the Users in current Data
        /// </summary>
        /// <returns>List of UserInfo-Elements</returns>
        private List<UserInfo> _GetUsers()
        {
            // create public List of all Users
            List<UserInfo> _intList = new List<UserInfo>();
            UserInfo _tmpObject;
            foreach( DataRow _row in _int_DataSet.Tables[ "UserData" ].Rows )
            {
                if( _row.RowState != DataRowState.Deleted && _row.RowState != DataRowState.Detached )
                {
                    _tmpObject = new UserInfo();
                    _tmpObject.ID = int.Parse( _row[ "colID" ].ToString() );
                    _tmpObject.Username = _row[ "colUsername" ].ToString();
                    _tmpObject.NT_User = _row[ "colNtUser" ].ToString();
                    _intList.Add( _tmpObject );
                }
            }
            return _intList;
        }

        /// <summary>
        /// add a new User to the current Data
        /// </summary>
        /// <param name="_NewUser">User-Object containing the Data for new User - ID is ignored</param>
        /// <returns>ID for new User on success or -1 on error</returns>
        private int _AddUser( UserData _NewUser )
        {
            DataRow _newRow = _int_DataSet.Tables[ "UserData" ].NewRow();
            _newRow.BeginEdit();
            _newRow[ "colUsername" ] = _NewUser.Username.ToLower(); // lower case only 
            _newRow[ "colPassword" ] = _NewUser.Password;
            _newRow[ "colFirstName" ] = _NewUser.FirstName;
            _newRow[ "colLastName" ] = _NewUser.LastName;
            _newRow[ "colNtUser" ] = _NewUser.NT_User.ToLower(); // lower case only
            _newRow.EndEdit();

            try
            {
                _int_DataSet.Tables[ "UserData" ].Rows.Add( _newRow );
            }
            catch( Exception )
            {
                // return error
                return -1;
            }

            // return id of new user
            return int.Parse( _newRow[ "colID" ].ToString() );
        }

        /// <summary>
        /// edit / update User in current Data
        /// </summary>
        /// <param name="_User">>User-Object containing the Data for User</param>
        /// <returns>TRUE on success, FALSE on error</returns>
        private bool _EditUser( UserData _User )
        {
            // find row in Table
            foreach( DataRow _row in _int_DataSet.Tables[ "UserData" ].Rows )
            {
                if( _row.RowState != DataRowState.Deleted && _row.RowState != DataRowState.Detached )
                {
                    if( _row[ "colID" ].ToString() == _User.ID.ToString() )
                    {
                        // found User in Table - update Data

                        // possible index one: Username
                        string _tmpRollBack = _row[ "colUsername" ].ToString(); // save old value for rollback
                        try
                        {
                            _row[ "colUsername" ] = _User.Username.ToLower(); // apply - lower case only 

                        }
                        catch( Exception )
                        {
                            return false;
                        }

                        // possible index two: NT-User
                        try
                        {
                            _row[ "colNtUser" ] = _User.NT_User.ToLower(); // lower case only
                        }
                        catch( Exception )
                        {
                            _row[ "colUsername" ] = _tmpRollBack; // reset username on error
                            return false;
                        }
                        // no error on index, save optionals
                        _row[ "colFirstName" ] = _User.FirstName;
                        _row[ "colLastName" ] = _User.LastName;
                        // password-handling:
                        if( _User.Password == null ) // Password is null / nothing --> delete current
                        {
                            _row[ "colPassword" ] = "";
                        }
                        else // passsword is not null / nothing
                        {
                            if( _User.Password != "" ) // Password set to something else then ""
                            {
                                _row[ "colPassword" ] = _User.Password; // add new Password to data
                            }
                        }

                        return true;
                    }
                }
            }
            // not found
            return false;
        }

        /// <summary>
        /// delete a User from current Data
        /// </summary>
        /// <param name="UserID">User-ID to use for the "request"</param>
        /// <returns>TRUE if deleted, FALSE on error</returns>
        private bool _DeleteUser( int UserID )
        {
            // internal reminder for DataRow
            DataRow _tmp = _int_DataSet.Tables[ "UserData" ].NewRow();
            bool _found = false;
            // find row in Table
            foreach( DataRow _row in _int_DataSet.Tables[ "UserData" ].Rows )
            {
                if( _row.RowState != DataRowState.Deleted && _row.RowState != DataRowState.Detached )
                {
                    if( _row[ "colID" ].ToString() == UserID.ToString() )
                    {
                        _tmp = _row;
                        _found = true;
                    }
                }
            }
            if( _found )
            {
                try
                {
                    _tmp.Delete();
                }
                catch (Exception)
                {
                    return false; // error
                }
                return true; // success
            }
            return false; // no found
        }
 
        /// <summary>
        /// get the first name for a User-ID
        /// </summary>
        /// <param name="ID">User-ID to use for the "request"</param>
        /// <param name="FieldName">the name Field to return (u_name [default], nt_name, f_name, l_name)</param>
        /// <returns>the Field-Value for the User as String or null / nothing if not found</returns>
        private String _GetUserField( int ID, string FieldName )
        {
            // get Column-Name
            string _intCol = "colUsername"; // uername by default
            switch( FieldName.ToLower() )
            {
                case "f_name": // first name
                    _intCol = "colFirstName";
                    break;
                case "l_name": // last name
                    _intCol = "colLastName";
                    break;
                case "nt_name": // nt-user
                    _intCol = "colNtUser";
                    break;
            }
            // search user-id
            foreach( DataRow _row in _int_DataSet.Tables[ "UserData" ].Rows )
            {
                if( _row.RowState != DataRowState.Deleted && _row.RowState != DataRowState.Detached )
                {
                    if( _row[ "colID" ].ToString() == ID.ToString() )
                    {
                        // found User in Table - return data-field as string
                        return _row[ _intCol ].ToString();
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// validate the Password for a User-ID
        /// </summary>
        /// <param name="ID">User-ID to use for the "request"</param>
        /// <param name="Password">the Password to validate</param>
        /// <returns>TRUE if Password is OK, FALSE on error (no match)</returns>
        private bool _CheckUserPassword( int ID, string Password )
        {
            foreach( DataRow _row in _int_DataSet.Tables[ "UserData" ].Rows )
            {
                if( _row.RowState != DataRowState.Deleted && _row.RowState != DataRowState.Detached )
                {
                    if( _row[ "colID" ].ToString() == ID.ToString() )
                    {
                        // found User in Table - check for Password-Match
                        if( _row[ "colPassword" ].ToString() == Password )
                        {
                            return true; // match
                        }
                        else
                        {
                            return false; // no match
                        }
                    }
                }
            }
            return false; // no match if user is not found
        }

        #endregion

        #region File-Handling

        /// <summary>
        /// save Data to File
        /// </summary>
        /// <param name="FileName">the FileName to use for save</param>
        /// <param name="FileVersion">optional File-Version to apply - use "" to apply DLL-Version</param>
        /// <returns>TRUE on success, FALSE on error</returns>
        private bool _SaveToFile( string FileName, string FileVersion )
        {
            // something set in FileName? Exit if not...
            if( FileName.Trim() == "" )
            {
                return false;
            }
            DDPro.Software.Net20.Library.Rijndael _cipher = new DDPro.Software.Net20.Library.Rijndael( System.Text.Encoding.UTF8 );
            // get dataset-data
            string _innerXML = _int_DataSet.GetXml();
            StringBuilder _FileCont = new StringBuilder();
            _FileCont.AppendLine( "CUX = Ciphered User XML" );
            // set File-Version by Assembly-Number
            if( FileVersion == "" ) // no Version specified - use DLL-Version
            {
                _FileCont.AppendLine( "Version = " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString() );
            }
            else // Version is specified
            {
                _FileCont.AppendLine( "Version = " + FileVersion );
            }
            _FileCont.AppendLine( "Index = " + _set_IdxMode.ToString() ); // specify used index
            _FileCont.AppendLine( "-| start |-" ); // set StartData-Tag
            // start Data-Block
            string _cDat = _cipher.EasyEncrypt( _innerXML, _set_DataCipherPhrase );
            // add linebreak every 60 signs in Data
            long _strLen = _cDat.Length;
            double _runCycles = ( _strLen / 60 );
            int _runs = Convert.ToInt32( Math.Floor(_runCycles) );
            for( long i = 0; i <= _runs; i++ )
            {
                if( ( i * 60 ) > int.MaxValue ) // if not "runable" cycle
                {
                    return false; // exit on too many cycles
                }
                if( i == _runs ) // last cycle - take the rest
                {
                    _FileCont.AppendLine( _cDat.Substring( Convert.ToInt32( i * 60 ) ) ); // add 60 signs 
                }
                else // regular cycle - write 60 signs
                {
                    _FileCont.AppendLine( _cDat.Substring( Convert.ToInt32( i * 60 ), 60 ) ); // add 60 signs 
                }
            }
            // end Data-Block
            _FileCont.AppendLine( "-| end |-" );
            // _FileCont.AppendLine( "" ); // 4 debug
            // _FileCont.AppendLine( _cDat ); // 4 debug
            // write data to file
            if( !_fileWriter( FileName, _FileCont.ToString() ) )
            {
                return false;
            }
            // everything has worked, data is saved 
            _int_DataSet.AcceptChanges(); // remind save
            return true;
        }

        /// <summary>
        /// save sata to File
        /// </summary>
        /// <param name="_FileName">Name for the File</param>
        /// <param name="_Content">Content for the File as String</param>
        /// <returns>TRUE if saved, FALSE on error</returns>
        private bool _fileWriter( string _FileName, string _Content )
        {
            // delete old temp
            if( System.IO.File.Exists( _FileName + ".tmp" ) )
            {
                try
                {
                    System.IO.File.Delete( _FileName + ".tmp" );
                }
                catch( Exception )
                {
                    return false;
                }
            }
            // save new temp
            try
            {
                //System.IO.File.WriteAllText( FileName, _fContent, System.Text.Encoding.UTF8 );
                System.IO.File.WriteAllText( _FileName + ".tmp", _Content, System.Text.Encoding.UTF8 );
            }
            catch( Exception )
            {
                return false;
            }
            // delete old file
            if( System.IO.File.Exists( _FileName ) )
            {
                try
                {
                    System.IO.File.Delete( _FileName );
                }
                catch( Exception )
                {
                    return false;
                }

            }
            // move new file
            try
            {
                System.IO.File.Move( _FileName + ".tmp", _FileName ); // rename to final name
            }
            catch( Exception )
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// (initial) load Data from File / DataSource
        /// </summary>
        /// <returns>TRUE on success, FALSE on error</returns>
        private bool _loadData( string FileName )
        {
            // something set in FileName? Exit if not...
            if( FileName.Trim() == "" )
            {
                return false;
            }
            // read Data from file
            string _fileContent;
            try
            {
                _fileContent = System.IO.File.ReadAllText( FileName, System.Text.Encoding.UTF8 );
            }
            catch (Exception)
            {
                return false;
            }
            // read Data from file
            StringBuilder _cData = new StringBuilder(); // Element for ciphered Data
            IndexColumn _fIndex = IndexColumn.Username; // Username as Default-index
            _set_Version = ""; // init with default-version
            // split into lines
            string[] _lines = _fileContent.Split( Environment.NewLine.ToCharArray() );
            // cleanup empty lines
            List<string> _cleaned = new List<string>();
            foreach( string _rawLine in _lines )
            {
                if( _rawLine.Trim() != "" )
                {
                    _cleaned.Add( _rawLine );
                }
            }
            // check Version
            bool _dataActive = false; // reminder for active data-block
            foreach( string _line in _cleaned )
            {
                // detect headline
                if( _line.Trim().ToLower().StartsWith( "cux" ) )
                {
                    // nothing for the moment...
                }
                // detect version
                if( _line.Trim().ToLower().StartsWith( "version" ) )
                {
                    if( !_CheckFileVersion( _line.Trim() ) ) // if invalid version
                    {
                        return false; // exit
                    }
                }
                // detect index
                if( _line.Trim().ToLower().StartsWith( "index" ) )
                {
                    _fIndex = _GetFileIndex( _line.Trim() );
                }

                // detect end
                if( _line.Trim().ToLower() == "-| end |-" )
                {
                    _dataActive = false;
                }
                // save data if active
                if( _dataActive )
                {
                    _cData.Append( _line.Trim() );
                }
                // detect start
                if( _line.Trim().ToLower() == "-| start |-" )
                {
                    _dataActive = true;
                }
            }
            // decrypt data
            DDPro.Software.Net20.Library.Rijndael _cipher = new DDPro.Software.Net20.Library.Rijndael( System.Text.Encoding.UTF8 );
            string _xmlString;
            try
            {
                _xmlString = _cipher.EasyDecrypt( _cData.ToString(), _set_DataCipherPhrase );
            }
            catch( Exception )
            {
                return false;
            }
            // initialize the internal DataSet by used Index-Column(s)
            _initializeDataSet( _fIndex );
            // apply XML to dataset
            try
            {
                System.IO.TextReader _dsData = new System.IO.StringReader(_xmlString);
                _int_DataSet.ReadXml( _dsData );
                _int_DataSet.AcceptChanges();
            }
            catch (Exception)
            {
                return false;
            }
            // everything was ok
            return true;
        }

        /// <summary>
        /// check the Version-Line for a match with DLL
        /// </summary>
        /// <param name="_Line">the complete Line inside the .cux-File</param>
        /// <returns>TRUE if Version is smaller or equal to Library...</returns>
        private bool _CheckFileVersion( string _Line )
        {
            // check version
            string[] _tmpData;
            _tmpData = _Line.Split( '=' );
            if( _tmpData.GetUpperBound( 0 ) < 1 ) // no Version-Info
            {
                return false;
            }
            string _libVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
            if( Convert.ToDouble( _tmpData[ 1 ] ) > Convert.ToDouble(_libVersion) ) // if File-Version is greater then DLL-Version
            {
                return false; // Format not supported...
            }
            // Version ok - remind
            _set_Version = _tmpData[ 1 ];
            return true;
        }

        /// <summary>
        /// get the IndexType used for the File
        /// </summary>
        /// <param name="_Line">the complete Line inside the .cux-File</param>
        /// <returns>the IndexType used for the File-Data</returns>
        private IndexColumn _GetFileIndex( string _Line )
        {
            // get index
            string[] _tmpData;
            _tmpData = _Line.Split( '=' );
            if( _tmpData.GetUpperBound( 0 ) < 1 ) // no Version-Info
            {
                return IndexColumn.Username; // username by default
            }
            // check Data-Field
            if( _tmpData[ 1 ].Trim() == IndexColumn.None.ToString() )
            {
                return IndexColumn.None;
            }
            if( _tmpData[ 1 ].Trim() == IndexColumn.NT_User.ToString() )
            {
                return IndexColumn.NT_User;
            }
            if( _tmpData[ 1 ].Trim() == IndexColumn.UserAndNT.ToString() )
            {
                return IndexColumn.UserAndNT;
            }
            // default is username
            return IndexColumn.Username;
        }

        #endregion

        #endregion

    }
}