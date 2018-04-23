using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxSampleLegacyCommands {
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
            // This is simple legacy-command. It provide the Execute method for doing something.
            LegacyCommand command = new LegacyCommand();
            // UI binding for button
            commandButton.BindCommand(command);
            #endregion #simpleCommand
        }
        #region CleanUp
        void OnDisposing() {
        }
        #endregion CleanUp
        public class LegacyCommand {
            public void Execute(object parameter) {
                XtraMessageBox.Show("Hello! I'm  Legacy command and I'm running!");
            }
        }
    }
}