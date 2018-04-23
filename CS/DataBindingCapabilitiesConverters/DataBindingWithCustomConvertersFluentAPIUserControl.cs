using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DxSampleDataBindingCapabilitiesConverters {
    public partial class DataBindingWithCustomConvertersFluentAPIUserControl : XtraUserControl {
        public DataBindingWithCustomConvertersFluentAPIUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            CheckEdit check = new CheckEdit();
            check.Dock = DockStyle.Top;
            check.Properties.AllowGrayed = true;
        
            SimpleButton commandButton = new SimpleButton();
            commandButton.Dock = DockStyle.Top;
            commandButton.Text = "Report the ModelState property value";
        
            check.Parent = this;
            commandButton.Parent = this;
            #endregion SetUp

            #region #dataBindingWithCustomConvertersFluentAPI
            // Set type of POCO-ViewModel
            mvvmContext.ViewModelType = typeof(ViewModel);
            // Data binding for the ModelState property (via MVVMContext FluentAPI)
            var fluent = mvvmContext.OfType<ViewModel>();
            fluent.SetBinding(check, e => e.CheckState, x => x.ModelState,
                modelState =>
                {
                    // Convert the ViewModel.State to CheckState
                    switch(modelState) {
                        case ViewModel.State.Active:
                            return CheckState.Checked;
                        case ViewModel.State.Inactive:
                            return CheckState.Unchecked;
                        default:
                            return CheckState.Indeterminate;
                    }
                },
                checkState =>
                {
                    // Convert back from CheckState to the ViewModel.State
                    switch(checkState) {
                        case CheckState.Checked:
                            return ViewModel.State.Active;
                        case CheckState.Unchecked:
                            return ViewModel.State.Inactive;
                        default:
                            return ViewModel.State.Suspended;
                    }
                });
            fluent.SetBinding(check, e => e.Text, x => x.ModelState, modelState =>
                string.Format("Click to change the current ViewModel state from {0} to {1}", modelState, (ViewModel.State)((1 + (int)modelState) % 3)));
            // UI binding for the Report command
            fluent.BindCommand(commandButton, x => x.ReportState());
            #endregion #dataBindingWithCustomConvertersFluentAPI
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        public class ViewModel {
            public virtual State ModelState { get; set; }
            public enum State {
                Suspended = 0,
                Inactive = 1,
                Active = 2
            }
            public void ReportState() {
                this.GetService<IMessageBoxService>().ShowMessage(ModelState.ToString());
            }
        }
    }
}