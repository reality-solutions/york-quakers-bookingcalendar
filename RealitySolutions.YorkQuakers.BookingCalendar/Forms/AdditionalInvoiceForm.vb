Imports System.ComponentModel
Imports DevExpress.XtraScheduler.UI
Imports RealitySolutions.YorkQuakers.BookingCalendar.Backend

Public Class AdditionalInvoiceForm
    Public Property BindingExtras As BindingList(Of BookingExtraPart)
    Public Property Controller As AppointmentFormController
    Public Property oSetting As Settings
    Public Property BookingID As Int64
    Public Property CustomerName As String
    Public Property RoomName As String

    Public Property InvoiceNo As String

    Private Sub AdditionalInvoiceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each entry In BindingExtras
            entry.Qty = 0
        Next

        ExtrasGrid.DataSource = BindingExtras
    End Sub

    Private Sub CancelSimpleButton_Click(sender As Object, e As EventArgs) Handles CancelSimpleButton.Click
        Close()
    End Sub

    Private Sub PostSimpleButton_Click(sender As Object, e As EventArgs) Handles PostSimpleButton.Click
        ProgressPanel1.Visible = True

        Dim oBookingExtras As List(Of BookingExtra) = CalendarCoordinator.FetchExtrasFull()
        Dim lstSelectedExtras As New List(Of BookingExtra)
        Dim boundExtras = DirectCast(ExtrasGrid.DataSource, BindingList(Of BookingExtraPart))

        For Each entry In boundExtras
            If entry.Qty > 0 Then lstSelectedExtras.Add(oBookingExtras(boundExtras.IndexOf(entry)))
        Next


        InvoiceNo = Sage50Coordinator.PostInvoice(oSetting, Controller.EditedAppointmentCopy.CustomFields("BookingRef"), lstSelectedExtras, CustomerName,
                                                                            RoomName, Nothing, "")

        ProgressPanel1.Visible = False

        DialogResult = DialogResult.OK
    End Sub


    Private Sub ExtrasGridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles ExtrasGridView.CellValueChanged
        Dim decTotalCost As Decimal = 0

        ' Extras costs
        For Each entry In DirectCast(ExtrasGrid.DataSource, BindingList(Of BookingExtraPart))
            If entry.Qty >= 1 Then decTotalCost += CalendarCoordinator.FetchExtraCost(entry.Extra, entry.Qty)
        Next

        CostTextEdit.Text = decTotalCost
    End Sub
End Class