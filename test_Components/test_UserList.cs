using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace LangugageXML.Component.Tests
{
    [TestFixture]
    public class UserList_Library
    {

        #region overloaded constructor

        [Test]
        public void test_constructorOverload_1()
        {
            DDPro.Software.Net20.Library.UserList _testObject = new DDPro.Software.Net20.Library.UserList();
            Assert.IsNotNull( _testObject, "UserList-Class for Test test_constructorOverload_1 could no be created..." );
            //Assert.AreEqual( "", _testObject.File, "" );
        }


        [Test]
        public void test_constructorOverload_2()
        {
            DDPro.Software.Net20.Library.UserList _testObject = new DDPro.Software.Net20.Library.UserList( DDPro.Software.Net20.Library.UserList.IndexColumn.None );
            Assert.IsNotNull( _testObject, "UserList-Class for Test test_constructorOverload_2 could no be created..." );
            //Assert.AreEqual( "", _testObject.File, "" );
        }

        [Test]
        public void test_constructorOverload_3()
        {
            string _file = System.IO.Path.GetTempPath() + @"\ctest_f1.cux";
            DDPro.Software.Net20.Library.UserList _testObject = new DDPro.Software.Net20.Library.UserList( _file );
            Assert.IsNotNull( _testObject, "UserList-Class for Test test_constructorOverload_3 could no be created..." );
            //Assert.AreEqual( "", _testObject.File, "" );
        }

        [Test]
        public void test_constructorOverload_4()
        {
            string _file = System.IO.Path.GetTempPath() + @"\ctest_f2.cux";
            DDPro.Software.Net20.Library.UserList _testObject = new DDPro.Software.Net20.Library.UserList( DDPro.Software.Net20.Library.UserList.IndexColumn.UserAndNT, _file );
            Assert.IsNotNull( _testObject, "UserList-Class for Test test_constructorOverload_4 could no be created..." );
            //Assert.AreEqual( "", _testObject.File, "" );
        }

        #endregion

        /*

        [Test]
        public void test_xXx()
        {
            DDPro.Software.Net20.Library.UserList _testObject = new DDPro.Software.Net20.Library.UserList();
            Assert.IsNotNull( _testObject, "UserList-Class for Test test_xXx could no be created..." );
            //Assert.AreEqual( "", _testObject.File, "" );
        }

        */

    }
}
