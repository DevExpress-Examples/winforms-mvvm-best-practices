Imports DevExpress.MVVM
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace DxSampleDelegateCommands
    Partial Public Class CommandWithCanExecuteConditionUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim commandButton As New SimpleButton()
            commandButton.Text = "Execute Command"
            commandButton.Dock = DockStyle.Top
            commandButton.Parent = Me

            Dim canExecute As Func(Of Boolean) = Function() (2 + 2 = 4)
            ' This command is created with `canExecute` parameter.
            Dim command As New DelegateCommand(
                Sub() XtraMessageBox.Show("Hello! I'm running, because the `canExecute` condition is `True`. Try to change this condition!"), canExecute)
            ' UI binding for button
            commandButton.BindCommand(command)
        End Sub
         Private Sub OnDisposing()
        End Sub
    	End Class
End Namespace