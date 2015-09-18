Public Class frmLogin

    Private Sub frmLogin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = (Me.DialogResult = Windows.Forms.DialogResult.Ignore)
    End Sub

    Private Sub buOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buOk.Click
        SetCursorWait()
        actLogin.Login = Me.txLogin.Text
        actLogin.PassWord = Me.txPass.Text
        actLogin.IsDomain = Not rbUser.Checked
        Dim objs As Object = Nothing
        If rbUser.Checked Then
            'objs = domDNS.XmlRpc.GetDomains(actLogin.Login, actLogin.PassWord)
        Else
            objs = domDNS.XmlRpc.GetZones(actLogin.Login, actLogin.PassWord, False)
        End If
#If DEBUG Then
        objs = "GO_ON"
#End If
        If objs Is Nothing OrElse objs.GetType Is GetType(Boolean) Then
            MsgBoxCond("La validación no es correcta.", MsgBoxStyle.Critical, True)
            Me.DialogResult = Windows.Forms.DialogResult.Ignore
        Else
            If rbUser.Checked Then
                Utils.SavePassUser(actLogin.Login, IIf(chkRemember.Checked, actLogin.PassWord, ""))
            Else
                Utils.SavePassDomain(actLogin.Login, IIf(chkRemember.Checked, actLogin.PassWord, ""))
            End If
        End If
        SetCursorDefault()
    End Sub

    Private Sub txLogin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txLogin.TextChanged
        If rbUser.Checked Then
            Me.txPass.Text = Utils.GetPassUser(Me.txLogin.Text)
        Else
            Me.txPass.Text = Utils.GetPassDomain(Me.txLogin.Text)
        End If
        Me.chkRemember.Checked = (Me.txPass.Text <> Nothing)
    End Sub

    Private Sub frmLogin_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Enter,Me.Load,rbUser.CheckedChanged, rbDomain.CheckedChanged
        Me.txLogin.Select()
    End Sub
End Class