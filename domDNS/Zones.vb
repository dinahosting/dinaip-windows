Imports System.Xml.XPath

Public Class Zones
    Inherits CommonAttributes
    Dim ls As List(Of Data.InfoZone)
    Dim iZones As Integer = Nothing
    Dim silentMode As Boolean = False

    Public Property List() As List(Of Data.InfoZone)
        Get
            Return ls
        End Get
        Set(ByVal value As List(Of Data.InfoZone))
            ls = value
        End Set
    End Property

    Public Function GetItemByHost(ByVal strHost As String) As Data.InfoZone
        If ls Is Nothing OrElse strHost = Nothing Then Return Nothing
        For Each iz As Data.InfoZone In ls
            If iz.Host = strHost Then
                Return iz
            End If
        Next
        Return Nothing
    End Function

    Public Property ZonesCount() As Integer
        Get
            Return iZones
        End Get
        Set(ByVal value As Integer)
            iZones = value
        End Set
    End Property

    ''' <summary>
    ''' Obtiene las zonas del dominio
    ''' </summary>
    Public Sub GetIt(ByVal strUser As String, ByVal strPasswordValue As String, ByVal strDomain As String)
        Me.InitializeExecute(strUser, strPasswordValue, strDomain)
        Dim values As Xml.XmlNodeList = Nothing
        Try
            If strUser = Nothing Then
                values = Me.GetXMLRequestPOSTMethod("dom_getZones", params)
            Else
                values = XmlRpc.GetZonesDomain(strUser, strPasswordValue, strDomain, silentMode)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        ls = New List(Of Data.InfoZone)
        Me.ZonesCount = -1
        If values Is Nothing Then Exit Sub
        Try
            Me.ZonesCount = Me.GetNodeInList("ZonesCount", values)

            For Each node As Xml.XmlNode In values.Item(0).ChildNodes
                If node.Name = "zone" Then
                    ls.Add(New Data.InfoZone(GetNodeInList("host", node.ChildNodes), GetNodeInList("type", node.ChildNodes), GetNodeInList("address", node.ChildNodes), strUser))
                End If
            Next

            GetCommonValues(values)
        Catch ex As Exception
            Throw New Exception(ex.Message & Me.ErrxTranslated)
        End Try
        If Not Me.Done Then
            Throw New Exception(Me.ErrxTranslated(False))
        End If
    End Sub

    ''' <summary>
    ''' Establece las zonas del dominio
    ''' </summary>
    Public Sub SetIt(ByVal strUser As String, ByVal strPasswordValue As String, ByVal strDomain As String, ByVal bAllowZeroZones As Boolean)
        If Not bAllowZeroZones AndAlso ls.Count = 0 Then
            Throw New Exception("The number of zones should be greater than [SET]")
        End If
        Me.InitializeExecute(strUser, strPasswordValue, strDomain)
        Dim values As Xml.XmlNodeList = Nothing
        Dim i As Integer = 0
        Dim strCol As String = Nothing
        For Each iz As Data.InfoZone In ls
            AddZoneToParams(iz, i)
            AddZoneToString(iz, i, strCol)
            i += 1
        Next
        strCol = "NumZones=" & ls.Count & strCol
        Try
            If strUser = Nothing Then
                params.Add(New Data.Parametro("NumZones", ls.Count))
                values = GetXMLRequestPOSTMethod("dom_setZones", params)
            Else
                values = XmlRpc.SetZonesDomain(strUser, strPasswordValue, strDomain, strCol, silentMode)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message & "[SET]")
        End Try
        Try
            GetCommonValues(values)
        Catch ex As Exception
            Throw New Exception(ex.Message & Me.ErrxTranslated & "[GET]")
        End Try
        If Not Me.Done Then
            Throw New Exception(Me.ErrxTranslated(False))
        End If
    End Sub

    Public Sub AddZoneToParams(ByVal iz As Data.InfoZone, ByVal iElement As Integer)
        If iz.Host = "mx" AndAlso iz.Type <> Data.TypeHost.MX Then Throw New Exception("El host de la zona 'mx' no está permitido.")
        If iz.Host = "mxs" AndAlso iz.Type <> Data.TypeHost.MXS Then Throw New Exception("El host de la zona 'mxs' no está permitido.")
        If iz.Host = "mx1" AndAlso iz.Type <> Data.TypeHost.MXD1 Then Throw New Exception("El host de la zona 'mx1' no está permitido.")
        If iz.Host = "mx2" AndAlso iz.Type <> Data.TypeHost.MXD2 Then Throw New Exception("El host de la zona 'mx2' no está permitido.")
        If iz.Host = "srv" AndAlso iz.Type <> Data.TypeHost.SRV Then Throw New Exception("El host de la zona 'srv' no está permitido.")
        If iz.Host = "def" Then Throw New Exception("El host de la zona 'def' no está permitido.")
        params.Add(New Data.Parametro("Host" & iElement, iz.Host))
        params.Add(New Data.Parametro("Type" & iElement, iz.TypeToAPI))
        Select Case iz.Type
            Case Data.TypeHost.SPF, Data.TypeHost.TXT
                params.Add(New Data.Parametro("Address" & iElement, System.Web.HttpUtility.UrlEncode(iz.Address)))
            Case Else
                params.Add(New Data.Parametro("Address" & iElement, iz.Address))
        End Select
    End Sub

    Public Sub AddZoneToString(ByVal iz As Data.InfoZone, ByVal iElement As Integer, ByRef strCol As String)
        Select Case iz.Type
            Case Data.TypeHost.FRAME, Data.TypeHost.URL
                If Not iz.Address.StartsWith("http://") And Not iz.Address.StartsWith("https://") And Not iz.Address.StartsWith("ftp://") Then iz.Address = "http://" & iz.Address
            Case Else
                'en principio non fai modificación nin comprobación algunha
        End Select
        If iz.Host = "mx" AndAlso iz.Type <> Data.TypeHost.MX Then Throw New Exception("El host de la zona 'mx' no está permitido.")
        If iz.Host = "mxs" AndAlso iz.Type <> Data.TypeHost.MXS Then Throw New Exception("El host de la zona 'mxs' no está permitido.")
        If iz.Host = "mx1" AndAlso iz.Type <> Data.TypeHost.MXD1 Then Throw New Exception("El host de la zona 'mx1' no está permitido.")
        If iz.Host = "mx2" AndAlso iz.Type <> Data.TypeHost.MXD2 Then Throw New Exception("El host de la zona 'mx2' no está permitido.")
        If iz.Host = "srv" AndAlso iz.Type <> Data.TypeHost.SRV Then Throw New Exception("El host de la zona 'srv' no está permitido.")
        If iz.Host = "def" Then Throw New Exception("El host de la zona 'def' no está permitido.")
        strCol &= "&Host" & iElement & "=" & iz.Host & "&Type" & iElement & "=" & iz.TypeToAPI & "&Address" & iElement & "="
        Select Case iz.Type
            Case Data.TypeHost.SPF, Data.TypeHost.TXT
                strCol &= System.Web.HttpUtility.UrlEncode(iz.Address)
            Case Else
                strCol &= iz.Address
        End Select
    End Sub

    Public Sub New(ByVal bSilentMode As Boolean)
        silentMode = bSilentMode
    End Sub
End Class