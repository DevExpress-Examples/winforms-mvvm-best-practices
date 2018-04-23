using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxSampleDelegateCommands {
    public partial class ParameterizedCommandWithCanExecuteConditionUserControl : XtraUserControl {
        public ParameterizedCommandWithCanExecuteConditionUserControl() {
            InitializeComponent();
            #region SetUp
            SimpleButton commandButton = new SimpleButton();
            commandButton.Text = "Execute Command";
            commandButton.Dock = DockStyle.Top;
            commandButton.Parent = this;
            #endregion SetUp

            #region #parameterizedCommandWithCanExecuteCondition
            Func<int, bool> canExecute = (p) => (2 + 2 == p);
            // This command is created as parameterized and with `canExecute` parameter.
            DelegateCommand<int> command = new DelegateCommand<int>((v) =>
            {
                XtraMessageBox.Show(string.Format(
                    "Hello! The parameter passed to command is {0}." + Environment.NewLine +
                    "And I'm running, because the `canExecute` condition is `True` for this parameter." + Environment.NewLine +
                    "Try to change this parameter!", v));
            }, canExecute);
            //
            int parameter = 4;
            // UI binding for button with `queryParameter` function
            commandButton.BindCommand(command, () => parameter);
            #endregion #parameterizedCommandWithCanExecuteCondition
        }
        #region CleanUp
        void OnDisposing() {
        }
        #endregion CleanUp
    }
}