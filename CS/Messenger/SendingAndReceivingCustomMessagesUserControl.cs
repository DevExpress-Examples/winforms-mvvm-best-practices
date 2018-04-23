using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DxSampleMessenger {
    public partial class SendingAndReceivingCustomMessagesUserControl : XtraUserControl {
        public SendingAndReceivingCustomMessagesUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            SimpleButton sendMessageButton = new SimpleButton();
            sendMessageButton.Text = "Send Message";
            sendMessageButton.Dock = DockStyle.Top;
            sendMessageButton.Parent = this;
            #endregion SetUp

            #region #sendingAndReceivingCustomMessages
            // add another view
            CustomMessageAwareView msgView = new CustomMessageAwareView();
            msgView.Parent = sendMessageButton.Parent;
            msgView.BringToFront();
            // start listening the ViewModel's custom messages  in View
            msgView.RegisterAsCustomMessageRecepient();
        
            mvvmContext.ViewModelType = typeof(ViewModelWithCustomMessage);
            // UI bindings for SendCustomMessage commands
            var fluentAPI = mvvmContext.OfType<ViewModelWithCustomMessage>();
            fluentAPI.BindCommand(sendMessageButton, x => x.SendCustomMessage());
            #endregion #sendingAndReceivingCustomMessages
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        public class ViewModelWithCustomMessage {
            Random rnd = new Random();
            public void SendCustomMessage() {
                Messenger.Default.Send(new CustomMessage() { Parameter = rnd.Next(0, 100) });
            }
            // Custom Message related to this ViewModel
            public class CustomMessage {
                public object Parameter { get; set; }
                public override string ToString() {
                    return string.Format("CustomMessage: {0}!", Parameter);
                }
            }
        }
        public class CustomMessageAwareView : XtraUserControl {
            MemoEdit memo;
            public CustomMessageAwareView() {
                this.Padding = new Padding(0, 0, 0, 4);
                this.Dock = DockStyle.Fill;
                memo = new MemoEdit();
                memo.Dock = DockStyle.Fill;
                memo.Parent = this;
            }
            public void RegisterAsCustomMessageRecepient() {
                Messenger.Default.Register<ViewModelWithCustomMessage.CustomMessage>(this, OnCustomMessage);
            }
            void OnCustomMessage(ViewModelWithCustomMessage.CustomMessage message) {
                memo.Text += (message.ToString() + Environment.NewLine);
                memo.SelectionStart = memo.Text.Length;
                memo.ScrollToCaret();
            }
        }
    }
}