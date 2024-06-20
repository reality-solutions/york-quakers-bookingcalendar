Imports RealitySolutions.YorkQuakers.BookingCalendar.Backend

Public Class SettingsForm
    Private Property oSettings As Settings

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'BookitCalendarDataSet.Extras' table. You can move, or remove it, as needed.
        Me.ExtrasTableAdapter.Fill(Me.BookitCalendarDataSet.Extras)
        'TODO: This line of code loads data into the 'BookitCalendarDataSet.Rooms' table. You can move, or remove it, as needed.
        Me.RoomsTableAdapter.Fill(Me.BookitCalendarDataSet.Rooms)
        ' Bind Settings
        oSettings = CalendarCoordinator.FetchSettings()

        If oSettings Is Nothing Then oSettings = New Settings

        SMTPServerTextEdit.DataBindings.Add("Text", oSettings, "SMTPServer")
        SMTPPortTextEdit.DataBindings.Add("Text", oSettings, "SMTPPort")
        SMTPUsernameTextEdit.DataBindings.Add("Text", oSettings, "SMTPUsername")
        SMTPPasswordTextEdit.DataBindings.Add("Text", oSettings, "SMTPPassword")
        SMTPFromTextEdit.DataBindings.Add("Text", oSettings, "FromAddress")
        SMTPCCTextEdit.DataBindings.Add("Text", oSettings, "CCAddress")
        SMTPBCCTextEdit.DataBindings.Add("Text", oSettings, "BCCAddress")
        S50PathTextEdit.DataBindings.Add("Text", oSettings, "Sage50Datapath")
        S50DSNTextEdit.DataBindings.Add("Text", oSettings, "Sage50DSN")
        S50WorkspaceTextEdit.DataBindings.Add("Text", oSettings, "Sage50Workspace")
        S50UserTextEdit.DataBindings.Add("Text", oSettings, "Sage50Username")
        S50PasswordTextEdit.DataBindings.Add("Text", oSettings, "Sage50Password")
        InvoiceTextEdit.DataBindings.Add("Text", oSettings, "InvoicePath")

        RecurrenceCheckEdit.DataBindings.Add("Checked", oSettings, "RecurrenceEnabled")
        RemindersCheckEdit.DataBindings.Add("Checked", oSettings, "RemindersEnabled")
        FromTimeEdit.DataBindings.Add("Time", oSettings, "FromTime")
        ToTimeEdit.DataBindings.Add("Time", oSettings, "ToTime")
    End Sub

    Private Sub SettingsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Save Settings
        Try
            RoomsTableAdapter.Update(BookitCalendarDataSet)
            ExtrasTableAdapter.Update(BookitCalendarDataSet)

            oSettings.FromTime = FromTimeEdit.Text
            oSettings.ToTime = ToTimeEdit.Text

            CalendarCoordinator.InsertUpdateSettings(oSettings)

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(LookAndFeel, ex.Message, "Save Settings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
    End Sub
End Class