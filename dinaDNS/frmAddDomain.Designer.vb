<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddDomain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddDomain))
        Me.cbDomain = New System.Windows.Forms.ComboBox
        Me.txDomain = New System.Windows.Forms.TextBox
        Me.rbFill = New System.Windows.Forms.RadioButton
        Me.rbSelect = New System.Windows.Forms.RadioButton
        Me.buCancel = New System.Windows.Forms.Button
        Me.buOk = New System.Windows.Forms.Button
        Me.lblTitle = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cbDomain
        '
        Me.cbDomain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDomain.FormattingEnabled = True
        Me.cbDomain.Location = New System.Drawing.Point(66, 41)
        Me.cbDomain.Name = "cbDomain"
        Me.cbDomain.Size = New System.Drawing.Size(203, 21)
        Me.cbDomain.TabIndex = 1
        '
        'txDomain
        '
        Me.txDomain.Enabled = False
        Me.txDomain.Location = New System.Drawing.Point(66, 68)
        Me.txDomain.Name = "txDomain"
        Me.txDomain.Size = New System.Drawing.Size(203, 20)
        Me.txDomain.TabIndex = 3
        '
        'rbFill
        '
        Me.rbFill.AutoSize = True
        Me.rbFill.Location = New System.Drawing.Point(34, 71)
        Me.rbFill.Name = "rbFill"
        Me.rbFill.Size = New System.Drawing.Size(14, 13)
        Me.rbFill.TabIndex = 2
        Me.rbFill.UseVisualStyleBackColor = True
        '
        'rbSelect
        '
        Me.rbSelect.AutoSize = True
        Me.rbSelect.Checked = True
        Me.rbSelect.Location = New System.Drawing.Point(34, 44)
        Me.rbSelect.Name = "rbSelect"
        Me.rbSelect.Size = New System.Drawing.Size(14, 13)
        Me.rbSelect.TabIndex = 0
        Me.rbSelect.TabStop = True
        Me.rbSelect.UseVisualStyleBackColor = True
        '
        'buCancel
        '
        Me.buCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buCancel.Location = New System.Drawing.Point(47, 104)
        Me.buCancel.Name = "buCancel"
        Me.buCancel.Size = New System.Drawing.Size(75, 23)
        Me.buCancel.TabIndex = 5
        Me.buCancel.Text = "&Cancelar"
        Me.buCancel.UseVisualStyleBackColor = True
        '
        'buOk
        '
        Me.buOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.buOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buOk.Location = New System.Drawing.Point(196, 104)
        Me.buOk.Name = "buOk"
        Me.buOk.Size = New System.Drawing.Size(75, 23)
        Me.buOk.TabIndex = 4
        Me.buOk.Text = "&Aceptar"
        Me.buOk.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(22, 14)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(255, 13)
        Me.lblTitle.TabIndex = 9
        Me.lblTitle.Text = "Dominio que quiere añadir para controlar con dinaIP:"
        '
        'frmAddDomain
        '
        Me.AcceptButton = Me.buOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.buCancel
        Me.ClientSize = New System.Drawing.Size(311, 139)
        Me.Controls.Add(Me.txDomain)
        Me.Controls.Add(Me.cbDomain)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.buCancel)
        Me.Controls.Add(Me.buOk)
        Me.Controls.Add(Me.rbSelect)
        Me.Controls.Add(Me.rbFill)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddDomain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Añadir dominio"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbDomain As System.Windows.Forms.ComboBox
    Friend WithEvents txDomain As System.Windows.Forms.TextBox
    Friend WithEvents rbFill As System.Windows.Forms.RadioButton
    Friend WithEvents rbSelect As System.Windows.Forms.RadioButton
    Friend WithEvents buCancel As System.Windows.Forms.Button
    Friend WithEvents buOk As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
End Class
