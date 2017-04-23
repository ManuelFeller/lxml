' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |   Language XML Editor  |   http://lxml.codeplex.com   |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

''' <summary>Class to handle Meta-Informations in a File</summary>
Public Class clsFileMetaData

#Region " internal Fields "

    ''' <summary>
    ''' the Program-Name
    ''' </summary>
    Private _Program As String

    ''' <summary>
    ''' the Description for the File
    ''' </summary>
    Private _Description As String

    ''' <summary>
    ''' the Last Update for the File
    ''' </summary>
    Private _LastUpDate As Date

    ''' <summary>
    ''' changes since last AcceptChanges?
    ''' </summary>
    Private _changes As Boolean

#End Region

#Region " Events for Update-Message(s) "

    ''' <summary>
    ''' Event to fire the Signal for a DataChange to GUI
    ''' </summary>
    Public Event UpDateChanged()

#End Region

#Region " Constructor "

    ''' <summary>
    ''' init an empty Instance
    ''' </summary>
    Public Sub New()
        _Program = ""
        _Description = ""
        _LastUpDate = Date.Now
        _changes = False
    End Sub

    ''' <summary>
    ''' init an Instance with defined date
    ''' </summary>
    ''' <param name="LastUpdate">initial LastChanges-Date to use</param>
    ''' <remarks>accepts changes automatically</remarks>
    Public Sub New(ByVal LastUpdate As Date)
        _Program = ""
        _Description = ""
        _LastUpDate = LastUpdate
        _changes = False
    End Sub

    ''' <summary>
    ''' init an Instance with defined last Update and Program
    ''' </summary>
    ''' <param name="LastUpdate">initial LastChanges-Date to use</param>
    ''' <param name="Program">initial Program-Text to use</param>
    ''' <remarks>accepts changes automatically</remarks>
    Public Sub New(ByVal LastUpdate As Date, ByVal Program As String)
        _Program = Program
        _Description = ""
        _LastUpDate = LastUpdate
        _changes = False
    End Sub

    ''' <summary>
    ''' init an Instance with defined Fields
    ''' </summary>
    ''' <param name="LastUpdate">initial LastChanges-Date to use</param>
    ''' <param name="Program">initial Program-Text to use</param>
    ''' <param name="Description">initial Description-Text to use</param>
    ''' <remarks>accepts changes automatically</remarks>
    Public Sub New(ByVal LastUpdate As Date, ByVal Program As String, ByVal Description As String)
        _Program = Program
        _Description = Description
        _LastUpDate = LastUpdate
        _changes = False
    End Sub


#End Region

#Region " public Properties "

    ''' <summary>
    ''' get / set Program-Name
    ''' </summary>
    Public Property Program() As String
        Get
            Return _Program
        End Get
        Set(ByVal value As String)
            _Program = value
            _changes = True
            _LastUpDate = Date.Now
            RaiseEvent UpDateChanged()
            Application.DoEvents()
        End Set
    End Property

    ''' <summary>
    ''' get / set Description-Text
    ''' </summary>
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
            _changes = True
            _LastUpDate = Date.Now
            RaiseEvent UpDateChanged()
            Application.DoEvents()
        End Set
    End Property

    ''' <summary>
    ''' get / set Date of last Update
    ''' </summary>
    Public Property LastUpdate() As Date
        Get
            Return _LastUpDate
        End Get
        Set(ByVal value As Date)
            _LastUpDate = value
            _changes = True
            RaiseEvent UpDateChanged()
            Application.DoEvents()
        End Set
    End Property

    ''' <summary>
    ''' Was the Meta-Data changed since the last AcceptChanges() / Class-Init?
    ''' </summary>
    ''' <returns>TRUE if there were changes, FALSE if not</returns>
    Public ReadOnly Property HasChanges() As Boolean
        Get
            Return _changes
        End Get
    End Property

#End Region

#Region " public Methods and Functions "

    ''' <summary>
    ''' try to set last Update using a String-Value
    ''' </summary>
    ''' <param name="DateValue">String with Date</param>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Public Function ApplyLastUpdate(ByVal DateValue As String) As Boolean
        Dim _tmpDate As Date
        ' ! TryParse can not read Date in invariant Culture by default !
        If Not Date.TryParse(DateValue, _tmpDate) Then
            ' try custom reader for Format:
            If Not clsReadIvCultureDate.TryParse(DateValue, _tmpDate) Then
                Return False
            End If
        End If
        _LastUpDate = _tmpDate
        _changes = True
        RaiseEvent UpDateChanged()
        Application.DoEvents()
        Return True
    End Function

    ''' <summary>
    ''' set Date.Now as new last Update
    ''' </summary>
    Public Sub SetNowAsUpDate()
        _LastUpDate = Date.Now
        _changes = True
        RaiseEvent UpDateChanged()
        Application.DoEvents()
    End Sub

    ''' <summary>
    ''' Accept changes since last call of this Function / Class-Init on Meta-Data (HasChanges is false then)
    ''' </summary>
    Public Sub AcceptChanges()
        _changes = False
    End Sub

#End Region

End Class