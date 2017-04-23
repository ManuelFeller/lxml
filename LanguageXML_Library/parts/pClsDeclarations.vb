' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Language XML Base Class |   http://lxml.codeplex.com  |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

Partial Public Class LanguageXML
    ' this Code is part of the public Interface of the class

#Region " public structures, enumerations and properties "

    ' Structures
    ''' <summary>This structure is used to provide the LXML Meta-Data for the open file.</summary>
    ''' <remarks>Structure for File Meta-Data (Program-Name, Description and Last Update of File)...</remarks>
    Public Structure fileBaseInfo
        ''' <summary>contains the associated Program-Name</summary>
        ''' <remarks>This (in the basic File-Format) optional Field can be used to ensure that the File is for the using Application...</remarks>
        Dim ProgramName As String
        ''' <summary>contains the additional description of the lxml-File</summary>
        ''' <remarks>This (in the basic File-Format) optional Field can be used to provide some short Informations about the Application as File-info / for a GUID / ...</remarks>
        Dim Description As String
        ''' <summary>contains the date of last update in the File - regular in Format of InvarantCulture - see Remarks</summary>
        ''' <remarks>The Editor released with the LanguageXML Toolset is saving all Values in InvaliantCulture-Format since version 1.9X of the Editor.<br />
        ''' The Class itself returns the same Format since version 0.12.0.0519 as default; before that Version is was an empty String...<br />
        ''' Before that Versions a &quot;undefined&quot; Date.ToString() was used so save the Timestamp; other Editors (that have to be developed first... ;-) may do something diffrent...</remarks>
        Dim LastUpdate As String
    End Structure
    ''' <summary>This structure is used to provide the internal available languages and the LXML meta-data for each language in the file.</summary>
    ''' <remarks>Structure for Language Meta-Data...</remarks>
    Public Structure langBaseInfo
        ''' <summary>contains the internal Name for the Language (used for property ActiveLanguage)</summary>
        ''' <remarks>This Value of the Lanuage is the internal Name within the File and is not supposed to be displayed to the User.<br />
        ''' Because the internal name is used as part of the TableName in the DataSet the possible Characters are very limited.<br />
        ''' You have to use this Value (the internal Name) to apply a new active Language...</remarks>
        Dim InternalName As String
        ''' <summary>contains the ISO-String for the Language</summary>
        ''' <remarks>The ISO-String (like en-US, en-GB, de-DE, hu-HU) for the Language.<br />
        ''' This is free Text that is &quot;guided&quot; by a ComboBox with Auto-Complete (in the Editor from this Toolset... ;-)</remarks>
        Dim IsoString As String
        ''' <summary>contains the Display-Name for the Language</summary>
        ''' <remarks>The Display-Name for the Language.<br />
        ''' This is free Text - it is recommended that the Name of the Language is saved in the Language itself (English, Deutsch, ...)<br />
        ''' Remind that this value is not &quot;indexed&quot; like the Default-Name - it may appear multiple Times if the Language-Editors do not think about this Example: English could appear for en-US and en-GB... ;-)</remarks>
        Dim DisplayName As String
        ''' <summary>contains the additional Informations for the Language</summary>
        ''' <remarks>The Info-Text for the Language. This is free Text...</remarks>
        Dim Info As String
        ''' <summary>contains the Author-Name for the Language</summary>
        ''' <remarks>The Name of the Language-Author. This is free Text...</remarks>
        Dim Author As String
        ''' <summary>contains the Version for the Language</summary>
        ''' <remarks>The Version for the Language. This is free Text...</remarks>
        Dim Version As String
        ''' <summary>contains the date of last update for the Language - regular in Format of InvarantCulture - see Remarks</summary>
        ''' <remarks>The Editor released with the LanguageXML Toolset is saving all Values in InvaliantCulture-Format since version 1.9X of the Editor.<br />
        ''' The Class itself returns the same Format since version 0.12.0.0519 as default; before that Version is was an empty String...<br />
        ''' Before that Versions a &quot;undefined&quot; Date.ToString() was used so save the Timestamp; other Editors (that have to be developed first... ;-) may do something diffrent...</remarks>
        Dim LastUpdate As String
    End Structure
    ''' <summary>This structure is used to pass Replace-Data to the ReadProcessedValue function(s).</summary>
    ''' <remarks>An Item contains the Information which placeholder has to be replaced with which value...</remarks>
    Public Structure ReplaceElements
        ''' <summary>the Value that should be replaced</summary>
        ''' <remarks>This is the Text to search for in the Language-Value...</remarks>
        Dim ReplaceThis As String
        ''' <summary>the Value that should be inserted</summary>
        ''' <remarks>This is the Text to insert for each appearance of the ReplaceThis-Value...</remarks>
        Dim ReplaceWith As String
    End Structure

    ' Enumerations
    ''' <summary>Message-Type for the internal provided Message-Box - Method</summary>
    ''' <remarks>This Enumeration is used to set the MessageType for the internal MessageBox-Method.<br />
    ''' Based on Default Item-Names (that are defined by the using Application) you can set the Title for the MessageBox without needing any Item-Name (or ID) for the call...</remarks>
    Public Enum MessageType
        ''' <summary>Info-Message</summary>
        ''' <remarks>needs a Language Item that is named "[MSG-HEADER-PREFIX]Info"</remarks>
        Info = 100
        ''' <summary>Warning-Message</summary>
        ''' <remarks>needs a Language Item that is named "[MSG-HEADER-PREFIX]Warning"</remarks>
        Warning = 200
        ''' <summary>Confirm-Message</summary>
        ''' <remarks>needs a Language Item that is named "[MSG-HEADER-PREFIX]Confirm"</remarks>
        Confirm = 300
        ''' <summary>Error-Message</summary>
        ''' <remarks>needs a Language Item that is named "[MSG-HEADER-PREFIX]Error"</remarks>
        ErrorMessage = 800
        ''' <summary>critiical Error-Message</summary>
        ''' <remarks>needs a Language Item that is named "[MSG-HEADER-PREFIX]Critical"</remarks>
        Critical = 900
    End Enum

    ' regular Properties
    ''' <summary>the internal Dataset used for handling the Language-Data</summary>
    ''' <value>the new Dataset to use</value>
    ''' <returns>the current Dataset</returns>
    ''' <remarks>Check the User-Guide (that should be attached to this Documentation) for a detailed definition about the used Format</remarks>
    Public Property lxmlData() As DataSet
        Get
            Return _lxmlBase.LanguageXML_DataSet
        End Get
        Set(ByVal lxmlDataSet As DataSet)
            _lxmlBase.LanguageXML_DataSet = lxmlDataSet
        End Set
    End Property
    ''' <summary>This property is used to get or set the internal Name of the active language.</summary>
    ''' <value>internal name for the new langauge to use</value>
    ''' <returns>internal name of the current language</returns>
    ''' <remarks>By changing this to the internal Name of another available language, the class internal changes the active output-language for all Methods and Functions...</remarks>
    Public Property ActiveLanguage() As String
        Get
            Return _lxmlBase.SelectedLanguage
        End Get
        Set(ByVal value As String)
            _lxmlBase.SetActiveLanguage(value)
        End Set
    End Property

    ' ThrowExceptions
    ' ShowErrorMessages


    ' MessageBox Properties
    ''' <summary>get / set the Name-Prefix for the LXML-Items that should be used as custom Title-Texts for the MessageBox</summary>
    ''' <value>the new Name-Prefix for the LXML-Items that should be used as custom Title-Texts for the MessageBox</value>
    ''' <returns>the current Name-Prefix for the LXML-Items that should be used as custom Title-Texts for the MessageBox</returns>
    ''' <remarks>Use this Property to read or set the Name-Prefix that introduces Custom-Title Items in the LXML-File.<br />
    ''' This is added to the string passed to the MessageBox-Function to create the full Name for the Custom-Title Item
    ''' (should help to keep code a bit shorter using &quot;Namespaces&quot; for those Items ;-) ...</remarks>
    Public Property MsgBox_LxmlTitleItemPrefix() As String
        Get
            Return _lxmlBase.Msgbox_LxmlTitletemPrefix
        End Get
        Set(ByVal value As String)
            _lxmlBase.Msgbox_LxmlTitletemPrefix = value
        End Set
    End Property
    ''' <summary>get / set the Name-Prefix for the LXML-Items that should be used as Default-Title-Texts</summary>
    ''' <value>the new Name-Prefix for the LXML-Items that should be used as Default Title-Texts for the MessageBox</value>
    ''' <returns>the current Name-Prefix for the LXML-Items that should be used as Default Title-Texts for the MessageBox</returns>
    ''' <remarks>Use this Property to read or set the Name-Prefix that introduces Default-Title Items in the LXML-File.<br />
    ''' This is added to the Default-Names in the MessageBox-Function to create the full Name for the Default-Title Item
    ''' (should help to keep code a bit shorter using &quot;Namespaces&quot; for those Items ;-) ...
    ''' <example>
    ''' Prefix &quot;err_msg_&quot; and MessageType &quot;MessageTyp.Confirm&quot; --> Item &quot;err_msg_Confirm&quot; is searched in the Language-Data...
    ''' </example>
    ''' <p>
    ''' Here are the Definitions for the Default-Names of the Language-Items used by the Class:
    ''' <ul>
    ''' <li>MessageType.Confirm = &quot;[USED_PREFIX]Confirm&quot;</li>
    ''' <li>MessageType.Critical = &quot;[USED_PREFIX]Critical&quot;</li>
    ''' <li>MessageType.ErrorMessage = &quot;[USED_PREFIX]Error&quot;</li>
    ''' <li>MessageType.Warning = &quot;[USED_PREFIX]Warning&quot;</li>
    ''' <li>MessageType.Info = &quot;[USED_PREFIX]Info&quot;</li>
    ''' </ul>
    ''' </p>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' </remarks>
    Public Property MsgBox_LxmMessageHeaderPrefix() As String
        Get
            Return _lxmlBase.Msgbox_LxmMessageHeaderPrefix
        End Get
        Set(ByVal value As String)
            _lxmlBase.Msgbox_LxmMessageHeaderPrefix = value
        End Set
    End Property
    ''' <summary>get / set the Name-Prefix for the LXML-Items that should be used as Message</summary>
    ''' <value>the new Name-Prefix for the LXML-Items that should be used as Text for the MessageBox</value>
    ''' <returns>the current Name-Prefix for the LXML-Items that should be used as Text for the MessageBox</returns>
    ''' <remarks>Use this Property to read or set the Name-Prefix that introduces Message Items in the LXML-File.<br />
    ''' This is added to the string passed to the MessageBox-Function to create the full Name for the Value Item
    ''' (should help to keep code a bit shorter using &quot;Namespaces&quot; for those Items ;-) ...</remarks>
    Public Property MsgBox_LxmMessageTextPrefix() As String
        Get
            Return _lxmlBase.Msgbox_LxmMessageTextPrefix
        End Get
        Set(ByVal value As String)
            _lxmlBase.Msgbox_LxmMessageTextPrefix = value
        End Set
    End Property

    ' read-only Properties
    ''' <summary>This read-only property is used to provide the LXML meta-data for the open File.</summary>
    ''' <returns>the current File-Informations</returns>
    ''' <remarks>You can use this Property to Access the Meta-Data for the open File without Requesting them from the internal Table...</remarks>
    Public ReadOnly Property FileDetails() As fileBaseInfo
        Get
            Return _lxmlBase.FileMeta
        End Get
    End Property
    ''' <summary>This read-only property is used to provide the internal available languages and the LXML meta-data for each language in the file as Array.</summary>
    ''' <returns>a langBaseInfo-structure-array (zero-based)...</returns>
    ''' <remarks>You can use this Property to Access the Meta-Data for the Languages in the open File without Requesting them from the internal Table...<br />
    ''' OUTDATED - used for compatiblity to older versions of the Class / Library...</remarks>
    Public ReadOnly Property LanguageDetails() As langBaseInfo()
        Get
            If _lxmlBase.LangMeta.Count > 0 Then ' at least one language found
                Dim _tmp(_lxmlBase.LangMeta.Count - 1) As langBaseInfo
                Dim _cnt As Integer = -1
                For Each _item As langBaseInfo In _lxmlBase.LangMeta
                    _cnt += 1
                    _tmp(_cnt) = _item
                Next
                Return _tmp
            Else ' no items - empty array with just one empty item
                ' should not happen in valid file becuase of default-language - just to be sure...
                Dim _tmp(0) As langBaseInfo
                Return _tmp
            End If
        End Get
    End Property
    ''' <summary>This read-only property is used to provide the internal available languages and the LXML meta-data for each language in the file as List.</summary>
    ''' <returns>a List of langBaseInfo-Items</returns>
    ''' <remarks>You can use this Property to Access the Meta-Data for the Languages in the open File without Requesting them from the internal Table...</remarks>
    Public ReadOnly Property LanguageDetailsList() As List(Of langBaseInfo)
        Get
            Return _lxmlBase.LangMeta
        End Get
    End Property
    ''' <summary>This read-only property is used for easy access to the Assemby-Version of the Library.</summary>
    ''' <returns>the DLL-Assembly-Version as System.Version</returns>
    ''' <remarks>Returns the Assembly-Version of the DLL-File - just to get this Information a bit more easy if wished... ;-)</remarks>
    Public ReadOnly Property DllVersion() As System.Version
        Get
            Return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
        End Get
    End Property

#End Region

End Class