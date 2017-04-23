''' <summary>Class for the basic Editor-Functions and Data-Handling</summary>
''' <remarks>depends on a running frmMain that "Hosts" the Application</remarks>
Friend Class clsEditorBase

#Region " Objects and EventHandler for the Class "

    ''' <summary>
    ''' the DataSet for the File-Data
    ''' </summary>
    Public LXML_DataSet As DataSet

    ''' <summary>
    ''' Handler-Class for MetaData of a open File
    ''' </summary>
    Public WithEvents OpenFileMetaData As clsFileMetaData

    ''' <summary>
    ''' Event-Handler for changed File-MetaData
    ''' </summary>
    Private Sub FileMetaDataLastUpdateChanged() Handles OpenFileMetaData.UpDateChanged
        For Each _form As System.Windows.Forms.Form In frmMain.MdiChildren ' if form is open, then refresh dispalyed Data
            If _form.Name = "frmBaseData" Then ' form is open
                Dim _tmp As frmBaseData = _form
                _tmp.PerformMetaUpDate()
            End If
        Next
    End Sub

    ''' <summary>reminder for the FormatVersion of the open file</summary>
    Private _OpenFileVersion As Integer = 0

    ''' <summary>Format-Version of open file (0 if no file, 1 or 2 if version was detected)</summary>
    Public Property OpenFileVersion() As Integer
        Get
            Return _OpenFileVersion
        End Get
        Set(ByVal value As Integer)
            _OpenFileVersion = value
        End Set
    End Property

#End Region

#Region " Construct & Init "

    ''' <summary>
    ''' constructor - initializes DataSet
    ''' </summary>
    Public Sub New()
        OpenFileMetaData = New clsFileMetaData
        Me.BaseInitDataSet()
    End Sub

    ''' <summary>
    ''' initialize the DataSet to a "new File"
    ''' </summary>
    Public Sub BaseInitDataSet()
        ' Das DataSet initialisieren:
        Me.LXML_DataSet = Nothing
        Me.LXML_DataSet = New DataSet("LanguageXML")

        ' MetaData erstellen
        ' ------------------
        ' Spalten erzeugen:
        Dim colMetaValue As New DataColumn ' Spalte mit Name des Feld
        colMetaValue.ColumnName = Declarations.LXML_DataSet.Tables.MetaData.Columns.mValue.Name
        colMetaValue.DataType = System.Type.GetType("System.String")
        Dim colMetaData As New DataColumn ' Spalte mit Wert des Feld
        colMetaData.ColumnName = Declarations.LXML_DataSet.Tables.MetaData.Columns.mData.Name
        colMetaData.DataType = System.Type.GetType("System.String")
        ' Spalten zu neuer Tabelle hinzufügen
        Dim tblMetaData As New DataTable(Declarations.LXML_DataSet.Tables.MetaData.Name)
        tblMetaData.Columns.Add(colMetaValue)
        tblMetaData.Columns.Add(colMetaData)
        ' Tabelle zum Datensatz hinzufügen
        Me.LXML_DataSet.Tables.Add(tblMetaData)

        ' ItemData erstellen
        ' ------------------
        ' Spalten erzeugen:
        Dim colItemId As New DataColumn ' Spalte mit ID des Feld
        colItemId.ColumnName = Declarations.LXML_DataSet.Tables.ItemData.Columns.iID.Name
        colItemId.DataType = System.Type.GetType("System.Int32")
        colItemId.Unique = True ' muss einmalig sein
        colItemId.AllowDBNull = False ' muss ein Wert sein
        colItemId.AutoIncrement = True
        Dim colItemName As New DataColumn ' Spalte mit Name des Feld
        colItemName.ColumnName = Declarations.LXML_DataSet.Tables.ItemData.Columns.iName.Name
        colItemName.DataType = System.Type.GetType("System.String")
        colItemName.Unique = True ' muss einmalig sein
        Dim colItemDescr As New DataColumn ' Spalte mit Beschreibung des Feld
        colItemDescr.ColumnName = Declarations.LXML_DataSet.Tables.ItemData.Columns.iDescription.Name
        colItemDescr.DataType = System.Type.GetType("System.String")
        ' Spalten zu neuer Tabelle hinzufügen
        Dim tblItemData As New DataTable(Declarations.LXML_DataSet.Tables.ItemData.Name)
        tblItemData.Columns.Add(colItemId)
        tblItemData.Columns.Add(colItemName)
        tblItemData.Columns.Add(colItemDescr)
        ' Tabelle zum Datensatz hinzufügen
        Me.LXML_DataSet.Tables.Add(tblItemData)

        ' DEFAULT-SprachTabelle erstellen
        ' -------------------------------
        ' Spalten erzeugen:
        Dim colLangID As New DataColumn ' Spalte mit ID des Feld
        colLangID.ColumnName = Declarations.LXML_DataSet.Tables.LangData.Columns.lID.Name
        colLangID.DataType = System.Type.GetType("System.String")
        colLangID.Unique = True
        Dim colLangData As New DataColumn ' Spalte mit Wert des Feld
        colLangData.ColumnName = Declarations.LXML_DataSet.Tables.LangData.Columns.lValue.Name
        colLangData.DataType = System.Type.GetType("System.String")
        ' Spalten zu neuer Tabelle hinzufügen
        Dim tblLang_DEFAULT As New DataTable(Declarations.LXML_DataSet.Tables.LangData.NamePrefix & Declarations.LXML_DataSet.Tables.DefaultLang.InternalName)

        tblLang_DEFAULT.Columns.Add(colLangID)
        tblLang_DEFAULT.Columns.Add(colLangData)
        ' Tabelle zum Datensatz hinzufügen
        Me.LXML_DataSet.Tables.Add(tblLang_DEFAULT)

        ' Datensatz initialisiert...
    End Sub

#End Region

#Region " File-Handling "

    '''' <summary>
    '''' load a LXML-File
    '''' </summary>
    '''' <param name="FilePath">Full path to the File to load</param>
    '''' <returns>TRUE on success, FALSE on error</returns>
    'Public Function LoadXmlLangFile(ByVal FilePath As String) As Boolean
    '    ' load a LXML-File to edit
    '    Me.BaseInitDataSet() ' (re)-init DataSet


    '    Dim _fileContent As String ' content of .lxml file
    '    Try
    '        _fileContent = System.IO.File.ReadAllText(FilePath, System.Text.Encoding.UTF8)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, frmMain.cLangXML.ReadValue("msg_title_Error"))
    '        Return False
    '    End Try
    '    ' load Data into TextReader for DataSet
    '    Dim _dsData As System.IO.TextReader = New System.IO.StringReader(_fileContent)

    '    ' apply data to dataset
    '    Try
    '        'Me.LXML_DataSet.ReadXml(FilePath)
    '        Me.LXML_DataSet.ReadXml(_dsData)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, frmMain.cLangXML.ReadValue("msg_title_Error"))
    '    End Try

    '    Dim _langTables As New List(Of String) ' List for additional Language-Tables
    '    For Each _row As DataRow In Me.LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.MetaData.Name).Rows ' check Meta-Data
    '        If _row.RowState <> DataRowState.Deleted And _row.RowState <> DataRowState.Detached Then
    '            If _row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mValue.Name) = Declarations.MetaData.File.Fields.NewLangTable.Name.Name Then ' if MetaName matches Language-Table-Info
    '                _langTables.Add(_row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mData.Name).ToString) ' add Table to List
    '            End If
    '        End If
    '    Next
    '    If _langTables.Count > 0 Then
    '        ' tables have to be craeted:
    '        Me.BaseInitDataSet() ' re-init the DataSet
    '        ' add additional tables that are needed to load all languages
    '        For Each _tabName As String In _langTables
    '            Me._CreateNewLangTable(_tabName, False)
    '        Next
    '        ' now load the file again with the correct defined dataset...
    '        _dsData = New System.IO.StringReader(_fileContent) ' re-set the reader
    '        Try
    '            'Me.LXML_DataSet.ReadXml(FilePath)
    '            Me.LXML_DataSet.ReadXml(_dsData)
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Exclamation, frmMain.cLangXML.ReadValue("msg_title_Error"))
    '            Return False
    '        End Try
    '    End If
    '    ' commit changes in DataSet
    '    Me.LXML_DataSet.AcceptChanges()
    '    ' read Meta-Data-Values for the File
    '    OpenFileMetaData = New clsFileMetaData
    '    For Each _row As DataRow In frmMain.cEditor.LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.MetaData.Name).Rows
    '        Select Case _row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mValue.Name)
    '            Case Declarations.MetaData.File.Fields.Program.Name ' new (correct spelled) value for program-field
    '                OpenFileMetaData.Program = _row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mData.Name).ToString
    '            Case Declarations.MetaData.File.Fields.Program_old.Name ' old (wrong spelled) value for program-field
    '                OpenFileMetaData.Program = _row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mData.Name).ToString
    '            Case Declarations.MetaData.File.Fields.Description.Name
    '                OpenFileMetaData.Description = _row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mData.Name).ToString
    '            Case Declarations.MetaData.File.Fields.LastUpdate.Name
    '                OpenFileMetaData.ApplyLastUpdate(_row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mData.Name).ToString)
    '        End Select
    '    Next
    '    OpenFileMetaData.AcceptChanges() ' accept changes to FileMetaData from File...
    '    Return True
    'End Function

#Region " FileLoader "

    ''' <summary>
    ''' load a LXML-File
    ''' </summary>
    ''' <param name="FilePath">Full path to the File to load</param>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Public Function LoadLanguageXmlFile(ByVal FilePath As String) As Boolean
        ' read data of file
        Dim _fileContent As String ' content of .lxml file
        Try
            _fileContent = System.IO.File.ReadAllText(FilePath, System.Text.Encoding.UTF8) ' read as UTF-8
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "LanguageXML Error:")
            Return False
        End Try

        Dim _tmpXDoc As New System.Xml.XmlDocument
        _tmpXDoc.InnerXml = _fileContent ' read data into Document
        Dim _res As Boolean = False
        If _tmpXDoc.HasChildNodes Then ' check document for type (version) - identify by root-element
            For Each _child As System.Xml.XmlNode In _tmpXDoc.ChildNodes
                Select Case _child.Name.ToLower
                    Case "languagexml" ' Version 1 - XML-DataSet
                        _res = _FileLoader_Version1(_fileContent)
                        _OpenFileVersion = 1
                    Case "lxml" ' Version two - (L)XML-Format
                        _res = _FileLoader_Version2(_child)
                        _OpenFileVersion = 2
                    Case "xml"
                        ' declaration - do nothing
                    Case Else ' unknown root-element
                        MsgBox("Unknown Root-Element in File...", MsgBoxStyle.Exclamation, "LanguageXML Error:")
                        _OpenFileVersion = 0
                        _res = False
                End Select
            Next
        End If

        If _res Then
            ' commit changes in DataSet
            Me.LXML_DataSet.AcceptChanges()
            ' read Meta-Data-Values for the File
            OpenFileMetaData = New clsFileMetaData
            For Each _row As DataRow In frmMain.cEditor.LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.MetaData.Name).Rows
                Select Case _row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mValue.Name)
                    Case Declarations.MetaData.File.Fields.Program.Name ' new (correct spelled) value for program-field
                        OpenFileMetaData.Program = _row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mData.Name).ToString
                    Case Declarations.MetaData.File.Fields.Program_old.Name ' old (wrong spelled) value for program-field
                        OpenFileMetaData.Program = _row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mData.Name).ToString
                    Case Declarations.MetaData.File.Fields.Description.Name
                        OpenFileMetaData.Description = _row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mData.Name).ToString
                    Case Declarations.MetaData.File.Fields.LastUpdate.Name
                        OpenFileMetaData.ApplyLastUpdate(_row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mData.Name).ToString)
                End Select
            Next
            OpenFileMetaData.AcceptChanges() ' accept changes to FileMetaData from File...
        Else ' no file opened
            _OpenFileVersion = 0
        End If
        ' return result of load
        Return _res
    End Function

#Region " Version 1 "

    Private Function _FileLoader_Version1(ByRef _fileData As String) As Boolean
        '' Sprachdaten-Datei laden
        BaseInitDataSet() ' Datensatz leeren und initialisieren

        ' load Data into TextReader for DataSet
        Dim _dsData As System.IO.TextReader = New System.IO.StringReader(_fileData)

        Try
            LXML_DataSet.ReadXml(_dsData)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "LanguageXML Error:")
            Return False
        End Try
        Dim i As Integer
        Dim LanguageTables() As String = {""}
        Dim Cnt As Integer = -1
        For i = 0 To LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.MetaData.Name).Rows.Count - 1
            If LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.MetaData.Name).Rows(i).Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mValue.Name).ToString = Declarations.MetaData.File.Fields.NewLangTable.Name Then
                ' Wenn Tabellen-Name gefunden, dann diesen zur Liste hinzufügen
                Cnt += 1
                ReDim Preserve LanguageTables(Cnt)
                LanguageTables(Cnt) = LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.MetaData.Name).Rows(i).Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mData.Name).ToString
            End If
        Next
        If Cnt > -1 Then
            ' es müssen Tabellen im Datensatz erzeugt werden:
            For i = 0 To UBound(LanguageTables)
                Me._CreateNewLangTable(LanguageTables(i), False)
            Next
            ' erneutes Laden der Daten
            LXML_DataSet.Clear()
            _dsData = New System.IO.StringReader(_fileData) ' re-iint text-reader
            Try
                LXML_DataSet.ReadXml(_dsData)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "LanguageXML Error:")
                Return False
            End Try
        End If
        Return True
    End Function

#End Region

#Region " Version 2 "

    Private Function _FileLoader_Version2(ByRef _rootElement As System.Xml.XmlNode) As Boolean
        Dim _versionElement As System.Xml.XmlElement
        Dim _fileElement As System.Xml.XmlElement
        Dim _languagesElement As System.Xml.XmlElement
        Dim _itemsElement As System.Xml.XmlElement

        If _rootElement.HasChildNodes Then ' there are Items inside
            For Each _element As System.Xml.XmlElement In _rootElement.ChildNodes ' check each item for type
                Select Case _element.Name.ToLower ' identify by name
                    Case "version"
                        _versionElement = _element
                    Case "file"
                        _fileElement = _element
                    Case "languages"
                        _languagesElement = _element
                    Case "items"
                        _itemsElement = _element
                End Select
            Next
        End If

        ' check version
        If Not _FileReaderV2_CheckVersion(_versionElement) Then Return False ' wrong version

        ' check file-meta
        Dim _fileMeta As List(Of _FrV2_MetaItem) = _FileReaderV2_FileMetaData(_fileElement) ' initialize Meta-Values for file
        'If _fileMeta.Count = 0 Then Return False ' DEBUG: no meta-items found --> no check needed in productive use because this is not really needed for a working file...

        ' check languages
        Dim _LangData As List(Of _FrV2_LanguageMeta) = _FileReaderV2_FileLanguages(_languagesElement)
        If _LangData.Count = 0 Then Return False ' no languages in file - exit false

        ' add languages to file-meta --> not needed for read - must not be saved again --> use code for editor...
        Dim _tmpMeta As _FrV2_MetaItem
        For Each _lang As _FrV2_LanguageMeta In _LangData ' check each language
            If _lang.InternalName <> "DEFAULT" Then ' if not default-language, then add to List of Tables to be generated
                _tmpMeta = New _FrV2_MetaItem ' create new Meta-Item
                _tmpMeta.ItemName = Declarations.MetaData.File.Fields.NewLangTable.Name ' item for new language-table
                _tmpMeta.ItemValue = Declarations.LXML_DataSet.Tables.LangData.NamePrefix & _lang.InternalName ' value for the item
                _fileMeta.Add(_tmpMeta) ' add meta-entry to data
            End If
        Next

        ' load items

        Return _FileReaderV2_LoadToTables(_itemsElement, _fileMeta, _LangData)


    End Function

    ' objects and worker

    Private Class _FrV2_MetaItem

        Public ItemName As String
        Public ItemValue As String

        Public Sub New()
            ItemName = ""
            ItemValue = ""
        End Sub

    End Class

    Private Class _FrV2_LanguageMeta

        Public InternalName As String
        Public LanguageId As String
        Public Values As List(Of _FrV2_MetaItem)

        Public Sub New()
            InternalName = ""
            LanguageId = ""
            Values = New List(Of _FrV2_MetaItem)
        End Sub

    End Class

    ' process version-info
    Private Function _FileReaderV2_CheckVersion(ByRef _versionElement As System.Xml.XmlElement) As Boolean
        If IsNothing(_versionElement) Then Return False

        ' check major version
        If _versionElement.GetAttribute("major").Trim <> "2" Then
            Return False
        End If
        '_versionElement.GetAttribute("minor") --> minor version just add values --> display info (if active) later

        Return True
    End Function

    ' process File Meta-Data
    Private Function _FileReaderV2_FileMetaData(ByRef _fileMetaElement As System.Xml.XmlElement) As List(Of _FrV2_MetaItem)
        Dim _res As New List(Of _FrV2_MetaItem)
        If IsNothing(_fileMetaElement) Then Return _res

        Dim _tmpItem As _FrV2_MetaItem ' init tmp-item
        ' build meta-values from attributes

        ' program
        _tmpItem = New _FrV2_MetaItem
        _tmpItem.ItemName = "programm"
        _tmpItem.ItemValue = _fileMetaElement.GetAttribute("program")
        _res.Add(_tmpItem)

        ' description
        _tmpItem = New _FrV2_MetaItem
        _tmpItem.ItemName = "description"
        _tmpItem.ItemValue = _fileMetaElement.GetAttribute("description")
        _res.Add(_tmpItem)

        ' last update
        _tmpItem = New _FrV2_MetaItem
        _tmpItem.ItemName = "update"
        _tmpItem.ItemValue = _fileMetaElement.GetAttribute("lastupdate")
        _res.Add(_tmpItem)

        Return _res
    End Function

    ' process Languages
    Private Function _FileReaderV2_FileLanguages(ByRef _languageElement As System.Xml.XmlElement) As List(Of _FrV2_LanguageMeta)
        Dim _res As New List(Of _FrV2_LanguageMeta)
        If IsNothing(_languageElement) Then Return _res
        ' needed results: 
        ' list of languages
        ' id for each language
        ' list of language-metadata
        Dim _tmpResItem As _FrV2_LanguageMeta
        Dim _tmpListItem As _FrV2_MetaItem
        Dim _tmpName As String
        If _languageElement.HasChildNodes Then
            For Each _lang As System.Xml.XmlElement In _languageElement.ChildNodes
                _tmpResItem = New _FrV2_LanguageMeta
                ' add control-items
                _tmpName = _lang.GetAttribute("name")
                If _tmpName.ToLower = "default" Then ' if default-language
                    _tmpResItem.InternalName = "DEFAULT" ' set name in upper case
                Else ' other language
                    _tmpResItem.InternalName = _tmpName
                End If
                _tmpResItem.LanguageId = _lang.GetAttribute("id")

                ' add items for data-table
                _tmpListItem = New _FrV2_MetaItem
                _tmpListItem.ItemName = "author"
                _tmpListItem.ItemValue = _lang.GetAttribute("author")
                _tmpResItem.Values.Add(_tmpListItem)

                _tmpListItem = New _FrV2_MetaItem
                _tmpListItem.ItemName = "name"
                _tmpListItem.ItemValue = _lang.GetAttribute("displayname")
                _tmpResItem.Values.Add(_tmpListItem)

                _tmpListItem = New _FrV2_MetaItem
                _tmpListItem.ItemName = "info"
                _tmpListItem.ItemValue = _lang.GetAttribute("info")
                _tmpResItem.Values.Add(_tmpListItem)

                _tmpListItem = New _FrV2_MetaItem
                _tmpListItem.ItemName = "iso"
                _tmpListItem.ItemValue = _lang.GetAttribute("iso")
                _tmpResItem.Values.Add(_tmpListItem)

                _tmpListItem = New _FrV2_MetaItem
                _tmpListItem.ItemName = "update"
                _tmpListItem.ItemValue = _lang.GetAttribute("lastupdate")
                _tmpResItem.Values.Add(_tmpListItem)

                _tmpListItem = New _FrV2_MetaItem
                _tmpListItem.ItemName = "version"
                _tmpListItem.ItemValue = _lang.GetAttribute("version")
                _tmpResItem.Values.Add(_tmpListItem)

                _res.Add(_tmpResItem)
            Next
        End If



        Return _res
    End Function

    ' load items
    Private Function _FileReaderV2_LoadToTables(ByRef _itemsElement As System.Xml.XmlElement, ByRef _fileMeta As List(Of _FrV2_MetaItem), ByRef _LangData As List(Of _FrV2_LanguageMeta)) As Boolean
        If IsNothing(_itemsElement) Then Return False ' no data passed
        If Not _itemsElement.HasChildNodes Then Return False ' no items found

        BaseInitDataSet() ' initialize DataSet
        ' fill file-meta Table
        Dim _tmpRow As DataRow
        For Each _item As _FrV2_MetaItem In _fileMeta
            _tmpRow = LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.MetaData.Name).NewRow
            _tmpRow.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mValue.Name) = _item.ItemName
            _tmpRow.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mData.Name) = _item.ItemValue
            Try
                LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.MetaData.Name).Rows.Add(_tmpRow)
            Catch ex As Exception
                Return False
            End Try
        Next

        ' fill basic data for languages
        For Each _lang As _FrV2_LanguageMeta In _LangData ' check each language
            If _lang.InternalName <> "DEFAULT" Then ' if not default-language, then generate needed table
                Me._CreateNewLangTable(Declarations.LXML_DataSet.Tables.LangData.NamePrefix & _lang.InternalName, False)
            End If
            ' fill meta-data values of table
            For Each _item As _FrV2_MetaItem In _lang.Values
                _tmpRow = LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.LangData.NamePrefix & _lang.InternalName).NewRow
                _tmpRow.Item(Declarations.LXML_DataSet.Tables.LangData.Columns.lID.Name) = _item.ItemName
                _tmpRow.Item(Declarations.LXML_DataSet.Tables.LangData.Columns.lValue.Name) = _item.ItemValue
                Try
                    LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.LangData.NamePrefix & _lang.InternalName).Rows.Add(_tmpRow)
                Catch ex As Exception
                    Return False
                End Try
            Next
        Next
        ' read items from XML-Element
        For Each _item As System.Xml.XmlElement In _itemsElement.ChildNodes ' check children
            If _item.Name.ToLower = "item" Then ' if valid container
                ' fill item-data
                _tmpRow = LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.ItemData.Name).NewRow
                _tmpRow.Item(Declarations.LXML_DataSet.Tables.ItemData.Columns.iID.Name) = Integer.Parse(_item.GetAttribute("id"))
                _tmpRow.Item(Declarations.LXML_DataSet.Tables.ItemData.Columns.iName.Name) = _item.GetAttribute("name")
                _tmpRow.Item(Declarations.LXML_DataSet.Tables.ItemData.Columns.iDescription.Name) = _item.GetAttribute("description")
                Try ' try to add (id or name may be present twice)
                    LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.ItemData.Name).Rows.Add(_tmpRow)
                Catch ex As Exception
                    Return False
                End Try
                ' fill languages (using sub-function)
                If Not _FileReaderV2_FillLanguages(_item, _LangData) Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    ' load values
    Private Function _FileReaderV2_FillLanguages(ByRef _langItemsElement As System.Xml.XmlElement, ByRef _LangData As List(Of _FrV2_LanguageMeta)) As Boolean
        'If IsNothing(_langItemsElement) Then Return False ' no items inside --> not needed because called from foreach...
        Dim _tmpTabName As String
        Dim _tmpRow As DataRow
        If _langItemsElement.HasChildNodes Then ' if item has (language-?)values 
            For Each _item As System.Xml.XmlElement In _langItemsElement.ChildNodes
                If _item.Name.ToLower = "language" Then
                    ' "search" table-name by id
                    _tmpTabName = ""
                    For Each _lang As _FrV2_LanguageMeta In _LangData
                        If _lang.LanguageId = _item.GetAttribute("id") Then
                            _tmpTabName = Declarations.LXML_DataSet.Tables.LangData.NamePrefix & _lang.InternalName
                            Exit For
                        End If
                    Next
                    ' if Table-name was found, apply value to dataset
                    If _tmpTabName <> "" Then
                        _tmpRow = LXML_DataSet.Tables(_tmpTabName).NewRow
                        _tmpRow.Item(Declarations.LXML_DataSet.Tables.LangData.Columns.lID.Name) = _langItemsElement.GetAttribute("id") ' get id form base-item
                        _tmpRow.Item(Declarations.LXML_DataSet.Tables.LangData.Columns.lValue.Name) = _item.GetAttribute("value") ' get value from language-item
                        Try
                            LXML_DataSet.Tables(_tmpTabName).Rows.Add(_tmpRow)
                        Catch ex As Exception
                            Return False
                        End Try
                    End If
                End If
            Next
        End If
        Return True
    End Function


#End Region

#End Region

#End Region

#Region " Data-Handling "

#Region " save Data "

    ''' <summary>
    ''' save a Language-Value in Table
    ''' </summary>
    ''' <param name="ValueId">the ID for the Language-Item</param>
    ''' <param name="ValueData">the Value for the Language-Item</param>
    ''' <param name="LangTable">the Table with Langugae-Data to use</param>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Public Function SaveLangValue(ByVal ValueId As String, ByVal ValueData As String, ByVal LangTable As String) As Boolean
        ' eine Sprach-Datenzeile einer Sprache speichern --> aktualisieren oder neu hinzufügen
        'Dim i As Integer
        Dim FoundAndUpdated As Boolean = False

        Dim RowNum As Integer = Me._SearchRowInTab(LangTable, Declarations.LXML_DataSet.Tables.LangData.Columns.lID.Name, ValueId) ' Zeile suchen
        If RowNum <> -1 Then ' gefunden
            ' Versuchen, den Wert zu speichern
            Try
                Me.LXML_DataSet.Tables(LangTable).Rows(RowNum).Item(Declarations.LXML_DataSet.Tables.LangData.Columns.lValue.Name) = ValueData
            Catch ex As Exception
                ' bei Fehler melden und Ende
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, frmMain.cLangXML.ReadValue("msg_title_Error"))
                Return False
            End Try
            FoundAndUpdated = True ' Update erfolgreich - merken
        End If

        ' prüfen, ob Wert neu hinzugefügt werden muss
        If Not FoundAndUpdated Then
            ' Wert als neue Zeile hinzufügen
            Dim newLangCol As DataRow = Me.LXML_DataSet.Tables(LangTable).NewRow
            newLangCol.Item(Declarations.LXML_DataSet.Tables.LangData.Columns.lID.Name) = ValueId
            newLangCol.Item(Declarations.LXML_DataSet.Tables.LangData.Columns.lValue.Name) = ValueData
            Try
                Me.LXML_DataSet.Tables(LangTable).Rows.Add(newLangCol)
            Catch ex As Exception
                ' bei Fehler melden und Ende
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, frmMain.cLangXML.ReadValue("msg_title_Error"))
                Return False
            End Try
            ' Wert hinzugefügt...
        End If
        Return True
    End Function

    ''' <summary>
    ''' save a MetaData-Value
    ''' </summary>
    ''' <param name="ValueName">Name for the Value</param>
    ''' <param name="ValueData">String-Content for the Value</param>
    ''' <param name="OldValue">optional old String-Content for multiple values lke LanguageTables</param>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Public Function SaveMetaValue(ByVal ValueName As String, ByVal ValueData As String, Optional ByVal OldValue As String = "") As Boolean
        ' eine Meta-Datenzeile speichern --> aktualisieren oder neu hinzufügen
        Dim _foundAndUpdated As Boolean = False
        Dim _row As DataRow
        If OldValue <> "" Then
            ' Sonderfall: Wert kann mehrfach vorkommen - nach altem wert suchen
            If OldValue <> Declarations.MetaData.NewMultiValue Then
                ' nur suchen, wenn nicht neuer Multi-Wert
                For Each _row In Me.LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.MetaData.Name).Rows
                    If _row.RowState <> DataRowState.Deleted And _row.RowState <> DataRowState.Detached Then
                        ' alle Zeilen durchsuchen
                        If _row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mValue.Name) = ValueName And _row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mData.Name) = OldValue Then
                            ' Versuchen, den Wert zu speichern
                            Try
                                _row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mData.Name) = ValueData
                            Catch ex As Exception
                                ' bei Fehler melden und Ende
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, frmMain.cLangXML.ReadValue("msg_title_Error"))
                                Return False
                            End Try
                            _foundAndUpdated = True ' Update erfolgreich - merken
                            Exit For ' For verlassen
                        End If
                    End If
                Next
            End If
        Else ' einzelwert
            For Each _row In Me.LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.MetaData.Name).Rows
                ' alle Zeilen durchsuchen
                If _row.RowState <> DataRowState.Deleted And _row.RowState <> DataRowState.Detached Then
                    If _row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mValue.Name) = ValueName Then
                        ' Versuchen, den Wert zu speichern
                        Try
                            _row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mData.Name) = ValueData
                        Catch ex As Exception
                            ' bei Fehler melden und Ende
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation, frmMain.cLangXML.ReadValue("msg_title_Error"))
                            Return False
                        End Try
                        _foundAndUpdated = True ' Update erfolgreich - merken
                        Exit For ' For verlassen
                    End If
                End If
            Next
        End If
        ' prüfen, ob Wert neu hinzugefügt werden muss
        If Not _foundAndUpdated Then
            ' Wert als neue Zeile hinzufügen
            Dim newMetaCol As DataRow = Me.LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.MetaData.Name).NewRow
            newMetaCol.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mValue.Name) = ValueName
            newMetaCol.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mData.Name) = ValueData
            Try
                Me.LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.MetaData.Name).Rows.Add(newMetaCol)
            Catch ex As Exception
                ' bei Fehler melden und Ende
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, frmMain.cLangXML.ReadValue("msg_title_Error"))
                Return False
            End Try
            ' Wert hinzugefügt...
        End If
        Return True
    End Function

#End Region

#Region " read Data "

    ''' <summary>
    ''' get a Language-Value by ID
    ''' </summary>
    ''' <param name="ValueId">the ID for the Item to get</param>
    ''' <param name="LangTable">the Language-Table to use</param>
    ''' <param name="DefaultFallback">optional set to TRUE to deactivate Auto-Fallback</param>
    ''' <returns>the Value for the Item</returns>
    Public Function GetLangValueByID(ByVal ValueId As String, ByVal LangTable As String, Optional ByVal DefaultFallback As Boolean = False) As String
        ' eine Sprach-Datenzeile einer Sprache per ID laden --> wenn nicht vorhanden, Optional Rückgabe aus Default-Sprache
        Dim RowNum As Integer = Me._SearchRowInTab(LangTable, Declarations.LXML_DataSet.Tables.LangData.Columns.lID.Name, ValueId) ' Zeile suchen
        If RowNum = -1 Then ' nicht gefunden
            If DefaultFallback Then ' wenn Default-Wert-Fallback erwünscht
                RowNum = Me._SearchRowInTab(Declarations.LXML_DataSet.Tables.LangData.NamePrefix & Declarations.LXML_DataSet.Tables.DefaultLang.InternalName, Declarations.LXML_DataSet.Tables.LangData.Columns.lID.Name, ValueId)
                If RowNum <> -1 Then ' Zeile gefunden
                    Return Me.LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.LangData.NamePrefix & Declarations.LXML_DataSet.Tables.DefaultLang.InternalName).Rows(RowNum).Item(Declarations.LXML_DataSet.Tables.LangData.Columns.lValue.Name).ToString
                End If
            End If
        Else ' Zeile gefunden
            Return Me.LXML_DataSet.Tables(LangTable).Rows(RowNum).Item(Declarations.LXML_DataSet.Tables.LangData.Columns.lValue.Name).ToString
        End If
        Return "" ' nix gefunden...
    End Function

    ''' <summary>
    ''' get a Language-Value by Name
    ''' </summary>
    ''' <param name="ValueName">the Name for the Item to get</param>
    ''' <param name="LangTable">the Language-Table to use</param>
    ''' <param name="DefaultFallback">optional set to TRUE to deactivate Auto-Fallback</param>
    ''' <returns>the Value for the Item</returns>
    Public Function GetLangValueByName(ByVal ValueName As String, ByVal LangTable As String, Optional ByVal DefaultFallback As Boolean = False) As String
        ' eine Sprach-Datenzeile einer Sprache per Name laden --> wenn nicht vorhanden, Optional Rückgabe aus Default-Sprache
        '
        ' Name Suchen und in ID übersetzen
        Dim FoundValue As String = ""
        Dim RowNum As Integer = Me._SearchRowInTab(Declarations.LXML_DataSet.Tables.ItemData.Name, Declarations.LXML_DataSet.Tables.ItemData.Columns.iName.Name, ValueName)
        If RowNum > -1 Then ' Zeile wurde gefunden - ID übernehmen
            FoundValue = Me.LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.ItemData.Name).Rows(RowNum).Item(Declarations.LXML_DataSet.Tables.ItemData.Columns.iID.Name).ToString
        Else ' Zeile wurde nicht gefunden
            Return ""
        End If
        ' über ID laden
        Return Me.GetLangValueByID(FoundValue, LangTable, DefaultFallback)
    End Function

    ''' <summary>
    ''' get the List of available Languages in the DataSet
    ''' </summary>
    ''' <returns>List of String contaning the internal Names of the available Languages</returns>
    Public Function GetInternalLanguageNamesList() As List(Of String)
        Dim _intResult As New List(Of String)
        For Each _table As DataTable In Me.LXML_DataSet.Tables
            ' Sprach-Tabelle:
            If _table.TableName.StartsWith(Declarations.LXML_DataSet.Tables.LangData.NamePrefix) Then
                _intResult.Add(_table.TableName.Substring(Declarations.LXML_DataSet.Tables.LangData.NamePrefix.Length))
            End If
        Next
        Return _intResult
    End Function

#End Region

#Region " delete Data "

    ''' <summary>
    ''' delete a Language-Item from the DataSet (Item and Values)
    ''' </summary>
    ''' <param name="ItemID">ID for the Item to delete</param>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Public Function DeleteLanguageItemFromDataSet(ByVal ItemID As Integer) As Boolean
        ' Zeile in den Items löschen...
        If Not Me._DeleteLanguageBaseItem(ItemID) Then ' delete Item-Base
            ' Info?
            Return False
        End If
        If Not Me._DeleteLanguageValueItem(ItemID) Then ' delete Language-Values
            ' Info?
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' delete the Language-Value for a ID in a defined Language-Tables
    ''' </summary>
    ''' <param name="ValueId">ID for the Item to delete</param>
    ''' <param name="LangTable">Name for the Language-Table to use</param>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Public Function DeleteLangValueByID(ByVal ValueId As String, ByVal LangTable As String) As Boolean
        ' eine Sprach-Datenzeile einer Sprache per ID löschen
        Dim RowNum As Integer = Me._SearchRowInTab(LangTable, Declarations.LXML_DataSet.Tables.LangData.Columns.lID.Name, ValueId) ' Zeile suchen
        If RowNum <> -1 Then ' Zeile gefunden
            ' löschen
            Try
                Me.LXML_DataSet.Tables(LangTable).Rows(RowNum).Delete()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, frmMain.cLangXML.ReadValue("msg_title_Error"))
                Return False ' Fehlermeldung, wenn löschen nicht möglich
            End Try
        End If
        Return True ' immer wahr, da "entfernt", wenn nicht vorhanden
    End Function

#End Region

#Region " Language-List handling "

    ''' <summary>
    ''' add a new Language to the DataSet
    ''' </summary>
    ''' <param name="InternalLanguageName">the new (internal) Name for the new Language</param>
    ''' <returns>TRUE on success, FALSE on error</returns>
    ''' <remarks>an internal Name can only contain A-Z, a-z, 0-9 or _ ...</remarks>
    Public Function AddLanguage2DataSet(ByVal InternalLanguageName As String) As Boolean

        ' hier den String prüfen auf unerlaubte Zeichen
        If Not Me._CheckNewLangName(InternalLanguageName) Then
            Return False
        End If

        Dim NewTabName As String = Declarations.LXML_DataSet.Tables.LangData.NamePrefix & InternalLanguageName
        For Each _table As DataTable In Me.LXML_DataSet.Tables
            If _table.TableName = NewTabName Then
                frmMain.cLangXML.MessageBox("IntNameNotUnique", DDPro.Software.Net20.Library.LanguageXML.MessageType.ErrorMessage)
                Return False
            End If
        Next
        ' interner Name noch nicht vorhanden --> anlegen
        If Not Me._CreateNewLangTable(NewTabName, True) Then
            frmMain.cLangXML.MessageBox("LangNotCreated", DDPro.Software.Net20.Library.LanguageXML.MessageType.ErrorMessage)
            Return False
        End If
        ' GuiUpdate
        'BindDataToGui(True) ' Daten an Gui binden - ohne die Statics der MetaDaten neu zu laden
        'LoadLangData2Gui() ' Daten der ausgewählten Sprache laden
        Return True
    End Function

    ''' <summary>
    ''' delete a Language from the DataSet
    ''' </summary>
    ''' <param name="InternalLanguageName">Internal Name for the Language without Table-Prefix</param>
    ''' <param name="IgnoreMissingTable">set to TRUE to get TRUE as result if the Language-Table could not be found</param>
    ''' <param name="IgnoreMissingMetaValue">set to TRUE to get TRUE as result if the Meta-Data could not be found</param>
    ''' <returns>TRUE on success or if configured, FALSE on error</returns>
    Public Function DeleteLanguageFromDataSet(ByVal InternalLanguageName As String, Optional ByVal IgnoreMissingTable As Boolean = False, Optional ByVal IgnoreMissingMetaValue As Boolean = False) As Boolean
        Dim _DelTabName As String = Declarations.LXML_DataSet.Tables.LangData.NamePrefix & InternalLanguageName
        Dim _DelTabRef As DataTable = Nothing
        For Each _table As DataTable In Me.LXML_DataSet.Tables
            If _table.TableName = _DelTabName Then
                _DelTabRef = _table
                Exit For
            End If
        Next
        If Not IsNothing(_DelTabRef) Then ' Table found
            Try ' try to delete table
                Me.LXML_DataSet.Tables.Remove(_DelTabRef)
            Catch ex As Exception
                ' Table could not be removed
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, frmMain.cLangXML.ReadValue("msg_title_Error"))
                Return False
            End Try
            ' still running - remove meta-info
            Return _DeleteLanguageMetaDataEntry(_DelTabName, IgnoreMissingMetaValue)
        Else ' Table not found
            If Not IgnoreMissingTable Then
                frmMain.cLangXML.MessageBox("LangTableToDelNotFound", DDPro.Software.Net20.Library.LanguageXML.MessageType.ErrorMessage)
                Return False
            End If
        End If
        Return True
    End Function

#End Region

#End Region

#Region " internal helper "

    ''' <summary>
    ''' get the Row-Index of a Row in a DataTable
    ''' </summary>
    ''' <param name="TableName">Name for the Table to scan</param>
    ''' <param name="SearchColumn">Name for the Column to scan</param>
    ''' <param name="SearchValue">Value to search</param>
    ''' <returns>RowIndex on success / match, -1 on error / not found</returns>
    Private Function _SearchRowInTab(ByVal TableName As String, ByVal SearchColumn As String, ByVal SearchValue As Object) As Integer
        ' interne Funktion zum Ermitteln einer Zeilennummer in einer Datentabelle
        Dim i As Integer
        Dim FoundRow As Integer = -1
        Dim RowCnt As Integer = -1
        Try
            RowCnt = Me.LXML_DataSet.Tables(TableName).Rows.Count - 1
        Catch ex As Exception ' may occur if table is not existing!
            Return FoundRow
        End Try
        For i = 0 To RowCnt
            ' alle Zeilen durchsuchen (aufsteigend)
            If Me.LXML_DataSet.Tables(TableName).Rows(i).RowState <> DataRowState.Deleted And Me.LXML_DataSet.Tables(TableName).Rows(i).RowState <> DataRowState.Deleted Then
                If Me.LXML_DataSet.Tables(TableName).Rows(i).Item(SearchColumn).ToString = SearchValue.ToString Then
                    ' Wert gefunden - Zeile merken...
                    FoundRow = i
                    Exit For ' For verlassen
                End If
            End If
            ' Wenn Mitte erreicht/überschritten, dann abbruch...
            If (RowCnt - i) <= i Then Exit For
            ' ggf. zugleich absteigend suchen --> schnellere Suche
            If Me.LXML_DataSet.Tables(TableName).Rows(RowCnt - i).RowState <> DataRowState.Deleted And Me.LXML_DataSet.Tables(TableName).Rows(RowCnt - i).RowState <> DataRowState.Deleted Then
                If Me.LXML_DataSet.Tables(TableName).Rows(RowCnt - i).Item(SearchColumn).ToString = SearchValue.ToString Then
                    ' Wert gefunden - Zeile merken...
                    FoundRow = RowCnt - i
                    Exit For ' For verlassen
                End If
            End If
        Next
        ' Ergebnis zurückgeben
        Return FoundRow
    End Function

    ''' <summary>
    ''' create a new Table for Language-Items in the DataSet
    ''' </summary>
    ''' <param name="TableName">full Name for the new Table (including prefix!)</param>
    ''' <param name="AddMetaData">set to TRUE to create the first Meta-Data Item(s)</param>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Private Function _CreateNewLangTable(ByVal TableName As String, ByVal AddMetaData As Boolean) As Boolean
        ' Spalten erzeugen:
        ' Spalte mit ID des Feld
        Dim colLangID As New DataColumn(Declarations.LXML_DataSet.Tables.LangData.Columns.lID.Name, System.Type.GetType("System.String"))
        colLangID.Unique = True ' einmalig
        ' Spalte mit Wert des Feld
        Dim colLangData As New DataColumn(Declarations.LXML_DataSet.Tables.LangData.Columns.lValue.Name, System.Type.GetType("System.String"))
        ' Tabelle erzeugen:
        Dim xTab As New DataTable
        xTab.Columns.Add(colLangID)
        xTab.Columns.Add(colLangData)
        ' Hinzufügen zum Datensatz
        xTab.TableName = TableName
        Try
            Me.LXML_DataSet.Tables.Add(xTab)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, frmMain.cLangXML.ReadValue("msg_title_Error"))
            Return False
        End Try
        ' Tabelle angelegt - MetaDaten-Info erzeugen und zurückgeben...
        If AddMetaData Then
            Return Me.SaveMetaValue(Declarations.MetaData.File.Fields.NewLangTable.Name, TableName, Declarations.MetaData.NewMultiValue)
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' delete the Base-Entry for the Language-Item in the Item-Table
    ''' </summary>
    ''' <param name="ID">ID of Item to delete</param>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Private Function _DeleteLanguageBaseItem(ByVal ID As Integer) As Boolean
        ' eine Sprach-Datenzeile einer Sprache per ID löschen
        Dim RowNum As Integer = Me._SearchRowInTab(Declarations.LXML_DataSet.Tables.ItemData.Name, Declarations.LXML_DataSet.Tables.ItemData.Columns.iID.Name, ID) ' Zeile suchen
        If RowNum <> -1 Then ' Zeile gefunden
            ' löschen
            Try
                Me.LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.ItemData.Name).Rows(RowNum).Delete()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, frmMain.cLangXML.ReadValue("msg_title_Error"))
                Return False ' Fehlermeldung, wenn löschen nicht möglich
            End Try
        End If
        Return True ' immer wahr, da "entfernt", wenn nicht vorhanden
    End Function

    ''' <summary>
    ''' delete the Language-Values for a ID in all Language-Tables
    ''' </summary>
    ''' <param name="ID">ID for the Item to delete</param>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Private Function _DeleteLanguageValueItem(ByVal ID As String) As Boolean
        For Each _table As DataTable In Me.LXML_DataSet.Tables
            If _table.TableName.StartsWith(Declarations.LXML_DataSet.Tables.LangData.NamePrefix) Then
                ' Sprach-Tabelle gefunden... - Wert löschen
                If Not DeleteLangValueByID(ID, _table.TableName) Then
                    Return False ' Fehler beim löschen - abbruch
                End If
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' helper for Language-Delete
    ''' </summary>
    ''' <param name="InternalTableName">Name of Language-Table that should be removed from Meta-Data</param>
    ''' <param name="IgnoreMissingValue">set to TRUE to get TRUE as result if the Meta-Data could not be found</param>
    ''' <returns>TRUE on success or if configured, FALSE on error</returns>
    Private Function _DeleteLanguageMetaDataEntry(ByVal InternalTableName As String, Optional ByVal IgnoreMissingValue As Boolean = False) As Boolean
        Dim _delRow As DataRow = Nothing
        For Each _row As DataRow In Me.LXML_DataSet.Tables(Declarations.LXML_DataSet.Tables.MetaData.Name).Rows
            If _row.RowState <> DataRowState.Deleted And _row.RowState <> DataRowState.Detached Then
                If _row.Item(Declarations.LXML_DataSet.Tables.MetaData.Columns.mValue.Name).ToString = Declarations.MetaData.File.Fields.NewLangTable.Name Then
                    _delRow = _row
                    Exit For
                End If
            End If
        Next
        If Not (IsNothing(_delRow)) Then ' row found - delete
            Try
                _delRow.Delete()
            Catch ex As Exception
                ' row could not be removed
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, frmMain.cLangXML.ReadValue("msg_title_Error"))
                Return False
            End Try
        Else ' nor row to delete found
            If Not IgnoreMissingValue Then
                frmMain.cLangXML.MessageBox("LangMetaToDelNotFound", DDPro.Software.Net20.Library.LanguageXML.MessageType.ErrorMessage)
                Return False
            End If
        End If
        Return True
    End Function

    ''' <summary>
    ''' verify if a Name can be as internal Name for a new Language (no illegal signs)
    ''' </summary>
    ''' <param name="NewName">the mane to check (without prefix)</param>
    ''' <returns>TRUE if Name is valid, FALSE on error</returns>
    Private Function _CheckNewLangName(ByVal NewName As String) As Boolean
        ' A-Z, a-z, 0-9, _ (underscore)
        Dim i As Integer ' Counter
        Dim IntSign As String
        Dim IntRes As Boolean
        For i = 0 To NewName.Length - 1
            IntSign = NewName.Substring(i, 1).ToUpper ' extract single sign as upper-char
            IntRes = False
            ' 48-57 = Numbers
            ' 95 = Underscore
            ' 65-90 = A-Z
            If Asc(IntSign) = 95 Then ' Underscore
                IntRes = True
            ElseIf Asc(IntSign) <= 57 And Asc(IntSign) >= 48 Then ' Numbers
                IntRes = True
            ElseIf Asc(IntSign) <= 90 And Asc(IntSign) >= 65 Then ' A-Z
                IntRes = True
            End If
            If Not IntRes Then
                frmMain.cLangXML.MessageBox("IllegalSignInIntLangName", DDPro.Software.Net20.Library.LanguageXML.MessageType.ErrorMessage)
                Return False
            End If
        Next
        Return True
    End Function

#End Region

End Class