using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxSamplePOCOAsynchronousCommands {
    public partial class FluentAPIForCommandsUserControl : XtraUserControl {
        public FluentAPIForCommandsUserControl() {
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

            #region #fluentAPIForCommands
            mvvmContext.ViewModelType = typeof(ViewModelWithAsyncCommandAndCancellation);
            var fluentAPI = mvvmContext.OfType<ViewModelWithAsyncCommandAndCancellation>();
            // UI binding for button
            fluentAPI.BindCommand(commandButton, x => x.DoSomethingAsynchronously());
            // UI binding for cancelation
            fluentAPI.BindCancelCommand(cancelButton, x => x.DoSomethingAsynchronously());
            // UI binding for progress
            fluentAPI.SetBinding(progressBar, p => p.EditValue, x => x.Progress);
            #endregion #fluentAPIForCommands
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        public class ViewModelWithAsyncCommandAndCancellation {
            // Asynchronous POCO-command will be created from this method.
            public Task DoSomethingAsynchronously() {
                return Task.Factory.StartNew(() =>
                {
                    var asyncCommand = this.GetAsyncCommand(x => x.DoSomethingAsynchronously());
                    for(int i = 0; i <= 100; i++) {
                        if(asyncCommand.IsCancellationRequested) // cancellation check
                            break;
                        System.Threading.Thread.Sleep(25); // do some work here
                        UpdateProgressOnUIThread(i);
                    }
                    UpdateProgressOnUIThread(0);
                });
            }
            // Property for progress
            public int Progress { get; private set; }
            protected IDispatcherService DispatcherService {
                get { return this.GetService<IDispatcherService>(); }
            }
            void UpdateProgressOnUIThread(int progress) {
                DispatcherService.BeginInvoke(() =>
                {
                    Progress = progress;
                    this.RaisePropertyChanged(x => x.Progress);
                });
            }
        }
    }
}