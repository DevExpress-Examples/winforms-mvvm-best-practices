Imports DevExpress.MVVM
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace DxSampleLegacyCommands
    Partial Public Class ParameterizedCommandUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim commandButton As New SimpleButton()
            commandButton.Text = "Execute Command"
            commandButton.Dock = DockStyle.Top
            commandButton.Parent = Me

            ' This is legacy-command with both the Execute(object) and the CanExecute(object) methods.
            Dim command As New LegacyCommandWithParameter()
            Dim parameter As Integer = 4
            ' UI binding for button with `queryParameter` function
            commandButton.BindCommand(command, Function() parameter)
        End Sub
         Private Sub OnDisposing()
        End Sub
        Public Class LegacyCommandWithParameter
            Public Sub Execute(ByVal parameter As Object)
                XtraMessageBox.Show(String.Format(
                                    "Hello! I'm  Legacy command and the parameter passed to me is {0}." + Environment.NewLine +
                                    "I'm running, because the `canExecute` condition is `True` for this parameter." + Environment.NewLine +
                                    "Try to change this parameter!", parameter))
            End Sub
            Public Function CanExecute(ByVal parameter As Object) As Boolean
                Return Object.Equals(2 + 2, parameter)
            End Function
        End Class
    	End Class
End Namespace