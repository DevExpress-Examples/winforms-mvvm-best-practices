Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms

Namespace DxSampleDialogServices
    Partial Public Class FlyoutDialogServiceUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim mvvmContext As New MVVMContext()
            mvvmContext.ContainerControl = Me
        
            Dim commandButton As New SimpleButton()
            commandButton.Text = "Execute Command"
            commandButton.Dock = DockStyle.Top
        
            Dim memo As New MemoEdit()
            memo.Dock = DockStyle.Top
            memo.Properties.ReadOnly = True
            memo.MinimumSize = New System.Drawing.Size(0, 100)
        
            commandButton.Parent = Me
            memo.Parent = Me
        

            ' Force use the FlyoutDialogService
            MVVMContext.RegisterFlyoutDialogService()
            '
            mvvmContext.ViewModelType = GetType(NotesViewModel)
            ' UI binding for Notes
            mvvmContext.SetBinding(memo, Function(m) m.EditValue, "Notes")
            ' UI binding for button
            mvvmContext.BindCommand(Of NotesViewModel)(commandButton, Sub(x) x.EditNotes())
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        Public Class NotesViewModel
            Public Sub New()
                Notes = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            End Sub
            Private privateNotes As String
            Public Overridable Property Notes() As String
                Get
                    Return privateNotes
                End Get
                Protected Set(ByVal value As String)
                    privateNotes = value
                End Set
            End Property
            ' using the GetService<> extension method for obtaining service instance
            Protected ReadOnly Property DialogService() As IDialogService
                Get
                    Return Me.GetService(Of IDialogService)()
                End Get
            End Property
            Public Sub EditNotes()
                Dim dialogParams = New Object() {Notes}
                If DialogService.ShowDialog(MessageButton.OKCancel, "Edit Notes", "EditNotes", dialogParams, Me) = MessageResult.OK Then
                    Notes = TryCast(dialogParams(0), String)
                End If
            End Sub
        End Class
        Public Class EditNotesViewModel
            Implements ISupportParameter
        
            Public Overridable Property Notes() As String
            Protected Sub OnNotesChanged()
                parameters(0) = Notes
            End Sub
            Private parameters() As Object
            Private Property ISupportParameter_Parameter() As Object Implements ISupportParameter.Parameter
                Get
                    Return parameters(0)
                End Get
                Set(ByVal value As Object)
                    If Object.ReferenceEquals(parameters, value) Then
                        Return
                    End If
                    parameters = DirectCast(value, Object())
                    Notes = TryCast(parameters(0), String)
                End Set
            End Property
        End Class
        Public Class NotesEditor
            Inherits XtraUserControl

            Public Sub New()
                Me.Padding = New Padding(12)
                Me.MinimumSize = New System.Drawing.Size(320, 160)
                '
                Dim mvvmContext As New MVVMContext()
                mvvmContext.ContainerControl = Me
                mvvmContext.ViewModelType = GetType(EditNotesViewModel)
                '
                Dim memo As New MemoEdit()
                memo.Dock = DockStyle.Fill
                memo.Parent = Me
                ' Data-binding for Notes
                mvvmContext.SetBinding(memo, Function(m) m.EditValue, "Notes")
            End Sub
        End Class
    	End Class
End Namespace