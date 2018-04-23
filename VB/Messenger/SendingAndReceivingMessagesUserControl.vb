Imports DevExpress.Mvvm
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms

Namespace DxSampleMessenger
    Partial Public Class SendingAndReceivingMessagesUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim mvvmContext As New MVVMContext()
            mvvmContext.ContainerControl = Me
        
            Dim sendMessageButton As New SimpleButton()
            sendMessageButton.Text = "Send Message"
            sendMessageButton.Dock = DockStyle.Top
            sendMessageButton.Parent = Me

            ' add another view
            Dim msgView As New MessageAwareView()
            msgView.Parent = sendMessageButton.Parent
            msgView.BringToFront()
            ' start listening the ViewModel's string messages in View1
            msgView.RegisterAsStringMessageRecepient()
        
            mvvmContext.ViewModelType = GetType(ViewModel)
            ' UI bindings for SendStringMessage commands
            Dim fluentAPI = mvvmContext.OfType(Of ViewModel)()
            fluentAPI.BindCommand(sendMessageButton, Sub(x) x.SendStringMessage())
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        Public Class ViewModel
            Public Sub SendStringMessage()
                Messenger.Default.Send("Something happens!")
            End Sub
        End Class
        Public Class MessageAwareView
            Inherits XtraUserControl
            Private memo As MemoEdit
            Public Sub New()
                Me.Padding = New Padding(0, 0, 0, 4)
                Me.Dock = DockStyle.Fill
                memo = New MemoEdit()
                memo.Dock = DockStyle.Fill
                memo.Parent = Me
            End Sub
            Public Sub RegisterAsStringMessageRecepient()
                Messenger.Default.Register(Of String)(Me, AddressOf OnStringMessage)
            End Sub
            Private Sub OnStringMessage(ByVal message As String)
                memo.Text += ("String message: " & message & Environment.NewLine)
                memo.SelectionStart = memo.Text.Length
                memo.ScrollToCaret()
            End Sub
        End Class
    	End Class
End Namespace