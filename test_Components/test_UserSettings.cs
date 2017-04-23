using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace LangugageXML.Component.Tests
{
    [TestFixture]
    public class UserSettings_Library
    {

        #region Constuctor Overloads

        [Test]
        public void test_ConstructorOverload_1()
        {
            // init new Class
            DDPro.Software.Net20.Library.UserSettings _testObject = new DDPro.Software.Net20.Library.UserSettings( @"Component-Tests\Settings" );
            Assert.IsNotNull( _testObject, "Settings-Class for Test test_ConstructorOverload_1 could no be created..." );
            string DataFile = _testObject.ConfigFilePath; // read Name for Configuration-File --> for delete on end if needed
            Assert.AreEqual( System.Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ) + @"\Component-Tests\Settings\user_set.xml", DataFile, "FilePath for Settings in Test test_ConstructorOverload_1 not OK..." );

        }

        [Test]
        public void test_ConstructorOverload_2()
        {
            // init new Class
            DDPro.Software.Net20.Library.UserSettings _testObject = new DDPro.Software.Net20.Library.UserSettings( @"Component-Tests\Settings",DDPro.Software.Net20.Library.UserSettings.RootFolder.CommonAppData );
            Assert.IsNotNull( _testObject, "Settings-Class for Test test_ConstructorOverload_2 could no be created..." );
            string DataFile = _testObject.ConfigFilePath; // read Name for Configuration-File --> for delete on end if needed
            Assert.AreEqual( System.Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData ) + @"\Component-Tests\Settings\user_set.xml", DataFile, "FilePath for Settings in Test test_ConstructorOverload_2 not OK..." );

        }

        [Test]
        public void test_ConstructorOverload_3()
        {
            // init new Class
            DDPro.Software.Net20.Library.UserSettings _testObject = new DDPro.Software.Net20.Library.UserSettings( @"Component-Tests\Settings" ,"testfile.utf");
            Assert.IsNotNull( _testObject, "Settings-Class for Test test_ConstructorOverload_3 could no be created..." );
            string DataFile = _testObject.ConfigFilePath; // read Name for Configuration-File --> for delete on end if needed
            Assert.AreEqual( System.Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ) + @"\Component-Tests\Settings\testfile.utf", DataFile, "FilePath for Settings in Test test_ConstructorOverload_3 not OK..." );
        }

        [Test]
        public void test_ConstructorOverload_4()
        {
            // init new Class
            DDPro.Software.Net20.Library.UserSettings _testObject = new DDPro.Software.Net20.Library.UserSettings( @"Component-Tests\Settings", "MyFile.xml", DDPro.Software.Net20.Library.UserSettings.RootFolder.MyDocuments );
            Assert.IsNotNull( _testObject, "Settings-Class for Test test_ConstructorOverload_4 could no be created..." );
            string DataFile = _testObject.ConfigFilePath; // read Name for Configuration-File --> for delete on end if needed
            Assert.AreEqual( System.Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments ) + @"\Component-Tests\Settings\MyFile.xml", DataFile, "FilePath for Settings in Test test_ConstructorOverload_4 not OK..." );

        }

        #endregion

        #region Read/Write Values

        [Test]
        public void test_ReadWrite_Type_String()
        {
            // init new Class
            DDPro.Software.Net20.Library.UserSettings _testObject = new DDPro.Software.Net20.Library.UserSettings( @"Component-Tests\Settings" );
            Assert.IsNotNull( _testObject, "Settings-Class for Test test_ReadWrite_Type_String could no be created..." );
            // String-Overload
            string _str_in = "TestText...";
            string _str_out = "";
            _str_out = _testObject.GetValue( "TestVal", "..." );
            Assert.AreEqual( "...", _str_out, "test_ReadWrite_Type_String: Value that should be empty returned not the passed default ..." );
            Assert.IsTrue( _testObject.SaveValue( "TestVal", _str_in ), "test_ReadWrite_Type_String: Value could not be saved..." );
            _str_out = _testObject.GetValue( "TestVal", "" );
            Assert.AreEqual( _str_in, _str_out, "test_ReadWrite_Type_String: Value that was saved did not return expected Value on read..." );
        }

        [Test]
        public void test_ReadWrite_Type_Boolean()
        {
            // init new Class
            DDPro.Software.Net20.Library.UserSettings _testObject = new DDPro.Software.Net20.Library.UserSettings( @"Component-Tests\Settings" );
            Assert.IsNotNull( _testObject, "Settings-Class for Test test_ReadWrite_Type_Boolean could no be created..." );
            // String-Overload
            bool _in = true;
            bool _out = false;
            _out = _testObject.GetValue( "TestVal", true );
            Assert.AreEqual( true, _out, "test_ReadWrite_Type_Boolean: Value that should be empty returned not the passed default ..." );
            Assert.IsTrue( _testObject.SaveValue( "TestVal", _in ), "test_ReadWrite_Type_Boolean: Value could not be saved..." );
            _out = _testObject.GetValue( "TestVal", false );
            Assert.AreEqual( _in, _out, "test_ReadWrite_Type_Boolean: Value that was saved did not return expected Value on read..." );
        }

        [Test]
        public void test_ReadWrite_Type_Integer()
        {
            // init new Class
            DDPro.Software.Net20.Library.UserSettings _testObject = new DDPro.Software.Net20.Library.UserSettings( @"Component-Tests\Settings" );
            Assert.IsNotNull( _testObject, "Settings-Class for Test test_ReadWrite_Type_Integer could no be created..." );
            // String-Overload
            int _in = int.MaxValue;
            int _out = 0;
            _out = _testObject.GetValue( "TestVal", 123 );
            Assert.AreEqual( 123, _out, "test_ReadWrite_Type_Integer: Value that should be empty returned not the passed default ..." );
            Assert.IsTrue( _testObject.SaveValue( "TestVal", _in ), "test_ReadWrite_Type_Integer: Value could not be saved..." );
            _out = _testObject.GetValue( "TestVal", 0 );
            Assert.AreEqual( _in, _out, "test_ReadWrite_Type_Integer: Value that was saved did not return expected Value on read..." );
        }

        [Test]
        public void test_ReadWrite_Type_Long()
        {
            // init new Class
            DDPro.Software.Net20.Library.UserSettings _testObject = new DDPro.Software.Net20.Library.UserSettings( @"Component-Tests\Settings" );
            Assert.IsNotNull( _testObject, "Settings-Class for Test test_ReadWrite_Type_Long could no be created..." );
            // String-Overload
            long _in = long.MaxValue;
            long _out = 0L;
            _out = _testObject.GetValue( "TestVal", 123L );
            Assert.AreEqual( 123L, _out, "test_ReadWrite_Type_Long: Value that should be empty returned not the passed default ..." );
            Assert.IsTrue( _testObject.SaveValue( "TestVal", _in ), "test_ReadWrite_Type_Long: Value could not be saved..." );
            _out = _testObject.GetValue( "TestVal", 0L );
            Assert.AreEqual( _in, _out, "test_ReadWrite_Type_Long: Value that was saved did not return expected Value on read..." );
        }

        [Test]
        public void test_ReadWrite_Type_Double()
        {
            // init new Class
            DDPro.Software.Net20.Library.UserSettings _testObject = new DDPro.Software.Net20.Library.UserSettings( @"Component-Tests\Settings" );
            Assert.IsNotNull( _testObject, "Settings-Class for Test test_ReadWrite_Type_Double could no be created..." );
            // String-Overload
            //double _in = double.MaxValue;
            double _out = 0D;
            _out = _testObject.GetValue( "TestVal", 1.23D );
            Assert.AreEqual( 1.23D, _out, "test_ReadWrite_Type_Double: Value that should be empty returned not the passed default ..." );
            Assert.IsTrue( _testObject.SaveValue( "TestVal", 1.23456D ), "test_ReadWrite_Type_Double: Test-Value could not be saved..." );
            _out = _testObject.GetValue( "TestVal", 0D );
            Assert.AreEqual( 1.23456D, _out, "test_ReadWrite_Type_Double: small Value that was saved did not return expected Value on read..." );

            
            //Assert.IsTrue( _testObject.SaveValue( "TestVal", _in ), "test_ReadWrite_Type_Double: Value could not be saved..." );
            //_out = _testObject.GetValue( "TestVal", 0D );
            //Assert.AreEqual( _in, _out, "test_ReadWrite_Type_Double: max Value that was saved did not return expected Value on read..." );
        }

        [Test]
        public void test_ReadWrite_Type_DateTime()
        {
            // init new Class
            DDPro.Software.Net20.Library.UserSettings _testObject = new DDPro.Software.Net20.Library.UserSettings( @"Component-Tests\Settings" );
            Assert.IsNotNull( _testObject, "Settings-Class for Test test_ReadWrite_Type_Double could no be created..." );
            // String-Overload
            DateTime _in = new DateTime( 2009, 12, 11, 1, 23, 45 ); // do not use .Now to save value, because milliseconds are NOT saved --> DateTime.Now would result in a failed test...
            DateTime _out = DateTime.Now.AddDays(-30);
            _out = _testObject.GetValue( "TestVal", new DateTime(2009,12,11,21,35,00) );
            Assert.AreEqual( new DateTime( 2009, 12, 11, 21, 35, 00 ), _out, "test_ReadWrite_Type_Double: Value that should be empty returned not the passed default ..." );
            Assert.IsTrue( _testObject.SaveValue( "TestVal", _in ), "test_ReadWrite_Type_Double: Value could not be saved..." );
            _out = _testObject.GetValue( "TestVal", DateTime.Now );
            Assert.AreEqual( _in, _out, "test_ReadWrite_Type_Double: Value that was saved did not return expected Value on read..." );
        }
        
        #endregion

        #region Delete Values

        [Test]
        public void test_ReadWriteDelete_Type_String()
        {
            // init new Class
            DDPro.Software.Net20.Library.UserSettings _testObject = new DDPro.Software.Net20.Library.UserSettings( @"Component-Tests\Settings" );
            Assert.IsNotNull( _testObject, "Settings-Class for Test test_ReadWriteDelete_Type_String could no be created..." );
            // String-Overload
            string _str_in = "TestText...";
            string _str_out = "";
            _str_out = _testObject.GetValue( "TestVal", "..." );
            Assert.AreEqual( "...", _str_out, "test_ReadWriteDelete_Type_String: Value that should be empty returned not the passed default ..." );
            Assert.IsTrue( _testObject.SaveValue( "TestVal", _str_in ), "test_ReadWriteDelete_Type_String: Value could not be saved..." );
            _str_out = _testObject.GetValue( "TestVal", "" );
            Assert.AreEqual( _str_in, _str_out, "test_ReadWriteDelete_Type_String: Value that was saved did not return expected Value on read..." );

            Assert.IsTrue( _testObject.SaveValue( "TestVal1", _str_in ), "test_ReadWriteDelete_Type_String: Value could not be saved..." );
            Assert.IsTrue( _testObject.SaveValue( "TestVal2", _str_in ), "test_ReadWriteDelete_Type_String: Value could not be saved..." );
            Assert.IsTrue( _testObject.SaveValue( "TestVal3", _str_in ), "test_ReadWriteDelete_Type_String: Value could not be saved..." );
            Assert.IsTrue( _testObject.SaveValue( "TestVal", "update..." ), "test_ReadWriteDelete_Type_String: Value could not be updated..." );
            _str_out = _testObject.GetValue( "TestVal", "" );
            Assert.AreEqual( "update...", _str_out, "test_ReadWriteDelete_Type_String: Value that was updated did not return expected Value on read..." );

            Assert.IsTrue( _testObject.DeleteValue( "TestVal" ), "test_ReadWriteDelete_Type_String: Value could not be deleted..." );

            _str_out = _testObject.GetValue( "TestVal", "default..." );
            Assert.AreEqual( "default...", _str_out, "test_ReadWriteDelete_Type_String: Value that was deleted did not return passed default Value on read..." );


        }

        #endregion

        #region File-IO

        [Test]
        public void test_FileIO_Features()
        {
            // init new Class
            DDPro.Software.Net20.Library.UserSettings _testObject = new DDPro.Software.Net20.Library.UserSettings( @"Component-Tests\Settings","UnitTest.xml" );
            Assert.IsNotNull( _testObject, "Settings-Class for Test test_FileIO_Features could no be created..." );
            string DataFile = _testObject.ConfigFilePath; // read Name for Configuration-File --> for delete on end if needed

            Assert.IsTrue( _testObject.SaveValue( "Test1", "Text 1" ), "test_FileIO_Features: Value 1 could not be saved..." );
            Assert.IsTrue( _testObject.SaveValue( "Test2", "Text 2" ), "test_FileIO_Features: Value 2 could not be saved..." );
            Assert.IsTrue( _testObject.SaveValue( "Test3", "Text 3" ), "test_FileIO_Features: Value 3 could not be saved..." );
            Assert.IsTrue( _testObject.SaveValue( "Test4", "Text 4" ), "test_FileIO_Features: Value 4 could not be saved..." );
            Assert.IsTrue( _testObject.SaveValue( "Test5", "Text 5" ), "test_FileIO_Features: Value 5 could not be saved..." );
            Assert.IsTrue( _testObject.SaveConfig(), "test_FileIO_Features: File could not be saved..." );

            _testObject = new DDPro.Software.Net20.Library.UserSettings( @"Component-Tests\Settings", "UnitTest.xml" );
            Assert.IsNotNull( _testObject, "Settings-Class for Test test_FileIO_Features could no be re-created..." );
            _testObject.ThrowExceptions = false;

            Assert.IsTrue( _testObject.ConfigFileExists, "test_FileIO_Features: File could not be found after save by Library..." );
            Assert.IsTrue( System.IO.File.Exists( DataFile ), "test_FileIO_Features: File could not be found after save by Test..." );

            Assert.AreEqual( "xXx1", _testObject.GetValue( "Test1", "xXx1" ), "test_FileIO_Features: unset Value 1 did not return expected default..." );
            Assert.AreEqual( "xXx2", _testObject.GetValue( "Test2", "xXx2" ), "test_FileIO_Features: unset Value 2 did not return expected default..." );
            Assert.AreEqual( "xXx3", _testObject.GetValue( "Test3", "xXx3" ), "test_FileIO_Features: unset Value 3 did not return expected default..." );
            Assert.AreEqual( "xXx4", _testObject.GetValue( "Test4", "xXx4" ), "test_FileIO_Features: unset Value 4 did not return expected default..." );
            Assert.AreEqual( "xXx5", _testObject.GetValue( "Test5", "xXx5" ), "test_FileIO_Features: unset Value 5 did not return expected default..." );

            Assert.IsTrue( _testObject.LoadConfig(), "test_FileIO_Features: File could not be loaded..." );

            Assert.AreEqual( "Text 1", _testObject.GetValue( "Test1", "xXx1" ), "test_FileIO_Features: unset Value 1 did not return expected default..." );
            Assert.AreEqual( "Text 2", _testObject.GetValue( "Test2", "xXx2" ), "test_FileIO_Features: unset Value 2 did not return expected default..." );
            Assert.AreEqual( "Text 3", _testObject.GetValue( "Test3", "xXx3" ), "test_FileIO_Features: unset Value 3 did not return expected default..." );
            Assert.AreEqual( "Text 4", _testObject.GetValue( "Test4", "xXx4" ), "test_FileIO_Features: unset Value 4 did not return expected default..." );
            Assert.AreEqual( "Text 5", _testObject.GetValue( "Test5", "xXx5" ), "test_FileIO_Features: unset Value 5 did not return expected default..." );

            _testObject.InitializeConfig();

            Assert.AreEqual( "xXx1", _testObject.GetValue( "Test1", "xXx1" ), "test_FileIO_Features: unset Value 1 did not return expected default..." );
            Assert.AreEqual( "xXx2", _testObject.GetValue( "Test2", "xXx2" ), "test_FileIO_Features: unset Value 2 did not return expected default..." );
            Assert.AreEqual( "xXx3", _testObject.GetValue( "Test3", "xXx3" ), "test_FileIO_Features: unset Value 3 did not return expected default..." );
            Assert.AreEqual( "xXx4", _testObject.GetValue( "Test4", "xXx4" ), "test_FileIO_Features: unset Value 4 did not return expected default..." );
            Assert.AreEqual( "xXx5", _testObject.GetValue( "Test5", "xXx5" ), "test_FileIO_Features: unset Value 5 did not return expected default..." );



            Assert.IsTrue( _testObject.DeleteConfig(), "test_FileIO_Features: Cofig-File could not be deleted by class..." );
            Assert.IsFalse( System.IO.File.Exists( DataFile ), "test_FileIO_Features: File was not deleted by Library..." );



        }

        #endregion

        /*

        [Test]
        public void test_xXx()
        {
            // init new Class
            DDPro.Software.Net20.Library.UserSettings _testObject = new DDPro.Software.Net20.Library.UserSettings( @"Component-Tests\Settings" );
            Assert.IsNotNull( _testObject, "Settings-Class for Test xXx could no be created..." );
            string DataFile = _testObject.ConfigFilePath; // read Name for Configuration-File --> for delete on end if needed
        }

        */
    }
}