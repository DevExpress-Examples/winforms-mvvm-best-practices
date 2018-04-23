using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DxSampleMessageBoxServices {
    public partial class XtraMessageBoxServiceUserControl : XtraUserControl {
        public XtraMessageBoxServiceUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            SimpleButton commandButton = new SimpleButton();
            commandButton.Text = "Execute Command";
            commandButton.Dock = DockStyle.Top;
            commandButton.Parent = this;
            #endregion SetUp

            #region #xtraMessageBoxService
            // Force use the XtraMessageBoxService
            MVVMContext.RegisterXtraMessageBoxService();
            //
            mvvmContext.ViewModelType = typeof(SayHelloViewModel);
            // UI binding for button
            mvvmContext.BindCommand<SayHelloViewModel>(commandButton, x => x.SayHello());
            #endregion #xtraMessageBoxService
        }
        #region CleanUp
        void OnDisposing() {
            MVVMContext.RegisterXtraMessageBoxService();
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        public class SayHelloViewModel {
            protected IMessageBoxService MessageBoxService {
                // using the GetService<> extension method for obtaining service instance
                get { return this.GetService<IMessageBoxService>(); }
            }
            public void SayHello() {
                // using the MessageBoxService.ShowMessage method
                if(MessageBoxService.ShowMessage("Hello, buddy! Have a nice day!", "Greeting", MessageButton.OK, MessageIcon.Information) == MessageResult.OK) {
                    // do something
                }
            }
        }
    }
}