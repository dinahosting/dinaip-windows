Public Class frmOptions

    Private Sub buCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buCancel.Click
        Me.Close()
    End Sub

    Private Sub buSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buSave.Click
        If Not chkMin.Checked AndAlso Not chkHour.Checked AndAlso Not chkDay.Checked Then
            MsgBoxCond("Tiene que indicar cada cuanto se ejecuta el servicio.", MsgBoxStyle.Exclamation, True)
            Me.DialogResult = Windows.Forms.DialogResult.Ignore
            Exit Sub
        End If
        UpdateOptionsRegistry("RunAtStartUp", chkRunWin.Checked)
        UpdateOptionsRegistry("InitMinimize", chkStartMin.Checked)
        UpdateOptionsRegistry("AutoDetect", chkAutoDetectIp.Checked)
        SaveOptionsLogin("NotifyEmail", txMail.Text)
        Dim iMiliSeconds As Integer = IIf(chkMin.Checked, nudMin.Value, 0) * 60
        UpdateOptionsRegistry("IntervalMin", IIf(chkMin.Checked, nudMin.Value, 0))
        iMiliSeconds += IIf(chkHour.Checked, nudHour.Value, 0) * 3600
        UpdateOptionsRegistry("IntervalHour", IIf(chkHour.Checked, nudHour.Value, 0))
        iMiliSeconds += IIf(chkDay.Checked, nudDay.Value, 0) * 86400
        UpdateOptionsRegistry("IntervalDay", IIf(chkDay.Checked, nudDay.Value, 0))
        iMiliSeconds *= 1000
        If aut.Interval <> iMiliSeconds Then aut.Interval = iMiliSeconds
        'establecemos ou quitamos a opción de arrancar con Windows
        Dim key As Microsoft.Win32.RegistryKey = Nothing
        Try
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            If Not key Is Nothing Then
                If chkRunWin.Checked Then
                    key.SetValue("dinaIP", My.Application.Info.DirectoryPath & "\dinaIP.exe")
                ElseIf key.GetValue("dinaIP") <> Nothing Then
                    key.DeleteValue("dinaIP")
                End If
            End If
        Catch se As Security.SecurityException
            'o usuario non ten acceso ó rexistro
        Catch ex As Exception
            'Console.WriteLine(ex.Message)
        Finally
            If Not key Is Nothing Then key.Close()
        End Try
    End Sub

    Private Sub nudMin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudMin.ValueChanged
        chkMin.Checked = True
    End Sub

    Private Sub nudHour_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudHour.ValueChanged
        chkHour.Checked = True
    End Sub

    Private Sub nudDay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDay.ValueChanged
        chkDay.Checked = True
    End Sub

    Private Sub frmOptions_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = (Me.DialogResult = Windows.Forms.DialogResult.Ignore)
    End Sub

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
#If DEBUG Then
        nudMin.Minimum = 1
#End If
        gbNotify.Visible = SilentMode
        If SilentMode Then
            Me.Height += 12 + gbNotify.Height
        End If
        txMail.Text = ReadOptionsLogin(actLogin.Login, "NotifyEmail", False)
        chkRunWin.Checked = ReadOptionsRegistry("RunAtStartUp")
        chkStartMin.Checked = ReadOptionsRegistry("InitMinimize")
        chkAutoDetectIp.Checked = ReadOptionsRegistry("AutoDetect")
        Dim oVal As Integer = ReadOptionsRegistry("IntervalMin")
        chkMin.Checked = (oVal <> Nothing)
        If oVal <> Nothing Then nudMin.Value = oVal
        oVal = ReadOptionsRegistry("IntervalHour")
        chkHour.Checked = (oVal <> Nothing)
        If oVal <> Nothing Then nudHour.Value = oVal
        oVal = ReadOptionsRegistry("IntervalDay")
        chkDay.Checked = (oVal <> Nothing)
        If oVal <> Nothing Then nudDay.Value = oVal
        'se está todo desmarcado é porque aínda non o gardou no rexistro, e por defecto é 10 minutos
        If Not (chkMin.Checked Or chkHour.Checked Or chkDay.Checked) Then
            chkMin.Checked = True
        End If
    End Sub

    Private Sub chkRunWin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRunWin.CheckedChanged

    End Sub
End Class