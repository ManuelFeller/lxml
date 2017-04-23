' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |   AES Rijndael Class   |   http://lxml.codeplex.com   |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

''' <summary>Class to encrypt / decrypt strings using AES (Rijndael)</summary>
Public Class Rijndael

    ''' <summary>
    ''' internal field for selected encoding
    ''' </summary>
    Private _encoder As System.Text.Encoding

    ''' <summary>
    ''' init new instance with UTF8-Encoding
    ''' </summary>
    Public Sub New()
        _encoder = System.Text.Encoding.UTF8
    End Sub

    ''' <summary>
    ''' init new instance with user-defined Encoding
    ''' </summary>
    ''' <param name="Encoding">the Encoding to use</param>
    Public Sub New(ByVal Encoding As System.Text.Encoding)
        _encoder = Encoding
    End Sub

    ''' <summary>
    ''' get / set the Text-Encoding to use for encrypt / decrypt
    ''' </summary>
    Public Property Encoder() As System.Text.Encoding
        Get
            Return _encoder
        End Get
        Set(ByVal value As System.Text.Encoding)
            _encoder = value
        End Set
    End Property

    ''' <summary>
    ''' get the DLL-Version
    ''' </summary>
    Public ReadOnly Property DllVersion() As System.Version
        Get
            Return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
        End Get
    End Property

    ' simple encrypt / decrypt (single run)

    ''' <summary>
    ''' "quick-use" Wrapper for EncryptString - returns result direcly
    ''' </summary>
    ''' <param name="StringData">String that should be encrypted</param>
    ''' <param name="PwdString">Password to use for encryption</param>
    ''' <returns>the encrypted String or "" on error</returns>
    ''' <remarks></remarks>
    Public Function EasyEncrypt(ByVal StringData As String, ByVal PwdString As String) As String
        If Not StringEncrypt(StringData, PwdString) Then Return ""
        Return StringData
    End Function
    ''' <summary>
    ''' "quick-use" Wrapper for EncryptString - returns result direcly
    ''' </summary>
    ''' <param name="StringData">String that should be decrypted</param>
    ''' <param name="PwdString">Password to use for decryption</param>
    ''' <returns>the decrypted String or "" on error</returns>
    ''' <remarks></remarks>
    Public Function EasyDecrypt(ByVal StringData As String, ByVal PwdString As String) As String
        If Not StringDecrypt(StringData, PwdString) Then Return ""
        Return StringData
    End Function

    ' simple encrypt / decrypt (multiple runs)
    ''' <summary>
    ''' "quick-use" Wrapper for EncryptString - calling it n times, returns result direcly
    ''' </summary>
    ''' <param name="StringData">String that should be encrypted</param>
    ''' <param name="PwdString">Password to use for encryption</param>
    ''' <param name="Cycles">number of encrypt-cycles to perform (must be 1 or more - should be less then 25)</param>
    ''' <returns>the encrypted String or "" on error</returns>
    ''' <remarks></remarks>
    Public Function EasyEncrypt(ByVal StringData As String, ByVal PwdString As String, ByVal Cycles As Integer) As String
        Dim _tmpdata As String = StringData
        If Cycles < 1 Then Cycles = 1
        For i As Integer = 0 To Cycles - 1
            If Not StringEncrypt(_tmpdata, PwdString) Then Return ""
        Next
        Return _tmpdata
    End Function
    ''' <summary>
    ''' "quick-use" Wrapper for EncryptString - calling it n times, returns result direcly
    ''' </summary>
    ''' <param name="StringData">String that should be decrypted</param>
    ''' <param name="PwdString">Password to use for decryption</param>
    ''' <param name="Cycles">number of decrypt-cycles to perform (must be 1 or more - should be less then 25)</param>
    ''' <returns>the decrypted String or "" on error</returns>
    ''' <remarks></remarks>
    Public Function EasyDecrypt(ByVal StringData As String, ByVal PwdString As String, ByVal Cycles As Integer) As String
        Dim _tmpdata As String = StringData
        If Cycles < 1 Then Cycles = 1
        For i As Integer = 0 To Cycles - 1
            If Not StringDecrypt(_tmpdata, PwdString) Then Return ""
        Next
        Return _tmpdata
    End Function

    ' basic Rijndael-Functions
    ''' <summary>
    ''' encrypt a referenced String using Rijndael
    ''' </summary>
    ''' <param name="StringData">reference to String that should be encrypted</param>
    ''' <param name="PwdString">Password to use for encryption</param>
    ''' <returns>boolean information if operation was successful</returns>
    ''' <remarks></remarks>
    Public Function StringEncrypt(ByRef StringData As String, ByVal PwdString As String) As Boolean
        Dim rd As New System.Security.Cryptography.RijndaelManaged ' Rijndael-Objekt anlegen
        Dim md5 As New System.Security.Cryptography.MD5CryptoServiceProvider ' MD5-Objekt anlegen
        Dim key() As Byte = md5.ComputeHash(_encoder.GetBytes(PwdString)) ' Verschlüsselungskennwort in MD5-Bytes
        md5.Clear() ' MD5-Objekt leeren
        rd.Key = key ' Schlüssel auf Objekt anwenden
        rd.GenerateIV() ' Generieren eines Random-Init-Vektor
        Dim iv() As Byte = rd.IV ' Vektor zuweisen
        Dim ms As New System.IO.MemoryStream ' Objekt für Daten
        ms.Write(iv, 0, iv.Length) ' Daten in Objekt schreiben
        Dim cs As New System.Security.Cryptography.CryptoStream(ms, rd.CreateEncryptor, System.Security.Cryptography.CryptoStreamMode.Write) ' CryptoStream erzeugen
        Dim data() As Byte = _encoder.GetBytes(StringData) ' Binary-Data des Input erzegen
        cs.Write(data, 0, data.Length) ' Daten in Objekt scheriben
        cs.FlushFinalBlock() ' Verschlüsselung auf Daten anwenden
        Dim encdata() As Byte = ms.ToArray() ' Verschlüsselte Daten in Byte-Array schreiben
        StringData = Convert.ToBase64String(encdata) ' Byte-Array als Base64String ausgeben
        cs.Close() ' CryptoStream-Objekt schließen
        rd.Clear() ' Rijndael-Objekt leeren
        Return True
    End Function
    ''' <summary>
    ''' decrypt a referenced String using Rijndael
    ''' </summary>
    ''' <param name="StringData">reference to String that should be decrypted</param>
    ''' <param name="PwdString">Password to use for decryption</param>
    ''' <returns>boolean information if operation was successful</returns>
    ''' <remarks></remarks>
    Public Function StringDecrypt(ByRef StringData As String, ByVal PwdString As String) As Boolean
        Dim rd As New System.Security.Cryptography.RijndaelManaged ' Rijndael-Objekt anlegen
        Dim rijndaelIvLength As Integer = 16 ' Variable für Länge anlegen
        Dim md5 As New System.Security.Cryptography.MD5CryptoServiceProvider ' MD5-Objekt anlegen
        Dim key() As Byte = md5.ComputeHash(_encoder.GetBytes(PwdString)) ' Verschlüsselungskennwort in MD5-Bytes
        md5.Clear() ' MD5-Objekt leeren
        Dim encdata() As Byte ' Variable für Datenverarbeitung anlegen
        Try
            encdata = Convert.FromBase64String(StringData) ' String in Byte-Array umwandeln
        Catch ex As Exception
            Return False
        End Try
        Dim ms As New System.IO.MemoryStream(encdata)  ' Objekt für Daten
        Dim iv(15) As Byte ' Byte-Array anlegen
        ms.Read(iv, 0, rijndaelIvLength) ' Daten in Objekt schreiben
        rd.IV = iv ' Init-Vektor des Objekt setzen
        rd.Key = key ' Schlüssel des Objekt setzen
        Dim cs As New System.Security.Cryptography.CryptoStream(ms, rd.CreateDecryptor, System.Security.Cryptography.CryptoStreamMode.Read) ' CryptoStream erzegen
        Dim data() As Byte
        Try
            ReDim data(ms.Length - rijndaelIvLength) ' Array für Binary-Data des Input erzeugen
        Catch ex As Exception
            Return False
        End Try
        Dim i As Integer ' Rückgabemerker
        Try
            i = cs.Read(data, 0, data.Length) ' Entschlüsselte Daten auslesen
        Catch ex As Exception
            Return False
        End Try
        StringData = _encoder.GetString(data, 0, i) ' Byte-Array als String ausgeben
        cs.Close() 'CryptoStream-Objekt schließen
        rd.Clear() ' Rijndael-Objekt leeren
        Return True
    End Function

End Class