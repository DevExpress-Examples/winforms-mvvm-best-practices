using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DxSampleCustomServices {
    public partial class CustomServiceWithKeyUserControl : XtraUserControl {
        public CustomServiceWithKeyUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            SimpleButton commandButton = new SimpleButton();
            commandButton.Text = "Execute Command";
            commandButton.Dock = DockStyle.Top;
            commandButton.Parent = this;
            #endregion SetUp

            #region #customServiceWithKey
            mvvmContext.ViewModelType = typeof(ViewModelWithKeyedCustomService);
            // Custom service registration
            mvvmContext.RegisterService("SomeKey1", new CustomService("Custom Service 1"));
            mvvmContext.RegisterService("SomeKey2", new CustomService("Custom Service 2"));
            // UI binding for button
            mvvmContext.BindCommand<ViewModelWithKeyedCustomService>(commandButton, x => x.DoSomethingViaCustomServices());
            #endregion #customServiceWithKey
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        public class ViewModelWithKeyedCustomService {
            [DevExpress.Mvvm.DataAnnotations.ServiceProperty(Key = "SomeKey1")]
            protected virtual ICustomService CustomService1 {
                get { throw new NotImplementedException(); }
            }
            [DevExpress.Mvvm.DataAnnotations.ServiceProperty(Key = "SomeKey2")]
            protected virtual ICustomService CustomService2 {
                get { throw new NotImplementedException(); }
            }
            public void DoSomethingViaCustomServices() {
                CustomService1.DoSomething();
                CustomService2.DoSomething();
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