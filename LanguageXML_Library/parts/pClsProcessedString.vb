' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Language XML Base Class |   http://lxml.codeplex.com  |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' | Authors:                                              |
' | ========                                              |
' | - Manuel a.k.a. Dade [DD-Productions]                 |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =
' |    visit the CodePlex-Page for License and Details    |
' = - = - = - = - = - = - = - = - = - = - = - = - = - = - =

Partial Public Class LanguageXML
    ' this Code is part of the public Interface of the class

#Region " processed String (with replaced Placeholder(s)) "

    ''' <summary>get a processed string-value from the active language by ID</summary>
    ''' <param name="ID">ID of the LXML-Item to load</param>
    ''' <param name="ReplaceThis">the String that should be replaced</param>
    ''' <param name="ReplaceWith">the String that should be inserted</param>
    ''' <param name="DefaultFallback">optional you can decativate the DefaultFallback function</param>
    ''' <returns>processed string-value for the active language</returns>
    ''' <remarks>Function to read a processed Value (Language-Value with replaced Placeholders) for the active Language using the Item-ID.<br />
    ''' <b>It has the same function like the overload using the Item-Name - but this way is not recommended!</b>
    ''' <p>This function may be used to avoid the internal step to get the ID before reading the Value (for example on slow Systems).<br />
    ''' Because ID's are auto-generated, an accidential deleted Value can get a new ID - think about that if you want to use this Overload..!</p></remarks>
    Public Function ReadProcessedValue(ByVal ID As Integer, ByVal ReplaceThis As String, ByVal ReplaceWith As String, Optional ByVal DefaultFallback As Boolean = True) As String
        ' load a processed Value by Name
        Dim _element As New ReplaceElements
        _element.ReplaceThis = ReplaceThis
        _element.ReplaceWith = ReplaceWith
        Return ReadProcessedValue(ID, _element, DefaultFallback)
    End Function
    ''' <summary>get a processed string-value from the active language by Name</summary>
    ''' <param name="Name">Name of the LXML-Item to load</param>
    ''' <param name="ReplaceThis">the String that should be replaced</param>
    ''' <param name="ReplaceWith">the String that should be inserted</param>
    ''' <param name="DefaultFallback">optional you can decativate the DefaultFallback function</param>
    ''' <returns>processed string-value for the active language</returns>
    ''' <remarks>This overload (using the Item-Name) is the easiest if there is just one Placeholder to replace - just pass the two needed Strings...</remarks>
    Public Function ReadProcessedValue(ByVal Name As String, ByVal ReplaceThis As String, ByVal ReplaceWith As String, Optional ByVal DefaultFallback As Boolean = True) As String
        ' load a processed Value by Name
        Dim _element As New ReplaceElements
        _element.ReplaceThis = ReplaceThis
        _element.ReplaceWith = ReplaceWith
        Return ReadProcessedValue(Name, _element, DefaultFallback)
    End Function

    ''' <summary>get a processed string-value from the active language by ID</summary>
    ''' <param name="ID">ID of the LXML-Item to load</param>
    ''' <param name="ReplaceData">ReplaceData-Element</param>
    ''' <param name="DefaultFallback">optional you can decativate the DefaultFallback function</param>
    ''' <returns>processed string-value for the active language</returns>
    ''' <remarks>Function to read a processed Value (Language-Value with replaced Placeholders) for the active Language using the Item-ID.<br />
    ''' <b>It has the same function like the overload using the Item-Name - but this way is not recommended!</b>
    ''' <p>This function may be used to avoid the internal step to get the ID before reading the Value (for example on slow Systems).<br />
    ''' Because ID's are auto-generated, an accidential deleted Value can get a new ID - think about that if you want to use this Overload..!</p></remarks>
    Public Function ReadProcessedValue(ByVal ID As Integer, ByVal ReplaceData As ReplaceElements, Optional ByVal DefaultFallback As Boolean = True) As String
        ' load a processed Value by Name
        Dim _elements(0) As ReplaceElements
        _elements(0) = ReplaceData
        Return ReadProcessedValue(ID, _elements, DefaultFallback)
    End Function
    ''' <summary>get a processed string-value from the active language by Name</summary>
    ''' <param name="Name">Name of the LXML-Item to load</param>
    ''' <param name="ReplaceData">ReplaceData-Element</param>
    ''' <param name="DefaultFallback">optional you can decativate the DefaultFallback function</param>
    ''' <returns>processed string-value for the active language</returns>
    ''' <remarks>This overload (using the Item-Name) is another way if there is just one Placeholder to replace - you pass a ReplaceData-Element instead of two Strings...</remarks>
    Public Function ReadProcessedValue(ByVal Name As String, ByVal ReplaceData As ReplaceElements, Optional ByVal DefaultFallback As Boolean = True) As String
        ' load a processed Value by Name
        Dim _elements(0) As ReplaceElements
        _elements(0) = ReplaceData
        Return ReadProcessedValue(Name, _elements, DefaultFallback)
    End Function

    ''' <summary>processed string-value from the active language by ID</summary>
    ''' <param name="Name">Name of the LXML-Item to load</param>
    ''' <param name="ReplaceData">List of ReplaceData-Elements</param>
    ''' <param name="DefaultFallback">optional you can decativate the DefaultFallback function</param>
    ''' <returns>processed string-value for the active language</returns>
    ''' <remarks>Function to read a processed Value (Language-Value with replaced Placeholders) for the active Language using the Item-ID.<br />
    ''' <b>It has the same function like the overload using the Item-Name - but this way is not recommended!</b>
    ''' <p>This function may be used to avoid the internal step to get the ID before reading the Value (for example on slow Systems).<br />
    ''' Because ID's are auto-generated, an accidential deleted Value can get a new ID - think about that if you want to use this Overload..!</p></remarks>
    Public Function ReadProcessedValue(ByVal Name As String, ByVal ReplaceData As List(Of ReplaceElements), Optional ByVal DefaultFallback As Boolean = True) As String
        ' load a processed Value by Name
        If ReplaceData.Count < 1 Then
            Throw New Exception("List with Replace-Data can not be empty...")
        End If
        Dim _elements(ReplaceData.Count - 1) As ReplaceElements
        For i As Integer = 0 To ReplaceData.Count - 1
            _elements(i) = ReplaceData(i)
        Next
        Return ReadProcessedValue(Name, _elements, DefaultFallback)
    End Function
    ''' <summary>processed string-value from the active language by Name</summary>
    ''' <param name="ID">ID of the LXML-Item to load</param>
    ''' <param name="ReplaceData">List of ReplaceData-Elements</param>
    ''' <param name="DefaultFallback">optional you can decativate the DefaultFallback function</param>
    ''' <returns>processed string-value for the active language</returns>
    ''' <remarks>This overload (using the Item-Name) is a way to change multiple Placeholders - you have to pass a List of ReplaceData-Elements if you use this overload...</remarks>
    Public Function ReadProcessedValue(ByVal ID As Integer, ByVal ReplaceData As List(Of ReplaceElements), Optional ByVal DefaultFallback As Boolean = True) As String
        ' load a processed Value by Name
        If ReplaceData.Count < 1 Then
            Throw New Exception("List with Replace-Data can not be empty...")
        End If
        Dim _elements(ReplaceData.Count - 1) As ReplaceElements
        For i As Integer = 0 To ReplaceData.Count - 1
            _elements(i) = ReplaceData(i)
        Next
        Return ReadProcessedValue(ID, _elements, DefaultFallback)
    End Function

    ' base-worker for other overloads
    ''' <summary>get a processed string-value from the active language by ID</summary>
    ''' <param name="ID">ID of the LXML-Item to load</param>
    ''' <param name="ReplaceData">ReplaceData Array</param>
    ''' <param name="DefaultFallback">optional you can decativate the DefaultFallback function</param>
    ''' <returns>processed string-value for the active language</returns>
    ''' <remarks>Function to read a processed Value (Language-Value with replaced Placeholders) for the active Language using the Item-ID.<br />
    ''' <b>It has the same function like the overload using the Item-Name - but this way is not recommended!</b>
    ''' <p>This function may be used to avoid the internal step to get the ID before reading the Value (for example on slow Systems).<br />
    ''' Because ID's are auto-generated, an accidential deleted Value can get a new ID - think about that if you want to use this Overload..!</p></remarks>
    Public Function ReadProcessedValue(ByVal ID As Integer, ByVal ReplaceData As ReplaceElements(), Optional ByVal DefaultFallback As Boolean = True) As String
        Return _lxmlBase.ReadProcessedValue(ID, ReplaceData, DefaultFallback)
    End Function
    ''' <summary>
    ''' get a processed string-value from the active language by Name
    ''' </summary>
    ''' <param name="Name">Name of the LXML-Item to load</param>
    ''' <param name="ReplaceData">ReplaceData Array</param>
    ''' <param name="DefaultFallback">optional you can decativate the DefaultFallback function</param>
    ''' <returns>processed string-value for the active language</returns>
    ''' <remarks>This overload (using the Item-Name) is a way to change multiple Placeholders - you have to pass an Array of ReplaceData-Elements if you use this overload...</remarks>
    Public Function ReadProcessedValue(ByVal Name As String, ByVal ReplaceData As ReplaceElements(), Optional ByVal DefaultFallback As Boolean = True) As String
        Return _lxmlBase.ReadProcessedValue(Name, ReplaceData, DefaultFallback)
    End Function

#End Region

End Class