Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms

Namespace DxSampleMessageBoxServices
    Partial Public Class XtraMessageBoxServiceUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim mvvmContext As New MVVMContext()
            mvvmContext.ContainerControl = Me
        
            Dim commandButton As New SimpleButton()
            commandButton.Text = "Execute Command"
            commandButton.Dock = DockStyle.Top
            commandButton.Parent = Me

            ' Force use the XtraMessageBoxService
            MVVMContext.RegisterXtraMessageBoxService()
            '
            mvvmContext.ViewModelType = GetType(SayHelloViewModel)
            ' UI binding for button
            mvvmContext.BindCommand(Of SayHelloViewModel)(commandButton, Sub(x) x.SayHello())
        End Sub
         Private Sub OnDisposing()
            MVVMContext.RegisterXtraMessageBoxService()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        Public Class SayHelloViewModel
            Protected ReadOnly Property MessageBoxService() As IMessageBoxService
                ' using the GetService<> extension method for obtaining service instance
                Get
                    Return Me.GetService(Of IMessageBoxService)()
                End Get
            End Property
            Public Sub SayHello()
                ' using the MessageBoxService.ShowMessage method
                If MessageBoxService.ShowMessage("Hello, buddy! Have a nice day!", "Greeting", MessageButton.OK, MessageIcon.Information) = MessageResult.OK Then
                    ' do something
                End If
            End Sub
        End Class
    	End Class
End Namespace