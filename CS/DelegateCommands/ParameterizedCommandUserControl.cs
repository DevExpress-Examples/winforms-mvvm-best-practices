using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxSampleDelegateCommands {
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
            // This command is created as parameterized.
            DelegateCommand<object> command = new DelegateCommand<object>((v) =>
            {
                XtraMessageBox.Show(string.Format("Hello! The parameter passed to command is {0}. Try to change this parameter!", v));
            });
            //
            object parameter = 5;
            // UI binding for button with `queryParameter` function
            commandButton.BindCommand(command, () => parameter);
            #endregion #parameterizedCommand
        }
        #region CleanUp
        void OnDisposing() {
        }
        #endregion CleanUp
    }
}