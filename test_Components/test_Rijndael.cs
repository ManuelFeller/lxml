using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace LangugageXML.Component.Tests
{
    [TestFixture]
    public class RijndaelAES_Library
    {

        [Test]
        public void test_RijndaelAES()
        {
            DDPro.Software.Net20.Library.Rijndael _testObject = new DDPro.Software.Net20.Library.Rijndael( Encoding.Default );
            Assert.NotNull( _testObject, "AES-Class for Test test_RijndaelAES could no be created..." );
            string _pw = "Pa$$Phra53!";
            string _msg = "Message to cipher...";
            string _tmp = "";

            // check one cycle
            _tmp = _testObject.EasyEncrypt( _msg, _pw );
            Assert.AreEqual( _msg, _testObject.EasyDecrypt( _tmp, _pw ), "test_RijndaelAES: encrypted String (1 cycle) not decrypted to original..." );
            Assert.AreNotEqual( _msg, _testObject.EasyDecrypt( _tmp, "wrongPW" ), "test_RijndaelAES: encrypted String (1 cycle) decrypted to original with wrong password --> error..." );

            // check five cycles
            _tmp = _testObject.EasyEncrypt( _msg, _pw, 5 );
            Assert.AreNotEqual( _msg, _testObject.EasyDecrypt( _tmp, _pw, 4 ), "test_RijndaelAES: encrypted String (5 cycles) decrypted to original with 4 cycles --> error..." );
            Assert.AreEqual( _msg, _testObject.EasyDecrypt( _tmp, _pw, 5 ), "test_RijndaelAES: encrypted String (5 cycles) not decrypted to original..." );



        }

    }
}
