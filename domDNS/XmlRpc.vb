Imports CookComputing.XmlRpc

Namespace XmlRpc
    <XmlRpcUrl("https://dinahosting.com/special/dhRpc/interface.php")> _
    Public Interface XmlRPCDH
        Inherits IXmlRpcProxy
        <XmlRpcMethod("getZones")> _
        Function GetZones(ByVal strDomain As String, ByVal strPassword As String) _
                                  As Object
        <XmlRpcMethod("loginDinaDNS")> _
        Function DoLogin(ByVal strName As String, ByVal strPassword As String, ByVal bIsDomain As Object) _
                                  As Object
        <XmlRpcMethod("getZonesDomain")> _
        Function GetZonesDomain(ByVal strUser As String, ByVal strPassword As String, ByVal strDomain As String) _
                                  As Object
        <XmlRpcMethod("setZonesDomain")> _
        Function SetZonesDomain(ByVal strUser As String, ByVal strPassword As String, ByVal strDomain As String, ByVal zones As String) _
                                  As Object
    End Interface

    Public Class Tracer
        Inherits XmlRpcLogger
#If DEBUG Then
        Protected Overrides Sub OnRequest(ByVal sender As Object, ByVal e As CookComputing.XmlRpc.XmlRpcRequestEventArgs)
            DumpStream("OnRequest", e.RequestStream)
        End Sub

        Protected Overrides Sub OnResponse(ByVal sender As Object, ByVal e As CookComputing.XmlRpc.XmlRpcResponseEventArgs)
            DumpStream("OnResponse", e.ResponseStream)
        End Sub

        Private Sub DumpStream(ByVal strWhere As String, ByVal stm As IO.Stream)
            stm.Position = 0
            Dim trdr As IO.TextReader = New IO.StreamReader(stm)
            Dim strAll As String = ""
            Dim s As String = trdr.ReadLine()
            While (s <> Nothing)
                strAll &= s & vbCrLf
                Trace.WriteLine(s)
                s = trdr.ReadLine()
            End While
            IO.File.AppendAllText(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\dinaIP-" & strWhere & ".log", Now.ToString & vbCrLf & StrDup(50, "=") & vbCrLf & strAll & StrDup(50, "-") & vbCrLf)
            Console.WriteLine("CONTIDO RECIBIDO DE " & strWhere & vbCrLf & s)
        End Sub
#End If
    End Class
    Public Module XmlRpc
        ''' <summary>
        ''' Función que devolve os dominios que ten contratados o usuario en DinaHosting
        ''' </summary>
        ''' <param name="strUser">Usuario de Dianhosting</param>
        ''' <param name="strPassWord">Password do usuario de Dinahosting</param>
        ''' <returns>Devolve un List cos datos dos dominios: dominio e clave</returns>
        Function DoLogin(ByVal strUser As String, ByVal strPassWord As String, ByVal bIsDomain As Boolean, ByVal bHideMsg As Boolean) As Data.LoginInfo
            'Function GetDomains(ByVal strUser As String, ByVal strPassWord As String) As List(Of Data.InfoDomain)
            Dim ret As Object
            Try
                If Not My.Computer.Network.IsAvailable Then Return Nothing
                Dim proxy As XmlRPCDH = CType(XmlRpcProxyGen.Create(GetType(XmlRPCDH)), XmlRPCDH)
                Dim tracer As Tracer = New Tracer
                tracer.Attach(proxy)
                ret = proxy.DoLogin(strUser, strPassWord, bIsDomain)
                If ret.GetType Is GetType(Boolean) Then
                    Return Nothing
                End If
                Dim lDomains As New List(Of Data.InfoDomain)
                For i As Integer = 0 To ret.Item("domains").Length - 1
                    Dim val As XmlRpcStruct = ret.Item("domains")(i)
                    lDomains.Add(New Data.InfoDomain(val.Item("dominio")))
                Next
                Return New Data.LoginInfo(lDomains, New Data.InfoVersion(ret.Item("version").Item("version"), ret.Item("version").Item("nivel_auth"), ret.Item("version").Item("observaciones"), ret.Item("version").Item("url")))
            Catch exc As Net.WebException
                If Not bHideMsg Then
                    MsgBox("No se ha podido establecer la conexión con dinaHosting." & vbCrLf & _
                            "Compruebe que tiene conexión a internet y vuelva a intentarlo.", MsgBoxStyle.Exclamation)
                End If
                Return Nothing
            Catch ta As Threading.ThreadAbortException
                'cancelouse o thread no que se estaba executando. En pcpo porque cancelou o user
                Return Nothing
            Catch ex As Exception
                Console.WriteLine("No se ha podido obtener la lista de dominios contratados con dinaHosting," & vbCrLf & _
                        "ya que se ha producido el siguiente error: (" & ex.GetType.ToString & ")" & vbCrLf & ex.Message)
                Return Nothing
            End Try
        End Function

        ''' <summary>
        ''' Función que devolve os dominios que ten contratados o usuario en DinaHosting
        ''' </summary>
        ''' <param name="strUser">Usuario de Dianhosting</param>
        ''' <param name="strPassWord">Password do usuario de Dinahosting</param>
        ''' <returns>Devolve un List cos datos dos dominios: dominio e clave</returns>
        Function GetDomains(ByVal strUser As String, ByVal strPassWord As String, ByVal bIsDomain As Boolean, ByVal bHideMsg As Boolean) As List(Of Data.InfoDomain)
            Return DoLogin(strUser, strPassWord, bIsDomain, Not bHideMsg).Domains
        End Function

        ''' <summary>
        ''' Función que devolve as zonas do dominio
        ''' </summary>
        ''' <param name="strDomain">dominio</param>
        ''' <param name="strPassWord">Password do dominio</param>
        ''' <returns>Devolve un List cos datos das zonas: host, type e address</returns>
        Function GetZones(ByVal strDomain As String, ByVal strPassWord As String, ByVal bHideMsg As Boolean) As List(Of Data.InfoZone)
            Try
                If Not My.Computer.Network.IsAvailable Then Return Nothing
                Dim proxy As XmlRPCDH = CType(XmlRpcProxyGen.Create(GetType(XmlRPCDH)), XmlRPCDH)
                Dim tracer As Tracer = New Tracer
                tracer.Attach(proxy)
                Dim ret As Object = proxy.GetZones(strDomain, strPassWord)
                If ret.GetType Is GetType(Boolean) Then
                    Return Nothing
                End If
                Dim lZones As New List(Of Data.InfoZone)
                For i As Integer = 0 To ret.Length - 1
                    Dim val As XmlRpcStruct = ret(i)
                    lZones.Add(New Data.InfoZone(val.Item("host"), val.Item("type"), val.Item("address"), strDomain))
                Next
                Return lZones
            Catch exc As Net.WebException
                If Not bHideMsg Then
                    MsgBox("No se ha podido establecer la conexión con dinaHosting." & vbCrLf & _
                            "Compruebe que tiene conexión a internet y vuelva a intentarlo.", MsgBoxStyle.Exclamation)
                End If
                Return Nothing
            Catch ta As Threading.ThreadAbortException
                'cancelouse o thread no que se estaba executando. En pcpo porque cancelou o user
                Return Nothing
            Catch ex As Exception
                Console.WriteLine("No se ha podido obtener la lista de dominios contratados con dinaHosting," & vbCrLf & _
                        "ya que se ha producido el siguiente error: (" & ex.GetType.ToString & ")" & vbCrLf & ex.Message)
                Return Nothing
            End Try
        End Function

        ''' <summary>
        ''' Función que devolve as zonas do dominio
        ''' </summary>
        ''' <param name="strDomain">dominio</param>
        ''' <param name="strPassWord">Password do dominio</param>
        ''' <returns>Devolve un List cos datos das zonas: host, type e address</returns>
        Function GetZonesDomain(ByVal strUser As String, ByVal strPassWord As String, ByVal strDomain As String, ByVal bHideMsg As Boolean) As Xml.XmlNodeList
           Try
                If Not My.Computer.Network.IsAvailable Then Return Nothing
                Dim proxy As XmlRPCDH = CType(XmlRpcProxyGen.Create(GetType(XmlRPCDH)), XmlRPCDH)
                Dim tracer As Tracer = New Tracer
                tracer.Attach(proxy)
                Dim ret As Object = proxy.GetZonesDomain(strUser, strPassWord, strDomain)
                If ret.GetType Is GetType(Boolean) Then
                    Return Nothing
                End If
                Dim xmldoc As New Xml.XmlDocument
                xmldoc.LoadXml(ret)

                Return xmldoc.GetElementsByTagName("interface-response")
            Catch exc As Net.WebException
                If Not bHideMsg Then
                    MsgBox("No se ha podido establecer la conexión con dinaHosting." & vbCrLf & _
                            "Compruebe que tiene conexión a internet y vuelva a intentarlo.", MsgBoxStyle.Exclamation)
                End If
                Return Nothing
            Catch ta As Threading.ThreadAbortException
                'cancelouse o thread no que se estaba executando. En pcpo porque cancelou o user
                Return Nothing
            Catch ex As Exception
                Console.WriteLine("No se ha podido obtener la lista de dominios contratados con dinaHosting," & vbCrLf & _
                        "ya que se ha producido el siguiente error: (" & ex.GetType.ToString & ")" & vbCrLf & ex.Message)
                Return Nothing
            End Try
        End Function

        ''' <summary>
        ''' Función que establece as zonas do dominio
        ''' </summary>
        ''' <param name="strDomain">dominio</param>
        ''' <param name="strPassWord">Password do dominio</param>
        ''' <returns>Devolve un List cos datos das zonas: host, type e address</returns>
        Function SetZonesDomain(ByVal strUser As String, ByVal strPassWord As String, ByVal strDomain As String, ByVal zones As String, ByVal bHideMsg As Boolean) As Xml.XmlNodeList
            Try
                If Not My.Computer.Network.IsAvailable Then Return Nothing
                Dim proxy As XmlRPCDH = CType(XmlRpcProxyGen.Create(GetType(XmlRPCDH)), XmlRPCDH)
                Dim tracer As Tracer = New Tracer
                tracer.Attach(proxy)
                Dim ret As Object = proxy.SetZonesDomain(strUser, strPassWord, strDomain, zones)
                If ret.GetType Is GetType(Boolean) Then
                    Return Nothing
                End If
                Dim xmldoc As New Xml.XmlDocument
                xmldoc.LoadXml(ret)

                Return xmldoc.GetElementsByTagName("interface-response")
            Catch exc As Net.WebException
                If Not bHideMsg Then
                    MsgBox("No se ha podido establecer la conexión con dinaHosting." & vbCrLf & _
                            "Compruebe que tiene conexión a internet y vuelva a intentarlo.", MsgBoxStyle.Exclamation)
                End If
                Return Nothing
            Catch ta As Threading.ThreadAbortException
                'cancelouse o thread no que se estaba executando. En pcpo porque cancelou o user
                Return Nothing
            Catch ex As Exception
                Console.WriteLine("No se ha podido obtener la lista de dominios contratados con dinaHosting," & vbCrLf & _
                        "ya que se ha producido el siguiente error: (" & ex.GetType.ToString & ")" & vbCrLf & ex.Message)
                Return Nothing
            End Try
        End Function
    End Module
End Namespace