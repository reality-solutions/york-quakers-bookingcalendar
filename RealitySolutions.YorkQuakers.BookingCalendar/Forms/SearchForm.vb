Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports RealitySolutions.YorkQuakers.BookingCalendar.Backend

Public Class SearchForm

    Public Property oSetting As Settings

    Private ReadOnly Property Bookings As DataTable
        Get
            Return CalendarCoordinator.FetchSearchableBookings(AccountLookUpEdit.Text, FromDateEdit.DateTime, ToDateEdit.DateTime, InvNoTextEdit.Text)
        End Get
    End Property


    Private Sub PostInvoicesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        oSetting = CalendarCoordinator.FetchSettings

        FromDateEdit.DateTime = Today
        ToDateEdit.DateTime = Today.AddDays(14)

        AccountLookUpEdit.Properties.DataSource = Sage50Accounts 'Sage50Coordinator.FetchAccounts(oSetting)
    End Sub

    Private Sub DisplaySimpleButton_Click(sender As Object, e As EventArgs) Handles DisplaySimpleButton.Click
        GridControl1.DataSource = Bookings
        GridControl1.ForceInitialize()

        GridView1.Columns(0).Visible = False
        GridView1.Columns(7).Visible = False
        GridView1.Columns(8).Visible = False
        GridView1.Columns(9).Visible = False
    End Sub

    Private Sub AccountLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles AccountLookUpEdit.EditValueChanged
        GridControl1.DataSource = Bookings
        GridControl1.ForceInitialize()

        GridView1.Columns(0).Visible = False
        GridView1.Columns(7).Visible = False
        GridView1.Columns(8).Visible = False
        GridView1.Columns(9).Visible = False
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ' refresh customers
        Try
            Sage50Accounts = Sage50Coordinator.FetchAccounts(oSetting)

            AccountLookUpEdit.Properties.DataSource = Sage50Accounts 'Sage50Coordinator.FetchAccounts(oSetting)
            AccountLookUpEdit.Properties.AllowNullInput = DefaultBoolean.True

        Catch ex As Exception
            ' ignore connection error

        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim gridView As GridView = CType(GridControl1.MainView, GridView)

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx"
        saveFileDialog.Title = "Export to Excel"
        saveFileDialog.ShowDialog()

        If saveFileDialog.FileName <> "" Then
            Dim options As New XlsxExportOptions()
            options.ExportMode = XlsxExportMode.SingleFile

            gridView.ExportToXlsx(saveFileDialog.FileName, options)
            MessageBox.Show("Export successful!", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class

