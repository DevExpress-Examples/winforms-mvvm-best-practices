Imports DevExpress.Mvvm
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms

Namespace DxSampleMessenger
    Partial Public Class SendingAndReceivingCustomMessagesUserControl
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
            Dim msgView As New CustomMessageAwareView()
            msgView.Parent = sendMessageButton.Parent
            msgView.BringToFront()
            ' start listening the ViewModel's custom messages  in View
            msgView.RegisterAsCustomMessageRecepient()
        
            mvvmContext.ViewModelType = GetType(ViewModelWithCustomMessage)
            ' UI bindings for SendCustomMessage commands
            Dim fluentAPI = mvvmContext.OfType(Of ViewModelWithCustomMessage)()
            fluentAPI.BindCommand(sendMessageButton, Sub(x) x.SendCustomMessage())
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        Public Class ViewModelWithCustomMessage
            Private rnd As New Random()
            Public Sub SendCustomMessage()
                Messenger.Default.Send(New CustomMessage() With {.Parameter = rnd.Next(0, 100)})
            End Sub
            ' Custom Message related to this ViewModel
            Public Class CustomMessage
                Public Property Parameter() As Object
                Public Overrides Function ToString() As String
                    Return String.Format("CustomMessage: {0}!", Parameter)
                End Function
            End Class
        End Class
        Public Class CustomMessageAwareView
            Inherits XtraUserControl
            Private memo As MemoEdit
            Public Sub New()
                Me.Padding = New Padding(0, 0, 0, 4)
                Me.Dock = DockStyle.Fill
                memo = New MemoEdit()
                memo.Dock = DockStyle.Fill
                memo.Parent = Me
            End Sub
            Public Sub RegisterAsCustomMessageRecepient()
                Messenger.Default.Register(Of ViewModelWithCustomMessage.CustomMessage)(Me, AddressOf OnCustomMessage)
            End Sub
            Private Sub OnCustomMessage(ByVal message As ViewModelWithCustomMessage.CustomMessage)
                memo.Text += (message.ToString() & Environment.NewLine)
                memo.SelectionStart = memo.Text.Length
                memo.ScrollToCaret()
            End Sub
        End Class
    	End Class
End Namespace