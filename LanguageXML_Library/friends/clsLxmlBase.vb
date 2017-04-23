' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | LXML internal Base Class |  http://lxml.codeplex.com  |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

''' <summary>Class with the Code for the internal implementation of LanguageXML (Code behind public Class...)</summary>
Friend Class clsLxmlBase

#Region " Constructor "

    ''' <summary>Constructor - create a new Instance and initialize the internal DataSet of the Class</summary>
    ''' <remarks>This is the basic initialization for the Class. It prepares a empty DataSet in Memory...</remarks>
    Public Sub New()
        Me.BaseInitDataSet() ' create internal Dataset for this Instance
    End Sub

#End Region

#Region " class-internal, public objects "

    ' ToDo: make this properties, isolate internal objects from public

    ''' <summary>the DataSet used to handle the Data</summary>
    Public LanguageXML_DataSet As New DataSet
    ''' <summary>the active Language (internal name)</summary>
    Public SelectedLanguage As String = My.Resources.str_intname_DefaultLang
    ''' <summary>Meta-Data for the open Language-File</summary>
    Public FileMeta As New LanguageXML.fileBaseInfo
    ''' <summary>List of Language Meta-Data Items (one for each Language in File... ;-)</summary>
    Public LangMeta As New List(Of LanguageXML.langBaseInfo)

    ''' <summary>Prefix to use for user-defined MessageBox-Titles</summary>
    Public Msgbox_LxmlTitletemPrefix As String = ""
    ''' <summary>Prefix to use for pre-defined MessageBox-Titles</summary>
    Public Msgbox_LxmMessageHeaderPrefix As String = ""
    ''' <summary>Prefix to use for MessageBox - Content</summary>
    Public Msgbox_LxmMessageTextPrefix As String = ""

#End Region

#Region " basic Data-Handling "

#Region " Init and load Data "

    ''' <summary>load Language-Data from a LXML-File</summary>
    ''' <param name="filePath">full Path of the LXML-File to open</param>
    ''' <returns>TRUE if File was loaded - FALSE if there was an Error</returns>
    ''' <remarks>This Functions loads the Data for the current Instance of the Class from a Language-XML File (Version 1 and 2)</remarks>
    Public Function LoadLanguageXmlFile(ByVal filePath As String) As Boolean
        Return Me._LoadLanguageXmlFile_(filePath)
    End Function

    ''' <summary>(re-)init the Dataset used for LXML</summary>
    ''' <remarks>This is the internal Initialization of the DataSet - should be done before any Data-Related action like loading of a File is performed...</remarks>
    Public Sub BaseInitDataSet()
        ' (re-)init the DataSet
        Me.LanguageXML_DataSet = Nothing
        Me.LanguageXML_DataSet = New DataSet
        '

        ' create Table for Meta-Data
        ' --------------------------
        ' create Columns:
        Dim __colMetaValue As New DataColumn ' Column with Key (ID)
        __colMetaValue.ColumnName = My.Resources.str_xml_FileMetaCol_ID
        __colMetaValue.DataType = System.Type.GetType("System.String")
        Dim __colMetaData As New DataColumn ' Column with Value for the Key
        __colMetaData.ColumnName = My.Resources.str_xml_FileMetaCol_Value
        __colMetaData.DataType = System.Type.GetType("System.String")
        ' add Columns to (new) Table
        Dim __tblMetaData As New DataTable(My.Resources.str_xml_TableMetaData)
        __tblMetaData.Columns.Add(__colMetaValue)
        __tblMetaData.Columns.Add(__colMetaData)
        ' add Table to the DataSet
        Me.LanguageXML_DataSet.Tables.Add(__tblMetaData)

        ' create Table for Language-Items
        ' -------------------------------
        ' create Columns:
        Dim __colItemId As New DataColumn ' Column for the Value-ID (Auto-ID)
        __colItemId.ColumnName = My.Resources.str_xml_FileItemCol_ID
        __colItemId.DataType = System.Type.GetType("System.Int32")
        __colItemId.Unique = True ' must be unique
        __colItemId.AllowDBNull = False ' must contain a Value
        __colItemId.AutoIncrement = True ' auto-increment for automatic generation
        Dim __colItemName As New DataColumn ' Column for Item-Name (ID by End-User)
        __colItemName.ColumnName = My.Resources.str_xml_FileItemCol_Name
        __colItemName.DataType = System.Type.GetType("System.String")
        __colItemName.Unique = True ' must be unique
        __colItemName.AllowDBNull = False ' must contain a Value
        Dim __colItemDescr As New DataColumn ' Column for Field-Description
        __colItemDescr.ColumnName = My.Resources.str_xml_FileItemCol_Description
        __colItemDescr.DataType = System.Type.GetType("System.String")
        ' add Columns to (new) Table
        Dim __tblItemData As New DataTable(My.Resources.str_xml_TableItemData)
        __tblItemData.Columns.Add(__colItemId)
        __tblItemData.Columns.Add(__colItemName)
        __tblItemData.Columns.Add(__colItemDescr)
        ' add Table to the DataSet
        Me.LanguageXML_DataSet.Tables.Add(__tblItemData)

        ' create Table for DEFAULT-Language
        ' ---------------------------------
        ' create Columns:
        Dim __colLangID As New DataColumn ' Column for the Value-ID
        __colLangID.ColumnName = My.Resources.str_xml_LangValCol_ID
        __colLangID.DataType = System.Type.GetType("System.String")
        __colLangID.Unique = True ' must be unique
        Dim __colLangData As New DataColumn ' Column for the Value itself
        __colLangData.ColumnName = My.Resources.str_xml_LangValCol_Value
        __colLangData.DataType = System.Type.GetType("System.String")
        ' add Columns to (new) Table
        Dim __tblLang_DEFAULT As New DataTable(My.Resources.str_xml_TableLangDataPrefix & My.Resources.str_intname_DefaultLang)
        __tblLang_DEFAULT.Columns.Add(__colLangID)
        __tblLang_DEFAULT.Columns.Add(__colLangData)
        ' add Table to the DataSet
        Me.LanguageXML_DataSet.Tables.Add(__tblLang_DEFAULT)

        ' DataSet is now prepared to be used...
    End Sub

#End Region

#Region " Language - Values and PreSet "

    ''' <summary>request a Language-Value from the DataSet (using numeric ID)</summary>
    ''' <param name="valueId">the (Auto-)ID of the Value to read</param>
    ''' <param name="langTable">the Language-Table that should be used</param>
    ''' <param name="defaultFallback">set this to TRUE if you want the Value from the Default-Language in case of a missing Value in selected Language</param>
    ''' <returns>the Value that was found in the DataSet or an empty String if nothing was found...</returns>
    ''' <remarks>This Function is the basic "Value-Loader" for the Class.<br />
    ''' All other (higher) Functions make use of this or the "next higher Version" using the user-defined ID-String to load the Language-Values...</remarks>
    Public Function GetLangValueByID(ByVal valueId As String, ByVal langTable As String, Optional ByVal defaultFallback As Boolean = False) As String
        Dim __RowNum As Integer = Me.SearchRowInTab(langTable, My.Resources.str_xml_LangValCol_ID, valueId) ' search Line of Value in requested Language-Table
        If __RowNum = -1 Then ' Value not found
            If defaultFallback Then ' if Default-Fallback is activated
                ' search Line of Value in default Language-Table
                __RowNum = Me.SearchRowInTab(My.Resources.str_xml_TableLangDataPrefix & My.Resources.str_intname_DefaultLang, My.Resources.str_xml_LangValCol_ID, valueId)
                If __RowNum <> -1 Then ' Line was found
                    ' return the Value from the Line
                    Return Me.LanguageXML_DataSet.Tables(My.Resources.str_xml_TableLangDataPrefix & My.Resources.str_intname_DefaultLang).Rows(__RowNum).Item(My.Resources.str_xml_LangValCol_Value).ToString
                End If
            End If
        Else ' Value was found in request Language
            Return Me.LanguageXML_DataSet.Tables(langTable).Rows(__RowNum).Item(My.Resources.str_xml_LangValCol_Value).ToString
        End If
        Return String.Empty ' nothing found, exit empty...
    End Function

    ''' <summary>request a Language-Value from the DataSet (using user-defined Value-ID)</summary>
    ''' <param name="valueName">the user-defined ID-String of the Value to read (case-sensitive)</param>
    ''' <param name="langTable">the Language-Table that should be used</param>
    ''' <param name="defaultFallback">set this to TRUE if you want the Value from the Default-Language in case of a missing Value in selected Language</param>
    ''' <returns>the Value that was found in the DataSet or an empty String if nothing was found...</returns>
    ''' <remarks>This Function is the recommended "Value-Loader" for the Class.<br />
    ''' Editing the Language-File and its Items may cause a diffrent Auto-ID (e.g. if you delete and re-create an Item); so using this way improves the ease of use in the Client-Application and makes it a bit more stable...</remarks>
    Public Function GetLangValueByName(ByVal valueName As String, ByVal langTable As String, Optional ByVal defaultFallback As Boolean = False) As String
        ' search user-defined ID and get the Auto-ID for the Item from the Item-Definition
        Dim __FoundValue As String = "" ' init result-var
        Dim __RowNum As Integer = Me.SearchRowInTab(My.Resources.str_xml_TableItemData, My.Resources.str_xml_FileItemCol_Name, valueName) ' search the row-number in the DataTable
        If __RowNum > -1 Then ' row was found - remind Auto-ID for the Item
            __FoundValue = Me.LanguageXML_DataSet.Tables(My.Resources.str_xml_TableItemData).Rows(__RowNum).Item(My.Resources.str_xml_FileItemCol_ID).ToString
        Else ' row was not found
            Return String.Empty ' exit with empty string
        End If
        ' Auto-ID loaded - now load the Value using it and pass the result to the caller...
        Return Me.GetLangValueByID(__FoundValue, langTable, defaultFallback)
    End Function

    ''' <summary>set the active Language for this Instance</summary>
    ''' <param name="internalName">the internal Name for the Language (not the Table-Name)</param>
    ''' <returns>TRUE if Language was set - FALSE if the DataTable was not found (Default is active then)</returns>
    ''' <remarks>This Function is sets the Parameter for all "higher" Functions that use this reminder to do their work...</remarks>
    Public Function SetActiveLanguage(ByVal internalName As String) As Boolean
        Dim __cnt As Integer ' counter
        For __cnt = 0 To Me.LanguageXML_DataSet.Tables.Count - 1 ' search tables
            If Me.LanguageXML_DataSet.Tables(__cnt).TableName = My.Resources.str_xml_TableLangDataPrefix & internalName Then ' if Language is available
                Me.SelectedLanguage = internalName ' remind internal name
                Return True ' job done
            End If
        Next
        Me.SelectedLanguage = My.Resources.str_intname_DefaultLang ' table not found - apply default
        Return False ' tehh caller that language was not found
    End Function

#End Region

#Region " Data-Helper "

    ''' <summary>Function to search the Row-Index for an Item in a DataTable</summary>
    ''' <param name="tableName">the Table-Name to use</param>
    ''' <param name="searchColumn">the Column that should be used</param>
    ''' <param name="searchValue">the Value to look for (case-sensitive)</param>
    ''' <returns>the Row-Index for the Row where the Column-Content matches the search (-1 if no match was found)</returns>
    ''' <remarks>Helper to find a Row in a Data-Table based on search for a single Column - used as internal Helper...</remarks>
    Public Function SearchRowInTab(ByVal tableName As String, ByVal searchColumn As String, ByVal searchValue As Object) As Integer
        Dim __cnt As Integer ' counter
        Dim __FoundRow As Integer = -1 ' reminder for result - init with "no match"
        Dim __RowCnt As Integer = Me.LanguageXML_DataSet.Tables(tableName).Rows.Count ' get Row-Count for the Table
        For __cnt = 0 To __RowCnt - 1 ' begin for-loop with all "lines"...

            ' regular search (ascending) - compare Values
            If Me.LanguageXML_DataSet.Tables(tableName).Rows(__cnt).Item(searchColumn).ToString = searchValue.ToString Then
                ' match - remind the Row-Index
                __FoundRow = __cnt
                Exit For ' exit the for-loop
            End If

            ' we passed the "middle" of the DataRows - all items are checked, exit for-loop
            ' (see next lines in loop to get more details about this)
            If (__RowCnt - __cnt - 1) <= __cnt Then Exit For

            ' to get a better response-time for Values at the end of the List:
            ' additional search (descending) - compare values
            If Me.LanguageXML_DataSet.Tables(tableName).Rows(__RowCnt - __cnt - 1).Item(searchColumn).ToString = searchValue.ToString Then
                ' match - remind the Row-Index
                __FoundRow = __RowCnt - __cnt - 1
                Exit For ' exit the for-loop
            End If

        Next
        ' return result of search to caller
        Return __FoundRow
    End Function

    ''' <summary>add a new Language-Table to the Language-DataSet</summary>
    ''' <param name="tableName">the Name for the Table that should be created</param>
    ''' <returns>TRUE if successful - FALSE if there was an Error</returns>
    ''' <remarks>This Function just creates the Table; the Meta-Data has to be created by the caller (if needed).<br />
    ''' This is required and must not be changed. Adding the Meta-Data is a diffrent Task and not performed here...</remarks>
    Public Function CreateNewLangTable(ByVal tableName As String) As Boolean
        ' create Columns:
        Dim __colLangID As New DataColumn(My.Resources.str_xml_LangValCol_ID, System.Type.GetType("System.String")) ' Column for the Value-ID
        __colLangID.Unique = True ' must be unique
        Dim __colLangData As New DataColumn(My.Resources.str_xml_LangValCol_Value, System.Type.GetType("System.String")) ' Column for the Value itself
        ' add Columns to (new) Table
        Dim __xTab As New DataTable
        __xTab.Columns.Add(__colLangID)
        __xTab.Columns.Add(__colLangData)
        ' apply Table-Name
        __xTab.TableName = tableName
        Try
            Me.LanguageXML_DataSet.Tables.Add(__xTab.Copy) ' add Table to the DataSet
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "LanguageXML Error:")
            Return False ' error - exit FALSE
        End Try
        ' no error - exit TRUE
        Return True
    End Function

    ''' <summary>fill the internal reminder for the Meta-Data of File and Languages</summary>
    ''' <remarks>This Method extracts all MetaData from the Tables and filles the internal Objects used for quick access to the Data...</remarks>
    Public Sub SetInfoObjects()
        ' clear File-infos
        Me.FileMeta.ProgramName = ""
        Me.FileMeta.Description = ""
        Me.FileMeta.LastUpdate = Date.Now.ToString(System.Globalization.CultureInfo.InvariantCulture)
        ' clear language_infos
        Me.LangMeta = New List(Of LanguageXML.langBaseInfo)
        ' prepare Item for Language-MetaData
        Dim __tmpItem As LanguageXML.langBaseInfo
        For Each __table As DataTable In LanguageXML_DataSet.Tables ' "scan" all Tables in DataSet
            If __table.TableName.StartsWith(My.Resources.str_xml_TableLangDataPrefix) Then ' if prefix matches a Language-DataTable
                __tmpItem = New LanguageXML.langBaseInfo ' create new object for Language-MetaData
                __tmpItem.InternalName = __table.TableName.Substring(My.Resources.str_xml_TableLangDataPrefix.Length) ' get internal Name by cutting Prefix...
                __tmpItem.LastUpdate = Date.Now.ToString(System.Globalization.CultureInfo.InvariantCulture) ' pre-define output-string for date to now - if not defined...
                For Each __row As DataRow In __table.Rows ' read the rows and search the MetaData-Items
                    Select Case __row.Item(My.Resources.str_xml_LangValCol_ID).ToString ' switch by ID
                        Case My.Resources.str_MetaL_ISO ' ID for Language ISO-String - save value
                            __tmpItem.IsoString = __row.Item(My.Resources.str_xml_LangValCol_Value).ToString
                        Case My.Resources.str_MetaL_Name ' ID for Language Name - save value
                            __tmpItem.DisplayName = __row.Item(My.Resources.str_xml_LangValCol_Value).ToString
                        Case My.Resources.str_MetaL_Info ' ID for Language-Info - save value
                            __tmpItem.Info = __row.Item(My.Resources.str_xml_LangValCol_Value).ToString
                        Case My.Resources.str_MetaL_Author ' ID for Language-Author - save value
                            __tmpItem.Author = __row.Item(My.Resources.str_xml_LangValCol_Value).ToString
                        Case My.Resources.str_MetaL_Version ' ID for Language-Version - save value
                            __tmpItem.Version = __row.Item(My.Resources.str_xml_LangValCol_Value).ToString
                        Case My.Resources.str_MetaL_LastUpdate ' ID for last Update of Language-Data - save value
                            __tmpItem.LastUpdate = __row.Item(My.Resources.str_xml_LangValCol_Value).ToString
                    End Select
                Next
                Me.LangMeta.Add(__tmpItem) ' add Language-Info to List
            ElseIf __table.TableName = My.Resources.str_xml_TableMetaData Then ' Table with Meta-Data for the File
                For Each __row As DataRow In __table.Rows ' read the rows
                    Select Case __row.Item(My.Resources.str_xml_FileMetaCol_ID).ToString ' switch by ID
                        Case My.Resources.str_MetaF_Programm ' new (correct spelled) value for program-field - save value
                            FileMeta.ProgramName = __row.Item(My.Resources.str_xml_FileMetaCol_Value).ToString
                        Case My.Resources.str_MetaF_Programm_old ' old (wrong spelled) value for program-field (for backwards-compatibity) - save value
                            FileMeta.ProgramName = __row.Item(My.Resources.str_xml_FileMetaCol_Value).ToString
                        Case My.Resources.str_MetaF_Description ' The File-Description - save value
                            FileMeta.Description = __row.Item(My.Resources.str_xml_FileMetaCol_Value).ToString
                        Case My.Resources.str_MetaF_Update ' the last File-Update- save value
                            FileMeta.LastUpdate = __row.Item(My.Resources.str_xml_FileMetaCol_Value).ToString
                    End Select
                Next
            End If
        Next
    End Sub

#End Region

#End Region

#Region " File-Loader "

#Region " basic Entry Point "

    ''' <summary>load a LXML-File into DataSet of this Instance</summary>
    ''' <param name="filePath">full Path of the File to read</param>
    ''' <returns>TRUE on success - FALSE if an error occured</returns>
    ''' <remarks>This Function detects the required Loader (Version 1 or 2) automatically...</remarks>
    Private Function _LoadLanguageXmlFile_(ByVal filePath As String) As Boolean
        ' read data of file
        Dim __fileContent As String ' content of .lxml file
        Try
            __fileContent = System.IO.File.ReadAllText(filePath, System.Text.Encoding.UTF8) ' read as UTF-8
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "LanguageXML Error:")
            Return False
        End Try

        Dim __tmpXDoc As New System.Xml.XmlDocument
        __tmpXDoc.InnerXml = __fileContent ' read data into XML-Document

        If __tmpXDoc.HasChildNodes Then ' check document for type (version) - identify by root-element
            For Each __child As System.Xml.XmlNode In __tmpXDoc.ChildNodes
                Select Case __child.Name.ToLower
                    Case "languagexml" ' Version 1 - XML-DataSet
                        Return _FileLoader_Version1_(__fileContent)
                    Case "lxml" ' Version two - (L)XML-Format
                        Return _FileLoader_Version2_(__child)
                    Case "xml"
                        ' declaration - do nothing
                    Case Else ' unknown root-element
                        MsgBox("Unknown Root-Element in File...", MsgBoxStyle.Exclamation, "LanguageXML Error:")
                        Return False
                End Select
            Next
        End If
        Return False ' to be sure...
    End Function

#End Region

#Region " Version 1 "

    ''' <summary>read a Data-File in Format-Version 1 (XML-serialized Dataset)</summary>
    ''' <param name="fileData">the Data that was inside loaded the File</param>
    ''' <returns>TRUE on success - FALSE if an error occured</returns>
    ''' <remarks>This is the "old" Loader for the very first Versions of LanguageXML...</remarks>
    Private Function _FileLoader_Version1_(ByRef fileData As String) As Boolean
        ' Info:

        '' 'old code

        ' ^^^^^ this (two ') marks old code that was used until the last release

        Me.BaseInitDataSet() ' start with empty Dataset
        ' load Data into TextReader for DataSet
        Dim __dsData As System.IO.TextReader = New System.IO.StringReader(fileData)
        Try
            Me.LanguageXML_DataSet.ReadXml(__dsData) ' try to read Data into DataSet
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "LanguageXML Error:") ' Data not valid (or other error)
            Return False
        End Try
        ''Dim __RowCnt As Integer ' Row-Counter
        ''Dim __LanguageTables() As String = {""} ' Array of Strings with required lang-tables
        Dim __NewTabs As List(Of String) = New List(Of String)
        ''Dim __NewCnt As Integer = -1 ' Array-Counter (new Languages - not in default-DataSet)
        ''For __RowCnt = 0 To LanguageXML_DataSet.Tables(My.Resources.str_xml_TableMetaData).Rows.Count - 1
        For Each __Row As DataRow In LanguageXML_DataSet.Tables(My.Resources.str_xml_TableMetaData).Rows
            ''If LanguageXML_DataSet.Tables(My.Resources.str_xml_TableMetaData).Rows(__RowCnt).Item(My.Resources.str_xml_FileMetaCol_ID).ToString = My.Resources.str_MetaF_NewLangTab Then
            If __Row.Item(My.Resources.str_xml_FileMetaCol_ID).ToString = My.Resources.str_MetaF_NewLangTab Then
                ' if a Meta-Item with an internal Language-Name was found

                ''__NewCnt += 1
                ''ReDim Preserve __LanguageTables(__NewCnt)
                ''__LanguageTables(__NewCnt) = LanguageXML_DataSet.Tables(My.Resources.str_xml_TableMetaData).Rows(__RowCnt).Item(My.Resources.str_xml_FileMetaCol_Value).ToString
                __NewTabs.Add(__Row.Item(My.Resources.str_xml_FileMetaCol_Value).ToString) ' add Langauge (Value of Meta-Item) to List...
            End If
        Next
        ''If __NewCnt > -1 Then
        If __NewTabs.Count > 0 Then
            ' There are additional Languages that should be loaded

            ''For __RowCnt = 0 To UBound(__LanguageTables)
            ''    Me.CreateNewLangTable(__LanguageTables(__RowCnt))
            ''Next
            For Each __Lang As String In __NewTabs ' create new Tables
                Me.CreateNewLangTable(__Lang)
            Next
            ' now load the Data again - the required Tables are present now
            Me.LanguageXML_DataSet.Clear()
            __dsData = New System.IO.StringReader(fileData) ' re-init text-reader
            Try
                Me.LanguageXML_DataSet.ReadXml(__dsData) ' try to read DataSet
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "LanguageXML Error:") ' error during read
                Return False ' exit here
            End Try
        End If
        ' everything was fine... ;-)
        Return True
    End Function

#End Region

#Region " Version 2 "

    ''' <summary>read a Data-File in Format-Version 2 (LXML Definition)</summary>
    ''' <param name="rootElement">the Root-Element of the LXML-Document to read</param>
    ''' <returns>TRUE on success - FALSE if an error occured</returns>
    ''' <remarks>This is the main Entry-Point for loading a File in Format Version 2...</remarks>
    Private Function _FileLoader_Version2_(ByRef rootElement As System.Xml.XmlNode) As Boolean
        ' init Reminder for Elements in XML-File
        Dim __versionElement As System.Xml.XmlElement
        Dim __fileElement As System.Xml.XmlElement
        Dim __languagesElement As System.Xml.XmlElement
        Dim __itemsElement As System.Xml.XmlElement

        If rootElement.HasChildNodes Then ' there are Items inside the Root-Element
            For Each _element As System.Xml.XmlElement In rootElement.ChildNodes ' check each item for type
                Select Case _element.Name.ToLower ' switch Element by Name and save references...
                    Case "version"
                        __versionElement = _element
                    Case "file"
                        __fileElement = _element
                    Case "languages"
                        __languagesElement = _element
                    Case "items"
                        __itemsElement = _element
                End Select
            Next
        End If

        ' check version
        If Not _FileReaderV2_CheckVersion_(__versionElement) Then Return False ' wrong version

        ' initialize Meta-Values for file - no fail on error because not needed to work... ;-)
        Dim _fileMeta As List(Of _FrV2_MetaItem) = _FileReaderV2_FileMetaData_(__fileElement)

        ' check languages
        Dim _LangData As List(Of _FrV2_LanguageMeta) = _FileReaderV2_FileLanguages(__languagesElement) ' read Data
        If _LangData.Count = 0 Then Return False ' no languages in file - exit false

        ' load items and pass result to caller
        Return _FileReaderV2_LoadToTables(__itemsElement, _fileMeta, _LangData)
    End Function

#Region " used Objects "

    ''' <summary>internal MetaData-Item to load from LXML-V2 File</summary>
    ''' <remarks>Used by internal workers...</remarks>
    Private Class _FrV2_MetaItem

        ''' <summary>the Name (ID) for the Meta-Item</summary>
        Public ItemName As String
        ''' <summary>the Value for the Meta-Item</summary>
        Public ItemValue As String

        ''' <summary>Constructor</summary>
        ''' <remarks>creates an empty Instance...</remarks>
        Public Sub New()
            ItemName = ""
            ItemValue = ""
        End Sub

    End Class

    ''' <summary>internal LanguageData-Item to load from LXML-V2 File</summary>
    ''' <remarks>Used by internal workers...</remarks>
    Private Class _FrV2_LanguageMeta

        ''' <summary>the internal name for the Language (used to create Table-Name)</summary>
        Public InternalName As String
        ''' <summary>the internal (Auto-)ID for the Language</summary>
        Public LanguageId As String
        ''' <summary>List for Language MetaData-Items</summary>
        Public Values As List(Of _FrV2_MetaItem)

        ''' <summary>Constructor</summary>
        ''' <remarks>creates an empty Instance...</remarks>
        Public Sub New()
            InternalName = ""
            LanguageId = ""
            Values = New List(Of _FrV2_MetaItem)
        End Sub

    End Class

#End Region

#Region " inner worker "

    ''' <summary>process Version-Info of File-Format</summary>
    ''' <param name="versionElement">the XML-Element containing the Version-Information</param>
    ''' <returns>TRUE if Version is OK - FALSE if not...</returns>
    ''' <remarks>At this Time only the "Major"-Information is checked...</remarks>
    Private Function _FileReaderV2_CheckVersion_(ByRef versionElement As System.Xml.XmlElement) As Boolean
        If IsNothing(versionElement) Then Return False ' exit if Item is nothing / null (must be present in valid V2-File)

        ' check major version
        If versionElement.GetAttribute("major").Trim <> "2" Then
            Return False
        End If
        '_versionElement.GetAttribute("minor") --> minor version just add values --> display info (if active) later

        Return True
    End Function

    ''' <summary>read File Meta-Data and save into List</summary>
    ''' <param name="fileMetaElement">the XML-Element containing the Meta-Data</param>
    ''' <returns>List of MetaData-Items</returns>
    ''' <remarks>creates Items from the Attributes inside the XML-Element...</remarks>
    Private Function _FileReaderV2_FileMetaData_(ByRef fileMetaElement As System.Xml.XmlElement) As List(Of _FrV2_MetaItem)
        Dim __res As New List(Of _FrV2_MetaItem) ' prepare Result-Object
        If IsNothing(fileMetaElement) Then Return __res ' if input is nothing / null return empty list

        Dim _tmpItem As _FrV2_MetaItem ' init tmp-item
        ' build meta-values from attributes

        ' program
        _tmpItem = New _FrV2_MetaItem ' create new object
        _tmpItem.ItemName = "programm" ' set name
        _tmpItem.ItemValue = fileMetaElement.GetAttribute("program") ' set value from XML-Attribute
        __res.Add(_tmpItem) ' add to list

        ' description
        _tmpItem = New _FrV2_MetaItem
        _tmpItem.ItemName = "description"
        _tmpItem.ItemValue = fileMetaElement.GetAttribute("description")
        __res.Add(_tmpItem)

        ' last update
        _tmpItem = New _FrV2_MetaItem
        _tmpItem.ItemName = "update"
        _tmpItem.ItemValue = fileMetaElement.GetAttribute("lastupdate")
        __res.Add(_tmpItem)

        Return __res ' list ready - job done
    End Function

    ''' <summary>read Language and its Meta-Data and save into List</summary>
    ''' <param name="languageElement">the XML-Element containing the Language-Item</param>
    ''' <returns>List of Language-MetaData-Items</returns>
    ''' <remarks>creates Items from the Attributes inside the XML-Element...</remarks>
    Private Function _FileReaderV2_FileLanguages(ByRef languageElement As System.Xml.XmlElement) As List(Of _FrV2_LanguageMeta)
        Dim __res As New List(Of _FrV2_LanguageMeta) ' prepare result
        If IsNothing(languageElement) Then Return __res
        ' needed results: 
        ' list of languages
        ' id for each language
        ' list of language-metadata
        Dim __tmpResItem As _FrV2_LanguageMeta
        Dim __tmpListItem As _FrV2_MetaItem
        Dim __tmpName As String
        If languageElement.HasChildNodes Then
            For Each __lang As System.Xml.XmlElement In languageElement.ChildNodes
                __tmpResItem = New _FrV2_LanguageMeta
                ' add control-items
                __tmpName = __lang.GetAttribute("name")
                If __tmpName.ToLower = "default" Then ' if default-language
                    __tmpResItem.InternalName = "DEFAULT" ' set name in upper case
                Else ' other language
                    __tmpResItem.InternalName = __tmpName
                End If
                __tmpResItem.LanguageId = __lang.GetAttribute("id") ' read Language-(Auto-)ID

                ' add items for data-table
                __tmpListItem = New _FrV2_MetaItem ' init Temp-Item
                __tmpListItem.ItemName = "author" ' set Item-Name
                __tmpListItem.ItemValue = __lang.GetAttribute("author") ' set Item-Value
                __tmpResItem.Values.Add(__tmpListItem) ' add item to List

                __tmpListItem = New _FrV2_MetaItem
                __tmpListItem.ItemName = "name"
                __tmpListItem.ItemValue = __lang.GetAttribute("displayname")
                __tmpResItem.Values.Add(__tmpListItem)

                __tmpListItem = New _FrV2_MetaItem
                __tmpListItem.ItemName = "info"
                __tmpListItem.ItemValue = __lang.GetAttribute("info")
                __tmpResItem.Values.Add(__tmpListItem)

                __tmpListItem = New _FrV2_MetaItem
                __tmpListItem.ItemName = "iso"
                __tmpListItem.ItemValue = __lang.GetAttribute("iso")
                __tmpResItem.Values.Add(__tmpListItem)

                __tmpListItem = New _FrV2_MetaItem
                __tmpListItem.ItemName = "update"
                __tmpListItem.ItemValue = __lang.GetAttribute("lastupdate")
                __tmpResItem.Values.Add(__tmpListItem)

                __tmpListItem = New _FrV2_MetaItem
                __tmpListItem.ItemName = "version"
                __tmpListItem.ItemValue = __lang.GetAttribute("version")
                __tmpResItem.Values.Add(__tmpListItem)

                __res.Add(__tmpResItem) ' add Item to Result
            Next
        End If
        ' Result is ready - job done
        Return __res
    End Function

    ' -- refactoring-break 2010-06-30

    ' load items
    Private Function _FileReaderV2_LoadToTables(ByRef _itemsElement As System.Xml.XmlElement, ByRef _fileMeta As List(Of _FrV2_MetaItem), ByRef _LangData As List(Of _FrV2_LanguageMeta)) As Boolean
        If IsNothing(_itemsElement) Then Return False ' no data passed
        If Not _itemsElement.HasChildNodes Then Return False ' no items found

        BaseInitDataSet() ' initialize DataSet
        ' fill file-meta Table
        Dim _tmpRow As DataRow
        For Each _item As _FrV2_MetaItem In _fileMeta
            _tmpRow = LanguageXML_DataSet.Tables(My.Resources.str_xml_TableMetaData).NewRow
            _tmpRow.Item(My.Resources.str_xml_FileMetaCol_ID) = _item.ItemName
            _tmpRow.Item(My.Resources.str_xml_FileMetaCol_Value) = _item.ItemValue
            Try
                LanguageXML_DataSet.Tables(My.Resources.str_xml_TableMetaData).Rows.Add(_tmpRow)
            Catch ex As Exception
                Return False
            End Try
        Next

        ' fill basic data for languages
        For Each _lang As _FrV2_LanguageMeta In _LangData ' check each language
            If _lang.InternalName <> "DEFAULT" Then ' if not default-language, then generate needed table
                CreateNewLangTable(My.Resources.str_xml_TableLangDataPrefix & _lang.InternalName)
            End If
            ' fill meta-data values of table
            For Each _item As _FrV2_MetaItem In _lang.Values
                _tmpRow = LanguageXML_DataSet.Tables(My.Resources.str_xml_TableLangDataPrefix & _lang.InternalName).NewRow
                _tmpRow.Item(My.Resources.str_xml_LangValCol_ID) = _item.ItemName
                _tmpRow.Item(My.Resources.str_xml_LangValCol_Value) = _item.ItemValue
                Try
                    LanguageXML_DataSet.Tables(My.Resources.str_xml_TableLangDataPrefix & _lang.InternalName).Rows.Add(_tmpRow)
                Catch ex As Exception
                    Return False
                End Try
            Next
        Next
        ' read items from XML-Element
        For Each _item As System.Xml.XmlElement In _itemsElement.ChildNodes ' check children
            If _item.Name.ToLower = "item" Then ' if valid container
                ' fill item-data
                _tmpRow = LanguageXML_DataSet.Tables(My.Resources.str_xml_TableItemData).NewRow
                _tmpRow.Item(My.Resources.str_xml_FileItemCol_ID) = Integer.Parse(_item.GetAttribute("id"))
                _tmpRow.Item(My.Resources.str_xml_FileItemCol_Name) = _item.GetAttribute("name")
                _tmpRow.Item(My.Resources.str_xml_FileItemCol_Description) = _item.GetAttribute("description")
                Try ' try to add (id or name may be present twice)
                    LanguageXML_DataSet.Tables(My.Resources.str_xml_TableItemData).Rows.Add(_tmpRow)
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
                            _tmpTabName = My.Resources.str_xml_TableLangDataPrefix & _lang.InternalName
                            Exit For
                        End If
                    Next
                    ' if Table-name was found, apply value to dataset
                    If _tmpTabName <> "" Then
                        _tmpRow = LanguageXML_DataSet.Tables(_tmpTabName).NewRow
                        _tmpRow.Item(My.Resources.str_xml_LangValCol_ID) = _langItemsElement.GetAttribute("id") ' get id form base-item
                        _tmpRow.Item(My.Resources.str_xml_LangValCol_Value) = _item.GetAttribute("value") ' get value from language-item
                        Try
                            LanguageXML_DataSet.Tables(_tmpTabName).Rows.Add(_tmpRow)
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

#Region " processed Value "

    ' ToDo: (?) create "better" Versions - some diffrent signatures for more ease of use...

    ''' <summary>get a processed string-value from the active language by ID</summary>
    ''' <param name="ID">ID of the LXML-Item to load</param>
    ''' <param name="ReplaceData">Array with ReplaceData-Elements</param>
    ''' <param name="DefaultFallback">optional you can decativate the DefaultFallback function</param>
    ''' <returns>processed string-value for the active language</returns>
    ''' <remarks>Function to read a processed Value (Language-Value with replaced Placeholders) for the active Language using the Item-ID.<br />
    ''' <b>It has the same function like the overload using the Item-Name - but this way is not recommended!</b>
    ''' <p>This function may be used to avoid the internal step to get the ID before reading the Value (for example on slow Systems).<br />
    ''' Because ID's are auto-generated, an accidential deleted Value can get a new ID - think about that if you want to use this Overload..!</p></remarks>
    Public Function ReadProcessedValue(ByVal ID As Integer, ByVal ReplaceData As LanguageXML.ReplaceElements(), Optional ByVal DefaultFallback As Boolean = True) As String
        ' einen Verarbeiteten Wert über die ID laden
        Dim LangValue As String = GetLangValueByID(ID.ToString, My.Resources.str_xml_TableLangDataPrefix & SelectedLanguage, DefaultFallback)
        If LangValue <> "" Then LangValue = ReplaceStringParts(LangValue, ReplaceData)
        Return LangValue
    End Function
    ''' <summary>
    ''' get a processed string-value from the active language by Name
    ''' </summary>
    ''' <param name="Name">Name of the LXML-Item to load</param>
    ''' <param name="ReplaceData">Array with ReplaceData-Elements</param>
    ''' <param name="DefaultFallback">optional you can decativate the DefaultFallback function</param>
    ''' <returns>processed string-value for the active language</returns>
    ''' <remarks>This overload (using the Item-Name) is a way to change multiple Placeholders - you have to pass an Array of ReplaceData-Elements if you use this overload...</remarks>
    Public Function ReadProcessedValue(ByVal Name As String, ByVal ReplaceData As LanguageXML.ReplaceElements(), Optional ByVal DefaultFallback As Boolean = True) As String
        ' load a processed Value by Name
        Dim LangValue As String = GetLangValueByName(Name, My.Resources.str_xml_TableLangDataPrefix & SelectedLanguage, DefaultFallback)
        If LangValue <> "" Then LangValue = ReplaceStringParts(LangValue, ReplaceData)
        Return LangValue
    End Function

    ''' <summary>Function to replace a List of Placeholders inside a String</summary>
    ''' <param name="Input">the String to process</param>
    ''' <param name="ReplaceData">the Replace-Data (Array) fo use</param>
    ''' <returns>the processed String with replaced Values</returns>
    ''' <remarks>This is the basic Function for this Task, used by diffrent "higher" functions...</remarks>
    Public Function ReplaceStringParts(ByVal Input As String, ByVal ReplaceData As LanguageXML.ReplaceElements()) As String
        Dim __TmpText As System.Text.StringBuilder = New System.Text.StringBuilder ' create StringBuilder for the Preplace-Process
        __TmpText.Append(Input) ' create Work-Copy of input
        Dim __cnt As Integer ' counter
        For __cnt = 0 To UBound(ReplaceData) ' for each Replace-Item in Array
            If ReplaceData(__cnt).ReplaceThis <> "" Then ' if value is not empty
                Try
                    __TmpText = __TmpText.Replace(ReplaceData(__cnt).ReplaceThis, ReplaceData(__cnt).ReplaceWith) ' try the replace
                Catch ex As Exception
                    MsgBox("Error:" & vbCrLf & "... replacing """ & ReplaceData(__cnt).ReplaceThis & """ with """ & ReplaceData(__cnt).ReplaceWith & """" & vbCrLf & " in String """ & Input & """ failed ...", MsgBoxStyle.Exclamation, "LanguageXML Replace:")
                End Try
            End If
        Next
        Return __TmpText.ToString ' return the result
    End Function


#End Region

#Region " MessageBox "

    ' MessageBox GetText:
    Public Function GetMessageBoxText(ByVal MessageName As String) As String
        Return GetLangValueByName(Msgbox_LxmMessageTextPrefix & MessageName, My.Resources.str_xml_TableLangDataPrefix & SelectedLanguage, True)
    End Function

    ' MessageBox GetProcessedText:
    Public Function GetProcessedMessageBoxText(ByVal MessageName As String, ByVal ReplaceData As LanguageXML.ReplaceElements()) As String
        Return ReadProcessedValue(Msgbox_LxmMessageTextPrefix & MessageName, ReplaceData, True)
    End Function

    ' MessageBox GetProcessedCustomTitle
    Public Function GetProcessedMessageBoxTitle(ByVal TitleName As String, ByVal ReplaceData As LanguageXML.ReplaceElements()) As String
        Return ReadProcessedValue(Msgbox_LxmlTitletemPrefix & TitleName, ReplaceData, True)
    End Function

    ' MessageBox GetReplaceArray (overloaded):
    Public Function GetReplaceArray(ByVal ReplaceThis As String, ByVal ReplaceWith As String) As LanguageXML.ReplaceElements()
        Dim _tmp(0) As LanguageXML.ReplaceElements
        _tmp(0).ReplaceThis = ReplaceThis
        _tmp(0).ReplaceWith = ReplaceWith
        Return _tmp
    End Function
    Public Function GetReplaceArray(ByVal ReplaceData As List(Of LanguageXML.ReplaceElements)) As LanguageXML.ReplaceElements()
        If ReplaceData.Count > 0 Then
            Dim _tmp(ReplaceData.Count - 1) As LanguageXML.ReplaceElements
            For i As Integer = 0 To ReplaceData.Count - 1
                _tmp(i).ReplaceThis = ReplaceData(i).ReplaceThis
                _tmp(i).ReplaceWith = ReplaceData(i).ReplaceWith
            Next
            Return _tmp
        Else
            Dim _tmp(0) As LanguageXML.ReplaceElements
            Return _tmp
        End If
    End Function

    ' MessageBox GetTitle:
    Public Function GetMessageBoxTitle(ByVal Type As LanguageXML.MessageType) As String
        Dim _titleName As String = ""
        Select Case Type
            Case LanguageXML.MessageType.Confirm
                _titleName = "Confirm"
            Case LanguageXML.MessageType.Critical
                _titleName = "Critical"
            Case LanguageXML.MessageType.ErrorMessage
                _titleName = "Error"
            Case LanguageXML.MessageType.Warning
                _titleName = "Warning"
            Case Else ' info as default
                _titleName = "Info"
        End Select
        ' return value
        Return GetLangValueByName(Msgbox_LxmMessageHeaderPrefix & _titleName, My.Resources.str_xml_TableLangDataPrefix & SelectedLanguage, True)
    End Function
    Public Function GetMessageBoxTitle(ByVal TitleName As String) As String
        Return GetLangValueByName(Msgbox_LxmlTitletemPrefix & TitleName, My.Resources.str_xml_TableLangDataPrefix & SelectedLanguage, True)
    End Function

#End Region

#Region " Auto-Apply text to Form and its Elements "

    'ToDo: move this Code to own partitial Class-Segment or own Class in "outer" Container (not Core-Function that can be ported to everywehre like WinMobile)

    ' overloaded Item-TextLoader (to implement DRY as good as possible)
    Public Function ApplyText_OnPrefixMatch(ByRef ApplyTo As System.Windows.Forms.Control, ByVal FormElementPrefix As String, ByVal lxmlElementPrefix As String, Optional ByVal DefaultFallback As Boolean = True) As Boolean
        Dim TmpName As String
        If ApplyTo.Name.StartsWith(FormElementPrefix) Then
            ' Item gehört zur Gruppe der Elemente, die gesetzt werden sollen
            TmpName = ApplyTo.Name
            Try
                ApplyTo.Text = GetLangValueByName(lxmlElementPrefix & TmpName.Substring(FormElementPrefix.Length), My.Resources.str_xml_TableLangDataPrefix & SelectedLanguage, DefaultFallback)
            Catch ex As Exception
                ' Text konnte nicht gesetzt werden
                MsgBox("Error:" & vbCrLf & "... property .Text of element """ & TmpName & """ could not be set ...", MsgBoxStyle.Exclamation, "LanguageXML AutoApply:")
                Return False
            End Try
        End If
        Return True
    End Function
    Public Function ApplyText_OnPrefixMatch(ByRef ApplyTo As System.Windows.Forms.ToolStripItem, ByVal FormElementPrefix As String, ByVal lxmlElementPrefix As String, Optional ByVal DefaultFallback As Boolean = True) As Boolean
        Dim TmpName As String
        If ApplyTo.Name.StartsWith(FormElementPrefix) Then
            ' Item gehört zur Gruppe der Elemente, die gesetzt werden sollen
            TmpName = ApplyTo.Name
            Try
                ApplyTo.Text = GetLangValueByName(lxmlElementPrefix & TmpName.Substring(FormElementPrefix.Length), My.Resources.str_xml_TableLangDataPrefix & SelectedLanguage, DefaultFallback)
            Catch ex As Exception
                ' Text konnte nicht gesetzt werden
                MsgBox("Error:" & vbCrLf & "... property .Text of element """ & TmpName & """ could not be set ...", MsgBoxStyle.Exclamation, "LanguageXML AutoApply:")
                Return False
            End Try
        End If
        Return True
    End Function

    ' Sprachdaten auf ein Form anwenden (alle Elemente mit Eigenschaft .Text, die einen passenden NamePrefix haben)
    Public Sub ApplyTexts_ToForm(ByRef ApplyTo As System.Windows.Forms.Form, ByVal FormElementPrefix As String, ByVal lxmlElementPrefix As String, Optional ByVal DefaultFallback As Boolean = True)
        Dim i As Integer
        Dim TmpName As String = ""
        ' Elemente verarbeiten:
        '
        ' ggf. Elemente im MainMenü setzen

        If Not IsNothing(ApplyTo.MainMenuStrip) Then
            ApplyTexts_ToMainMenu(ApplyTo, FormElementPrefix, lxmlElementPrefix, DefaultFallback)
        End If
        ' Alle Elemente im Stamm des des Form
        For i = 0 To ApplyTo.Controls.Count - 1
            TmpName = ApplyTo.Controls(i).Name
            ' ggf. StatusStrip-Items abarbeiten
            If ApplyTo.Controls(i).GetType.Name = GetType(System.Windows.Forms.StatusStrip).Name Then ' Status-Strip
                ApplyTexts_ToStatusStrip(ApplyTo.Controls(i), FormElementPrefix, lxmlElementPrefix, DefaultFallback)
            Else ' anderes Control - ggf. setzen
                ApplyText_OnPrefixMatch(ApplyTo.Controls(i), FormElementPrefix, lxmlElementPrefix, DefaultFallback)
            End If
            ' Hier ggf. rekusiv Unter-Elemente abarbeiten:
            If ApplyTo.Controls(i).HasChildren Then
                ApplyTexts_ToFormSubElements(ApplyTo.Controls(i), FormElementPrefix, lxmlElementPrefix, DefaultFallback)
            End If
        Next
    End Sub

    ' Unter-Objekte eines Form setzen
    Public Sub ApplyTexts_ToFormSubElements(ByRef ApplyTo As System.Windows.Forms.Control, ByVal FormElementPrefix As String, ByVal lxmlElementPrefix As String, Optional ByVal DefaultFallback As Boolean = True)
        ' rekursiv Unter-Objekte eines Form durcharbeiten
        Dim i As Integer
        ' Elemente setzen
        For i = 0 To ApplyTo.Controls.Count - 1
            ApplyText_OnPrefixMatch(ApplyTo.Controls(i), FormElementPrefix, lxmlElementPrefix, DefaultFallback)
            If ApplyTo.Controls(i).HasChildren Then
                ApplyTexts_ToFormSubElements(ApplyTo.Controls(i), FormElementPrefix, lxmlElementPrefix, DefaultFallback)
            End If
        Next
    End Sub

    ' Hauptmenü des Form setzen
    Public Sub ApplyTexts_ToMainMenu(ByRef ApplyTo As System.Windows.Forms.Form, ByVal FormElementPrefix As String, ByVal lxmlElementPrefix As String, Optional ByVal DefaultFallback As Boolean = True)
        ' Hauptmenü des Form setzen
        For Each mnItem As System.Windows.Forms.ToolStripItem In ApplyTo.MainMenuStrip.Items
            ' jedes Haupt-Element durchsuchen ggf. setzen und unterlemente ebenfalls (rekursiv)
            ApplyTexts_ToMenuSubElements(mnItem, FormElementPrefix, lxmlElementPrefix, DefaultFallback)
        Next
    End Sub
    ' Menü-Element und Unterelemente setzen...
    Public Sub ApplyTexts_ToMenuSubElements(ByRef ApplyTo As System.Windows.Forms.ToolStripItem, ByVal FormElementPrefix As String, ByVal lxmlElementPrefix As String, Optional ByVal DefaultFallback As Boolean = True)
        Select Case ApplyTo.GetType.FullName
            Case GetType(System.Windows.Forms.ToolStripComboBox).FullName ' combo-box
                Dim _tmpBox As System.Windows.Forms.ToolStripComboBox = ApplyTo ' "convert"
                If _tmpBox.DropDownStyle <> Windows.Forms.ComboBoxStyle.DropDownList Then ' if not DropDownList then set Text on Prefix-Match
                    ApplyText_OnPrefixMatch(ApplyTo, FormElementPrefix, lxmlElementPrefix, DefaultFallback)
                End If
            Case GetType(System.Windows.Forms.ToolStripSeparator).FullName
                ' nothing
            Case GetType(System.Windows.Forms.ToolStripTextBox).FullName ' textBox - fill in NameMatch
                ApplyText_OnPrefixMatch(ApplyTo, FormElementPrefix, lxmlElementPrefix, DefaultFallback)
            Case GetType(System.Windows.Forms.ToolStripMenuItem).FullName ' MenuItem - set Text and look for nested...
                ApplyTexts_ToMenuItemSubElements(ApplyTo, FormElementPrefix, lxmlElementPrefix, DefaultFallback)
            Case Else ' unknown item
                ' nothing
        End Select
    End Sub
    ' Menu-Item setzen und Unterelemente setzen...
    Public Sub ApplyTexts_ToMenuItemSubElements(ByRef ApplyTo As System.Windows.Forms.ToolStripMenuItem, ByVal FormElementPrefix As String, ByVal lxmlElementPrefix As String, Optional ByVal DefaultFallback As Boolean = True)
        Dim i As Integer
        ApplyText_OnPrefixMatch(ApplyTo, FormElementPrefix, lxmlElementPrefix, DefaultFallback)
        ' ggf. Unterlemente setzen
        If ApplyTo.HasDropDownItems Then
            For i = 0 To ApplyTo.DropDownItems.Count - 1
                ApplyTexts_ToMenuSubElements(ApplyTo.DropDownItems(i), FormElementPrefix, lxmlElementPrefix, DefaultFallback)
            Next
        End If
    End Sub

    ' StatusStrip abarbeiten
    Public Sub ApplyTexts_ToStatusStrip(ByRef ApplyTo As System.Windows.Forms.StatusStrip, ByVal FormElementPrefix As String, ByVal lxmlElementPrefix As String, Optional ByVal DefaultFallback As Boolean = True)
        ' Items eines StatusStrip-Objekt setzen
        For Each _tsItem As System.Windows.Forms.ToolStripItem In ApplyTo.Items
            ApplyTexts_ToStatusBarSubElements(_tsItem, FormElementPrefix, lxmlElementPrefix, DefaultFallback)
        Next
    End Sub
    ' StatusStrip-Element und Unterelemente setzen...
    Public Sub ApplyTexts_ToStatusBarSubElements(ByRef ApplyTo As System.Windows.Forms.ToolStripItem, ByVal FormElementPrefix As String, ByVal lxmlElementPrefix As String, Optional ByVal DefaultFallback As Boolean = True)
        If ApplyTo.GetType.Name = GetType(System.Windows.Forms.ToolStripSplitButton).Name Then
            ' ggf. Unterlemente setzen eines Split-Button setzen
            ApplyText_ToToolStripSplitButtonElements(ApplyTo, FormElementPrefix, lxmlElementPrefix, DefaultFallback)
        ElseIf ApplyTo.GetType.Name = GetType(System.Windows.Forms.ToolStripDropDownButton).Name Then
            ' ggf. Unterlemente setzen eines DropDown setzen
            ApplyText_ToToolStripDropDownElements(ApplyTo, FormElementPrefix, lxmlElementPrefix, DefaultFallback)
        Else ' regular item - set text
            ApplyText_OnPrefixMatch(ApplyTo, FormElementPrefix, lxmlElementPrefix, DefaultFallback)
        End If
    End Sub
    ' StatusStrip-SplitButton und Unter-Elemente setzen
    Public Sub ApplyText_ToToolStripSplitButtonElements(ByRef ApplyTo As System.Windows.Forms.ToolStripSplitButton, ByVal FormElementPrefix As String, ByVal lxmlElementPrefix As String, Optional ByVal DefaultFallback As Boolean = True)
        ApplyText_OnPrefixMatch(ApplyTo, FormElementPrefix, lxmlElementPrefix, DefaultFallback)
        ' Unter-Elemente sind Menu-Items - bestehende Funktion nutzen
        If ApplyTo.HasDropDownItems Then
            For Each _tsItem As System.Windows.Forms.ToolStripItem In ApplyTo.DropDownItems
                ApplyTexts_ToMenuSubElements(_tsItem, FormElementPrefix, lxmlElementPrefix, DefaultFallback)
            Next
        End If
    End Sub
    ' StatusStrip-DropDownButton und Unterelemente Setzen
    Public Sub ApplyText_ToToolStripDropDownElements(ByRef ApplyTo As System.Windows.Forms.ToolStripDropDownButton, ByVal FormElementPrefix As String, ByVal lxmlElementPrefix As String, Optional ByVal DefaultFallback As Boolean = True)
        ApplyText_OnPrefixMatch(ApplyTo, FormElementPrefix, lxmlElementPrefix, DefaultFallback)
        If ApplyTo.HasDropDownItems Then
            For Each _tsItem As System.Windows.Forms.ToolStripItem In ApplyTo.DropDownItems
                ApplyTexts_ToMenuSubElements(_tsItem, FormElementPrefix, lxmlElementPrefix, DefaultFallback)
            Next
        End If
    End Sub

#End Region

End Class