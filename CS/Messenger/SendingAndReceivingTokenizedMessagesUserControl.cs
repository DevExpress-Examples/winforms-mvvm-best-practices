using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DxSampleMessenger {
    public partial class SendingAndReceivingTokenizedMessagesUserControl : XtraUserControl {
        public SendingAndReceivingTokenizedMessagesUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            SimpleButton sendMessageButton = new SimpleButton();
            sendMessageButton.Text = "Send Message";
            sendMessageButton.Dock = DockStyle.Top;
            sendMessageButton.Parent = this;
            #endregion SetUp

            #region #sendingAndReceivingTokenizedMessages
            // add another view
            TokenizedMessagesAwareView msgView = new TokenizedMessagesAwareView();
            msgView.Parent = sendMessageButton.Parent;
            msgView.BringToFront();
            // start listening the ViewModel's custom messages  in View
            msgView.RegisterAsCustomMessageRecepient();
        
            mvvmContext.ViewModelType = typeof(ViewModelWithTokenizedMessages);
            // UI bindings for SendCustomMessage commands
            var fluentAPI = mvvmContext.OfType<ViewModelWithTokenizedMessages>();
            fluentAPI.BindCommand(sendMessageButton, x => x.SendTokenizedMessage());
            #endregion #sendingAndReceivingTokenizedMessages
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        public class ViewModelWithTokenizedMessages {
            Random rnd = new Random();
            public void SendTokenizedMessage() {
                int parameter = rnd.Next(0, 100);
                var msg = new TokenizedMessage() { Parameter = parameter };
                if(parameter % 10 == 0)
                    Messenger.Default.Send(msg, "Ten");
                else
                    Messenger.Default.Send(msg, (parameter % 2 == 1) ? "Odd" : "Even");
            }
            // Message related to this ViewModel (will be dispatched via string token)
            public class TokenizedMessage {
                public object Parameter { get; set; }
            }
        }
        public class TokenizedMessagesAwareView : XtraUserControl {
            MemoEdit memo;
            public TokenizedMessagesAwareView() {
                this.Padding = new Padding(0, 0, 0, 4);
                this.Dock = DockStyle.Fill;
                memo = new MemoEdit();
                memo.Dock = DockStyle.Fill;
                memo.Parent = this;
            }
            public void RegisterAsCustomMessageRecepient() {
                Messenger.Default.Register<ViewModelWithTokenizedMessages.TokenizedMessage>(this, "Odd", OnOddMessage);
                Messenger.Default.Register<ViewModelWithTokenizedMessages.TokenizedMessage>(this, "Even", OnEvenMessage);
                Messenger.Default.Register<ViewModelWithTokenizedMessages.TokenizedMessage>(this, "Ten", OnTenMessage);
            }
            void OnOddMessage(ViewModelWithTokenizedMessages.TokenizedMessage message) {
                LogMessage("Odd: " + message.Parameter.ToString());
            }
            void OnEvenMessage(ViewModelWithTokenizedMessages.TokenizedMessage message) {
                LogMessage("Even: " + message.Parameter.ToString());
            }
            void OnTenMessage(ViewModelWithTokenizedMessages.TokenizedMessage message) {
                LogMessage("Ten: " + message.Parameter.ToString());
            }
            void LogMessage(string message) {
                memo.Text += (message + Environment.NewLine);
                memo.SelectionStart = memo.Text.Length;
                memo.ScrollToCaret();
            }
        }
    }
}