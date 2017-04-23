' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |   Language XML Editor  |   http://lxml.codeplex.com   |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

''' <summary>Class to handle Meta-Informations in a Language</summary>
Public Class clsLanguageMetaData

#Region " internal Fields "

    ''' <summary>
    ''' Display-Name for the Language
    ''' </summary>
    Private _DisplayName As String

    ''' <summary>
    ''' ISO-String for the Language
    ''' </summary>
    Private _IsoString As String

    ''' <summary>
    ''' version  for the Language
    ''' </summary>
    Private _Version As String

    ''' <summary>
    ''' Author for the Language
    ''' </summary>
    Private _Author As String

    ''' <summary>
    ''' Info-Text for the Language
    ''' </summary>
    Private _InfoText As String

    ''' <summary>
    ''' lastUpdate for the Language
    ''' </summary>
    Private _LastUpdate As Date

    ''' <summary>
    ''' changes since last AcceptChanges?
    ''' </summary>
    Private _changes As Boolean

#End Region

#Region " Events for Update-Message(s) "

    ''' <summary>
    ''' Event to fire the Signal for "last Update"-Change to GUI
    ''' </summary>
    Public Event UpDateChanged()

#End Region

#Region " Constructor "

    ''' <summary>
    ''' init an empty Instance
    ''' </summary>
    Public Sub New()
        _DisplayName = ""
        _IsoString = ""
        _Version = ""
        _Author = ""
        _InfoText = ""
        _LastUpdate = Date.Now
        _changes = False
    End Sub

    ''' <summary>
    ''' init an Instance with defined last Update
    ''' </summary>
    ''' <param name="LastUpdate">initial LastChanges-Date to use</param>
    Public Sub New(ByVal LastUpdate As Date)
        _DisplayName = ""
        _IsoString = ""
        _Version = ""
        _Author = ""
        _InfoText = ""
        _LastUpdate = LastUpdate
        _changes = False
    End Sub

    ''' <summary>
    ''' init an Instance with defined last Update and ISO-String
    ''' </summary>
    ''' <param name="LastUpdate">initial LastChanges-Date to use</param>
    ''' <param name="IsoString">initial ISO-String to use</param>
    Public Sub New(ByVal LastUpdate As Date, ByVal IsoString As String)
        _DisplayName = ""
        _IsoString = IsoString
        _Version = ""
        _Author = ""
        _InfoText = ""
        _LastUpdate = LastUpdate
        _changes = False
    End Sub

    ''' <summary>
    ''' init an Instance with defined last Update, ISO-String and Display-Name
    ''' </summary>
    ''' <param name="LastUpdate">initial LastChanges-Date to use</param>
    ''' <param name="IsoString">initial ISO-String to use</param>
    ''' <param name="DisplayName">initial Display-Name to use</param>
    Public Sub New(ByVal LastUpdate As Date, ByVal IsoString As String, ByVal DisplayName As String)
        _DisplayName = DisplayName
        _IsoString = IsoString
        _Version = ""
        _Author = ""
        _InfoText = ""
        _LastUpdate = LastUpdate
        _changes = False
    End Sub

    ''' <summary>
    ''' init an Instance with defined last Update, ISO-String, Display-Name and Author
    ''' </summary>
    ''' <param name="LastUpdate">initial LastChanges-Date to use</param>
    ''' <param name="IsoString">initial ISO-String to use</param>
    ''' <param name="DisplayName">initial Display-Name to use</param>
    ''' <param name="Author">initial Author to use</param>
    Public Sub New(ByVal LastUpdate As Date, ByVal IsoString As String, ByVal DisplayName As String, ByVal Author As String)
        _DisplayName = DisplayName
        _IsoString = IsoString
        _Version = ""
        _Author = Author
        _InfoText = ""
        _LastUpdate = LastUpdate
        _changes = False
    End Sub

    ''' <summary>
    ''' init an Instance with defined last Update, ISO-String, Display-Name, Author and Version
    ''' </summary>
    ''' <param name="LastUpdate">initial LastChanges-Date to use</param>
    ''' <param name="IsoString">initial ISO-String to use</param>
    ''' <param name="DisplayName">initial Display-Name to use</param>
    ''' <param name="Author">initial Author to use</param>
    ''' <param name="Version">initial Version to use</param>
    Public Sub New(ByVal LastUpdate As Date, ByVal IsoString As String, ByVal DisplayName As String, ByVal Author As String, ByVal Version As String)
        _DisplayName = DisplayName
        _IsoString = IsoString
        _Version = Version
        _Author = Author
        _InfoText = ""
        _LastUpdate = LastUpdate
        _changes = False
    End Sub

    ''' <summary>
    ''' init an Instance with defined Fields
    ''' </summary>
    ''' <param name="LastUpdate">initial LastChanges-Date to use</param>
    ''' <param name="IsoString">initial ISO-String to use</param>
    ''' <param name="DisplayName">initial Display-Name to use</param>
    ''' <param name="Author">initial Author to use</param>
    ''' <param name="Version">initial Version to use</param>
    ''' <param name="InfoText"></param>
    Public Sub New(ByVal LastUpdate As Date, ByVal IsoString As String, ByVal DisplayName As String, ByVal Author As String, ByVal Version As String, ByVal InfoText As String)
        _DisplayName = DisplayName
        _IsoString = IsoString
        _Version = Version
        _Author = Author
        _InfoText = InfoText
        _LastUpdate = LastUpdate
        _changes = False
    End Sub

#End Region

#Region " public Properties "

    ''' <summary>
    ''' get / set Display-Name
    ''' </summary>
    Public Property DisplayName() As String
        Get
            Return _DisplayName
        End Get
        Set(ByVal value As String)
            _DisplayName = value
            _changes = True
            _LastUpdate = Date.Now
            RaiseEvent UpDateChanged()
            Application.DoEvents()
        End Set
    End Property

    ''' <summary>
    ''' get / set ISO-String
    ''' </summary>
    Public Property IsoString() As String
        Get
            Return _IsoString
        End Get
        Set(ByVal value As String)
            _IsoString = value
            _changes = True
            _LastUpdate = Date.Now
            RaiseEvent UpDateChanged()
            Application.DoEvents()
        End Set
    End Property

    ''' <summary>
    ''' get / set Version
    ''' </summary>
    Public Property Version() As String
        Get
            Return _Version
        End Get
        Set(ByVal value As String)
            _Version = value
            _changes = True
            _LastUpdate = Date.Now
            RaiseEvent UpDateChanged()
            Application.DoEvents()
        End Set
    End Property

    ''' <summary>
    ''' get / set Author
    ''' </summary>
    Public Property Author() As String
        Get
            Return _Author
        End Get
        Set(ByVal value As String)
            _Author = value
            _changes = True
            _LastUpdate = Date.Now
            RaiseEvent UpDateChanged()
            Application.DoEvents()
        End Set
    End Property

    ''' <summary>
    ''' get / set Info-Text
    ''' </summary>
    Public Property InfoText() As String
        Get
            Return _InfoText
        End Get
        Set(ByVal value As String)
            _InfoText = value
            _changes = True
            _LastUpdate = Date.Now
            RaiseEvent UpDateChanged()
            Application.DoEvents()
        End Set
    End Property

    ''' <summary>
    ''' get / set Date of last Update
    ''' </summary>
    Public Property LastUpdate() As Date
        Get
            Return _LastUpdate
        End Get
        Set(ByVal value As Date)
            _LastUpdate = value
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
        _LastUpdate = _tmpDate
        _changes = True
        RaiseEvent UpDateChanged()
        Application.DoEvents()
        Return True
    End Function

    ''' <summary>
    ''' set Date.Now as new last Update
    ''' </summary>
    Public Sub SetNowAsUpDate()
        _LastUpdate = Date.Now
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