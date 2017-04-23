' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |   Language XML Editor  |   http://lxml.codeplex.com   |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

''' <summary>Class to read String with Date-Value in Invariant Culture ( Example-Value: "11/30/2009 17:45:00" )</summary>
Friend Class clsReadIvCultureDate

    ''' <summary>convert a Date-String in Format of invariant Culture to Date</summary>
    ''' <param name="DateValue">the String-Value to parse</param>
    ''' <returns>the Date-Value if the String is in valid Format</returns>
    ''' <exception cref="Exception">Thrown if the Value could not be converted to a Date - Details in Message-Text...</exception>
    Public Shared Function Parse(ByVal DateValue As String) As Date
        Dim _intDate As String = DateValue.Trim ' remove spaces around
        Dim _singlevalues(5) As Short
        ' 11/30/2009 17:00:00
        If _intDate.Length = 19 Then ' Lenght match
            ' read values
            _singlevalues(0) = Short.Parse(_intDate.Substring(0, 2)) ' get month
            _singlevalues(1) = Short.Parse(_intDate.Substring(3, 2)) ' get day
            _singlevalues(2) = Short.Parse(_intDate.Substring(6, 4)) ' get year
            _singlevalues(3) = Short.Parse(_intDate.Substring(11, 2)) ' get hour
            _singlevalues(4) = Short.Parse(_intDate.Substring(14, 2)) ' get minute
            _singlevalues(5) = Short.Parse(_intDate.Substring(17, 2)) ' get second
            ' check values if valid
            If _singlevalues(0) < 1 Or _singlevalues(0) > 12 Then ' check month
                Throw New Exception("Value """ & _singlevalues(0).ToString & """ not valid as Month...")
            End If
            If _singlevalues(1) < 1 Or _singlevalues(1) > 31 Then ' check day
                Throw New Exception("Value """ & _singlevalues(1).ToString & """ not valid as Day...")
            End If
            If _singlevalues(2) < 1 Or _singlevalues(2) > 2999 Then ' check year
                Throw New Exception("Value """ & _singlevalues(2).ToString & """ not valid as Year...")
            End If
            If _singlevalues(3) < 0 Or _singlevalues(3) > 23 Then ' check hour
                Throw New Exception("Value """ & _singlevalues(3).ToString & """ not valid as Hour...")
            End If
            If _singlevalues(4) < 0 Or _singlevalues(4) > 59 Then ' check minutes
                Throw New Exception("Value """ & _singlevalues(4).ToString & """ not valid as Minute...")
            End If
            If _singlevalues(5) < 0 Or _singlevalues(5) > 59 Then ' check seconds
                Throw New Exception("Value """ & _singlevalues(5).ToString & """ not valid as Second...")
            End If
            ' return new date from value
            Return New Date(_singlevalues(2), _singlevalues(0), _singlevalues(1), _singlevalues(3), _singlevalues(4), _singlevalues(5))
        Else ' Lenght not matching
            Throw New Exception("Length of Value """ & DateValue & """ does not Match Length of a Date-String in invariant Culture-Format (MM/dd/yyyy HH:mm:ss) ...")
        End If
    End Function

    ''' <summary>try to convert a Date-String in Format of invariant Cultrure to Date</summary>
    ''' <param name="DateValue">the String-Value to parse</param>
    ''' <param name="result">referenced Date-Object for the result</param>
    ''' <returns>TRUE on success, FALSE on error</returns>
    Public Shared Function TryParse(ByVal DateValue As String, ByRef result As Date) As Boolean
        Try
            result = Parse(DateValue)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

End Class