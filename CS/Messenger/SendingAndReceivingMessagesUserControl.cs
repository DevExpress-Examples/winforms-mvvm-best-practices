using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DxSampleMessenger {
    public partial class SendingAndReceivingMessagesUserControl : XtraUserControl {
        public SendingAndReceivingMessagesUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            SimpleButton sendMessageButton = new SimpleButton();
            sendMessageButton.Text = "Send Message";
            sendMessageButton.Dock = DockStyle.Top;
            sendMessageButton.Parent = this;
            #endregion SetUp

            #region #sendingAndReceivingMessages
            // add another view
            MessageAwareView msgView = new MessageAwareView();
            msgView.Parent = sendMessageButton.Parent;
            msgView.BringToFront();
            // start listening the ViewModel's string messages in View1
            msgView.RegisterAsStringMessageRecepient();
        
            mvvmContext.ViewModelType = typeof(ViewModel);
            // UI bindings for SendStringMessage commands
            var fluentAPI = mvvmContext.OfType<ViewModel>();
            fluentAPI.BindCommand(sendMessageButton, x => x.SendStringMessage());
            #endregion #sendingAndReceivingMessages
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        public class ViewModel {
            public void SendStringMessage() {
                Messenger.Default.Send("Something happens!");
            }
        }
        public class MessageAwareView : XtraUserControl {
            MemoEdit memo;
            public MessageAwareView() {
                this.Padding = new Padding(0, 0, 0, 4);
                this.Dock = DockStyle.Fill;
                memo = new MemoEdit();
                memo.Dock = DockStyle.Fill;
                memo.Parent = this;
            }
            public void RegisterAsStringMessageRecepient() {
                Messenger.Default.Register<string>(this, OnStringMessage);
            }
            void OnStringMessage(string message) {
                memo.Text += ("String message: " + message + Environment.NewLine);
                memo.SelectionStart = memo.Text.Length;
                memo.ScrollToCaret();
            }
        }
    }
}