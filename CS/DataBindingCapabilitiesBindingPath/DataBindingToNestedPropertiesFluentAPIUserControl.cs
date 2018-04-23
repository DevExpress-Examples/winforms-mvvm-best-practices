using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DxSampleDataBindingCapabilitiesBindingPath {
    public partial class DataBindingToNestedPropertiesFluentAPIUserControl : XtraUserControl {
        public DataBindingToNestedPropertiesFluentAPIUserControl() {
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

            #region #dataBindingToNestedPropertiesFluentAPI
            // Set type of POCO-ViewModel
            mvvmContext.ViewModelType = typeof(ViewModel);
            // Data binding for the Title property of nested ViewModel (via MVVMContext FluentAPI)
            var fluent = mvvmContext.OfType<ViewModel>();
            fluent.SetBinding(editor, e => e.EditValue, x => x.Child.Title);
            // UI binding for the Report command
            ViewModel viewModel = mvvmContext.GetViewModel<ViewModel>();
            commandButton.Click += (s, e) => XtraMessageBox.Show(viewModel.GetChildTitleAsHumanReadableString());
            #endregion #dataBindingToNestedPropertiesFluentAPI
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        public class ViewModel {
            public ViewModel() {
                // Create Nested ViewModel as POCO-ViewModel
                Child = ViewModelSource.Create<NestedViewModel>();
            }
            // Nested ViewModel
            public NestedViewModel Child { get; private set; }
            // Just a method for readability
            public string GetChildTitleAsHumanReadableString() {
                if(Child.Title == null)
                    return "Child.Title is (Null)";
                if(Child.Title.Length == 0)
                    return "Child.Title is (Empty)";
                if(string.IsNullOrWhiteSpace(Child.Title))
                    return "Child.Title is (WhiteSpace)";
                return "Child.Title = " + Child.Title;
            }
        }
        public class NestedViewModel {
            public virtual string Title { get; set; }
        }
    }
}