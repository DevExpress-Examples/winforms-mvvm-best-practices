Imports DevExpress.MVVM
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace DxSamplePOCOAsynchronousCommands
    Partial Public Class SimpleCommandUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim mvvmContext As New MVVMContext()
            mvvmContext.ContainerControl = Me
        
            Dim progressBar As New ProgressBarControl()
            progressBar.Dock = DockStyle.Top
        
            Dim commandButton As New SimpleButton()
            commandButton.Text = "Start Command Execution"
            commandButton.Dock = DockStyle.Top
        
            Dim cancelButton As New SimpleButton()
            cancelButton.Text = "Cancel Command Execution"
            cancelButton.Dock = DockStyle.Top
        
            cancelButton.Parent = Me
            commandButton.Parent = Me
            progressBar.Parent = Me

            cancelButton.Visible = False
            progressBar.Visible = False
            '
            mvvmContext.ViewModelType = GetType(ViewModelWithAsyncCommand)
            ' UI binding for button
            mvvmContext.BindCommand(Of ViewModelWithAsyncCommand)(commandButton, Sub(x) x.DoSomethingAsynchronously())
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        Public Class ViewModelWithAsyncCommand
            ' Asynchronous POCO-command will be created from this method.
            Public Function DoSomethingAsynchronously() As Task
                Return Task.Factory.StartNew(Sub() System.Threading.Thread.Sleep(1000)) ' do some work here
            End Function
        End Class
    	End Class
End Namespace