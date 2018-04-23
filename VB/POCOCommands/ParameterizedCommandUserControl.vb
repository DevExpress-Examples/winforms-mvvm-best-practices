Imports DevExpress.MVVM
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace DxSamplePOCOCommands
    Partial Public Class ParameterizedCommandUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim mvvmContext As New MVVMContext()
            mvvmContext.ContainerControl = Me
        
            Dim commandButton As New SimpleButton()
            commandButton.Text = "Execute Command"
            commandButton.Dock = DockStyle.Top
            commandButton.Parent = Me

            mvvmContext.ViewModelType = GetType(ViewModelWithParametrizedCommand)
            '
            Dim parameter As Object = 5
            ' UI binding for button with `queryParameter` function
            mvvmContext.BindCommand(Of ViewModelWithParametrizedCommand, Object)(commandButton, Sub(x, p) x.DoSomething(p), Function(x) parameter)
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        '' 
        '' POCO View Model with command that has a parameter
        '' 
        Public Class ViewModelWithParametrizedCommand
            ' Parameterized POCO-command will be created from this method.
            Public Sub DoSomething(ByVal p As Object)
                XtraMessageBox.Show(String.Format("Hello! The parameter passed to command is {0}. Try to change this parameter!", p))
            End Sub
        End Class
    	End Class
End Namespace