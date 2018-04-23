Imports DevExpress.MVVM
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace DxSampleDelegateCommands
    Partial Public Class ParameterizedCommandWithCanExecuteConditionUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim commandButton As New SimpleButton()
            commandButton.Text = "Execute Command"
            commandButton.Dock = DockStyle.Top
            commandButton.Parent = Me

            Dim canExecute As Func(Of Integer, Boolean) = Function(p) (2 + 2 = p)
            ' This command is created as parameterized and with `canExecute` parameter.
            Dim command As New DelegateCommand(Of Integer)(
                Sub(v) XtraMessageBox.Show(
                    String.Format(
                                "Hello! The parameter passed to command is {0}." + Environment.NewLine +
                                "And I'm running, because the `canExecute` condition is `True` for this parameter." + Environment.NewLine +
                                "Try to change this parameter!", v)), canExecute)
            Dim parameter As Integer = 4
            ' UI binding for button with `queryParameter` function
        End Sub
         Private Sub OnDisposing()
        End Sub
    	End Class
End Namespace