Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms

Namespace DxSampleDataBindingCapabilitiesConverters
    Partial Public Class DataBindingViaDefaultConvertersFluentAPIUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New()
            InitializeComponent()
            Dim mvvmContext As New MVVMContext()
            mvvmContext.ContainerControl = Me

            Dim trackBar As New TrackBarControl()
            trackBar.Dock = DockStyle.Top
            trackBar.Properties.Minimum = 0
            trackBar.Properties.Maximum = 100

            Dim editor As New TextEdit()
            editor.Dock = DockStyle.Top
            editor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            editor.Properties.Mask.EditMask = "N0"
            editor.Properties.Mask.UseMaskAsDisplayFormat = True

            editor.Parent = Me
            trackBar.Parent = Me

            ' Set type of POCO-ViewModel
            mvvmContext.ViewModelType = GetType(ViewModel)
            ' Data binding for the Progress property (via MVVMContext FluentAPI)
            Dim fluent = mvvmContext.OfType(Of ViewModel)()
            ' Binding two integer properties - 'Value' and 'Progress'. No conversion needed
            fluent.SetBinding(trackBar, Function(t) t.Value, Function(x) x.Progress)
            ' Binding the string 'Text' property to the integer 'Progress'. Values are automatically converted to/from an appropriate type.
            fluent.SetBinding(editor, Function(e) e.Text, Function(x) x.Progress)
        End Sub
        Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        Public Class ViewModel
            Public Overridable Property Progress() As Integer
        End Class
    End Class
End Namespace