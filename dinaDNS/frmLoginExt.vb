Public Class frmLoginExt

    Dim bAllowAutoConnect As Boolean
    Dim bGoToShop As Boolean = True
    Dim lUsers As List(Of String)

    Private Sub frmLogin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = (Me.DialogResult = Windows.Forms.DialogResult.Ignore)
    End Sub

    Private Sub buOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buOk.Click
        If Me.txPass.Text = Nothing Then
            Exit Sub
        End If
        SetCursorWait()
        actLogin.Login = Me.cbLogin.Text
        actLogin.PassWord = Me.txPass.Text
        actLogin.IsDomain = Not rbUser.Checked
        Dim objs As Object = domDNS.XmlRpc.DoLogin(actLogin.Login, actLogin.PassWord, Not rbUser.Checked, False)
        If objs Is Nothing OrElse objs.GetType Is GetType(Boolean) Then
            MsgBoxCond("La validación no es correcta.", MsgBoxStyle.Critical, True)
            Me.DialogResult = Windows.Forms.DialogResult.Ignore
        Else
            If rbUser.Checked Then
                Utils.SavePassUser(actLogin.Login, IIf(chkRemember.Checked, actLogin.PassWord, ""))
                Utils.SaveOptionsLogin(k_LoginHide, Not chkSaveData.Checked)
                Utils.SaveOptionsLogin(k_AutoVerifyNewVersion, chkVerifyNewVerion.Checked)
            Else
                Utils.SavePassDomain(actLogin.Login, IIf(chkRemember.Checked, actLogin.PassWord, ""))
                Utils.SaveOptionsLogin(k_LoginHide, Not chkSaveData.Checked)
                Utils.SaveOptionsLogin(k_AutoVerifyNewVersion, chkVerifyNewVerion.Checked)
            End If
            UpdateWhoAutoConnect(chkAutoConnect.Checked)
            'comprobamos o caso de nova versión
            If chkVerifyNewVerion.Checked AndAlso Not DoGetNewVersionApplication(objs.Version) Then End
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        SetCursorDefault()
    End Sub

    Private Sub cbLogin_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbLogin.SelectedIndexChanged
        If cbLogin.SelectedIndex = cbLogin.Items.Count - 1 AndAlso bGoToShop Then
            Try
                Dim pr As New Process
                pr.StartInfo.FileName = My.Resources.UrlRegistro
                pr.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                pr.Start()
                bGoToShop = False
            Catch ex As Exception : End Try
        Else
            bGoToShop = True
            cbLogin_TextChanged(sender, Nothing)
        End If
    End Sub

    Private Sub cbLogin_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbLogin.TextChanged
        Dim ostrLang As String = Nothing
        If rbUser.Checked Then
            Me.txPass.Text = Utils.GetPassUser(Me.cbLogin.Text)
        Else
            Me.txPass.Text = Utils.GetPassDomain(Me.cbLogin.Text)
        End If
        Dim strWhoAutoConnect As String = WhoAutoConnect()
        If strWhoAutoConnect.StartsWith(Utils.k_NotUser & "\") Then
            strWhoAutoConnect = strWhoAutoConnect.Substring((Utils.k_NotUser & "\").Length)
            If strWhoAutoConnect = cbLogin.Text Then rbDomain.Checked = True
        ElseIf strWhoAutoConnect = cbLogin.Text Then
            rbUser.Checked = True
        End If
        Me.chkAutoConnect.Checked = (strWhoAutoConnect = cbLogin.Text)
        If lUsers.Contains(cbLogin.Text) Then chkRemember.Checked = (Me.txPass.Text <> Nothing)
        chkSaveData.Checked = (Me.cbLogin.Text <> Nothing AndAlso Me.cbLogin.Items.Contains(Me.cbLogin.Text))
        chkVerifyNewVerion.Checked = Utils.ReadOptionsLogin(Me.cbLogin.Text, k_AutoVerifyNewVersion, Not rbUser.Checked)

    End Sub

    Private Sub frmLogin_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Enter, rbUser.CheckedChanged, rbDomain.CheckedChanged
        'engadimos todos os posibles usuarios
        If rbUser.Checked Then
            lUsers = ReadUsersRegistry()
        Else
            lUsers = ReadDomainsRegistry()
        End If
        lUsers.Sort()
        Me.cbLogin.Items.Clear()
        For Each str As String In lUsers
            Me.cbLogin.Items.Add(str)
        Next
        Me.cbLogin.Items.Add("Crear usuario...")
        Me.cbLogin.Select()
    End Sub

    Public Shadows Sub Show(ByVal bAlloAutoConnectValue As Boolean)
        bAllowAutoConnect = bAlloAutoConnectValue
        Me.Visible = True
        Me.BringToFront()
        Me.TopMost = True
        Me.Visible = False
        Me.TopMost = False
        Me.ShowDialog()
    End Sub

    Private Sub frmLoginExt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Cargamos ó usuario que ten auto conexión
        Dim bUser As Boolean = True
        Dim strWhoWasLastLogin As String = WhoWasLastLogin()
        If strWhoWasLastLogin <> Nothing AndAlso strWhoWasLastLogin.StartsWith(Utils.k_NotUser & "\") Then
            strWhoWasLastLogin = strWhoWasLastLogin.Substring((Utils.k_NotUser & "\").Length)
            bUser = False
        End If
        rbUser.Checked = bUser
        If lUsers.Contains(strWhoWasLastLogin) Then
            Me.cbLogin.Text = strWhoWasLastLogin
            rbDomain.Checked = Not bUser
        End If
        bUser = True
        Dim strWhoAutoConnect As String = WhoAutoConnect()
        If strWhoAutoConnect <> Nothing AndAlso strWhoAutoConnect.StartsWith(Utils.k_NotUser & "\") Then
            strWhoAutoConnect = strWhoAutoConnect.Substring((Utils.k_NotUser & "\").Length)
            bUser = False
        End If
        If strWhoWasLastLogin <> strWhoAutoConnect OrElse strWhoAutoConnect = Nothing Then Exit Sub
        Me.chkAutoConnect.Checked = (strWhoAutoConnect = cbLogin.Text)
        If Me.cbLogin.Text = Nothing Then
            rbUser.Checked = bUser
            If lUsers.Contains(strWhoAutoConnect) Then
                Me.cbLogin.Text = strWhoAutoConnect
                rbDomain.Checked = Not bUser
            End If
        End If
        If Not rbUser.Checked And Not rbDomain.Checked Then rbUser.Checked = True
        If Me.chkAutoConnect.Checked And bAllowAutoConnect Then buOk_Click(buOk, New System.EventArgs)
    End Sub

    Private Sub chkRemember_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRemember.CheckedChanged, chkSaveData.CheckedChanged
        If Not chkRemember.Checked Or Not chkSaveData.Checked Then
            chkAutoConnect.Enabled = False
        Else
            chkAutoConnect.Enabled = True
        End If
    End Sub

    Private Sub chkAutoConnect_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAutoConnect.EnabledChanged
        If Not sender.enabled Then sender.checked = False
    End Sub

    Private Sub txPass_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txPass.TextChanged
        buOk.Enabled = (txPass.Text <> Nothing)
    End Sub
End Class