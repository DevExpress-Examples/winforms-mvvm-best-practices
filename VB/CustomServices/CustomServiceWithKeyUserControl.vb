Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms

Namespace DxSampleCustomServices
    Partial Public Class CustomServiceWithKeyUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim mvvmContext As New MVVMContext()
            mvvmContext.ContainerControl = Me
        
            Dim commandButton As New SimpleButton()
            commandButton.Text = "Execute Command"
            commandButton.Dock = DockStyle.Top
            commandButton.Parent = Me

            mvvmContext.ViewModelType = GetType(ViewModelWithKeyedCustomService)
            ' Custom service registration
            mvvmContext.RegisterService("SomeKey1", New CustomService("Custom Service 1"))
            mvvmContext.RegisterService("SomeKey2", New CustomService("Custom Service 2"))
            ' UI binding for button
            mvvmContext.BindCommand(Of ViewModelWithKeyedCustomService)(commandButton, Sub(x) x.DoSomethingViaCustomServices())
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        Public Class ViewModelWithKeyedCustomService
            <DevExpress.Mvvm.DataAnnotations.ServiceProperty(Key:="SomeKey1")>
            Protected Overridable ReadOnly Property CustomService1() As ICustomService
                Get
                    Throw New NotImplementedException()
                End Get
            End Property
            <DevExpress.Mvvm.DataAnnotations.ServiceProperty(Key:="SomeKey2")>
            Protected Overridable ReadOnly Property CustomService2() As ICustomService
                Get
                    Throw New NotImplementedException()
                End Get
            End Property
            Public Sub DoSomethingViaCustomServices()
                CustomService1.DoSomething()
                CustomService2.DoSomething()
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