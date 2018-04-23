using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace DxSampleDataBindingCapabilitiesConverters {
    public partial class DataBindingViaDefaultConvertersFluentAPIUserControl : XtraUserControl {
        public DataBindingViaDefaultConvertersFluentAPIUserControl() {
            InitializeComponent();
            #region SetUp
            MVVMContext mvvmContext = new MVVMContext();
            mvvmContext.ContainerControl = this;
        
            TrackBarControl trackBar = new TrackBarControl();
            trackBar.Dock = DockStyle.Top;
            trackBar.Properties.Minimum = 0;
            trackBar.Properties.Maximum = 100;
        
            TextEdit editor = new TextEdit();
            editor.Dock = DockStyle.Top;
            editor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            editor.Properties.Mask.EditMask = "P0";
            editor.Properties.Mask.UseMaskAsDisplayFormat = true;
        
            editor.Parent = this;
            trackBar.Parent = this;
            #endregion SetUp

            #region #dataBindingViaDefaultConvertersFluentAPI
            // Set type of POCO-ViewModel
            mvvmContext.ViewModelType = typeof(ViewModel);
            // Data binding for the Progress property (via MVVMContext FluentAPI)
            var fluent = mvvmContext.OfType<ViewModel>();
            fluent.SetBinding(trackBar, e => e.EditValue, x => x.Progress);
            fluent.SetBinding(editor, e => e.EditValue, x => x.Progress);
            #endregion #dataBindingViaDefaultConvertersFluentAPI
        }
        #region CleanUp
        void OnDisposing() {
            var context = MVVMContext.FromControl(this);
            if(context != null) context.Dispose();
        }
        #endregion CleanUp
        public class ViewModel {
            public virtual int Progress { get; set; }
        }
    }
}