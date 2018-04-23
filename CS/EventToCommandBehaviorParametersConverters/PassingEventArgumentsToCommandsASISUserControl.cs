using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DxSampleEventToCommandBehaviorParametersConverters {
    public partial class PassingEventArgumentsToCommandsASISUserControl : XtraUserControl {
        public PassingEventArgumentsToCommandsASISUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            PanelControl panel = new PanelControl();
            panel.Dock = DockStyle.Top;
            panel.Parent = this;
        
            LabelControl label = new LabelControl();
            label.Text = "Click to Execute Command";
            label.Dock = DockStyle.Fill;
            label.AutoSizeMode = LabelAutoSizeMode.None;
            label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            label.Parent = panel;
        
            #endregion SetUp

            #region #passingEventArgumentsToCommandsASIS
            mvvmContext.ViewModelType = typeof(MouseDownAwareViewModel);
            // UI binding for the EventToCommand behavior
            mvvmContext.OfType<MouseDownAwareViewModel>()
                .WithEvent<MouseEventArgs>(label, "MouseDown")
                .EventToCommand(x => x.ReportArgs(new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0)));
            #endregion #passingEventArgumentsToCommandsASIS
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        public class MouseDownAwareViewModel {
            public MouseDownAwareViewModel() {
                Message = "MouseDown performed!";
            }
            public string Message { get; set; }
            protected IMessageBoxService MessageBoxService {
                get { return this.GetService<IMessageBoxService>(); }
            }
            public void Report(string message) {
                MessageBoxService.ShowMessage(message);
            }
            public void ReportArgs(MouseEventArgs args) {
                string message = string.Join(", ",
                        "Button: " + args.Button.ToString(),
                        "Location: " + args.Location.ToString(),
                        "Clicks: " + args.Clicks.ToString(),
                        "Delta: " + args.Delta.ToString());
                MessageBoxService.ShowMessage("Args = {" + message + "}");
            }
            public void ReportLocation(Point pt) {
                MessageBoxService.ShowMessage("Location = " + pt.ToString());
            }
        }
    }
}