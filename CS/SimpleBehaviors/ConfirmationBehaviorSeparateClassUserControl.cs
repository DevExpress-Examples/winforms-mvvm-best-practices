using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DxSampleSimpleBehaviors {
    public partial class ConfirmationBehaviorSeparateClassUserControl : XtraUserControl {
        public ConfirmationBehaviorSeparateClassUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            CheckEdit editor = new CheckEdit();
            editor.Dock = DockStyle.Top;
            editor.Text = "Please, try to change checked state of this editor";
            editor.Parent = this;
        
            #endregion SetUp

            #region #confirmationBehaviorSeparateClass
            // UI binding for the EditValueChangingConfirmation behavior
            mvvmContext.AttachBehavior<EditValueChangingConfirmation>(editor);
            #endregion #confirmationBehaviorSeparateClass
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        public class EditValueChangingConfirmation : ConfirmationBehavior<ChangingEventArgs> {
            public EditValueChangingConfirmation()
                : base("EditValueChanging") {
            }
            protected override string GetConfirmationCaption() {
                return "EditValue changing confirmation";
            }
            protected override string GetConfirmationText() {
                return "This editor's EditValue is about to be changed. Are you sure?";
            }
        }
    }
}