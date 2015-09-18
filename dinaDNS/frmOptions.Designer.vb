<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.chkRunWin = New System.Windows.Forms.CheckBox
        Me.chkStartMin = New System.Windows.Forms.CheckBox
        Me.buSave = New System.Windows.Forms.Button
        Me.buCancel = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.chkDay = New System.Windows.Forms.CheckBox
        Me.chkHour = New System.Windows.Forms.CheckBox
        Me.chkMin = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.nudDay = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.nudMin = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.nudHour = New System.Windows.Forms.NumericUpDown
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.chkAutoDetectIp = New System.Windows.Forms.CheckBox
        Me.gbNotify = New System.Windows.Forms.Panel
        Me.txMail = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.nudDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudHour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.gbNotify.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkRunWin
        '
        Me.chkRunWin.AutoSize = True
        Me.chkRunWin.Location = New System.Drawing.Point(12, 12)
        Me.chkRunWin.Name = "chkRunWin"
        Me.chkRunWin.Size = New System.Drawing.Size(153, 17)
        Me.chkRunWin.TabIndex = 0
        Me.chkRunWin.Text = "Ejecutar al iniciar Windows"
        Me.chkRunWin.UseVisualStyleBackColor = True
        '
        'chkStartMin
        '
        Me.chkStartMin.AutoSize = True
        Me.chkStartMin.Location = New System.Drawing.Point(12, 35)
        Me.chkStartMin.Name = "chkStartMin"
        Me.chkStartMin.Size = New System.Drawing.Size(108, 17)
        Me.chkStartMin.TabIndex = 1
        Me.chkStartMin.Text = "Iniciar minimizada"
        Me.chkStartMin.UseVisualStyleBackColor = True
        '
        'buSave
        '
        Me.buSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.buSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buSave.Location = New System.Drawing.Point(202, 141)
        Me.buSave.Name = "buSave"
        Me.buSave.Size = New System.Drawing.Size(120, 23)
        Me.buSave.TabIndex = 3
        Me.buSave.Text = "&Guardar cambios"
        Me.buSave.UseVisualStyleBackColor = True
        '
        'buCancel
        '
        Me.buCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buCancel.Location = New System.Drawing.Point(37, 141)
        Me.buCancel.Name = "buCancel"
        Me.buCancel.Size = New System.Drawing.Size(120, 23)
        Me.buCancel.TabIndex = 4
        Me.buCancel.Text = "&Descartar cambios"
        Me.buCancel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.chkStartMin)
        Me.Panel1.Controls.Add(Me.chkRunWin)
        Me.Panel1.Location = New System.Drawing.Point(177, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(175, 63)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.chkDay)
        Me.Panel2.Controls.Add(Me.chkHour)
        Me.Panel2.Controls.Add(Me.chkMin)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.nudDay)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.nudMin)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.nudHour)
        Me.Panel2.Location = New System.Drawing.Point(12, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(159, 117)
        Me.Panel2.TabIndex = 0
        '
        'chkDay
        '
        Me.chkDay.AutoSize = True
        Me.chkDay.Location = New System.Drawing.Point(15, 89)
        Me.chkDay.Name = "chkDay"
        Me.chkDay.Size = New System.Drawing.Size(15, 14)
        Me.chkDay.TabIndex = 4
        Me.chkDay.UseVisualStyleBackColor = True
        '
        'chkHour
        '
        Me.chkHour.AutoSize = True
        Me.chkHour.Location = New System.Drawing.Point(15, 63)
        Me.chkHour.Name = "chkHour"
        Me.chkHour.Size = New System.Drawing.Size(15, 14)
        Me.chkHour.TabIndex = 2
        Me.chkHour.UseVisualStyleBackColor = True
        '
        'chkMin
        '
        Me.chkMin.AutoSize = True
        Me.chkMin.Checked = True
        Me.chkMin.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMin.Location = New System.Drawing.Point(15, 37)
        Me.chkMin.Name = "chkMin"
        Me.chkMin.Size = New System.Drawing.Size(15, 14)
        Me.chkMin.TabIndex = 0
        Me.chkMin.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(89, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "días"
        '
        'nudDay
        '
        Me.nudDay.Location = New System.Drawing.Point(36, 86)
        Me.nudDay.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudDay.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudDay.Name = "nudDay"
        Me.nudDay.Size = New System.Drawing.Size(47, 20)
        Me.nudDay.TabIndex = 5
        Me.nudDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudDay.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(89, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "minutos"
        '
        'nudMin
        '
        Me.nudMin.Location = New System.Drawing.Point(36, 34)
        Me.nudMin.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.nudMin.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudMin.Name = "nudMin"
        Me.nudMin.Size = New System.Drawing.Size(47, 20)
        Me.nudMin.TabIndex = 1
        Me.nudMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudMin.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(89, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "horas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Ejecutar el servicio cada..."
        '
        'nudHour
        '
        Me.nudHour.Location = New System.Drawing.Point(36, 60)
        Me.nudHour.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.nudHour.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudHour.Name = "nudHour"
        Me.nudHour.Size = New System.Drawing.Size(47, 20)
        Me.nudHour.TabIndex = 3
        Me.nudHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudHour.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.chkAutoDetectIp)
        Me.Panel3.Location = New System.Drawing.Point(177, 87)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(175, 42)
        Me.Panel3.TabIndex = 2
        '
        'chkAutoDetectIp
        '
        Me.chkAutoDetectIp.AutoSize = True
        Me.chkAutoDetectIp.Location = New System.Drawing.Point(12, 12)
        Me.chkAutoDetectIp.Name = "chkAutoDetectIp"
        Me.chkAutoDetectIp.Size = New System.Drawing.Size(155, 17)
        Me.chkAutoDetectIp.TabIndex = 0
        Me.chkAutoDetectIp.Text = "Autodetectar ip's dinámicas"
        Me.chkAutoDetectIp.UseVisualStyleBackColor = True
        '
        'gbNotify
        '
        Me.gbNotify.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbNotify.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gbNotify.Controls.Add(Me.Label5)
        Me.gbNotify.Controls.Add(Me.txMail)
        Me.gbNotify.Location = New System.Drawing.Point(12, 87)
        Me.gbNotify.Name = "gbNotify"
        Me.gbNotify.Size = New System.Drawing.Size(340, 42)
        Me.gbNotify.TabIndex = 3
        '
        'txMail
        '
        Me.txMail.Location = New System.Drawing.Point(120, 10)
        Me.txMail.Name = "txMail"
        Me.txMail.Size = New System.Drawing.Size(210, 20)
        Me.txMail.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Notificar cambios a"
        '
        'frmOptions
        '
        Me.AcceptButton = Me.buSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.buCancel
        Me.ClientSize = New System.Drawing.Size(364, 176)
        Me.Controls.Add(Me.gbNotify)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.buCancel)
        Me.Controls.Add(Me.buSave)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Opciones"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.nudDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudHour, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.gbNotify.ResumeLayout(False)
        Me.gbNotify.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkRunWin As System.Windows.Forms.CheckBox
    Friend WithEvents chkStartMin As System.Windows.Forms.CheckBox
    Friend WithEvents buSave As System.Windows.Forms.Button
    Friend WithEvents buCancel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents chkDay As System.Windows.Forms.CheckBox
    Friend WithEvents chkHour As System.Windows.Forms.CheckBox
    Friend WithEvents chkMin As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nudDay As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudHour As System.Windows.Forms.NumericUpDown
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents chkAutoDetectIp As System.Windows.Forms.CheckBox
    Friend WithEvents gbNotify As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txMail As System.Windows.Forms.TextBox
End Class
