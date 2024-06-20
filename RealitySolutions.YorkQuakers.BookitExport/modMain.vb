Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Module modMain
    Private _log As log4net.ILog = log4net.LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Sub Main()

        Try
            _log.Info("Starting...")

            '' Export to FTP directory for syncing with website
            '_log.Info("Connecting to FTP directory")
            ''Dim oFTPClient As New FTPclient(My.Settings.FTPHostname, My.Settings.FTPUsername, My.Settings.FTPPassword)

            'Dim strExportFileName As String = String.Format("{0}Bookings_{1:ddMMyyyyHmmss}.json", My.Settings.FTPExportDirectory, DateTime.Now)
            'Dim strLocalFile As String = IO.Path.Combine(My.Settings.ExportFolder, "Bookings.json")
            ''Dim fi = New FileInfo(strLocalFile)

            'ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls

            ''_log.InfoFormat("Uploading file {0}", strLocalFile)
            ''_log.InfoFormat("Uploading file {0}", strExportFileName)
            ''oFTPClient.Upload(fi, strExportFileName)
            '_log.InfoFormat(My.Settings.FTPHostname)
            '_log.InfoFormat(My.Settings.FTPExportDirectory)
            'Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(strExportFileName), System.Net.FtpWebRequest)


            'request.Credentials = New System.Net.NetworkCredential(My.Settings.FTPUsername, My.Settings.FTPPassword)
            'request.Method = System.Net.WebRequestMethods.Ftp.UploadFile
            'request.UsePassive = True
            'request.EnableSsl = False


            'Dim file() As Byte = System.IO.File.ReadAllBytes(strLocalFile)

            'Dim strz As System.IO.Stream = request.GetRequestStream()
            'strz.Write(file, 0, file.Length)
            'strz.Close()
            'strz.Dispose()

            'Exit Sub


            _log.Info("Connecting to SQL")
            Using oSqlConnection As New SqlClient.SqlConnection(My.Settings.BookitSQLConnection)
                oSqlConnection.Open()

                _log.Info("Fetching bookings")
                Dim oDT As New DataTable

                Dim oSqlCommand As New SqlClient.SqlCommand(<![CDATA[
            SELECT        dbo.Bookings.BookingID, dbo.Bookings.StartDate, dbo.Bookings.EndDate, dbo.Bookings.Subject, dbo.Bookings.Location, dbo.Bookings.Description, dbo.Rooms.RoomName, dbo.Bookings.BookingRef, 
                                     dbo.Bookings.AccountName, dbo.Bookings.Notes, dbo.Bookings.AcceptedTC
            FROM            dbo.Bookings INNER JOIN
                                     dbo.Rooms ON dbo.Bookings.RoomID = dbo.Rooms.RoomID
            ]]>.Value, oSqlConnection)

                Using oSQLDA As New SqlClient.SqlDataAdapter(oSqlCommand)
                    oSQLDA.Fill(oDT)
                End Using

                Dim oBookitObject As New With
                    {
                .Booking = oDT
                }

                Dim strJSON As String = JsonConvert.SerializeObject(oBookitObject, Formatting.Indented)
                Dim oJSONFile = New StreamWriter(My.Settings.ExportFolder & "Bookings.json")
                Dim strOutputPath As String = My.Settings.ExportFolder & "Bookings.json"

                _log.Info("Writing to JSON file")
                oJSONFile.Write(strJSON)
                oJSONFile.Flush()

                oJSONFile.Close()

                ' Export to FTP directory for syncing with website
                '_log.Info("Connecting to FTP directory")
                'Dim oFTPClient As New FTPclient(My.Settings.FTPHostname, My.Settings.FTPUsername, My.Settings.FTPPassword)

                'Dim strExportFileName As String = String.Format("{0}/Bookings_{1:ddMMyyyyHmmss}.json", My.Settings.FTPExportDirectory, DateTime.Now)

                '_log.InfoFormat("Uploading file {0}", strExportFileName)
                'oFTPClient.Upload(strOutputPath, strExportFileName)

                oSqlConnection.Close()
            End Using

            _log.Info("Exiting...")
        Catch ex As Exception
            _log.Error(ex)

        End Try
    End Sub

End Module
