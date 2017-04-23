' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |   Language XML Editor  |   http://lxml.codeplex.com   |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

''' <summary>Class to hold the Code for opening the Windows-FileProperties Dialog</summary>
''' <remarks>This Code-Segment is not compatible with Mono! A Custom Dialog still has to be designed...</remarks>
Public Class clsFilePropertiesDialog

    ''' <summary>
    ''' Method to show Windows-Properties-Dialog for a File
    ''' </summary>
    ''' <param name="FileName">Full Path to the File that shouldbe used</param>
    Public Shared Sub OpenFileProperties(ByVal FileName As String)
        _callDisplayFileProperties(FileName)
    End Sub

#Region " internal code (implementation) "

    ''' <summary>
    ''' Constant Value for the File-Properties Windows-Dialog
    ''' </summary>
    Private Const SW_SHOW As Short = 5
    ''' <summary>
    ''' Constant Value for the File-Properties Windows-Dialog
    ''' </summary>
    Private Const SEE_MASK_INVOKEIDLIST As Short = &HCS
    ''' <summary>
    ''' Structure for the Dialog-Call
    ''' </summary>
    Private Structure SHELLEXECUTEINFO
        Dim cbSize As Integer
        Dim fMask As Integer
        Dim hwnd As Integer
        Dim lpVerb As String
        Dim lpFile As String
        Dim lpParameters As String
        Dim lpDirectory As String
        Dim nShow As Integer
        Dim hInstApp As Integer
        ' optional fields
        Dim lpIDList As Integer
        Dim lpClass As String
        Dim hkeyClass As Integer
        Dim dwHotKey As Integer
        Dim hIcon As Integer
        Dim hProcess As Integer
    End Structure
    ''' <summary>
    ''' Declaration of the needed Windows-Function from shell32.dll
    ''' </summary>
    Private Declare Function ShellExecuteEx Lib "shell32.dll" (ByRef s As SHELLEXECUTEINFO) As Integer
    ''' <summary>
    ''' Call the Windows-Function to Display the Dialog
    ''' </summary>
    ''' <param name="sFullFileAndPathName">Full path to File that should be used</param>
    Private Shared Sub _callDisplayFileProperties(ByVal sFullFileAndPathName As String)
        Dim shInfo As New SHELLEXECUTEINFO
        With shInfo
            .cbSize = Len(shInfo)
            .lpFile = sFullFileAndPathName
            .nShow = SW_SHOW
            .fMask = SEE_MASK_INVOKEIDLIST
            .lpVerb = "properties"
        End With
        ShellExecuteEx(shInfo)
    End Sub

#End Region

End Class
