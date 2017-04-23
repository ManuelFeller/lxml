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

#Region " internal MessageBox (with optional Placeholder-Replace) "

#Region " Group for supported MessageBox.Show Overload Type 1 - all variants "

#Region " Default-Tile "

    ' no Placeholder-Replace
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a defined Title...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="Type">the MessageType to use for Title-Selection (remember to set MsgBox_LxmMessageHeaderPrefix for this)</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox using Item-Name (without the prefix) and a Default-Title.
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmMessageHeaderPrefix = &quot;msg_title_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter Type = &quot;MessageType.Confirm&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_title_Confirm&quot;</li>
    ''' </ul></p></example>
    ''' <p>It is required that you have created Items for the Default-Titles with the correct Name within the Language-Items to use it.<br />
    ''' (correct Name: Items using the defined prefix for MessageBox-Titles with the below defined Strings appended as Item-Name)</p>
    ''' <p>The Definition for the Default-Names of the Language-Items used by the Class:
    ''' <ul><li>MessageType.Confirm = &quot;[USED_PREFIX]Confirm&quot;</li>
    ''' <li>MessageType.Critical = &quot;[USED_PREFIX]Critical&quot;</li>
    ''' <li>MessageType.ErrorMessage = &quot;[USED_PREFIX]Error&quot;</li>
    ''' <li>MessageType.Warning = &quot;[USED_PREFIX]Warning&quot;</li>
    ''' <li>MessageType.Info = &quot;[USED_PREFIX]Info&quot;</li>
    ''' </ul></p>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmMessageHeaderPrefix">Property LanguageXML.MsgBox_LxmMessageHeaderPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal Type As MessageType) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetMessageBoxText(MessageName)
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(Type)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title)
    End Function
    ' including Placeholder-Replace
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a defined Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="Type">the MessageType to use for Title-Selection (remember to set MsgBox_LxmMessageHeaderPrefix for this)</param>
    ''' <param name="ReplaceThis">the String that should be replaced in MessageText</param>
    ''' <param name="ReplaceWith">the String that should be inserted in MessageText</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name (without the prefix) with processed Value and a Default-Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmMessageHeaderPrefix = &quot;msg_title_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter Type = &quot;MessageType.Confirm&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_title_Confirm&quot;</li>
    ''' </ul></p></example>
    ''' <p>It is required that you have created Items for the Default-Titles with the correct Name within the Language-Items to use it.<br />
    ''' (correct Name: Items using the defined prefix for MessageBox-Titles with the below defined Strings appended as Item-Name)</p>
    ''' <p>The Definition for the Default-Names of the Language-Items used by the Class:
    ''' <ul><li>MessageType.Confirm = &quot;[USED_PREFIX]Confirm&quot;</li>
    ''' <li>MessageType.Critical = &quot;[USED_PREFIX]Critical&quot;</li>
    ''' <li>MessageType.ErrorMessage = &quot;[USED_PREFIX]Error&quot;</li>
    ''' <li>MessageType.Warning = &quot;[USED_PREFIX]Warning&quot;</li>
    ''' <li>MessageType.Info = &quot;[USED_PREFIX]Info&quot;</li>
    ''' </ul></p>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmMessageHeaderPrefix">Property LanguageXML.MsgBox_LxmMessageHeaderPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal Type As MessageType, ByVal ReplaceThis As String, ByVal ReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(ReplaceThis, ReplaceWith))
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(Type)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title)
    End Function
    ''' <summary>
    ''' display a MessageBox without the need to request the Language-Items by custom code - using a defined Title and Placeholder-Replace...
    ''' </summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="Type">the MessageType to use for Title-Selection (remember to set MsgBox_LxmMessageHeaderPrefix for this)</param>
    ''' <param name="ReplaceData">List of ReplaceData-Elements for the MessageText</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name (without the prefix) with processed Value and a Default-Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmMessageHeaderPrefix = &quot;msg_title_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter Type = &quot;MessageType.Confirm&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_title_Confirm&quot;</li>
    ''' </ul></p></example>
    ''' <p>It is required that you have created Items for the Default-Titles with the correct Name within the Language-Items to use it.<br />
    ''' (correct Name: Items using the defined prefix for MessageBox-Titles with the below defined Strings appended as Item-Name)</p>
    ''' <p>The Definition for the Default-Names of the Language-Items used by the Class:
    ''' <ul><li>MessageType.Confirm = &quot;[USED_PREFIX]Confirm&quot;</li>
    ''' <li>MessageType.Critical = &quot;[USED_PREFIX]Critical&quot;</li>
    ''' <li>MessageType.ErrorMessage = &quot;[USED_PREFIX]Error&quot;</li>
    ''' <li>MessageType.Warning = &quot;[USED_PREFIX]Warning&quot;</li>
    ''' <li>MessageType.Info = &quot;[USED_PREFIX]Info&quot;</li>
    ''' </ul></p>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmMessageHeaderPrefix">Property LanguageXML.MsgBox_LxmMessageHeaderPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal Type As MessageType, ByVal ReplaceData As List(Of ReplaceElements)) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(ReplaceData))
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(Type)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title)
    End Function
    ''' <summary>
    ''' display a MessageBox without the need to request the Language-Items by custom code - using a defined Title and Placeholder-Replace...
    ''' </summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="Type">the MessageType to use for Title-Selection (remember to set MsgBox_LxmMessageHeaderPrefix for this)</param>
    ''' <param name="ReplaceData">ReplaceData Array</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name (without the prefix) with processed Value and a Default-Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmMessageHeaderPrefix = &quot;msg_title_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter Type = &quot;MessageType.Confirm&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_title_Confirm&quot;</li>
    ''' </ul></p></example>
    ''' <p>It is required that you have created Items for the Default-Titles with the correct Name within the Language-Items to use it.<br />
    ''' (correct Name: Items using the defined prefix for MessageBox-Titles with the below defined Strings appended as Item-Name)</p>
    ''' <p>The Definition for the Default-Names of the Language-Items used by the Class:
    ''' <ul><li>MessageType.Confirm = &quot;[USED_PREFIX]Confirm&quot;</li>
    ''' <li>MessageType.Critical = &quot;[USED_PREFIX]Critical&quot;</li>
    ''' <li>MessageType.ErrorMessage = &quot;[USED_PREFIX]Error&quot;</li>
    ''' <li>MessageType.Warning = &quot;[USED_PREFIX]Warning&quot;</li>
    ''' <li>MessageType.Info = &quot;[USED_PREFIX]Info&quot;</li>
    ''' </ul></p>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmMessageHeaderPrefix">Property LanguageXML.MsgBox_LxmMessageHeaderPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal Type As MessageType, ByVal ReplaceData As ReplaceElements()) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, ReplaceData)
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(Type)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title)
    End Function

#End Region

#Region " custom Title "

    ' no Placeholder-Replace
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox using Item-Name for Message and a custom Title (Item-Names without prefix).
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetMessageBoxText(MessageName)
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(TitleName)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title)
    End Function

    ' including Placeholder-Replace in Message-Text
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="ReplaceThis">the String that should be replaced</param>
    ''' <param name="ReplaceWith">the String that should be inserted</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and a custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal ReplaceThis As String, ByVal ReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(ReplaceThis, ReplaceWith))
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(TitleName)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="ReplaceData">List of ReplaceData-Elements</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and a custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal ReplaceData As List(Of ReplaceElements)) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(ReplaceData))
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(TitleName)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="ReplaceData">ReplaceData Array</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and a custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal ReplaceData As ReplaceElements()) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, ReplaceData)
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(TitleName)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title)
    End Function

    ' including Placeholder-Replace in Message-Text and Title
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="TextReplaceThis">the String that should be replaced in Message-Text</param>
    ''' <param name="TextReplaceWith">the String that should be inserted in Message-Text</param>
    ''' <param name="TitleReplaceThis">the String that should be replaced in Message-Title</param>
    ''' <param name="TitleReplaceWith">the String that should be inserted Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal TextReplaceThis As String, ByVal TextReplaceWith As String, ByVal TitleReplaceThis As String, ByVal TitleReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(TextReplaceThis, TextReplaceWith))
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, _lxmlBase.GetReplaceArray(TitleReplaceThis, TitleReplaceWith))
        Return System.Windows.Forms.MessageBox.Show(_msg, _title)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="TextReplaceData">List of ReplaceData-Elements for Message-Text</param>
    ''' <param name="TitleReplaceData">List of ReplaceData-Elements for Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal TextReplaceData As List(Of ReplaceElements), ByVal TitleReplaceData As List(Of ReplaceElements)) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(TextReplaceData))
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, _lxmlBase.GetReplaceArray(TitleReplaceData))
        Return System.Windows.Forms.MessageBox.Show(_msg, _title)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="TextReplaceData">ReplaceData Array for Message-Text</param>
    ''' <param name="TitleReplaceData">ReplaceData Array for Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal TextReplaceData As ReplaceElements(), ByVal TitleReplaceData As ReplaceElements()) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, TextReplaceData)
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, TitleReplaceData)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="TextReplaceData">List of ReplaceData-Elements for Message-Text</param>
    ''' <param name="TitleReplaceThis">the String that should be replaced in Message-Title</param>
    ''' <param name="TitleReplaceWith">the String that should be inserted Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal TextReplaceData As List(Of ReplaceElements), ByVal TitleReplaceThis As String, ByVal TitleReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(TextReplaceData))
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, _lxmlBase.GetReplaceArray(TitleReplaceThis, TitleReplaceWith))
        Return System.Windows.Forms.MessageBox.Show(_msg, _title)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="TextReplaceData">ReplaceData Array for Message-Text</param>
    ''' <param name="TitleReplaceThis">the String that should be replaced in Message-Title</param>
    ''' <param name="TitleReplaceWith">the String that should be inserted Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal TextReplaceData As ReplaceElements(), ByVal TitleReplaceThis As String, ByVal TitleReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, TextReplaceData)
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, _lxmlBase.GetReplaceArray(TitleReplaceThis, TitleReplaceWith))
        Return System.Windows.Forms.MessageBox.Show(_msg, _title)
    End Function

#End Region

#End Region

#Region " Group for supported MessageBox.Show Overload Type 2 - all variants "

#Region " Default-Tile "

    ' no Placeholder-Replace
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a defined Title...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="Buttons"></param>
    ''' <param name="Type">the MessageType to use for Title-Selection (remember to set MsgBox_LxmMessageHeaderPrefix for this)</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox using Item-Name (without the prefix) and a Default-Title.
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmMessageHeaderPrefix = &quot;msg_title_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter Type = &quot;MessageType.Confirm&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_title_Confirm&quot;</li>
    ''' </ul></p></example>
    ''' <p>It is required that you have created Items for the Default-Titles with the correct Name within the Language-Items to use it.<br />
    ''' (correct Name: Items using the defined prefix for MessageBox-Titles with the below defined Strings appended as Item-Name)</p>
    ''' <p>The Definition for the Default-Names of the Language-Items used by the Class:
    ''' <ul><li>MessageType.Confirm = &quot;[USED_PREFIX]Confirm&quot;</li>
    ''' <li>MessageType.Critical = &quot;[USED_PREFIX]Critical&quot;</li>
    ''' <li>MessageType.ErrorMessage = &quot;[USED_PREFIX]Error&quot;</li>
    ''' <li>MessageType.Warning = &quot;[USED_PREFIX]Warning&quot;</li>
    ''' <li>MessageType.Info = &quot;[USED_PREFIX]Info&quot;</li>
    ''' </ul></p>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmMessageHeaderPrefix">Property LanguageXML.MsgBox_LxmMessageHeaderPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal Type As MessageType, ByVal Buttons As Windows.Forms.MessageBoxButtons) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetMessageBoxText(MessageName)
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(Type)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons)
    End Function
    ' including Placeholder-Replace
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a defined Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="Type">the MessageType to use for Title-Selection (remember to set MsgBox_LxmMessageHeaderPrefix for this)</param>
    ''' <param name="ReplaceThis">the String that should be replaced in MessageText</param>
    ''' <param name="ReplaceWith">the String that should be inserted in MessageText</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name (without the prefix) with processed Value and a Default-Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmMessageHeaderPrefix = &quot;msg_title_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter Type = &quot;MessageType.Confirm&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_title_Confirm&quot;</li>
    ''' </ul></p></example>
    ''' <p>It is required that you have created Items for the Default-Titles with the correct Name within the Language-Items to use it.<br />
    ''' (correct Name: Items using the defined prefix for MessageBox-Titles with the below defined Strings appended as Item-Name)</p>
    ''' <p>The Definition for the Default-Names of the Language-Items used by the Class:
    ''' <ul><li>MessageType.Confirm = &quot;[USED_PREFIX]Confirm&quot;</li>
    ''' <li>MessageType.Critical = &quot;[USED_PREFIX]Critical&quot;</li>
    ''' <li>MessageType.ErrorMessage = &quot;[USED_PREFIX]Error&quot;</li>
    ''' <li>MessageType.Warning = &quot;[USED_PREFIX]Warning&quot;</li>
    ''' <li>MessageType.Info = &quot;[USED_PREFIX]Info&quot;</li>
    ''' </ul></p>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmMessageHeaderPrefix">Property LanguageXML.MsgBox_LxmMessageHeaderPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal Type As MessageType, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal ReplaceThis As String, ByVal ReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(ReplaceThis, ReplaceWith))
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(Type)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons)
    End Function
    ''' <summary>
    ''' display a MessageBox without the need to request the Language-Items by custom code - using a defined Title and Placeholder-Replace...
    ''' </summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="Type">the MessageType to use for Title-Selection (remember to set MsgBox_LxmMessageHeaderPrefix for this)</param>
    ''' <param name="ReplaceData">List of ReplaceData-Elements for the MessageText</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name (without the prefix) with processed Value and a Default-Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmMessageHeaderPrefix = &quot;msg_title_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter Type = &quot;MessageType.Confirm&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_title_Confirm&quot;</li>
    ''' </ul></p></example>
    ''' <p>It is required that you have created Items for the Default-Titles with the correct Name within the Language-Items to use it.<br />
    ''' (correct Name: Items using the defined prefix for MessageBox-Titles with the below defined Strings appended as Item-Name)</p>
    ''' <p>The Definition for the Default-Names of the Language-Items used by the Class:
    ''' <ul><li>MessageType.Confirm = &quot;[USED_PREFIX]Confirm&quot;</li>
    ''' <li>MessageType.Critical = &quot;[USED_PREFIX]Critical&quot;</li>
    ''' <li>MessageType.ErrorMessage = &quot;[USED_PREFIX]Error&quot;</li>
    ''' <li>MessageType.Warning = &quot;[USED_PREFIX]Warning&quot;</li>
    ''' <li>MessageType.Info = &quot;[USED_PREFIX]Info&quot;</li>
    ''' </ul></p>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmMessageHeaderPrefix">Property LanguageXML.MsgBox_LxmMessageHeaderPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal Type As MessageType, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal ReplaceData As List(Of ReplaceElements)) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(ReplaceData))
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(Type)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons)
    End Function
    ''' <summary>
    ''' display a MessageBox without the need to request the Language-Items by custom code - using a defined Title and Placeholder-Replace...
    ''' </summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="Type">the MessageType to use for Title-Selection (remember to set MsgBox_LxmMessageHeaderPrefix for this)</param>
    ''' <param name="ReplaceData">ReplaceData Array</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name (without the prefix) with processed Value and a Default-Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmMessageHeaderPrefix = &quot;msg_title_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter Type = &quot;MessageType.Confirm&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_title_Confirm&quot;</li>
    ''' </ul></p></example>
    ''' <p>It is required that you have created Items for the Default-Titles with the correct Name within the Language-Items to use it.<br />
    ''' (correct Name: Items using the defined prefix for MessageBox-Titles with the below defined Strings appended as Item-Name)</p>
    ''' <p>The Definition for the Default-Names of the Language-Items used by the Class:
    ''' <ul><li>MessageType.Confirm = &quot;[USED_PREFIX]Confirm&quot;</li>
    ''' <li>MessageType.Critical = &quot;[USED_PREFIX]Critical&quot;</li>
    ''' <li>MessageType.ErrorMessage = &quot;[USED_PREFIX]Error&quot;</li>
    ''' <li>MessageType.Warning = &quot;[USED_PREFIX]Warning&quot;</li>
    ''' <li>MessageType.Info = &quot;[USED_PREFIX]Info&quot;</li>
    ''' </ul></p>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmMessageHeaderPrefix">Property LanguageXML.MsgBox_LxmMessageHeaderPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal Type As MessageType, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal ReplaceData As ReplaceElements()) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, ReplaceData)
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(Type)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons)
    End Function

#End Region

#Region " custom Title "

    ' no Placeholder-Replace
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox using Item-Name for Message and a custom Title (Item-Names without prefix).
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetMessageBoxText(MessageName)
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(TitleName)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons)
    End Function

    ' including Placeholder-Replace in Message-Text
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="ReplaceThis">the String that should be replaced</param>
    ''' <param name="ReplaceWith">the String that should be inserted</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and a custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal ReplaceThis As String, ByVal ReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(ReplaceThis, ReplaceWith))
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(TitleName)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="ReplaceData">List of ReplaceData-Elements</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and a custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal ReplaceData As List(Of ReplaceElements)) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(ReplaceData))
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(TitleName)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="ReplaceData">ReplaceData Array</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and a custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal ReplaceData As ReplaceElements()) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, ReplaceData)
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(TitleName)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons)
    End Function

    ' including Placeholder-Replace in Message-Text and Title
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="TextReplaceThis">the String that should be replaced in Message-Text</param>
    ''' <param name="TextReplaceWith">the String that should be inserted in Message-Text</param>
    ''' <param name="TitleReplaceThis">the String that should be replaced in Message-Title</param>
    ''' <param name="TitleReplaceWith">the String that should be inserted Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal TextReplaceThis As String, ByVal TextReplaceWith As String, ByVal TitleReplaceThis As String, ByVal TitleReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(TextReplaceThis, TextReplaceWith))
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, _lxmlBase.GetReplaceArray(TitleReplaceThis, TitleReplaceWith))
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="TextReplaceData">List of ReplaceData-Elements for Message-Text</param>
    ''' <param name="TitleReplaceData">List of ReplaceData-Elements for Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal TextReplaceData As List(Of ReplaceElements), ByVal TitleReplaceData As List(Of ReplaceElements)) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(TextReplaceData))
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, _lxmlBase.GetReplaceArray(TitleReplaceData))
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="TextReplaceData">ReplaceData Array for Message-Text</param>
    ''' <param name="TitleReplaceData">ReplaceData Array for Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal TextReplaceData As ReplaceElements(), ByVal TitleReplaceData As ReplaceElements()) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, TextReplaceData)
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, TitleReplaceData)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="TextReplaceData">List of ReplaceData-Elements for Message-Text</param>
    ''' <param name="TitleReplaceThis">the String that should be replaced in Message-Title</param>
    ''' <param name="TitleReplaceWith">the String that should be inserted Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal TextReplaceData As List(Of ReplaceElements), ByVal TitleReplaceThis As String, ByVal TitleReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(TextReplaceData))
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, _lxmlBase.GetReplaceArray(TitleReplaceThis, TitleReplaceWith))
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="TextReplaceData">ReplaceData Array for Message-Text</param>
    ''' <param name="TitleReplaceThis">the String that should be replaced in Message-Title</param>
    ''' <param name="TitleReplaceWith">the String that should be inserted Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal TextReplaceData As ReplaceElements(), ByVal TitleReplaceThis As String, ByVal TitleReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, TextReplaceData)
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, _lxmlBase.GetReplaceArray(TitleReplaceThis, TitleReplaceWith))
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons)
    End Function

#End Region

#End Region

#Region " Group for supported MessageBox.Show Overload Type 3 - all variants "

#Region " Default-Tile "

    ' no Placeholder-Replace
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a defined Title...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="Type">the MessageType to use for Title-Selection (remember to set MsgBox_LxmMessageHeaderPrefix for this)</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox using Item-Name (without the prefix) and a Default-Title.
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmMessageHeaderPrefix = &quot;msg_title_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter Type = &quot;MessageType.Confirm&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_title_Confirm&quot;</li>
    ''' </ul></p></example>
    ''' <p>It is required that you have created Items for the Default-Titles with the correct Name within the Language-Items to use it.<br />
    ''' (correct Name: Items using the defined prefix for MessageBox-Titles with the below defined Strings appended as Item-Name)</p>
    ''' <p>The Definition for the Default-Names of the Language-Items used by the Class:
    ''' <ul><li>MessageType.Confirm = &quot;[USED_PREFIX]Confirm&quot;</li>
    ''' <li>MessageType.Critical = &quot;[USED_PREFIX]Critical&quot;</li>
    ''' <li>MessageType.ErrorMessage = &quot;[USED_PREFIX]Error&quot;</li>
    ''' <li>MessageType.Warning = &quot;[USED_PREFIX]Warning&quot;</li>
    ''' <li>MessageType.Info = &quot;[USED_PREFIX]Info&quot;</li>
    ''' </ul></p>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmMessageHeaderPrefix">Property LanguageXML.MsgBox_LxmMessageHeaderPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal Type As MessageType, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetMessageBoxText(MessageName)
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(Type)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon)
    End Function
    ' including Placeholder-Replace
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a defined Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="Type">the MessageType to use for Title-Selection (remember to set MsgBox_LxmMessageHeaderPrefix for this)</param>
    ''' <param name="ReplaceThis">the String that should be replaced in MessageText</param>
    ''' <param name="ReplaceWith">the String that should be inserted in MessageText</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name (without the prefix) with processed Value and a Default-Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmMessageHeaderPrefix = &quot;msg_title_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter Type = &quot;MessageType.Confirm&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_title_Confirm&quot;</li>
    ''' </ul></p></example>
    ''' <p>It is required that you have created Items for the Default-Titles with the correct Name within the Language-Items to use it.<br />
    ''' (correct Name: Items using the defined prefix for MessageBox-Titles with the below defined Strings appended as Item-Name)</p>
    ''' <p>The Definition for the Default-Names of the Language-Items used by the Class:
    ''' <ul><li>MessageType.Confirm = &quot;[USED_PREFIX]Confirm&quot;</li>
    ''' <li>MessageType.Critical = &quot;[USED_PREFIX]Critical&quot;</li>
    ''' <li>MessageType.ErrorMessage = &quot;[USED_PREFIX]Error&quot;</li>
    ''' <li>MessageType.Warning = &quot;[USED_PREFIX]Warning&quot;</li>
    ''' <li>MessageType.Info = &quot;[USED_PREFIX]Info&quot;</li>
    ''' </ul></p>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmMessageHeaderPrefix">Property LanguageXML.MsgBox_LxmMessageHeaderPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal Type As MessageType, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal ReplaceThis As String, ByVal ReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(ReplaceThis, ReplaceWith))
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(Type)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon)
    End Function
    ''' <summary>
    ''' display a MessageBox without the need to request the Language-Items by custom code - using a defined Title and Placeholder-Replace...
    ''' </summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="Type">the MessageType to use for Title-Selection (remember to set MsgBox_LxmMessageHeaderPrefix for this)</param>
    ''' <param name="ReplaceData">List of ReplaceData-Elements for the MessageText</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name (without the prefix) with processed Value and a Default-Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmMessageHeaderPrefix = &quot;msg_title_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter Type = &quot;MessageType.Confirm&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_title_Confirm&quot;</li>
    ''' </ul></p></example>
    ''' <p>It is required that you have created Items for the Default-Titles with the correct Name within the Language-Items to use it.<br />
    ''' (correct Name: Items using the defined prefix for MessageBox-Titles with the below defined Strings appended as Item-Name)</p>
    ''' <p>The Definition for the Default-Names of the Language-Items used by the Class:
    ''' <ul><li>MessageType.Confirm = &quot;[USED_PREFIX]Confirm&quot;</li>
    ''' <li>MessageType.Critical = &quot;[USED_PREFIX]Critical&quot;</li>
    ''' <li>MessageType.ErrorMessage = &quot;[USED_PREFIX]Error&quot;</li>
    ''' <li>MessageType.Warning = &quot;[USED_PREFIX]Warning&quot;</li>
    ''' <li>MessageType.Info = &quot;[USED_PREFIX]Info&quot;</li>
    ''' </ul></p>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmMessageHeaderPrefix">Property LanguageXML.MsgBox_LxmMessageHeaderPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal Type As MessageType, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal ReplaceData As List(Of ReplaceElements)) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(ReplaceData))
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(Type)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon)
    End Function
    ''' <summary>
    ''' display a MessageBox without the need to request the Language-Items by custom code - using a defined Title and Placeholder-Replace...
    ''' </summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="Type">the MessageType to use for Title-Selection (remember to set MsgBox_LxmMessageHeaderPrefix for this)</param>
    ''' <param name="ReplaceData">ReplaceData Array</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name (without the prefix) with processed Value and a Default-Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmMessageHeaderPrefix = &quot;msg_title_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter Type = &quot;MessageType.Confirm&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_title_Confirm&quot;</li>
    ''' </ul></p></example>
    ''' <p>It is required that you have created Items for the Default-Titles with the correct Name within the Language-Items to use it.<br />
    ''' (correct Name: Items using the defined prefix for MessageBox-Titles with the below defined Strings appended as Item-Name)</p>
    ''' <p>The Definition for the Default-Names of the Language-Items used by the Class:
    ''' <ul><li>MessageType.Confirm = &quot;[USED_PREFIX]Confirm&quot;</li>
    ''' <li>MessageType.Critical = &quot;[USED_PREFIX]Critical&quot;</li>
    ''' <li>MessageType.ErrorMessage = &quot;[USED_PREFIX]Error&quot;</li>
    ''' <li>MessageType.Warning = &quot;[USED_PREFIX]Warning&quot;</li>
    ''' <li>MessageType.Info = &quot;[USED_PREFIX]Info&quot;</li>
    ''' </ul></p>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmMessageHeaderPrefix">Property LanguageXML.MsgBox_LxmMessageHeaderPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal Type As MessageType, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal ReplaceData As ReplaceElements()) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, ReplaceData)
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(Type)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon)
    End Function

#End Region

#Region " custom Title "

    ' no Placeholder-Replace
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox using Item-Name for Message and a custom Title (Item-Names without prefix).
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetMessageBoxText(MessageName)
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(TitleName)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon)
    End Function

    ' including Placeholder-Replace in Message-Text
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="ReplaceThis">the String that should be replaced</param>
    ''' <param name="ReplaceWith">the String that should be inserted</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and a custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal ReplaceThis As String, ByVal ReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(ReplaceThis, ReplaceWith))
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(TitleName)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="ReplaceData">List of ReplaceData-Elements</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and a custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal ReplaceData As List(Of ReplaceElements)) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(ReplaceData))
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(TitleName)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="ReplaceData">ReplaceData Array</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and a custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal ReplaceData As ReplaceElements()) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, ReplaceData)
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(TitleName)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon)
    End Function

    ' including Placeholder-Replace in Message-Text and Title
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="TextReplaceThis">the String that should be replaced in Message-Text</param>
    ''' <param name="TextReplaceWith">the String that should be inserted in Message-Text</param>
    ''' <param name="TitleReplaceThis">the String that should be replaced in Message-Title</param>
    ''' <param name="TitleReplaceWith">the String that should be inserted Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal TextReplaceThis As String, ByVal TextReplaceWith As String, ByVal TitleReplaceThis As String, ByVal TitleReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(TextReplaceThis, TextReplaceWith))
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, _lxmlBase.GetReplaceArray(TitleReplaceThis, TitleReplaceWith))
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="TextReplaceData">List of ReplaceData-Elements for Message-Text</param>
    ''' <param name="TitleReplaceData">List of ReplaceData-Elements for Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal TextReplaceData As List(Of ReplaceElements), ByVal TitleReplaceData As List(Of ReplaceElements)) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(TextReplaceData))
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, _lxmlBase.GetReplaceArray(TitleReplaceData))
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="TextReplaceData">ReplaceData Array for Message-Text</param>
    ''' <param name="TitleReplaceData">ReplaceData Array for Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal TextReplaceData As ReplaceElements(), ByVal TitleReplaceData As ReplaceElements()) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, TextReplaceData)
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, TitleReplaceData)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="TextReplaceData">List of ReplaceData-Elements for Message-Text</param>
    ''' <param name="TitleReplaceThis">the String that should be replaced in Message-Title</param>
    ''' <param name="TitleReplaceWith">the String that should be inserted Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal TextReplaceData As List(Of ReplaceElements), ByVal TitleReplaceThis As String, ByVal TitleReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(TextReplaceData))
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, _lxmlBase.GetReplaceArray(TitleReplaceThis, TitleReplaceWith))
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="TextReplaceData">ReplaceData Array for Message-Text</param>
    ''' <param name="TitleReplaceThis">the String that should be replaced in Message-Title</param>
    ''' <param name="TitleReplaceWith">the String that should be inserted Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal TextReplaceData As ReplaceElements(), ByVal TitleReplaceThis As String, ByVal TitleReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, TextReplaceData)
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, _lxmlBase.GetReplaceArray(TitleReplaceThis, TitleReplaceWith))
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon)
    End Function

#End Region

#End Region

#Region " Group for supported MessageBox.Show Overload Type 4 - all variants "

#Region " Default-Tile "

    ' no Placeholder-Replace
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a defined Title...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="DefaultButton">the DefaultButton to use</param>
    ''' <param name="Type">the MessageType to use for Title-Selection (remember to set MsgBox_LxmMessageHeaderPrefix for this)</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox using Item-Name (without the prefix) and a Default-Title.
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmMessageHeaderPrefix = &quot;msg_title_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter Type = &quot;MessageType.Confirm&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_title_Confirm&quot;</li>
    ''' </ul></p></example>
    ''' <p>It is required that you have created Items for the Default-Titles with the correct Name within the Language-Items to use it.<br />
    ''' (correct Name: Items using the defined prefix for MessageBox-Titles with the below defined Strings appended as Item-Name)</p>
    ''' <p>The Definition for the Default-Names of the Language-Items used by the Class:
    ''' <ul><li>MessageType.Confirm = &quot;[USED_PREFIX]Confirm&quot;</li>
    ''' <li>MessageType.Critical = &quot;[USED_PREFIX]Critical&quot;</li>
    ''' <li>MessageType.ErrorMessage = &quot;[USED_PREFIX]Error&quot;</li>
    ''' <li>MessageType.Warning = &quot;[USED_PREFIX]Warning&quot;</li>
    ''' <li>MessageType.Info = &quot;[USED_PREFIX]Info&quot;</li>
    ''' </ul></p>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmMessageHeaderPrefix">Property LanguageXML.MsgBox_LxmMessageHeaderPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal Type As MessageType, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal DefaultButton As Windows.Forms.MessageBoxDefaultButton) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetMessageBoxText(MessageName)
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(Type)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon, DefaultButton)
    End Function
    ' including Placeholder-Replace
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a defined Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="Type">the MessageType to use for Title-Selection (remember to set MsgBox_LxmMessageHeaderPrefix for this)</param>
    ''' <param name="ReplaceThis">the String that should be replaced in MessageText</param>
    ''' <param name="ReplaceWith">the String that should be inserted in MessageText</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name (without the prefix) with processed Value and a Default-Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmMessageHeaderPrefix = &quot;msg_title_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter Type = &quot;MessageType.Confirm&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_title_Confirm&quot;</li>
    ''' </ul></p></example>
    ''' <p>It is required that you have created Items for the Default-Titles with the correct Name within the Language-Items to use it.<br />
    ''' (correct Name: Items using the defined prefix for MessageBox-Titles with the below defined Strings appended as Item-Name)</p>
    ''' <p>The Definition for the Default-Names of the Language-Items used by the Class:
    ''' <ul><li>MessageType.Confirm = &quot;[USED_PREFIX]Confirm&quot;</li>
    ''' <li>MessageType.Critical = &quot;[USED_PREFIX]Critical&quot;</li>
    ''' <li>MessageType.ErrorMessage = &quot;[USED_PREFIX]Error&quot;</li>
    ''' <li>MessageType.Warning = &quot;[USED_PREFIX]Warning&quot;</li>
    ''' <li>MessageType.Info = &quot;[USED_PREFIX]Info&quot;</li>
    ''' </ul></p>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmMessageHeaderPrefix">Property LanguageXML.MsgBox_LxmMessageHeaderPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal Type As MessageType, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal DefaultButton As Windows.Forms.MessageBoxDefaultButton, ByVal ReplaceThis As String, ByVal ReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(ReplaceThis, ReplaceWith))
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(Type)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon, DefaultButton)
    End Function
    ''' <summary>
    ''' display a MessageBox without the need to request the Language-Items by custom code - using a defined Title and Placeholder-Replace...
    ''' </summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="Type">the MessageType to use for Title-Selection (remember to set MsgBox_LxmMessageHeaderPrefix for this)</param>
    ''' <param name="ReplaceData">List of ReplaceData-Elements for the MessageText</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name (without the prefix) with processed Value and a Default-Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmMessageHeaderPrefix = &quot;msg_title_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter Type = &quot;MessageType.Confirm&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_title_Confirm&quot;</li>
    ''' </ul></p></example>
    ''' <p>It is required that you have created Items for the Default-Titles with the correct Name within the Language-Items to use it.<br />
    ''' (correct Name: Items using the defined prefix for MessageBox-Titles with the below defined Strings appended as Item-Name)</p>
    ''' <p>The Definition for the Default-Names of the Language-Items used by the Class:
    ''' <ul><li>MessageType.Confirm = &quot;[USED_PREFIX]Confirm&quot;</li>
    ''' <li>MessageType.Critical = &quot;[USED_PREFIX]Critical&quot;</li>
    ''' <li>MessageType.ErrorMessage = &quot;[USED_PREFIX]Error&quot;</li>
    ''' <li>MessageType.Warning = &quot;[USED_PREFIX]Warning&quot;</li>
    ''' <li>MessageType.Info = &quot;[USED_PREFIX]Info&quot;</li>
    ''' </ul></p>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmMessageHeaderPrefix">Property LanguageXML.MsgBox_LxmMessageHeaderPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal Type As MessageType, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal DefaultButton As Windows.Forms.MessageBoxDefaultButton, ByVal ReplaceData As List(Of ReplaceElements)) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(ReplaceData))
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(Type)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon, DefaultButton)
    End Function
    ''' <summary>
    ''' display a MessageBox without the need to request the Language-Items by custom code - using a defined Title and Placeholder-Replace...
    ''' </summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="Type">the MessageType to use for Title-Selection (remember to set MsgBox_LxmMessageHeaderPrefix for this)</param>
    ''' <param name="ReplaceData">ReplaceData Array</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name (without the prefix) with processed Value and a Default-Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmMessageHeaderPrefix = &quot;msg_title_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter Type = &quot;MessageType.Confirm&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_title_Confirm&quot;</li>
    ''' </ul></p></example>
    ''' <p>It is required that you have created Items for the Default-Titles with the correct Name within the Language-Items to use it.<br />
    ''' (correct Name: Items using the defined prefix for MessageBox-Titles with the below defined Strings appended as Item-Name)</p>
    ''' <p>The Definition for the Default-Names of the Language-Items used by the Class:
    ''' <ul><li>MessageType.Confirm = &quot;[USED_PREFIX]Confirm&quot;</li>
    ''' <li>MessageType.Critical = &quot;[USED_PREFIX]Critical&quot;</li>
    ''' <li>MessageType.ErrorMessage = &quot;[USED_PREFIX]Error&quot;</li>
    ''' <li>MessageType.Warning = &quot;[USED_PREFIX]Warning&quot;</li>
    ''' <li>MessageType.Info = &quot;[USED_PREFIX]Info&quot;</li>
    ''' </ul></p>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmMessageHeaderPrefix">Property LanguageXML.MsgBox_LxmMessageHeaderPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal Type As MessageType, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal DefaultButton As Windows.Forms.MessageBoxDefaultButton, ByVal ReplaceData As ReplaceElements()) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, ReplaceData)
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(Type)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon, DefaultButton)
    End Function

#End Region

#Region " custom Title "

    ' no Placeholder-Replace
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="DefaultButton">the DefaultButton to use</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox using Item-Name for Message and a custom Title (Item-Names without prefix).
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal DefaultButton As Windows.Forms.MessageBoxDefaultButton) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetMessageBoxText(MessageName)
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(TitleName)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon, DefaultButton)
    End Function

    ' including Placeholder-Replace in Message-Text
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="DefaultButton">the DefaultButton to use</param>
    ''' <param name="ReplaceThis">the String that should be replaced</param>
    ''' <param name="ReplaceWith">the String that should be inserted</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and a custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal DefaultButton As Windows.Forms.MessageBoxDefaultButton, ByVal ReplaceThis As String, ByVal ReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(ReplaceThis, ReplaceWith))
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(TitleName)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon, DefaultButton)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="DefaultButton">the DefaultButton to use</param>
    ''' <param name="ReplaceData">List of ReplaceData-Elements</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and a custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal DefaultButton As Windows.Forms.MessageBoxDefaultButton, ByVal ReplaceData As List(Of ReplaceElements)) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(ReplaceData))
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(TitleName)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon, DefaultButton)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="DefaultButton">the DefaultButton to use</param>
    ''' <param name="ReplaceData">ReplaceData Array</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and a custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal DefaultButton As Windows.Forms.MessageBoxDefaultButton, ByVal ReplaceData As ReplaceElements()) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, ReplaceData)
        Dim _title As String = _lxmlBase.GetMessageBoxTitle(TitleName)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon, DefaultButton)
    End Function

    ' including Placeholder-Replace in Message-Text and Title
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="DefaultButton">the DefaultButton to use</param>
    ''' <param name="TextReplaceThis">the String that should be replaced in Message-Text</param>
    ''' <param name="TextReplaceWith">the String that should be inserted in Message-Text</param>
    ''' <param name="TitleReplaceThis">the String that should be replaced in Message-Title</param>
    ''' <param name="TitleReplaceWith">the String that should be inserted Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal DefaultButton As Windows.Forms.MessageBoxDefaultButton, ByVal TextReplaceThis As String, ByVal TextReplaceWith As String, ByVal TitleReplaceThis As String, ByVal TitleReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(TextReplaceThis, TextReplaceWith))
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, _lxmlBase.GetReplaceArray(TitleReplaceThis, TitleReplaceWith))
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon, DefaultButton)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="DefaultButton">the DefaultButton to use</param>
    ''' <param name="TextReplaceData">List of ReplaceData-Elements for Message-Text</param>
    ''' <param name="TitleReplaceData">List of ReplaceData-Elements for Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal DefaultButton As Windows.Forms.MessageBoxDefaultButton, ByVal TextReplaceData As List(Of ReplaceElements), ByVal TitleReplaceData As List(Of ReplaceElements)) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(TextReplaceData))
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, _lxmlBase.GetReplaceArray(TitleReplaceData))
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon, DefaultButton)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="DefaultButton">the DefaultButton to use</param>
    ''' <param name="TextReplaceData">ReplaceData Array for Message-Text</param>
    ''' <param name="TitleReplaceData">ReplaceData Array for Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal DefaultButton As Windows.Forms.MessageBoxDefaultButton, ByVal TextReplaceData As ReplaceElements(), ByVal TitleReplaceData As ReplaceElements()) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, TextReplaceData)
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, TitleReplaceData)
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon, DefaultButton)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="DefaultButton">the DefaultButton to use</param>
    ''' <param name="TextReplaceData">List of ReplaceData-Elements for Message-Text</param>
    ''' <param name="TitleReplaceThis">the String that should be replaced in Message-Title</param>
    ''' <param name="TitleReplaceWith">the String that should be inserted Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal DefaultButton As Windows.Forms.MessageBoxDefaultButton, ByVal TextReplaceData As List(Of ReplaceElements), ByVal TitleReplaceThis As String, ByVal TitleReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, _lxmlBase.GetReplaceArray(TextReplaceData))
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, _lxmlBase.GetReplaceArray(TitleReplaceThis, TitleReplaceWith))
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon, DefaultButton)
    End Function
    ''' <summary>display a MessageBox without the need to request the Language-Items by custom code - using a custom Title and Placeholder-Replace...</summary>
    ''' <param name="MessageName">the Item-Name for the Message (must be without prefix if it is set in the class-properties --> MsgBox_LxmMessageTextPrefix)</param>
    ''' <param name="TitleName">the Item-Name for the custom Title (must be without prefix if it is set in the class-properties --> MsgBox_LxmlTitleItemPrefix)</param>
    ''' <param name="Buttons">the Button(s) to display</param>
    ''' <param name="Icon">the Icon to display</param>
    ''' <param name="DefaultButton">the DefaultButton to use</param>
    ''' <param name="TextReplaceData">ReplaceData Array for Message-Text</param>
    ''' <param name="TitleReplaceThis">the String that should be replaced in Message-Title</param>
    ''' <param name="TitleReplaceWith">the String that should be inserted Message-Title</param>
    ''' <returns>the Result of the internal used MessageBox.Show()...</returns>
    ''' <remarks>This overload is used if you want to display a MessageBox by Item-Name with processed Value for the Message and the custom Title...
    ''' <example><p>Settings:
    ''' <ul><li>Class-Property MsgBox_LxmlTitleItemPrefix = &quot;msg_ctitle_&quot;</li>
    ''' <li>Class-Property MsgBox_LxmMessageTextPrefix = &quot;msg_text_&quot;</li>
    ''' <li>Function-Parameter MessageName = &quot;TestConfirm&quot;</li>
    ''' <li>Function-Parameter TitleName = &quot;TestTitle&quot;</li></ul></p>
    ''' <p>Result:
    ''' <ul><li>Language-Item for Message that is loaded: &quot;msg_text_TestConfirm&quot;</li>
    ''' <li>Language-Item for Title that is loaded: &quot;msg_ctitle_TestTitle&quot;</li>
    ''' </ul></p></example>
    ''' <seealso cref="MessageType">Enumeration LanguageXML.MessageType</seealso>
    ''' <seealso cref="MsgBox_LxmlTitleItemPrefix">Property LanguageXML.MsgBox_LxmlTitleItemPrefix</seealso>
    ''' <seealso cref="MsgBox_LxmMessageTextPrefix">Property LanguageXML.MsgBox_LxmMessageTextPrefix</seealso>
    ''' <seealso cref="ReadProcessedValue">Function LanguageXML.ReadProcessedValue</seealso>
    ''' </remarks>
    Public Function MessageBox(ByVal MessageName As String, ByVal TitleName As String, ByVal Buttons As Windows.Forms.MessageBoxButtons, ByVal Icon As Windows.Forms.MessageBoxIcon, ByVal DefaultButton As Windows.Forms.MessageBoxDefaultButton, ByVal TextReplaceData As ReplaceElements(), ByVal TitleReplaceThis As String, ByVal TitleReplaceWith As String) As System.Windows.Forms.DialogResult
        Dim _msg As String = _lxmlBase.GetProcessedMessageBoxText(MessageName, TextReplaceData)
        Dim _title As String = _lxmlBase.GetProcessedMessageBoxTitle(TitleName, _lxmlBase.GetReplaceArray(TitleReplaceThis, TitleReplaceWith))
        Return System.Windows.Forms.MessageBox.Show(_msg, _title, Buttons, Icon, DefaultButton)
    End Function

#End Region

#End Region

#End Region

End Class