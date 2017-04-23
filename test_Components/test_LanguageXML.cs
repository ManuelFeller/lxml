using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace LangugageXML.Component.Tests
{
    [TestFixture]
    public class LanguageXML_Library
    {
        /// <summary>LanguageXML-File (Version 1) to use for Test - this must be improved, too</summary>
        private const string LxmlV1TestFile = @"C:\UserData\fellerm\LanguageXML 4 CodeProject\solution\test_Components\test_objects\testform.lxml";
        /// <summary>LanguageXML-File (Version 2) to use for Test - this must be improved, too</summary>
        private const string LxmlV2TestFile = @"C:\UserData\fellerm\LanguageXML 4 CodeProject\solution\test_Components\test_objects\testform_v2.lxml";

        [Test]
        public void test_FileV1_FormAutoApply()
        {
            _test_FormAutoApply( LxmlV1TestFile );
        }

        [Test]
        public void test_FileV1_ValueRead()
        {
            _test_ValueRead( LxmlV1TestFile );
        }

        [Test]
        public void test_FileV2_FormAutoApply()
        {
            _test_FormAutoApply( LxmlV2TestFile );
        }

        [Test]
        public void test_FileV2_ValueRead()
        {
            _test_ValueRead( LxmlV2TestFile );
        }

        [Test]
        public void test_FileLoad_V1()
        {
            DDPro.Software.Net20.Library.LanguageXML _testObject = new DDPro.Software.Net20.Library.LanguageXML();
            Assert.IsNotNull( _testObject, "LanguageXML-Class for Test _test_ValueRead (" + LxmlV1TestFile + ") could no be created..." );

            DateTime _tmpDate = DateTime.Now;

            // load file
            Assert.IsTrue( _testObject.LoadFromXmlFile( LxmlV1TestFile ), "_test_ValueRead: .lxml-File (" + LxmlV1TestFile + ") could not be loaded..." );

        }

        [Test]
        public void test_FileLoad_V2()
        {
            DDPro.Software.Net20.Library.LanguageXML _testObject = new DDPro.Software.Net20.Library.LanguageXML();
            Assert.IsNotNull( _testObject, "LanguageXML-Class for Test _test_ValueRead (" + LxmlV2TestFile + ") could no be created..." );

            DateTime _tmpDate = DateTime.Now;

            // load file
            Assert.IsTrue( _testObject.LoadFromXmlFile( LxmlV2TestFile ), "_test_ValueRead: .lxml-File (" + LxmlV2TestFile + ") could not be loaded..." );

        }

        #region internals

        /// <summary>test Value-Reading</summary>
        /// <param name="_file">the File to use</param>
        private void _test_ValueRead( string _file )
        {
            DDPro.Software.Net20.Library.LanguageXML _testObject = new DDPro.Software.Net20.Library.LanguageXML();
            Assert.IsNotNull( _testObject, "LanguageXML-Class for Test _test_ValueRead (" + _file + ") could no be created..." );

            DateTime _tmpDate = DateTime.Now;

            // load file
            Assert.IsTrue( _testObject.LoadFromXmlFile( _file ), "_test_ValueRead: .lxml-File (" + _file + ") could not be loaded..." );

            // read values from default-lang
            Assert.AreEqual( "english", _testObject.ReadValue( "test_val2Lang", true ), "_test_ValueRead: returned Value (1st lang, fallback) not like expected..." );
            Assert.AreEqual( "only eng", _testObject.ReadValue( "test_val1Lang", true ), "_test_ValueRead: returned Value (1st lang, fallback) not like expected..." );

            // processed value
            List<DDPro.Software.Net20.Library.LanguageXML.ReplaceElements> _replace = new List<DDPro.Software.Net20.Library.LanguageXML.ReplaceElements>();
            DDPro.Software.Net20.Library.LanguageXML.ReplaceElements _tmpItem = new DDPro.Software.Net20.Library.LanguageXML.ReplaceElements();
            _tmpItem.ReplaceThis = "{v1}";
            _tmpItem.ReplaceWith = "replace";
            _replace.Add( _tmpItem );
            _tmpItem = new DDPro.Software.Net20.Library.LanguageXML.ReplaceElements();
            _tmpItem.ReplaceThis = "{v2}";
            _tmpItem.ReplaceWith = "return";
            _replace.Add( _tmpItem );
            // test all overloads
            Assert.AreEqual( "Test replace and return...", _testObject.ReadProcessedValue( "test_processed", _replace, false ), "_test_ValueRead: ProcessedText (both values) not like expected result..." );
            Assert.AreEqual( "Test {v1} and return...", _testObject.ReadProcessedValue( "test_processed", _tmpItem, false ), "_test_ValueRead: ProcessedText (second value) not like expected result..." );
            Assert.AreEqual( "Test replace and {v2}...", _testObject.ReadProcessedValue( "test_processed", "{v1}", "replace", false ), "_test_ValueRead: ProcessedText (first value) not like expected result..." );

            // language-list and -MetaData ...
            List<DDPro.Software.Net20.Library.LanguageXML.langBaseInfo> _tmpLangMeta = _testObject.LanguageDetailsList; // read Data from Class
            Assert.AreEqual( 2, _tmpLangMeta.Count, "_test_ValueRead: not expected number of languages in file..." ); // check number of languages
            foreach( DDPro.Software.Net20.Library.LanguageXML.langBaseInfo _langItem in _tmpLangMeta ) // for each language
            {
                switch( _langItem.InternalName.ToLower() ) // check by internal name (not case-sensitive)
                {
                    case "default": // default-language
                        Assert.AreEqual( "Manuel Feller", _langItem.Author, "_test_ValueRead: Meta-Field Author for default-language not like expected..." );
                        Assert.AreEqual( "English (US)", _langItem.DisplayName, "_test_ValueRead: Meta-Field DisplayName for default-language not like expected..." );
                        Assert.AreEqual( "... Test-Values for the Test-Form in Component-Test ...", _langItem.Info, "_test_ValueRead: Meta-Field Info for default-language not like expected..." );
                        Assert.AreEqual( "DEFAULT", _langItem.InternalName, "_test_ValueRead: Meta-Field InternalName for default-language not like expected..." );
                        Assert.AreEqual( "en-US", _langItem.IsoString, "_test_ValueRead: Meta-Field ISO-String for default-language not like expected..." );
                        Assert.IsTrue( DDPro.Software.Net20.Tests.CommonHelper.clsIvCultureDate.TryParse( _langItem.LastUpdate, out _tmpDate ), "_test_ValueRead: Meta-Field LastUpdate for default-language could not be converted to date..." );
                        Assert.AreEqual( "1.0.en", _langItem.Version, "_test_ValueRead: Meta-Field Version for default-language not like expected..." );
                        break;
                    case "german": // second language in file
                        Assert.AreEqual( "Manuel Feller", _langItem.Author, "_test_ValueRead: Meta-Field Author for second language not like expected..." );
                        Assert.AreEqual( "Deutsch", _langItem.DisplayName, "_test_ValueRead: Meta-Field DisplayName for second language not like expected..." );
                        Assert.AreEqual( "... blah und blubs ...", _langItem.Info, "_test_ValueRead: Meta-Field Info for second language not like expected..." );
                        Assert.AreEqual( "german", _langItem.InternalName, "_test_ValueRead: Meta-Field InternalName for second language not like expected..." );
                        Assert.AreEqual( "de-DE", _langItem.IsoString, "_test_ValueRead: Meta-Field ISO-String for second language not like expected..." );
                        Assert.IsTrue( DDPro.Software.Net20.Tests.CommonHelper.clsIvCultureDate.TryParse( _langItem.LastUpdate, out _tmpDate ), "_test_ValueRead: Meta-Field LastUpdate for second language could not be converted to date..." );
                        Assert.AreEqual( "1.0.de", _langItem.Version, "_test_ValueRead: Meta-Field Version for second language not like expected..." );
                        break;
                    default: // unknown language
                        Assert.IsTrue( false, "unknown Language detected in FileData..." ); // fail test here... ;-)
                        break;
                }
            }

            // test second language
            _testObject.ActiveLanguage = "german";
            Assert.AreEqual( "german", _testObject.ActiveLanguage, "_test_ValueRead: ActiveLangugae not like expected..." );
            // second language
            Assert.AreEqual( "deutsch", _testObject.ReadValue( "test_val2Lang", true ), "_test_ValueRead: returned Value (2nd lang, fallback) not like expected..." );
            Assert.AreEqual( "only eng", _testObject.ReadValue( "test_val1Lang", true ), "_test_ValueRead: returned Value (2nd lang, fallback) not like expected..." );
            // second language without fallback
            Assert.AreEqual( "deutsch", _testObject.ReadValue( "test_val2Lang", false ), "_test_ValueRead: returned Value (2nd lang, no fallback) not like expected..." );
            Assert.AreEqual( "", _testObject.ReadValue( "test_val1Lang", false ), "_test_ValueRead: returned Value (2nd lang, no fallback) not like expected..." );

            // Meta-Data File
            DDPro.Software.Net20.Library.LanguageXML.fileBaseInfo _tmpFileInfo = _testObject.FileDetails;
            Assert.AreEqual( "Component-Test", _tmpFileInfo.ProgramName, "_test_ValueRead: Meta-Field ProgramName for file not like expected..." );
            Assert.AreEqual( "... data for the Test-Form ...", _tmpFileInfo.Description, "_test_ValueRead: Meta-Field FileInfo for file not like expected..." );
            Assert.IsTrue( DDPro.Software.Net20.Tests.CommonHelper.clsIvCultureDate.TryParse( _tmpFileInfo.LastUpdate, out _tmpDate ), "_test_ValueRead: Meta-Field LastUpdate for file could not be converted to date..." );

        }

        /// <summary>test Form Auto-Apply</summary>
        /// <param name="_file">the File to use</param>
        private void _test_FormAutoApply( string _file )
        {
            DDPro.Software.Net20.Library.LanguageXML _testObject = new DDPro.Software.Net20.Library.LanguageXML();
            Assert.IsNotNull( _testObject, "LanguageXML-Class for Test _test_FormAutoApply (" + _file + ") could no be created..." );

            // create instance of test-form
            DDPro.Software.Net20.Tests.test_objects.tFrmLangXML _testForm = new DDPro.Software.Net20.Tests.test_objects.tFrmLangXML();
            //bool _res = _testObject.LoadFromXmlFile( _file );
            Assert.IsTrue( _testObject.LoadFromXmlFile( _file ), "_test_FormAutoApply: .lxml-File (" + _file + ") could not be loaded..." );

            Assert.AreEqual( "Test-Text", _testObject.ReadValue( "test_value", true ), "_test_FormAutoApply: Test-Text not like expected..." );

            // create a casted reference to use auto-apply (sorry, no better way until now - has to be improved...)
            System.Windows.Forms.Form _refHolder = ( System.Windows.Forms.Form ) _testForm;
            // call auto-apply
            _testObject.ApplyTextToForm( ref _refHolder, "lx_", "av_tf_", true, true );

            // check form for expected values
            Assert.AreEqual( "Form", _testForm.Text, "_test_FormAutoApply: Form-Text not set..." );
            Assert.AreEqual( "File", _testForm.lx_mnFile.Text, "_test_FormAutoApply: FileMenu-Text not set..." );
            Assert.AreEqual( "Item 1", _testForm.lx_mniItem1.Text, "_test_FormAutoApply: MenuItem1-Text not set..." );
            Assert.AreEqual( "ComboBox", _testForm.lx_mniCombo.Text, "_test_FormAutoApply: MenuComboBox-Text not set..." );
            Assert.AreEqual( "TextBox", _testForm.lx_mniText.Text, "_test_FormAutoApply: MenuTextBox-Text not set..." );
            Assert.AreEqual( "Nest", _testForm.lx_mniItemNest.Text, "_test_FormAutoApply: MenuNest-Text not set..." );
            Assert.AreEqual( "Nested", _testForm.lx_mniItemNested.Text, "_test_FormAutoApply: MenuNested-Text not set..." );
            Assert.AreEqual( "Button", _testForm.lx_btnTest.Text, "_test_FormAutoApply: Button-Text not set..." );
            Assert.AreEqual( "TextBox", _testForm.lx_tbxTest.Text, "_test_FormAutoApply: TextBox-Text not set..." );
            Assert.AreEqual( "ComboBox", _testForm.lx_cbxTest.Text, "_test_FormAutoApply: ComboBox-Text not set..." );
            Assert.AreEqual( "Label", _testForm.lx_lblTest.Text, "_test_FormAutoApply: Label-Text not set..." );
            Assert.AreEqual( "RadioButton", _testForm.lx_rbtTest.Text, "_test_FormAutoApply: RadioButton-Text not set..." );
            Assert.AreEqual( "LinkLabel", _testForm.lx_lnkTest.Text, "_test_FormAutoApply: LinkLabel-Text not set..." );
            Assert.AreEqual( "CheckBox", _testForm.lx_chkTest.Text, "_test_FormAutoApply: CheckBox-Text not set..." );
            Assert.AreEqual( "GroupBox", _testForm.lx_grpTest.Text, "_test_FormAutoApply: GroupBox-Text not set..." );
            Assert.AreEqual( "RichtTextBox", _testForm.lx_rtfTest.Text, "_test_FormAutoApply: RichTextBox-Text not set..." );
            Assert.AreEqual( "Tab 1", _testForm.lx_tpgTest1.Text, "_test_FormAutoApply: TabPage1-Text not set..." );
            Assert.AreEqual( "Tab 2", _testForm.lx_tpgTest2.Text, "_test_FormAutoApply: TabPage2-Text not set..." );
            Assert.AreEqual( "masked Text", _testForm.lx_mtbTest.Text, "_test_FormAutoApply: MaskedtextBox-Text not set..." );
            Assert.AreEqual( "Label", _testForm.lx_tsLblTest.Text, "_test_FormAutoApply: Label-Text on StatusBar not set..." );
            Assert.AreEqual( "DropDown", _testForm.lx_tsDrpTest.Text, "_test_FormAutoApply: DropDown-Text on StatusBar not set..." );
            Assert.AreEqual( "SplitButton", _testForm.lx_tsSplTest.Text, "_test_FormAutoApply: SplitButton-Text on StatusBar not set..." );
            Assert.AreEqual( "DropDownElement1", _testForm.lx_tsDrp1Elem1.Text, "_test_FormAutoApply: DropDown1-Item-Text on StatusBar not set..." );
            Assert.AreEqual( "DropDownElement2", _testForm.lx_tsDrp2Elem1.Text, "_test_FormAutoApply: DropDown2-Item-Text on StatusBar not set..." );
            Assert.AreEqual( "SplitButtonElement1", _testForm.lx_tsSpl1Elem1.Text, "_test_FormAutoApply: SplitButton1-Item-Text on StatusBar not set..." );
            Assert.AreEqual( "SplitButtonElementNest", _testForm.lx_tsSpl2ElemNest.Text, "_test_FormAutoApply: SplitButton2-NestItem-Text on StatusBar not set..." );
            Assert.AreEqual( "SplitButtonNestedItem", _testForm.lx_tsSpl2NestedItem.Text, "_test_FormAutoApply: SplitButton2-NestedItem-Text on StatusBar not set..." );
            Assert.AreEqual( "SplitButtonNestedCombo", _testForm.lx_tsSpl2NestedCombo.Text, "_test_FormAutoApply: SplitButton2-NestedComboBox-Text on StatusBar not set..." );
            Assert.AreEqual( "SplitButtonNestedText", _testForm.lx_tsSpl2NestedText.Text, "_test_FormAutoApply: SplitButton2-NestedTextBox-Text on StatusBar not set..." );

            // check Item without prefix --> not changed...
            Assert.AreEqual( "...", _testForm.lblNoChange.Text, "_test_FormAutoApply: NoChangeLabel-Text changed..." );


            //Assert.AreEqual( "", _testForm.Text, "_test_FormAutoApply: -Text not set..." );
            //Assert.AreEqual( "", _testForm.Text, "_test_FormAutoApply: -Text not set..." );
            //Assert.AreEqual( "", _testForm.Text, "_test_FormAutoApply: -Text not set..." );
            //Assert.AreEqual( "", _testForm.Text, "_test_FormAutoApply: -Text not set..." );
            //Assert.AreEqual( "", _testForm.Text, "_test_FormAutoApply: -Text not set..." );






        }

        #endregion


    }
}
