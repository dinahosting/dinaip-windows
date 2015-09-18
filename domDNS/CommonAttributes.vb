Imports System.Xml.XPath

''' <summary>
'''Implementa todos los parámetros comunes a cada una de las clases. Todas las demás clases heredan de él.
''' </summary>
Public Class CommonAttributes
    Private Const k_URL = "http://apisms.gestiondecuenta.com/php/comun/ejecutarComando.php"

    Dim uid As String
    Dim pw As String
    Dim strDomain As String
    ReadOnly Property SLD() As String
        Get
            If strDomain = Nothing Then Return ""
            Return Split(strDomain, ".", 2)(0)
        End Get
    End Property
    ReadOnly Property TLD() As String
        Get
            If strDomain = Nothing Then Return ""
            If strDomain.IndexOf(".") <> -1 Then
                Return Split(strDomain, ".", 2)(1)
            Else
                Return ""
            End If
        End Get
    End Property

    Dim strCommand As String
    Dim strCode As String
    Dim strCodeText As String
    Dim iErrCount As Integer
    Dim strErrx As String
    Dim bDone As Boolean

    Friend lErrors As List(Of Integer)
    Friend params As List(Of Data.Parametro)

#Region "Parámetros"
    ''' <summary>Requerido Usuario de Dinahosting (string)</summary>
    Public Property User() As String
        Get
            Return uid
        End Get
        Set(ByVal value As String)
            uid = value
        End Set
    End Property

    ''' <summary>Requerido Clave de Dinahosting(string)</summary>
    Public Property Password() As String
        Get
            Return pw
        End Get
        Set(ByVal value As String)
            pw = value
        End Set
    End Property

    ''' <summary>Requerido Dominio(string)</summary>
    Public Property Domain() As String
        Get
            Return strDomain
        End Get
        Set(ByVal value As String)
            strDomain = value
        End Set
    End Property
#End Region

#Region "Parámetros Devueltos y Valores"
    ''' <summary>Nombre del comando que se ejecuta. string</summary>
    Public Property Command() As String
        Get
            Return strCommand
        End Get
        Set(ByVal value As String)
            strCommand = value
        End Set
    End Property

    ''' <summary>Código que indica la ejecución del comando. string</summary>
    Public Property Code() As String
        Get
            Return strCode
        End Get
        Set(ByVal value As String)
            strCode = value
        End Set
    End Property

    ''' <summary>Texto descriptivo que explica la ejecución del comando. string</summary>
    Public Property CodeText() As String
        Get
            Return strCodeText
        End Get
        Set(ByVal value As String)
            strCodeText = value
        End Set
    End Property

    ''' <summary>El número de errores que han ocurrido. int</summary>
    Public Property ErrCount() As Integer
        Get
            Return iErrCount
        End Get
        Set(ByVal value As Integer)
            iErrCount = value
        End Set
    End Property

    ''' <summary>Si ErrCount>0, en Err(1 a ErrCount) se indican los errores producidos. string</summary>
    Public Property Errx() As String
        Get
            Return strErrx
        End Get
        Set(ByVal value As String)
            strErrx = value
        End Set
    End Property

    ''' <summary>Devuelve las zonas en las que hai errores</summary>
    Public ReadOnly Property Errors() As List(Of Integer)
        Get
            If lErrors Is Nothing Then ErrxTranslated()
            Return lErrors
        End Get
    End Property

    ''' <summary>Devuelve la interpretación de los errores devueltos por la API de php</summary>
    Public Function ErrxTranslated(Optional ByVal bPutEnter As Boolean = True) As String
        lErrors = New List(Of Integer)
        If strErrx = Nothing Then Return Nothing
        Dim strErrs As String() = strErrx.Split(New Char() {vbCr, vbLf})
        Dim str As String = Nothing
        For Each strErr As String In strErrs
            If strErr <> Nothing Then
                Dim strDescr As String = Nothing
                Dim iZoneNumber As Integer = strErr.LastIndexOf("_")
                If IsNumeric(strErr.Substring(iZoneNumber + 1)) Then
                    strDescr = GetStatusDescription(strErr.Substring(0, iZoneNumber + 1))
                    If strDescr <> Nothing Then
                        strDescr = "Zona " & strErr.Substring(iZoneNumber + 1) + 1 & ": " & strDescr
                        lErrors.Add(strErr.Substring(iZoneNumber + 1) + 1)
                    End If
                Else
                    strDescr = GetStatusDescription(strErr)
                End If
                If strDescr = Nothing Then
                    If strErr.StartsWith("ERROR_WRONG_NODEFINIDO_") Then
                        strDescr &= strErr.Replace("ERROR_WRONG_NODEFINIDO_", My.Resources.ErrorsAPI.ERROR_WRONG_NODEFINIDO_)
                    Else
                        strDescr &= strErr
                    End If
                End If
                str &= vbCrLf & strDescr
            End If
        Next
        str = str.Substring(vbCrLf.Length)
        If bPutEnter AndAlso str <> Nothing Then str = vbCrLf & str
        Return str
    End Function

    ''' <summary>
    ''' Devuelve la interpretación de los errores devueltos por la API de php
    ''' </summary>
    ''' <param name="strErr">Err devuelto, p. ej., Errx en calquer sms_... e Status na clase SMS</param>
    Private Function GetStatusDescription(ByVal strErr As String) As String
        If strErr = Nothing Then Return Nothing
        Return My.Resources.ErrorsAPI.ResourceManager.GetString(strErr)
    End Function

    ''' <summary>true Indica que todo se ha realizado correctamente, false lo contrario. enum(‘true’,’false’)</summary>
    Public Property Done() As Boolean
        Get
            Return bDone
        End Get
        Set(ByVal value As Boolean)
            bDone = value
        End Set
    End Property
#End Region

    ''' <summary>
    ''' Carga os valores a partir do XML
    ''' </summary>
    Friend Sub GetCommonValues(ByVal values As Xml.XmlNodeList)
        If values Is Nothing Then Throw New Exception("No se ha obtenido una respuesta válida del servidor. " & vbCrLf & "Inténtalo de nuevo y si el problema continúa ponte en contacto con soporte técnico.")
        Me.Command = GetNodeInList("Command", values)
        Me.Code = GetNodeInList("Code", values)
        Me.CodeText = GetNodeInList("CodeText", values)
        Me.ErrCount = GetNodeInList("ErrCount", values)
        Me.Errx = Nothing
        lErrors = Nothing
        For i As Integer = 1 To Me.ErrCount
            Me.Errx &= vbCrLf & GetNodeInList("Err" & i, values)
        Next
        If Me.Errx <> Nothing Then Me.Errx = Me.Errx.Substring(vbCrLf.Length)
        Me.Done = GetNodeInList("Done", values)
    End Sub

    ''' <summary>
    ''' Carga los valores a partir del XPathNavigator
    ''' </summary>
    Friend Sub GetCommonValues(ByVal values As Xml.XPath.XPathNavigator)
        With values
            Me.Command = .SelectSingleNode("Command").Value
            Me.Code = .SelectSingleNode("Code").Value
            Me.CodeText = .SelectSingleNode("CodeText").Value
            Me.ErrCount = .SelectSingleNode("ErrCount").Value
            If Not .SelectSingleNode("errors") Is Nothing Then Me.Errx = .SelectSingleNode("errors").Value
            Me.Done = .SelectSingleNode("Done").Value
        End With
    End Sub

    ''' <summary>
    ''' Inicializa la ejecución
    ''' </summary>
    ''' <remarks>Crea la lista de parámetros y añade los datos del login de la cuenta</remarks>
    Protected Sub InitializeExecute(ByVal strUser As String, ByVal strPass As String, ByVal strDomain As String)
        Me.User = strUser
        Me.Password = strPass
        Me.Domain = strDomain
        params = New List(Of Data.Parametro)
        If strUser = Nothing Then
            params.Add(New Data.Parametro("uid", Me.Domain))
        Else
            params.Add(New Data.Parametro("uid", Me.User))
        End If
        params.Add(New Data.Parametro("pw", Me.Password))
        If strUser <> Nothing Then params.Add(New Data.Parametro("domain", Me.Domain))
        params.Add(New Data.Parametro("sld", Me.SLD))
        params.Add(New Data.Parametro("tld", Me.TLD))
    End Sub

    ''' <summary>Busca un nodo dentro dunha colección</summary>
    Friend Function GetNodeInList(ByVal strBusca As String, ByVal xmlNodos As Xml.XmlNodeList, Optional ByVal bReturnValue As Boolean = True) As Object
        'recorremos os nodos da lista buscando o que nos interesa, e devolvemos o value do mesmo
        Dim oValueAtopado As Object = Nothing
        For Each xmlNodo As Xml.XmlNode In xmlNodos
            Try
                If xmlNodo.Name = strBusca Then
                    If bReturnValue Then
                        oValueAtopado = xmlNodo.InnerText
                    Else
                        oValueAtopado = xmlNodo
                    End If
                ElseIf Not xmlNodo.ChildNodes Is Nothing AndAlso xmlNodo.ChildNodes.Count > 0 Then
                    oValueAtopado = GetNodeInList(strBusca, xmlNodo.ChildNodes, bReturnValue)
                End If
                If Not oValueAtopado Is Nothing Then
                    Return oValueAtopado
                End If
            Catch ex As Exception
                Return Nothing
            End Try
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' Devuelve el XPathNavigator que contiene los datos devueltos tras la ejecución del comando. Al ser un Xpath permitirá el uso de filtros en el contenido
    ''' </summary>
    ''' <param name="strFunctionName">Nombre de la función que se va ejecutar</param>
    ''' <param name="Params">Lista de parámetros que se le envía a la función</param>
    Friend Function GetXMLByGETNavigator(ByVal strFunctionName As String, ByVal Params As List(Of Data.Parametro)) As XPathNavigator
        'montamos as condicións que se lle van a enviar
        Dim strConditions As String = ""
        For Each par As Data.Parametro In Params
            strConditions &= "&" & par.Condition & "=" & par.Value
        Next
        'se non ten condicións sae
        If strConditions = Nothing Then
            Throw New Exception(My.Resources.Messages.Not_params_to_execute_command)
        End If

        Try
            'cargamos o documento XML co comando a executar
            'Console.WriteLine("Empeza a carga do XPath: " & Now.TimeOfDay.ToString)
            Dim xmlXDoc As New XPathDocument(k_URL & "?" & "command=" & strFunctionName & strConditions)
            'Console.WriteLine("Remata a carga do XPath: " & Now.TimeOfDay.ToString)
            'seguindo a estructura do XML, localizamos o <interface-response>, que é onde están todos os nodos que nos interesan
            Return xmlXDoc.CreateNavigator.SelectSingleNode("interface-response")
        Catch xml As Xml.XmlException
            Throw New Exception(My.Resources.Messages.Not_load_good_XML)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Devolve o nodo que contén os datos devoltos tras a execución do comando
    ''' </summary>
    ''' <param name="strFunctionName">Nome da función que se vai executar</param>
    ''' <param name="Params">Lista de parámetros que se lle envía á función</param>
    ''' <remarks>Os datos son enviados por POST</remarks>
    Friend Function GetXMLRequestPOSTMethod(ByVal strFunctionName As String, ByVal Params As List(Of Data.Parametro)) As Xml.XmlNodeList
        'montamos as condicións que se lle van a enviar
        Dim strConditions As String = ""
        For Each par As Data.Parametro In Params
            strConditions &= "&" & par.Condition & "=" & par.Value
        Next
        'se non ten condicións sae
        If strConditions = Nothing Then
            Throw New Exception(My.Resources.Messages.Not_params_to_execute_command)
        End If

        Dim xmlDoc As New MSXML.XMLHTTPRequest
        Try
            xmlDoc.open("POST", k_URL, False)
            xmlDoc.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
            xmlDoc.send("command=" & strFunctionName & strConditions)
            Dim xml As New Xml.XmlDocument
            xml.LoadXml(xmlDoc.responseText)
            'seguindo a estructura do XML, localizamos o <interface-response>, que é onde están todos os nodos que nos interesan
            Dim xmlNodos As Xml.XmlNodeList = xml.GetElementsByTagName("interface-response")

            'se non se atopou o nodo, lanza unha excepción
            If xmlNodos Is Nothing Then
                Throw New Exception(My.Resources.Messages.Not_load_good_XML)
            Else
                Return xmlNodos
            End If
        Catch xml As Xml.XmlException
            Throw New Exception(My.Resources.Messages.Not_load_good_XML)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
