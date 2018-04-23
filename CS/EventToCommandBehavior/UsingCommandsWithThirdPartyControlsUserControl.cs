using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DxSampleEventToCommandBehavior {
    public partial class UsingCommandsWithThirdPartyControlsUserControl : XtraUserControl {
        public UsingCommandsWithThirdPartyControlsUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            Button thirdPartyButton = new Button();
            thirdPartyButton.Dock = DockStyle.Top;
            thirdPartyButton.Text = "Execute Command";
            thirdPartyButton.Parent = this;
        
            #endregion SetUp

            #region #usingCommandsWithThirdPartyControls
            mvvmContext.ViewModelType = typeof(ViewModel);
            // UI binding for the ClickToSayHello behavior
            mvvmContext.AttachBehavior<ClickToSayHello>(thirdPartyButton);
            #endregion #usingCommandsWithThirdPartyControls
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        public class ViewModel {
            protected IMessageBoxService MessageBoxService {
                get { return this.GetService<IMessageBoxService>(); }
            }
            public void SayHello() {
                MessageBoxService.ShowMessage("Hello!");
            }
        }
        public class ClickToSayHello : DevExpress.Utils.MVVM.EventToCommandBehavior<ViewModel, EventArgs> {
            public ClickToSayHello()
                : base("Click", x => x.SayHello()) {
            }
        }
    }
}