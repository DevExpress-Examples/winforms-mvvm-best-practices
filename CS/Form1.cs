using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraNavBar;

namespace DxSample {
    public partial class Form1 :Form {
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.XtraUserControl xtraUserControl1;
        private NavBarControl navBarControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;

        public Form1() {
            InitializeComponent();
            InitializeNavBar();
        }

        private void InitializeNavBar() {
            
           NavBarGroup group0 = navBarControl1.Groups.Add();
           group0.Expanded = true;
           group0.Caption = "POCO Bindable Properties";
           NavBarItemLink itemLink0 = group0.AddItem();
           itemLink0.Item.Tag = typeof(DxSamplePOCOBindableProperties.StandardDataBindingUserControl);
           itemLink0.Item.Caption = "Standard Data-Binding";
           NavBarItemLink itemLink1 = group0.AddItem();
           itemLink1.Item.Tag = typeof(DxSamplePOCOBindableProperties.DataBindingViaMVVMContextUserControl);
           itemLink1.Item.Caption = "Data-Binding via MVVMContext";
           NavBarItemLink itemLink2 = group0.AddItem();
           itemLink2.Item.Tag = typeof(DxSamplePOCOBindableProperties.DataBindingViaMVVMContextFluentAPIUserControl);
           itemLink2.Item.Caption = "Data-Binding via MVVMContext (Fluent API)";
           NavBarGroup group1 = navBarControl1.Groups.Add();
           group1.Expanded = true;
           group1.Caption = "POCO Dependencies";
           NavBarItemLink itemLink3 = group1.AddItem();
           itemLink3.Item.Tag = typeof(DxSamplePOCODependencies.SimpleDependenciesUserControl);
           itemLink3.Item.Caption = "Simple dependencies";
           NavBarItemLink itemLink4 = group1.AddItem();
           itemLink4.Item.Tag = typeof(DxSamplePOCODependencies.PropertyChangedNotificationsUserControl);
           itemLink4.Item.Caption = "PropertyChanged notifications";
           NavBarGroup group2 = navBarControl1.Groups.Add();
           group2.Expanded = true;
           group2.Caption = "UI Triggers";
           NavBarItemLink itemLink5 = group2.AddItem();
           itemLink5.Item.Tag = typeof(DxSampleUITriggers.SimpleUITriggerUserControl);
           itemLink5.Item.Caption = "Simple UI Trigger";
           NavBarItemLink itemLink6 = group2.AddItem();
           itemLink6.Item.Tag = typeof(DxSampleUITriggers.SimpleUITriggerFluentAPIUserControl);
           itemLink6.Item.Caption = "Simple UI Trigger (Fluent API)";
           NavBarGroup group3 = navBarControl1.Groups.Add();
           group3.Expanded = true;
           group3.Caption = "Binding to Legacy ViewModels";
           NavBarItemLink itemLink7 = group3.AddItem();
           itemLink7.Item.Tag = typeof(DxSampleBindingToLegacyViewModels.DataBindingViaMVVMContextUserControl);
           itemLink7.Item.Caption = "Data-Binding via MVVMContext";
           NavBarItemLink itemLink8 = group3.AddItem();
           itemLink8.Item.Tag = typeof(DxSampleBindingToLegacyViewModels.DataBindingViaMVVMContextFluentAPIUserControl);
           itemLink8.Item.Caption = "Data-Binding via MVVMContext (Fluent API)";
           NavBarGroup group4 = navBarControl1.Groups.Add();
           group4.Expanded = true;
           group4.Caption = "Data-Binding Capabilities (Binding Path)";
           NavBarItemLink itemLink9 = group4.AddItem();
           itemLink9.Item.Tag = typeof(DxSampleDataBindingCapabilitiesBindingPath.DataBindingToNestedPropertiesUserControl);
           itemLink9.Item.Caption = "Data-Binding to Nested Properties";
           NavBarItemLink itemLink10 = group4.AddItem();
           itemLink10.Item.Tag = typeof(DxSampleDataBindingCapabilitiesBindingPath.DataBindingToNestedPropertiesFluentAPIUserControl);
           itemLink10.Item.Caption = "Data-Binding to Nested Properties (Fluent API)";
           NavBarGroup group5 = navBarControl1.Groups.Add();
           group5.Expanded = true;
           group5.Caption = "Data-Binding Capabilities (Converters)";
           NavBarItemLink itemLink11 = group5.AddItem();
           itemLink11.Item.Tag = typeof(DxSampleDataBindingCapabilitiesConverters.DataBindingViaDefaultConvertersFluentAPIUserControl);
           itemLink11.Item.Caption = "Data-Binding via Default Converters (Fluent API)";
           NavBarGroup group6 = navBarControl1.Groups.Add();
           group6.Expanded = true;
           group6.Caption = "Data-Binding Capabilities (Converters)";
           NavBarItemLink itemLink12 = group6.AddItem();
           itemLink12.Item.Tag = typeof(DxSampleDataBindingCapabilitiesConverters.DataBindingWithCustomConvertersFluentAPIUserControl);
           itemLink12.Item.Caption = "Data-Binding with Custom Converters (Fluent API)";
           NavBarGroup group7 = navBarControl1.Groups.Add();
           group7.Expanded = true;
           group7.Caption = "Delegate Commands";
           NavBarItemLink itemLink13 = group7.AddItem();
           itemLink13.Item.Tag = typeof(DxSampleDelegateCommands.SimpleCommandUserControl);
           itemLink13.Item.Caption = "Simple Command";
           NavBarItemLink itemLink14 = group7.AddItem();
           itemLink14.Item.Tag = typeof(DxSampleDelegateCommands.CommandWithCanExecuteConditionUserControl);
           itemLink14.Item.Caption = "Command with CanExecute condition";
           NavBarItemLink itemLink15 = group7.AddItem();
           itemLink15.Item.Tag = typeof(DxSampleDelegateCommands.ParameterizedCommandUserControl);
           itemLink15.Item.Caption = "Parameterized Command";
           NavBarItemLink itemLink16 = group7.AddItem();
           itemLink16.Item.Tag = typeof(DxSampleDelegateCommands.ParameterizedCommandWithCanExecuteConditionUserControl);
           itemLink16.Item.Caption = "Parameterized Command with CanExecute condition";
           NavBarGroup group8 = navBarControl1.Groups.Add();
           group8.Expanded = true;
           group8.Caption = "POCO Commands";
           NavBarItemLink itemLink17 = group8.AddItem();
           itemLink17.Item.Tag = typeof(DxSamplePOCOCommands.SimpleCommandUserControl);
           itemLink17.Item.Caption = "Simple Command";
           NavBarItemLink itemLink18 = group8.AddItem();
           itemLink18.Item.Tag = typeof(DxSamplePOCOCommands.CommandWithCanExecuteConditionUserControl);
           itemLink18.Item.Caption = "Command with CanExecute condition";
           NavBarItemLink itemLink19 = group8.AddItem();
           itemLink19.Item.Tag = typeof(DxSamplePOCOCommands.ParameterizedCommandUserControl);
           itemLink19.Item.Caption = "Parameterized Command";
           NavBarItemLink itemLink20 = group8.AddItem();
           itemLink20.Item.Tag = typeof(DxSamplePOCOCommands.ParameterizedCommandWithCanExecuteConditionUserControl);
           itemLink20.Item.Caption = "Parameterized Command with CanExecute condition";
           NavBarItemLink itemLink21 = group8.AddItem();
           itemLink21.Item.Tag = typeof(DxSamplePOCOCommands.FluentAPIForCommandsUserControl);
           itemLink21.Item.Caption = "Fluent API for commands";
           NavBarGroup group9 = navBarControl1.Groups.Add();
           group9.Expanded = true;
           group9.Caption = "POCO Asynchronous Commands";
           NavBarItemLink itemLink22 = group9.AddItem();
           itemLink22.Item.Tag = typeof(DxSamplePOCOAsynchronousCommands.SimpleCommandUserControl);
           itemLink22.Item.Caption = "Simple Command";
           NavBarItemLink itemLink23 = group9.AddItem();
           itemLink23.Item.Tag = typeof(DxSamplePOCOAsynchronousCommands.SimpleCommandWithCancellationUserControl);
           itemLink23.Item.Caption = "Simple Command with Cancellation";
           NavBarItemLink itemLink24 = group9.AddItem();
           itemLink24.Item.Tag = typeof(DxSamplePOCOAsynchronousCommands.FluentAPIForCommandsUserControl);
           itemLink24.Item.Caption = "Fluent API for commands";
           NavBarGroup group10 = navBarControl1.Groups.Add();
           group10.Expanded = true;
           group10.Caption = "Legacy Commands";
           NavBarItemLink itemLink25 = group10.AddItem();
           itemLink25.Item.Tag = typeof(DxSampleLegacyCommands.SimpleCommandUserControl);
           itemLink25.Item.Caption = "Simple Command";
           NavBarItemLink itemLink26 = group10.AddItem();
           itemLink26.Item.Tag = typeof(DxSampleLegacyCommands.ParameterizedCommandUserControl);
           itemLink26.Item.Caption = "Parameterized Command";
           NavBarGroup group11 = navBarControl1.Groups.Add();
           group11.Expanded = true;
           group11.Caption = "MessageBox Services";
           NavBarItemLink itemLink27 = group11.AddItem();
           itemLink27.Item.Tag = typeof(DxSampleMessageBoxServices.MessageBoxServiceUserControl);
           itemLink27.Item.Caption = "MessageBox Service";
           NavBarItemLink itemLink28 = group11.AddItem();
           itemLink28.Item.Tag = typeof(DxSampleMessageBoxServices.XtraMessageBoxServiceUserControl);
           itemLink28.Item.Caption = "XtraMessageBox Service";
           NavBarItemLink itemLink29 = group11.AddItem();
           itemLink29.Item.Tag = typeof(DxSampleMessageBoxServices.FlyoutMessageBoxServiceUserControl);
           itemLink29.Item.Caption = "FlyoutMessageBox Service";
           NavBarGroup group12 = navBarControl1.Groups.Add();
           group12.Expanded = true;
           group12.Caption = "Dialog Services";
           NavBarItemLink itemLink30 = group12.AddItem();
           itemLink30.Item.Tag = typeof(DxSampleDialogServices.XtraDialogServiceUserControl);
           itemLink30.Item.Caption = "XtraDialog Service";
           NavBarItemLink itemLink31 = group12.AddItem();
           itemLink31.Item.Tag = typeof(DxSampleDialogServices.FlyoutDialogServiceUserControl);
           itemLink31.Item.Caption = "FlyoutDialog Service";
           NavBarItemLink itemLink32 = group12.AddItem();
           itemLink32.Item.Tag = typeof(DxSampleDialogServices.RibbonDialogServiceUserControl);
           itemLink32.Item.Caption = "RibbonDialog Service";
           NavBarGroup group13 = navBarControl1.Groups.Add();
           group13.Expanded = true;
           group13.Caption = "Custom Services";
           NavBarItemLink itemLink33 = group13.AddItem();
           itemLink33.Item.Tag = typeof(DxSampleCustomServices.CustomServiceUserControl);
           itemLink33.Item.Caption = "Custom Service";
           NavBarItemLink itemLink34 = group13.AddItem();
           itemLink34.Item.Tag = typeof(DxSampleCustomServices.CustomServiceWithKeyUserControl);
           itemLink34.Item.Caption = "Custom Service with Key";
           NavBarGroup group14 = navBarControl1.Groups.Add();
           group14.Expanded = true;
           group14.Caption = "Simple Behaviors";
           NavBarItemLink itemLink35 = group14.AddItem();
           itemLink35.Item.Tag = typeof(DxSampleSimpleBehaviors.ConfirmationBehaviorSeparateClassUserControl);
           itemLink35.Item.Caption = "Confirmation Behavior (separate class)";
           NavBarItemLink itemLink36 = group14.AddItem();
           itemLink36.Item.Tag = typeof(DxSampleSimpleBehaviors.ConfirmationBehaviorGenericConfirmationBehaviorClassUserControl);
           itemLink36.Item.Caption = "Confirmation Behavior (generic ConfirmationBehavior class)";
           NavBarItemLink itemLink37 = group14.AddItem();
           itemLink37.Item.Tag = typeof(DxSampleSimpleBehaviors.ConfirmationBehaviorFluentAPIUserControl);
           itemLink37.Item.Caption = "Confirmation Behavior (Fluent API)";
           NavBarGroup group15 = navBarControl1.Groups.Add();
           group15.Expanded = true;
           group15.Caption = "Event-To-Command Behavior";
           NavBarItemLink itemLink38 = group15.AddItem();
           itemLink38.Item.Tag = typeof(DxSampleEventToCommandBehavior.UsingCommandsWithThirdPartyControlsUserControl);
           itemLink38.Item.Caption = "Using Commands with third-party controls";
           NavBarItemLink itemLink39 = group15.AddItem();
           itemLink39.Item.Tag = typeof(DxSampleEventToCommandBehavior.UsingCommandsWithThirdPartyControlsFluentAPIUserControl);
           itemLink39.Item.Caption = "Using Commands with third-party controls (Fluent API)";
           NavBarGroup group16 = navBarControl1.Groups.Add();
           group16.Expanded = true;
           group16.Caption = "Event-To-Command Behavior (Parameters&Converters)";
           NavBarItemLink itemLink40 = group16.AddItem();
           itemLink40.Item.Tag = typeof(DxSampleEventToCommandBehaviorParametersConverters.PassingParametersToCommandsUserControl);
           itemLink40.Item.Caption = "Passing parameters to Commands";
           NavBarItemLink itemLink41 = group16.AddItem();
           itemLink41.Item.Tag = typeof(DxSampleEventToCommandBehaviorParametersConverters.PassingEventArgumentsToCommandsASISUserControl);
           itemLink41.Item.Caption = "Passing event Arguments to Commands AS IS";
           NavBarItemLink itemLink42 = group16.AddItem();
           itemLink42.Item.Tag = typeof(DxSampleEventToCommandBehaviorParametersConverters.PassingEventArgumentsToCommandsViaConverterUserControl);
           itemLink42.Item.Caption = "Passing event Arguments to Commands via Converter";
           NavBarGroup group17 = navBarControl1.Groups.Add();
           group17.Expanded = true;
           group17.Caption = "Messenger";
           NavBarItemLink itemLink43 = group17.AddItem();
           itemLink43.Item.Tag = typeof(DxSampleMessenger.SendingAndReceivingMessagesUserControl);
           itemLink43.Item.Caption = "Sending and receiving Messages";
           NavBarItemLink itemLink44 = group17.AddItem();
           itemLink44.Item.Tag = typeof(DxSampleMessenger.SendingAndReceivingCustomMessagesUserControl);
           itemLink44.Item.Caption = "Sending and receiving custom Messages";
           NavBarItemLink itemLink45 = group17.AddItem();
           itemLink45.Item.Tag = typeof(DxSampleMessenger.SendingAndReceivingTokenizedMessagesUserControl);
           itemLink45.Item.Caption = "Sending and receiving tokenized Messages";
        }
        private void navBarControl1_LinkClicked(object sender, NavBarLinkEventArgs e) {
            if(xtraUserControl1.Controls.Count == 1)  xtraUserControl1.Controls[0].Dispose();
            xtraUserControl1.Controls.Clear();
            Control userControl = Activator.CreateInstance(e.Link.Item.Tag as Type) as Control;
            userControl.Dock = DockStyle.Fill;
            userControl.Parent = xtraUserControl1;
        }
        private void InitializeComponent() {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.xtraUserControl1 = new DevExpress.XtraEditors.XtraUserControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.xtraUserControl1);
            this.layoutControl1.Controls.Add(this.navBarControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(775, 419);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // xtraUserControl1
            // 
            this.xtraUserControl1.Location = new System.Drawing.Point(298, 12);
            this.xtraUserControl1.Name = "xtraUserControl1";
            this.xtraUserControl1.Size = new System.Drawing.Size(465, 395);
            this.xtraUserControl1.TabIndex = 5;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = null;
            this.navBarControl1.Location = new System.Drawing.Point(12, 12);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 282;
            this.navBarControl1.Size = new System.Drawing.Size(282, 395);
            this.navBarControl1.TabIndex = 4;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarControl1_LinkClicked);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(775, 419);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.navBarControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(286, 399);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.xtraUserControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(286, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(469, 399);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(775, 419);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
