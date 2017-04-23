' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |   Language XML Editor  |   http://lxml.codeplex.com   |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

''' <summary>Class with the needed Strings for the Program</summary>
Friend Class Declarations

    ''' <summary>Strings for the DataSet that is used for LanguageXML</summary>
    Public Class LXML_DataSet
        ''' <summary>Strings for the Tables in the DataSet</summary>
        Public Class Tables
            ''' <summary>Strings for the Item-List Table</summary>
            Public Class ItemData
                ''' <summary>Name for the Item-List Table</summary>
                Public Const Name As String = "tblItemData"
                ''' <summary>Strings regarding the Columns in the Table</summary>
                Public Class Columns
                    ''' <summary>Strings for the ID-Column</summary>
                    Public Class iID
                        ''' <summary>Name for the Column</summary>
                        Public Const Name As String = "colItemId"
                    End Class
                    ''' <summary>Strings for the Name-Column</summary>
                    Public Class iName
                        ''' <summary>Name for the Column</summary>
                        Public Const Name As String = "colItemName"
                    End Class
                    ''' <summary>Strings for the Description-Column</summary>
                    Public Class iDescription
                        ''' <summary>Name for the Column</summary>
                        Public Const Name As String = "colItemDescr"
                    End Class
                End Class
            End Class
            ''' <summary>Strings for the Meta-Data Table</summary>
            Public Class MetaData
                ''' <summary>Name for the Meta-Data Table</summary>
                Public Const Name As String = "tblMetaData"
                ''' <summary>Strings regarding the Columns in the Table</summary>
                Public Class Columns
                    ''' <summary>Strings for the ID-Column</summary>
                    Public Class mValue
                        ''' <summary>Name for the Column</summary>
                        Public Const Name As String = "colMetaValue"
                    End Class
                    ''' <summary>Strings for the Data-Column</summary>
                    Public Class mData
                        ''' <summary>Name for the Column</summary>
                        Public Const Name As String = "colMetaData"
                    End Class
                End Class
            End Class
            ''' <summary>Strings for the Language-Data Table</summary>
            Public Class LangData
                ''' <summary>Name-Prefix for the Language-Data Table(s)</summary>
                Public Const NamePrefix As String = "tblLang_"
                ''' <summary>Strings regarding the Columns in the Table</summary>
                Public Class Columns
                    ''' <summary>Strings for the ID-Column</summary>
                    Public Class lID
                        ''' <summary>Name for the Column</summary>
                        Public Const Name As String = "colLangID"
                    End Class
                    ''' <summary>Strings for the Value-Column</summary>
                    Public Class lValue
                        ''' <summary>Name for the Column</summary>
                        Public Const Name As String = "colLangData"
                    End Class
                End Class
            End Class
            ''' <summary>Strings regarding the Default-Language in the DataSet</summary>
            Public Class DefaultLang
                ''' <summary>internal Name for the Default-Language(-Table)</summary>
                Public Const InternalName As String = "DEFAULT"
            End Class
        End Class
    End Class

    ''' <summary>Strings for the MetaData in the DataTables of the DataSet</summary>
    Public Class MetaData
        ''' <summary>String used for a new Multi-Value in Meta-Data</summary>
        Public Const NewMultiValue As String = "_new_value_"
        ''' <summary>Strings for the File Meta-Data</summary>
        Public Class File
            ''' <summary>Strings for Fields (ID's / Names, ...) in File Meta-Data</summary>
            Public Class Fields
                ''' <summary>Strings for the Field Program</summary>
                Public Class Program
                    ''' <summary>ID / Name for the Field</summary>
                    Public Const Name As String = "program"
                End Class
                ''' <summary>old Strings for the Field Program</summary>
                Public Class Program_old
                    ''' <summary>old ID / Name for the Field</summary>
                    Public Const Name As String = "programm"
                End Class
                ''' <summary>Strings for the Field Description</summary>
                Public Class Description
                    ''' <summary>ID / Name for the Field</summary>
                    Public Const Name As String = "description"
                End Class
                ''' <summary>Strings for the Field LastUpdate</summary>
                Public Class LastUpdate
                    ''' <summary>ID / Name for the Field</summary>
                    Public Const Name As String = "update"
                End Class
                ''' <summary>Strings for the Field NewLangTable-Name</summary>
                Public Class NewLangTable
                    ''' <summary>ID / Name for the Field</summary>
                    Public Const Name As String = "addlangtab"
                End Class
            End Class
        End Class

        ''' <summary>Strings for the Language Meta-Data</summary>
        Public Class Language
            ''' <summary>Strings for Fields (ID's / Names, ...) in Language Meta-Data</summary>
            Public Class Fields
                ''' <summary>Strings for the Field Program</summary>
                Public Class DisplayName
                    ''' <summary>ID / Name for the Field</summary>
                    Public Const Name As String = "name"
                End Class
                ''' <summary>Strings for the Field Program</summary>
                Public Class IsoString
                    ''' <summary>ID / Name for the Field</summary>
                    Public Const Name As String = "iso"
                End Class
                ''' <summary>Strings for the Field Program</summary>
                Public Class Author
                    ''' <summary>ID / Name for the Field</summary>
                    Public Const Name As String = "author"
                End Class
                ''' <summary>Strings for the Field Program</summary>
                Public Class Version
                    ''' <summary>ID / Name for the Field</summary>
                    Public Const Name As String = "version"
                End Class
                ''' <summary>Strings for the Field Program</summary>
                Public Class InfoText
                    ''' <summary>ID / Name for the Field</summary>
                    Public Const Name As String = "info"
                End Class
                ''' <summary>Strings for the Field Program</summary>
                Public Class lastUpdate
                    ''' <summary>ID / Name for the Field</summary>
                    Public Const Name As String = "update"
                End Class
            End Class
        End Class
    End Class

    ''' <summary>Strings for the Language Edit-Grid</summary>
    Public Class LangEditGrid
        ''' <summary>Strings regarding the Columns in the DataGridView</summary>
        Public Class Columns
            ''' <summary>Strings for the Column ID</summary>
            Public Class ID
                ''' <summary>Name for the Column</summary>
                Public Const Name As String = "colID"
            End Class
            ''' <summary>Strings for the Column Name</summary>
            Public Class Name
                ''' <summary>Name for the Column</summary>
                Public Const Name As String = "colName"
            End Class
            ''' <summary>Strings for the Column Description</summary>
            Public Class Description
                ''' <summary>Name for the Column</summary>
                Public Const Name As String = "colDescription"
            End Class
            ''' <summary>Strings for the Column Value</summary>
            Public Class Value
                ''' <summary>Name for the Column</summary>
                Public Const Name As String = "colValue"
            End Class
            ''' <summary>Strings for the Column HelperValue</summary>
            Public Class HelperValue
                ''' <summary>Name for the Column</summary>
                Public Const Name As String = "colHelper"
            End Class
        End Class
    End Class

End Class