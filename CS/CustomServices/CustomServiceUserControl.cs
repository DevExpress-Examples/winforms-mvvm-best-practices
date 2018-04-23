using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DxSampleCustomServices {
    public partial class CustomServiceUserControl : XtraUserControl {
        public CustomServiceUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            SimpleButton commandButton = new SimpleButton();
            commandButton.Text = "Execute Command";
            commandButton.Dock = DockStyle.Top;
            commandButton.Parent = this;
            #endregion SetUp

            #region #customService
            mvvmContext.ViewModelType = typeof(ViewModelWithCustomService);
            // Custom service registration
            mvvmContext.RegisterService(new CustomService());
            // UI binding for button
            mvvmContext.BindCommand<ViewModelWithCustomService>(commandButton, x => x.DoSomethingViaCustomService());
            #endregion #customService
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        public class ViewModelWithCustomService {
            public void DoSomethingViaCustomService() {
                this.GetService<ICustomService>().DoSomething();
            }
        }
        public interface ICustomService {
            void DoSomething();
        }
        public class CustomService : ICustomService {
            string text;
            public CustomService(string text = null) {
                this.text = text;
            }
            public void DoSomething() {
                XtraMessageBox.Show("Hi!", text ?? "CustomService");
            }
        }
    }
}