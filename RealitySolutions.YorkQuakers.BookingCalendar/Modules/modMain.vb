Module modMain
    Public SageOnline As Boolean
    Public SageCompanyName As String

    Sub Main()
        ' Connect to Sage 50
        Try
            SageCompanyName = "Test Company"
            SageOnline = True

        Catch ex As Exception
            ' Allow but indicate offline
            SageOnline = False
        End Try

        ' Initiate any global variables




    End Sub
End Module
