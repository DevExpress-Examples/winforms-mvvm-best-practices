using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxSampleLegacyCommands {
    public partial class ParameterizedCommandUserControl : XtraUserControl {
        public ParameterizedCommandUserControl() {
            InitializeComponent();
            #region SetUp
            SimpleButton commandButton = new SimpleButton();
            commandButton.Text = "Execute Command";
            commandButton.Dock = DockStyle.Top;
            commandButton.Parent = this;
            #endregion SetUp

            #region #parameterizedCommand
            // This is legacy-command with both the Execute(object) and the CanExecute(object) methods.
            LegacyCommandWithParameter command = new LegacyCommandWithParameter();
            int parameter = 4;
            // UI binding for button with `queryParameter` function
            commandButton.BindCommand(command, () => parameter);
            #endregion #parameterizedCommand
        }
        #region CleanUp
        void OnDisposing() {
        }
        #endregion CleanUp
        public class LegacyCommandWithParameter {
            public void Execute(object parameter) {
                XtraMessageBox.Show(string.Format(
                    "Hello! I'm  Legacy command and the parameter passed to me is {0}." + Environment.NewLine +
                    "I'm running, because the `canExecute` condition is `True` for this parameter." + Environment.NewLine +
                    "Try to change this parameter!", parameter));
            }
            public bool CanExecute(object parameter) {
                return object.Equals(2 + 2, parameter);
            }
        }
    }
}