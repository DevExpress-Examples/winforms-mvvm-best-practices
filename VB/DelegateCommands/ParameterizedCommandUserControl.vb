Imports DevExpress.MVVM
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace DxSampleDelegateCommands
    Partial Public Class ParameterizedCommandUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim commandButton As New SimpleButton()
            commandButton.Text = "Execute Command"
            commandButton.Dock = DockStyle.Top
            commandButton.Parent = Me

            ' This command is created as parameterized.
            Dim command As New DelegateCommand(Of Object)(
                Sub(v) XtraMessageBox.Show(
                    String.Format("Hello! The parameter passed to command is {0}. Try to change this parameter!", v)))
            '
            Dim parameter As Object = 5
            ' UI binding for button with `queryParameter` function
        End Sub
         Private Sub OnDisposing()
        End Sub
    	End Class
End Namespace