using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DxSampleDialogServices {
    public partial class RibbonDialogServiceUserControl : XtraUserControl {
        public RibbonDialogServiceUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            SimpleButton commandButton = new SimpleButton();
            commandButton.Text = "Execute Command";
            commandButton.Dock = DockStyle.Top;
        
            MemoEdit memo = new MemoEdit();
            memo.Dock = DockStyle.Top;
            memo.Properties.ReadOnly = true;
            memo.MinimumSize = new System.Drawing.Size(0, 100);
        
            commandButton.Parent = this;
            memo.Parent = this;
        
            #endregion SetUp

            #region #ribbonDialogService
            // Force use the RibbonDialogService
            MVVMContext.RegisterRibbonDialogService();
            //
            mvvmContext.ViewModelType = typeof(NotesViewModel);
            // UI binding for Notes
            mvvmContext.SetBinding(memo, m => m.EditValue, "Notes");
            // UI binding for button
            mvvmContext.BindCommand<NotesViewModel>(commandButton, x => x.EditNotes());
            #endregion #ribbonDialogService
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        public class NotesViewModel {
            public NotesViewModel() {
                Notes = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            }
            public virtual string Notes { get; protected set; }
            // using the GetService<> extension method for obtaining service instance
            protected IDialogService DialogService {
                get { return this.GetService<IDialogService>(); }
            }
            public void EditNotes() {
                var dialogParams = new object[] { Notes };
                if(DialogService.ShowDialog(MessageButton.OKCancel, "Edit Notes", "EditNotes", dialogParams, this) == MessageResult.OK)
                    Notes = dialogParams[0] as string;
            }
        }
        public class EditNotesViewModel : ISupportParameter {
            public virtual string Notes { get; set; }
            protected void OnNotesChanged() {
                parameters[0] = Notes;
            }
            object[] parameters;
            object ISupportParameter.Parameter {
                get { return parameters[0]; }
                set {
                    if(object.ReferenceEquals(parameters, value)) return;
                    parameters = (object[])value;
                    Notes = parameters[0] as string;
                }
            }
        }
        [DevExpress.Utils.MVVM.UI.ViewType("EditNotes")]
        public class NotesEditor : XtraUserControl {
            public NotesEditor() {
                this.Padding = new Padding(12);
                this.MinimumSize = new System.Drawing.Size(320, 160);
                //
                MVVMContext mvvmContext = new MVVMContext();
                mvvmContext.ContainerControl = this;
                mvvmContext.ViewModelType = typeof(EditNotesViewModel);
                //
                MemoEdit memo = new MemoEdit();
                memo.Dock = DockStyle.Fill;
                memo.Parent = this;
                // Data-binding for Notes
                mvvmContext.SetBinding(memo, m => m.EditValue, "Notes");
            }
        }
    }
}