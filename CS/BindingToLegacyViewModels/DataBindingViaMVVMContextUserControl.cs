using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DxSampleBindingToLegacyViewModels {
    public partial class DataBindingViaMVVMContextUserControl : XtraUserControl {
        public DataBindingViaMVVMContextUserControl() {
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

            #region #dataBindingViaMVVMContext
            var legacyViewModel = new LegacyViewModel("Legacy ViewModel");
            // initialize the MVVMContext with the specific ViewModel's instance
            mvvmContext.SetViewModel(typeof(LegacyViewModel), legacyViewModel);
            // Data binding for the Title property (via MVVMContext API)
            mvvmContext.SetBinding(editor, e => e.EditValue, "Title");
            // UI binding for the Report command
            commandButton.Click += (s, e) => XtraMessageBox.Show(legacyViewModel.Title);
            #endregion #dataBindingViaMVVMContext
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        public class LegacyViewModel {
            string titleCore;
            public LegacyViewModel(string title) {
                this.titleCore = title;
            }
            public virtual string Title {
                get { return titleCore; }
                set {
                    if(titleCore == value) return;
                    titleCore = value;
                    OnTitleChanged();
                }
            }
            void OnTitleChanged() {
                EventHandler h = TitleChanged;
                if(h != null) h(this, EventArgs.Empty);
            }
            public event EventHandler TitleChanged;
        }
    }
}