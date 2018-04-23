using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DxSampleUITriggers {
    public partial class SimpleUITriggerUserControl : XtraUserControl {
        public SimpleUITriggerUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            CheckEdit checkEdit = new CheckEdit();
            checkEdit.Dock = DockStyle.Top;
            checkEdit.Text = "IsActive";
        
            LabelControl label = new LabelControl();
            label.Dock = DockStyle.Top;
            label.AutoSizeMode = LabelAutoSizeMode.Vertical;
            label.Text = "Inactive";
        
            label.Parent = this;
            checkEdit.Parent = this;
            #endregion SetUp

            #region #simpleUITrigger
            // Set type of POCO-ViewModel
            mvvmContext.ViewModelType = typeof(UIViewModel);
            // Data binding for the IsActive property
            mvvmContext.SetBinding<CheckEdit, UIViewModel, bool>(checkEdit, c => c.Checked, x => x.IsActive);
            // Property-change Trigger for the IsActive property
            mvvmContext.SetTrigger<UIViewModel, bool>(x => x.IsActive, (active) =>
            {
                label.Text = active ? "Active" : "Inactive";
            });
            #endregion #simpleUITrigger
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        // 
        // We will track the IsActive property changing in UI
        // 
        public class UIViewModel {
            public virtual bool IsActive { get; set; }
        }
    }
}