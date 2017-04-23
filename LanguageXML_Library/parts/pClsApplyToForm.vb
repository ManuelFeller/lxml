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

#Region " Auto-Apply Text to Form & Elements "

    ''' <summary>
    ''' apply the language-specific Strings to the elements in a Form - prefix of Form-Elements and Language-Items is the same...
    ''' </summary>
    ''' <param name="ApplyTo">the Form to "process"...</param>
    ''' <param name="ElementPrefix">the Name-prefix-string for the Elements to handle...</param>
    ''' <param name="SetFormText">optional do not change form-name (for dynamic titles)...</param>
    ''' <param name="DefaultFallback">optional do no DefaultFallback...</param>
    ''' <remarks><p>This Method sets the .Text-Property of all prepared Form-Controls (prepared means the Name starts with the prefix defined in the Method-Call Parameters).<br />
    ''' This overload is used if the prefix of the Control-Names and the Language-Items are the same.</p>
    ''' <p>If you use &quot;DefaultFallback&quot; the Class sets the Value of the Default-Language if the Item of the active Language is empty...</p>
    ''' <p>If you use &quot;SetFormText&quot; the From is the only Object that must not have a Prefix in it's Name - but the Item in LanguageXML must contain it...</p>
    ''' <example>
    ''' <p>Settings:
    ''' <ul>
    ''' <li>&quot;ElementPrefix&quot; is &quot;lx_&quot;</li>
    ''' <li>&quot;SetFormText&quot; is &quot;TRUE&quot;</li>
    ''' </ul></p>
    ''' <p>Result:
    ''' <ul>
    ''' <li>Form &quot;frmMain&quot; gets the Value of Item &quot;lx_frmMain&quot;</li>
    ''' <li>every supported Control on Form where the Name starts with &quot;lx_&quot; gets the Value of the identical named LanguageXML-Item</li>
    ''' </ul></p>
    ''' </example></remarks>
    Public Sub ApplyTextToForm(ByRef ApplyTo As System.Windows.Forms.Form, ByVal ElementPrefix As String, Optional ByVal SetFormText As Boolean = True, Optional ByVal DefaultFallback As Boolean = True)
        ' if wished try to set the Form-Name
        If SetFormText Then
            Try
                ApplyTo.Text = _lxmlBase.GetLangValueByName(ElementPrefix & ApplyTo.Name, My.Resources.str_xml_TableLangDataPrefix & _lxmlBase.SelectedLanguage, DefaultFallback)
            Catch ex As Exception
                MsgBox("Error:" & vbCrLf & "... setting Property .Text of """ & ApplyTo.Name & """ failed ...", MsgBoxStyle.Exclamation, "LanguageXML AutoApply:")
            End Try
        End If
        ' call internal worker for all Controls with passed Settings
        _lxmlBase.ApplyTexts_ToForm(ApplyTo, ElementPrefix, ElementPrefix, DefaultFallback)
    End Sub
    ''' <summary>
    ''' apply the language-specific Strings to the elements in a Form - prefix of Form-Elements and Language-Items is diffrent...
    ''' </summary>
    ''' <param name="ApplyTo">the Form to "process"...</param>
    ''' <param name="FormElementPrefix">the Name-prefix-string for the Form-Elements to handle...</param>
    ''' <param name="lxmlElementPrefix">the Name-prefix-string for the Language-Elements to handle...</param>
    ''' <param name="SetFormText">optional do not change form-name (for dynamic titles)...</param>
    ''' <param name="DefaultFallback">optional do no DefaultFallback...</param>
    ''' <remarks><p>This Method sets the .Text-Property of all prepared Form-Controls (prepared means the Name starts with the prefix defined in the Method-Call Parameters).<br />
    ''' This overload is used if the prefix of the Control-Names and the Language-Items are diffrent.</p>
    ''' <p>If you use &quot;DefaultFallback&quot; the Class sets the Value of the Default-Language if the Item of the active Language is empty...</p>
    ''' <p>If you use &quot;SetFormText&quot; the From is the only Object that must not have a Prefix in it's Name - but the Item in LanguageXML must contain it...</p>
    ''' <example>
    ''' <p>Settings:
    ''' <ul>
    ''' <li>&quot;FormElementPrefix&quot; is &quot;lx_&quot;</li>
    ''' <li>&quot;lxmlElementPrefix&quot; is &quot;as_mf_&quot;</li>
    ''' <li>&quot;SetFormText&quot; is &quot;TRUE&quot;</li>
    ''' </ul></p>
    ''' <p>Result:
    ''' <ul>
    ''' <li>Form &quot;frmMain&quot; gets the Value of Item &quot;as_mf_frmMain&quot;</li>
    ''' <li>every supported Control on Form where the Name starts with &quot;lx_&quot; gets the Value of the LanguageXML-Item that has the defined prefix and is named &quot;identical&quot;...<br />
    ''' (in this case identical means if you compare without prefix --> Control &quot;lx_lblHeadline&quot; gets Value of Item &quot;as_mf_lblHeadline&quot;, ...)</li>
    ''' </ul></p>
    ''' </example></remarks>
    Public Sub ApplyTextToForm(ByRef ApplyTo As System.Windows.Forms.Form, ByVal FormElementPrefix As String, ByVal lxmlElementPrefix As String, Optional ByVal SetFormText As Boolean = True, Optional ByVal DefaultFallback As Boolean = True)
        ' if wished try to set the Form-Name
        If SetFormText Then
            Try
                ApplyTo.Text = _lxmlBase.GetLangValueByName(lxmlElementPrefix & ApplyTo.Name, My.Resources.str_xml_TableLangDataPrefix & _lxmlBase.SelectedLanguage, DefaultFallback)
            Catch ex As Exception
                MsgBox("Error:" & vbCrLf & "... setting Property .Text of """ & ApplyTo.Name & """ failed ...", MsgBoxStyle.Exclamation, "LanguageXML AutoApply:")
            End Try
        End If
        ' call internal worker for all Controls with passed Settings
        _lxmlBase.ApplyTexts_ToForm(ApplyTo, FormElementPrefix, lxmlElementPrefix, DefaultFallback)
    End Sub
    ''' <summary>
    ''' apply the language-specific Strings to the elements in a Form - prefix of Form-Elements and Language-Items is diffrent; Element for Form to handle has own prefix...
    ''' </summary>
    ''' <param name="ApplyTo">the Form to "process"...</param>
    ''' <param name="FormElementPrefix">the Name-prefix-string for the Form-Elements to handle...</param>
    ''' <param name="lxmlElementPrefix">the Name-prefix-string for the Language-Elements to handle...</param>
    ''' <param name="lxmlFormElementPrefix">the Name-prefix-string for the Form to handle...</param>
    ''' <param name="DefaultFallback">optional do no DefaultFallback...</param>
    ''' <remarks><p>This Method sets the .Text-Property of all prepared Form-Controls (prepared means the Name starts with the prefix defined in the Method-Call Parameters).<br />
    ''' This overload is used if the prefix of the Control-Names and the Language-Items for Controls and From are diffrent.</p>
    ''' <p>If you use &quot;DefaultFallback&quot; the Class sets the Value of the Default-Language if the Item of the active Language is empty...</p>
    ''' <p>If you use &quot;SetFormText&quot; the From is the only Object that must not have a Prefix in it's Name - but the Item in LanguageXML must contain it...</p>
    ''' <example>
    ''' <p>Settings:
    ''' <ul>
    ''' <li>&quot;FormElementPrefix&quot; is &quot;lx_&quot;</li>
    ''' <li>&quot;lxmlElementPrefix&quot; is &quot;as_mf_&quot;</li>
    ''' <li>&quot;lxmlFormElementPrefix&quot; is &quot;as_frm_&quot;</li>
    ''' <li>&quot;SetFormText&quot; is &quot;TRUE&quot;</li>
    ''' </ul></p>
    ''' <p>Result:
    ''' <ul>
    ''' <li>Form &quot;frmMain&quot; gets the Value of Item &quot;as_frm_frmMain&quot;</li>
    ''' <li>every supported Control on Form where the Name starts with &quot;lx_&quot; gets the Value of the LanguageXML-Item that has the defined prefix and is named &quot;identical&quot;...<br />
    ''' (in this case identical means if you compare without prefix --> Control &quot;lx_lblHeadline&quot; gets Value of Item &quot;as_mf_lblHeadline&quot;, ...)</li>
    ''' </ul></p>
    ''' </example></remarks>
    Public Sub ApplyTextToForm(ByRef ApplyTo As System.Windows.Forms.Form, ByVal FormElementPrefix As String, ByVal lxmlElementPrefix As String, ByVal lxmlFormElementPrefix As String, Optional ByVal DefaultFallback As Boolean = True)
        ' try to set the Form-Name
        Try
            ApplyTo.Text = _lxmlBase.GetLangValueByName(lxmlFormElementPrefix & ApplyTo.Name, My.Resources.str_xml_TableLangDataPrefix & _lxmlBase.SelectedLanguage, DefaultFallback)
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & "... setting Property .Text of """ & ApplyTo.Name & """ failed ...", MsgBoxStyle.Exclamation, "LanguageXML AutoApply:")
        End Try
        ' call internal worker for all Controls with passed Settings
        _lxmlBase.ApplyTexts_ToForm(ApplyTo, FormElementPrefix, lxmlElementPrefix, DefaultFallback)
    End Sub

#End Region

End Class