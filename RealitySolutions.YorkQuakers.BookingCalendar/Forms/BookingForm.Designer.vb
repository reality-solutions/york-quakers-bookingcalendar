Imports DevExpress.XtraBars.Ribbon

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BookingForm
    Inherits RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BookingForm))
        Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btnSaveAndClose = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.barLabel = New DevExpress.XtraBars.BarEditItem()
        Me.barStatus = New DevExpress.XtraBars.BarEditItem()
        Me.barReminder = New DevExpress.XtraBars.BarEditItem()
        Me.btnRecurrence = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSave = New DevExpress.XtraBars.BarButtonItem()
        Me.btnNext = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPrevious = New DevExpress.XtraBars.BarButtonItem()
        Me.btnTimeZones = New DevExpress.XtraBars.BarButtonItem()
        Me.rpAppointment = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgActions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.lblSubject = New DevExpress.XtraEditors.LabelControl()
        Me.panel1 = New DevExpress.XtraEditors.PanelControl()
        Me.edtTimeZone = New DevExpress.XtraScheduler.UI.TimeZoneEdit()
        Me.lblResource = New DevExpress.XtraEditors.LabelControl()
        Me.edtResources = New DevExpress.XtraScheduler.UI.AppointmentResourcesEdit()
        Me.chkAllDay = New DevExpress.XtraEditors.CheckEdit()
        Me.tbSubject = New DevExpress.XtraEditors.TextEdit()
        Me.edtEndTime = New DevExpress.XtraEditors.TimeEdit()
        Me.lblLocation = New DevExpress.XtraEditors.LabelControl()
        Me.edtEndDate = New DevExpress.XtraEditors.DateEdit()
        Me.tbLocation = New DevExpress.XtraEditors.TextEdit()
        Me.lblEndTime = New DevExpress.XtraEditors.LabelControl()
        Me.lblStartTime = New DevExpress.XtraEditors.LabelControl()
        Me.edtStartTime = New DevExpress.XtraEditors.TimeEdit()
        Me.edtStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.tbDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.CheckedListBoxControl1 = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        CType(Me.edtTimeZone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtResources.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtResources.ResourcesCheckedListBoxControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAllDay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSubject.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtEndTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtStartTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckedListBoxControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ribbonControl1
        '
        Me.ribbonControl1.AutoSizeItems = True
        Me.ribbonControl1.ExpandCollapseItem.Id = 0
        Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbonControl1.ExpandCollapseItem, Me.ribbonControl1.SearchEditItem, Me.btnSaveAndClose, Me.btnDelete, Me.barLabel, Me.barStatus, Me.barReminder, Me.btnRecurrence, Me.btnSave, Me.btnNext, Me.btnPrevious, Me.btnTimeZones})
        Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.ribbonControl1.MaxItemId = 2
        Me.ribbonControl1.Name = "ribbonControl1"
        Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rpAppointment})
        Me.ribbonControl1.QuickToolbarItemLinks.Add(Me.btnSave)
        Me.ribbonControl1.QuickToolbarItemLinks.Add(Me.btnPrevious)
        Me.ribbonControl1.QuickToolbarItemLinks.Add(Me.btnNext)
        Me.ribbonControl1.QuickToolbarItemLinks.Add(Me.btnDelete)
        Me.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013
        Me.ribbonControl1.Size = New System.Drawing.Size(496, 158)
        '
        'btnSaveAndClose
        '
        Me.btnSaveAndClose.Caption = "Save And Close"
        Me.btnSaveAndClose.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnSaveAndClose.Hint = "Save this item and close the window"
        Me.btnSaveAndClose.Id = 3
        Me.btnSaveAndClose.ImageOptions.Image = CType(resources.GetObject("btnSaveAndClose.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSaveAndClose.ImageOptions.LargeImage = CType(resources.GetObject("btnSaveAndClose.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnSaveAndClose.ImageOptions.SvgImage = CType(resources.GetObject("btnSaveAndClose.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnSaveAndClose.Name = "btnSaveAndClose"
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleName = "Delete"
        Me.btnDelete.Caption = "Delete"
        Me.btnDelete.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnDelete.Hint = "Delete this item"
        Me.btnDelete.Id = 4
        Me.btnDelete.ImageOptions.Image = CType(resources.GetObject("btnDelete.ImageOptions.Image"), System.Drawing.Image)
        Me.btnDelete.ImageOptions.LargeImage = CType(resources.GetObject("btnDelete.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnDelete.ImageOptions.SvgImage = CType(resources.GetObject("btnDelete.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnDelete.Name = "btnDelete"
        '
        'barLabel
        '
        Me.barLabel.AccessibleName = "Label"
        Me.barLabel.Caption = "Label:"
        Me.barLabel.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.barLabel.Edit = Nothing
        Me.barLabel.EditWidth = 120
        Me.barLabel.Hint = "Change the label of this item"
        Me.barLabel.Id = 8
        Me.barLabel.Name = "barLabel"
        '
        'barStatus
        '
        Me.barStatus.AccessibleName = "Show time as"
        Me.barStatus.Caption = "Show time as:"
        Me.barStatus.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.barStatus.Edit = Nothing
        Me.barStatus.EditWidth = 120
        Me.barStatus.Hint = "Change how the time for this item is marked on your calendar"
        Me.barStatus.Id = 11
        Me.barStatus.Name = "barStatus"
        '
        'barReminder
        '
        Me.barReminder.AccessibleName = "Reminder"
        Me.barReminder.Caption = "Reminder:"
        Me.barReminder.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.barReminder.Edit = Nothing
        Me.barReminder.EditWidth = 120
        Me.barReminder.Hint = "Choose when to be reminded of this item"
        Me.barReminder.Id = 12
        Me.barReminder.Name = "barReminder"
        '
        'btnRecurrence
        '
        Me.btnRecurrence.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.btnRecurrence.Caption = "Recurrence"
        Me.btnRecurrence.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnRecurrence.Hint = "Schedule this item to repeat regularly"
        Me.btnRecurrence.Id = 17
        Me.btnRecurrence.ImageOptions.Image = CType(resources.GetObject("btnRecurrence.ImageOptions.Image"), System.Drawing.Image)
        Me.btnRecurrence.ImageOptions.LargeImage = CType(resources.GetObject("btnRecurrence.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnRecurrence.ImageOptions.SvgImage = CType(resources.GetObject("btnRecurrence.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnRecurrence.Name = "btnRecurrence"
        '
        'btnSave
        '
        Me.btnSave.Caption = "Save"
        Me.btnSave.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnSave.Id = 1
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.ImageOptions.SvgImage = CType(resources.GetObject("btnSave.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnSave.Name = "btnSave"
        '
        'btnNext
        '
        Me.btnNext.AccessibleName = "Next"
        Me.btnNext.Caption = "Next"
        Me.btnNext.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnNext.Hint = "Next Item"
        Me.btnNext.Id = 3
        Me.btnNext.ImageOptions.Image = CType(resources.GetObject("btnNext.ImageOptions.Image"), System.Drawing.Image)
        Me.btnNext.ImageOptions.LargeImage = CType(resources.GetObject("btnNext.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnNext.ImageOptions.SvgImage = CType(resources.GetObject("btnNext.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnNext.Name = "btnNext"
        '
        'btnPrevious
        '
        Me.btnPrevious.AccessibleName = "Previous"
        Me.btnPrevious.Caption = "Previous"
        Me.btnPrevious.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnPrevious.Hint = "Previous Item"
        Me.btnPrevious.Id = 4
        Me.btnPrevious.ImageOptions.Image = CType(resources.GetObject("btnPrevious.ImageOptions.Image"), System.Drawing.Image)
        Me.btnPrevious.ImageOptions.LargeImage = CType(resources.GetObject("btnPrevious.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnPrevious.ImageOptions.SvgImage = CType(resources.GetObject("btnPrevious.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnPrevious.Name = "btnPrevious"
        '
        'btnTimeZones
        '
        Me.btnTimeZones.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.btnTimeZones.Caption = "Time Zones"
        Me.btnTimeZones.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnTimeZones.Hint = "Show or hide time zone control, which you can use to specify the time zone for th" &
    "e start and end times of the appointment"
        Me.btnTimeZones.Id = 1
        Me.btnTimeZones.ImageOptions.Image = CType(resources.GetObject("btnTimeZones.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTimeZones.ImageOptions.LargeImage = CType(resources.GetObject("btnTimeZones.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnTimeZones.ImageOptions.SvgImage = CType(resources.GetObject("btnTimeZones.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnTimeZones.Name = "btnTimeZones"
        '
        'rpAppointment
        '
        Me.rpAppointment.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgActions, Me.rpgOptions})
        Me.rpAppointment.Name = "rpAppointment"
        Me.rpAppointment.Text = "Booking"
        '
        'rpgActions
        '
        Me.rpgActions.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.rpgActions.ItemLinks.Add(Me.btnSaveAndClose)
        Me.rpgActions.ItemLinks.Add(Me.btnDelete)
        Me.rpgActions.Name = "rpgActions"
        Me.rpgActions.Text = "Actions"
        '
        'rpgOptions
        '
        Me.rpgOptions.AllowTextClipping = False
        Me.rpgOptions.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.rpgOptions.ItemLinks.Add(Me.barLabel)
        Me.rpgOptions.ItemLinks.Add(Me.barStatus)
        Me.rpgOptions.ItemLinks.Add(Me.barReminder)
        Me.rpgOptions.ItemLinks.Add(Me.btnRecurrence, "C")
        Me.rpgOptions.Name = "rpgOptions"
        Me.rpgOptions.Text = "Options"
        '
        'lblSubject
        '
        Me.lblSubject.AccessibleName = "Subject"
        Me.lblSubject.Location = New System.Drawing.Point(8, 167)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(53, 13)
        Me.lblSubject.TabIndex = 13
        Me.lblSubject.Text = "Description"
        '
        'panel1
        '
        Me.panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panel1.Controls.Add(Me.edtTimeZone)
        Me.panel1.Controls.Add(Me.lblResource)
        Me.panel1.Controls.Add(Me.edtResources)
        Me.panel1.Controls.Add(Me.chkAllDay)
        Me.panel1.Location = New System.Drawing.Point(287, 184)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(207, 79)
        Me.panel1.TabIndex = 23
        '
        'edtTimeZone
        '
        Me.edtTimeZone.Location = New System.Drawing.Point(3, 58)
        Me.edtTimeZone.MenuManager = Me.ribbonControl1
        Me.edtTimeZone.Name = "edtTimeZone"
        Me.edtTimeZone.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.edtTimeZone.Size = New System.Drawing.Size(195, 20)
        Me.edtTimeZone.TabIndex = 37
        '
        'lblResource
        '
        Me.lblResource.AccessibleName = "Resource"
        Me.lblResource.Location = New System.Drawing.Point(3, 3)
        Me.lblResource.Name = "lblResource"
        Me.lblResource.Size = New System.Drawing.Size(31, 13)
        Me.lblResource.TabIndex = 0
        Me.lblResource.Text = "Room:"
        '
        'edtResources
        '
        Me.edtResources.EditValue = ""
        Me.edtResources.Location = New System.Drawing.Point(75, 3)
        Me.edtResources.Name = "edtResources"
        Me.edtResources.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        '
        '
        '
        Me.edtResources.ResourcesCheckedListBoxControl.CheckOnClick = True
        Me.edtResources.ResourcesCheckedListBoxControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.edtResources.ResourcesCheckedListBoxControl.Location = New System.Drawing.Point(0, 0)
        Me.edtResources.ResourcesCheckedListBoxControl.Name = ""
        Me.edtResources.ResourcesCheckedListBoxControl.Size = New System.Drawing.Size(200, 100)
        Me.edtResources.ResourcesCheckedListBoxControl.TabIndex = 0
        Me.edtResources.Size = New System.Drawing.Size(123, 20)
        Me.edtResources.TabIndex = 36
        '
        'chkAllDay
        '
        Me.chkAllDay.Location = New System.Drawing.Point(3, 36)
        Me.chkAllDay.Name = "chkAllDay"
        Me.chkAllDay.Properties.AccessibleName = "All day event"
        Me.chkAllDay.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton
        Me.chkAllDay.Properties.AutoWidth = True
        Me.chkAllDay.Properties.Caption = "&All day event"
        Me.chkAllDay.Size = New System.Drawing.Size(86, 20)
        Me.chkAllDay.TabIndex = 15
        '
        'tbSubject
        '
        Me.tbSubject.EditValue = ""
        Me.tbSubject.Location = New System.Drawing.Point(92, 164)
        Me.tbSubject.Name = "tbSubject"
        Me.tbSubject.Properties.AccessibleName = "Subject"
        Me.tbSubject.Size = New System.Drawing.Size(393, 20)
        Me.tbSubject.TabIndex = 14
        '
        'edtEndTime
        '
        Me.edtEndTime.EditValue = New Date(2005, 3, 31, 0, 0, 0, 0)
        Me.edtEndTime.Location = New System.Drawing.Point(193, 242)
        Me.edtEndTime.Name = "edtEndTime"
        Me.edtEndTime.Properties.AccessibleName = "End time"
        Me.edtEndTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edtEndTime.Properties.Mask.EditMask = "t"
        Me.edtEndTime.Size = New System.Drawing.Size(88, 20)
        Me.edtEndTime.TabIndex = 22
        '
        'lblLocation
        '
        Me.lblLocation.AccessibleName = "Location"
        Me.lblLocation.Location = New System.Drawing.Point(8, 194)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(44, 13)
        Me.lblLocation.TabIndex = 15
        Me.lblLocation.Text = "&Location:"
        '
        'edtEndDate
        '
        Me.edtEndDate.EditValue = New Date(2005, 3, 31, 0, 0, 0, 0)
        Me.edtEndDate.Location = New System.Drawing.Point(92, 242)
        Me.edtEndDate.Name = "edtEndDate"
        Me.edtEndDate.Properties.AccessibleName = "End date"
        Me.edtEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.edtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edtEndDate.Properties.MaxValue = New Date(4000, 1, 1, 0, 0, 0, 0)
        Me.edtEndDate.Size = New System.Drawing.Size(93, 20)
        Me.edtEndDate.TabIndex = 21
        '
        'tbLocation
        '
        Me.tbLocation.EditValue = ""
        Me.tbLocation.Location = New System.Drawing.Point(92, 190)
        Me.tbLocation.Name = "tbLocation"
        Me.tbLocation.Properties.AccessibleName = "Location"
        Me.tbLocation.Size = New System.Drawing.Size(189, 20)
        Me.tbLocation.TabIndex = 16
        '
        'lblEndTime
        '
        Me.lblEndTime.AccessibleName = "End time"
        Me.lblEndTime.Location = New System.Drawing.Point(8, 245)
        Me.lblEndTime.Name = "lblEndTime"
        Me.lblEndTime.Size = New System.Drawing.Size(45, 13)
        Me.lblEndTime.TabIndex = 20
        Me.lblEndTime.Text = "&End time:"
        '
        'lblStartTime
        '
        Me.lblStartTime.AccessibleName = "Start time"
        Me.lblStartTime.Location = New System.Drawing.Point(8, 219)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(51, 13)
        Me.lblStartTime.TabIndex = 17
        Me.lblStartTime.Text = "S&tart time:"
        '
        'edtStartTime
        '
        Me.edtStartTime.EditValue = New Date(2005, 3, 31, 0, 0, 0, 0)
        Me.edtStartTime.Location = New System.Drawing.Point(193, 216)
        Me.edtStartTime.Name = "edtStartTime"
        Me.edtStartTime.Properties.AccessibleName = "Start time"
        Me.edtStartTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edtStartTime.Properties.Mask.EditMask = "t"
        Me.edtStartTime.Size = New System.Drawing.Size(88, 20)
        Me.edtStartTime.TabIndex = 19
        '
        'edtStartDate
        '
        Me.edtStartDate.EditValue = New Date(2005, 3, 31, 0, 0, 0, 0)
        Me.edtStartDate.Location = New System.Drawing.Point(92, 216)
        Me.edtStartDate.Name = "edtStartDate"
        Me.edtStartDate.Properties.AccessibleName = "Start date"
        Me.edtStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.edtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edtStartDate.Properties.MaxValue = New Date(4000, 1, 1, 0, 0, 0, 0)
        Me.edtStartDate.Size = New System.Drawing.Size(93, 20)
        Me.edtStartDate.TabIndex = 18
        '
        'tbDescription
        '
        Me.tbDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDescription.EditValue = ""
        Me.tbDescription.Location = New System.Drawing.Point(92, 269)
        Me.tbDescription.Name = "tbDescription"
        Me.tbDescription.Properties.AccessibleName = "Message"
        Me.tbDescription.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Client
        Me.tbDescription.Size = New System.Drawing.Size(393, 97)
        Me.tbDescription.TabIndex = 25
        '
        'LabelControl1
        '
        Me.LabelControl1.AccessibleName = "End time"
        Me.LabelControl1.Location = New System.Drawing.Point(8, 270)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl1.TabIndex = 26
        Me.LabelControl1.Text = "Notes"
        '
        'CheckedListBoxControl1
        '
        Me.CheckedListBoxControl1.Location = New System.Drawing.Point(92, 372)
        Me.CheckedListBoxControl1.Name = "CheckedListBoxControl1"
        Me.CheckedListBoxControl1.Size = New System.Drawing.Size(393, 95)
        Me.CheckedListBoxControl1.TabIndex = 27
        '
        'LabelControl2
        '
        Me.LabelControl2.AccessibleName = "End time"
        Me.LabelControl2.Location = New System.Drawing.Point(8, 376)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl2.TabIndex = 28
        Me.LabelControl2.Text = "Extras"
        '
        'BookingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 485)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.CheckedListBoxControl1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.tbDescription)
        Me.Controls.Add(Me.lblSubject)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.tbSubject)
        Me.Controls.Add(Me.edtEndTime)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.edtEndDate)
        Me.Controls.Add(Me.tbLocation)
        Me.Controls.Add(Me.lblEndTime)
        Me.Controls.Add(Me.lblStartTime)
        Me.Controls.Add(Me.edtStartTime)
        Me.Controls.Add(Me.edtStartDate)
        Me.Controls.Add(Me.ribbonControl1)
        Me.Name = "BookingForm"
        Me.Ribbon = Me.ribbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Booking"
        CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.edtTimeZone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtResources.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtResources.ResourcesCheckedListBoxControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAllDay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSubject.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtEndTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtStartTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckedListBoxControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents ribbonControl1 As RibbonControl
    Private WithEvents btnSaveAndClose As DevExpress.XtraBars.BarButtonItem
    Private WithEvents btnDelete As DevExpress.XtraBars.BarButtonItem
    Private WithEvents barLabel As DevExpress.XtraBars.BarEditItem
    Private WithEvents barStatus As DevExpress.XtraBars.BarEditItem
    Private WithEvents barReminder As DevExpress.XtraBars.BarEditItem
    Private WithEvents btnRecurrence As DevExpress.XtraBars.BarButtonItem
    Private WithEvents btnSave As DevExpress.XtraBars.BarButtonItem
    Private WithEvents btnNext As DevExpress.XtraBars.BarButtonItem
    Private WithEvents btnPrevious As DevExpress.XtraBars.BarButtonItem
    Private WithEvents btnTimeZones As DevExpress.XtraBars.BarButtonItem
    Private WithEvents rpAppointment As RibbonPage
    Private WithEvents rpgActions As RibbonPageGroup
    Private WithEvents rpgOptions As RibbonPageGroup
    Protected WithEvents lblSubject As DevExpress.XtraEditors.LabelControl
    Protected WithEvents panel1 As DevExpress.XtraEditors.PanelControl
    Private WithEvents edtTimeZone As DevExpress.XtraScheduler.UI.TimeZoneEdit
    Protected WithEvents lblResource As DevExpress.XtraEditors.LabelControl
    Protected WithEvents edtResources As DevExpress.XtraScheduler.UI.AppointmentResourcesEdit
    Protected WithEvents chkAllDay As DevExpress.XtraEditors.CheckEdit
    Protected WithEvents tbSubject As DevExpress.XtraEditors.TextEdit
    Protected WithEvents edtEndTime As DevExpress.XtraEditors.TimeEdit
    Protected WithEvents lblLocation As DevExpress.XtraEditors.LabelControl
    Protected WithEvents edtEndDate As DevExpress.XtraEditors.DateEdit
    Protected WithEvents tbLocation As DevExpress.XtraEditors.TextEdit
    Protected WithEvents lblEndTime As DevExpress.XtraEditors.LabelControl
    Protected WithEvents lblStartTime As DevExpress.XtraEditors.LabelControl
    Protected WithEvents edtStartTime As DevExpress.XtraEditors.TimeEdit
    Protected WithEvents edtStartDate As DevExpress.XtraEditors.DateEdit
    Protected WithEvents tbDescription As DevExpress.XtraEditors.MemoEdit
    Protected WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CheckedListBoxControl1 As DevExpress.XtraEditors.CheckedListBoxControl
    Protected WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
End Class
