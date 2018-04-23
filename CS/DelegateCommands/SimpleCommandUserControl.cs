using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxSampleDelegateCommands {
    public partial class SimpleCommandUserControl : XtraUserControl {
        public SimpleCommandUserControl() {
            InitializeComponent();
            #region SetUp
            SimpleButton commandButton = new SimpleButton();
            commandButton.Text = "Execute Command";
            commandButton.Dock = DockStyle.Top;
            commandButton.Parent = this;
            #endregion SetUp

            #region #simpleCommand
            // This is simple command. It just for doing something.
            DelegateCommand command = new DelegateCommand(() =>
            {
                XtraMessageBox.Show("Hello! I'm running!");
            });
            // UI binding for button
            commandButton.BindCommand(command);
            #endregion #simpleCommand
        }
        #region CleanUp
        void OnDisposing() {
        }
        #endregion CleanUp
    }
}