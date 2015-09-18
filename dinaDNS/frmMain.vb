Public Class frmMain
    Dim lsDomains As New Dictionary(Of String, frmZones)

    Private Sub tsmiConectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiConectar.Click, tsbConectar.Click
        'Dim f As New frmLogin
        'f.ShowDialog()
        Dim f As New frmLoginExt
        f.Show(False)
        LoadDomains()
    End Sub

    Private Sub tsmiNewDomain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiNewDomain.Click, tsbNew.Click
        Dim ls As List(Of domDNS.Data.InfoDomain) = domDNS.XmlRpc.GetDomains(actLogin.Login, actLogin.PassWord, False, True)
        For Each it As ListViewItem In Me.ListView1.Items
            For Each id As domDNS.Data.InfoDomain In ls
                If id.Domain = it.Tag.Domain Then
                    ls.Remove(id)
                    Exit For
                End If
            Next
        Next
        Dim f As New frmAddDomain
        f.Tag = ls
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then LoadDomains()
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim f As New frmLogin
        'f.ShowDialog()
        If My.Application.CommandLineArgs IsNot Nothing AndAlso My.Application.CommandLineArgs.Count = 1 Then
            SilentMode = (My.Application.CommandLineArgs(0) = "/silent")
        End If
        If ReadOptionsRegistry("InitMinimize") Then
            Me.WindowState = FormWindowState.Minimized
        End If
        DoLogin()
        LoadDomains()
        aut = New Automatic(niDinaDNS)
    End Sub

    Private Sub DoLogin()
        SetCursorWait()
        tmSilent.Stop()
        'Cargamos ó usuario que ten auto conexión
        Dim strWhoWasLastLogin As String = WhoWasLastLogin()
        If strWhoWasLastLogin <> Nothing AndAlso strWhoWasLastLogin.StartsWith(Utils.k_NotUser & "\") Then
            strWhoWasLastLogin = strWhoWasLastLogin.Substring((Utils.k_NotUser & "\").Length)
        End If
        Dim strWhoAutoConnect As String = WhoAutoConnect()
        If strWhoAutoConnect.StartsWith(Utils.k_NotUser & "\") Then
            strWhoAutoConnect = strWhoAutoConnect.Substring((Utils.k_NotUser & "\").Length)
        End If
        Dim bShowForm As Boolean = True
        If strWhoAutoConnect = strWhoWasLastLogin Then
            Dim lUsers As List(Of String) = ReadUsersRegistry()
            Dim bUser As Boolean = lUsers.Contains(strWhoWasLastLogin)
            Dim strPass As String = Nothing
            If bUser Then
                strPass = Utils.GetPassUser(strWhoWasLastLogin)
            Else
                strPass = Utils.GetPassDomain(strWhoWasLastLogin)
            End If
            If strPass <> Nothing Then
                actLogin.Login = strWhoAutoConnect
                actLogin.PassWord = strPass
                actLogin.IsDomain = Not bUser
                'comprobo se loguea ben
                Dim objs As Object = domDNS.XmlRpc.DoLogin(actLogin.Login, actLogin.PassWord, actLogin.IsDomain, SilentMode)
                If objs Is Nothing OrElse objs.GetType Is GetType(Boolean) Then
                    MsgBoxCond("La validación no es correcta.", MsgBoxStyle.Critical, False)
                    If SilentMode Then
                        tmSilent.Start()
                        Exit Sub
                    End If
                Else
                    'comprobamos o caso de nova versión
                    If Utils.ReadOptionsLogin(strWhoAutoConnect, k_AutoVerifyNewVersion, Not bUser) AndAlso Not DoGetNewVersionApplication(objs.Version) Then End
                    bShowForm = False
                End If
            End If
        End If
        SetCursorDefault()
        If bShowForm Then
            Dim f As New frmLoginExt
            f.ShowDialog()
        End If
        If actLogin Is Nothing OrElse actLogin.Login = Nothing Then End
    End Sub

    Private Sub LoadDomains()
        Me.ListView1.Items.Clear()
        If actLogin.IsDomain Then
            Me.ListView1.Items.Add(actLogin.Login).Tag = New domDNS.Data.InfoDomain(actLogin.Login)
        Else
            For Each dm As domDNS.Data.InfoDomain In Utils.GetDomainsRegistry(actLogin.Login)
                Me.ListView1.Items.Add(dm.Domain).Tag = dm
            Next
        End If
        tsmiNewDomain.Enabled = Not actLogin.IsDomain
        tsbNew.Enabled = Not actLogin.IsDomain
        tsbDel.Enabled = Not actLogin.IsDomain
        tsmiDelDomain.Enabled = Not actLogin.IsDomain
    End Sub

    Private Sub ListView1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        ShowZones()
    End Sub

    Public Sub Pechou(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        lsDomains.Remove(sender.Tag.Domain)
    End Sub

    Private Sub FileMenu_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileMenu.DropDownOpening
        If Not Me.ListView1.SelectedItems Is Nothing AndAlso Me.ListView1.SelectedItems.Count > 0 Then
            tsmiEditDomain.Enabled = True
        Else
            tsmiEditDomain.Enabled = False
        End If
    End Sub

    Private Sub tsmiDelDomain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmiDelDomain.Click, tsbDel.Click
        If Not Me.ListView1.SelectedItems Is Nothing AndAlso Me.ListView1.SelectedItems.Count > 0 Then
            Dim id As domDNS.Data.InfoDomain = Me.ListView1.SelectedItems(0).Tag
            If MsgBoxCond("¿Está seguro que quiere eliminar el dominio '" & id.Domain & "'?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, True) = MsgBoxResult.Yes Then
                If Utils.DeleteDomain(id) Then
                    Try
                        lsDomains(id.Domain).buCancel_Click(Nothing, Nothing)
                    Catch ex As Exception
                        'non está na colección
                    End Try
                    LoadDomains()
                End If
            End If
        End If
    End Sub

    Private Sub tsmiEditDomain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmiEditDomain.Click
        ShowZones()
    End Sub

    Private Sub ShowZones()
        SetCursorWait()
        If Me.ListView1.SelectedItems Is Nothing OrElse Me.ListView1.SelectedItems.Count = 0 Then Exit Sub
        Dim it As ListViewItem = Me.ListView1.SelectedItems(0)
        Dim f As frmZones = Nothing
        Try
            f = lsDomains(it.Tag.Domain)
        Catch ex As Exception : End Try
        If f Is Nothing Then
            f = New frmZones
            f.Tag = it.Tag
            lsDomains.Add(it.Tag.Domain, f)
            f.Text = it.Tag.Domain & ": Panel de zonas DNS"
            AddHandler f.FormClosed, AddressOf Pechou
            f.Show()
        Else
            f.BringToFront()
        End If
        SetCursorDefault()
    End Sub

    Private Sub tsmiExportConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiExportConfig.Click
        Dim f As New frmPass
        f.ShowDialog()
        Dim NewLogin As Login = f.NewLogin
        f.Dispose()
        f = Nothing
        If NewLogin Is Nothing OrElse NewLogin.Login = Nothing Then Exit Sub
        'O QUE VAI EXPORTAR É A INFORMACIÓN DO USUARIO QUE ACABA DE INDICAR

        Dim sfd As New SaveFileDialog
        sfd.AddExtension = True
        sfd.DefaultExt = ".reg"
        sfd.Filter = "Archivo de configuración (*.xml)|*.xml"
        sfd.OverwritePrompt = True
        If sfd.ShowDialog = Windows.Forms.DialogResult.Cancel OrElse sfd.FileName = Nothing Then Exit Sub
        Try
            Dim xmlDoc As Xml.XmlDocument = GetExportedConfiguration(NewLogin)
            If xmlDoc Is Nothing Then
                MsgBoxCond("No hay configuración para exportar o la autenticación no ha sido correcta.", MsgBoxStyle.Exclamation, True)
                Exit Sub
            End If
            xmlDoc.Save(sfd.FileName)
            MsgBoxCond("Se ha exportado la configuración correctamente.", MsgBoxStyle.Information, True)
        Catch ex As Exception
            ShowError(ex.Message, True)
        End Try
    End Sub

    Private Sub tsmiImportConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiImportConfig.Click
        Dim f As New frmPass
        f.lblInfoText.Text = "Introduzca las credenciales del archivo de importación:"
        f.ShowDialog()
        Dim NewLogin As Login = f.NewLogin
        f.Dispose()
        f = Nothing
        If NewLogin Is Nothing OrElse NewLogin.Login = Nothing Then Exit Sub
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Archivo de configuración (*.xml)|*.xml"
        If ofd.ShowDialog = Windows.Forms.DialogResult.Cancel OrElse ofd.FileName = Nothing Then Exit Sub
        ImportConfiguration(ofd.FileName, NewLogin)
        LoadDomains()
    End Sub

    Private Sub tsmiShowDNS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiShowDNS.Click
        ShowMe()
    End Sub

    Private Sub ShowMe()
        Me.Visible = True
        Me.WindowState = iLastWindowState
        Me.TopMost = True
        Me.Activate()
        Me.BringToFront()
        Me.Select()
        Me.TopMost = False
    End Sub

    Private Sub tsmiResumeService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiResumeService.Click, tsmiReanudarServicio.Click
        aut.ResumeService()
    End Sub

    Private Sub tsmiStopService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiStopService.Click, tsmiDetenerServicio.Click
        aut.StopService()
    End Sub

    Private Sub tsmiResumeService_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiResumeService.EnabledChanged
        tsmiReanudarServicio.Enabled = sender.enabled
    End Sub

    Private Sub tsmiStopService_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiStopService.EnabledChanged
        tsmiDetenerServicio.Enabled = sender.enabled
    End Sub

    Dim iLastWindowState As FormWindowState = FormWindowState.Normal

    Private Sub frmMain_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ClientSizeChanged
        Me.ShowInTaskbar = (Me.WindowState <> FormWindowState.Minimized)
        Me.Visible = Me.ShowInTaskbar
        If Me.WindowState <> FormWindowState.Minimized Then
            iLastWindowState = Me.WindowState
        End If
    End Sub

    Private Sub niDinaDNS_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles niDinaDNS.DoubleClick
        ShowMe()
    End Sub

    Private Sub niDinaDNS_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles niDinaDNS.MouseDoubleClick
        ShowMe()
    End Sub

    Private Sub tsmiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiExit.Click, tsmiSalir.Click
        CloseNotifyIcon()
        End
    End Sub

    Private Sub tsmiOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiOptions.Click
        Dim f As New frmOptions
        f.ShowDialog()
    End Sub

    Private Sub tsmiAcercaDe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAcercaDe.Click
        Dim f As New AboutBox1
        f.ShowDialog()
    End Sub

    Protected Overrides Sub OnFormClosing(ByVal e As System.Windows.Forms.FormClosingEventArgs)
        CloseNotifyIcon()
        MyBase.OnFormClosing(e)
    End Sub

    Private Sub CloseNotifyIcon()
        niDinaDNS.Visible = False
    End Sub

    Private Sub tmSilent_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmSilent.Tick
        DoLogin()
    End Sub

    Private Sub tsmiCheckNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiCheckNow.Click
        aut.checkNow()
    End Sub
End Class