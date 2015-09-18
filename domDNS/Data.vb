Public Class Data

    Public Class LoginInfo
        Public Domains As List(Of InfoDomain)
        Public Version As InfoVersion
        Public Sub New(ByVal lDomains As List(Of InfoDomain), ByVal ivVersion As InfoVersion)
            Domains = lDomains
            Version = ivVersion
        End Sub
    End Class

    ''' <summary>
    ''' Estructura para os dominios contratados en DinaHosting: dominio e password
    ''' </summary>
    Public Class InfoDomain
        Dim strDomain As String

        Property Domain() As String
            Get
                Return strDomain
            End Get
            Set(ByVal value As String)
                strDomain = value
            End Set
        End Property

        Public Sub New(ByVal strDom As String)
            Domain = strDom
        End Sub

        Public Overrides Function ToString() As String
            Return Domain
        End Function
    End Class

    Public Enum TypeHost
        unknown
        A
        AAAA
        URL
        FRAME
        CNAME
        SPF
        MX
        MXS
        MXD1
        MXD2
        SRV
        R301
        TXT
    End Enum

    ''' <summary>
    ''' Estructura para as zonas dos dominios: host, type e address
    ''' </summary>
    Public Class InfoZone
        Dim strHt As String
        Dim eTe As TypeHost
        Dim strAs As String
        Dim strOriginalType As String

        Property Host() As String
            Get
                Return strHt
            End Get
            Set(ByVal value As String)
                strHt = value
            End Set
        End Property

        Property Type() As TypeHost
            Get
                Return eTe
            End Get
            Set(ByVal value As TypeHost)
                eTe = value
            End Set
        End Property

        ReadOnly Property OriginalType() As String
            Get
                Return strOriginalType
            End Get
        End Property

        ReadOnly Property TypeToString() As String
            Get
                Select Case eTe
                    Case TypeHost.A
                        Return "A"
                    Case TypeHost.AAAA
                        Return "AAAA"
                    Case TypeHost.URL
                        Return "URL"
                    Case TypeHost.FRAME
                        Return "FRAME"
                    Case TypeHost.CNAME
                        Return "CNAME"
                    Case TypeHost.SPF
                        Return "SPF"
                    Case TypeHost.MX
                        Return "MX"
                    Case TypeHost.MXS
                        Return "MXS"
                    Case TypeHost.MXD1
                        Return "MXD1"
                    Case TypeHost.MXD2
                        Return "MXD2"
                    Case TypeHost.R301
                        Return "R301"
                    Case TypeHost.SPF
                        Return "SPF"
                    Case TypeHost.SRV
                        Return "SRV"
                    Case TypeHost.TXT
                        Return "TXT"
                    Case Else
                        Return "unknown"
                End Select
            End Get
        End Property

        ReadOnly Property TypeToAPI() As String
            Get
                Select Case eTe
                    Case TypeHost.A
                        Return "A"
                    Case TypeHost.AAAA
                        Return "AAAA"
                    Case TypeHost.URL
                        Return "URL"
                    Case TypeHost.FRAME
                        Return "FRAME"
                    Case TypeHost.CNAME
                        Return "CNAME"
                    Case TypeHost.SPF
                        Return "spf"
                    Case TypeHost.MX
                        Return "MX"
                    Case TypeHost.MXS
                        Return "MXS"
                    Case TypeHost.MXD1
                        Return "MXD1"
                    Case TypeHost.MXD2
                        Return "MXD2"
                    Case TypeHost.R301
                        Return "URL_301"
                    Case TypeHost.SPF
                        Return "SPF"
                    Case TypeHost.SRV
                        Return "SRV"
                    Case TypeHost.TXT
                        Return "TXT"
                    Case Else
                        Return strOriginalType ' TypeHost.unknown
                End Select
            End Get
        End Property

        Property Address() As String
            Get
                Select Case Me.Type
                    Case Data.TypeHost.FRAME, Data.TypeHost.URL
                        If Not strAs.StartsWith("http://") And Not strAs.StartsWith("https://") And Not strAs.StartsWith("ftp://") Then strAs = "http://" & strAs
                    Case Else
                        'en principio non fai modificación nin comprobación algunha
                End Select
                Return strAs
            End Get
            Set(ByVal value As String)
                Select Case Me.Type
                    Case Data.TypeHost.FRAME, Data.TypeHost.URL
                        If Not value.StartsWith("http://") And Not value.StartsWith("https://") And Not value.StartsWith("ftp://") Then value = "http://" & value
                    Case Else
                        'en principio non fai modificación nin comprobación algunha
                End Select
                strAs = value
            End Set
        End Property

        Public Sub New(ByVal strHost As String, ByVal strType As String, ByVal strAddress As String, ByVal strUser As String)
            Host = strHost
            strOriginalType = strType
            Select Case strType
                Case "A"
                    Type = TypeHost.A
                Case "AAAA"
                    Type = TypeHost.AAAA
                Case "redi", "URL"
                    Type = TypeHost.URL
                Case "fram", "FRAME"
                    Type = TypeHost.FRAME
                Case "cnam", "CNAME"
                    Type = TypeHost.CNAME
                Case "spf"
                    Type = TypeHost.SPF
                Case "MX"
                    Type = TypeHost.MX
                Case "MXS"
                    Type = TypeHost.MXS
                Case "MXD1"
                    Type = TypeHost.MXD1
                Case "MXD2"
                    Type = TypeHost.MXD2
                Case "r301"
                    Type = TypeHost.R301
                Case "SPF"
                    Type = TypeHost.SPF
                Case "SRV"
                    Type = TypeHost.SRV
                Case "TXT"
                    Type = TypeHost.TXT
                Case Else
                    Type = TypeHost.unknown
                    If strType <> Nothing Then
                        Try
                            Dim conSMTP As New System.Net.Mail.SmtpClient("mail.dinahosting.com", 25)
                            conSMTP.Send("dinaIP <dinaIP@dinahosting.com>", "jpenin@dinahosting.com", "Reporte de dinaIP", String.Format("User: {0} ==> NOT GOOD IMPLEMENTATION ABOUT TYPE ZONES {1}{2} --- {3} --- {4}{5}", strUser, "{", strType, strHost, strAddress, "}"))
                        Catch ex As Exception
                            Throw New Exception("NOT GOOD IMPLEMENTATION ABOUT TYPE ZONES {" & strType & "}")
                        End Try
                    End If
            End Select
            Select Case Type
                Case Data.TypeHost.SPF, Data.TypeHost.TXT
                    Address = System.Web.HttpUtility.UrlDecode(System.Web.HttpUtility.UrlDecode(strAddress))
                Case Else
                    Address = strAddress
            End Select
        End Sub

        Public Overrides Function ToString() As String
            Return Host & " (" & TypeToString() & ") --> " & Address
        End Function
    End Class

    ''' <summary>
    ''' Implementa la información necesaria de cada uno de los datos que se necesitan
    ''' para enviar/recibir a información
    ''' </summary>
    Friend Class Parametro
        Dim strCondition As String
        Dim oValue As Object

        ''' <summary>
        ''' Crea un nuevo parámetro a partir del nombre y el valor dados
        ''' </summary>
        Public Sub New(ByVal strConditionValue As String, ByVal oNewValue As Object)
            strCondition = strConditionValue
            oValue = oNewValue
        End Sub

        ''' <summary>
        ''' Nombre del parámetro
        ''' </summary>
        Public Property Condition() As String
            Get
                Return strCondition
            End Get
            Set(ByVal value As String)
                strCondition = value
            End Set
        End Property

        ''' <summary>
        ''' Valor que toma el parámetro
        ''' </summary>
        Public Property Value() As Object
            Get
                Return oValue
            End Get
            Set(ByVal value As Object)
                If value <> Nothing AndAlso value.GetType Is GetType(String) Then
                    oValue = CStr(value)
                Else
                    oValue = value
                End If
                Debug.WriteLine(strCondition & ":" & vbTab & oValue)
            End Set
        End Property
    End Class

    Public Enum eTypeVersion
        Required
        Must
        OptionalUpdate
    End Enum

    Public Class InfoVersion
        Public Version As String
        Public Type As eTypeVersion
        Public Notes As String
        Public URL As String
        Public Sub New(ByVal strVersion As String, ByVal strType As String, ByVal strNotes As String, ByVal strURL As String)
            Version = strVersion
            Select Case strType.ToLower
                Case "required"
                    Type = eTypeVersion.Required
                Case "must"
                    Type = eTypeVersion.Must
                Case "optional"
                    Type = eTypeVersion.OptionalUpdate
                Case Else
                    Throw New Exception("NOT IMPLEMENTED VERSION'S TYPE")
            End Select
            Notes = strNotes
            URL = strURL
        End Sub
    End Class
End Class
