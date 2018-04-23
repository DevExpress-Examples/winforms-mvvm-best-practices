Imports DevExpress.MVVM
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace DxSamplePOCOCommands
    Partial Public Class CommandWithCanExecuteConditionUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim mvvmContext As New MVVMContext()
            mvvmContext.ContainerControl = Me
        
            Dim commandButton As New SimpleButton()
            commandButton.Text = "Execute Command"
            commandButton.Dock = DockStyle.Top
            commandButton.Parent = Me

            mvvmContext.ViewModelType = GetType(ViewModelWithConditionalCommand)
            ' UI binding for button
            mvvmContext.BindCommand(Of ViewModelWithConditionalCommand)(commandButton, Sub(x) x.DoSomething())
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        '' 
        '' POCO View Model with command that depends on specific condition
        '' 
        Public Class ViewModelWithConditionalCommand
            ' POCO-command will be created from this method.
            Public Sub DoSomething()
                XtraMessageBox.Show("Hello! I'm running, because the `canExecute` condition is `True`.")
            End Sub
            ' `CanExecute` method for the `SayHello` command.
            Public Function CanDoSomething() As Boolean
                Return (2 + 2) = 4
            End Function
        End Class
    	End Class
End Namespace