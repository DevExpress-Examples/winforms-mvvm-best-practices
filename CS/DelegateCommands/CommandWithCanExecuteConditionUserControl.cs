using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxSampleDelegateCommands {
    public partial class CommandWithCanExecuteConditionUserControl : XtraUserControl {
        public CommandWithCanExecuteConditionUserControl() {
            InitializeComponent();
            #region SetUp
            SimpleButton commandButton = new SimpleButton();
            commandButton.Text = "Execute Command";
            commandButton.Dock = DockStyle.Top;
            commandButton.Parent = this;
            #endregion SetUp

            #region #commandWithCanExecuteCondition
            Func<bool> canExecute = () => (2 + 2 == 4);
            // This command is created with `canExecute` parameter.
            DelegateCommand command = new DelegateCommand(() =>
            {
                XtraMessageBox.Show("Hello! I'm running, because the `canExecute` condition is `True`. Try to change this condition!");
            }, canExecute);
            // UI binding for button
            commandButton.BindCommand(command);
            #endregion #commandWithCanExecuteCondition
        }
        #region CleanUp
        void OnDisposing() {
        }
        #endregion CleanUp
    }
}