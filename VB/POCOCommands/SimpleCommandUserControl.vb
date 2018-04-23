Imports DevExpress.MVVM
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace DxSamplePOCOCommands
    Partial Public Class SimpleCommandUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim mvvmContext As New MVVMContext()
            mvvmContext.ContainerControl = Me
        
            Dim commandButton As New SimpleButton()
            commandButton.Text = "Execute Command"
            commandButton.Dock = DockStyle.Top
            commandButton.Parent = Me

            mvvmContext.ViewModelType = GetType(ViewModelWithSimpleCommand)
            ' UI binding for button
            mvvmContext.BindCommand(Of ViewModelWithSimpleCommand)(commandButton, Sub(x) x.DoSomething())
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        '' 
        '' POCO View Model with simple command
        '' 
        Public Class ViewModelWithSimpleCommand
            ' POCO-command will be created from this method.
            Public Sub DoSomething()
                XtraMessageBox.Show("Hello! I'm running!")
            End Sub
        End Class
    	End Class
End Namespace