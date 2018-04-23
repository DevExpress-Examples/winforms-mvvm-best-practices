using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DxSampleEventToCommandBehavior {
    public partial class UsingCommandsWithThirdPartyControlsFluentAPIUserControl : XtraUserControl {
        public UsingCommandsWithThirdPartyControlsFluentAPIUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            Button thirdPartyButton = new Button();
            thirdPartyButton.Dock = DockStyle.Top;
            thirdPartyButton.Text = "Execute Command";
            thirdPartyButton.Parent = this;
        
            #endregion SetUp

            #region #usingCommandsWithThirdPartyControlsFluentAPI
            mvvmContext.ViewModelType = typeof(ViewModel);
            // UI binding for the EventToCommand behavior (using FluentAPI)
            mvvmContext.WithEvent<ViewModel, EventArgs>(thirdPartyButton, "Click")
                .EventToCommand(x => x.SayHello());
            #endregion #usingCommandsWithThirdPartyControlsFluentAPI
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
    }
}