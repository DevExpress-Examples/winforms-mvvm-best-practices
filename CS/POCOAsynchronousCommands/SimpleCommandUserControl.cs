using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxSamplePOCOAsynchronousCommands {
    public partial class SimpleCommandUserControl : XtraUserControl {
        public SimpleCommandUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            ProgressBarControl progressBar = new ProgressBarControl();
            progressBar.Dock = DockStyle.Top;
        
            SimpleButton commandButton = new SimpleButton();
            commandButton.Text = "Start Command Execution";
            commandButton.Dock = DockStyle.Top;
        
            SimpleButton cancelButton = new SimpleButton();
            cancelButton.Text = "Cancel Command Execution";
            cancelButton.Dock = DockStyle.Top;
        
            cancelButton.Parent = this;
            commandButton.Parent = this;
            progressBar.Parent = this;
            #endregion SetUp

            #region #simpleCommand
            cancelButton.Visible = false;
            progressBar.Visible = false;
            //
            mvvmContext.ViewModelType = typeof(ViewModelWithAsyncCommand);
            // UI binding for button
            mvvmContext.BindCommand<ViewModelWithAsyncCommand>(commandButton, x => x.DoSomethingAsynchronously());
            #endregion #simpleCommand
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        public class ViewModelWithAsyncCommand {
            // Asynchronous POCO-command will be created from this method.
            public Task DoSomethingAsynchronously() {
                return Task.Factory.StartNew(() =>
                {
                    System.Threading.Thread.Sleep(1000); // do some work here
                });
            }
        }
    }
}