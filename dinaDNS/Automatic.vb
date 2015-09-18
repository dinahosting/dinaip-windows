Public Class Automatic

    Dim tm As New Timers.Timer(600000)
    Dim tmIco As New Timers.Timer(250)
    Dim strNewFileForIP As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\dinaIp.text"
    Public Const k_URLNotifyChanges As String = "http://neumaticos-hernandez.com/dinaIp/WriteChanges.php?domain='strDomain'&OldIp='strOldIp'&NewIp='strNewIp'"
    Public Const k_URLGetIp1 As String = "http://dinadns01.dinaserver.com/"
    Public Const k_URLGetIp2 As String = "http://dinadns02.dinaserver.com/"
    'Por defecto son cada 10 minutos
    Dim strLastIp As String = "Unknown"
    Dim bLog As Boolean = True
    Dim strFileLog As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\dinaIP.log"
    Dim niDNS As NotifyIcon

    Public Sub StopService()
        If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & " - Servicio parado correctamente.")
        tmIco.Stop()
        tm.Stop()
        niDNS.ContextMenuStrip.Items(1).Enabled = False
        niDNS.ContextMenuStrip.Items(0).Enabled = True
    End Sub

    Public Sub ResumeService()
        If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & " - Servicio reanudado correctamente.")
        tm.Start()
        niDNS.ContextMenuStrip.Items(1).Enabled = True
        niDNS.ContextMenuStrip.Items(0).Enabled = False
    End Sub

    ''' <summary>Devuelve o establece el intervalo de ejecución del servicio</summary>
    ''' <remarks>Al modificar el intervalo, reinicia el servicio</remarks>
    Public Property Interval() As Integer
        Get
            Return tm.Interval
        End Get
        Set(ByVal value As Integer)
            StopService()
            tm.Interval = value
            ResumeService()
        End Set
    End Property

    Public ReadOnly Property ActualIp() As String
        Get
            Return strLastIp
        End Get
    End Property

    Public Sub New(ByVal ni As NotifyIcon)
        niDNS = ni
        If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & " - Servicio iniciado correctamente.")
        ReadRegistry()
        If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & " - IP: " & strLastIp)
        AddHandler tm.Elapsed, AddressOf Tick
        AddHandler tmIco.Elapsed, AddressOf ChangeIco
        tm.AutoReset = True
        ResumeService()
        Tick(tm, Nothing)
    End Sub

    Private Sub ChangeIco(ByVal sender As Object, ByVal e As Timers.ElapsedEventArgs)
        niDNS.Icon = My.Resources.ResourceManager.GetObject("ico0" & niDNS.Tag)
        niDNS.Tag += 1
        If niDNS.Tag > 3 Then niDNS.Tag = 1
        If tm.Enabled Then tmIco.Stop()
    End Sub

    Private Sub Tick(ByVal sender As Object, ByVal e As Timers.ElapsedEventArgs)
        checkNow()
    End Sub

    Public Sub checkNow()
        niDNS.Text = My.Application.Info.AssemblyName & vbCrLf & "Comprobando..."
        tmIco.Start()
        tm.Stop()
        If bLog Then
            While IO.File.Exists(strNewFileForIP)
                Try
                    IO.File.Delete(strNewFileForIP)
                Catch ex As Exception : End Try
            End While
        End If
        Try
            My.Computer.Network.DownloadFile(k_URLGetIp1, strNewFileForIP)
        Catch ex As Exception
            If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & " - Primera obtención fallida: " & ex.Message)
            Try
                My.Computer.Network.DownloadFile(k_URLGetIp2, strNewFileForIP)
            Catch exc As Exception
                If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & " - Segunda obtención fallida: " & exc.Message)
                tm.Start()
                niDNS.ShowBalloonTip(2000, "dinaIP", "Última comprobación fallida", ToolTipIcon.Error)
                niDNS.Text = My.Application.Info.AssemblyName & vbCrLf & "IP: " & strLastIp
                Exit Sub
            End Try
        End Try
        Dim str As String = IO.File.ReadAllText(My.Computer.FileSystem.SpecialDirectories.Temp & "\dinaIp.text")
        If str <> strLastIp Then
            If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & " Cambio de IP: " & strLastIp & " ==> " & str)
            NotifyChanges(str)
            UpdateOptionsRegistry("IP", str)
            ReadRegistry()
        Else
            CheckForPendingChanges(str)
        End If
        tm.Start()
        niDNS.Text = My.Application.Info.AssemblyName & vbCrLf & "IP: " & strLastIp
    End Sub

    Private Sub ReadRegistry()
        strLastIp = Utils.ReadOptionsRegistry("IP")
        If strLastIp = Nothing Then strLastIp = "Unknown"
    End Sub

    Private Function SafeCDec(ByVal o As Object) As Integer
        Try
            Return CDec(o)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub NotifyChanges(ByVal strNewIp As String)
        If actLogin.Login = Nothing Or actLogin.PassWord = Nothing Then
            If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & ": NC - No se puede notificar el cambio de IP porque no hay ningún usuario logueado en el sistema")
            Exit Sub
        End If
        Dim ls As New List(Of domDNS.Data.InfoDomain)
        If actLogin.IsDomain Then
            ls.Add(New domDNS.Data.InfoDomain(actLogin.Login))
        Else
            ls = GetDomainsRegistry(actLogin.Login)
        End If
        For Each id As domDNS.Data.InfoDomain In ls
            Dim zn As New domDNS.Zones(SilentMode)
            Dim bModify As Boolean = False
            Try
                zn.GetIt(IIf(actLogin.IsDomain, Nothing, actLogin.Login), actLogin.PassWord, id.Domain)
                If zn.ZonesCount = -1 Then
                    Throw New Exception("No se actualizarán las zonas porque no se han obtenido correctamente (Estableciendo zonas)")
                End If
                Try
                    For Each iz As domDNS.Data.InfoZone In zn.List
                        Dim strZone As String = GetAddressZoneDomain(id.Domain, iz.Host)
                        If strZone <> Nothing Then
                            If AddressContainIP(strZone, Me.ActualIp) Then
                                If bLog Then IO.File.AppendAllText(strFileLog, String.Format("{0}{1}: NC - Dominio: {2}: Zona '{3}'= {4}->{5}({6})", vbCrLf, Now.ToString, id.Domain, iz.Host, iz.Address, strNewIp, strLastIp))
                                iz.Address = iz.Address.Replace(strLastIp, strNewIp)
                            Else
                                If bLog Then IO.File.AppendAllText(strFileLog, String.Format("{0}{1}: NC - Dominio: {2}: Zona '{3}'= {4}->{5}", vbCrLf, Now.ToString, id.Domain, iz.Host, iz.Address, strNewIp))
                                iz.Address = strNewIp
                            End If
                            bModify = True
                        End If
                    Next
                Catch ex As Exception
                    Throw New Exception(ex.Message & " (Comprobando las zonas)")
                End Try
                If bModify Then
                    Try
                        zn.SetIt(IIf(actLogin.IsDomain, Nothing, actLogin.Login), actLogin.PassWord, id.Domain, False)
                    Catch ex As Exception
                        Throw New Exception(ex.Message & " (Estableciendo zonas)")
                    End Try
                    Try
                        For Each strZone As String In GetHostZonesDomain(id.Domain)
                            Utils.SetZoneDomain(id.Domain, strZone, zn.GetItemByHost(strZone).TypeToString, zn.GetItemByHost(strZone).Address)
                        Next
                    Catch ex As Exception
                        If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & ": NC - " & ex.Message & " (Actualizando las zonas del registro)")
                    End Try
                    If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & ": NC - Se han actualizado las zonas del registro")
                Else
                    If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & ": NC - " & id.Domain & " --> No tiene zonas para actualizar")
                End If
            Catch ex As Exception
                If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & ": NC - " & id.Domain & " --> Actualizando zonas se produjo el siguiente error: " & ex.Message)
            End Try
            zn = Nothing
        Next
        If ls.Count = 0 Then
            If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & ": NC - No hay zonas para actualizar")
        End If
    End Sub

    Private Sub CheckForPendingChanges(ByVal strNewIp As String)
        If actLogin.Login = Nothing Or actLogin.PassWord = Nothing Then
            If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & ": CFP - No se puede notificar el cambio de IP porque sigue sin haber ningún usuario logueado en el sistema")
            Exit Sub
        End If
        Dim ls As New List(Of domDNS.Data.InfoDomain)
        If actLogin.IsDomain Then
            ls.Add(New domDNS.Data.InfoDomain(actLogin.Login))
        Else
            ls = GetDomainsRegistry(actLogin.Login)
        End If
        For Each id As domDNS.Data.InfoDomain In ls
            Dim bModify As Boolean = False
            Try
                Dim regZones As Dictionary(Of String, domDNS.Data.InfoZone) = GetZonesDomain(id.Domain)
                If regZones.Count > 0 Then
                    For Each kv As KeyValuePair(Of String, domDNS.Data.InfoZone) In regZones
                        If kv.Value.Address <> strNewIp Then
                            bModify = True
                            Exit For
                        End If
                    Next
                    If bModify Then
                        Dim zn As New domDNS.Zones(SilentMode)
                        zn.GetIt(IIf(actLogin.IsDomain, Nothing, actLogin.Login), actLogin.PassWord, id.Domain)
                        If zn.ZonesCount = -1 Then
                            Throw New Exception("No se actualizarán las zonas porque no se han obtenido correctamente (Estableciendo zonas)")
                        End If
                        Try
                            For Each iz As domDNS.Data.InfoZone In zn.List
                                If GetAddressZoneDomain(id.Domain, iz.Host) <> Nothing Then
                                    If bLog Then IO.File.AppendAllText(strFileLog, String.Format("{0}{1}: CFP - Dominio: {2}: Zona '{3}'= {4}->{5}", vbCrLf, Now.ToString, id.Domain, iz.Host, iz.Address, strNewIp))
                                    iz.Address = strNewIp
                                End If
                            Next
                        Catch ex As Exception
                            Throw New Exception(ex.Message & " (Modificando zonas)")
                        End Try
                        Try
                            zn.SetIt(IIf(actLogin.IsDomain, Nothing, actLogin.Login), actLogin.PassWord, id.Domain, False)
                        Catch ex As Exception
                            Throw New Exception(ex.Message & " (Estableciendo zonas)")
                        End Try
                        Try
                            For Each strZone As String In GetHostZonesDomain(id.Domain)
                                Utils.SetZoneDomain(id.Domain, strZone, zn.GetItemByHost(strZone).TypeToString, zn.GetItemByHost(strZone).Address)
                            Next
                        Catch ex As Exception
                            If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & ": CFP - " & ex.Message & " (Actualizando las zonas del registro)")
                        End Try
                        If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & ": CFP - Se han actualizado las zonas del registro")
                        zn = Nothing
                    End If
                End If
            Catch ex As Exception
                If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & ": CFP - " & id.Domain & " --> Actualizando zonas se produjo el siguiente error: " & ex.Message)
            End Try
        Next
        If ls.Count = 0 Then
            If bLog Then IO.File.AppendAllText(strFileLog, vbCrLf & Now.ToString & ": CFP - No hay zonas para actualizar")
        End If
    End Sub
End Class
