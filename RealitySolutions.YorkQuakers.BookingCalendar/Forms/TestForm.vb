Imports DevExpress.XtraEditors
Imports RealitySolutions.YorkQuakers.BookingCalendar.Backend

Public Class TestForm

    Public Property oSetting As Settings

    Private Sub PostInvoicesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        oSetting = CalendarCoordinator.FetchSettings

        FromDateEdit.DateTime = Today.AddDays(-28)
        ToDateEdit.DateTime = Today.AddDays(14)

        DisplaySimpleButton.PerformClick()
    End Sub

    Private Sub DisplaySimpleButton_Click(sender As Object, e As EventArgs) Handles DisplaySimpleButton.Click
        Dim oBookings As DataTable = CalendarCoordinator.FetchProvisionalBookings(FromDateEdit.DateTime, ToDateEdit.DateTime)

        GridControl1.DataSource = oBookings
        GridControl1.ForceInitialize()
        GridView1.Columns(0).Visible = False
        GridView1.Columns("BookingType").Visible = False
        GridView1.Columns("RoomCode").Visible = False
        GridView1.Columns("RoomQty").Visible = False
        GridView1.Columns("RoomPrice").Visible = False
        GridView1.Columns("Notes").Visible = False
        GridView1.Columns("AccountName").Visible = False
        GridView1.Columns("ContactEmail").Visible = False
        GridView1.Columns("InvoiceNo").Visible = False
        GridView1.Columns("InvoiceGenerated").Visible = False
        GridView1.Columns("InvoicingEmail").Visible = False
    End Sub

End Class