<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPass
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPass))
        Me.txLogin = New System.Windows.Forms.TextBox
        Me.rbUser = New System.Windows.Forms.RadioButton
        Me.buOk = New System.Windows.Forms.Button
        Me.buCancel = New System.Windows.Forms.Button
        Me.lblLogin = New System.Windows.Forms.Label
        Me.lblPass = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txPass = New System.Windows.Forms.TextBox
        Me.rbDomain = New System.Windows.Forms.RadioButton
        Me.lblInfoText = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txLogin
        '
        Me.txLogin.Location = New System.Drawing.Point(86, 24)
        Me.txLogin.Name = "txLogin"
        Me.txLogin.Size = New System.Drawing.Size(159, 20)
        Me.txLogin.TabIndex = 0
        '
        'rbUser
        '
        Me.rbUser.AutoSize = True
        Me.rbUser.Checked = True
        Me.rbUser.Location = New System.Drawing.Point(40, 34)
        Me.rbUser.Name = "rbUser"
        Me.rbUser.Size = New System.Drawing.Size(118, 17)
        Me.rbUser.TabIndex = 0
        Me.rbUser.TabStop = True
        Me.rbUser.Text = "Usuario dinahosting"
        Me.rbUser.UseVisualStyleBackColor = True
        '
        'buOk
        '
        Me.buOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buOk.Location = New System.Drawing.Point(296, 59)
        Me.buOk.Name = "buOk"
        Me.buOk.Size = New System.Drawing.Size(75, 23)
        Me.buOk.TabIndex = 4
        Me.buOk.Text = "&Aceptar"
        Me.buOk.UseVisualStyleBackColor = True
        '
        'buCancel
        '
        Me.buCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buCancel.Location = New System.Drawing.Point(296, 90)
        Me.buCancel.Name = "buCancel"
        Me.buCancel.Size = New System.Drawing.Size(75, 23)
        Me.buCancel.TabIndex = 5
        Me.buCancel.Text = "&Cancelar"
        Me.buCancel.UseVisualStyleBackColor = True
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.Location = New System.Drawing.Point(12, 27)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(68, 13)
        Me.lblLogin.TabIndex = 8
        Me.lblLogin.Text = "Identificador:"
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Location = New System.Drawing.Point(12, 53)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(64, 13)
        Me.lblPass.TabIndex = 9
        Me.lblPass.Text = "Contraseña:"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txPass)
        Me.Panel1.Controls.Add(Me.txLogin)
        Me.Panel1.Controls.Add(Me.lblPass)
        Me.Panel1.Controls.Add(Me.lblLogin)
        Me.Panel1.Location = New System.Drawing.Point(12, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(265, 88)
        Me.Panel1.TabIndex = 2
        '
        'txPass
        '
        Me.txPass.Location = New System.Drawing.Point(86, 50)
        Me.txPass.Name = "txPass"
        Me.txPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txPass.Size = New System.Drawing.Size(100, 20)
        Me.txPass.TabIndex = 1
        '
        'rbDomain
        '
        Me.rbDomain.AutoSize = True
        Me.rbDomain.Location = New System.Drawing.Point(180, 34)
        Me.rbDomain.Name = "rbDomain"
        Me.rbDomain.Size = New System.Drawing.Size(63, 17)
        Me.rbDomain.TabIndex = 1
        Me.rbDomain.Text = "Dominio"
        Me.rbDomain.UseVisualStyleBackColor = True
        '
        'lblInfoText
        '
        Me.lblInfoText.AutoSize = True
        Me.lblInfoText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoText.Location = New System.Drawing.Point(9, 9)
        Me.lblInfoText.Name = "lblInfoText"
        Me.lblInfoText.Size = New System.Drawing.Size(366, 13)
        Me.lblInfoText.TabIndex = 9
        Me.lblInfoText.Text = "Por razones de seguridad, es necesario autenticarse de nuevo:"
        '
        'frmPass
        '
        Me.AcceptButton = Me.buOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.buCancel
        Me.ClientSize = New System.Drawing.Size(388, 144)
        Me.Controls.Add(Me.lblInfoText)
        Me.Controls.Add(Me.rbDomain)
        Me.Controls.Add(Me.buCancel)
        Me.Controls.Add(Me.buOk)
        Me.Controls.Add(Me.rbUser)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPass"
        Me.Text = "Verificar autenticación"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txLogin As System.Windows.Forms.TextBox
    Friend WithEvents rbUser As System.Windows.Forms.RadioButton
    Friend WithEvents buOk As System.Windows.Forms.Button
    Friend WithEvents buCancel As System.Windows.Forms.Button
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbDomain As System.Windows.Forms.RadioButton
    Friend WithEvents txPass As System.Windows.Forms.TextBox
    Friend WithEvents lblInfoText As System.Windows.Forms.Label
End Class
