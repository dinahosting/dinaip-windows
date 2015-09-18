<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.tsbConectar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbNew = New System.Windows.Forms.ToolStripButton
        Me.tsbDel = New System.Windows.Forms.ToolStripButton
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiConectar = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmiNewDomain = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiEditDomain = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiDelDomain = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmiExportConfig = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiImportConfig = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmiExit = New System.Windows.Forms.ToolStripMenuItem
        Me.EjecuciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiReanudarServicio = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiDetenerServicio = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmiOptions = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiHostingsEnDinaHosting = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiHostingLinux = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiHostingWindows = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiHostingMac = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiServidoresDedicados = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmiTutorial = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiAcercaDe = New System.Windows.Forms.ToolStripMenuItem
        Me.niDinaDNS = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cmsNi = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiResumeService = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiStopService = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmiShowDNS = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiSalir = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.tmSilent = New System.Windows.Forms.Timer(Me.components)
        Me.tsmiCheckNow = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.cmsNi.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(12, 13)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(238, 256)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'ToolStrip
        '
        Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConectar, Me.ToolStripSeparator4, Me.tsbNew, Me.tsbDel})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(262, 31)
        Me.ToolStrip.Stretch = True
        Me.ToolStrip.TabIndex = 14
        Me.ToolStrip.Text = "ToolStrip"
        '
        'tsbConectar
        '
        Me.tsbConectar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbConectar.Image = CType(resources.GetObject("tsbConectar.Image"), System.Drawing.Image)
        Me.tsbConectar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConectar.Name = "tsbConectar"
        Me.tsbConectar.Size = New System.Drawing.Size(28, 28)
        Me.tsbConectar.Text = "Conectar a dinaHosting"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'tsbNew
        '
        Me.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNew.Image = CType(resources.GetObject("tsbNew.Image"), System.Drawing.Image)
        Me.tsbNew.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsbNew.Name = "tsbNew"
        Me.tsbNew.Size = New System.Drawing.Size(28, 28)
        Me.tsbNew.Text = "Nuevo"
        '
        'tsbDel
        '
        Me.tsbDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDel.Enabled = False
        Me.tsbDel.Image = CType(resources.GetObject("tsbDel.Image"), System.Drawing.Image)
        Me.tsbDel.ImageTransparentColor = System.Drawing.Color.White
        Me.tsbDel.Name = "tsbDel"
        Me.tsbDel.Size = New System.Drawing.Size(28, 28)
        Me.tsbDel.Text = "Eliminar"
        '
        'MenuStrip
        '
        Me.MenuStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.EjecuciónToolStripMenuItem, Me.HelpMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(262, 24)
        Me.MenuStrip.TabIndex = 12
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiConectar, Me.ToolStripSeparator5, Me.tsmiNewDomain, Me.tsmiEditDomain, Me.tsmiDelDomain, Me.ToolStripSeparator1, Me.tsmiExportConfig, Me.tsmiImportConfig, Me.ToolStripSeparator3, Me.tsmiExit})
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(55, 20)
        Me.FileMenu.Text = "&Archivo"
        '
        'tsmiConectar
        '
        Me.tsmiConectar.Name = "tsmiConectar"
        Me.tsmiConectar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.tsmiConectar.Size = New System.Drawing.Size(187, 22)
        Me.tsmiConectar.Text = "&Conectar"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(184, 6)
        '
        'tsmiNewDomain
        '
        Me.tsmiNewDomain.Image = CType(resources.GetObject("tsmiNewDomain.Image"), System.Drawing.Image)
        Me.tsmiNewDomain.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsmiNewDomain.Name = "tsmiNewDomain"
        Me.tsmiNewDomain.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.tsmiNewDomain.Size = New System.Drawing.Size(187, 22)
        Me.tsmiNewDomain.Text = "&Añadir dominio"
        '
        'tsmiEditDomain
        '
        Me.tsmiEditDomain.Enabled = False
        Me.tsmiEditDomain.Image = CType(resources.GetObject("tsmiEditDomain.Image"), System.Drawing.Image)
        Me.tsmiEditDomain.Name = "tsmiEditDomain"
        Me.tsmiEditDomain.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.tsmiEditDomain.Size = New System.Drawing.Size(187, 22)
        Me.tsmiEditDomain.Text = "Edi&tar dominio"
        '
        'tsmiDelDomain
        '
        Me.tsmiDelDomain.Enabled = False
        Me.tsmiDelDomain.Image = CType(resources.GetObject("tsmiDelDomain.Image"), System.Drawing.Image)
        Me.tsmiDelDomain.ImageTransparentColor = System.Drawing.Color.White
        Me.tsmiDelDomain.Name = "tsmiDelDomain"
        Me.tsmiDelDomain.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.tsmiDelDomain.Size = New System.Drawing.Size(187, 22)
        Me.tsmiDelDomain.Text = "&Eliminar dominio"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(184, 6)
        '
        'tsmiExportConfig
        '
        Me.tsmiExportConfig.Name = "tsmiExportConfig"
        Me.tsmiExportConfig.Size = New System.Drawing.Size(187, 22)
        Me.tsmiExportConfig.Text = "&Exportar configuración"
        '
        'tsmiImportConfig
        '
        Me.tsmiImportConfig.Name = "tsmiImportConfig"
        Me.tsmiImportConfig.Size = New System.Drawing.Size(187, 22)
        Me.tsmiImportConfig.Text = "&Importar configuración"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(184, 6)
        '
        'tsmiExit
        '
        Me.tsmiExit.Name = "tsmiExit"
        Me.tsmiExit.Size = New System.Drawing.Size(187, 22)
        Me.tsmiExit.Text = "&Salir"
        '
        'EjecuciónToolStripMenuItem
        '
        Me.EjecuciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiReanudarServicio, Me.tsmiDetenerServicio, Me.ToolStripSeparator6, Me.tsmiOptions})
        Me.EjecuciónToolStripMenuItem.Name = "EjecuciónToolStripMenuItem"
        Me.EjecuciónToolStripMenuItem.Size = New System.Drawing.Size(83, 20)
        Me.EjecuciónToolStripMenuItem.Text = "&Herramientas"
        '
        'tsmiReanudarServicio
        '
        Me.tsmiReanudarServicio.Name = "tsmiReanudarServicio"
        Me.tsmiReanudarServicio.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.tsmiReanudarServicio.Size = New System.Drawing.Size(242, 22)
        Me.tsmiReanudarServicio.Text = "&Reanudar servicio"
        '
        'tsmiDetenerServicio
        '
        Me.tsmiDetenerServicio.Name = "tsmiDetenerServicio"
        Me.tsmiDetenerServicio.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.tsmiDetenerServicio.Size = New System.Drawing.Size(242, 22)
        Me.tsmiDetenerServicio.Text = "&Detener servicio"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(239, 6)
        '
        'tsmiOptions
        '
        Me.tsmiOptions.Name = "tsmiOptions"
        Me.tsmiOptions.Size = New System.Drawing.Size(242, 22)
        Me.tsmiOptions.Text = "&Opciones"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiHostingsEnDinaHosting, Me.ToolStripSeparator7, Me.tsmiTutorial, Me.tsmiAcercaDe})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(50, 20)
        Me.HelpMenu.Text = "&Ayuda"
        '
        'tsmiHostingsEnDinaHosting
        '
        Me.tsmiHostingsEnDinaHosting.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiHostingLinux, Me.tsmiHostingWindows, Me.tsmiHostingMac, Me.tsmiServidoresDedicados})
        Me.tsmiHostingsEnDinaHosting.Name = "tsmiHostingsEnDinaHosting"
        Me.tsmiHostingsEnDinaHosting.Size = New System.Drawing.Size(134, 22)
        Me.tsmiHostingsEnDinaHosting.Text = "&Descubre"
        Me.tsmiHostingsEnDinaHosting.Visible = False
        '
        'tsmiHostingLinux
        '
        Me.tsmiHostingLinux.Name = "tsmiHostingLinux"
        Me.tsmiHostingLinux.Size = New System.Drawing.Size(177, 22)
        Me.tsmiHostingLinux.Text = "Hosting &Linux"
        '
        'tsmiHostingWindows
        '
        Me.tsmiHostingWindows.Name = "tsmiHostingWindows"
        Me.tsmiHostingWindows.Size = New System.Drawing.Size(177, 22)
        Me.tsmiHostingWindows.Text = "Hosting &Windows"
        '
        'tsmiHostingMac
        '
        Me.tsmiHostingMac.Name = "tsmiHostingMac"
        Me.tsmiHostingMac.Size = New System.Drawing.Size(177, 22)
        Me.tsmiHostingMac.Text = "Hosting &Mac"
        '
        'tsmiServidoresDedicados
        '
        Me.tsmiServidoresDedicados.Name = "tsmiServidoresDedicados"
        Me.tsmiServidoresDedicados.Size = New System.Drawing.Size(177, 22)
        Me.tsmiServidoresDedicados.Text = "Servidores &Dedicados"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(131, 6)
        Me.ToolStripSeparator7.Visible = False
        '
        'tsmiTutorial
        '
        Me.tsmiTutorial.Name = "tsmiTutorial"
        Me.tsmiTutorial.Size = New System.Drawing.Size(134, 22)
        Me.tsmiTutorial.Text = "&Tutorial"
        Me.tsmiTutorial.Visible = False
        '
        'tsmiAcercaDe
        '
        Me.tsmiAcercaDe.Name = "tsmiAcercaDe"
        Me.tsmiAcercaDe.Size = New System.Drawing.Size(134, 22)
        Me.tsmiAcercaDe.Text = "&Acerca de..."
        '
        'niDinaDNS
        '
        Me.niDinaDNS.ContextMenuStrip = Me.cmsNi
        Me.niDinaDNS.Icon = CType(resources.GetObject("niDinaDNS.Icon"), System.Drawing.Icon)
        Me.niDinaDNS.Tag = "2"
        Me.niDinaDNS.Text = "dinaIP"
        Me.niDinaDNS.Visible = True
        '
        'cmsNi
        '
        Me.cmsNi.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiResumeService, Me.tsmiStopService, Me.ToolStripSeparator8, Me.tsmiCheckNow, Me.ToolStripSeparator2, Me.tsmiShowDNS, Me.tsmiSalir})
        Me.cmsNi.Name = "cmsNi"
        Me.cmsNi.Size = New System.Drawing.Size(217, 148)
        '
        'tsmiResumeService
        '
        Me.tsmiResumeService.Name = "tsmiResumeService"
        Me.tsmiResumeService.Size = New System.Drawing.Size(216, 22)
        Me.tsmiResumeService.Text = "&Reanudar servicio automático"
        '
        'tsmiStopService
        '
        Me.tsmiStopService.Name = "tsmiStopService"
        Me.tsmiStopService.Size = New System.Drawing.Size(216, 22)
        Me.tsmiStopService.Text = "&Detener servicio automático"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(213, 6)
        '
        'tsmiShowDNS
        '
        Me.tsmiShowDNS.Name = "tsmiShowDNS"
        Me.tsmiShowDNS.Size = New System.Drawing.Size(216, 22)
        Me.tsmiShowDNS.Text = "&Mostrar dinaIP"
        '
        'tsmiSalir
        '
        Me.tsmiSalir.Name = "tsmiSalir"
        Me.tsmiSalir.Size = New System.Drawing.Size(216, 22)
        Me.tsmiSalir.Text = "&Salir"
        '
        'ToolStripContainer1
        '
        Me.ToolStripContainer1.BottomToolStripPanelVisible = False
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.ListView1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(262, 281)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(262, 312)
        Me.ToolStripContainer1.TabIndex = 15
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip)
        '
        'tmSilent
        '
        Me.tmSilent.Interval = 5000
        '
        'tsmiCheckNow
        '
        Me.tsmiCheckNow.Name = "tsmiCheckNow"
        Me.tsmiCheckNow.Size = New System.Drawing.Size(216, 22)
        Me.tsmiCheckNow.Text = "&Comprobar ahora"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(213, 6)
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(262, 336)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(270, 370)
        Me.Name = "frmMain"
        Me.Text = "dinaIP"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.cmsNi.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbConectar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDel As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiConectar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiNewDomain As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiEditDomain As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiDelDomain As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHostingsEnDinaHosting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHostingLinux As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHostingWindows As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHostingMac As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiServidoresDedicados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiTutorial As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAcercaDe As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents niDinaDNS As System.Windows.Forms.NotifyIcon
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiExportConfig As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiImportConfig As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsNi As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiResumeService As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiStopService As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiShowDNS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EjecuciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiReanudarServicio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiDetenerServicio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents tmSilent As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiCheckNow As System.Windows.Forms.ToolStripMenuItem
End Class
