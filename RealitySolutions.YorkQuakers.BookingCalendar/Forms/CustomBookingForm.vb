Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports DevExpress.Utils
Imports DevExpress.Utils.Internal
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Native
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.iCalendar
Imports DevExpress.XtraScheduler.Localization
Imports DevExpress.XtraScheduler.Native
Imports DevExpress.XtraScheduler.Printing
Imports DevExpress.XtraScheduler.Printing.Native
Imports DevExpress.XtraScheduler.UI
Imports DevExpress.XtraScheduler.Commands
Imports DevExpress.XtraScheduler.Services
Imports DevExpress.XtraPrinting
Imports RealitySolutions.YorkQuakers.BookingCalendar.Backend
Imports DevExpress.XtraScheduler.Xml
Imports System.Linq

Partial Public Class CustomBookingForm
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm
    Implements IDXManagerPopupMenu
#Region "Fields"
    Private m_openRecurrenceForm As Boolean
    Private ReadOnly m_storage As ISchedulerStorage
    Private ReadOnly m_control As SchedulerControl
    Private m_recurringIcon As Icon
    Private m_normalIcon As Icon
    Private ReadOnly m_controller As AppointmentFormController
    Private m_menuManager As IDXMenuManager
    Private m_supressCancelCore As Boolean
#End Region

    Public Property oSetting As Settings
    Public Property BookingID As Int64
    Public Property oStorage As SchedulerDataStorage
    Public Property SourceAppointment As Appointment

    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal control As DevExpress.XtraScheduler.SchedulerControl, ByVal apt As Appointment)
        Me.New(control, apt, False)
    End Sub
    Public Property IsOccurence As Boolean = False
    Public Sub New(ByVal control As DevExpress.XtraScheduler.SchedulerControl, ByVal apt As Appointment, ByVal openRecurrenceForm As Boolean)
        Guard.ArgumentNotNull(control, "control")
        Guard.ArgumentNotNull(control.DataStorage, "control.DataStorage")
        Guard.ArgumentNotNull(apt, "apt")

        Me.m_openRecurrenceForm = openRecurrenceForm
        Me.m_controller = CreateController(control, apt)
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()
        SetupPredefinedConstraints()

        LoadIcons()

        Me.m_control = control
        Me.m_storage = control.DataStorage

        Me.edtResource.SchedulerControl = control
        Me.edtResource.Storage = m_storage
        Me.edtResources.SchedulerControl = control

        Me.riAppointmentResource.SchedulerControl = control
        Me.riAppointmentResource.Storage = m_storage
        Me.riAppointmentStatus.Storage = m_storage

        Me.riAppointmentLabel.Storage = m_storage

        BindControllerToControls()

        LookAndFeel.ParentLookAndFeel = control.LookAndFeel

        Me.m_supressCancelCore = False

        IsOccurence = apt.IsOccurrence
    End Sub
#Region "Properties"
    <Browsable(False)>
    Public Property MenuManager() As IDXMenuManager
        Get
            Return m_menuManager
        End Get
        Private Set(ByVal value As IDXMenuManager)
            m_menuManager = value
        End Set
    End Property
    Protected Friend ReadOnly Property Controller() As AppointmentFormController
        Get
            Return m_controller
        End Get
    End Property
    Protected Friend ReadOnly Property Control() As SchedulerControl
        Get
            Return m_control
        End Get
    End Property
    Protected Friend ReadOnly Property Storage() As ISchedulerStorage
        Get
            Return m_storage
        End Get
    End Property
    Protected Friend ReadOnly Property IsNewAppointment() As Boolean
        Get
            Return If(m_controller IsNot Nothing, m_controller.IsNewAppointment, True)
        End Get
    End Property
    Protected Friend ReadOnly Property RecurringIcon() As Icon
        Get
            Return m_recurringIcon
        End Get
    End Property
    Protected Friend ReadOnly Property NormalIcon() As Icon
        Get
            Return m_normalIcon
        End Get
    End Property
    Protected Friend ReadOnly Property OpenRecurrenceForm() As Boolean
        Get
            Return m_openRecurrenceForm
        End Get
    End Property
    <DXDescription("DevExpress.XtraScheduler.UI.AppointmentRibbonForm,ReadOnly"), DXCategory(CategoryName.Behavior), DefaultValue(False)>
    Public Property [ReadOnly]() As Boolean
        Get
            Return Controller.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            If Controller.ReadOnly = value Then
                Return
            End If
            Controller.ReadOnly = value
        End Set
    End Property
    Protected Overrides ReadOnly Property ShowMode() As FormShowMode
        Get
            Return DevExpress.XtraEditors.FormShowMode.AfterInitialization
        End Get
    End Property
#End Region

    Public Overridable Sub LoadFormData(ByVal appointment As Appointment)
        'do nothing
    End Sub
    Public Overridable Function SaveFormData(ByVal appointment As Appointment) As Boolean
        Return True
    End Function
    Public Overridable Function IsAppointmentChanged(ByVal appointment As Appointment) As Boolean
        Return False
    End Function
    Public Overridable Sub SetMenuManager(ByVal menuManager As DevExpress.Utils.Menu.IDXMenuManager)
        MenuManagerUtils.SetMenuManager(Controls, menuManager)
        Me.m_menuManager = menuManager
    End Sub

    Protected Friend Overridable Sub SetupPredefinedConstraints()
        Me.edtResources.Visible = True
        If (Not WindowsFormsSettings.GetAllowDefaultSvgImages()) Then
            For Each item As BarItem In Me.ribbonControl1.Items
                item.ImageOptions.SvgImage = Nothing
            Next item
        End If
    End Sub
    Protected Overridable Sub BindControllerToControls()
        Me.DataBindings.Add("Text", Controller, "Caption")
        BindControllerToIcon()
        BindProperties(Me.tbSubject, "Text", "Subject")
        BindProperties(Me.tbLocation, "Text", "Location")
        BindProperties(Me.tbDescription, "Text", "Description")
        BindProperties(Me.edtStartDate, "EditValue", "DisplayStartDate")
        BindProperties(Me.edtStartDate, "Enabled", "IsDateTimeEditable")
        BindProperties(Me.edtStartTime, "EditValue", "DisplayStartTime")
        BindProperties(Me.edtStartTime, "Enabled", "IsTimeEnabled")
        BindProperties(Me.edtEndDate, "EditValue", "DisplayEndDate", DataSourceUpdateMode.Never)
        BindProperties(Me.edtEndDate, "Enabled", "IsDateTimeEditable", DataSourceUpdateMode.Never)
        BindProperties(Me.edtEndTime, "EditValue", "DisplayEndTime", DataSourceUpdateMode.Never)
        BindProperties(Me.edtEndTime, "Enabled", "IsTimeEnabled", DataSourceUpdateMode.Never)
        BindProperties(Me.chkAllDay, "Checked", "AllDay")
        BindProperties(Me.chkAllDay, "Enabled", "IsDateTimeEditable")

        BindProperties(Me.lblResource, "Enabled", "CanEditResource")

        BindProperties(Me.edtResources, "ResourceIds", "ResourceIds")
        BindProperties(Me.edtResources, "Visible", "ResourceSharing")
        BindProperties(Me.edtResources, "Enabled", "CanEditResource")

        BindProperties(Me.edtResource, "ResourceId", "ResourceId")
        BindProperties(Me.edtResource, "Enabled", "CanEditResource")
        BindToBoolPropertyAndInvert(Me.edtResource, "Visible", "ResourceSharing")

        BindProperties(Me.barLabel, "EditValue", "Label")

        BindProperties(Me.barStatus, "EditValue", "Status")

        BindBoolToVisibility(Me.barReminder, "Visibility", "ReminderVisible")
        BindProperties(Me.barReminder, "Editvalue", "ReminderTimeBeforeStart")

        BindProperties(Me.btnDelete, "Enabled", "CanDeleteAppointment")

        BindBoolToVisibility(Me.btnRecurrence, "Visibility", "ShouldShowRecurrenceButton")
        BindProperties(Me.btnRecurrence, "Down", "IsRecurrentAppointment")


        BindToBoolPropertyAndInvert(Me.ribbonControl1, "Enabled", "ReadOnly")

        BindProperties(Me.edtTimeZone, "Visible", "TimeZoneVisible")
        BindProperties(Me.edtTimeZone, "EditValue", "TimeZoneId")
        BindProperties(Me.edtTimeZone, "Enabled", "TimeZoneEnabled")

        BindBoolToVisibility(Me.btnTimeZones, "Visibility", "TimeZonesEnabled")
        BindProperties(Me.btnTimeZones, "Down", "TimeZoneVisible")
    End Sub

    Protected Overridable Sub BindControllerToIcon()
        Dim binding As New Binding("Icon", Controller, "AppointmentType")
        AddHandler binding.Format, AddressOf AppointmentTypeToIconConverter
        DataBindings.Add(binding)
    End Sub
    Protected Overridable Sub ObjectToStringConverter(ByVal o As Object, ByVal e As ConvertEventArgs)
        e.Value = e.Value.ToString()
    End Sub
    Protected Overridable Sub AppointmentTypeToIconConverter(ByVal o As Object, ByVal e As ConvertEventArgs)
        Dim type As AppointmentType = CType(e.Value, AppointmentType)
        If type = AppointmentType.Pattern Then
            e.Value = RecurringIcon
        Else
            e.Value = NormalIcon
        End If
    End Sub
    Protected Overridable Sub BindProperties(ByVal target As Control, ByVal targetProperty As String, ByVal sourceProperty As String)
        BindProperties(target, targetProperty, sourceProperty, DataSourceUpdateMode.OnPropertyChanged)
    End Sub
    Protected Overridable Sub BindProperties(ByVal target As Control, ByVal targetProperty As String, ByVal sourceProperty As String, ByVal updateMode As DataSourceUpdateMode)
        target.DataBindings.Add(targetProperty, Controller, sourceProperty, True, updateMode)
        BindToIsReadOnly(target, updateMode)
    End Sub
    Protected Overridable Sub BindProperties(ByVal target As Control, ByVal targetProperty As String, ByVal sourceProperty As String, ByVal objectToStringConverter As ConvertEventHandler)
        Dim binding As New Binding(targetProperty, Controller, sourceProperty, True)
        AddHandler binding.Format, objectToStringConverter
        target.DataBindings.Add(binding)
    End Sub
    Protected Overridable Sub BindToBoolPropertyAndInvert(ByVal target As Control, ByVal targetProperty As String, ByVal sourceProperty As String)
        target.DataBindings.Add(New BoolInvertBinding(targetProperty, Controller, sourceProperty))
        BindToIsReadOnly(target)
    End Sub
    Protected Overridable Sub BindToIsReadOnly(ByVal control As Control)
        BindToIsReadOnly(control, DataSourceUpdateMode.OnPropertyChanged)
    End Sub
    Protected Overridable Sub BindToIsReadOnly(ByVal control As Control, ByVal updateMode As DataSourceUpdateMode)
        If (Not (TypeOf control Is BaseEdit)) OrElse control.DataBindings("ReadOnly") IsNot Nothing Then
            Return
        End If
        control.DataBindings.Add("ReadOnly", Controller, "ReadOnly", True, updateMode)
    End Sub

    Protected Overridable Sub BindProperties(ByVal target As DevExpress.XtraBars.BarItem, ByVal targetProperty As String, ByVal sourceProperty As String)
        BindProperties(target, targetProperty, sourceProperty, DataSourceUpdateMode.OnPropertyChanged)
    End Sub
    Protected Overridable Sub BindProperties(ByVal target As DevExpress.XtraBars.BarItem, ByVal targetProperty As String, ByVal sourceProperty As String, ByVal updateMode As DataSourceUpdateMode)
        target.DataBindings.Add(targetProperty, Controller, sourceProperty, True, updateMode)
    End Sub
    Protected Overridable Sub BindProperties(ByVal target As DevExpress.XtraBars.BarItem, ByVal targetProperty As String, ByVal sourceProperty As String, ByVal objectToStringConverter As ConvertEventHandler)
        Dim binding As New Binding(targetProperty, Controller, sourceProperty, True)
        AddHandler binding.Format, objectToStringConverter
        target.DataBindings.Add(binding)
    End Sub
    Protected Overridable Sub BindToBoolPropertyAndInvert(ByVal target As DevExpress.XtraBars.BarItem, ByVal targetProperty As String, ByVal sourceProperty As String)
        target.DataBindings.Add(New BoolInvertBinding(targetProperty, Controller, sourceProperty))
    End Sub
    Protected Overridable Sub BindBoolToVisibility(ByVal target As DevExpress.XtraBars.BarItem, ByVal targetProperty As String, ByVal sourceProperty As String)
        target.DataBindings.Add(New BoolToVisibilityBinding(targetProperty, Controller, sourceProperty, False))
    End Sub
    Protected Overridable Sub BindBoolToVisibility(ByVal target As DevExpress.XtraBars.BarItem, ByVal targetProperty As String, ByVal sourceProperty As String, ByVal invert As Boolean)
        target.DataBindings.Add(New BoolToVisibilityBinding(targetProperty, Controller, sourceProperty, invert))
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)
        If Controller Is Nothing Then
            Return
        End If
        SubscribeControlsEvents()
        LoadFormData(Controller.EditedAppointmentCopy)
    End Sub
    Protected Overridable Function CreateController(ByVal control As SchedulerControl, ByVal apt As Appointment) As AppointmentFormController
        Return New AppointmentFormController(control, apt)
    End Function
    Protected Friend Overridable Sub LoadIcons()
        Dim asm As System.Reflection.Assembly = GetType(SchedulerControl).Assembly
        Me.m_recurringIcon = ResourceImageHelper.CreateIconFromResources(SchedulerIconNames.RecurringAppointment, asm)
        Me.m_normalIcon = ResourceImageHelper.CreateIconFromResources(SchedulerIconNames.Appointment, asm)
    End Sub
    Protected Friend Overridable Sub SubscribeControlsEvents()
        AddHandler Me.edtEndDate.Validating, AddressOf OnEdtEndDateValidating
        AddHandler Me.edtEndDate.InvalidValue, AddressOf OnEdtEndDateInvalidValue
        AddHandler Me.edtEndTime.Validating, AddressOf OnEdtEndTimeValidating
        AddHandler Me.edtEndTime.InvalidValue, AddressOf OnEdtEndTimeInvalidValue
        AddHandler Me.riDuration.Validating, AddressOf OnCbReminderValidating
        AddHandler Me.edtStartDate.Validating, AddressOf OnEdtStartDateValidating
        AddHandler Me.edtStartDate.InvalidValue, AddressOf OnEdtStartDateInvalidValue
        AddHandler Me.edtStartTime.Validating, AddressOf OnEdtStartTimeValidating
        AddHandler Me.edtStartTime.InvalidValue, AddressOf OnEdtStartTimeInvalidValue
        AddHandler Me.edtResource.SelectedIndexChanged, AddressOf edtResource_SelectedIndexChanged
    End Sub
    Protected Friend Overridable Sub UnsubscribeControlsEvents()
        RemoveHandler Me.edtEndDate.Validating, AddressOf OnEdtEndDateValidating
        RemoveHandler Me.edtEndDate.InvalidValue, AddressOf OnEdtEndDateInvalidValue
        RemoveHandler Me.edtEndTime.Validating, AddressOf OnEdtEndTimeValidating
        RemoveHandler Me.edtEndTime.InvalidValue, AddressOf OnEdtEndTimeInvalidValue
        RemoveHandler Me.riDuration.Validating, AddressOf OnCbReminderValidating
        RemoveHandler Me.edtStartDate.Validating, AddressOf OnEdtStartDateValidating
        RemoveHandler Me.edtStartDate.InvalidValue, AddressOf OnEdtStartDateInvalidValue
        RemoveHandler Me.edtStartTime.Validating, AddressOf OnEdtStartTimeValidating
        RemoveHandler Me.edtStartTime.InvalidValue, AddressOf OnEdtStartTimeInvalidValue
        RemoveHandler Me.edtResource.SelectedIndexChanged, AddressOf edtResource_SelectedIndexChanged
    End Sub

    Protected Friend Overridable Sub OnEdtStartTimeInvalidValue(ByVal sender As Object, ByVal e As InvalidValueExceptionEventArgs)
        e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval)
    End Sub
    Protected Friend Overridable Sub OnEdtStartTimeValidating(ByVal sender As Object, ByVal e As CancelEventArgs)
        e.Cancel = Not Controller.ValidateLimitInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay)
    End Sub
    Protected Friend Overridable Sub OnEdtStartDateInvalidValue(ByVal sender As Object, ByVal e As InvalidValueExceptionEventArgs)
        e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval)
    End Sub
    Protected Friend Overridable Sub OnEdtStartDateValidating(ByVal sender As Object, ByVal e As CancelEventArgs)
        e.Cancel = Not Controller.ValidateLimitInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay)
    End Sub
    Protected Friend Overridable Sub OnEdtEndDateValidating(ByVal sender As Object, ByVal e As CancelEventArgs)
        e.Cancel = Not IsValidInterval()
        If (Not e.Cancel) Then
            Me.edtEndDate.DataBindings("EditValue").WriteValue()
        End If
    End Sub
    Protected Friend Overridable Sub OnEdtEndDateInvalidValue(ByVal sender As Object, ByVal e As InvalidValueExceptionEventArgs)
        If (Not AppointmentFormControllerBase.ValidateInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay)) Then
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_InvalidEndDate)
        Else
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval)
        End If
    End Sub
    Protected Friend Overridable Sub OnEdtEndTimeValidating(ByVal sender As Object, ByVal e As CancelEventArgs)
        e.Cancel = Not IsValidInterval()
        If (Not e.Cancel) Then
            Me.edtEndTime.DataBindings("EditValue").WriteValue()
        End If
    End Sub
    Protected Friend Overridable Sub OnEdtEndTimeInvalidValue(ByVal sender As Object, ByVal e As InvalidValueExceptionEventArgs)
        If (Not AppointmentFormControllerBase.ValidateInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay)) Then
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_InvalidEndDate)
        Else
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval)
        End If
    End Sub
    Protected Friend Overridable Function IsValidInterval() As Boolean
        Return AppointmentFormControllerBase.ValidateInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay) AndAlso Controller.ValidateLimitInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay)
    End Function
    Protected Friend Overridable Sub OnOkButton()
        Save(True)
    End Sub
    Protected Overridable Sub OnSaveButton()
        Save(False)
    End Sub
    Private Sub Save(ByVal closeAfterSave As Boolean)
        If tbSubject.Text = "" Then
            XtraMessageBox.Show(LookAndFeel, "Please enter the description first.", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        'If AccountLookUpEdit.Text = "" Then
        '    XtraMessageBox.Show(LookAndFeel, "Please select the customer account first.", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Return
        'End If
        If edtResource.Text = "" Then
            XtraMessageBox.Show(LookAndFeel, "Please select the room first.", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        'If txtContactEmail.Text = "" Then
        '    XtraMessageBox.Show(LookAndFeel, "Please enter the contact email address first.", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Return
        'End If
        'If txtContactEmail.Text.Contains("@") = False Then
        '    XtraMessageBox.Show(LookAndFeel, "Please enter a valid email address.", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Return
        'End If

        'If txtContactEmail.Text.Contains(".co.uk") = False And txtContactEmail.Text.Contains(".com") = False And txtContactEmail.Text.Contains(".org") = False Then
        '    XtraMessageBox.Show(LookAndFeel, "Please enter a valid email address.", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Return
        'End 

        If (Not ValidateDateAndTime()) Then
            Return
        End If
        If (Not SaveFormData(Controller.EditedAppointmentCopy)) Then
            Return
        End If
        If (Not Controller.IsConflictResolved()) Then
            ShowMessageBox(SchedulerLocalizer.GetString(SchedulerStringId.Msg_Conflict), Controller.GetMessageBoxCaption(SchedulerStringId.Msg_Conflict), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If IsAppointmentChanged(Controller.EditedAppointmentCopy) OrElse Controller.IsAppointmentChanged() OrElse Controller.IsNewAppointment Then
            Controller.ApplyChanges()
        End If

        If Controller.IsRecurrentAppointment Then
            Controller.ApplyRecurrence(Controller.EditedAppointmentCopy)
        End If

        CreateUpdateBooking()

        If bAborted Then Exit Sub

        If closeAfterSave Then
            Me.m_supressCancelCore = True
            DialogResult = System.Windows.Forms.DialogResult.OK
        End If
    End Sub
    Private Function ValidateDateAndTime() As Boolean
        Me.edtEndDate.DoValidate()
        Me.edtEndTime.DoValidate()
        Me.edtStartDate.DoValidate()
        Me.edtStartTime.DoValidate()

        Return String.IsNullOrEmpty(Me.edtEndTime.ErrorText) AndAlso String.IsNullOrEmpty(Me.edtEndDate.ErrorText) AndAlso String.IsNullOrEmpty(Me.edtStartDate.ErrorText) AndAlso String.IsNullOrEmpty(Me.edtStartTime.ErrorText)
    End Function
    Protected Overridable Sub OnSaveAsButton()
        Dim fileDialog As New SaveFileDialog()
        fileDialog.Filter = "iCalendar files (*.ics)|*.ics"
        fileDialog.FilterIndex = 1
        If fileDialog.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
            Return
        End If
        Try
            Using stream As Stream = fileDialog.OpenFile()
                ExportAppointment(stream)
            End Using
        Catch
            ShowMessageBox("Error: could not export appointments", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ExportAppointment(ByVal stream As Stream)
        If stream Is Nothing Then
            Return
        End If

        Dim aptsToExport As New AppointmentBaseCollection()
        aptsToExport.Add(Controller.EditedAppointmentCopy)
        Dim exporter As New iCalendarExporter(Me.m_storage, aptsToExport)

        exporter.ProductIdentifier = "-//Developer Express Inc."
        exporter.Export(stream)
    End Sub
    Protected Friend Overridable Function ShowMessageBox(ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon) As DialogResult
        Return XtraMessageBox.Show(Me, text, caption, buttons, icon)
    End Function
    Protected Friend Overridable Sub OnDeleteButton()
        If IsNewAppointment Then
            Return
        End If

        Controller.DeleteAppointment()

        DialogResult = System.Windows.Forms.DialogResult.Abort
        Close()
    End Sub
    Protected Friend Overridable Sub OnRecurrenceButton()
        If (Not Controller.ShouldShowRecurrenceButton) Then
            Return
        End If

        Dim patternCopy As Appointment = Controller.PrepareToRecurrenceEdit()

        Dim result As DialogResult
        Using form As Form = CreateAppointmentRecurrenceForm(patternCopy, Control.OptionsView.FirstDayOfWeek)
            form.Controls(0).Controls(13).Hide()
            result = ShowRecurrenceForm(form)
        End Using

        If result = System.Windows.Forms.DialogResult.Abort Then
            Controller.RemoveRecurrence()
        ElseIf result = System.Windows.Forms.DialogResult.OK Then
            Controller.ApplyRecurrence(patternCopy)
        End If

        Me.btnRecurrence.Down = Controller.IsRecurrentAppointment
    End Sub
    Protected Overridable Sub OnCloseButton()
        Me.Close()
    End Sub

    Private Function CancelCore() As Boolean
        Dim result As Boolean = True

        If DialogResult <> System.Windows.Forms.DialogResult.Abort AndAlso Controller IsNot Nothing AndAlso Controller.IsAppointmentChanged() AndAlso (Not Me.m_supressCancelCore) Then
            Dim dialogResult As DialogResult = ShowMessageBox(SchedulerLocalizer.GetString(SchedulerStringId.Msg_SaveBeforeClose), Controller.GetMessageBoxCaption(SchedulerStringId.Msg_SaveBeforeClose), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

            If dialogResult = System.Windows.Forms.DialogResult.Cancel Then
                result = False
            ElseIf dialogResult = System.Windows.Forms.DialogResult.Yes Then
                Save(True)
            End If
        End If

        Return result
    End Function

    Protected Overridable Function ShowRecurrenceForm(ByVal form As Form) As DialogResult
        Return FormTouchUIAdapter.ShowDialog(form, Me)
    End Function
    Protected Friend Overridable Function CreateAppointmentRecurrenceForm(ByVal patternCopy As Appointment, ByVal firstDayOfWeek As DevExpress.XtraScheduler.FirstDayOfWeek) As Form
        Dim form As New AppointmentRecurrenceForm(patternCopy, firstDayOfWeek, Controller)
        form.SetMenuManager(MenuManager)
        form.LookAndFeel.ParentLookAndFeel = LookAndFeel
        form.RightToLeftLayout = RightToLeftLayout
        form.RightToLeft = RightToLeft
        form.Controls(0).Controls(13).Hide()
        form.ShowExceptionsRemoveMsgBox = m_controller.AreExceptionsPresent()
        Return form
    End Function
    Friend Sub OnAppointmentFormActivated(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        If m_openRecurrenceForm Then
            m_openRecurrenceForm = False
            OnRecurrenceButton()
        End If
    End Sub
    Protected Friend Overridable Sub OnCbReminderValidating(ByVal sender As Object, ByVal e As CancelEventArgs)
        Dim span As TimeSpan = CType(barReminder.EditValue, TimeSpan)
        e.Cancel = span.Ticks < 0 AndAlso span <> TimeSpan.MinValue
        If (Not e.Cancel) Then
            Me.barReminder.DataBindings("EditValue").WriteValue()
        End If
    End Sub

    Protected Friend Overridable Sub OnNextButton()
        If CancelCore() Then
            Me.m_supressCancelCore = True
            Dim command As New OpenNextAppointmentCommand(Control)
            command.Execute()
            Me.Close()
        End If
    End Sub

    Protected Friend Overridable Sub OnPreviousButton()
        If CancelCore() Then
            Me.m_supressCancelCore = True
            Dim command As New OpenPrevAppointmentCommand(Control)
            command.Execute()
            Me.Close()
        End If
    End Sub

    Protected Friend Overridable Sub OnTimeZonesButton()
        Controller.TimeZoneVisible = Not Controller.TimeZoneVisible
    End Sub

    Protected Overridable Sub OnApplicationButtonClick()
        Me.appointmentBackstageControl.SetPrintDocument(Control.GetPrintPreviewDocument(New RibbonFormPreviewMemoPrintStyle(Controller.EditedAppointmentCopy)))
    End Sub

    Protected Overridable Sub OnPrintButton()
        Using tool As PrintTool = New PrintTool(Me.appointmentBackstageControl.Document)
            tool.Print(Me.appointmentBackstageControl.SelectedPrinterName)
        End Using
    End Sub

    Protected Overridable Sub OnPrintOptionsButton()
        Using tool As PrintTool = New PrintTool(Me.appointmentBackstageControl.Document)
            tool.PrintDialog(FindForm(), LookAndFeel)
        End Using
    End Sub

    Private Sub btnSaveAndClose_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSaveAndClose.ItemClick
        OnOkButton()
    End Sub

    Private Sub barButtonDelete_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        OnDeleteButton()
    End Sub

    Private Sub barRecurrence_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles btnRecurrence.ItemClick
        OnRecurrenceButton()
    End Sub

    Private Sub bvbSave_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs) Handles bvbSave.ItemClick
        OnSaveButton()
    End Sub

    Private Sub bvbSaveAs_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs) Handles bvbSaveAs.ItemClick
        OnSaveAsButton()
    End Sub

    Private Sub bvbClose_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs) Handles bvbClose.ItemClick
        OnCloseButton()
    End Sub

    Private Sub btnSave_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles btnSave.ItemClick
        OnSaveButton()
    End Sub

    Protected Overrides Sub OnClosing(ByVal e As CancelEventArgs)
        e.Cancel = Not CancelCore()
        MyBase.OnClosing(e)
    End Sub

    Private Sub btnNext_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles btnNext.ItemClick
        OnNextButton()
    End Sub

    Private Sub btnPrevious_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles btnPrevious.ItemClick
        OnPreviousButton()
    End Sub

    Private Sub btnTimeZones_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles btnTimeZones.ItemClick
        OnTimeZonesButton()
    End Sub

    Private Sub ribbonControl1_ApplicationButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles ribbonControl1.ApplicationButtonClick
        OnApplicationButtonClick()
    End Sub

    Private Sub schedulerPrint_PrintOptionsClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles appointmentBackstageControl.PrintOptionsClick
        OnPrintOptionsButton()
    End Sub

    Private Sub schedulerPrint_PrintClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles appointmentBackstageControl.PrintClick
        OnPrintButton()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Me.components IsNot Nothing Then
                Me.components.Dispose()
            End If
            If LookAndFeel IsNot Nothing Then
                LookAndFeel.ParentLookAndFeel = Nothing
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Dim SourceBookingID As Int64 = 0

    Private Sub CustomBookingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Maintain Booking"

        ' Bind account lookup to sage 50 accounts list
        AccountLookUpEdit.Properties.DataSource = Sage50Accounts 'Sage50Coordinator.FetchAccounts(oSetting)
        AccountLookUpEdit.Properties.AllowNullInput = DefaultBoolean.True

        ' Remove the (Any) resource
        edtResource.Properties.Items.RemoveAt(0)

        AccountLookUpEdit.EditValue = Controller.EditedAppointmentCopy.CustomFields("AccountName")
        BookingRefTextEdit.Text = Controller.EditedAppointmentCopy.CustomFields("BookingRef")



        If SourceAppointment.IsRecurring And SourceAppointment.IsOccurrence Then
            If SourceAppointment.RecurrenceIndex = 0 Then
                BookingID = SourceAppointment.RecurrencePattern.Id
                chkInvoice.Checked = SourceAppointment.RecurrencePattern.GetOccurrence(SourceAppointment.RecurrenceIndex).CustomFields("InvoiceGenerated")
                txtInvoiceNo.Text = SourceAppointment.RecurrencePattern.GetOccurrence(SourceAppointment.RecurrenceIndex).CustomFields("InvoiceNo")
                chkEmail.Checked = SourceAppointment.RecurrencePattern.GetOccurrence(SourceAppointment.RecurrenceIndex).CustomFields("EmailGenerated")
                chkTC.Checked = SourceAppointment.RecurrencePattern.GetOccurrence(SourceAppointment.RecurrenceIndex).CustomFields("AcceptedTC")
            Else
                PostInvoiceBar2ButtonItem.Enabled = False
                SendEmailBarButtonItem.Enabled = False
                PostInvoiceBarButtonItem.Enabled = False
            End If
        Else
            chkInvoice.Checked = Controller.EditedAppointmentCopy.CustomFields("InvoiceGenerated")
            txtInvoiceNo.Text = Controller.EditedAppointmentCopy.CustomFields("InvoiceNo")
            chkEmail.Checked = Controller.EditedAppointmentCopy.CustomFields("EmailGenerated")
            chkTC.Checked = Controller.EditedAppointmentCopy.CustomFields("AcceptedTC")
        End If

        txtContactEmail.Text = Controller.EditedAppointmentCopy.CustomFields("ContactEmail")
        txtInvoicingEmail.Text = Controller.EditedAppointmentCopy.CustomFields("InvoicingEmail")
        edtResource.ResourceId = Controller.EditedAppointmentCopy.ResourceId
        tbInvoiceNotes.Text = Controller.EditedAppointmentCopy.CustomFields("InvoiceNotes")


        ' Populate room costs grid 
        Dim intBookingID As Int64 = BookingID
        If SourceAppointment.IsRecurring And SourceAppointment.IsOccurrence Then
            If intBookingID = 0 Then intBookingID = SourceAppointment.RecurrencePattern.Id

        End If

        ' Populate list of extras grid
        Dim oExtras As List(Of String) = CalendarCoordinator.FetchExtras()
        Dim oBindingExtras As New BindingList(Of BookingExtraPart)

        For Each oExtra In oExtras
            oBindingExtras.Add(New BookingExtraPart() With {.Extra = oExtra, .Qty = CalendarCoordinator.FetchExtraCount(intBookingID, oExtra)})
        Next

        ExtrasGrid.DataSource = oBindingExtras


        Dim dicCosts As List(Of RoomCost) = CalendarCoordinator.FetchRoomCosts(intBookingID)
        Dim oRoomCosts As new BindingList(Of RoomCostPart)

        If edtResource.Text <> "" Then
            Dim oSessionCode = CalendarCoordinator.FetchRoomSageSessionCode(edtResource.Text)
            Dim oHourCode = CalendarCoordinator.FetchRoomSageHourCode(edtResource.Text)
            Dim oU3ACode = CalendarCoordinator.FetchRoomSageU3ACode(edtResource.Text)

            If oSessionCode <> "" Then oRoomCosts.Add(New RoomCostPart() With {.Sage50Code = oSessionCode, .Qty = 0, .Price = CalendarCoordinator.FetchRoomSessionCost(edtResource.Text)})
            If oHourCode <> "" Then oRoomCosts.Add(New RoomCostPart() With {.Sage50Code = oHourCode, .Qty = 0, .Price = CalendarCoordinator.FetchRoomHourCost(edtResource.Text)})
            If oU3ACode <> "" Then oRoomCosts.Add(New RoomCostPart() With {.Sage50Code = oU3ACode, .Qty = 0, .Price = CalendarCoordinator.FetchRoomU3ACost(edtResource.Text)})

            For Each entry In dicCosts
                Dim oExistingCost = oRoomCosts.FirstOrDefault(Function(x) x.Sage50Code = entry.Sage50Code)

                If oExistingCost IsNot Nothing Then oExistingCost.Qty = entry.Quantity : oExistingCost.Price = entry.Price
            Next
        End If

        RoomsGridControl.DataSource = oRoomCosts
        RoomsGridView.Columns(2).Visible = False

        ' Populate booking extras and costs, if amending
        If intBookingID <> 0 Then
            PostInvoiceBarButtonItem.Enabled = True
            PostInvoiceBar2ButtonItem.Enabled = True
            SendEmailBarButtonItem.Enabled = True
            CancelBarButtonItem.Enabled = True

            If SourceAppointment.IsRecurring And SourceAppointment.IsOccurrence Then
                If SourceAppointment.RecurrenceIndex = 0 Then

                Else
                    PostInvoiceBar2ButtonItem.Enabled = False
                    SendEmailBarButtonItem.Enabled = False
                    PostInvoiceBarButtonItem.Enabled = False
                End If
            End If

            decRoomSessionCost = CalendarCoordinator.FetchRoomSessionCost(edtResource.Text)
            decRoomHourCost = CalendarCoordinator.FetchRoomHourCost(edtResource.Text)
            decRoomU3ACost = CalendarCoordinator.FetchRoomU3ACost(edtResource.Text)

            UpdateCosts()
        End If

        If Controller.EditedAppointmentCopy.CustomFields("Cancelled") = True Then
            topPanel.Enabled = False
            bottomPanel.Enabled = False
            ribbonControl1.Enabled = False
            ExtrasGrid.Enabled = False
            RoomsGridControl.Enabled = False
        End If
    End Sub

    Private decRoomSessionCost As Decimal = 0
    Private decRoomHourCost As Decimal = 0
    Private decRoomU3ACost As Decimal = 0

    Private Sub UpdateCosts()
        Dim decTotalCost As Decimal = 0

        If edtResource.Text <> "" Then
            decRoomSessionCost = CalendarCoordinator.FetchRoomSessionCost(edtResource.Text)
            decRoomHourCost = CalendarCoordinator.FetchRoomHourCost(edtResource.Text)
            decRoomU3ACost = CalendarCoordinator.FetchRoomU3ACost(edtResource.Text)
        End If

        ' Room costs
        Try
            decTotalCost += decRoomSessionCost * DirectCast(RoomsGridControl.DataSource, BindingList(Of RoomCostPart))(0).Qty
        Catch ex As Exception
        End Try
        Try
            decTotalCost += decRoomHourCost * DirectCast(RoomsGridControl.DataSource, BindingList(Of RoomCostPart))(1).Qty
        Catch ex As Exception
        End Try
        Try
            decTotalCost += decRoomU3ACost * DirectCast(RoomsGridControl.DataSource, BindingList(Of RoomCostPart))(2).Qty
        Catch ex As Exception
        End Try

        ' Extras costs
        For Each entry In DirectCast(ExtrasGrid.DataSource, BindingList(Of BookingExtraPart))
            If entry.Qty >= 1 Then decTotalCost += CalendarCoordinator.FetchExtraCost(entry.Extra, entry.Qty)
        Next

        CostTextEdit.Text = decTotalCost
    End Sub

    Dim bAborted As Boolean = False
    Private Sub CreateUpdateBooking()
        bAborted = False

        Dim oBooking As New Booking

        With oBooking
            .BookingID = BookingID
            .Type = Controller.EditedAppointmentCopy.Type
            .StartDate = Controller.EditedAppointmentCopy.Start
            .EndDateTime = Controller.EditedAppointmentCopy.End
            .AllDay = Controller.EditedAppointmentCopy.AllDay
            .Subject = Controller.EditedAppointmentCopy.Subject
            .Location = edtResource.Text
            .Description = Controller.EditedAppointmentCopy.Description
            .Status = Controller.EditedAppointmentCopy.StatusKey
            .Label = Controller.EditedAppointmentCopy.LabelKey
            .RoomID = Controller.EditedAppointmentCopy.ResourceId

            If Controller.EditedAppointmentCopy.Reminder IsNot Nothing Then
                .ReminderInfo = ReminderCollectionXmlPersistenceHelper.CreateSaveInstance(Controller.EditedAppointmentCopy).ToXml 'Controller.EditedAppointmentCopy.Reminder.ToString
            End If
            If Controller.EditedAppointmentCopy.RecurrenceInfo IsNot Nothing Then
                .RecurrenceInfo = Controller.EditedAppointmentCopy.RecurrenceInfo.ToXml()
            End If
            If SourceAppointment.IsRecurring And SourceAppointment.IsOccurrence Then
                If SourceAppointment.RecurrenceIndex = 0 Then
                    .RecurrenceInfo = SourceAppointment.RecurrenceInfo.ToXml()
                    .Type = 1
                End If
            End If

            .ContactEmail = txtContactEmail.Text
            .InvoicingEmail = txtInvoicingEmail.Text
            .InvoiceNo = txtInvoiceNo.Text
            If .InvoiceNo <> "" Then .InvoiceGenerated = True Else .InvoiceGenerated = False
            .AccountName = AccountLookUpEdit.Text
            .InvoiceNotes = tbInvoiceNotes.Text
            .EmailGenerated = chkEmail.Checked
            .AcceptedTC = chkTC.Checked
        End With

        ' Collate booking extras
        Dim lstExtras As New List(Of BookingExtra)

        For Each entry In DirectCast(ExtrasGrid.DataSource, BindingList(Of BookingExtraPart))
            If entry.Qty >= 1 Then lstExtras.Add(New BookingExtra() With {.Name = entry.Extra, .ExtraCount = entry.Qty})
        Next

        Dim lstRoomCosts As New List(Of RoomCost)

        For Each entry In DirectCast(RoomsGridControl.DataSource, BindingList(Of RoomCostPart))
            If entry.Qty >= 1 Then lstRoomCosts.Add(New RoomCost() With {.Sage50Code = entry.Sage50Code, .Quantity = entry.Qty, .Price = entry.Price})
        Next

        Controller.EditedAppointmentCopy.Location = edtResource.Text
        Controller.EditedAppointmentCopy.CustomFields("AccountName") = AccountLookUpEdit.Text
        Controller.EditedAppointmentCopy.CustomFields("ContactEmail") = txtContactEmail.Text
        Controller.EditedAppointmentCopy.CustomFields("InvoicingEmail") = txtInvoicingEmail.Text
        Controller.EditedAppointmentCopy.CustomFields("InvoiceNotes") = tbInvoiceNotes.Text
        Controller.EditedAppointmentCopy.CustomFields("InvoiceGenerated") = txtInvoiceNo.Text <> ""
        Controller.EditedAppointmentCopy.CustomFields("InvoiceNo") = txtInvoiceNo.Text
        Controller.EditedAppointmentCopy.CustomFields("AcceptedTC") = chkTC.Checked
        Controller.EditedAppointmentCopy.CustomFields("EmailGenerated") = chkEmail.Checked


        If BookingID = 0 Then
            If oBooking.RecurrenceInfo IsNot Nothing Then
                Dim guidRec As Guid = Guid.NewGuid()

                ' this is a recurring booking, we need to generate the individual booking entrys
                ' if no end date, then stop after 6 months?
                Dim oRecurrenceDetails = SourceAppointment.RecurrenceInfo
                Dim oRecurrencePattern = SourceAppointment.RecurrencePattern

                Dim weekdays = oRecurrenceDetails.WeekDays
                Dim type = oRecurrenceDetails.Type

                Dim counter As Integer = 0

                Dim bOccurence As Boolean = False
                Dim bEndByDate As Boolean = False
                Dim bNoEndDate As Boolean = False
                Dim endByDate As Date = oRecurrenceDetails.End

                If oRecurrenceDetails.Range = RecurrenceRange.EndByDate Then
                    bEndByDate = True
                ElseIf oRecurrenceDetails.Range = RecurrenceRange.NoEndDate Then
                    bNoEndDate = True

                ElseIf oRecurrenceDetails.Range = RecurrenceRange.OccurrenceCount Then
                    counter = oRecurrenceDetails.OccurrenceCount
                    bOccurence = True
                End If

                Dim startDate = oBooking.StartDate
                Dim endDate = oBooking.EndDateTime

                If bOccurence Then
                    For i As Integer = 0 To oRecurrenceDetails.OccurrenceCount
                        If counter = 0 Then Exit For


                        oBooking.Type = 0
                        oBooking.RecurrenceInfo = Nothing
                        oBooking.IsRecurring = True
                        oBooking.RecurringGUID = guidRec
                        oBooking.StartDate = startDate
                        oBooking.EndDateTime = endDate

                        Dim intInsertedID As Dictionary(Of Int64, String)
                        Dim rangeDays = weekdays.ToString.Replace(" ", "").Split(",")

                        If type = RecurrenceType.Weekly Then
                            For j As Integer = 0 To rangeDays.Length - 1
                                If counter = 0 Then Exit For

                                Dim day = rangeDays(j)

                                oBooking.StartDate = startDate
                                oBooking.EndDateTime = endDate

                                If i = 0 Then
                                    intInsertedID = CalendarCoordinator.InsertBooking(oBooking, BookingRefTextEdit.Text)

                                    CalendarCoordinator.InsertBookingExtras(lstExtras, intInsertedID.Keys.First)
                                    CalendarCoordinator.InsertRoomCosts(lstRoomCosts, intInsertedID.Keys.First)

                                    ' Issues with automatically setting ID field
                                    oStorage.Appointments(oStorage.Appointments.Count - 1).SetId(intInsertedID.Keys.First)
                                    Controller.EditedAppointmentCopy.CustomFields("BookingRef") = intInsertedID.Values.First
                                Else

                                    intInsertedID = CalendarCoordinator.InsertBooking(oBooking, BookingRefTextEdit.Text)

                                    CalendarCoordinator.InsertBookingExtras(lstExtras, intInsertedID.Keys.First)
                                    CalendarCoordinator.InsertRoomCosts(lstRoomCosts, intInsertedID.Keys.First)
                                End If

                                counter -= 1 ' oRecurrenceDetails.Periodicity

                                ' increment start and end date
                                Dim daysToAdd As Integer = 1
                                If j = (rangeDays.Length - 1) Then
                                    Dim dayOfWeek As String = rangeDays(0) ' first day of next week
                                    Dim nextDate As Date = GetNextWeekday(startDate, dayOfWeek).AddDays(7 * (oRecurrenceDetails.Periodicity - 1))
                                    daysToAdd = Math.Abs(DateDiff(DateInterval.Day, startDate, nextDate)) ' first day of next week


                                    i += (rangeDays.Length - 1)
                                Else
                                    Dim dayOfWeek As String = rangeDays(j + 1)
                                    Dim nextDate As Date = GetNextWeekday(startDate, dayOfWeek)
                                    daysToAdd = Math.Abs(DateDiff(DateInterval.Day, startDate, nextDate))
                                End If

                                startDate = startDate.AddDays(daysToAdd)
                                endDate = endDate.AddDays(daysToAdd)
                            Next
                        Else

                            oBooking.StartDate = startDate
                            oBooking.EndDateTime = endDate

                            If i = 0 Then
                                intInsertedID = CalendarCoordinator.InsertBooking(oBooking, BookingRefTextEdit.Text)

                                CalendarCoordinator.InsertBookingExtras(lstExtras, intInsertedID.Keys.First)
                                CalendarCoordinator.InsertRoomCosts(lstRoomCosts, intInsertedID.Keys.First)

                                ' Issues with automatically setting ID field
                                oStorage.Appointments(oStorage.Appointments.Count - 1).SetId(intInsertedID.Keys.First)
                                Controller.EditedAppointmentCopy.CustomFields("BookingRef") = intInsertedID.Values.First
                            Else
                                intInsertedID = CalendarCoordinator.InsertBooking(oBooking, BookingRefTextEdit.Text)

                                CalendarCoordinator.InsertBookingExtras(lstExtras, intInsertedID.Keys.First)
                                CalendarCoordinator.InsertRoomCosts(lstRoomCosts, intInsertedID.Keys.First)
                            End If

                            ' increment 
                            counter -= 1 ' oRecurrenceDetails.Periodicity

                            ' increment start and end date
                            If type = RecurrenceType.Monthly Then
                                startDate = startDate.AddMonths(1 * oRecurrenceDetails.Periodicity)
                                endDate = endDate.AddMonths(1 * oRecurrenceDetails.Periodicity)

                            ElseIf type = RecurrenceType.Yearly Then
                                startDate = startDate.AddYears(1 * oRecurrenceDetails.Periodicity)
                                endDate = endDate.AddYears(1 * oRecurrenceDetails.Periodicity)

                            ElseIf type = RecurrenceType.Daily Then
                                If weekdays = WeekDays.EveryDay Then
                                    startDate = startDate.AddDays(1)
                                    endDate = endDate.AddDays(1)
                                ElseIf weekdays = WeekDays.WorkDays Then
                                    startDate = startDate.AddDays(1)
                                    endDate = endDate.AddDays(1)

                                    If startDate.DayOfWeek = DayOfWeek.Saturday Then startDate = startDate.AddDays(2)
                                    If endDate.DayOfWeek = DayOfWeek.Saturday Then endDate = endDate.AddDays(2)
                                    'Do Until startDate.DayOfWeek <> DayOfWeek.Saturday And startDate.DayOfWeek <> DayOfWeek.Sunday
                                    '    startDate = startDate.AddDays(1)
                                    '    endDate = endDate.AddDays(1)
                                    'Loop
                                End If
                            End If
                        End If
                    Next
                ElseIf bEndByDate Then
                    Dim i As Integer = 0

                    Do Until startDate >= endByDate
                        oBooking.Type = 0
                        oBooking.RecurrenceInfo = Nothing
                        oBooking.IsRecurring = True
                        oBooking.RecurringGUID = guidRec
                        oBooking.StartDate = startDate
                        oBooking.EndDateTime = endDate

                        Dim intInsertedID As Dictionary(Of Int64, String)
                        Dim rangeDays = weekdays.ToString.Replace(" ", "").Split(",")

                        If type = RecurrenceType.Weekly Then
                            For j As Integer = 0 To rangeDays.Length - 1
                                Dim day = rangeDays(j)

                                oBooking.StartDate = startDate
                                oBooking.EndDateTime = endDate

                                If i = 0 Then
                                    intInsertedID = CalendarCoordinator.InsertBooking(oBooking, BookingRefTextEdit.Text)

                                    CalendarCoordinator.InsertBookingExtras(lstExtras, intInsertedID.Keys.First)
                                    CalendarCoordinator.InsertRoomCosts(lstRoomCosts, intInsertedID.Keys.First)

                                    ' Issues with automatically setting ID field
                                    oStorage.Appointments(oStorage.Appointments.Count - 1).SetId(intInsertedID.Keys.First)
                                    Controller.EditedAppointmentCopy.CustomFields("BookingRef") = intInsertedID.Values.First
                                Else
                                    oBooking.Type = 0
                                    oBooking.RecurrenceInfo = Nothing

                                    intInsertedID = CalendarCoordinator.InsertBooking(oBooking, BookingRefTextEdit.Text)

                                    CalendarCoordinator.InsertBookingExtras(lstExtras, intInsertedID.Keys.First)
                                    CalendarCoordinator.InsertRoomCosts(lstRoomCosts, intInsertedID.Keys.First)
                                End If

                                counter -= 1 ' oRecurrenceDetails.Periodicity

                                ' increment start and end date
                                Dim daysToAdd As Integer = 1
                                If j = (rangeDays.Length - 1) Then
                                    Dim dayOfWeek As String = rangeDays(0) ' first day of next week
                                    Dim nextDate As Date = GetNextWeekday(startDate, dayOfWeek).AddDays(7 * (oRecurrenceDetails.Periodicity - 1))
                                    daysToAdd = Math.Abs(DateDiff(DateInterval.Day, startDate, nextDate)) ' first day of next week

                                    i += (rangeDays.Length - 1)
                                Else
                                    Dim dayOfWeek As String = rangeDays(j + 1)
                                    Dim nextDate As Date = GetNextWeekday(startDate, dayOfWeek)
                                    daysToAdd = Math.Abs(DateDiff(DateInterval.Day, startDate, nextDate))
                                End If

                                startDate = startDate.AddDays(daysToAdd)
                                endDate = endDate.AddDays(daysToAdd)
                            Next
                        Else

                            oBooking.StartDate = startDate
                            oBooking.EndDateTime = endDate

                            If i = 0 Then
                                intInsertedID = CalendarCoordinator.InsertBooking(oBooking, BookingRefTextEdit.Text)

                                CalendarCoordinator.InsertBookingExtras(lstExtras, intInsertedID.Keys.First)
                                CalendarCoordinator.InsertRoomCosts(lstRoomCosts, intInsertedID.Keys.First)

                                ' Issues with automatically setting ID field
                                oStorage.Appointments(oStorage.Appointments.Count - 1).SetId(intInsertedID.Keys.First)
                                Controller.EditedAppointmentCopy.CustomFields("BookingRef") = intInsertedID.Values.First
                            Else
                                intInsertedID = CalendarCoordinator.InsertBooking(oBooking, BookingRefTextEdit.Text)

                                CalendarCoordinator.InsertBookingExtras(lstExtras, intInsertedID.Keys.First)
                                CalendarCoordinator.InsertRoomCosts(lstRoomCosts, intInsertedID.Keys.First)
                            End If

                            ' increment
                            counter -= 1 ' oRecurrenceDetails.Periodicity

                            ' increment start and end date
                            If type = RecurrenceType.Monthly Then
                                startDate = startDate.AddMonths(1 * oRecurrenceDetails.Periodicity)
                                endDate = endDate.AddMonths(1 * oRecurrenceDetails.Periodicity)

                            ElseIf type = RecurrenceType.Yearly Then
                                startDate = startDate.AddYears(1 * oRecurrenceDetails.Periodicity)
                                endDate = endDate.AddYears(1 * oRecurrenceDetails.Periodicity)

                            ElseIf type = RecurrenceType.Daily Then
                                If weekdays = WeekDays.EveryDay Then
                                    startDate = startDate.AddDays(1)
                                    endDate = endDate.AddDays(1)
                                ElseIf weekdays = WeekDays.WorkDays Then
                                    startDate = startDate.AddDays(1)
                                    endDate = endDate.AddDays(1)

                                    If startDate.DayOfWeek = DayOfWeek.Saturday Then startDate = startDate.AddDays(2)
                                    If endDate.DayOfWeek = DayOfWeek.Saturday Then endDate = endDate.AddDays(2)
                                End If
                            End If
                        End If
                    Loop
                ElseIf bNoEndDate Then
                    XtraMessageBox.Show(LookAndFeel, "Please change the recurrence option end date from : 'No end date'", "Recurrence", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    bAborted = True
                    Exit Sub
                Else

                End If
            Else
                Dim intInsertedID As Dictionary(Of Int64, String) = CalendarCoordinator.InsertBooking(oBooking, BookingRefTextEdit.Text)
                CalendarCoordinator.InsertBookingExtras(lstExtras, intInsertedID.Keys.First)
                CalendarCoordinator.InsertRoomCosts(lstRoomCosts, intInsertedID.Keys.First)
                oStorage.SetAppointmentId(Controller.EditedAppointmentCopy, intInsertedID)

                ' Issues with automatically setting ID field
                oStorage.Appointments(oStorage.Appointments.Count - 1).SetId(intInsertedID.Keys.First)
                Controller.EditedAppointmentCopy.CustomFields("BookingRef") = intInsertedID.Values.First
            End If

        Else
            CalendarCoordinator.UpdateBooking(oBooking, BookingRefTextEdit.Text)
            CalendarCoordinator.UpdateBookingExtras(lstExtras, oBooking.BookingID)
            CalendarCoordinator.UpdateRoomCosts(lstRoomCosts, oBooking.BookingID)
        End If

        Try
            Controller.ApplyChanges()
        Catch ex As Exception
        End Try
    End Sub

    Private Shared Function GetNextWeekday(startDate As Date, dayName As String) As DateTime
        ' Do not match today, so start tomorrow '
        Dim result = startDate.AddDays(1)
        ' If the current day of the week is not one of your preferred, then keep going '
        While Not dayName = result.DayOfWeek.ToString()
            result = result.AddDays(1)
        End While
        Return result
    End Function
    Public Function WeekDayNumber(ByVal weekName As String) As Integer

        Dim weekNames As New Dictionary(Of String, Integer)

        For i As Integer = 1 To 7
            weekNames.Add(WeekdayName(i), i)
        Next

        Return weekNames(weekName)
    End Function


    Private Sub PostInvoiceBar2ButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles PostInvoiceBar2ButtonItem.ItemClick
        If String.IsNullOrEmpty(Controller.EditedAppointmentCopy.CustomFields("AccountName")) Then
            XtraMessageBox.Show(LookAndFeel, "No Sage 50 Account entered for this booking", "Post Invoice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Controller.EditedAppointmentCopy.CustomFields("InvoiceGenerated") = False Then
            XtraMessageBox.Show(LookAndFeel, "An initial invoice has not yet been posted for this booking.", "Post Invoice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you wish to post an additional invoice for this booking to Sage 50?", "Post Invoice",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Using frmAdditionalInvoice As New AdditionalInvoiceForm
                    frmAdditionalInvoice.Controller = Controller
                    frmAdditionalInvoice.BindingExtras = ExtrasGrid.DataSource
                    frmAdditionalInvoice.oSetting = oSetting
                    frmAdditionalInvoice.CustomerName = AccountLookUpEdit.Text.Split("|")(0)
                    frmAdditionalInvoice.RoomName = edtResource.Text
                    frmAdditionalInvoice.BookingID = BookingID

                    If frmAdditionalInvoice.ShowDialog = DialogResult.OK Then
                        Dim strAdditionalInvoiceNo As String =
                            String.Format("{0}|{1}", Controller.EditedAppointmentCopy.CustomFields("InvoiceNo"), frmAdditionalInvoice.InvoiceNo)

                        If strAdditionalInvoiceNo = "" Then Throw New Exception("Failed to generate sage 50 invoice.")

                        CalendarCoordinator.FlagAsInvoiced(BookingID, strAdditionalInvoiceNo)

                        'Try
                        '    EmailCoordinator.SendInvoiceEmail(oSetting, Controller.EditedAppointmentCopy.CustomFields("InvoicingEmail"),
                        '                                                   Controller.EditedAppointmentCopy.CustomFields("AccountName").ToString.Split("|")(1),
                        '                                                   frmAdditionalInvoice.InvoiceNo, Controller.EditedAppointmentCopy.CustomFields("BookingRef"))
                        'Catch ex As Exception
                        '    XtraMessageBox.Show(LookAndFeel, "An error has occurred generating the booking invoice email", "Post Invoice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'End Try

                        If SourceAppointment.IsRecurring And SourceAppointment.IsOccurrence Then
                            SourceAppointment.RecurrencePattern.GetOccurrence(SourceAppointment.RecurrenceIndex).CustomFields("InvoiceNo") = strAdditionalInvoiceNo

                        Else
                            Controller.EditedAppointmentCopy.CustomFields("InvoiceNo") = strAdditionalInvoiceNo

                        End If

                        XtraMessageBox.Show(LookAndFeel, "Additional Invoice " & frmAdditionalInvoice.InvoiceNo & " generated successfully.", "Post Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Controller.ApplyChanges()

                        Close()
                    End If
                End Using

            Catch ex As Exception
                ProgressPanel1.Visible = False
                XtraMessageBox.Show(LookAndFeel, ex.Message, "Post Invoice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End Try
        End If

    End Sub

    Private Sub PostInvoiceBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles PostInvoiceBarButtonItem.ItemClick
        ' Post invoice to sage 50
        If String.IsNullOrEmpty(Controller.EditedAppointmentCopy.CustomFields("AccountName")) Then
            XtraMessageBox.Show(LookAndFeel, "No Sage 50 Account entered for this booking", "Post Invoice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Controller.EditedAppointmentCopy.CustomFields("InvoiceGenerated") = True Then
            XtraMessageBox.Show(LookAndFeel, "An invoice has already been posted for this booking.", "Post Invoice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If txtInvoicingEmail.Text = "" Then
            XtraMessageBox.Show(LookAndFeel, "WARNING - No invoice email entered, no email will be generated.", "Post Invoice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        If DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("Are you sure you wish to post an invoice for £{0} for this booking to Sage 50?", CDec(CostTextEdit.Text)), "Post Invoice",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                ProgressPanel1.Visible = True

                Dim lstRoomCosts As New List(Of RoomCost)

                For Each entry In DirectCast(RoomsGridControl.DataSource, BindingList(Of RoomCostPart))
                    If entry.Qty >= 1 Then lstRoomCosts.Add(New RoomCost() With {.Sage50Code = entry.Sage50Code, .Quantity = entry.Qty, .price = entry.Price})
                Next

                Dim strInvoiceNo As String = Sage50Coordinator.PostInvoice(oSetting, Controller.EditedAppointmentCopy.CustomFields("BookingRef"), CalendarCoordinator.PopulateExtras(BookingID), AccountLookUpEdit.Text.Split("|")(0),
                                                                            edtResource.Text, lstRoomCosts, tbInvoiceNotes.Text)

                If strInvoiceNo = "" Then Throw New Exception("Failed to generate sage 50 invoice.")

                CalendarCoordinator.FlagAsInvoiced(BookingID, strInvoiceNo)


                Try
                    If txtInvoicingEmail.Text <> "" Then
                        EmailCoordinator.SendInvoiceEmail(oSetting, txtInvoicingEmail.Text,
                                                                   Controller.EditedAppointmentCopy.CustomFields("AccountName").ToString.Split("|")(1),
                                                                   strInvoiceNo, Controller.EditedAppointmentCopy.CustomFields("BookingRef"))
                    End If
                Catch ex As Exception
                    XtraMessageBox.Show(LookAndFeel, "An error has occurred generating the booking invoice email" & vbCrLf & vbCrLf & ex.Message, "Post Invoice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try


                If SourceAppointment.IsRecurring And SourceAppointment.IsOccurrence Then
                    SourceAppointment.RecurrencePattern.GetOccurrence(SourceAppointment.RecurrenceIndex).CustomFields("InvoiceNo") = strInvoiceNo
                    SourceAppointment.RecurrencePattern.GetOccurrence(SourceAppointment.RecurrenceIndex).CustomFields("InvoiceGenerated") = True
                Else
                    Controller.EditedAppointmentCopy.CustomFields("InvoiceNo") = strInvoiceNo
                    Controller.EditedAppointmentCopy.CustomFields("InvoiceGenerated") = True
                End If

                XtraMessageBox.Show(LookAndFeel, "Invoice " & strInvoiceNo & " generated successfully.", "Post Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Controller.ApplyChanges()

                ProgressPanel1.Visible = False
                Close()
            Catch ex As Exception
                ProgressPanel1.Visible = False
                XtraMessageBox.Show(LookAndFeel, ex.Message, "Post Invoice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End Try
        End If
    End Sub

    Private Sub SendEmailBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles SendEmailBarButtonItem.ItemClick
        If txtContactEmail.Text = "" Then
            XtraMessageBox.Show(LookAndFeel, "Bookng Email is blank", "Email", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        ' Send notification email to customer
        If DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you wish to send a booking email to this client?", "Send Email",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                'CalendarCoordinator.FlagAsConfirmed(BookingID)

                EmailCoordinator.SendBookingEmail(oSetting, txtContactEmail.Text,
                                                  Controller.EditedAppointmentCopy.CustomFields("AccountName").ToString.Split("|")(1),
                                                  Controller.EditedAppointmentCopy.CustomFields("BookingRef").ToString)

                'If SourceAppointment.IsRecurring And SourceAppointment.IsOccurrence Then
                '    SourceAppointment.RecurrencePattern.GetOccurrence(SourceAppointment.RecurrenceIndex).CustomFields("EmailGenerated") = True
                'Else
                '    Controller.EditedAppointmentCopy.CustomFields("EmailGenerated") = True
                'End If

                Controller.ApplyChanges()
                Close()
            Catch ex As Exception
                XtraMessageBox.Show(LookAndFeel, ex.Message, "Send Email", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End Try
        End If
    End Sub

    Private Sub CancelBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles CancelBarButtonItem.ItemClick
        ' Send notification email to customer
        If DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you wish to cancel this booking?", "Cancel Booking",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                CalendarCoordinator.FlagAsCancelled(BookingID)

                If SourceAppointment.IsRecurring And SourceAppointment.IsOccurrence Then
                    SourceAppointment.RecurrencePattern.GetOccurrence(SourceAppointment.RecurrenceIndex).CustomFields("Cancelled") = True
                Else
                    Controller.EditedAppointmentCopy.CustomFields("Cancelled") = True
                End If
                Controller.ApplyChanges()
                Close()

            Catch ex As Exception
                XtraMessageBox.Show(LookAndFeel, ex.Message, "Cancel Booking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End Try
        End If
    End Sub

    Private Sub edtResource_SelectedIndexChanged(sender As Object, e As EventArgs)
        tbLocation.Text = edtResource.Text

        ' Fetch room costs
        decRoomSessionCost = CalendarCoordinator.FetchRoomSessionCost(edtResource.Text)
        decRoomHourCost = CalendarCoordinator.FetchRoomHourCost(edtResource.Text)
        decRoomU3ACost = CalendarCoordinator.FetchRoomU3ACost(edtResource.Text)

        ' Need to fetch room codes from sage 50
        Dim oRoomCosts As New BindingList(Of RoomCostPart)
        Dim oSessionCode = CalendarCoordinator.FetchRoomSageSessionCode(edtResource.Text)
        Dim oHourCode = CalendarCoordinator.FetchRoomSageHourCode(edtResource.Text)
        Dim oU3ACode = CalendarCoordinator.FetchRoomSageU3ACode(edtResource.Text)

        If oSessionCode <> "" Then oRoomCosts.Add(New RoomCostPart() With {.Sage50Code = oSessionCode, .Qty = 0, .Price = CalendarCoordinator.FetchRoomSessionCost(edtResource.Text)})
        If oHourCode <> "" Then oRoomCosts.Add(New RoomCostPart() With {.Sage50Code = oHourCode, .Qty = 0, .Price = CalendarCoordinator.FetchRoomHourCost(edtResource.Text)})
        If oU3ACode <> "" Then oRoomCosts.Add(New RoomCostPart() With {.Sage50Code = oU3ACode, .Qty = 0, .Price = CalendarCoordinator.FetchRoomU3ACost(edtResource.Text)})

        RoomsGridControl.DataSource = oRoomCosts
        RoomsGridView.Columns(2).Visible = False
    End Sub

    Private Sub ExtrasGridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles ExtrasGridView.CellValueChanged
        UpdateCosts()
    End Sub

    Private Sub RoomsGridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles RoomsGridView.CellValueChanged
        UpdateCosts()
    End Sub

    Private Sub AccountLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles AccountLookUpEdit.EditValueChanged
        txtContactEmail.Text = Sage50Coordinator.FetchEmail(oSetting, AccountLookUpEdit.Text.Split("|")(0).Trim(" "))
        txtInvoicingEmail.Text = Sage50Coordinator.FetchEmail(oSetting, AccountLookUpEdit.Text.Split("|")(0).Trim(" "))
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ' refresh customers
        Try
            Sage50Accounts = Sage50Coordinator.FetchAccounts(oSetting)

            AccountLookUpEdit.Properties.DataSource = Sage50Accounts 'Sage50Coordinator.FetchAccounts(oSetting)
            AccountLookUpEdit.Properties.AllowNullInput = DefaultBoolean.True
            AccountLookUpEdit.EditValue = Controller.EditedAppointmentCopy.CustomFields("AccountName")

        Catch ex As Exception
            ' ignore connection error

        End Try
    End Sub
End Class

Public Class RoomCostPart
    Public Property Sage50Code As String
    Public Property Qty As Integer
    Public Property Price As Decimal
End Class

Public Class BookingExtraPart
    Public Property Extra As String
    Public Property Qty As Integer
End Class