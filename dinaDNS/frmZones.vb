Public Class frmZones
    Dim zn As New domDNS.Zones(False)
    Dim bAllowChange As Boolean = True

    Private Sub buAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buAdd.Click
        Dim iLastLine As Integer = pnLines.Controls(pnLines.Controls.Count - 1).Name.Replace("pnLine", Nothing)
        Dim iLine As Integer = iLastLine + 1

        If pnLines.Controls("pnLine" & iLastLine).Top - 1 + (2 * pnLines.Controls("pnLine" & iLastLine).Height) > pnLines.Height AndAlso Not pnLines.VerticalScroll.Visible Then
            'está mostrando o scroll
            pnLabels.Width -= 17
        End If

        Dim chk As New System.Windows.Forms.CheckBox
        chk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        chk.AutoSize = True
        chk.Location = pnLines.Controls("pnLine" & iLastLine).Controls("chkIpDinamica" & iLastLine).Location
        chk.Name = "chkIpDinamica" & iLine
        chk.Size = New System.Drawing.Size(81, 17)
        chk.TabIndex = 3
        chk.Text = "IP dinámica"
        chk.UseVisualStyleBackColor = True

        Dim bu As New System.Windows.Forms.Button
        bu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        bu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        bu.Location = pnLines.Controls("pnLine" & iLastLine).Controls("buRemove" & iLastLine).Location
        bu.Name = "buRemove" & iLine
        bu.Size = New System.Drawing.Size(22, 22)
        bu.TabIndex = 3
        bu.Text = "-"
        bu.UseVisualStyleBackColor = True
        AddHandler bu.Click, AddressOf buRemove_Click

        Dim cb As New System.Windows.Forms.ComboBox
        cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        cb.FormattingEnabled = True
        cb.Items.AddRange(New Object() {"A", "AAAA", "CNAME", "FRAME", "TXT", "URL"})
        cb.Location = New System.Drawing.Point(164, 2)
        cb.Name = "cb"
        cb.Size = New System.Drawing.Size(64, 21)
        cb.TabIndex = 1

        Dim txValue As New System.Windows.Forms.TextBox
        txValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        txValue.Location = New System.Drawing.Point(234, 3)
        txValue.Name = "txValor" & iLine
        txValue.Size = pnLines.Controls("pnLine" & iLastLine).Controls("txValor" & iLastLine).Size
        txValue.TabIndex = 2

        Dim txHost As New System.Windows.Forms.TextBox
        txHost.Location = New System.Drawing.Point(3, 3)
        txHost.Name = "txHost" & iLine
        txHost.Size = New System.Drawing.Size(155, 20)
        txHost.TabIndex = 0

        Dim pn As New System.Windows.Forms.Panel
        pn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        pn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        pn.Location = New System.Drawing.Point(0, pnLines.Controls("pnLine" & iLastLine).Top + pnLines.Controls("pnLine" & iLastLine).Height - 1)
        pn.Name = "pnLine" & iLine
        pn.Size = pnLines.Controls("pnLine" & iLastLine).Size
        pn.TabIndex = pnLines.Controls("pnLine" & iLastLine).TabIndex + 1
        pn.Controls.Add(txHost)
        pn.Controls.Add(cb)
        pn.Controls.Add(txValue)
        pn.Controls.Add(chk)
        pn.Controls.Add(bu)

        AddHandler cb.SelectedIndexChanged, AddressOf ZoneChange
        AddHandler txValue.TextChanged, AddressOf ZoneChange
        AddHandler chk.EnabledChanged, AddressOf ChkIPEnabledChanged
        AddHandler chk.CheckedChanged, AddressOf chkIpCheckedChanged
        AddHandler txHost.TextChanged, AddressOf ChangeHost
        AddHandler txHost.Enter, AddressOf EnterHost

        pnLines.Controls.Add(pn)
        buAdd.Top = pn.Top + 3
        buAdd.TabIndex += 1
        buCancel.TabIndex += 1
        buSave.TabIndex += 1
        pnLines.ScrollControlIntoView(pn)
        txHost.Select()
        iLastLine = iLine
    End Sub

    Private Sub buRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buRemove1.Click
        strLastText = sender.parent.controls(0).text
        If Not ChangeHostInZone(sender.parent, True) Then Exit Sub
        Remove(sender.name.replace("buRemove", Nothing))
    End Sub

    Private Sub Remove(ByVal iLine As Integer)
        Dim pnLine As Panel = pnLines.Controls("pnLine" & iLine)
        If pnLines.Controls.Count = 2 Then
            ClearContainer(pnLine)
            Exit Sub
        End If
        Dim bVisible As Boolean = pnLines.VerticalScroll.Visible
        For Each ctrl As Control In pnLines.Controls
            If ctrl.Top > pnLine.Top Then
                ctrl.Top -= pnLine.Height - 1
            End If
        Next
        While pnLine.Controls.Count > 0
            pnLine.Controls(0).Dispose()
        End While
        pnLine.Dispose()
        pnLines.Controls.Remove(pnLine)
        buAdd.TabIndex -= 1
        buCancel.TabIndex -= 1
        buSave.TabIndex -= 1
        frmZones_SizeChanged(Me, Nothing)
    End Sub

    Private Sub frmZones_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        bAllowChange = ReadOptionsRegistry("AutoDetect")
        chkAutoDetectIp.Checked = bAllowChange
        'Se non ten ip  automática, activo todo
        For Each ctrl As Control In Me.pnLines.Controls
            If Not ctrl.GetType Is GetType(Button) Then
                ZoneChange(ctrl.Controls(0), Nothing)
            End If
        Next
        Timer1_Tick(Timer1, Nothing)
    End Sub

    Private Sub frmZones_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If pnLines.VerticalScroll.Visible Then
            pnLabels.Width = pnLines.Width - 17
        Else
            pnLabels.Width = pnLines.Width
        End If
    End Sub

    Private Sub frmZones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'obteño as zonas do dominio
        Try
            zn.GetIt(IIf(actLogin.IsDomain, Nothing, actLogin.Login), actLogin.PassWord, Me.Tag.Domain)
        Catch ex As Exception
            ShowError(ex.Message, True)
            buCancel_Click(Nothing, Nothing)
            Exit Sub
        End Try
        'obteño as zonas do rexitro
        Dim lSavedZones As Dictionary(Of String, domDNS.Data.InfoZone) = GetZonesDomain(Me.Tag.Domain)
        Dim pn As Panel = pnLines.Controls("pnLine1")
        Dim iFile As Integer = 1
        For Each iz As domDNS.Data.InfoZone In zn.List
            Select Case iz.Type
                Case domDNS.Data.TypeHost.unknown, domDNS.Data.TypeHost.MX, domDNS.Data.TypeHost.MXS, domDNS.Data.TypeHost.MXD1, domDNS.Data.TypeHost.MXD2, domDNS.Data.TypeHost.R301, domDNS.Data.TypeHost.SPF, domDNS.Data.TypeHost.SRV
                    'estos tipos non se deixan cambiar
                    'Console.WriteLine("Este non se deixa tocar..." & iz.Host & vbTab & iz.TypeToString)
                Case Else
                    If pn Is Nothing Then
                        buAdd_Click(buAdd, Nothing)
                        pn = Me.pnLines.Controls(iFile)
                        If Me.Size.Height + Me.Location.Y + pn.Height < My.Computer.Screen.WorkingArea.Height Then Me.Height += pn.Height
                    End If
                    If pn Is Nothing Then Throw New Exception("BAD COMPOSITION WITH ZONES")
                    'gardo no tag na liña o antigo host, por se o borra ou o 
                    pn.Tag = iz.Host
                    pn.Controls(0).Text = iz.Host
                    Dim bSinceWeb As Boolean = True
                    If iz.Host <> Nothing AndAlso lSavedZones.ContainsKey(iz.Host) Then
                        If iz.Address <> lSavedZones(iz.Host).Address Then
                            bSinceWeb = MsgBoxCond("Existen diferencias en la zona '" & iz.Host & "':" & vbCrLf & vbCrLf & _
                                            "PC:" & vbTab & lSavedZones(iz.Host).Address & vbTab & "(" & lSavedZones(iz.Host).TypeToString & ")" & vbCrLf & _
                                            "Dominio:" & vbTab & iz.Address & vbTab & "(" & iz.TypeToString & ")" & vbCrLf & vbCrLf & _
                                            "¿desea mantener el valor que la zona tiene en su PC?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, True) = MsgBoxResult.No
                            If bSinceWeb Then
                                lSavedZones.Remove(iz.Host)
                            End If
                        Else
                            bSinceWeb = False
                        End If
                    End If
                    If bSinceWeb Then
                        pn.Controls(1).Text = iz.TypeToString
                        pn.Controls(2).Text = iz.Address
                        CType(pn.Controls(3), CheckBox).Checked = False
                    Else
                        pn.Controls(1).Text = lSavedZones(iz.Host).TypeToString
                        pn.Controls(2).Text = lSavedZones(iz.Host).Address
                        CType(pn.Controls(3), CheckBox).Checked = True
                        lSavedZones.Remove(iz.Host)
                    End If
                    pn = Nothing
                    iFile += 1
            End Select
        Next
        If lSavedZones.Count > 0 AndAlso MsgBoxCond("En el equipo actual hay guardadas zonas que actualmente no están definidas en su dominio," & vbCrLf & "¿desea mostrarlas para poder gestionarlas?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1, True) = MsgBoxResult.Yes Then
            For Each iz As domDNS.Data.InfoZone In lSavedZones.Values
                Select Case iz.Type
                    Case domDNS.Data.TypeHost.unknown, domDNS.Data.TypeHost.SPF, domDNS.Data.TypeHost.MXD1, domDNS.Data.TypeHost.MXD2
                        'estos tipos non se deixan cambiar
                        'Console.WriteLine("Este non se deixa tocar..." & iz.Host & vbTab & iz.TypeToString)
                    Case Else
                        If pn Is Nothing Then
                            buAdd_Click(buAdd, Nothing)
                            pn = Me.pnLines.Controls(iFile)
                            If Me.Size.Height + Me.Location.Y + pn.Height < My.Computer.Screen.WorkingArea.Height Then Me.Height += pn.Height
                        End If
                        If pn Is Nothing Then Throw New Exception("BAD COMPOSITION WITH ZONES")
                        'gardo no tag na liña o antigo host, por se o borra ou o 
                        pn.Tag = iz.Host
                        pn.Controls(0).Text = iz.Host
                        pn.Controls(1).Text = iz.TypeToString
                        pn.Controls(2).Text = iz.Address
                        CType(pn.Controls(3), CheckBox).Checked = True
                        pn = Nothing
                        iFile += 1
                End Select
            Next
        End If
        VerifyPermissionZones()
    End Sub

    Private Sub VerifyPermissionZones()
        If zn Is Nothing OrElse zn.List Is Nothing Then Exit Sub
        For Each ctrl As Control In Me.pnLines.Controls
            If Not ctrl.GetType Is GetType(Button) Then
                Dim iz As domDNS.Data.InfoZone = zn.GetItemByHost(ctrl.Tag)
                If ctrl.Tag <> Nothing AndAlso zn IsNot Nothing Then
                    CType(ctrl.Controls(3), CheckBox).Enabled = Not chkAutoDetectIp.Checked OrElse (Not iz Is Nothing AndAlso chkAutoDetectIp.Checked AndAlso Not AddressContainIP(iz.Address))
                    For Each znl As domDNS.Data.InfoZone In zn.List
                        Select Case znl.Type
                            Case domDNS.Data.TypeHost.unknown, domDNS.Data.TypeHost.SPF, domDNS.Data.TypeHost.MXD1, domDNS.Data.TypeHost.MXD2
                                If znl.Address = ctrl.Controls(0).Text & "." & Me.Tag.Domain & "." Then
                                    CType(ctrl.Controls(0), TextBox).ReadOnly = True
                                    ctrl.Controls(4).Visible = False
                                    ctrl.Controls(0).BackColor = Color.LightGray
                                    ctrl.Controls(0).ForeColor = Me.ForeColor
                                    Exit For
                                End If
                            Case Else

                        End Select
                        'Console.WriteLine(iz.Host & vbTab & iz.TypeToString)
                    Next
                End If
            End If
        Next
    End Sub

    Public Sub buCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buCancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Function CheckData() As Boolean
        CheckData = False
        Dim lRemove As New List(Of Panel)
        For Each ctrl As Control In Me.pnLines.Controls
            If Not ctrl.GetType Is GetType(Button) Then
                Select Case ctrl.Controls(0).Text
                    Case "mx1", "mx2", "def"
                        MsgBoxCond("No puede existir una zona con un host llamado '" & ctrl.Controls(0).Text & "'", MsgBoxStyle.Exclamation, True)
                        Exit Function
                    Case ""
                        If ctrl.Controls(1).Text = Nothing AndAlso ctrl.Controls(2).Text = Nothing Then
                            lRemove.Add(ctrl)
                        End If
                End Select
                If ctrl.Controls(1).Text = Nothing AndAlso (ctrl.Controls(0).Text <> Nothing Or ctrl.Controls(2).Text <> Nothing) Then
                    MsgBoxCond("Tiene que seleccionar el tipo de la zona.", MsgBoxStyle.Exclamation, True)
                    Return False
                End If
            End If
            ctrl.BackColor = Me.BackColor
        Next
        While lRemove.Count > 0
            buRemove_Click(lRemove(0).Controls(4), Nothing)
            lRemove.RemoveAt(0)
        End While
        Return True
    End Function

    Private Sub AddInfoZoneToCol(ByRef dic As List(Of domDNS.Data.InfoZone), ByVal iz As domDNS.Data.InfoZone)
        Try
            If iz Is Nothing Then Exit Sub
            If dic.Contains(iz) Then dic.Remove(iz)
            dic.Add(iz)
        Catch ex As Exception
            'Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub buSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buSave.Click
        If Not CheckData() Then Exit Sub
        SetCursorWait()
        Dim nd As New List(Of domDNS.Data.InfoZone)
        Dim lDinamics As New Dictionary(Of String, String())
        For Each ctrl As Control In Me.pnLines.Controls
            If Not ctrl.GetType Is GetType(Button) Then
                Try
                    zn.List.Remove(ctrl.Tag)
                Catch ex As Exception
                    'é novo
                End Try
                AddInfoZoneToCol(nd, New domDNS.Data.InfoZone(ctrl.Controls(0).Text, ctrl.Controls(1).Text, ctrl.Controls(2).Text, actLogin.Login))
                If ctrl.Tag Is Nothing Then ctrl.Tag = ctrl.Controls(0).Text
                If CType(ctrl.Controls(3), CheckBox).Checked Then
                    For Each icurz As domDNS.Data.InfoZone In nd
                        If icurz.Host = ctrl.Controls(0).Text Then
                            lDinamics.Add(icurz.Host, New String() {icurz.TypeToString, icurz.Address})
                            Exit For
                        End If
                    Next
                End If
            End If
        Next
        For Each iz As domDNS.Data.InfoZone In zn.List
            Select Case iz.Type
                Case domDNS.Data.TypeHost.unknown
                    If iz.Address <> Nothing And iz.Host <> Nothing Then
                        AddInfoZoneToCol(nd, iz)
                    End If
                Case domDNS.Data.TypeHost.MX, domDNS.Data.TypeHost.MXD1, domDNS.Data.TypeHost.MXD2, domDNS.Data.TypeHost.MXS, domDNS.Data.TypeHost.R301, domDNS.Data.TypeHost.SPF, domDNS.Data.TypeHost.SRV
                    AddInfoZoneToCol(nd, iz)
                Case Else
                    'descarta porque se borrou na pantalla
            End Select
        Next
        zn.List = nd
        Try
            zn.SetIt(IIf(actLogin.IsDomain, Nothing, actLogin.Login), actLogin.PassWord, Me.Tag.Domain, True)
            'se todo sae ben, realiza os cambios no rexistro
            Try
                DeleteZonesDomain(Me.Tag.Domain)
                For Each strZone As String In lDinamics.Keys
                    Utils.SetZoneDomain(Me.Tag.Domain, strZone, lDinamics.Item(strZone)(0), lDinamics.Item(strZone)(1))
                Next
                MsgBoxCond("Se han realizado los cambios correctamente.", MsgBoxStyle.Information, True)
            Catch ex As Exception
                MsgBoxCond("Se produjeron errores al guardar los cambios en el registro," & vbCrLf & "pero la modificación de las zonas ha sido correcta.", MsgBoxStyle.Exclamation, True)
            End Try

            Me.Close()
            Me.Dispose()
        Catch ex As Exception
            ShowError("No se han guardado los cambios porque se produjo el siguiente error:" & vbCrLf & ex.Message, True)
        End Try
        For Each i As Integer In zn.Errors
            Dim iCounter As Integer = 1
            For Each ctrl As Control In Me.pnLines.Controls
                If Not ctrl.GetType Is GetType(Button) Then
                    If iCounter = i Then ctrl.BackColor = k_badColor
                    iCounter += 1
                End If
            Next
            'Me.pnLines.Controls("pnLine" & i).BackColor = k_badColor
        Next
        SetCursorDefault()
    End Sub

    Dim strLastText As String = Nothing

    Private Sub EnterHost(ByVal sender As Object, ByVal e As System.EventArgs) Handles txHost1.Enter
        strLastText = sender.text
    End Sub

    Private Sub ChangeHost(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txHost1.TextChanged
        If Not ChangeHostInZone(sender.parent) Then
            sender.Text = strLastText
        End If
    End Sub

    Private Function ChangeHostInZone(ByVal pnLine As Panel, Optional ByVal bDelete As Boolean = False) As Boolean
        If zn Is Nothing OrElse zn.List Is Nothing OrElse strLastText = Nothing Then Return True
        For Each iz As domDNS.Data.InfoZone In zn.List
            Select Case iz.Type
                Case domDNS.Data.TypeHost.unknown, domDNS.Data.TypeHost.SPF, domDNS.Data.TypeHost.MX, domDNS.Data.TypeHost.MXS, domDNS.Data.TypeHost.MXD1, domDNS.Data.TypeHost.MXD2, domDNS.Data.TypeHost.SRV
                    If iz.Address = strLastText & "." & Me.Tag.Domain & "." Then
                        If strLastText <> pnLine.Controls(0).Text OrElse bDelete Then
                            Return (MsgBoxCond("No se puede modificar el host '" & pnLine.Controls(0).Text & "' porque hay una zona apuntando a él," & vbCrLf & "¿quiere realizar el cambio de todas maneras?", MsgBoxStyle.Information Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, True) = MsgBoxResult.Yes)
                        End If
                    End If
                Case Else
            End Select
        Next
        Return True
    End Function

    Private Sub ZoneChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txValor1.TextChanged, cbTipo1.SelectedIndexChanged
        CType(sender.parent.Controls(3), CheckBox).Visible = (sender.parent.controls(1).text = "A")
        If CType(sender.parent.Controls(3), CheckBox).Visible Then
            CType(sender.parent.Controls(3), CheckBox).Enabled = (Not bAllowChange OrElse (bAllowChange AndAlso AddressContainIP(sender.parent.controls(2).text)))
            If bAllowChange Then
                CType(sender.parent.Controls(3), CheckBox).Checked = AddressContainIP(sender.parent.controls(2).text)
            End If
        Else
            CType(sender.parent.Controls(3), CheckBox).Checked = False
        End If
    End Sub

    Private Sub chkIpCheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIpDinamica1.CheckedChanged
        If sender.checked AndAlso sender.parent.Controls(1).text = Nothing AndAlso sender.parent.Controls(2).text = Nothing Then
            sender.parent.Controls(1).text = "A"
            sender.parent.Controls(2).text = aut.ActualIp
        End If
    End Sub

    Private Sub ChkIPEnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIpDinamica1.EnabledChanged
        If Not sender.enabled Then sender.checked = False
    End Sub

    Private Sub chkAutoDetectIp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoDetectIp.CheckedChanged
        If sender.checked Then
            sender.forecolor = Color.Green
        Else
            sender.forecolor = Me.ForeColor
        End If
        UpdateOptionsRegistry("AutoDetect", chkAutoDetectIp.Checked)
        frmZones_Activated(Me, Nothing)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblIp.Text = "Ip actual:" & vbCrLf & aut.ActualIp
    End Sub
End Class
