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

#Region " regular Value-Read "

    ''' <summary>get a string-value from the active language by ID</summary>
    ''' <param name="ID">ID of the LXML-Item to load</param>
    ''' <param name="DefaultFallback">optional you can decativate the DefaultFallback function</param>
    ''' <returns>string-value for the active language</returns>
    ''' <remarks>Function to read a Value for the active Language using the Item-ID.<br />
    ''' <b>This way is not recommended!</b>
    ''' <p>This function may be used to avoid the internal step to get the ID before reading the Value (for example on slow Systems).<br />
    ''' Because ID's are auto-generated, an accidential deleted Value can get a new ID - think about that if you want to use this Version..!</p></remarks>
    Public Function ReadValue(ByVal ID As Integer, Optional ByVal DefaultFallback As Boolean = True) As String
        Return _lxmlBase.GetLangValueByID(ID.ToString, My.Resources.str_xml_TableLangDataPrefix & _lxmlBase.SelectedLanguage, DefaultFallback)
    End Function
    ''' <summary>get a string-value from the active language by Name</summary>
    ''' <param name="Name">Name of the LXML-Item to load (case-sensitive)</param>
    ''' <param name="DefaultFallback">optional you can decativate the DefaultFallback function</param>
    ''' <returns>string-value for the active language</returns>
    ''' <remarks>Function to read a Value for the active Language using the Item-Name (recommended Version).</remarks>
    Public Function ReadValue(ByVal Name As String, Optional ByVal DefaultFallback As Boolean = True) As String
        Return _lxmlBase.GetLangValueByName(Name, My.Resources.str_xml_TableLangDataPrefix & _lxmlBase.SelectedLanguage, DefaultFallback)
    End Function

#End Region

End Class