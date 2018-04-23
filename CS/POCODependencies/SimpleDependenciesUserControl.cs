using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DxSamplePOCODependencies {
    public partial class SimpleDependenciesUserControl : XtraUserControl {
        public SimpleDependenciesUserControl() {
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

            #region #simpleDependencies
            // Set type of POCO-ViewModel
            mvvmContext.ViewModelType = typeof(MultViewModel);
            // Data binding for the operands
            mvvmContext.SetBinding(editor1, e => e.EditValue, "Operand1");
            mvvmContext.SetBinding(editor2, e => e.EditValue, "Operand2");
            // Data binding for the result
            mvvmContext.SetBinding(resultLabel, l => l.Text, "ResultText");
            #endregion #simpleDependencies
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        // 
        // POCO View Model provides out-of-the-box support of the OnXXXChanging/OnXXXChanged callbacks.
        // 
        public class MultViewModel {
            public MultViewModel() {
                Operand1 = 2;
                Operand2 = 3;
            }
            public virtual int Operand1 { get; set; }
            public virtual int Operand2 { get; set; }
            public virtual int Result { get; set; }
            public virtual string ResultText { get; set; }
            // OnChanged callback will be created for the Operand1 property from this method.
            protected void OnOperand1Changed() {
                // Result depends on Operand1
                UpdateResult();
            }
            // OnChanged callback will be created for the Operand2 property from this method.
            protected void OnOperand2Changed() {
                // Result depends on Operand2
                UpdateResult();
            }
            // OnChanged callback will be created for the Result property from this method.
            protected void OnResultChanged() {
                // ResultText depends on Result
                UpdateResultText();
            }
            void UpdateResult() {
                Result = Operand1 * Operand2;
            }
            void UpdateResultText() {
                ResultText = string.Format("The result of operands multiplication is: {0:n0}", Result);
            }
        }
    }
}