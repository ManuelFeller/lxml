' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |   Language XML Editor  |   http://lxml.codeplex.com   |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

''' <summary>Class to save Data as File in Format-Version 2</summary>
Friend Class clsFileWriterV2

    ''' <summary>internal reference to the clsEditorBase</summary>
    Private _editor As clsEditorBase

    ''' <summary>internal reference for the FileName</summary>
    Private _fileName As String

    ''' <summary>internal XML-Document</summary>
    Private _xDoc As System.Xml.XmlDocument

    ''' <summary>init Class</summary>
    ''' <param name="Data">referenced running clsEditorBase</param>
    ''' <param name="File">referenced FileName</param>
    Public Sub New(ByRef Data As clsEditorBase, ByRef File As String)
        _editor = Data
        _fileName = File
    End Sub

    ''' <summary>save the Data in Editor to File</summary>
    ''' <returns>TRUE on success, FASLE on error</returns>
    Public Function SaveFile() As Boolean
        ' create document, declaration and root-element
        _xDoc = New System.Xml.XmlDocument
        Dim _xDeclare As System.Xml.XmlDeclaration = _xDoc.CreateXmlDeclaration("1.0", "UTF-8", "yes")
        Dim _xRoot As System.Xml.XmlElement = _xDoc.CreateElement("lxml")
        _xDoc.AppendChild(_xDeclare)
        _xDoc.AppendChild(_xRoot)
        ' create objects for Main-Elements in Root and append to document
        Dim _xVersion As System.Xml.XmlElement = _xDoc.CreateElement("version")
        Dim _xFileMeta As System.Xml.XmlElement = _xDoc.CreateElement("file")
        Dim _xLanguages As System.Xml.XmlElement = _xDoc.CreateElement("languages")
        Dim _xItems As System.Xml.XmlElement = _xDoc.CreateElement("items")
        _xRoot.AppendChild(_xVersion)
        _xRoot.AppendChild(_xFileMeta)
        _xRoot.AppendChild(_xLanguages)
        _xRoot.AppendChild(_xItems)
        ' save version-info
        _xVersion.SetAttribute("major", "2")
        _xVersion.SetAttribute("minor", "0")
        ' save File-Meta-Data
        _xFileMeta.SetAttribute("program", _editor.OpenFileMetaData.Program)
        _xFileMeta.SetAttribute("description", _editor.OpenFileMetaData.Description)
        _xFileMeta.SetAttribute("lastupdate", _editor.OpenFileMetaData.LastUpdate.ToString(System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat))
        ' save LanguageList
        Dim _lAssign As New List(Of _LangInfo)
        If Not _SaveLanguageList(_xLanguages, _lAssign) Then Return False ' if language-node could not be created then fail
        ' save language-items
        If Not _SaveLanguageItems(_xItems, _lAssign) Then Return False ' if value-node could not be created then fail
        ' save to file
        Try
            _xDoc.Save(_fileName)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, MsgBox(ex.Message, MsgBoxStyle.Exclamation, frmMain.cLangXML.ReadValue("msg_title_Error")))
            Return False
        End Try
        Return True
    End Function

    ' internal worker and objects

    Private Class _LangInfo
        Public ID As String
        Public Name As String
        Public Sub New()
            ID = ""
            Name = ""
        End Sub
    End Class

    Private Function _SaveLanguageList(ByRef _element As System.Xml.XmlElement, ByRef _AssignInfo As List(Of _LangInfo)) As Boolean
        Dim _lang As List(Of String) = _editor.GetInternalLanguageNamesList ' read languages
        Dim _tmp As _LangInfo
        Dim _tab As String
        Dim _xElem As System.Xml.XmlElement
        _AssignInfo = New List(Of _LangInfo)
        For Each _langName As String In _lang ' for each language
            ' create Assign-info
            _tmp = New _LangInfo
            _tmp.ID = _AssignInfo.Count.ToString
            _tmp.Name = _langName
            ' "build" tablename
            _tab = Declarations.LXML_DataSet.Tables.LangData.NamePrefix & _langName
            ' create element
            _xElem = _xDoc.CreateElement("language")
            ' fill element
            _xElem.SetAttribute("id", _tmp.ID)
            If _tmp.Name = Declarations.LXML_DataSet.Tables.DefaultLang.InternalName Then
                _xElem.SetAttribute("name", _tmp.Name.ToLower) ' set DEFAULT to lower case
            Else ' "regular" language
                _xElem.SetAttribute("name", _tmp.Name) ' set DEFAULT to lower case
            End If
            _xElem.SetAttribute("iso", _editor.GetLangValueByID(Declarations.MetaData.Language.Fields.IsoString.Name, _tab, False))
            _xElem.SetAttribute("displayname", _editor.GetLangValueByID(Declarations.MetaData.Language.Fields.DisplayName.Name, _tab, False))
            _xElem.SetAttribute("author", _editor.GetLangValueByID(Declarations.MetaData.Language.Fields.Author.Name, _tab, False))
            _xElem.SetAttribute("version", _editor.GetLangValueByID(Declarations.MetaData.Language.Fields.Version.Name, _tab, False))
            _xElem.SetAttribute("info", _editor.GetLangValueByID(Declarations.MetaData.Language.Fields.InfoText.Name, _tab, False))
            _xElem.SetAttribute("lastupdate", _editor.GetLangValueByID(Declarations.MetaData.Language.Fields.lastUpdate.Name, _tab, False))
            ' append XML-Item to its parent
            _element.AppendChild(_xElem)
            ' save assig-info
            _AssignInfo.Add(_tmp)
        Next
        Return True
    End Function

    Private Function _SaveLanguageItems(ByRef _element As System.Xml.XmlElement, ByRef _AssignInfo As List(Of _LangInfo)) As Boolean
        Dim _tmpBase As System.Xml.XmlElement
        Dim _tmpSub As System.Xml.XmlElement
        Dim _tmpValue As String
        Dim _tmpId As String
        For Each _row As DataRow In _editor.LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.ItemData.Name).Rows
            ' for each item in data:
            ' create base-item
            _tmpId = _row.Item(Declarations.LXML_DataSet.Tables.ItemData.Columns.iID.Name).ToString
            _tmpBase = _xDoc.CreateElement("item")
            _tmpBase.SetAttribute("id", _tmpId)
            _tmpBase.SetAttribute("name", _row.Item(Declarations.LXML_DataSet.Tables.ItemData.Columns.iName.Name).ToString)
            _tmpBase.SetAttribute("description", _row.Item(Declarations.LXML_DataSet.Tables.ItemData.Columns.iDescription.Name).ToString)
            ' set values for languages
            For Each _lang As _LangInfo In _AssignInfo ' for each language try to read value
                _tmpValue = _editor.GetLangValueByID(_tmpId, Declarations.LXML_DataSet.Tables.LangData.NamePrefix & _lang.Name, False)
                If _tmpValue <> "" Then ' if Value is not empty
                    ' create value-item
                    _tmpSub = _xDoc.CreateElement("language")
                    ' fill item
                    _tmpSub.SetAttribute("id", _lang.ID) ' LanguageID
                    _tmpSub.SetAttribute("value", _tmpValue) ' Value
                    ' append language-value to item
                    _tmpBase.AppendChild(_tmpSub)
                End If
            Next
            ' add item to output
            _element.AppendChild(_tmpBase)
        Next
        Return True
    End Function

End Class