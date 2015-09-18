Public Class frmPass

    Friend NewLogin As New Login()

    Private Sub frmLogin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = (Me.DialogResult = Windows.Forms.DialogResult.Ignore)
    End Sub

    Private Sub buOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buOk.Click
        SetCursorWait()
        NewLogin.Login = Me.txLogin.Text
        NewLogin.PassWord = Me.txPass.Text
        NewLogin.IsDomain = Not rbUser.Checked
        SetCursorDefault()
    End Sub

    Private Sub frmLogin_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Enter,Me.Load,rbUser.CheckedChanged, rbDomain.CheckedChanged
        Me.txLogin.Select()
    End Sub
End Class