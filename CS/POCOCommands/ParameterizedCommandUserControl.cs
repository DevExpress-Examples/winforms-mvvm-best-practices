using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DxSamplePOCOCommands {
    public partial class ParameterizedCommandUserControl : XtraUserControl {
        public ParameterizedCommandUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            SimpleButton commandButton = new SimpleButton();
            commandButton.Text = "Execute Command";
            commandButton.Dock = DockStyle.Top;
            commandButton.Parent = this;
            #endregion SetUp

            #region #parameterizedCommand
            mvvmContext.ViewModelType = typeof(ViewModelWithParametrizedCommand);
            //
            object parameter = 5;
            // UI binding for button with `queryParameter` function
            mvvmContext.BindCommand<ViewModelWithParametrizedCommand, object>(commandButton, (x, p) => x.DoSomething(p), x => parameter);
            #endregion #parameterizedCommand
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        // 
        // POCO View Model with command that has a parameter
        // 
        public class ViewModelWithParametrizedCommand {
            // Parameterized POCO-command will be created from this method.
            public void DoSomething(object p) {
                XtraMessageBox.Show(string.Format("Hello! The parameter passed to command is {0}. Try to change this parameter!", p));
            }
        }
    }
}