Imports DevExpress.MVVM
Imports DevExpress.MVVM.DataAnnotations
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms

Namespace DxSampleUITriggers
    Partial Public Class SimpleUITriggerFluentAPIUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim mvvmContext As New MVVMContext()
            mvvmContext.ContainerControl = Me
        
            Dim checkEdit As New CheckEdit()
            checkEdit.Dock = DockStyle.Top
            checkEdit.Text = "IsActive"
        
            Dim label As New LabelControl()
            label.Dock = DockStyle.Top
            label.AutoSizeMode = LabelAutoSizeMode.Vertical
            label.Text = "Inactive"
        
            label.Parent = Me
            checkEdit.Parent = Me

            ' Set type of POCO-ViewModel
            mvvmContext.ViewModelType = GetType(UIViewModel)
            ' Data binding for the IsActive property
            Dim fluentAPI = mvvmContext.OfType(Of UIViewModel)()
            fluentAPI.SetBinding(checkEdit, Function(c) c.Checked, Function(x) x.IsActive)
            ' Property-change Trigger for the IsActive property
            fluentAPI.SetTrigger(Function(x) x.IsActive, Sub(active) label.Text = If(active, "Active", "Inactive"))
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        '' 
        '' We will track the IsActive property changing in UI
        '' 
        Public Class UIViewModel
            Public Overridable Property IsActive() As Boolean
        End Class
    	End Class
End Namespace