Imports DevExpress.MVVM
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace DxSamplePOCOCommands
    Partial Public Class ParameterizedCommandWithCanExecuteConditionUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim mvvmContext As New MVVMContext()
            mvvmContext.ContainerControl = Me
        
            Dim commandButton As New SimpleButton()
            commandButton.Text = "Execute Command"
            commandButton.Dock = DockStyle.Top
            commandButton.Parent = Me

            mvvmContext.ViewModelType = GetType(ViewModelWithParametrizedConditionalCommand)
            '
            Dim parameter As Integer = 4
            ' UI binding for button with `queryParameter` function
            mvvmContext.BindCommand(Of ViewModelWithParametrizedConditionalCommand, Integer)(commandButton, Sub(x, p) x.DoSomething(p), Function(x) parameter)
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        '' 
        '' POCO View Model with command that has a parameter and depends on specific condition
        '' 
        Public Class ViewModelWithParametrizedConditionalCommand
            ' Parameterized POCO-command will be created from this method.
            Public Sub DoSomething(ByVal p As Integer)
                XtraMessageBox.Show(String.Format(
                                    "Hello! The parameter passed to command is {0}." + Environment.NewLine +
                                    "And I'm running, because the `canExecute` condition is `True` for this parameter." + Environment.NewLine +
                                    "Try to change this parameter!", p))
            End Sub
            ' Parameterized `CanExecute` method for the `Say` command.
            Public Function CanDoSomething(ByVal p As Integer) As Boolean
                Return (2 + 2) = p
            End Function
        End Class
    	End Class
End Namespace