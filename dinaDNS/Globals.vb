Module Globals

    Public aut As Automatic
    Public actLogin As New Login
    Public k_badColor As Color = Color.FromArgb(237, 202, 202)
    Public SilentMode As Boolean = False

    Class Login
        Public Login As String
        Public PassWord As String
        Public IsDomain As Boolean

        Sub New(ByVal strLogin As String, ByVal strPwd As String, ByVal bIsDomain As Boolean)
            Login = strLogin
            PassWord = strPwd
            IsDomain = bIsDomain
        End Sub

        Sub New()
        End Sub
    End Class
End Module
