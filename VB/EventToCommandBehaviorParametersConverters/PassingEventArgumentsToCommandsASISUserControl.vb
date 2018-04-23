Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace DxSampleEventToCommandBehaviorParametersConverters
    Partial Public Class PassingEventArgumentsToCommandsASISUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim mvvmContext As New MVVMContext()
            mvvmContext.ContainerControl = Me
        
            Dim panel As New PanelControl()
            panel.Dock = DockStyle.Top
            panel.Parent = Me
        
            Dim label As New LabelControl()
            label.Text = "Click to Execute Command"
            label.Dock = DockStyle.Fill
            label.AutoSizeMode = LabelAutoSizeMode.None
            label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            label.Parent = panel
        

            mvvmContext.ViewModelType = GetType(MouseDownAwareViewModel)
            ' UI binding for the EventToCommand behavior
            mvvmContext.OfType(Of MouseDownAwareViewModel)().WithEvent(Of MouseEventArgs)(label, "MouseDown").
                EventToCommand(Sub(x) x.ReportArgs(New MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0)))
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        Public Class MouseDownAwareViewModel
            Public Sub New()
                Message = "MouseDown performed!"
            End Sub
            Public Property Message() As String
            Protected ReadOnly Property MessageBoxService() As IMessageBoxService
                Get
                    Return Me.GetService(Of IMessageBoxService)()
                End Get
            End Property
            Public Sub Report(ByVal message As String)
                MessageBoxService.ShowMessage(message)
            End Sub
            Public Sub ReportArgs(ByVal args As MouseEventArgs)
        
                Dim msg As String = String.Join(", ",
                                          "Button: " & args.Button.ToString(),
                                          "Location: " & args.Location.ToString(),
                                          "Clicks: " & args.Clicks.ToString(),
                                          "Delta: " & args.Delta.ToString())
                MessageBoxService.ShowMessage("Args = {" & msg & "}")
            End Sub
            Public Sub ReportLocation(ByVal pt As Point)
                MessageBoxService.ShowMessage("Location = " & pt.ToString())
            End Sub
        End Class
    	End Class
End Namespace