<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmZones
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmZones))
        Me.pnLines = New System.Windows.Forms.Panel
        Me.buAdd = New System.Windows.Forms.Button
        Me.pnLine1 = New System.Windows.Forms.Panel
        Me.txHost1 = New System.Windows.Forms.TextBox
        Me.cbTipo1 = New System.Windows.Forms.ComboBox
        Me.txValor1 = New System.Windows.Forms.TextBox
        Me.chkIpDinamica1 = New System.Windows.Forms.CheckBox
        Me.buRemove1 = New System.Windows.Forms.Button
        Me.buCancel = New System.Windows.Forms.Button
        Me.buSave = New System.Windows.Forms.Button
        Me.pnLabels = New System.Windows.Forms.Panel
        Me.lblType = New System.Windows.Forms.Label
        Me.lvlOption = New System.Windows.Forms.Label
        Me.lblValue = New System.Windows.Forms.Label
        Me.lblHost = New System.Windows.Forms.Label
        Me.chkAutoDetectIp = New System.Windows.Forms.CheckBox
        Me.lblIp = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pnLines.SuspendLayout()
        Me.pnLine1.SuspendLayout()
        Me.pnLabels.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnLines
        '
        Me.pnLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnLines.AutoScroll = True
        Me.pnLines.Controls.Add(Me.buAdd)
        Me.pnLines.Controls.Add(Me.pnLine1)
        Me.pnLines.Location = New System.Drawing.Point(12, 34)
        Me.pnLines.Name = "pnLines"
        Me.pnLines.Size = New System.Drawing.Size(678, 55)
        Me.pnLines.TabIndex = 9
        '
        'buAdd
        '
        Me.buAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buAdd.Location = New System.Drawing.Point(652, 3)
        Me.buAdd.Name = "buAdd"
        Me.buAdd.Size = New System.Drawing.Size(22, 22)
        Me.buAdd.TabIndex = 10
        Me.buAdd.Text = "+"
        Me.buAdd.UseVisualStyleBackColor = True
        '
        'pnLine1
        '
        Me.pnLine1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnLine1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnLine1.Controls.Add(Me.txHost1)
        Me.pnLine1.Controls.Add(Me.cbTipo1)
        Me.pnLine1.Controls.Add(Me.txValor1)
        Me.pnLine1.Controls.Add(Me.chkIpDinamica1)
        Me.pnLine1.Controls.Add(Me.buRemove1)
        Me.pnLine1.Location = New System.Drawing.Point(0, 0)
        Me.pnLine1.Name = "pnLine1"
        Me.pnLine1.Size = New System.Drawing.Size(678, 28)
        Me.pnLine1.TabIndex = 0
        '
        'txHost1
        '
        Me.txHost1.Location = New System.Drawing.Point(3, 3)
        Me.txHost1.Name = "txHost1"
        Me.txHost1.Size = New System.Drawing.Size(155, 20)
        Me.txHost1.TabIndex = 0
        '
        'cbTipo1
        '
        Me.cbTipo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipo1.FormattingEnabled = True
        Me.cbTipo1.Items.AddRange(New Object() {"A", "AAAA", "CNAME", "FRAME", "TXT", "URL"})
        Me.cbTipo1.Location = New System.Drawing.Point(164, 2)
        Me.cbTipo1.Name = "cbTipo1"
        Me.cbTipo1.Size = New System.Drawing.Size(64, 21)
        Me.cbTipo1.TabIndex = 1
        '
        'txValor1
        '
        Me.txValor1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txValor1.Location = New System.Drawing.Point(234, 3)
        Me.txValor1.Name = "txValor1"
        Me.txValor1.Size = New System.Drawing.Size(300, 20)
        Me.txValor1.TabIndex = 2
        '
        'chkIpDinamica1
        '
        Me.chkIpDinamica1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIpDinamica1.AutoSize = True
        Me.chkIpDinamica1.Location = New System.Drawing.Point(540, 5)
        Me.chkIpDinamica1.Name = "chkIpDinamica1"
        Me.chkIpDinamica1.Size = New System.Drawing.Size(81, 17)
        Me.chkIpDinamica1.TabIndex = 3
        Me.chkIpDinamica1.Text = "IP dinámica"
        Me.chkIpDinamica1.UseVisualStyleBackColor = True
        '
        'buRemove1
        '
        Me.buRemove1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buRemove1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buRemove1.Location = New System.Drawing.Point(627, 2)
        Me.buRemove1.Name = "buRemove1"
        Me.buRemove1.Size = New System.Drawing.Size(22, 22)
        Me.buRemove1.TabIndex = 4
        Me.buRemove1.Text = "-"
        Me.buRemove1.UseVisualStyleBackColor = True
        '
        'buCancel
        '
        Me.buCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buCancel.Location = New System.Drawing.Point(150, 105)
        Me.buCancel.Name = "buCancel"
        Me.buCancel.Size = New System.Drawing.Size(120, 23)
        Me.buCancel.TabIndex = 8
        Me.buCancel.Text = "&Descartar cambios"
        Me.buCancel.UseVisualStyleBackColor = True
        '
        'buSave
        '
        Me.buSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.buSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buSave.Location = New System.Drawing.Point(440, 105)
        Me.buSave.Name = "buSave"
        Me.buSave.Size = New System.Drawing.Size(120, 23)
        Me.buSave.TabIndex = 7
        Me.buSave.Text = "&Guardar cambios"
        Me.buSave.UseVisualStyleBackColor = True
        '
        'pnLabels
        '
        Me.pnLabels.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnLabels.Controls.Add(Me.lblType)
        Me.pnLabels.Controls.Add(Me.lvlOption)
        Me.pnLabels.Controls.Add(Me.lblValue)
        Me.pnLabels.Controls.Add(Me.lblHost)
        Me.pnLabels.Location = New System.Drawing.Point(12, 4)
        Me.pnLabels.Name = "pnLabels"
        Me.pnLabels.Size = New System.Drawing.Size(678, 28)
        Me.pnLabels.TabIndex = 10
        '
        'lblType
        '
        Me.lblType.BackColor = System.Drawing.Color.Gainsboro
        Me.lblType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.Location = New System.Drawing.Point(161, 5)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(72, 23)
        Me.lblType.TabIndex = 1
        Me.lblType.Text = "Tipo"
        Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lvlOption
        '
        Me.lvlOption.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvlOption.BackColor = System.Drawing.Color.Gainsboro
        Me.lvlOption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvlOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlOption.Location = New System.Drawing.Point(538, 5)
        Me.lvlOption.Name = "lvlOption"
        Me.lvlOption.Size = New System.Drawing.Size(140, 23)
        Me.lvlOption.TabIndex = 3
        Me.lvlOption.Text = "Opción"
        Me.lvlOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblValue
        '
        Me.lblValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblValue.BackColor = System.Drawing.Color.Gainsboro
        Me.lblValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValue.Location = New System.Drawing.Point(232, 5)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(307, 23)
        Me.lblValue.TabIndex = 2
        Me.lblValue.Text = "Valor"
        Me.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHost
        '
        Me.lblHost.BackColor = System.Drawing.Color.Gainsboro
        Me.lblHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHost.Location = New System.Drawing.Point(0, 5)
        Me.lblHost.Name = "lblHost"
        Me.lblHost.Size = New System.Drawing.Size(162, 23)
        Me.lblHost.TabIndex = 0
        Me.lblHost.Text = "Host"
        Me.lblHost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkAutoDetectIp
        '
        Me.chkAutoDetectIp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkAutoDetectIp.AutoSize = True
        Me.chkAutoDetectIp.Location = New System.Drawing.Point(12, 102)
        Me.chkAutoDetectIp.Name = "chkAutoDetectIp"
        Me.chkAutoDetectIp.Size = New System.Drawing.Size(91, 30)
        Me.chkAutoDetectIp.TabIndex = 11
        Me.chkAutoDetectIp.Text = "Autodetectar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ip's dinámicas"
        Me.chkAutoDetectIp.UseVisualStyleBackColor = True
        '
        'lblIp
        '
        Me.lblIp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIp.Location = New System.Drawing.Point(599, 102)
        Me.lblIp.Name = "lblIp"
        Me.lblIp.Size = New System.Drawing.Size(91, 30)
        Me.lblIp.TabIndex = 12
        Me.lblIp.Text = "Label1"
        Me.lblIp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 5000
        '
        'frmZones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.buCancel
        Me.ClientSize = New System.Drawing.Size(702, 136)
        Me.Controls.Add(Me.lblIp)
        Me.Controls.Add(Me.chkAutoDetectIp)
        Me.Controls.Add(Me.pnLabels)
        Me.Controls.Add(Me.buCancel)
        Me.Controls.Add(Me.pnLines)
        Me.Controls.Add(Me.buSave)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(650, 170)
        Me.Name = "frmZones"
        Me.Text = "Panel de zonas de DNS"
        Me.pnLines.ResumeLayout(False)
        Me.pnLine1.ResumeLayout(False)
        Me.pnLine1.PerformLayout()
        Me.pnLabels.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnLines As System.Windows.Forms.Panel
    Friend WithEvents pnLine1 As System.Windows.Forms.Panel
    Friend WithEvents chkIpDinamica1 As System.Windows.Forms.CheckBox
    Friend WithEvents cbTipo1 As System.Windows.Forms.ComboBox
    Friend WithEvents txValor1 As System.Windows.Forms.TextBox
    Friend WithEvents txHost1 As System.Windows.Forms.TextBox
    Friend WithEvents buCancel As System.Windows.Forms.Button
    Friend WithEvents buSave As System.Windows.Forms.Button
    Friend WithEvents buRemove1 As System.Windows.Forms.Button
    Friend WithEvents pnLabels As System.Windows.Forms.Panel
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblHost As System.Windows.Forms.Label
    Friend WithEvents lvlOption As System.Windows.Forms.Label
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents buAdd As System.Windows.Forms.Button
    Friend WithEvents chkAutoDetectIp As System.Windows.Forms.CheckBox
    Friend WithEvents lblIp As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
