using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DxSamplePOCOBindableProperties {
    public partial class StandardDataBindingUserControl : XtraUserControl {
        public StandardDataBindingUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            TextEdit editor = new TextEdit();
            editor.Dock = DockStyle.Top;
            editor.Properties.NullValuePrompt = "Please, enter the Title here...";
            editor.Properties.NullValuePromptShowForEmptyValue = true;
        
            SimpleButton commandButton = new SimpleButton();
            commandButton.Dock = DockStyle.Top;
            commandButton.Text = "Report the Title property value";
        
            commandButton.Parent = this;
            editor.Parent = this;
            #endregion SetUp

            #region #standardDataBinding
            // Set type of POCO-ViewModel
            mvvmContext.ViewModelType = typeof(ViewModel);
            ViewModel viewModel = mvvmContext.GetViewModel<ViewModel>();
            // Data binding for the Title property (via the DataBindings collection)
            editor.DataBindings.Add("EditValue", viewModel, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
            // UI binding for the Report command
            commandButton.Click += (s, e) => XtraMessageBox.Show(viewModel.GetTitleAsHumanReadableString());
            #endregion #standardDataBinding
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        // 
        // POCO View Model provides out-of-the-box support of the INotifyPropertyChanged.
        // 
        public class ViewModel {
            // Bindable property will be created from this property.
            public virtual string Title { get; set; }
            // Just a method for readability
            public string GetTitleAsHumanReadableString() {
                if(Title == null)
                    return "(Null)";
                if(Title.Length == 0)
                    return "(Empty)";
                if(string.IsNullOrWhiteSpace(Title))
                    return "(WhiteSpace)";
                return Title;
            }
        }
    }
}