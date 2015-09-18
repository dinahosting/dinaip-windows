Public Class frmAddDomain

    Private Sub Method_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFill.CheckedChanged, rbSelect.CheckedChanged
        cbDomain.Enabled = rbSelect.Checked
        txDomain.Enabled = rbFill.Checked
    End Sub

    Private Sub frmLogin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = (Me.DialogResult = Windows.Forms.DialogResult.Ignore)
    End Sub

    Private Sub buCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buCancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub buOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buOk.Click
        Dim id As domDNS.Data.InfoDomain = Nothing
        If rbSelect.Checked Then
            id = cbDomain.SelectedItem
        Else
            For Each lid As domDNS.Data.InfoDomain In Me.Tag
                If lid.Domain = Me.txDomain.Text Then
                    id = lid
                    Exit For
                End If
            Next
        End If
        If id Is Nothing Then
            MsgBoxCond("El dominio seleccionado no es correcto", MsgBoxStyle.Critical, True)
            Me.DialogResult = Windows.Forms.DialogResult.Ignore
        Else
            Try
                Utils.SaveDomainUser(actLogin.Login, id.Domain)
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Catch ex As Exception
                MsgBoxCond("No se ha podido añadir el dominio porque se produjo el siguiente error:" & vbCrLf & ex.Message, MsgBoxStyle.Critical, True)
                Me.DialogResult = Windows.Forms.DialogResult.Ignore
            End Try
        End If
    End Sub

    Private Sub frmAddDomain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.cbDomain.Items.Clear()
        For Each id As domDNS.Data.InfoDomain In Me.Tag
            Me.cbDomain.Items.Add(id)
        Next
    End Sub
End Class