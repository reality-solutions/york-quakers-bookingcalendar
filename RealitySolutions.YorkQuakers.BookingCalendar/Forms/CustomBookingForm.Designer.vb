Imports DevExpress.XtraScheduler.UI
Partial Class CustomBookingForm

#Region "Designer generated code"
    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomBookingForm))
        Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.backstageViewControl1 = New DevExpress.XtraBars.Ribbon.BackstageViewControl()
        Me.bvPrint = New DevExpress.XtraBars.Ribbon.BackstageViewClientControl()
        Me.appointmentBackstageControl = New DevExpress.XtraScheduler.Design.AppointmentBackstageControl()
        Me.bvtPrint = New DevExpress.XtraBars.Ribbon.BackstageViewTabItem()
        Me.bvbSave = New DevExpress.XtraBars.Ribbon.BackstageViewButtonItem()
        Me.bvbSaveAs = New DevExpress.XtraBars.Ribbon.BackstageViewButtonItem()
        Me.bvbClose = New DevExpress.XtraBars.Ribbon.BackstageViewButtonItem()
        Me.btnSaveAndClose = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.barLabel = New DevExpress.XtraBars.BarEditItem()
        Me.riAppointmentLabel = New DevExpress.XtraScheduler.UI.RepositoryItemAppointmentLabel()
        Me.barStatus = New DevExpress.XtraBars.BarEditItem()
        Me.riAppointmentStatus = New DevExpress.XtraScheduler.UI.RepositoryItemAppointmentStatus()
        Me.barReminder = New DevExpress.XtraBars.BarEditItem()
        Me.riDuration = New DevExpress.XtraScheduler.UI.RepositoryItemDuration()
        Me.btnRecurrence = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSave = New DevExpress.XtraBars.BarButtonItem()
        Me.btnNext = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPrevious = New DevExpress.XtraBars.BarButtonItem()
        Me.btnTimeZones = New DevExpress.XtraBars.BarButtonItem()
        Me.PostInvoiceBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.SendEmailBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.CancelBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.PostInvoiceBar2ButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.rpAppointment = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgActions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.riAppointmentResource = New DevExpress.XtraScheduler.UI.RepositoryItemAppointmentResource()
        Me.lblStartTime = New DevExpress.XtraEditors.LabelControl()
        Me.edtStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.tbLocation = New DevExpress.XtraEditors.TextEdit()
        Me.edtStartTime = New DevExpress.XtraEditors.TimeEdit()
        Me.lblEndTime = New DevExpress.XtraEditors.LabelControl()
        Me.edtEndDate = New DevExpress.XtraEditors.DateEdit()
        Me.edtEndTime = New DevExpress.XtraEditors.TimeEdit()
        Me.lblLocation = New DevExpress.XtraEditors.LabelControl()
        Me.panel1 = New DevExpress.XtraEditors.PanelControl()
        Me.edtTimeZone = New DevExpress.XtraScheduler.UI.TimeZoneEdit()
        Me.edtResources = New DevExpress.XtraScheduler.UI.AppointmentResourcesEdit()
        Me.chkAllDay = New DevExpress.XtraEditors.CheckEdit()
        Me.lblResource = New DevExpress.XtraEditors.LabelControl()
        Me.edtResource = New DevExpress.XtraScheduler.UI.AppointmentResourceEdit()
        Me.tbSubject = New DevExpress.XtraEditors.TextEdit()
        Me.lblSubject = New DevExpress.XtraEditors.LabelControl()
        Me.panelMain = New System.Windows.Forms.Panel()
        Me.tbDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.panelDescription = New System.Windows.Forms.Panel()
        Me.topPanel = New System.Windows.Forms.Panel()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.ProgressPanel1 = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.chkTC = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.txtInvoicingEmail = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.RoomsGridControl = New DevExpress.XtraGrid.GridControl()
        Me.RoomsGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.BookingRefTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.chkEmail = New DevExpress.XtraEditors.CheckEdit()
        Me.txtContactEmail = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.chkInvoice = New DevExpress.XtraEditors.CheckEdit()
        Me.AccountLookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtInvoiceNo = New DevExpress.XtraEditors.TextEdit()
        Me.bottomPanel = New System.Windows.Forms.Panel()
        Me.ExtrasGrid = New DevExpress.XtraGrid.GridControl()
        Me.ExtrasGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tbInvoiceNotes = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.CostTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem6 = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.backstageViewControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.backstageViewControl1.SuspendLayout()
        Me.bvPrint.SuspendLayout()
        CType(Me.riAppointmentLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.riAppointmentStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.riDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.riAppointmentResource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtStartTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtEndTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        CType(Me.edtTimeZone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtResources.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtResources.ResourcesCheckedListBoxControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAllDay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtResource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSubject.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.topPanel.SuspendLayout()
        CType(Me.chkTC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInvoicingEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RoomsGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RoomsGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BookingRefTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContactEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkInvoice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccountLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInvoiceNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bottomPanel.SuspendLayout()
        CType(Me.ExtrasGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExtrasGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbInvoiceNotes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CostTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ribbonControl1
        '
        Me.ribbonControl1.ApplicationButtonDropDownControl = Me.backstageViewControl1
        Me.ribbonControl1.AutoSizeItems = True
        Me.ribbonControl1.ExpandCollapseItem.Id = 0
        Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbonControl1.ExpandCollapseItem, Me.ribbonControl1.SearchEditItem, Me.btnSaveAndClose, Me.btnDelete, Me.barLabel, Me.barStatus, Me.barReminder, Me.btnRecurrence, Me.btnSave, Me.btnNext, Me.btnPrevious, Me.btnTimeZones, Me.PostInvoiceBarButtonItem, Me.SendEmailBarButtonItem, Me.CancelBarButtonItem, Me.PostInvoiceBar2ButtonItem})
        resources.ApplyResources(Me.ribbonControl1, "ribbonControl1")
        Me.ribbonControl1.MaxItemId = 7
        Me.ribbonControl1.Name = "ribbonControl1"
        Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rpAppointment})
        Me.ribbonControl1.QuickToolbarItemLinks.Add(Me.btnSave)
        Me.ribbonControl1.QuickToolbarItemLinks.Add(Me.btnPrevious)
        Me.ribbonControl1.QuickToolbarItemLinks.Add(Me.btnNext)
        Me.ribbonControl1.QuickToolbarItemLinks.Add(Me.btnDelete)
        Me.ribbonControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.riAppointmentLabel, Me.riAppointmentResource, Me.riAppointmentStatus, Me.riDuration})
        Me.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013
        '
        'backstageViewControl1
        '
        resources.ApplyResources(Me.backstageViewControl1, "backstageViewControl1")
        Me.backstageViewControl1.Controls.Add(Me.bvPrint)
        Me.backstageViewControl1.Items.Add(Me.bvtPrint)
        Me.backstageViewControl1.Items.Add(Me.bvbSave)
        Me.backstageViewControl1.Items.Add(Me.bvbSaveAs)
        Me.backstageViewControl1.Items.Add(Me.bvbClose)
        Me.backstageViewControl1.Name = "backstageViewControl1"
        Me.backstageViewControl1.Office2013StyleOptions.HeaderBackColor = System.Drawing.SystemColors.Control
        Me.backstageViewControl1.OwnerControl = Me.ribbonControl1
        Me.backstageViewControl1.SelectedTab = Me.bvtPrint
        Me.backstageViewControl1.SelectedTabIndex = 0
        Me.backstageViewControl1.Style = DevExpress.XtraBars.Ribbon.BackstageViewStyle.Office2013
        '
        'bvPrint
        '
        resources.ApplyResources(Me.bvPrint, "bvPrint")
        Me.bvPrint.Controls.Add(Me.appointmentBackstageControl)
        Me.bvPrint.Name = "bvPrint"
        '
        'appointmentBackstageControl
        '
        resources.ApplyResources(Me.appointmentBackstageControl, "appointmentBackstageControl")
        Me.appointmentBackstageControl.Name = "appointmentBackstageControl"
        '
        'bvtPrint
        '
        resources.ApplyResources(Me.bvtPrint, "bvtPrint")
        Me.bvtPrint.ContentControl = Me.bvPrint
        Me.bvtPrint.Name = "bvtPrint"
        Me.bvtPrint.Selected = True
        '
        'bvbSave
        '
        resources.ApplyResources(Me.bvbSave, "bvbSave")
        Me.bvbSave.Name = "bvbSave"
        '
        'bvbSaveAs
        '
        resources.ApplyResources(Me.bvbSaveAs, "bvbSaveAs")
        Me.bvbSaveAs.Name = "bvbSaveAs"
        '
        'bvbClose
        '
        resources.ApplyResources(Me.bvbClose, "bvbClose")
        Me.bvbClose.Name = "bvbClose"
        '
        'btnSaveAndClose
        '
        resources.ApplyResources(Me.btnSaveAndClose, "btnSaveAndClose")
        Me.btnSaveAndClose.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnSaveAndClose.Id = 3
        Me.btnSaveAndClose.ImageOptions.Image = CType(resources.GetObject("btnSaveAndClose.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSaveAndClose.ImageOptions.LargeImage = CType(resources.GetObject("btnSaveAndClose.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnSaveAndClose.ImageOptions.SvgImage = CType(resources.GetObject("btnSaveAndClose.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnSaveAndClose.Name = "btnSaveAndClose"
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnDelete.Id = 4
        Me.btnDelete.ImageOptions.Image = CType(resources.GetObject("btnDelete.ImageOptions.Image"), System.Drawing.Image)
        Me.btnDelete.ImageOptions.LargeImage = CType(resources.GetObject("btnDelete.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnDelete.ImageOptions.SvgImage = CType(resources.GetObject("btnDelete.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'barLabel
        '
        resources.ApplyResources(Me.barLabel, "barLabel")
        Me.barLabel.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.barLabel.Edit = Me.riAppointmentLabel
        Me.barLabel.Id = 8
        Me.barLabel.Name = "barLabel"
        Me.barLabel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'riAppointmentLabel
        '
        resources.ApplyResources(Me.riAppointmentLabel, "riAppointmentLabel")
        Me.riAppointmentLabel.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("riAppointmentLabel.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.riAppointmentLabel.Name = "riAppointmentLabel"
        '
        'barStatus
        '
        resources.ApplyResources(Me.barStatus, "barStatus")
        Me.barStatus.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.barStatus.Edit = Me.riAppointmentStatus
        Me.barStatus.Id = 11
        Me.barStatus.Name = "barStatus"
        Me.barStatus.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'riAppointmentStatus
        '
        resources.ApplyResources(Me.riAppointmentStatus, "riAppointmentStatus")
        Me.riAppointmentStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("riAppointmentStatus.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.riAppointmentStatus.Name = "riAppointmentStatus"
        '
        'barReminder
        '
        resources.ApplyResources(Me.barReminder, "barReminder")
        Me.barReminder.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.barReminder.Edit = Me.riDuration
        Me.barReminder.Id = 12
        Me.barReminder.Name = "barReminder"
        Me.barReminder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'riDuration
        '
        resources.ApplyResources(Me.riDuration, "riDuration")
        Me.riDuration.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("riDuration.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.riDuration.DisabledStateText = Nothing
        Me.riDuration.Name = "riDuration"
        Me.riDuration.ShowEmptyItem = True
        '
        'btnRecurrence
        '
        Me.btnRecurrence.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        resources.ApplyResources(Me.btnRecurrence, "btnRecurrence")
        Me.btnRecurrence.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnRecurrence.Id = 17
        Me.btnRecurrence.ImageOptions.Image = CType(resources.GetObject("btnRecurrence.ImageOptions.Image"), System.Drawing.Image)
        Me.btnRecurrence.ImageOptions.LargeImage = CType(resources.GetObject("btnRecurrence.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnRecurrence.ImageOptions.SvgImage = CType(resources.GetObject("btnRecurrence.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnRecurrence.Name = "btnRecurrence"
        '
        'btnSave
        '
        resources.ApplyResources(Me.btnSave, "btnSave")
        Me.btnSave.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnSave.Id = 1
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.ImageOptions.SvgImage = CType(resources.GetObject("btnSave.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnNext
        '
        resources.ApplyResources(Me.btnNext, "btnNext")
        Me.btnNext.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnNext.Id = 3
        Me.btnNext.ImageOptions.Image = CType(resources.GetObject("btnNext.ImageOptions.Image"), System.Drawing.Image)
        Me.btnNext.ImageOptions.LargeImage = CType(resources.GetObject("btnNext.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnNext.ImageOptions.SvgImage = CType(resources.GetObject("btnNext.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnPrevious
        '
        resources.ApplyResources(Me.btnPrevious, "btnPrevious")
        Me.btnPrevious.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnPrevious.Id = 4
        Me.btnPrevious.ImageOptions.Image = CType(resources.GetObject("btnPrevious.ImageOptions.Image"), System.Drawing.Image)
        Me.btnPrevious.ImageOptions.LargeImage = CType(resources.GetObject("btnPrevious.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnPrevious.ImageOptions.SvgImage = CType(resources.GetObject("btnPrevious.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnTimeZones
        '
        Me.btnTimeZones.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        resources.ApplyResources(Me.btnTimeZones, "btnTimeZones")
        Me.btnTimeZones.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnTimeZones.Id = 1
        Me.btnTimeZones.ImageOptions.Image = CType(resources.GetObject("btnTimeZones.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTimeZones.ImageOptions.LargeImage = CType(resources.GetObject("btnTimeZones.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnTimeZones.ImageOptions.SvgImage = CType(resources.GetObject("btnTimeZones.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnTimeZones.Name = "btnTimeZones"
        Me.btnTimeZones.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'PostInvoiceBarButtonItem
        '
        resources.ApplyResources(Me.PostInvoiceBarButtonItem, "PostInvoiceBarButtonItem")
        Me.PostInvoiceBarButtonItem.Enabled = False
        Me.PostInvoiceBarButtonItem.Id = 3
        Me.PostInvoiceBarButtonItem.ImageOptions.Image = CType(resources.GetObject("PostInvoiceBarButtonItem.ImageOptions.Image"), System.Drawing.Image)
        Me.PostInvoiceBarButtonItem.ImageOptions.LargeImage = CType(resources.GetObject("PostInvoiceBarButtonItem.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.PostInvoiceBarButtonItem.Name = "PostInvoiceBarButtonItem"
        '
        'SendEmailBarButtonItem
        '
        resources.ApplyResources(Me.SendEmailBarButtonItem, "SendEmailBarButtonItem")
        Me.SendEmailBarButtonItem.Enabled = False
        Me.SendEmailBarButtonItem.Id = 4
        Me.SendEmailBarButtonItem.ImageOptions.Image = CType(resources.GetObject("SendEmailBarButtonItem.ImageOptions.Image"), System.Drawing.Image)
        Me.SendEmailBarButtonItem.ImageOptions.LargeImage = CType(resources.GetObject("SendEmailBarButtonItem.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.SendEmailBarButtonItem.Name = "SendEmailBarButtonItem"
        '
        'CancelBarButtonItem
        '
        resources.ApplyResources(Me.CancelBarButtonItem, "CancelBarButtonItem")
        Me.CancelBarButtonItem.Enabled = False
        Me.CancelBarButtonItem.Id = 5
        Me.CancelBarButtonItem.ImageOptions.Image = CType(resources.GetObject("CancelBarButtonItem.ImageOptions.Image"), System.Drawing.Image)
        Me.CancelBarButtonItem.ImageOptions.LargeImage = CType(resources.GetObject("CancelBarButtonItem.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.CancelBarButtonItem.Name = "CancelBarButtonItem"
        Me.CancelBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'PostInvoiceBar2ButtonItem
        '
        resources.ApplyResources(Me.PostInvoiceBar2ButtonItem, "PostInvoiceBar2ButtonItem")
        Me.PostInvoiceBar2ButtonItem.Enabled = False
        Me.PostInvoiceBar2ButtonItem.Id = 6
        Me.PostInvoiceBar2ButtonItem.ImageOptions.Image = CType(resources.GetObject("PostInvoiceBar2ButtonItem.ImageOptions.Image"), System.Drawing.Image)
        Me.PostInvoiceBar2ButtonItem.ImageOptions.LargeImage = CType(resources.GetObject("PostInvoiceBar2ButtonItem.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.PostInvoiceBar2ButtonItem.Name = "PostInvoiceBar2ButtonItem"
        '
        'rpAppointment
        '
        Me.rpAppointment.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgActions, Me.rpgOptions})
        Me.rpAppointment.Name = "rpAppointment"
        resources.ApplyResources(Me.rpAppointment, "rpAppointment")
        '
        'rpgActions
        '
        Me.rpgActions.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.rpgActions.ItemLinks.Add(Me.btnSaveAndClose)
        Me.rpgActions.ItemLinks.Add(Me.btnDelete)
        Me.rpgActions.ItemLinks.Add(Me.PostInvoiceBarButtonItem)
        Me.rpgActions.ItemLinks.Add(Me.SendEmailBarButtonItem)
        Me.rpgActions.ItemLinks.Add(Me.CancelBarButtonItem)
        Me.rpgActions.ItemLinks.Add(Me.PostInvoiceBar2ButtonItem)
        Me.rpgActions.Name = "rpgActions"
        resources.ApplyResources(Me.rpgActions, "rpgActions")
        '
        'rpgOptions
        '
        Me.rpgOptions.AllowTextClipping = False
        Me.rpgOptions.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.rpgOptions.ItemLinks.Add(Me.barLabel)
        Me.rpgOptions.ItemLinks.Add(Me.barStatus)
        Me.rpgOptions.ItemLinks.Add(Me.barReminder)
        Me.rpgOptions.ItemLinks.Add(Me.btnRecurrence, "C")
        Me.rpgOptions.ItemLinks.Add(Me.btnTimeZones)
        Me.rpgOptions.Name = "rpgOptions"
        resources.ApplyResources(Me.rpgOptions, "rpgOptions")
        '
        'riAppointmentResource
        '
        resources.ApplyResources(Me.riAppointmentResource, "riAppointmentResource")
        Me.riAppointmentResource.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("riAppointmentResource.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.riAppointmentResource.Name = "riAppointmentResource"
        '
        'lblStartTime
        '
        resources.ApplyResources(Me.lblStartTime, "lblStartTime")
        Me.lblStartTime.Name = "lblStartTime"
        '
        'edtStartDate
        '
        resources.ApplyResources(Me.edtStartDate, "edtStartDate")
        Me.edtStartDate.Name = "edtStartDate"
        Me.edtStartDate.Properties.AccessibleName = resources.GetString("edtStartDate.Properties.AccessibleName")
        Me.edtStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("edtStartDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.edtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edtStartDate.Properties.MaxValue = New Date(4000, 1, 1, 0, 0, 0, 0)
        '
        'tbLocation
        '
        resources.ApplyResources(Me.tbLocation, "tbLocation")
        Me.tbLocation.Name = "tbLocation"
        Me.tbLocation.Properties.AccessibleName = resources.GetString("tbLocation.Properties.AccessibleName")
        '
        'edtStartTime
        '
        resources.ApplyResources(Me.edtStartTime, "edtStartTime")
        Me.edtStartTime.Name = "edtStartTime"
        Me.edtStartTime.Properties.AccessibleName = resources.GetString("edtStartTime.Properties.AccessibleName")
        Me.edtStartTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edtStartTime.Properties.Mask.EditMask = resources.GetString("edtStartTime.Properties.Mask.EditMask")
        '
        'lblEndTime
        '
        resources.ApplyResources(Me.lblEndTime, "lblEndTime")
        Me.lblEndTime.Name = "lblEndTime"
        '
        'edtEndDate
        '
        resources.ApplyResources(Me.edtEndDate, "edtEndDate")
        Me.edtEndDate.Name = "edtEndDate"
        Me.edtEndDate.Properties.AccessibleName = resources.GetString("edtEndDate.Properties.AccessibleName")
        Me.edtEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("edtEndDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.edtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edtEndDate.Properties.MaxValue = New Date(4000, 1, 1, 0, 0, 0, 0)
        '
        'edtEndTime
        '
        resources.ApplyResources(Me.edtEndTime, "edtEndTime")
        Me.edtEndTime.Name = "edtEndTime"
        Me.edtEndTime.Properties.AccessibleName = resources.GetString("edtEndTime.Properties.AccessibleName")
        Me.edtEndTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edtEndTime.Properties.Mask.EditMask = resources.GetString("edtEndTime.Properties.Mask.EditMask")
        '
        'lblLocation
        '
        resources.ApplyResources(Me.lblLocation, "lblLocation")
        Me.lblLocation.Name = "lblLocation"
        '
        'panel1
        '
        resources.ApplyResources(Me.panel1, "panel1")
        Me.panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panel1.Controls.Add(Me.edtTimeZone)
        Me.panel1.Controls.Add(Me.edtResources)
        Me.panel1.Controls.Add(Me.chkAllDay)
        Me.panel1.Name = "panel1"
        '
        'edtTimeZone
        '
        resources.ApplyResources(Me.edtTimeZone, "edtTimeZone")
        Me.edtTimeZone.MenuManager = Me.ribbonControl1
        Me.edtTimeZone.Name = "edtTimeZone"
        Me.edtTimeZone.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("edtTimeZone.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'edtResources
        '
        resources.ApplyResources(Me.edtResources, "edtResources")
        Me.edtResources.Name = "edtResources"
        Me.edtResources.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("edtResources.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        '
        '
        Me.edtResources.ResourcesCheckedListBoxControl.CheckOnClick = True
        Me.edtResources.ResourcesCheckedListBoxControl.Dock = CType(resources.GetObject("edtResources.ResourcesCheckedListBoxControl.Dock"), System.Windows.Forms.DockStyle)
        Me.edtResources.ResourcesCheckedListBoxControl.Location = CType(resources.GetObject("edtResources.ResourcesCheckedListBoxControl.Location"), System.Drawing.Point)
        Me.edtResources.ResourcesCheckedListBoxControl.Name = ""
        Me.edtResources.ResourcesCheckedListBoxControl.Size = CType(resources.GetObject("edtResources.ResourcesCheckedListBoxControl.Size"), System.Drawing.Size)
        Me.edtResources.ResourcesCheckedListBoxControl.TabIndex = CType(resources.GetObject("edtResources.ResourcesCheckedListBoxControl.TabIndex"), Integer)
        '
        'chkAllDay
        '
        resources.ApplyResources(Me.chkAllDay, "chkAllDay")
        Me.chkAllDay.Name = "chkAllDay"
        Me.chkAllDay.Properties.AccessibleName = resources.GetString("chkAllDay.Properties.AccessibleName")
        Me.chkAllDay.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton
        Me.chkAllDay.Properties.AutoWidth = True
        Me.chkAllDay.Properties.Caption = resources.GetString("chkAllDay.Properties.Caption")
        '
        'lblResource
        '
        resources.ApplyResources(Me.lblResource, "lblResource")
        Me.lblResource.Name = "lblResource"
        '
        'edtResource
        '
        resources.ApplyResources(Me.edtResource, "edtResource")
        Me.edtResource.Name = "edtResource"
        Me.edtResource.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox
        Me.edtResource.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("edtResource.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'tbSubject
        '
        resources.ApplyResources(Me.tbSubject, "tbSubject")
        Me.tbSubject.Name = "tbSubject"
        Me.tbSubject.Properties.AccessibleName = resources.GetString("tbSubject.Properties.AccessibleName")
        '
        'lblSubject
        '
        resources.ApplyResources(Me.lblSubject, "lblSubject")
        Me.lblSubject.Name = "lblSubject"
        '
        'panelMain
        '
        resources.ApplyResources(Me.panelMain, "panelMain")
        Me.panelMain.Name = "panelMain"
        '
        'tbDescription
        '
        resources.ApplyResources(Me.tbDescription, "tbDescription")
        Me.tbDescription.Name = "tbDescription"
        Me.tbDescription.Properties.AccessibleName = resources.GetString("tbDescription.Properties.AccessibleName")
        Me.tbDescription.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Client
        '
        'panelDescription
        '
        resources.ApplyResources(Me.panelDescription, "panelDescription")
        Me.panelDescription.Name = "panelDescription"
        '
        'topPanel
        '
        Me.topPanel.Controls.Add(Me.SimpleButton1)
        Me.topPanel.Controls.Add(Me.ProgressPanel1)
        Me.topPanel.Controls.Add(Me.chkTC)
        Me.topPanel.Controls.Add(Me.LabelControl9)
        Me.topPanel.Controls.Add(Me.txtInvoicingEmail)
        Me.topPanel.Controls.Add(Me.LabelControl7)
        Me.topPanel.Controls.Add(Me.RoomsGridControl)
        Me.topPanel.Controls.Add(Me.LabelControl6)
        Me.topPanel.Controls.Add(Me.lblResource)
        Me.topPanel.Controls.Add(Me.BookingRefTextEdit)
        Me.topPanel.Controls.Add(Me.edtResource)
        Me.topPanel.Controls.Add(Me.chkEmail)
        Me.topPanel.Controls.Add(Me.txtContactEmail)
        Me.topPanel.Controls.Add(Me.LabelControl5)
        Me.topPanel.Controls.Add(Me.chkInvoice)
        Me.topPanel.Controls.Add(Me.AccountLookUpEdit)
        Me.topPanel.Controls.Add(Me.LabelControl4)
        Me.topPanel.Controls.Add(Me.LabelControl3)
        Me.topPanel.Controls.Add(Me.txtInvoiceNo)
        Me.topPanel.Controls.Add(Me.lblSubject)
        Me.topPanel.Controls.Add(Me.panel1)
        Me.topPanel.Controls.Add(Me.tbSubject)
        Me.topPanel.Controls.Add(Me.edtEndTime)
        Me.topPanel.Controls.Add(Me.lblLocation)
        Me.topPanel.Controls.Add(Me.edtEndDate)
        Me.topPanel.Controls.Add(Me.tbLocation)
        Me.topPanel.Controls.Add(Me.lblEndTime)
        Me.topPanel.Controls.Add(Me.lblStartTime)
        Me.topPanel.Controls.Add(Me.edtStartTime)
        Me.topPanel.Controls.Add(Me.edtStartDate)
        resources.ApplyResources(Me.topPanel, "topPanel")
        Me.topPanel.Name = "topPanel"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.SimpleButton1, "SimpleButton1")
        Me.SimpleButton1.Name = "SimpleButton1"
        '
        'ProgressPanel1
        '
        Me.ProgressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ProgressPanel1.Appearance.Options.UseBackColor = True
        Me.ProgressPanel1.BarAnimationElementThickness = 2
        resources.ApplyResources(Me.ProgressPanel1, "ProgressPanel1")
        Me.ProgressPanel1.Name = "ProgressPanel1"
        '
        'chkTC
        '
        resources.ApplyResources(Me.chkTC, "chkTC")
        Me.chkTC.MenuManager = Me.ribbonControl1
        Me.chkTC.Name = "chkTC"
        Me.chkTC.Properties.Caption = resources.GetString("chkTC.Properties.Caption")
        '
        'LabelControl9
        '
        resources.ApplyResources(Me.LabelControl9, "LabelControl9")
        Me.LabelControl9.Name = "LabelControl9"
        '
        'txtInvoicingEmail
        '
        resources.ApplyResources(Me.txtInvoicingEmail, "txtInvoicingEmail")
        Me.txtInvoicingEmail.Name = "txtInvoicingEmail"
        Me.txtInvoicingEmail.Properties.AccessibleName = resources.GetString("txtInvoicingEmail.Properties.AccessibleName")
        '
        'LabelControl7
        '
        resources.ApplyResources(Me.LabelControl7, "LabelControl7")
        Me.LabelControl7.Name = "LabelControl7"
        '
        'RoomsGridControl
        '
        resources.ApplyResources(Me.RoomsGridControl, "RoomsGridControl")
        Me.RoomsGridControl.MainView = Me.RoomsGridView
        Me.RoomsGridControl.MenuManager = Me.ribbonControl1
        Me.RoomsGridControl.Name = "RoomsGridControl"
        Me.RoomsGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.RoomsGridView})
        '
        'RoomsGridView
        '
        Me.RoomsGridView.GridControl = Me.RoomsGridControl
        Me.RoomsGridView.Name = "RoomsGridView"
        Me.RoomsGridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.RoomsGridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.RoomsGridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace
        Me.RoomsGridView.OptionsCustomization.AllowColumnMoving = False
        Me.RoomsGridView.OptionsCustomization.AllowColumnResizing = False
        Me.RoomsGridView.OptionsCustomization.AllowFilter = False
        Me.RoomsGridView.OptionsCustomization.AllowGroup = False
        Me.RoomsGridView.OptionsCustomization.AllowSort = False
        Me.RoomsGridView.OptionsView.ShowGroupPanel = False
        Me.RoomsGridView.OptionsView.ShowIndicator = False
        '
        'LabelControl6
        '
        resources.ApplyResources(Me.LabelControl6, "LabelControl6")
        Me.LabelControl6.Name = "LabelControl6"
        '
        'BookingRefTextEdit
        '
        resources.ApplyResources(Me.BookingRefTextEdit, "BookingRefTextEdit")
        Me.BookingRefTextEdit.Name = "BookingRefTextEdit"
        Me.BookingRefTextEdit.Properties.AccessibleName = resources.GetString("BookingRefTextEdit.Properties.AccessibleName")
        '
        'chkEmail
        '
        resources.ApplyResources(Me.chkEmail, "chkEmail")
        Me.chkEmail.MenuManager = Me.ribbonControl1
        Me.chkEmail.Name = "chkEmail"
        Me.chkEmail.Properties.Caption = resources.GetString("chkEmail.Properties.Caption")
        '
        'txtContactEmail
        '
        resources.ApplyResources(Me.txtContactEmail, "txtContactEmail")
        Me.txtContactEmail.Name = "txtContactEmail"
        Me.txtContactEmail.Properties.AccessibleName = resources.GetString("txtContactEmail.Properties.AccessibleName")
        '
        'LabelControl5
        '
        resources.ApplyResources(Me.LabelControl5, "LabelControl5")
        Me.LabelControl5.Name = "LabelControl5"
        '
        'chkInvoice
        '
        resources.ApplyResources(Me.chkInvoice, "chkInvoice")
        Me.chkInvoice.MenuManager = Me.ribbonControl1
        Me.chkInvoice.Name = "chkInvoice"
        Me.chkInvoice.Properties.Caption = resources.GetString("chkInvoice.Properties.Caption")
        '
        'AccountLookUpEdit
        '
        resources.ApplyResources(Me.AccountLookUpEdit, "AccountLookUpEdit")
        Me.AccountLookUpEdit.MenuManager = Me.ribbonControl1
        Me.AccountLookUpEdit.Name = "AccountLookUpEdit"
        Me.AccountLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("AccountLookUpEdit.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.AccountLookUpEdit.Properties.NullText = resources.GetString("AccountLookUpEdit.Properties.NullText")
        '
        'LabelControl4
        '
        resources.ApplyResources(Me.LabelControl4, "LabelControl4")
        Me.LabelControl4.Name = "LabelControl4"
        '
        'LabelControl3
        '
        resources.ApplyResources(Me.LabelControl3, "LabelControl3")
        Me.LabelControl3.Name = "LabelControl3"
        '
        'txtInvoiceNo
        '
        resources.ApplyResources(Me.txtInvoiceNo, "txtInvoiceNo")
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Properties.AccessibleName = resources.GetString("txtInvoiceNo.Properties.AccessibleName")
        '
        'bottomPanel
        '
        Me.bottomPanel.Controls.Add(Me.ExtrasGrid)
        Me.bottomPanel.Controls.Add(Me.tbInvoiceNotes)
        Me.bottomPanel.Controls.Add(Me.LabelControl8)
        Me.bottomPanel.Controls.Add(Me.PanelControl1)
        Me.bottomPanel.Controls.Add(Me.LabelControl1)
        Me.bottomPanel.Controls.Add(Me.tbDescription)
        resources.ApplyResources(Me.bottomPanel, "bottomPanel")
        Me.bottomPanel.Name = "bottomPanel"
        '
        'ExtrasGrid
        '
        resources.ApplyResources(Me.ExtrasGrid, "ExtrasGrid")
        Me.ExtrasGrid.MainView = Me.ExtrasGridView
        Me.ExtrasGrid.MenuManager = Me.ribbonControl1
        Me.ExtrasGrid.Name = "ExtrasGrid"
        Me.ExtrasGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ExtrasGridView})
        '
        'ExtrasGridView
        '
        Me.ExtrasGridView.GridControl = Me.ExtrasGrid
        Me.ExtrasGridView.Name = "ExtrasGridView"
        Me.ExtrasGridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ExtrasGridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ExtrasGridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace
        Me.ExtrasGridView.OptionsCustomization.AllowColumnMoving = False
        Me.ExtrasGridView.OptionsCustomization.AllowColumnResizing = False
        Me.ExtrasGridView.OptionsCustomization.AllowFilter = False
        Me.ExtrasGridView.OptionsCustomization.AllowGroup = False
        Me.ExtrasGridView.OptionsCustomization.AllowSort = False
        Me.ExtrasGridView.OptionsView.ShowGroupPanel = False
        Me.ExtrasGridView.OptionsView.ShowIndicator = False
        '
        'tbInvoiceNotes
        '
        resources.ApplyResources(Me.tbInvoiceNotes, "tbInvoiceNotes")
        Me.tbInvoiceNotes.Name = "tbInvoiceNotes"
        Me.tbInvoiceNotes.Properties.AccessibleName = resources.GetString("tbInvoiceNotes.Properties.AccessibleName")
        Me.tbInvoiceNotes.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Client
        '
        'LabelControl8
        '
        resources.ApplyResources(Me.LabelControl8, "LabelControl8")
        Me.LabelControl8.Name = "LabelControl8"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.CostTextEdit)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        resources.ApplyResources(Me.PanelControl1, "PanelControl1")
        Me.PanelControl1.Name = "PanelControl1"
        '
        'CostTextEdit
        '
        resources.ApplyResources(Me.CostTextEdit, "CostTextEdit")
        Me.CostTextEdit.MenuManager = Me.ribbonControl1
        Me.CostTextEdit.Name = "CostTextEdit"
        Me.CostTextEdit.Properties.ReadOnly = True
        '
        'LabelControl2
        '
        resources.ApplyResources(Me.LabelControl2, "LabelControl2")
        Me.LabelControl2.Name = "LabelControl2"
        '
        'LabelControl1
        '
        resources.ApplyResources(Me.LabelControl1, "LabelControl1")
        Me.LabelControl1.Name = "LabelControl1"
        '
        'BarButtonItem1
        '
        resources.ApplyResources(Me.BarButtonItem1, "BarButtonItem1")
        Me.BarButtonItem1.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BarButtonItem1.Id = 4
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonItem2
        '
        resources.ApplyResources(Me.BarButtonItem2, "BarButtonItem2")
        Me.BarButtonItem2.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BarButtonItem2.Id = 4
        Me.BarButtonItem2.ImageOptions.Image = CType(resources.GetObject("BarButtonItem2.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem2.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem2.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem2.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonItem2.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonItem2.Name = "BarButtonItem2"
        Me.BarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonItem4
        '
        resources.ApplyResources(Me.BarButtonItem4, "BarButtonItem4")
        Me.BarButtonItem4.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.BarButtonItem4.Id = 4
        Me.BarButtonItem4.ImageOptions.Image = CType(resources.GetObject("BarButtonItem4.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem4.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem4.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem4.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonItem4.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonItem4.Name = "BarButtonItem4"
        Me.BarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonItem3
        '
        resources.ApplyResources(Me.BarButtonItem3, "BarButtonItem3")
        Me.BarButtonItem3.Enabled = False
        Me.BarButtonItem3.Id = 3
        Me.BarButtonItem3.ImageOptions.Image = CType(resources.GetObject("BarButtonItem3.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem3.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem3.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'BarButtonItem6
        '
        resources.ApplyResources(Me.BarButtonItem6, "BarButtonItem6")
        Me.BarButtonItem6.Enabled = False
        Me.BarButtonItem6.Id = 3
        Me.BarButtonItem6.ImageOptions.Image = CType(resources.GetObject("BarButtonItem6.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem6.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem6.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem6.Name = "BarButtonItem6"
        '
        'CustomBookingForm
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.bottomPanel)
        Me.Controls.Add(Me.topPanel)
        Me.Controls.Add(Me.backstageViewControl1)
        Me.Controls.Add(Me.ribbonControl1)
        Me.MaximizeBox = False
        Me.Name = "CustomBookingForm"
        Me.Ribbon = Me.ribbonControl1
        Me.ShowInTaskbar = False
        CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.backstageViewControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.backstageViewControl1.ResumeLayout(False)
        Me.bvPrint.ResumeLayout(False)
        CType(Me.riAppointmentLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.riAppointmentStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.riDuration, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.riAppointmentResource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtStartTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtEndTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.edtTimeZone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtResources.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtResources.ResourcesCheckedListBoxControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAllDay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtResource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSubject.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.topPanel.ResumeLayout(False)
        Me.topPanel.PerformLayout()
        CType(Me.chkTC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInvoicingEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RoomsGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RoomsGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BookingRefTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContactEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkInvoice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccountLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInvoiceNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bottomPanel.ResumeLayout(False)
        Me.bottomPanel.PerformLayout()
        CType(Me.ExtrasGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExtrasGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbInvoiceNotes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.CostTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private components As System.ComponentModel.IContainer = Nothing
    Private WithEvents ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Private rpAppointment As DevExpress.XtraBars.Ribbon.RibbonPage
    Private rpgActions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Private rpgOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Private WithEvents btnSaveAndClose As DevExpress.XtraBars.BarButtonItem
    Private WithEvents btnDelete As DevExpress.XtraBars.BarButtonItem
    Private barLabel As DevExpress.XtraBars.BarEditItem
    Private riAppointmentLabel As RepositoryItemAppointmentLabel
    Private riAppointmentResource As RepositoryItemAppointmentResource
    Private barStatus As DevExpress.XtraBars.BarEditItem
    Private riAppointmentStatus As RepositoryItemAppointmentStatus
    Private barReminder As DevExpress.XtraBars.BarEditItem
    Private riDuration As RepositoryItemDuration
    Private WithEvents btnRecurrence As DevExpress.XtraBars.BarButtonItem
    Protected lblStartTime As DevExpress.XtraEditors.LabelControl
    Protected edtStartDate As DevExpress.XtraEditors.DateEdit
    Protected tbLocation As DevExpress.XtraEditors.TextEdit
    Protected edtStartTime As DevExpress.XtraEditors.TimeEdit
    Protected lblEndTime As DevExpress.XtraEditors.LabelControl
    Protected edtEndDate As DevExpress.XtraEditors.DateEdit
    Protected edtEndTime As DevExpress.XtraEditors.TimeEdit
    Protected lblLocation As DevExpress.XtraEditors.LabelControl
    Protected panel1 As DevExpress.XtraEditors.PanelControl
    Protected lblResource As DevExpress.XtraEditors.LabelControl
    Protected edtResource As AppointmentResourceEdit
    Protected edtResources As AppointmentResourcesEdit
    Protected chkAllDay As DevExpress.XtraEditors.CheckEdit
    Protected tbSubject As DevExpress.XtraEditors.TextEdit
    Protected lblSubject As DevExpress.XtraEditors.LabelControl
    Private panelMain As System.Windows.Forms.Panel
    Protected tbDescription As DevExpress.XtraEditors.MemoEdit
    Private panelDescription As System.Windows.Forms.Panel
    Private topPanel As System.Windows.Forms.Panel
    Private bottomPanel As System.Windows.Forms.Panel
    Private backstageViewControl1 As DevExpress.XtraBars.Ribbon.BackstageViewControl
    Private WithEvents bvbSave As DevExpress.XtraBars.Ribbon.BackstageViewButtonItem
    Private WithEvents bvbSaveAs As DevExpress.XtraBars.Ribbon.BackstageViewButtonItem
    Private WithEvents bvbClose As DevExpress.XtraBars.Ribbon.BackstageViewButtonItem
    Private WithEvents btnSave As DevExpress.XtraBars.BarButtonItem
    Private WithEvents btnNext As DevExpress.XtraBars.BarButtonItem
    Private WithEvents btnPrevious As DevExpress.XtraBars.BarButtonItem
    Private WithEvents btnTimeZones As DevExpress.XtraBars.BarButtonItem
    Private edtTimeZone As TimeZoneEdit
    Private bvPrint As DevExpress.XtraBars.Ribbon.BackstageViewClientControl
    Private bvtPrint As DevExpress.XtraBars.Ribbon.BackstageViewTabItem
    Private WithEvents appointmentBackstageControl As DevExpress.XtraScheduler.Design.AppointmentBackstageControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CostTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Protected WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PostInvoiceBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Private WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Private WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Private WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SendEmailBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents chkEmail As DevExpress.XtraEditors.CheckEdit
    Protected WithEvents txtContactEmail As DevExpress.XtraEditors.TextEdit
    Protected WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkInvoice As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents AccountLookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Protected WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Protected WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Protected WithEvents txtInvoiceNo As DevExpress.XtraEditors.TextEdit
    Protected WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Protected WithEvents BookingRefTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ProgressPanel1 As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents ExtrasGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents ExtrasGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Protected WithEvents tbInvoiceNotes As DevExpress.XtraEditors.MemoEdit
    Protected WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RoomsGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents RoomsGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Protected WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Protected WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Protected WithEvents txtInvoicingEmail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CancelBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PostInvoiceBar2ButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem6 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents chkTC As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class