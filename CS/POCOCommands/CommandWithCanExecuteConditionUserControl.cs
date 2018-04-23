using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxSamplePOCOCommands {
    public partial class CommandWithCanExecuteConditionUserControl : XtraUserControl {
        public CommandWithCanExecuteConditionUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            SimpleButton commandButton = new SimpleButton();
            commandButton.Text = "Execute Command";
            commandButton.Dock = DockStyle.Top;
            commandButton.Parent = this;
            #endregion SetUp

            #region #commandWithCanExecuteCondition
            mvvmContext.ViewModelType = typeof(ViewModelWithConditionalCommand);
            // UI binding for button
            mvvmContext.BindCommand<ViewModelWithConditionalCommand>(commandButton, x => x.DoSomething());
            #endregion #commandWithCanExecuteCondition
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        // 
        // POCO View Model with command that depends on specific condition
        // 
        public class ViewModelWithConditionalCommand {
            // POCO-command will be created from this method.
            public void DoSomething() {
                XtraMessageBox.Show("Hello! I'm running, because the `canExecute` condition is `True`.");
            }
            // `CanExecute` method for the `SayHello` command.
            public bool CanDoSomething() {
                return (2 + 2) == 4;
            }
        }
    }
}