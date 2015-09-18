Module Utils

#Region "Registro"
    Public Const k_PwdDomain As String = "_PW_Access_Domain_"
    Public Const k_LoginHide As String = "_login_Hide"
    Public Const k_AutoVerifyNewVersion As String = "_login_AutoVerifyNewVersion"
    Public Const k_Registry As String = "SOFTWARE\DinaHosting\dinaIP"
    Public Const k_NotUser As String = "Unknown"

#Region "Usuario DH"
    Friend Function GetPassUser(ByVal strUser As String) As String
        Dim str As String = ReadOptionRegistry(strUser, "Password")
        Return Desencripta(str)
    End Function

    Friend Sub SavePassUser(ByVal strUser As String, ByVal strPass As String)
        UpdateOptionRegistry(strUser, "Password", Encripta(strPass))
    End Sub
#End Region

#Region "Dominio"
    Friend Function GetPassDomain(ByVal strDomain As String) As String
        Dim str As String = ReadOptionRegistry(k_NotUser, k_PwdDomain, "\" & strDomain)
        Return Desencripta(str)
    End Function

    Friend Sub SavePassDomain(ByVal strDomain As String, ByVal strPass As String)
        UpdateOptionRegistry(k_NotUser, k_PwdDomain, Encripta(strPass), "\" & strDomain)
    End Sub
#End Region

#Region "Por usuario actual"
    ''' <summary>Independientemente do logueo do usuario, obtén a info da zona do dominio</summary>
    Friend Function GetInfoZoneDomain(ByVal strDomain As String, ByVal strHost As String) As domDNS.Data.InfoZone
        Dim strUser As String = IIf(actLogin.IsDomain, k_NotUser, actLogin.Login)
        Dim oSavedInfo As Object = ReadOptionRegistry(strUser, strHost, "\" & strDomain)
        Try
            Dim strType As String = Nothing
            Dim strAddress As String = Nothing
            If TypeOf (oSavedInfo) Is Array Then
                strType = oSavedInfo(0)
                strAddress = oSavedInfo(1)
            ElseIf TypeOf (oSavedInfo) Is String Then
                strType = "URL"
                strAddress = oSavedInfo
            Else
                'Throw New Exception("UNKNOWN INFO ZONE")
                'non está almacenada... non é dinámica
                Return Nothing
            End If
            Return New domDNS.Data.InfoZone(strHost, strType, strAddress, actLogin.Login)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>Independientemente do logueo do usuario, obtén a dirección do host do dominio</summary>
    Friend Function GetAddressZoneDomain(ByVal strDomain As String, ByVal strHost As String) As String
        Dim iz As domDNS.Data.InfoZone = GetInfoZoneDomain(strDomain, strHost)
        If iz Is Nothing Then
            Return Nothing
        Else
            Return iz.Address
        End If
    End Function

    ''' <summary>Independientemente do logueo do usuario, obtén as zonas dinámicas do dominio</summary>
    Friend Function GetZonesDomain(ByVal strDomain As String) As Dictionary(Of String, domDNS.Data.InfoZone)
        Dim strUser As String = IIf(actLogin.IsDomain, k_NotUser, actLogin.Login)
        If strUser = Nothing Then Return Nothing
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(k_Registry & "\" & Encripta(strUser) & "\" & strDomain, True)
        Dim oVal As New Dictionary(Of String, domDNS.Data.InfoZone)
        Try
            Dim strValues As String() = key.GetValueNames
            For Each str As String In strValues
                Select Case str
                    Case k_PwdDomain, k_AutoVerifyNewVersion, k_LoginHide
                    Case Else
                        oVal.Add(str, GetInfoZoneDomain(strDomain, str))
                End Select
            Next
        Catch ex As Exception
        Finally
            If Not key Is Nothing Then key.Close()
        End Try
        Return oVal
    End Function

    ''' <summary>Independientemente do logueo do usuario, obtén os hosts das zonas dinámicas do dominio</summary>
    Friend Function GetHostZonesDomain(ByVal strDomain As String) As List(Of String)
        Dim strUser As String = IIf(actLogin.IsDomain, k_NotUser, actLogin.Login)
        If strUser = Nothing Then Return Nothing
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(k_Registry & "\" & Encripta(strUser) & "\" & strDomain, True)
        Dim oVal As New List(Of String)
        Try
            Dim strValues As String() = key.GetValueNames
            For Each str As String In strValues
                If str <> k_PwdDomain And str <> k_LoginHide And str <> k_AutoVerifyNewVersion Then oVal.Add(str)
            Next
        Catch ex As Exception
        Finally
            If Not key Is Nothing Then key.Close()
        End Try
        Return oVal
    End Function

    ''' <summary>Independientemente do logueo do usuario, garda a zona do host do dominio</summary>
    Friend Sub SetZoneDomain(ByVal strDomain As String, ByVal strHost As String, ByVal strType As String, ByVal strAddress As String)
        Dim strUser As String = IIf(actLogin.IsDomain, k_NotUser, actLogin.Login)
        UpdateOptionRegistry(strUser, strHost, New String() {strType, strAddress}, "\" & strDomain)
    End Sub

    ''' <summary>Independientemente del logueo del usuario, elimina las zonas del dominio</summary>
    Friend Sub DeleteZonesDomain(ByVal strDomain As String)
        Dim strUser As String = IIf(actLogin.IsDomain, k_NotUser, actLogin.Login)
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(k_Registry & "\" & Encripta(strUser) & "\" & strDomain, True)
        If key Is Nothing Then Exit Sub
        Dim strValues As String() = key.GetValueNames
        For Each str As String In strValues
            Select Case str
                Case k_PwdDomain, k_AutoVerifyNewVersion, k_LoginHide
                Case Else
                    key.DeleteValue(str)
            End Select
        Next
        key.Close()
    End Sub

    ''' <summary>Independientemente del logueo del usuario, elimina o dominio</summary>
    Friend Function DeleteDomain(ByVal id As domDNS.Data.InfoDomain) As Boolean
        Dim strUser As String = IIf(actLogin.IsDomain, k_NotUser, actLogin.Login)
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(k_Registry & "\" & Encripta(strUser) & "\" & id.Domain, True)
        If key Is Nothing Then Exit Function
        If actLogin.IsDomain AndAlso Desencripta(key.GetValue(k_PwdDomain)) <> actLogin.PassWord Then
            ShowError("No se borrará el dominio porque la clave no es correcta.", True)
            Exit Function
        End If
        key.Close()
        key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(k_Registry & "\" & Encripta(strUser), True)
        Try
            key.DeleteSubKey(id.Domain)
            MsgBoxCond("Se ha borrado el dominio correctamente", MsgBoxStyle.Information, True)
        Catch ex As Exception
            ShowError(ex.Message, True)
        End Try
        key.Close()
        Return True
    End Function

    Friend Function GetExportedConfiguration(ByVal newLogin As Login) As Xml.XmlDocument
        Dim strUser As String = IIf(newLogin.IsDomain, k_NotUser, newLogin.Login)
        Dim str As String = Nothing
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(k_Registry & "\" & Encripta(strUser), True)
        If key Is Nothing Then Return Nothing
        Dim xmlDoc As New Xml.XmlDocument
        Dim node As Xml.XmlNode = xmlDoc.CreateNode(Xml.XmlNodeType.Element, "dinaIP", "")
        xmlDoc.AppendChild(node)
        node.AppendChild(xmlDoc.CreateNode(Xml.XmlNodeType.Element, "user", ""))
        node.Item("user").AppendChild(xmlDoc.CreateCDataSection(Encripta(strUser)))
        If Not newLogin.IsDomain Then
            'metemos calquer dato que haxa no usuario, en pcpo só a contraseña
            For Each strValue As String In key.GetValueNames
                If strValue <> Nothing Then
                    node.AppendChild(xmlDoc.CreateNode(Xml.XmlNodeType.Element, strValue, ""))
                    node.Item(strValue).AppendChild(xmlDoc.CreateCDataSection(key.GetValue(strValue)))
                End If
            Next
        End If
        node = node.AppendChild(xmlDoc.CreateNode(Xml.XmlNodeType.Element, "domains", ""))
        'metemos os datos dos cominios do usuario
        For Each strDomain As String In key.GetSubKeyNames
            If Not newLogin.IsDomain OrElse (newLogin.IsDomain AndAlso newLogin.Login = strDomain) Then
                node.AppendChild(xmlDoc.CreateNode(Xml.XmlNodeType.Element, strDomain, ""))
                'metemos calquer dato que haxa no usuario, en pcpo só a contraseña
                Dim iZones As Integer = 0
                For Each strValue As String In key.OpenSubKey(strDomain, False).GetValueNames
                    Select Case strValue
                        Case k_PwdDomain, k_AutoVerifyNewVersion, k_LoginHide
                            node.Item(strDomain).AppendChild(xmlDoc.CreateNode(Xml.XmlNodeType.Element, strValue, ""))
                            node.Item(strDomain).ChildNodes(node.Item(strDomain).ChildNodes.Count - 1).AppendChild(xmlDoc.CreateCDataSection(key.OpenSubKey(strDomain, False).GetValue(strValue)))
                        Case Else
                            node.Item(strDomain).AppendChild(xmlDoc.CreateNode(Xml.XmlNodeType.Element, "zone" & iZones, ""))
                            node.Item(strDomain).Item("zone" & iZones).AppendChild(xmlDoc.CreateNode(Xml.XmlNodeType.Element, "host", ""))
                            node.Item(strDomain).Item("zone" & iZones).ChildNodes(node.Item(strDomain).Item("zone" & iZones).ChildNodes.Count - 1).AppendChild(xmlDoc.CreateCDataSection(strValue))
                            Dim ovalue As String() = New String() {"Unknown", ""}
                            Try
                                ovalue = key.OpenSubKey(strDomain, False).GetValue(strValue)
                            Catch ex As Exception : End Try
                            node.Item(strDomain).Item("zone" & iZones).AppendChild(xmlDoc.CreateNode(Xml.XmlNodeType.Element, "type", ""))
                            node.Item(strDomain).Item("zone" & iZones).ChildNodes(node.Item(strDomain).Item("zone" & iZones).ChildNodes.Count - 1).AppendChild(xmlDoc.CreateCDataSection(ovalue(0)))
                            node.Item(strDomain).Item("zone" & iZones).AppendChild(xmlDoc.CreateNode(Xml.XmlNodeType.Element, "address", ""))
                            node.Item(strDomain).Item("zone" & iZones).ChildNodes(node.Item(strDomain).Item("zone" & iZones).ChildNodes.Count - 1).AppendChild(xmlDoc.CreateCDataSection(ovalue(1)))
                            iZones += 1
                    End Select
                Next
            End If
        Next
        key.Close()
        Return xmlDoc
    End Function

    Friend Sub ImportConfiguration(ByVal strPathfile As String, ByVal newLogin As Login)
        Dim xmlDoc As New Xml.XmlDocument
        Try
            xmlDoc.Load(strPathfile)
        Catch ex As Exception
            ShowError(ex.Message, True)
            Exit Sub
        End Try

        Dim ImportLogin As Login = Nothing
        Dim strUser As String = Desencripta(xmlDoc("dinaIP").Item("user").ChildNodes(0).Value)
        If strUser <> k_NotUser Then
            ImportLogin = New Login(strUser, Desencripta(xmlDoc("dinaIP").Item("Password").ChildNodes(0).Value), False)
        Else
            ImportLogin = New Login(xmlDoc("dinaIP").Item("domains").ChildNodes(0).Name, Desencripta(xmlDoc("dinaIP").Item("domains").ChildNodes(0).Item(k_PwdDomain).ChildNodes(0).Value), True)
        End If
        If ImportLogin Is Nothing Then Exit Sub
        If ImportLogin.IsDomain <> newLogin.IsDomain Or ImportLogin.Login <> newLogin.Login Or ImportLogin.PassWord <> newLogin.PassWord Then
            MsgBoxCond("No se puede importar la configuración porque la autenticación" & vbCrLf & "NO se corresponde con la del fichero de importación.", MsgBoxStyle.Critical, True)
            Exit Sub
        End If
        If Not ImportLogin.IsDomain Then Utils.SavePassUser(ImportLogin.Login, ImportLogin.PassWord)
        For Each nodeParent As Xml.XmlNode In xmlDoc("dinaIP").ChildNodes
            Select Case nodeParent.Name
                Case "user", "Password"
                    'xa o meteu
                Case "domains"
                    For Each nodeDomain As Xml.XmlNode In nodeParent.ChildNodes
                        For Each node As Xml.XmlNode In nodeDomain.ChildNodes
                            Select Case node.Name
                                Case k_PwdDomain, k_LoginHide, k_AutoVerifyNewVersion
                                    UpdateOptionRegistry(IIf(ImportLogin.IsDomain, k_NotUser, ImportLogin.Login), node.Name, node.ChildNodes(0).Value, "\" & nodeDomain.Name)
                                Case Else
                                    UpdateOptionRegistry(IIf(ImportLogin.IsDomain, k_NotUser, ImportLogin.Login), node.Item("host").ChildNodes(0).Value, New String() {node.Item("type").ChildNodes(0).Value, node.Item("address").ChildNodes(0).Value}, "\" & nodeDomain.Name)
                            End Select
                        Next
                    Next
                Case Else
                    UpdateOptionRegistry(IIf(ImportLogin.IsDomain, k_NotUser, ImportLogin.Login), nodeParent.Value, nodeParent.ChildNodes(0).Value, "\" & IIf(ImportLogin.IsDomain, ImportLogin.Login, Nothing))
            End Select
        Next
        xmlDoc = Nothing
        MsgBoxCond("La importación se ha realizado correctamente.", MsgBoxStyle.Information, True)
    End Sub

    Friend Sub SaveOptionsLogin(ByVal strValue As String, ByVal oValue As Object)
        Dim strUser As String = IIf(actLogin.IsDomain, k_NotUser, actLogin.Login)
        UpdateOptionRegistry(strUser, strValue, oValue, IIf(actLogin.IsDomain, "\" & actLogin.Login, Nothing))
    End Sub

    Friend Function ReadOptionsLogin(ByVal strLogin As String, ByVal strValue As String, ByVal bIsDomain As Boolean) As Object
        Dim strUser As String = IIf(bIsDomain, k_NotUser, strLogin)
        Return Utils.ReadOptionRegistry(strUser, strValue, IIf(bIsDomain, "\" & strLogin, Nothing))
    End Function

    Friend Sub UpdateWhoAutoConnect(ByVal bAutoConnect As Boolean)
        Dim strAutoConnect As String = IIf(actLogin.IsDomain, k_NotUser & "\", Nothing) & actLogin.Login
        If bAutoConnect Then
            UpdateOptionsRegistry("WhoAutoConnect", Encripta(strAutoConnect))
        ElseIf WhoAutoConnect() = strAutoConnect Then
            UpdateOptionsRegistry("WhoAutoConnect", "")
        End If
        UpdateOptionsRegistry("LastLogin", Encripta(strAutoConnect))
    End Sub
#End Region

    Friend Function SaveDomainUser(ByVal strUser As String, ByVal strDominio As String) As Boolean
        If strUser = Nothing Then Throw New Exception("No se ha indicado el usuario.")
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(k_Registry & "\" & Encripta(strUser), Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
        If key Is Nothing Then Throw New Exception("No se ha podido acceder al registro del usuario.")
        key.CreateSubKey(strDominio)
        key.Close()
        Return True
    End Function

    Friend Function GetDomainsRegistry(ByVal strUser As String) As List(Of domDNS.Data.InfoDomain)
        Dim ls As New List(Of domDNS.Data.InfoDomain)
        If strUser = Nothing Then Return ls
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(k_Registry & "\" & Encripta(strUser), True)
        If Not key Is Nothing Then
            Dim domains() As String = key.GetSubKeyNames
            For Each str As String In domains
                ls.Add(New domDNS.Data.InfoDomain(str))
            Next
        End If
        Return ls
    End Function

    Friend Sub UpdateOptionRegistry(ByVal strUser As String, ByVal strProperty As String, ByVal oValue As Object, Optional ByVal strSubKeys As String = Nothing)
        If strUser = Nothing Then Exit Sub
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(k_Registry & "\" & Encripta(strUser) & strSubKeys, True)
        If key Is Nothing Then
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(k_Registry & "\" & Encripta(strUser) & strSubKeys, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
        End If
        key.SetValue(strProperty, oValue)
        key.Close()
    End Sub

    Private Function ReadOptionRegistry(ByVal strUser As String, ByVal strProperty As String, Optional ByVal strSubKeys As String = Nothing) As Object
        If strUser = Nothing Then Return Nothing
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(k_Registry & "\" & Encripta(strUser) & strSubKeys, True)
        Dim oVal As Object = Nothing
        Try
            oVal = key.GetValue(strProperty)
        Catch ex As Exception
        Finally
            If Not key Is Nothing Then key.Close()
        End Try
        Return oVal
    End Function

    Friend Function ReadOptionsRegistry(ByVal strValue As String) As Object
        Dim key As Microsoft.Win32.RegistryKey = Nothing
        Try
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(Utils.k_Registry)
        Catch ex As Exception : End Try
        If key Is Nothing Then Return Nothing
        Return key.GetValue(strValue)
        key.Close()
    End Function

    Friend Sub UpdateOptionsRegistry(ByVal strValue As String, ByVal oValue As String)
        Dim key As Microsoft.Win32.RegistryKey = Nothing
        Try
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(Utils.k_Registry)
        Catch ex As Exception : End Try
        If key Is Nothing Then Exit Sub
        Try
            key.SetValue(strValue, oValue)
        Catch ex As Exception : End Try
        key.Close()
    End Sub

    Friend Function ReadUsersRegistry() As List(Of String)
        Dim lUsers As New List(Of String)
        Dim key As Microsoft.Win32.RegistryKey = Nothing
        Try
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(k_Registry, False)
            For Each str As String In key.GetSubKeyNames
                If Desencripta(str) <> k_NotUser Then
                    Dim kUser As Microsoft.Win32.RegistryKey = key.OpenSubKey(str)
                    If Not kUser Is Nothing Then
                        If Not CBool(kUser.GetValue(k_LoginHide)) Then lUsers.Add(Desencripta(str))
                        kUser.Close()
                    End If
                End If
            Next
        Catch ex As Exception
        Finally
            If Not key Is Nothing Then key.Close()
        End Try
        Return lUsers
    End Function

    Friend Function ReadDomainsRegistry() As List(Of String)
        Dim lUsers As New List(Of String)
        Dim key As Microsoft.Win32.RegistryKey = Nothing
        Try
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(k_Registry & "\" & Encripta(k_NotUser), False)
            For Each str As String In key.GetSubKeyNames
                Dim kUser As Microsoft.Win32.RegistryKey = key.OpenSubKey(str)
                If Not kUser Is Nothing Then
                    If Not CBool(kUser.GetValue(k_LoginHide)) Then lUsers.Add(str)
                    kUser.Close()
                End If
            Next
        Catch ex As Exception
        Finally
            If Not key Is Nothing Then key.Close()
        End Try
        Return lUsers
    End Function

    Friend Function WhoWasLastLogin() As String
        Dim strReturn As String = Nothing
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(k_Registry, False)
        Try
            strReturn = Desencripta(key.GetValue("LastLogin"))
        Catch ex As Exception
        Finally
            If Not key Is Nothing Then key.Close()
            If strReturn = Nothing Then strReturn = ""
        End Try
        Return strReturn
    End Function

    Friend Function WhoAutoConnect() As String
        Dim strReturn As String = Nothing
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(k_Registry, False)
        Try
            strReturn = Desencripta(key.GetValue("WhoAutoConnect"))
        Catch ex As Exception
        Finally
            If Not key Is Nothing Then key.Close()
            If strReturn = Nothing Then strReturn = ""
        End Try
        Return strReturn
    End Function
#End Region

#Region "Codificación"
    Private strCryptKey As String = My.User.Name

    Public Function Encripta(ByVal strValue As String) As String
        Dim strCadenaResultante As String = ""
        Dim Llave() As Byte = Nothing

        If strValue <> Nothing AndAlso strCryptKey <> Nothing Then
            If GeneraLlave(strCryptKey, Llave) Then
                Dim oValue() As Byte = System.Text.Encoding.ASCII.GetBytes(strValue)
                For i As Integer = 1 To oValue.Length
                    strCadenaResultante &= Chr(Llave(i Mod (strCryptKey.Length - 1) + oValue(i - 1)))
                Next
            Else
                'La llave debe tener al menos dos caracteres.
            End If
        End If

        Return strCadenaResultante
    End Function

    Public Function Desencripta(ByVal strValue As String) As String
        Dim strCadenaResultante As String = ""
        Dim Llave() As Byte = Nothing

        If strValue <> Nothing Then
            If GeneraLlave(strCryptKey, Llave) Then
                For i As Integer = 1 To strValue.Length
                    Dim iPosicion As Integer = Asc(strValue.Chars(i - 1)) - Llave(i Mod (strCryptKey.Length - 1))
                    If iPosicion > 0 Then
                        strCadenaResultante &= Chr(iPosicion)
                    Else
                        strCadenaResultante &= Chr(iPosicion + 255)
                    End If
                Next
            Else
                'La llave debe tener al menos dos caracteres.
            End If
        End If
        Return strCadenaResultante
    End Function

    Private Function GeneraLlave(ByVal strKey As String, ByRef Llave() As Byte) As Boolean
        If Len(strCryptKey) > 1 Then
            Llave = System.Text.Encoding.ASCII.GetBytes(strCryptKey)
            ReDim Preserve Llave(strCryptKey.Length - 1 + 254)
            'Vamos incrementando cada columna hasta llenar el array en todas sus posiciones
            For i As Integer = 0 To strCryptKey.Length - 1
                For j As Integer = 1 To 254
                    Dim N As Integer = Llave(i + j - 1) + 1
                    If N = 256 Then N = 1
                    Llave(i + j) = N
                Next
            Next
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "Forms"
    Friend Sub SetCursorWait()
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
    End Sub

    Friend Sub SetCursorDefault()
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Friend Sub ClearContainer(ByVal ctrlPai As Control)
        For Each ctrl As Control In ctrlPai.Controls
            If Not ctrl.Name.EndsWith("_NC") Then
                Select Case ctrl.GetType.ToString
                    Case GetType(TextBox).ToString
                        ctrl.Text = Nothing
                        ctrl.Tag = Nothing
                    Case GetType(DateTimePicker).ToString
                        CType(ctrl, DateTimePicker).Value = Date.Now
                    Case GetType(ListView).ToString
                        CType(ctrl, ListView).Items.Clear()
                    Case GetType(GroupBox).ToString, GetType(Panel).ToString
                        ClearContainer(ctrl)
                    Case GetType(ComboBox).ToString
                        CType(ctrl, ComboBox).SelectedIndex = -1
                        CType(ctrl, ComboBox).Text = Nothing
                    Case GetType(RadioButton).ToString
                        CType(ctrl, RadioButton).Checked = False
                End Select
            End If
        Next
    End Sub
#End Region

    Public Function MsgBoxCond(ByVal strMessage As String, ByVal iTypeNotification As MsgBoxStyle, ByVal bAlwaysShow As Boolean) As MsgBoxResult
        If bAlwaysShow Or Not SilentMode Then
            Return MsgBox(strMessage, iTypeNotification)
        Else
            IO.File.AppendAllText(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\dinaIP-silent.log", vbCrLf & Now.ToString & strMessage)
            Return MsgBoxResult.Ok
        End If
    End Function

    Public Sub ShowError(ByVal str As String, ByVal bAlwaysShow As Boolean)
        MsgBoxCond(str, MsgBoxStyle.Critical, bAlwaysShow)
    End Sub

    Function AddressContainIP(ByVal strAddress As String, Optional ByVal strActualIp As String = Nothing) As Boolean
        If strAddress = Nothing Then Return False
        If strActualIp = Nothing Then strActualIp = aut.ActualIp
        Dim regex As New System.Text.RegularExpressions.Regex("\b" & strActualIp & "\b", System.Text.RegularExpressions.RegexOptions.Singleline)
        Return regex.Match(strAddress).Success
    End Function

    ''' <summary>
    ''' Descarga a nova versión da aplicación
    ''' </summary>
    Public Function DoGetNewVersionApplication(ByVal valid As domDNS.Data.InfoVersion) As Boolean
        Try
            Dim bDiferent As Boolean = False
            'corto a versión e comparo elemento a elemento
            Dim strSaved() As String = valid.Version.Split(".")
            Dim strActual() As String = My.Application.Info.Version.ToString.Split(".")
            For i As Integer = 0 To strActual.Length - 1
                'miro si podo comparar os elementos
                If i <= strSaved.Length - 1 Then
                    'Como comeza comparando de esquerda a dereita, no momento en que a actual é maior xa sae...
                    If strActual(i) > strSaved(i) Then
                        Return True
                    ElseIf strActual(i) < strSaved(i) Then
                        bDiferent = True
                        Exit For
                    End If
                ElseIf strActual(i) > 0 Then
                    'son versións diferentes, pero como a actual ten máis elementos, é máis recente que a gardada
                    Exit For
                End If
            Next
            If bDiferent And Not SilentMode Then
                If My.Application.Info.Version.ToString < "1.0.7" Then
                    IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\dinaIP-OnRequest.log")
                    IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\dinaIP-OnResponse.log")
                End If
                Select Case valid.Type
                    Case domDNS.Data.eTypeVersion.Required
                        MsgBoxCond("A continuación se va actualizar la aplicación a la versión " & valid.Version, MsgBoxStyle.Exclamation, True)
                    Case domDNS.Data.eTypeVersion.Must
                        If MsgBoxCond("Debería actualizar la aplicación a la versión " & valid.Version & "," & vbCrLf & "¿Desea hacerlo?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1, True) = MsgBoxResult.No Then Return True
                    Case domDNS.Data.eTypeVersion.OptionalUpdate
                        If MsgBoxCond("Se recomieda actualizar la aplicación a la versión " & valid.Version & "," & vbCrLf & "¿Desea hacerlo?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1, True) = MsgBoxResult.No Then Return True
                End Select
                Dim pr As New Process
                pr.StartInfo.FileName = valid.URL
                pr.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                pr.Start()
                'nos casos en que o cambio de versión sexa requerido, cancelamos a aplicación
                If valid.Type = domDNS.Data.eTypeVersion.Required Then
                    Return False
                Else
                    Return True
                End If
            End If
        Catch ex As Exception
            'pode que se lance unha excepción cando se cancela a descarga.
            'Console.WriteLine("Ó comprobar a versión: " & ex.Message)
        End Try
        Return True
    End Function
End Module
