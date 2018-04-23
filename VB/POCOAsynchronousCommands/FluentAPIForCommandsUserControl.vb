Imports DevExpress.MVVM
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace DxSamplePOCOAsynchronousCommands
    Partial Public Class FluentAPIForCommandsUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim mvvmContext As New MVVMContext()
            mvvmContext.ContainerControl = Me
        
            Dim progressBar As New ProgressBarControl()
            progressBar.Dock = DockStyle.Top
        
            Dim commandButton As New SimpleButton()
            commandButton.Text = "Start Command Execution"
            commandButton.Dock = DockStyle.Top
        
            Dim cancelButton As New SimpleButton()
            cancelButton.Text = "Cancel Command Execution"
            cancelButton.Dock = DockStyle.Top
        
            cancelButton.Parent = Me
            commandButton.Parent = Me
            progressBar.Parent = Me

            mvvmContext.ViewModelType = GetType(ViewModelWithAsyncCommandAndCancellation)
            Dim fluentAPI = mvvmContext.OfType(Of ViewModelWithAsyncCommandAndCancellation)()
            ' UI binding for button
            fluentAPI.BindCommand(commandButton, Sub(x) x.DoSomethingAsynchronously())
            ' UI binding for cancelation
            fluentAPI.BindCancelCommand(cancelButton, Sub(x) x.DoSomethingAsynchronously())
            ' UI binding for progress
            fluentAPI.SetBinding(progressBar, Function(p) p.EditValue, Function(x) x.Progress)
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        Public Class ViewModelWithAsyncCommandAndCancellation
            ' Asynchronous POCO-command will be created from this method.
            Public Function DoSomethingAsynchronously() As Task
                Return Task.Factory.StartNew(
                    Sub()
                        Dim asyncCommand = Me.GetAsyncCommand(Function(x) x.DoSomethingAsynchronously())
                        For i As Integer = 0 To 100
                            If asyncCommand.IsCancellationRequested Then
                                Exit For
                            End If
                            ' do some work here
                            System.Threading.Thread.Sleep(25)
                            UpdateProgressOnUIThread(i)
                        Next i
                        UpdateProgressOnUIThread(0)
                    End Sub)
            End Function
            ' Property for progress
            Private privateProgress As Integer
            Public Property Progress() As Integer
                Get
                    Return privateProgress
                End Get
                Private Set(ByVal value As Integer)
                    privateProgress = value
                End Set
            End Property
            Protected ReadOnly Property DispatcherService() As IDispatcherService
                Get
                    Return Me.GetService(Of IDispatcherService)()
                End Get
            End Property
            Private Sub UpdateProgressOnUIThread(ByVal progress As Integer)
                DispatcherService.BeginInvoke(Sub()
                                                  Me.Progress = progress
                                                  Me.RaisePropertyChanged(Function(x) x.Progress)
                                              End Sub)
            End Sub
        End Class
    	End Class
End Namespace