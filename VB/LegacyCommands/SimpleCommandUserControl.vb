Imports DevExpress.MVVM
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace DxSampleLegacyCommands
    Partial Public Class SimpleCommandUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim commandButton As New SimpleButton()
            commandButton.Text = "Execute Command"
            commandButton.Dock = DockStyle.Top
            commandButton.Parent = Me

            ' This is simple legacy-command. It provide the Execute method for doing something.
            Dim command As New LegacyCommand()
            ' UI binding for button
            commandButton.BindCommand(command)
        End Sub
         Private Sub OnDisposing()
        End Sub
        Public Class LegacyCommand
            Public Sub Execute(ByVal parameter As Object)
                XtraMessageBox.Show("Hello! I'm  Legacy command and I'm running!")
            End Sub
        End Class
    	End Class
End Namespace