using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxSamplePOCOCommands {
    public partial class SimpleCommandUserControl : XtraUserControl {
        public SimpleCommandUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            SimpleButton commandButton = new SimpleButton();
            commandButton.Text = "Execute Command";
            commandButton.Dock = DockStyle.Top;
            commandButton.Parent = this;
            #endregion SetUp

            #region #simpleCommand
            mvvmContext.ViewModelType = typeof(ViewModelWithSimpleCommand);
            // UI binding for button
            mvvmContext.BindCommand<ViewModelWithSimpleCommand>(commandButton, x => x.DoSomething());
            #endregion #simpleCommand
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        // 
        // POCO View Model with simple command
        // 
        public class ViewModelWithSimpleCommand {
            // POCO-command will be created from this method.
            public void DoSomething() {
                XtraMessageBox.Show("Hello! I'm running!");
            }
        }
    }
}