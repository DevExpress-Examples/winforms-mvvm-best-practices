Imports DevExpress.Mvvm
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms

Namespace DxSampleMessenger
    Partial Public Class SendingAndReceivingTokenizedMessagesUserControl
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
            Dim msgView As New TokenizedMessagesAwareView()
            msgView.Parent = sendMessageButton.Parent
            msgView.BringToFront()
            ' start listening the ViewModel's custom messages  in View
            msgView.RegisterAsCustomMessageRecepient()
        
            mvvmContext.ViewModelType = GetType(ViewModelWithTokenizedMessages)
            ' UI bindings for SendCustomMessage commands
            Dim fluentAPI = mvvmContext.OfType(Of ViewModelWithTokenizedMessages)()
            fluentAPI.BindCommand(sendMessageButton, Sub(x) x.SendTokenizedMessage())
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        Public Class ViewModelWithTokenizedMessages
            Private rnd As New Random()
            Public Sub SendTokenizedMessage()
                Dim parameter As Integer = rnd.Next(0, 100)
                Dim msg = New TokenizedMessage() With {.Parameter = parameter}
                If parameter Mod 10 = 0 Then
                    Messenger.Default.Send(msg, "Ten")
                Else
                    Messenger.Default.Send(msg, If(parameter Mod 2 = 1, "Odd", "Even"))
                End If
            End Sub
            ' Message related to this ViewModel (will be dispatched via string token)
            Public Class TokenizedMessage
                Public Property Parameter() As Object
            End Class
        End Class
        Public Class TokenizedMessagesAwareView
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
                Messenger.Default.Register(Of ViewModelWithTokenizedMessages.TokenizedMessage)(Me, "Odd", AddressOf OnOddMessage)
                Messenger.Default.Register(Of ViewModelWithTokenizedMessages.TokenizedMessage)(Me, "Even", AddressOf OnEvenMessage)
                Messenger.Default.Register(Of ViewModelWithTokenizedMessages.TokenizedMessage)(Me, "Ten", AddressOf OnTenMessage)
            End Sub
            Private Sub OnOddMessage(ByVal message As ViewModelWithTokenizedMessages.TokenizedMessage)
                LogMessage("Odd: " & message.Parameter.ToString())
            End Sub
            Private Sub OnEvenMessage(ByVal message As ViewModelWithTokenizedMessages.TokenizedMessage)
                LogMessage("Even: " & message.Parameter.ToString())
            End Sub
            Private Sub OnTenMessage(ByVal message As ViewModelWithTokenizedMessages.TokenizedMessage)
                LogMessage("Ten: " & message.Parameter.ToString())
            End Sub
            Private Sub LogMessage(ByVal message As String)
                memo.Text += (message & Environment.NewLine)
                memo.SelectionStart = memo.Text.Length
                memo.ScrollToCaret()
            End Sub
        End Class
    	End Class
End Namespace