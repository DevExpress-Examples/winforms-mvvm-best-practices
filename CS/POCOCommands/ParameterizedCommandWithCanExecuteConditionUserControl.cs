using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxSamplePOCOCommands {
    public partial class ParameterizedCommandWithCanExecuteConditionUserControl : XtraUserControl {
        public ParameterizedCommandWithCanExecuteConditionUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            SimpleButton commandButton = new SimpleButton();
            commandButton.Text = "Execute Command";
            commandButton.Dock = DockStyle.Top;
            commandButton.Parent = this;
            #endregion SetUp

            #region #parameterizedCommandWithCanExecuteCondition
            mvvmContext.ViewModelType = typeof(ViewModelWithParametrizedConditionalCommand);
            //
            int parameter = 4;
            // UI binding for button with `queryParameter` function
            mvvmContext.BindCommand<ViewModelWithParametrizedConditionalCommand, int>(commandButton, (x, p) => x.DoSomething(p), x => parameter);
            #endregion #parameterizedCommandWithCanExecuteCondition
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        // 
        // POCO View Model with command that has a parameter and depends on specific condition
        // 
        public class ViewModelWithParametrizedConditionalCommand {
            // Parameterized POCO-command will be created from this method.
            public void DoSomething(int p) {
                XtraMessageBox.Show(string.Format(
                    "Hello! The parameter passed to command is {0}." + Environment.NewLine +
                    "And I'm running, because the `canExecute` condition is `True` for this parameter." + Environment.NewLine +
                    "Try to change this parameter!", p));
            }
            // Parameterized `CanExecute` method for the `Say` command.
            public bool CanDoSomething(int p) {
                return (2 + 2) == p;
            }
        }
    }
}