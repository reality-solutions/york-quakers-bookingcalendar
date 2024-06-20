Imports DevExpress.LookAndFeel

Public Class SplashScreen
    Sub New()
        InitializeComponent()

    End Sub

    Private lookAndFeel As UserLookAndFeel
    Protected Overrides ReadOnly Property TargetLookAndFeel As UserLookAndFeel
        Get
            If lookAndFeel Is Nothing Then
                lookAndFeel = New UserLookAndFeel(Me)
                lookAndFeel.UseDefaultLookAndFeel = False
                lookAndFeel.SkinName = "The Bezier"
            End If
            Return lookAndFeel
        End Get
    End Property
    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)

        Dim command As SplashScreenCommand = CType(cmd, SplashScreenCommand)
        If command = SplashScreenCommand.UpdateText Then
            SplashLabelControl.Text = arg.ToString
        End If
    End Sub

    Public Enum SplashScreenCommand
        UpdateText
    End Enum
End Class
