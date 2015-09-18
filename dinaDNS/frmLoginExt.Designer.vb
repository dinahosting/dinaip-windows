<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoginExt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoginExt))
        Me.rbUser = New System.Windows.Forms.RadioButton
        Me.buOk = New System.Windows.Forms.Button
        Me.buCancel = New System.Windows.Forms.Button
        Me.lblLogin = New System.Windows.Forms.Label
        Me.lblPass = New System.Windows.Forms.Label
        Me.chkRemember = New System.Windows.Forms.CheckBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cbLogin = New System.Windows.Forms.ComboBox
        Me.txPass = New System.Windows.Forms.TextBox
        Me.rbDomain = New System.Windows.Forms.RadioButton
        Me.chkSaveData = New System.Windows.Forms.CheckBox
        Me.chkVerifyNewVerion = New System.Windows.Forms.CheckBox
        Me.chkAutoConnect = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rbUser
        '
        Me.rbUser.AutoSize = True
        Me.rbUser.Checked = True
        Me.rbUser.Location = New System.Drawing.Point(40, 16)
        Me.rbUser.Name = "rbUser"
        Me.rbUser.Size = New System.Drawing.Size(118, 17)
        Me.rbUser.TabIndex = 0
        Me.rbUser.TabStop = True
        Me.rbUser.Text = "Usuario dinahosting"
        Me.rbUser.UseVisualStyleBackColor = True
        '
        'buOk
        '
        Me.buOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.buOk.Enabled = False
        Me.buOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buOk.Location = New System.Drawing.Point(169, 231)
        Me.buOk.Name = "buOk"
        Me.buOk.Size = New System.Drawing.Size(75, 23)
        Me.buOk.TabIndex = 7
        Me.buOk.Text = "&Aceptar"
        Me.buOk.UseVisualStyleBackColor = True
        '
        'buCancel
        '
        Me.buCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buCancel.Location = New System.Drawing.Point(41, 231)
        Me.buCancel.Name = "buCancel"
        Me.buCancel.Size = New System.Drawing.Size(75, 23)
        Me.buCancel.TabIndex = 8
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
        'chkRemember
        '
        Me.chkRemember.AutoSize = True
        Me.chkRemember.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkRemember.Location = New System.Drawing.Point(48, 148)
        Me.chkRemember.Name = "chkRemember"
        Me.chkRemember.Size = New System.Drawing.Size(177, 17)
        Me.chkRemember.TabIndex = 4
        Me.chkRemember.Text = "Recordar contraseña de acceso"
        Me.chkRemember.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cbLogin)
        Me.Panel1.Controls.Add(Me.txPass)
        Me.Panel1.Controls.Add(Me.lblPass)
        Me.Panel1.Controls.Add(Me.lblLogin)
        Me.Panel1.Location = New System.Drawing.Point(12, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(268, 88)
        Me.Panel1.TabIndex = 2
        '
        'cbLogin
        '
        Me.cbLogin.FormattingEnabled = True
        Me.cbLogin.Location = New System.Drawing.Point(86, 24)
        Me.cbLogin.Name = "cbLogin"
        Me.cbLogin.Size = New System.Drawing.Size(161, 21)
        Me.cbLogin.TabIndex = 0
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
        Me.rbDomain.Location = New System.Drawing.Point(180, 16)
        Me.rbDomain.Name = "rbDomain"
        Me.rbDomain.Size = New System.Drawing.Size(63, 17)
        Me.rbDomain.TabIndex = 1
        Me.rbDomain.Text = "Dominio"
        Me.rbDomain.UseVisualStyleBackColor = True
        '
        'chkSaveData
        '
        Me.chkSaveData.AutoSize = True
        Me.chkSaveData.BackColor = System.Drawing.Color.Transparent
        Me.chkSaveData.CheckAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.chkSaveData.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkSaveData.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkSaveData.Location = New System.Drawing.Point(48, 125)
        Me.chkSaveData.Name = "chkSaveData"
        Me.chkSaveData.Size = New System.Drawing.Size(128, 17)
        Me.chkSaveData.TabIndex = 3
        Me.chkSaveData.Text = "Recordar identificador"
        Me.chkSaveData.UseVisualStyleBackColor = False
        '
        'chkVerifyNewVerion
        '
        Me.chkVerifyNewVerion.AutoSize = True
        Me.chkVerifyNewVerion.BackColor = System.Drawing.Color.Transparent
        Me.chkVerifyNewVerion.CheckAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.chkVerifyNewVerion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkVerifyNewVerion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkVerifyNewVerion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkVerifyNewVerion.Location = New System.Drawing.Point(48, 191)
        Me.chkVerifyNewVerion.Name = "chkVerifyNewVerion"
        Me.chkVerifyNewVerion.Size = New System.Drawing.Size(196, 17)
        Me.chkVerifyNewVerion.TabIndex = 6
        Me.chkVerifyNewVerion.Text = "Comprobar si hay una nueva versión"
        Me.chkVerifyNewVerion.UseVisualStyleBackColor = False
        '
        'chkAutoConnect
        '
        Me.chkAutoConnect.AutoSize = True
        Me.chkAutoConnect.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoConnect.CheckAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.chkAutoConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkAutoConnect.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAutoConnect.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkAutoConnect.Location = New System.Drawing.Point(48, 168)
        Me.chkAutoConnect.Name = "chkAutoConnect"
        Me.chkAutoConnect.Size = New System.Drawing.Size(192, 17)
        Me.chkAutoConnect.TabIndex = 5
        Me.chkAutoConnect.Text = "Conectar automáticamente al iniciar"
        Me.chkAutoConnect.UseVisualStyleBackColor = False
        '
        'frmLoginExt
        '
        Me.AcceptButton = Me.buOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.buCancel
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.chkSaveData)
        Me.Controls.Add(Me.chkVerifyNewVerion)
        Me.Controls.Add(Me.chkAutoConnect)
        Me.Controls.Add(Me.rbDomain)
        Me.Controls.Add(Me.chkRemember)
        Me.Controls.Add(Me.buCancel)
        Me.Controls.Add(Me.buOk)
        Me.Controls.Add(Me.rbUser)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoginExt"
        Me.Text = "Login dinaIP"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbUser As System.Windows.Forms.RadioButton
    Friend WithEvents buOk As System.Windows.Forms.Button
    Friend WithEvents buCancel As System.Windows.Forms.Button
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents chkRemember As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbDomain As System.Windows.Forms.RadioButton
    Friend WithEvents txPass As System.Windows.Forms.TextBox
    Friend WithEvents cbLogin As System.Windows.Forms.ComboBox
    Friend WithEvents chkSaveData As System.Windows.Forms.CheckBox
    Friend WithEvents chkVerifyNewVerion As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoConnect As System.Windows.Forms.CheckBox
End Class
