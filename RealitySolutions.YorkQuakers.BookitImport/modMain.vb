Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Module modMain
    Private _log As log4net.ILog = log4net.LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Sub Main()

        Try
            _log.Info("Starting...")

            _log.Info("Fetching pending files")

            Dim oDirectory As New IO.DirectoryInfo(My.Settings.ImportFolder)
            Dim oSucessDirectory As New IO.DirectoryInfo(My.Settings.ImportFolder & "\Success")
            Dim oFailedDirectory As New IO.DirectoryInfo(My.Settings.ImportFolder & "\Failed")

            Dim oFiles = oDirectory.GetFiles("*.json")

            If oFiles.Count = 0 Then
                _log.Info("No files to import")
                GoTo Finish
            Else
                _log.Info("Connecting to SQL")

                Using oSqlConnection As New SqlClient.SqlConnection(My.Settings.BookitSQLConnection)
                    oSqlConnection.Open()

                    For Each oFile In oFiles
                        _log.InfoFormat("Processing file {0}", oFile.FullName)

                        Try
                            ' Get the json file and serialize to booking
                            Dim strJSON As String = File.ReadAllText(oFile.FullName)
                            Dim oBookings As List(Of Booking) = JsonConvert.DeserializeObject(Of List(Of Booking))(strJSON)

                            _log.InfoFormat("Count - {0}", oBookings.Count)

                            For Each oBooking As Booking In oBookings
                                _log.InfoFormat("Processing booking reference {0}", oBooking.reference)

                                Try
                                    For Each oRoom As Room In oBooking.rooms
                                        _log.InfoFormat("Fetching room {0}", oRoom.name)

                                        Dim intRoomID As Int64 = 0
                                        ' Fetch room
                                        Dim oSqlCommand As New SqlClient.SqlCommand(<![CDATA[
SELECT RoomID FROM Rooms WHERE WebRoomName = @Name
]]>.Value, oSqlConnection)
                                        oSqlCommand.Parameters.AddWithValue("@Name", oRoom.name)

                                        intRoomID = CLng(oSqlCommand.ExecuteScalar)

                                        If intRoomID = 0 Then Throw New Exception("Room not found")

                                        ' Save/update booking
                                        _log.Info("Saving booking record")
                                        Dim oSqlCommand1 As New SqlClient.SqlCommand(<![CDATA[
UPDATE Bookings 
SET WebBookingID = @BookingID
WHERE BookingRef = @BookingRef
IF @@ROWCOUNT = 0
    INSERT INTO Bookings (Type,StartDate,EndDate,AllDay,Subject,Location,Description,Status,Label,RoomID,ContactEmail,BookingRef,AccountName,Notes,InvoiceNotes,InvoicingEmail,WebBookingID)
    VALUES (0, @StartDate, @EndDate,0,@Subject, @Location, @Description,2,0,@RoomID, @ContactEmail, @BookingRef, @AccountName,@Notes,@InvoiceNotes,@InvoiceEmail,@BookingID)
]]>.Value, oSqlConnection)
                                        Dim dtBooking As Date = CDate(oBooking.date)
                                        Dim dtStart As Date = CDate(oBooking.start_time)
                                        Dim dtEnd As Date = CDate(oBooking.end_time)

                                        _log.Debug(dtBooking.ToString)
                                        _log.Debug(dtStart.ToString)
                                        _log.Debug(dtEnd.ToString)


                                        With oSqlCommand1
                                            With .Parameters
                                                .AddWithValue("@BookingID", oBooking.id)
                                                .AddWithValue("@StartDate", New Date(dtBooking.Year, dtBooking.Month, dtBooking.Day, dtStart.Hour, dtStart.Minute, dtStart.Second))
                                                .AddWithValue("@EndDate", New Date(dtBooking.Year, dtBooking.Month, dtBooking.Day, dtEnd.Hour, dtEnd.Minute, dtEnd.Second))
                                                .AddWithValue("@Subject", oBooking.notice_text)
                                                .AddWithValue("@Location", oRoom.name)
                                                .AddWithValue("@Description", "")
                                                .AddWithValue("@RoomID", intRoomID)
                                                .AddWithValue("@ContactEmail", oBooking.invoice_email)
                                                .AddWithValue("@BookingRef", oBooking.reference)
                                                .AddWithValue("@AccountName", "")
                                                .AddWithValue("@Notes", "")
                                                .AddWithValue("@InvoiceNotes", "")
                                                .AddWithValue("@InvoiceEmail", oBooking.invoice_email)
                                            End With

                                            .ExecuteNonQuery()
                                        End With

                                        ' Fetch booking 
                                        Dim intBookingID As Int64 = 0
                                        Dim oSqlCommand2a As New SqlClient.SqlCommand(<![CDATA[
SELECT BookingID FROM Bookings WHERE WebBookingID = @BookingID
]]>.Value, oSqlConnection)
                                        oSqlCommand2a.Parameters.AddWithValue("@BookingID", oBooking.id)

                                        intBookingID = CLng(oSqlCommand2a.ExecuteScalar)

                                        If intBookingID = 0 Then Throw New Exception("Extra not found")

                                        '                                        For Each oExtra As Extra In oRoom.extras
                                        '                                            If oExtra.quantity < 0 Then
                                        '                                                _log.Debug("Quantity is < 0 skipping")
                                        '                                                Continue For
                                        '                                            End If

                                        '                                            _log.InfoFormat("Fetching extra {0}", oExtra.name)

                                        '                                            ' Fetch extra
                                        '                                            Dim intExtraID As Int64 = 0
                                        '                                            Dim oSqlCommand2 As New SqlClient.SqlCommand(<![CDATA[
                                        'SELECT ExtraID FROM Extras WHERE WebExtraName = @Name
                                        ']]>.Value, oSqlConnection)
                                        '                                            oSqlCommand2.Parameters.AddWithValue("@Name", oExtra.name)

                                        '                                            intExtraID = CLng(oSqlCommand2.ExecuteScalar)

                                        '                                            If intExtraID = 0 Then Throw New Exception("Extra not found")

                                        '                                            ' Save/update booking extra
                                        '                                            _log.Info("Creating booking extra")
                                        '                                            Dim oSqlCommand3 As New SqlClient.SqlCommand(<![CDATA[
                                        'UPDATE BookingExtras
                                        'SET ExtraID = @ExtraID
                                        'WHERE ExtraID = @ExtraID AND BookingID = @BookingID
                                        'IF @@ROWCOUNT = 0
                                        'INSERT INTO BookingExtras(ExtraID, BookingID, ExtraCount)
                                        'VALUES (@ExtraID, @BookingID, @Count)
                                        ']]>.Value, oSqlConnection)
                                        '                                            With oSqlCommand3
                                        '                                                With .Parameters
                                        '                                                    .AddWithValue("@ExtraID", intExtraID)
                                        '                                                    .AddWithValue("@BookingID", intBookingID)
                                        '                                                    .AddWithValue("@Count", oExtra.quantity)
                                        '                                                End With

                                        '                                                .ExecuteNonQuery()
                                        '                                            End With
                                        '                                        Next

                                        ' Done
                                        _log.InfoFormat("Booking reference {0} successfully imported/updated", oBooking.reference)
                                    Next
                                Catch ex As Exception
                                    _log.Error("Failed to import booking record")
                                    _log.Error(ex.ToString())
                                    Continue For
                                End Try
                            Next

                            _log.Info("Booking file successfully processed, moving file")
                                If IO.File.Exists(oSucessDirectory.FullName & "\" & oFile.Name) Then
                                    IO.File.Delete(oSucessDirectory.FullName & "\" & oFile.Name)
                                End If
                                IO.File.Move(oFile.FullName, oSucessDirectory.FullName & "\" & oFile.Name)
                            ' Next
                        Catch ex As Exception
                            _log.Error("Failed to import booking file")
                            _log.Error(ex.ToString())
                            If IO.File.Exists(oFailedDirectory.FullName & "\" & oFile.Name) Then
                                IO.File.Delete(oFailedDirectory.FullName & "\" & oFile.Name)
                            End If
                            IO.File.Move(oFile.FullName, oFailedDirectory.FullName & "\" & oFile.Name)
                            Continue For
                        End Try
                    Next


                    oSqlConnection.Close()
                End Using
            End If



Finish:
            _log.Info("Exiting...")
        Catch ex As Exception
            _log.Error(ex)

        End Try
    End Sub

End Module


#Region "JSON"

Public Class WebBookings
    Public Property Booking As Booking
End Class

Public Class Booking
    Public Property id As Integer
    Public Property created_at As Date
    Public Property updated_at As Date
    Public Property start_time As String
    Public Property end_time As String
    Public Property [date] As String
    Public Property total_price As String
    Public Property notes As Object
    Public Property user_id As Integer
    Public Property reference As String
    Public Property price As String
    Public Property status As Integer
    Public Property people As Integer
    Public Property booking_type As Integer
    Public Property contact_name As String
    Public Property contact_phone As String
    Public Property invoice_name As String
    Public Property invoice_email As String
    Public Property purpose As String
    Public Property notice_text As String
    Public Property updated_by As Object
    Public Property po_number As Object
    Public Property source_id As String
    Public Property rooms As List(Of Room)
    Public Property user As String
End Class

Public Class Room
    Public Property id As Integer
    Public Property name As String
    Public Property created_at As Date
    Public Property updated_at As Date
    Public Property price As String
    Public Property data As Data
    Public Property summary As String
    Public Property description As String
    Public Property capacity As Integer
    Public Property image As Object
    Public Property parent_id As Integer?
    Public Property hourly_price As String
    Public Property pivot As Pivot
    Public Property extras As List(Of Extra)
End Class

Public Class Data
    Public Property width As String
    Public Property length As String
End Class

Public Class Pivot
    Public Property booking_id As Integer
    Public Property room_id As Integer
    Public Property price As String
End Class

Public Class Extra
    Public Property id As Integer
    Public Property created_at As Date
    Public Property updated_at As Date
    Public Property name As String
    Public Property slug As String
    Public Property description As String
    Public Property price As String
    Public Property per_session As Integer
    Public Property invoiced_price As Integer
    Public Property price_description As String
    Public Property quantity As Integer
    Public Property pivot As Pivot1
End Class

Public Class Pivot1
    Public Property room_id As Integer
    Public Property extra_id As Integer
End Class

#End Region

