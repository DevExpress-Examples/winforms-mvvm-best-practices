Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.XtraNavBar

Namespace DxSample
    Partial Public Class Form1
        Inherits Form

        Private layoutControl1 As DevExpress.XtraLayout.LayoutControl
        Private xtraUserControl1 As DevExpress.XtraEditors.XtraUserControl
        Private WithEvents navBarControl1 As NavBarControl
        Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
        Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
        Private layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem

        Public Sub New()
            InitializeComponent()
            InitializeNavBar()
        End Sub

        Private Sub InitializeNavBar()
            
           Dim group0 As NavBarGroup = navBarControl1.Groups.Add()
           group0.Expanded = True
           group0.Caption = "Simple Behaviors"
           Dim itemLink0  As NavBarItemLink = group0.AddItem()
           itemLink0.Item.Tag = GetType(DxSampleSimpleBehaviors.ConfirmationBehaviorSeparateClassUserControl)
           itemLink0.Item.Caption = "Confirmation Behavior (separate class)"
           Dim itemLink1  As NavBarItemLink = group0.AddItem()
           itemLink1.Item.Tag = GetType(DxSampleSimpleBehaviors.ConfirmationBehaviorGenericConfirmationBehaviorClassUserControl)
           itemLink1.Item.Caption = "Confirmation Behavior (generic ConfirmationBehavior class)"
           Dim itemLink2  As NavBarItemLink = group0.AddItem()
           itemLink2.Item.Tag = GetType(DxSampleSimpleBehaviors.ConfirmationBehaviorFluentAPIUserControl)
           itemLink2.Item.Caption = "Confirmation Behavior (Fluent API)"
           Dim group1 As NavBarGroup = navBarControl1.Groups.Add()
           group1.Expanded = True
           group1.Caption = "Event-To-Command Behavior"
           Dim itemLink3  As NavBarItemLink = group1.AddItem()
           itemLink3.Item.Tag = GetType(DxSampleEventToCommandBehavior.UsingCommandsWithThirdPartyControlsUserControl)
           itemLink3.Item.Caption = "Using Commands with third-party controls"
           Dim itemLink4  As NavBarItemLink = group1.AddItem()
           itemLink4.Item.Tag = GetType(DxSampleEventToCommandBehavior.UsingCommandsWithThirdPartyControlsFluentAPIUserControl)
           itemLink4.Item.Caption = "Using Commands with third-party controls (Fluent API)"
           Dim group2 As NavBarGroup = navBarControl1.Groups.Add()
           group2.Expanded = True
           group2.Caption = "Event-To-Command Behavior (Parameters&Converters)"
           Dim itemLink5  As NavBarItemLink = group2.AddItem()
           itemLink5.Item.Tag = GetType(DxSampleEventToCommandBehaviorParametersConverters.PassingParametersToCommandsUserControl)
           itemLink5.Item.Caption = "Passing parameters to Commands"
           Dim itemLink6  As NavBarItemLink = group2.AddItem()
           itemLink6.Item.Tag = GetType(DxSampleEventToCommandBehaviorParametersConverters.PassingEventArgumentsToCommandsASISUserControl)
           itemLink6.Item.Caption = "Passing event Arguments to Commands AS IS"
           Dim itemLink7  As NavBarItemLink = group2.AddItem()
           itemLink7.Item.Tag = GetType(DxSampleEventToCommandBehaviorParametersConverters.PassingEventArgumentsToCommandsViaConverterUserControl)
           itemLink7.Item.Caption = "Passing event Arguments to Commands via Converter"
           Dim group3 As NavBarGroup = navBarControl1.Groups.Add()
           group3.Expanded = True
           group3.Caption = "POCO Bindable Properties"
           Dim itemLink8  As NavBarItemLink = group3.AddItem()
           itemLink8.Item.Tag = GetType(DxSamplePOCOBindableProperties.StandardDataBindingUserControl)
           itemLink8.Item.Caption = "Standard Data-Binding"
           Dim itemLink9  As NavBarItemLink = group3.AddItem()
           itemLink9.Item.Tag = GetType(DxSamplePOCOBindableProperties.DataBindingViaMVVMContextUserControl)
           itemLink9.Item.Caption = "Data-Binding via MVVMContext"
           Dim itemLink10  As NavBarItemLink = group3.AddItem()
           itemLink10.Item.Tag = GetType(DxSamplePOCOBindableProperties.DataBindingViaMVVMContextFluentAPIUserControl)
           itemLink10.Item.Caption = "Data-Binding via MVVMContext (Fluent API)"
           Dim group4 As NavBarGroup = navBarControl1.Groups.Add()
           group4.Expanded = True
           group4.Caption = "POCO Dependencies"
           Dim itemLink11  As NavBarItemLink = group4.AddItem()
           itemLink11.Item.Tag = GetType(DxSamplePOCODependencies.SimpleDependenciesUserControl)
           itemLink11.Item.Caption = "Simple dependencies"
           Dim itemLink12  As NavBarItemLink = group4.AddItem()
           itemLink12.Item.Tag = GetType(DxSamplePOCODependencies.PropertyChangedNotificationsUserControl)
           itemLink12.Item.Caption = "PropertyChanged notifications"
           Dim group5 As NavBarGroup = navBarControl1.Groups.Add()
           group5.Expanded = True
           group5.Caption = "UI Triggers"
           Dim itemLink13  As NavBarItemLink = group5.AddItem()
           itemLink13.Item.Tag = GetType(DxSampleUITriggers.SimpleUITriggerUserControl)
           itemLink13.Item.Caption = "Simple UI Trigger"
           Dim itemLink14  As NavBarItemLink = group5.AddItem()
           itemLink14.Item.Tag = GetType(DxSampleUITriggers.SimpleUITriggerFluentAPIUserControl)
           itemLink14.Item.Caption = "Simple UI Trigger (Fluent API)"
           Dim group6 As NavBarGroup = navBarControl1.Groups.Add()
           group6.Expanded = True
           group6.Caption = "Binding to Legacy ViewModels"
           Dim itemLink15  As NavBarItemLink = group6.AddItem()
           itemLink15.Item.Tag = GetType(DxSampleBindingToLegacyViewModels.DataBindingViaMVVMContextUserControl)
           itemLink15.Item.Caption = "Data-Binding via MVVMContext"
           Dim itemLink16  As NavBarItemLink = group6.AddItem()
           itemLink16.Item.Tag = GetType(DxSampleBindingToLegacyViewModels.DataBindingViaMVVMContextFluentAPIUserControl)
           itemLink16.Item.Caption = "Data-Binding via MVVMContext (Fluent API)"
           Dim group7 As NavBarGroup = navBarControl1.Groups.Add()
           group7.Expanded = True
           group7.Caption = "Data-Binding Capabilities (Binding Path)"
           Dim itemLink17  As NavBarItemLink = group7.AddItem()
           itemLink17.Item.Tag = GetType(DxSampleDataBindingCapabilitiesBindingPath.DataBindingToNestedPropertiesUserControl)
           itemLink17.Item.Caption = "Data-Binding to Nested Properties"
           Dim itemLink18  As NavBarItemLink = group7.AddItem()
           itemLink18.Item.Tag = GetType(DxSampleDataBindingCapabilitiesBindingPath.DataBindingToNestedPropertiesFluentAPIUserControl)
           itemLink18.Item.Caption = "Data-Binding to Nested Properties (Fluent API)"
           Dim group8 As NavBarGroup = navBarControl1.Groups.Add()
           group8.Expanded = True
           group8.Caption = "Data-Binding Capabilities (Converters)"
           Dim itemLink19  As NavBarItemLink = group8.AddItem()
           itemLink19.Item.Tag = GetType(DxSampleDataBindingCapabilitiesConverters.DataBindingViaDefaultConvertersFluentAPIUserControl)
           itemLink19.Item.Caption = "Data-Binding via Default Converters (Fluent API)"
           Dim group9 As NavBarGroup = navBarControl1.Groups.Add()
           group9.Expanded = True
           group9.Caption = "Data-Binding Capabilities (Converters)"
            'Dim itemLink20  As NavBarItemLink = group9.AddItem()
            'itemLink20.Item.Tag = GetType(DxSampleDataBindingCapabilitiesConverters.DataBindingWithCustomConvertersFluentAPIUserControl)
            'itemLink20.Item.Caption = "Data-Binding with Custom Converters (Fluent API)"
           Dim group10 As NavBarGroup = navBarControl1.Groups.Add()
           group10.Expanded = True
           group10.Caption = "Delegate Commands"
           Dim itemLink21  As NavBarItemLink = group10.AddItem()
           itemLink21.Item.Tag = GetType(DxSampleDelegateCommands.SimpleCommandUserControl)
           itemLink21.Item.Caption = "Simple Command"
           Dim itemLink22  As NavBarItemLink = group10.AddItem()
           itemLink22.Item.Tag = GetType(DxSampleDelegateCommands.CommandWithCanExecuteConditionUserControl)
           itemLink22.Item.Caption = "Command with CanExecute condition"
           Dim itemLink23  As NavBarItemLink = group10.AddItem()
           itemLink23.Item.Tag = GetType(DxSampleDelegateCommands.ParameterizedCommandUserControl)
           itemLink23.Item.Caption = "Parameterized Command"
           Dim itemLink24  As NavBarItemLink = group10.AddItem()
           itemLink24.Item.Tag = GetType(DxSampleDelegateCommands.ParameterizedCommandWithCanExecuteConditionUserControl)
           itemLink24.Item.Caption = "Parameterized Command with CanExecute condition"
           Dim group11 As NavBarGroup = navBarControl1.Groups.Add()
           group11.Expanded = True
           group11.Caption = "POCO Commands"
           Dim itemLink25  As NavBarItemLink = group11.AddItem()
           itemLink25.Item.Tag = GetType(DxSamplePOCOCommands.SimpleCommandUserControl)
           itemLink25.Item.Caption = "Simple Command"
           Dim itemLink26  As NavBarItemLink = group11.AddItem()
           itemLink26.Item.Tag = GetType(DxSamplePOCOCommands.CommandWithCanExecuteConditionUserControl)
           itemLink26.Item.Caption = "Command with CanExecute condition"
           Dim itemLink27  As NavBarItemLink = group11.AddItem()
           itemLink27.Item.Tag = GetType(DxSamplePOCOCommands.ParameterizedCommandUserControl)
           itemLink27.Item.Caption = "Parameterized Command"
           Dim itemLink28  As NavBarItemLink = group11.AddItem()
           itemLink28.Item.Tag = GetType(DxSamplePOCOCommands.ParameterizedCommandWithCanExecuteConditionUserControl)
           itemLink28.Item.Caption = "Parameterized Command with CanExecute condition"
           Dim itemLink29  As NavBarItemLink = group11.AddItem()
           itemLink29.Item.Tag = GetType(DxSamplePOCOCommands.FluentAPIForCommandsUserControl)
           itemLink29.Item.Caption = "Fluent API for commands"
           Dim group12 As NavBarGroup = navBarControl1.Groups.Add()
           group12.Expanded = True
           group12.Caption = "POCO Asynchronous Commands"
           Dim itemLink30  As NavBarItemLink = group12.AddItem()
           itemLink30.Item.Tag = GetType(DxSamplePOCOAsynchronousCommands.SimpleCommandUserControl)
           itemLink30.Item.Caption = "Simple Command"
           Dim itemLink31  As NavBarItemLink = group12.AddItem()
           itemLink31.Item.Tag = GetType(DxSamplePOCOAsynchronousCommands.SimpleCommandWithCancellationUserControl)
           itemLink31.Item.Caption = "Simple Command with Cancellation"
           Dim itemLink32  As NavBarItemLink = group12.AddItem()
           itemLink32.Item.Tag = GetType(DxSamplePOCOAsynchronousCommands.FluentAPIForCommandsUserControl)
           itemLink32.Item.Caption = "Fluent API for commands"
           Dim group13 As NavBarGroup = navBarControl1.Groups.Add()
           group13.Expanded = True
           group13.Caption = "Legacy Commands"
           Dim itemLink33  As NavBarItemLink = group13.AddItem()
           itemLink33.Item.Tag = GetType(DxSampleLegacyCommands.SimpleCommandUserControl)
           itemLink33.Item.Caption = "Simple Command"
           Dim itemLink34  As NavBarItemLink = group13.AddItem()
           itemLink34.Item.Tag = GetType(DxSampleLegacyCommands.ParameterizedCommandUserControl)
           itemLink34.Item.Caption = "Parameterized Command"
           Dim group14 As NavBarGroup = navBarControl1.Groups.Add()
           group14.Expanded = True
           group14.Caption = "Messenger"
           Dim itemLink35  As NavBarItemLink = group14.AddItem()
           itemLink35.Item.Tag = GetType(DxSampleMessenger.SendingAndReceivingMessagesUserControl)
           itemLink35.Item.Caption = "Sending and receiving Messages"
           Dim itemLink36  As NavBarItemLink = group14.AddItem()
           itemLink36.Item.Tag = GetType(DxSampleMessenger.SendingAndReceivingCustomMessagesUserControl)
           itemLink36.Item.Caption = "Sending and receiving custom Messages"
           Dim itemLink37  As NavBarItemLink = group14.AddItem()
           itemLink37.Item.Tag = GetType(DxSampleMessenger.SendingAndReceivingTokenizedMessagesUserControl)
           itemLink37.Item.Caption = "Sending and receiving tokenized Messages"
           Dim group15 As NavBarGroup = navBarControl1.Groups.Add()
           group15.Expanded = True
           group15.Caption = "MessageBox Services"
           Dim itemLink38  As NavBarItemLink = group15.AddItem()
           itemLink38.Item.Tag = GetType(DxSampleMessageBoxServices.MessageBoxServiceUserControl)
           itemLink38.Item.Caption = "MessageBox Service"
           Dim itemLink39  As NavBarItemLink = group15.AddItem()
           itemLink39.Item.Tag = GetType(DxSampleMessageBoxServices.XtraMessageBoxServiceUserControl)
           itemLink39.Item.Caption = "XtraMessageBox Service"
           Dim itemLink40  As NavBarItemLink = group15.AddItem()
           itemLink40.Item.Tag = GetType(DxSampleMessageBoxServices.FlyoutMessageBoxServiceUserControl)
           itemLink40.Item.Caption = "FlyoutMessageBox Service"
           Dim group16 As NavBarGroup = navBarControl1.Groups.Add()
           group16.Expanded = True
           group16.Caption = "Dialog Services"
           Dim itemLink41  As NavBarItemLink = group16.AddItem()
           itemLink41.Item.Tag = GetType(DxSampleDialogServices.XtraDialogServiceUserControl)
           itemLink41.Item.Caption = "XtraDialog Service"
           Dim itemLink42  As NavBarItemLink = group16.AddItem()
           itemLink42.Item.Tag = GetType(DxSampleDialogServices.FlyoutDialogServiceUserControl)
           itemLink42.Item.Caption = "FlyoutDialog Service"
           Dim itemLink43  As NavBarItemLink = group16.AddItem()
           itemLink43.Item.Tag = GetType(DxSampleDialogServices.RibbonDialogServiceUserControl)
           itemLink43.Item.Caption = "RibbonDialog Service"
           Dim group17 As NavBarGroup = navBarControl1.Groups.Add()
           group17.Expanded = True
           group17.Caption = "Custom Services"
           Dim itemLink44  As NavBarItemLink = group17.AddItem()
           itemLink44.Item.Tag = GetType(DxSampleCustomServices.CustomServiceUserControl)
           itemLink44.Item.Caption = "Custom Service"
           Dim itemLink45  As NavBarItemLink = group17.AddItem()
           itemLink45.Item.Tag = GetType(DxSampleCustomServices.CustomServiceWithKeyUserControl)
           itemLink45.Item.Caption = "Custom Service with Key"
        End Sub
        Private Sub navBarControl1_LinkClicked(ByVal sender As Object, ByVal e As NavBarLinkEventArgs) Handles navBarControl1.LinkClicked
            If xtraUserControl1.Controls.Count = 1 Then
                xtraUserControl1.Controls(0).Dispose()
            End If
            xtraUserControl1.Controls.Clear()
            Dim userControl As Control = TryCast(Activator.CreateInstance(TryCast(e.Link.Item.Tag, Type)), Control)
            userControl.Dock = DockStyle.Fill
            userControl.Parent = xtraUserControl1
        End Sub
        Private Sub InitializeComponent()
            Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
            Me.xtraUserControl1 = New DevExpress.XtraEditors.XtraUserControl()
            Me.navBarControl1 = New DevExpress.XtraNavBar.NavBarControl()
            Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
            Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
            CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.layoutControl1.SuspendLayout()
            CType(Me.navBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'layoutControl1
            '
            Me.layoutControl1.Controls.Add(Me.xtraUserControl1)
            Me.layoutControl1.Controls.Add(Me.navBarControl1)
            Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
            Me.layoutControl1.Name = "layoutControl1"
            Me.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1010, 245, 450, 350)
            Me.layoutControl1.Root = Me.layoutControlGroup1
            Me.layoutControl1.Size = New System.Drawing.Size(775, 419)
            Me.layoutControl1.TabIndex = 0
            Me.layoutControl1.Text = "layoutControl1"
            '
            'xtraUserControl1
            '
            Me.xtraUserControl1.Location = New System.Drawing.Point(210, 12)
            Me.xtraUserControl1.Name = "xtraUserControl1"
            Me.xtraUserControl1.Size = New System.Drawing.Size(553, 395)
            Me.xtraUserControl1.TabIndex = 5
            '
            'navBarControl1
            '
            Me.navBarControl1.ActiveGroup = Nothing
            Me.navBarControl1.Location = New System.Drawing.Point(12, 12)
            Me.navBarControl1.Name = "navBarControl1"
            Me.navBarControl1.OptionsNavPane.ExpandedWidth = 194
            Me.navBarControl1.Size = New System.Drawing.Size(194, 395)
            Me.navBarControl1.TabIndex = 4
            Me.navBarControl1.Text = "navBarControl1"
            '
            'layoutControlGroup1
            '
            Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
            Me.layoutControlGroup1.GroupBordersVisible = False
            Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutControlItem1, Me.layoutControlItem2})
            Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
            Me.layoutControlGroup1.Name = "Root"
            Me.layoutControlGroup1.Size = New System.Drawing.Size(775, 419)
            Me.layoutControlGroup1.TextVisible = False
            '
            'layoutControlItem1
            '
            Me.layoutControlItem1.Control = Me.navBarControl1
            Me.layoutControlItem1.Location = New System.Drawing.Point(0, 0)
            Me.layoutControlItem1.Name = "layoutControlItem1"
            Me.layoutControlItem1.Size = New System.Drawing.Size(198, 399)
            Me.layoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
            Me.layoutControlItem1.TextVisible = False
            '
            'layoutControlItem2
            '
            Me.layoutControlItem2.Control = Me.xtraUserControl1
            Me.layoutControlItem2.Location = New System.Drawing.Point(198, 0)
            Me.layoutControlItem2.MinSize = New System.Drawing.Size(5, 5)
            Me.layoutControlItem2.Name = "layoutControlItem2"
            Me.layoutControlItem2.Size = New System.Drawing.Size(557, 399)
            Me.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
            Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
            Me.layoutControlItem2.TextVisible = False
            '
            'Form1
            '
            Me.ClientSize = New System.Drawing.Size(775, 419)
            Me.Controls.Add(Me.layoutControl1)
            Me.Name = "Form1"
            CType(Me.layoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.layoutControl1.ResumeLayout(False)
            CType(Me.navBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace
