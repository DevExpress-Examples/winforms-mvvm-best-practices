Imports DevExpress.MVVM
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace DxSampleDelegateCommands
    Partial Public Class SimpleCommandUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim commandButton As New SimpleButton()
            commandButton.Text = "Execute Command"
            commandButton.Dock = DockStyle.Top
            commandButton.Parent = Me

            ' This is simple command. It just for doing something.
            Dim command As New DelegateCommand(
                Sub() XtraMessageBox.Show("Hello! I'm running!"))
            ' UI binding for button
            commandButton.BindCommand(command)
        End Sub
         Private Sub OnDisposing()
        End Sub
    	End Class
End Namespace