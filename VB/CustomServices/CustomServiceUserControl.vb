Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms

Namespace DxSampleCustomServices
    Partial Public Class CustomServiceUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim mvvmContext As New MVVMContext()
            mvvmContext.ContainerControl = Me
        
            Dim commandButton As New SimpleButton()
            commandButton.Text = "Execute Command"
            commandButton.Dock = DockStyle.Top
            commandButton.Parent = Me

            mvvmContext.ViewModelType = GetType(ViewModelWithCustomService)
            ' Custom service registration
            mvvmContext.RegisterService(New CustomService())
            ' UI binding for button
            mvvmContext.BindCommand(Of ViewModelWithCustomService)(commandButton, Sub(x) x.DoSomethingViaCustomService())
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        Public Class ViewModelWithCustomService
            Public Sub DoSomethingViaCustomService()
                Me.GetService(Of ICustomService)().DoSomething()
            End Sub
        End Class
        Public Interface ICustomService
            Sub DoSomething()
        End Interface
        Public Class CustomService
            Implements ICustomService
        
            Private text As String
            Public Sub New(Optional ByVal text As String = Nothing)
                Me.text = text
            End Sub
            Public Sub DoSomething() Implements ICustomService.DoSomething
                XtraMessageBox.Show("Hi!", If(text, "CustomService"))
            End Sub
        End Class
    	End Class
End Namespace