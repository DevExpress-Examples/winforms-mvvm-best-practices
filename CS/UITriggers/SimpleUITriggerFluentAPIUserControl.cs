using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DxSampleUITriggers {
    public partial class SimpleUITriggerFluentAPIUserControl : XtraUserControl {
        public SimpleUITriggerFluentAPIUserControl() {
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

            #region #simpleUITriggerFluentAPI
            // Set type of POCO-ViewModel
            mvvmContext.ViewModelType = typeof(UIViewModel);
            // Data binding for the IsActive property
            var fluentAPI = mvvmContext.OfType<UIViewModel>();
            fluentAPI.SetBinding(checkEdit, c => c.Checked, x => x.IsActive);
            // Property-change Trigger for the IsActive property
            fluentAPI.SetTrigger(x => x.IsActive, (active) =>
            {
                label.Text = active ? "Active" : "Inactive";
            });
            #endregion #simpleUITriggerFluentAPI
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