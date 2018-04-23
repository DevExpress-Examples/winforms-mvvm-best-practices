using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DxSampleSimpleBehaviors {
    public partial class ConfirmationBehaviorGenericConfirmationBehaviorClassUserControl : XtraUserControl {
        public ConfirmationBehaviorGenericConfirmationBehaviorClassUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            CheckEdit editor = new CheckEdit();
            editor.Dock = DockStyle.Top;
            editor.Text = "Please, try to change checked state of this editor";
            editor.Parent = this;
        
            #endregion SetUp

            #region #confirmationBehaviorGenericConfirmationBehaviorClass
            // UI binding for the generic ConfirmationBehavior behavior with some specific parameters
            mvvmContext.AttachBehavior<ConfirmationBehavior<ChangingEventArgs>>(editor,
                behavior =>
                {
                    behavior.Caption = "CheckEdit State changing";
                    behavior.Text = "This checkEdit's checked-state is about to be changed. Are you sure?";
                    behavior.Buttons = ConfirmationButtons.YesNo;
                    behavior.ShowQuestionIcon = true;
                }, "EditValueChanging");
            #endregion #confirmationBehaviorGenericConfirmationBehaviorClass
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
    }
}