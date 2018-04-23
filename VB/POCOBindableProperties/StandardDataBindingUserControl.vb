Imports DevExpress.MVVM
Imports DevExpress.MVVM.DataAnnotations
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms

Namespace DxSamplePOCOBindableProperties
    Partial Public Class StandardDataBindingUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim mvvmContext As New MVVMContext()
            mvvmContext.ContainerControl = Me
        
            Dim editor As New TextEdit()
            editor.Dock = DockStyle.Top
            editor.Properties.NullValuePrompt = "Please, enter the Title here..."
            editor.Properties.NullValuePromptShowForEmptyValue = True
        
            Dim commandButton As New SimpleButton()
            commandButton.Dock = DockStyle.Top
            commandButton.Text = "Report the Title property value"
        
            commandButton.Parent = Me
            editor.Parent = Me

            ' Set type of POCO-ViewModel
            mvvmContext.ViewModelType = GetType(ViewModel)
            Dim viewModel As ViewModel = mvvmContext.GetViewModel(Of ViewModel)()
            ' Data binding for the Title property (via the DataBindings collection)
            editor.DataBindings.Add("EditValue", viewModel, "Title", True, DataSourceUpdateMode.OnPropertyChanged)
            ' UI binding for the Report command
            AddHandler commandButton.Click, Sub(s, e) XtraMessageBox.Show(viewModel.GetTitleAsHumanReadableString())
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        '' 
        '' POCO View Model provides out-of-the-box support of the INotifyPropertyChanged.
        '' 
        Public Class ViewModel
            ' Bindable property will be created from this property.
            Public Overridable Property Title() As String
            ' Just a method for readability
            Public Function GetTitleAsHumanReadableString() As String
                If Title Is Nothing Then
                    Return "(Null)"
                End If
                If Title.Length = 0 Then
                    Return "(Empty)"
                End If
                If String.IsNullOrWhiteSpace(Title) Then
                    Return "(WhiteSpace)"
                End If
                Return Title
            End Function
        End Class
    	End Class
End Namespace