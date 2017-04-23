' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Language XML Base Class |   http://lxml.codeplex.com  |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

''' <summary>Class for the read-usage of LanguageXML-Files (.lxml) in Applications</summary>
''' <remarks>This Class provides the "Client-Functions" for the use of LanguageXML.<br />
''' For Windows-Forms you can use an AutoApply for most Elements used on a Form - see Userguide for Details...<br />
''' <p>
''' Used References:
''' <ul>
''' <li>System</li>
''' <li>System.Data</li>
''' <li>System.Windows.Forms</li>
''' <li>System.Xml</li>
''' </ul>
''' </p></remarks>
Partial Public Class LanguageXML
    ' his Code is part of the public Interface of the class
    ' this is the "Base"...


    ' ToDo: DLL - open issues:
    ' - Context-Menu Items
    ' - ToolTips --> Menu-Items have their own Items for ToolTipInfo..!
    ' - Use .ToolTip in Element-Names, .xxx for custom Elements of a control (support where it makes sense --> textbox-mask, RTF for Rich-Text [This must be integrated into the Editor... ;-)] )
    ' - internal Managment of "static" Placeholder-Values (only used to build text) ??? set (e.g. Version-)String for Value once, then just call without replace-value (only name as parameter)
    ' - apply-to-control function (if the Item is not a Form)
    ' - Parameter "throw Exceptions" - default FALSE for backwards-comp. (to throw Exceptions instead of Message-Boxes)

#Region " class-internal Base-Object with Functions and Data-Handling "

    ''' <summary>internal Object for the Base-functions</summary>
    Private _lxmlBase As clsLxmlBase

#End Region

#Region " general public logic "

    ''' <summary>Constructor - create a new Instance and initialize the internal DataSet of the Class.</summary>
    ''' <remarks>This is the basic initialization for the Class. It prepares a empty DataSet in Memory...</remarks>
    Public Sub New()
        '_BaseInitDataSet() ' Datensatz für diese Instanz initialisieren
        _lxmlBase = New clsLxmlBase ' initialize new Base-Class with inner workers
    End Sub

    ''' <summary>This function loads a LXML-Data-File to the internal DataSet.</summary>
    ''' <param name="File">full path to the .lxml-File to load</param>
    ''' <returns>TRUE if the loading was successfull...</returns>
    ''' <remarks>This Function is used to load a LanguagXML-File (regular used once on Application-Init... ;-)</remarks>
    Public Function LoadFromXmlFile(ByVal File As String) As Boolean
        If Not _lxmlBase.LoadLanguageXmlFile(File) Then
            ' file could not be loaded
            Return False
        End If
        _lxmlBase.SetInfoObjects()
        Return True
    End Function

    ' Info: more public Logic can be found in the Files in Folder "parts"...

#End Region

End Class