using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DxSamplePOCODependencies {
    public partial class PropertyChangedNotificationsUserControl : XtraUserControl {
        public PropertyChangedNotificationsUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            TextEdit editor1 = new TextEdit();
            editor1.Dock = DockStyle.Top;
            editor1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            editor1.Properties.Mask.EditMask = "n0";
            editor1.Properties.Mask.UseMaskAsDisplayFormat = true;
        
            TextEdit editor2 = new TextEdit();
            editor2.Dock = DockStyle.Top;
            editor2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            editor2.Properties.Mask.EditMask = "n0";
            editor2.Properties.Mask.UseMaskAsDisplayFormat = true;
        
            LabelControl resultLabel = new LabelControl();
            resultLabel.Dock = DockStyle.Top;
            resultLabel.AutoSizeMode = LabelAutoSizeMode.Vertical;
        
            resultLabel.Parent = this;
            editor1.Parent = this;
            editor2.Parent = this;
            #endregion SetUp

            #region #propertyChangedNotifications
            // Set type of POCO-ViewModel
            mvvmContext.ViewModelType = typeof(SumViewModel);
            // Data binding for the operands
            mvvmContext.SetBinding(editor1, e => e.EditValue, "Operand1");
            mvvmContext.SetBinding(editor2, e => e.EditValue, "Operand2");
            // Data binding for the result
            mvvmContext.SetBinding(resultLabel, l => l.Text, "ResultText");
            #endregion #propertyChangedNotifications
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        // 
        // POCO View Model supports attributes and extension-methods for different purposes.
        // 
        public class SumViewModel {
            public SumViewModel() {
                Operand1 = 2;
                Operand2 = 2;
            }
            // using the BindableProperty attribute
            [BindableProperty(OnPropertyChangedMethodName = "NotifyResultAndResultTextChanged")]
            public virtual int Operand1 { get; set; }
            // using the BindableProperty attribute
            [BindableProperty(OnPropertyChangedMethodName = "NotifyResultAndResultTextChanged")]
            public virtual int Operand2 { get; set; }
            // We will raise change-notification for this property manually
            public int Result {
                get { return Operand1 + Operand2; }
            }
            // We will raise change-notification for this property manually
            public string ResultText {
                get { return string.Format("The result of operands summarization is: {0:n0}", Result); }
            }
            protected void NotifyResultAndResultTextChanged() {
                this.RaisePropertyChanged(x => x.Result); // change-notification for the Result
                this.RaisePropertyChanged(x => x.ResultText); // change-notification for the ResultText
            }
        }
    }
}