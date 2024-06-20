Imports DevExpress.XtraEditors
Imports RealitySolutions.YorkQuakers.BookingCalendar.Backend

Public Class PostInvoicesForm

    Public Property oSetting As Settings

    Private Sub PostInvoicesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        oSetting = CalendarCoordinator.FetchSettings

        FromDateEdit.DateTime = Today
        ToDateEdit.DateTime = Today.AddDays(14)

        AccountLookUpEdit.Properties.DataSource = Sage50Accounts 'Sage50Coordinator.FetchAccounts(oSetting)
    End Sub

    Private Sub DisplaySimpleButton_Click(sender As Object, e As EventArgs) Handles DisplaySimpleButton.Click
        If AccountLookUpEdit.Text = "" Then
            DevExpress.XtraEditors.XtraMessageBox.Show(LookAndFeel, "No account selected.", "Post Invoices", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim oBookings As DataTable = CalendarCoordinator.FetchNonPostedBookings(AccountLookUpEdit.Text, FromDateEdit.DateTime, ToDateEdit.DateTime)

        GridControl1.DataSource = oBookings
        GridControl1.ForceInitialize()
        GridView1.Columns(0).Visible = False
    End Sub



    Private Sub PostSimpleButton_Click(sender As Object, e As EventArgs) Handles PostSimpleButton.Click
        If DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you wish to post invoices for these bookings to S50?", "Post Invoice",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                ProgressPanel1.Visible = True

                Dim lstCombinedRoomCosts As New List(Of RoomCost)
                Dim lstCombinedExtras As New List(Of BookingExtra)

                Dim strBookingRef As String = ""
                Dim strInvEmail As String = ""
                Dim dtStartDate As DateTime = Nothing
                Dim dtEndDate As DateTime = Nothing
                Dim strSage50Code As String = ""

                Dim oRoomCosts As New List(Of CombinedRoomCost)
                Dim oRoomExtras As New List(Of CombinedExtra)



                'For Each bookingRowView As DataRowView In GridView1.DataSource
                For i As Integer = 0 To GridView1.DataRowCount - 1


                    Dim bookingRow As DataRow = GridView1.GetDataRow(i) 'bookingRowView.Row
                    Dim BookingID As Int64 = bookingRow("BookingID") 'Booking.BookingID

                    strInvEmail = bookingRow("InvoicingEmail")
                    strBookingRef = bookingRow("BookingRef")
                    dtStartDate = bookingRow("StartDate")
                    dtEndDate = bookingRow("EndDate")
                    strSage50Code = bookingRow("RoomCode")


                    If BookingID > 0 Then
                        Dim lstRoomCosts As List(Of RoomCost) = CalendarCoordinator.FetchRoomCosts(BookingID, strSage50Code)
                        Dim lstExtras As List(Of BookingExtra) = CalendarCoordinator.PopulateExtras(BookingID)


                        oRoomCosts.Add(New CombinedRoomCost() With {.BookingID = BookingID, .BookingRef = strBookingRef, .StartDate = dtStartDate, .EndDate = dtEndDate, .RoomCosts = lstRoomCosts})
                        oRoomExtras.Add(New CombinedExtra() With {.BookingID = BookingID, .BookingRef = strBookingRef, .StartDate = dtStartDate, .EndDate = dtEndDate, .Extras = lstExtras})

                        lstCombinedRoomCosts.AddRange(lstRoomCosts)
                        lstCombinedExtras.AddRange(lstExtras)
                    End If
                Next

                ' Post/send combined invoice
                'Dim strInvoiceNo As String = Sage50Coordinator.PostInvoice(oSetting, strBookingRef, lstCombinedExtras, AccountLookUpEdit.Text.Split("|")(0),
                '                                                          "", lstCombinedRoomCosts, "")
                Dim strInvoiceNo As String = Sage50Coordinator.PostInvoice(oSetting, strBookingRef, oRoomExtras, AccountLookUpEdit.Text.Split("|")(0),
                                                                          "", oRoomCosts, "")
                If strInvoiceNo = "" Then Throw New Exception("Failed to generate sage 50 invoice.")



                'For Each bookingRowView As DataRowView In GridView1.DataSource
                For i As Integer = 0 To GridView1.DataRowCount - 1


                    Dim bookingRow As DataRow = GridView1.GetDataRow(i) 'bookingRowView.Row     Dim bookingRow As DataRow = bookingRowView.Row
                    Dim BookingID As Int64 = bookingRow("BookingID") 'Booking.BookingID


                    CalendarCoordinator.FlagAsInvoiced(BookingID, strInvoiceNo)
                Next

                Try
                    EmailCoordinator.SendInvoiceEmail(oSetting, strInvEmail, AccountLookUpEdit.Text.Split("|")(1), strInvoiceNo, strBookingRef)

                Catch ex As Exception
                    XtraMessageBox.Show(LookAndFeel, "An error has occurred generating the booking invoices email", "Post Invoices", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try

                XtraMessageBox.Show(LookAndFeel, "Invoices generated successfully.", "Post Invoices", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ProgressPanel1.Visible = False
                DialogResult = DialogResult.OK

                Close()

            Catch ex As Exception
                ProgressPanel1.Visible = False
                XtraMessageBox.Show(LookAndFeel, ex.Message, "Post Invoices", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End Try

            DisplaySimpleButton.PerformClick()
        End If
    End Sub

    Private Sub AccountLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles AccountLookUpEdit.EditValueChanged
        Dim oBookings As DataTable = CalendarCoordinator.FetchNonPostedBookings(AccountLookUpEdit.Text, FromDateEdit.DateTime, ToDateEdit.DateTime)

        GridControl1.DataSource = oBookings
        GridControl1.ForceInitialize()
        GridView1.Columns(0).Visible = False
    End Sub
End Class

