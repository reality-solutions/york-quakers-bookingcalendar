Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Drawing
Imports DevExpress.XtraSplashScreen
Imports RealitySolutions.YorkQuakers.BookingCalendar.Backend
Imports DevExpress.XtraScheduler.Internal.Implementations

Public Class CalendarForm
    Private Property oSettings As Settings

    Sub New()
        SplashScreenManager.ShowForm(GetType(SplashScreen))
        SplashScreenManager.Default.SendCommand(SplashScreen.SplashScreenCommand.UpdateText, "Initialising UI...")

        InitSkins()
        InitializeComponent()

        Try
            SplashScreenManager.Default.SendCommand(SplashScreen.SplashScreenCommand.UpdateText, "Populating Rooms...")
            Me.RoomsTableAdapter.Fill(Me.BookitCalendarDataSet.Rooms)
            SplashScreenManager.Default.SendCommand(SplashScreen.SplashScreenCommand.UpdateText, "Populating Bookings...")
            Me.BookingsTableAdapter.ClearBeforeFill = True
            Me.BookingsTableAdapter.Fill(Me.BookitCalendarDataSet.Bookings)

            SplashScreenManager.Default.SendCommand(SplashScreen.SplashScreenCommand.UpdateText, "Fetching Settings...")
            oSettings = CalendarCoordinator.FetchSettings

            SplashScreenManager.Default.SendCommand(SplashScreen.SplashScreenCommand.UpdateText, "Connecting to Sage 50...")
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(LookAndFeel, ex.Message, "Connect to Database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Dim bConnected As Boolean = False

        Try

            Sage50Coordinator.ConnectSage50(oSettings)
            bConnected = True
        Catch ex As Exception
            '  DevExpress.XtraEditors.XtraMessageBox.Show(LookAndFeel, ex.Message, "Connect to Sage 50", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Try
            If bConnected = False Then Sage50Coordinator.ConnectSage50(oSettings, 1) : bConnected = True

        Catch ex As Exception
            'DevExpress.XtraEditors.XtraMessageBox.Show(LookAndFeel, ex.Message, "Connect to Sage 50", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Try
            If bConnected = False Then Sage50Coordinator.ConnectSage50(oSettings, 2) : bConnected = True

        Catch ex As Exception
            ' DevExpress.XtraEditors.XtraMessageBox.Show(LookAndFeel, ex.Message, "Connect to Sage 50", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Try
            If bConnected = False Then Sage50Coordinator.ConnectSage50(oSettings, 3) : bConnected = True

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(LookAndFeel, ex.Message, "Connect to Sage 50", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Try
            SplashScreenManager.Default.SendCommand(SplashScreen.SplashScreenCommand.UpdateText, "Fetching Accounts...")

            Sage50Accounts = Sage50Coordinator.FetchAccounts(oSettings)
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(LookAndFeel, ex.Message, "Connect to Sage 50", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        SplashScreenManager.Default.SendCommand(SplashScreen.SplashScreenCommand.UpdateText, "Configuring...")
        SchedulerControl.Start = DateTime.Now
        SchedulerControl.ActiveViewType = SchedulerViewType.Day
        SchedulerControl.GroupType = SchedulerGroupType.Resource

        If oSettings IsNot Nothing Then
            SchedulerStorage.EnableReminders = oSettings.RemindersEnabled
            SchedulerControl.OptionsCustomization.AllowAppointmentCreate = If(oSettings.RecurrenceEnabled, UsedAppointmentType.All, UsedAppointmentType.NonRecurring)
            SchedulerControl.DayView.WorkTime = New TimeOfDayInterval(TimeSpan.Parse(oSettings.FromTime), TimeSpan.Parse(oSettings.ToTime))
            SchedulerControl.FullWeekView.WorkTime = New TimeOfDayInterval(TimeSpan.Parse(oSettings.FromTime), TimeSpan.Parse(oSettings.ToTime))
            SchedulerControl.WorkWeekView.WorkTime = New TimeOfDayInterval(TimeSpan.Parse(oSettings.FromTime), TimeSpan.Parse(oSettings.ToTime))
            SchedulerControl.DayView.VisibleTime = New TimeOfDayInterval(TimeSpan.Parse(oSettings.FromTime), TimeSpan.Parse(oSettings.ToTime))
            SchedulerControl.FullWeekView.VisibleTime = New TimeOfDayInterval(TimeSpan.Parse(oSettings.FromTime), TimeSpan.Parse(oSettings.ToTime))
            SchedulerControl.WorkWeekView.VisibleTime = New TimeOfDayInterval(TimeSpan.Parse(oSettings.FromTime), TimeSpan.Parse(oSettings.ToTime))

            siSage50.Caption = oSettings.Sage50DSN
        End If

        SplashScreenManager.Default.SendCommand(SplashScreen.SplashScreenCommand.UpdateText, "Finalising UI...")
        siInfo.Caption = "Connected to BookitCalendar"
    End Sub

    Sub InitSkins()
        SkinManager.EnableFormSkins()
        BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle(My.Settings.ApplicationSkinName, My.Settings.ApplicationPalletteName)
    End Sub

    Private Sub PlannerSchedulerForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Application.DoEvents()
        Me.Opacity = 100
        SplashScreenManager.CloseForm()

        Using frmProvisonalBookings As New ProvisionalBookingsForm
            frmProvisonalBookings.ShowDialog()
        End Using
    End Sub

    'Private Sub SchedulerControl1_AppointmentViewInfoCustomizing(ByVal sender As Object, ByVal e As AppointmentViewInfoCustomizingEventArgs)
    '    e.ViewInfo.ToolTipText = "Test" ' String.Format("Started at {0:g}", e.ViewInfo.Appointment.Start)
    '    e.ViewInfo.
    'End Sub

    Private Sub SchedulerControl_AppointmentViewInfoCustomizing(ByVal sender As Object, ByVal e As AppointmentViewInfoCustomizingEventArgs) Handles SchedulerControl.AppointmentViewInfoCustomizing
        ' Colour appointments to match resource colours
        Dim oApt As Appointment = e.ViewInfo.Appointment
        Dim oResource As Resource = SchedulerStorage.Resources.GetResourceById(oApt.ResourceId)
        If oResource IsNot Nothing Then e.ViewInfo.Appearance.BackColor = oResource.GetColor()

        Try
            If String.IsNullOrEmpty(oApt.CustomFields("ContactEmail")) Then
                e.ViewInfo.Appearance.BackColor = Color.Silver
                e.ViewInfo.Appearance.ForeColor = Color.White
            End If
            If oApt.CustomFields("InvoiceGenerated") = True Then
                If oApt.IsRecurring Then
                    If oApt.RecurrenceIndex = 0 Then
                        e.ViewInfo.Appearance.BackColor = Color.DarkGreen
                        e.ViewInfo.Appearance.ForeColor = Color.White
                    End If
                Else
                    e.ViewInfo.Appearance.BackColor = Color.DarkGreen
                    e.ViewInfo.Appearance.ForeColor = Color.White
                End If
            End If
            If oApt.CustomFields("AccountName") IsNot Nothing Then
                If oApt.CustomFields("AccountName").ToString.ToLower.StartsWith("quaker") Then
                    e.ViewInfo.Appearance.BackColor = Color.Silver
                    e.ViewInfo.Appearance.ForeColor = Color.White
                End If
            End If
            If oApt.CustomFields("AcceptedTC") = False Then
                e.ViewInfo.Appearance.BorderColor = Color.Red
            ElseIf oApt.CustomFields("AcceptedTC") = True Then
                e.ViewInfo.Appearance.BorderColor = Color.Black
            End If
            'Hide recurring booking if matching child found 
            If oApt.IsRecurring Then
                If oApt.RecurrenceInfo IsNot Nothing Then
                    ' this is the series one
                    Dim lstToDlete As New List(Of Appointment)
                    Dim apts As AppointmentBaseCollection = SchedulerControl.ActiveView.GetAppointments()
                    For Each apt As Appointment In apts
                        If apt.RecurrenceInfo IsNot Nothing Then
                            Continue For
                        End If
                        If apt.Start = oApt.Start And apt.End = oApt.End And apt.ResourceId = oApt.ResourceId Then
                            e.ViewInfo.Bounds = Rectangle.Empty
                            'e.ViewInfo.Bounds = New Rectangle(e.ViewInfo.Bounds.X, e.ViewInfo.Bounds.Y, 0, 0)
                            ' oApt.StatusKey = 1
                            '  OnFilterAppointment(SchedulerStorage, New PersistentObjectCancelEventArgs(oApt))
                            ' SchedulerStorage.Appointments.Filter = "[StatusKey] = 2"
                            ' SchedulerControl.DayView.LayoutChanged()
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Public Sub OnFilterAppointment(sender As Object, e As PersistentObjectCancelEventArgs) _
    'Handles SchedulerStorage.FilterAppointment
    '    ' Filter all tentative appointments.

    '    e.Cancel = CType(e.Object, Appointment).StatusKey = 1
    'End Sub
    Dim bDragDrop As Boolean = False
    Dim droppedSourceObject As Appointment = Nothing
    Private Sub schedulerControl1_AppointmentDrop(ByVal sender As Object, ByVal e As AppointmentDragEventArgs) Handles SchedulerControl.AppointmentDrop
        droppedSourceObject = e.SourceAppointment '.GetSourceObject(SchedulerStorage)

        bDragDrop = True
    End Sub

    Private Sub SchedulerStorage_AppointmentChanging(sender As Object, e As PersistentObjectCancelEventArgs) Handles SchedulerStorage.AppointmentChanging

    End Sub

    Private Sub SchedulerStorage_AppointmentDeleting(sender As Object, e As PersistentObjectCancelEventArgs) Handles SchedulerStorage.AppointmentDeleting
        ' Handle booking deleting event
        Dim intBookingID As Int64 = e.Object.Id
        Dim bRecurring As Boolean = CalendarCoordinator.IsRecurringBooking(e.Object.Id)
        Dim oAppointmentItem = TryCast(e.Object, AppointmentItem)

        If DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you wish to delete this booking?", "Delete Booking",
                                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Try
                If bRecurring Then
                    Dim result = DevExpress.XtraEditors.XtraMessageBox.Show("This is a recurring booking, do you wish to remove just the selected occurrences(Yes) or the entire series of occurrences (No)?", "Delete Booking",
                                                      MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                    If result = DialogResult.Yes Then
                        CalendarCoordinator.DeleteBooking(intBookingID)
                    ElseIf result = DialogResult.No Then
                        CalendarCoordinator.DeleteBooking(intBookingID, True)
                    ElseIf result = DialogResult.Cancel Then

                        e.Cancel = True
                    End If
                Else
                    CalendarCoordinator.DeleteBooking(intBookingID)
                End If


                'If oAppointmentItem.IsRecurring And oAppointmentItem.IsBase Then
                '    ' Delete whole series
                '    If DevExpress.XtraEditors.XtraMessageBox.Show("This is a recurrence booking base, deleting this will remove the whole series, continue?", "Delete Series",
                '                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '        CalendarCoordinator.DeleteBooking(intBookingID)
                '    End If
                'ElseIf oAppointmentItem.IsOccurrence Then
                '    If DevExpress.XtraEditors.XtraMessageBox.Show("This is a recurrence booking, deleting this will remove the current recurrence entry, continue?", "Delete Recurrence",
                '                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                '        CalendarCoordinator.UpdateRecurrenceInfo(intBookingID, oAppointmentItem.RecurrenceInfo.ToXml)
                '    End If
                'Else
                '    CalendarCoordinator.DeleteBooking(intBookingID)
                'End If

            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(LookAndFeel, ex.Message, "Delete Booking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End Try
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub SchedulerStorage_AppointmentInserting(sender As Object, e As PersistentObjectCancelEventArgs) Handles SchedulerStorage.AppointmentInserting
        ' Handle booking inserting event

    End Sub

    Private Sub SchedulerStorage_AppointmentsInserted(sender As Object, e As PersistentObjectsEventArgs) Handles SchedulerStorage.AppointmentsInserted
        Dim oApt = DirectCast(e.Objects(0), Appointment)
        'If bDragDrop Then
        '    Dim droppedNewObject = oApt
        '    Dim dicCosts As List(Of RoomCost) = CalendarCoordinator.FetchRoomCosts(droppedSourceObject.Id)
        '    bDragDrop = False
        'End If

        If oApt.Type = AppointmentType.DeletedOccurrence Then
            ' BookingsTableAdapter.Update(BookitCalendarDataSet)            
        ElseIf oApt.Type = AppointmentType.ChangedOccurrence Then
            'BookingsTableAdapter.Update(BookitCalendarDataSet)
        End If
    End Sub

    Private Sub SchedulerStorage_AppointmentsDeleted(sender As Object, e As PersistentObjectsEventArgs) Handles SchedulerStorage.AppointmentsDeleted
        '  BookingsTableAdapter.Update(BookitCalendarDataSet)
    End Sub

    Private Sub schedulerControl_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles SchedulerControl.PopupMenuShowing
        ' Modify scheduler context menu
        Dim info = SchedulerControl.ActiveView.ViewInfo.CalcHitInfo(SchedulerControl.PointToClient(Form.MousePosition), True)

        Dim copyMenu As New DevExpress.Utils.Menu.DXMenuItem
        With copyMenu
            .Caption = "Copy"

            AddHandler .Click, AddressOf CopyMenuClick
        End With

        Dim pasteMenu As New DevExpress.Utils.Menu.DXMenuItem
        With pasteMenu
            .Caption = "Paste"

            AddHandler .Click, AddressOf PasteMenuClick
        End With

        Dim cancelMenu As New DevExpress.Utils.Menu.DXMenuItem
        With cancelMenu
            .Caption = "Cancel"

            AddHandler .Click, AddressOf CancelMenuClick
        End With

        If info.HitTest = SchedulerHitTest.ResourceHeader = True Then

        Else
            If e.Menu.Id = SchedulerMenuItemId.DefaultMenu Then
                e.Menu.Items(0).Caption = "New Booking"
                e.Menu.Items(2).Caption = "New Recurring Booking"
                e.Menu.Items.Add(pasteMenu)
            ElseIf e.Menu.Id = SchedulerMenuItemId.AppointmentMenu Then

                e.Menu.Items(3).Visible = False
                e.Menu.Items(4).Visible = False
                e.Menu.Items(5).Visible = False
                e.Menu.Items.Add(cancelMenu)
                e.Menu.Items.Add(copyMenu)
            End If
        End If

    End Sub

    Private Sub CancelMenuClick(sender As Object, e As EventArgs)
        Dim oSelectedAppointment = SchedulerControl.SelectedAppointments(0)

        If oSelectedAppointment IsNot Nothing Then
            If oSelectedAppointment.CustomFields("Cancelled") = True Then
                oSelectedAppointment.CustomFields("Cancelled") = False

                CalendarCoordinator.CancelBooking(oSelectedAppointment.Id, False)

            Else
                oSelectedAppointment.CustomFields("Cancelled") = True

                CalendarCoordinator.CancelBooking(oSelectedAppointment.Id, True)

            End If
        End If
    End Sub

    Private Sub PasteMenuClick(sender As Object, e As EventArgs)
        If oCopiedAppointment IsNot Nothing Then
            ' update the start date and resource
            oCopiedAppointment.Start = SchedulerControl.SelectedInterval.Start
            oCopiedAppointment.End = oCopiedAppointment.Start + oCopiedAppointment.Duration
            oCopiedAppointment.ResourceId = SchedulerControl.SelectedResource.Id

            SchedulerControl.DataStorage.Appointments.Add(oCopiedAppointment)

            SchedulerStorage.RefreshData()
            SchedulerControl.RefreshData()

            ' popup on screen
            SchedulerControl.ShowEditAppointmentForm(oCopiedAppointment)

            oCopiedAppointment = Nothing
        End If
    End Sub

    Private oCopiedAppointment As Appointment = Nothing

    Private Sub CopyMenuClick(sender As Object, e As EventArgs)
        Dim oSelectedAppointment = SchedulerControl.SelectedAppointments(0)

        If oSelectedAppointment IsNot Nothing Then
            oCopiedAppointment = oSelectedAppointment.Copy()
        End If
    End Sub

    Private Sub SchedulerControl_EditAppointmentFormShowing(sender As Object, e As AppointmentFormEventArgs) Handles SchedulerControl.EditAppointmentFormShowing
        'Dim selection As TimeInterval = SchedulerControl.SelectedInterval
        'Dim apts As AppointmentBaseCollection = SchedulerControl.ActiveView.GetAppointments()

        'For Each apt As Appointment In apts
        '    Dim aptInterval As TimeInterval = New TimeInterval(apt.Start, apt.[End])

        '    If e.Appointment.Id <= 0 Then
        '        If aptInterval.IntersectsWith(selection) And apt.ResourceId = e.Appointment.ResourceId And apt.IsRecurring = False Then
        '            DevExpress.XtraEditors.XtraMessageBox.Show(LookAndFeel, "This booking conflicts with another previously scheduled booking", "Create Booking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        '            e.Handled = True
        '            Exit Sub
        '        End If
        '    End If
        'Next

        Dim intBookingID As Long = 0
        If e.Appointment.IsRecurring Then
            If e.Appointment.IsOccurrence Then
                intBookingID = e.Appointment.Id 'e.Appointment.RecurrencePattern.Id ' this is an occurence/ single recurrence booking
            Else
                intBookingID = e.Appointment.Id ' this is the parent recurrence booking
            End If
        Else
            intBookingID = e.Appointment.Id
        End If

        ' Show custom appointment form for bookings
        Dim scheduler As SchedulerControl = CType(sender, SchedulerControl)
        Dim oForm As CustomBookingForm = New CustomBookingForm(scheduler, e.Appointment, e.OpenRecurrenceForm)
        oForm.oSetting = oSettings
        oForm.SourceAppointment = e.Appointment
        oForm.BookingID = intBookingID ' If(e.Appointment.IsRecurring, If(e.Appointment.IsOccurrence, e.Appointment.RecurrencePattern.Id, e.Appointment.Id), e.Appointment.Id)
        oForm.oStorage = SchedulerStorage

        Try
            If oForm.ShowDialog = DialogResult.OK Then
                'BookingsTableAdapter.Update(BookitCalendarDataSet)
                BookitCalendarDataSet.AcceptChanges()

                RefreshBarButtonItem.PerformClick()

                'SchedulerStorage.RefreshData()
                'SchedulerControl.RefreshData()
            End If

            e.Handled = True
        Finally
            oForm.Dispose()
        End Try
    End Sub

    Private Sub CalendarForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Save skin settings
        My.Settings.ApplicationSkinName = UserLookAndFeel.Default.SkinName
        My.Settings.ApplicationPalletteName = UserLookAndFeel.Default.ActiveSvgPaletteName
        My.Settings.Save()

        Sage50Coordinator.DisconnectSage50(oSettings)
    End Sub

    Private Sub SettingsBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SettingsBarButtonItem.ItemClick
        Using frmSettings As New SettingsForm
            frmSettings.ShowDialog()
        End Using

        RefreshSettings()
    End Sub

    Private Sub RefreshSettings()
        oSettings = CalendarCoordinator.FetchSettings

        If oSettings IsNot Nothing Then
            SchedulerStorage.EnableReminders = oSettings.RemindersEnabled
            SchedulerControl.OptionsCustomization.AllowAppointmentCreate = If(oSettings.RecurrenceEnabled, UsedAppointmentType.All, UsedAppointmentType.NonRecurring)
            SchedulerControl.FullWeekView.WorkTime = New TimeOfDayInterval(TimeSpan.Parse(oSettings.FromTime), TimeSpan.Parse(oSettings.ToTime))
            SchedulerControl.WorkWeekView.WorkTime = New TimeOfDayInterval(TimeSpan.Parse(oSettings.FromTime), TimeSpan.Parse(oSettings.ToTime))
            SchedulerControl.FullWeekView.VisibleTime = New TimeOfDayInterval(TimeSpan.Parse(oSettings.FromTime), TimeSpan.Parse(oSettings.ToTime))
            SchedulerControl.WorkWeekView.VisibleTime = New TimeOfDayInterval(TimeSpan.Parse(oSettings.FromTime), TimeSpan.Parse(oSettings.ToTime))
        End If
    End Sub

    Private Sub SchedulerControl_CustomDrawAppointment(sender As Object, e As CustomDrawObjectEventArgs) Handles SchedulerControl.CustomDrawAppointment
        Dim viewInfo As AppointmentViewInfo = TryCast(e.ObjectInfo, AppointmentViewInfo)

        Dim im As Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bonote_32x32.png")
        Dim im2 As Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_32x32.png")
        Dim im3 As Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/mail/mail_32x32.png")

        Dim imageBounds As New Rectangle(viewInfo.InnerBounds.X - 5, viewInfo.InnerBounds.Y, im.Width, im.Height)
        Dim mainContentBounds As New Rectangle(viewInfo.InnerBounds.X + 30, viewInfo.InnerBounds.Y, viewInfo.InnerBounds.Width, viewInfo.InnerBounds.Height - im.Height - 1)
        Dim borderBounds As New Rectangle(e.Bounds.X, e.Bounds.Y, viewInfo.Bounds.Width, viewInfo.Bounds.Height)

        ' Draw border
        e.Cache.DrawRectangle(New Pen(Color.Black), borderBounds)

        ' Draw image in the appointment.
        If e.Bounds.Width > 50 Then
            If viewInfo.Appointment.CustomFields("InvoiceGenerated") = True Then
                If viewInfo.Appointment.IsRecurring Then
                    If viewInfo.Appointment.RecurrenceIndex = 0 Then
                        e.Cache.Graphics.DrawImage(im, imageBounds)

                    End If
                Else
                    e.Cache.Graphics.DrawImage(im, imageBounds)

                End If

                'e.Cache.DrawString(viewInfo.DisplayText.Trim(), viewInfo.Appearance.Font, viewInfo.Appearance.GetForeBrush(e.Cache), mainContentBounds, StringFormat.GenericDefault)
                'Dim subjSize As SizeF = e.Graphics.MeasureString(viewInfo.DisplayText.Trim(), viewInfo.Appearance.Font, mainContentBounds.Width - 30)
                'Dim lineYposition As Integer = CInt(Fix(subjSize.Height))

                'Dim descriptionLocation As New Rectangle(mainContentBounds.X, mainContentBounds.Y + lineYposition, mainContentBounds.Width - 30, mainContentBounds.Height - lineYposition)

                'If viewInfo.Appointment.Description.Trim() <> "" Then
                '    e.Cache.Graphics.DrawLine(viewInfo.Appearance.GetForePen(e.Cache), descriptionLocation.Location, New Point(descriptionLocation.X + descriptionLocation.Width, descriptionLocation.Y))
                '    e.Cache.DrawString(viewInfo.Appointment.Description.Trim(), viewInfo.Appearance.Font, viewInfo.Appearance.GetForeBrush(e.Cache), descriptionLocation, StringFormat.GenericTypographic)
                'End If

                'e.Handled = True
            ElseIf (viewInfo.Appointment.CustomFields("Cancelled") = True) Then
                e.Cache.Graphics.DrawImage(im2, imageBounds)

                'e.Cache.DrawString(viewInfo.DisplayText.Trim(), viewInfo.Appearance.Font, viewInfo.Appearance.GetForeBrush(e.Cache), mainContentBounds, StringFormat.GenericDefault)
                'Dim subjSize As SizeF = e.Graphics.MeasureString(viewInfo.DisplayText.Trim(), viewInfo.Appearance.Font, mainContentBounds.Width - 30)
                'Dim lineYposition As Integer = CInt(Fix(subjSize.Height))

                'Dim descriptionLocation As New Rectangle(mainContentBounds.X, mainContentBounds.Y + lineYposition, mainContentBounds.Width - 30, mainContentBounds.Height - lineYposition)

                'If viewInfo.Appointment.Description.Trim() <> "" Then
                '    e.Cache.Graphics.DrawLine(viewInfo.Appearance.GetForePen(e.Cache), descriptionLocation.Location, New Point(descriptionLocation.X + descriptionLocation.Width, descriptionLocation.Y))
                '    e.Cache.DrawString(viewInfo.Appointment.Description.Trim(), viewInfo.Appearance.Font, viewInfo.Appearance.GetForeBrush(e.Cache), descriptionLocation, StringFormat.GenericTypographic)
                'End If

                'e.Handled = True
            ElseIf viewInfo.Appointment.CustomFields("EmailGenerated") = True Then
                If viewInfo.Appointment.IsRecurring Then
                    If viewInfo.Appointment.RecurrenceIndex = 0 Then
                        e.Cache.Graphics.DrawImage(im3, imageBounds)
                    End If
                Else
                    e.Cache.Graphics.DrawImage(im3, imageBounds)
                End If


            End If
        End If


    End Sub

    Private Sub ListBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListBarButtonItem.ItemClick
        Using frmListDetails As New PostInvoicesForm
            frmListDetails.ShowDialog()
        End Using

        RefreshBarButtonItem.PerformClick()
    End Sub

    Private Sub RefreshBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RefreshBarButtonItem.ItemClick

        Me.BookingsTableAdapter.Fill(Me.BookitCalendarDataSet.Bookings)

        ' refresh customers
        'Try
        '    Sage50Accounts = Sage50Coordinator.FetchAccounts(oSettings)

        'Catch ex As Exception
        '    ' ignore connection error

        'End Try

        SchedulerStorage.RefreshData()
        SchedulerControl.RefreshData()
    End Sub

    Private Sub SchedulerControl_InitAppointmentDisplayText(sender As Object, e As AppointmentDisplayTextEventArgs) Handles SchedulerControl.InitAppointmentDisplayText
        If e.Appointment.CustomFields("InvoiceGenerated") = True Then
            e.Description = String.Format("{0}{1}{2}{1}{3}", e.Appointment.CustomFields("AccountName"), vbCrLf, e.Appointment.CustomFields("InvoiceNo"), e.Appointment.CustomFields("BookingRef")) ' e.Appointment.Description)
        Else
            e.Description = String.Format("{0}{1}{2}", e.Appointment.CustomFields("AccountName"), vbCrLf, e.Appointment.CustomFields("BookingRef")) 'e.Appointment.Description)
        End If
    End Sub

    Private Sub SchedulerControl_CustomizeAppointmentFlyout(sender As Object, e As CustomizeAppointmentFlyoutEventArgs) Handles SchedulerControl.CustomizeAppointmentFlyout
        e.ShowReminder = False
        e.ShowLocation = False
        e.Subject = String.Format("{0}{1}Ref - {2}|Invoice - {3}", e.Appointment.Subject, vbCrLf, e.Appointment.CustomFields("BookingRef"), e.Appointment.CustomFields("InvoiceNo"))
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Using frmProvisionalBookings As New ProvisionalBookingsForm
            frmProvisionalBookings.ShowDialog()
        End Using
    End Sub

    Private Sub FindBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindBarButtonItem.ItemClick
        Using frmSearch As New SearchForm
            frmSearch.ShowDialog()
        End Using
    End Sub
End Class
