Imports DevExpress.MVVM
Imports DevExpress.MVVM.DataAnnotations
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms

Namespace DxSampleDataBindingCapabilitiesBindingPath
    Partial Public Class DataBindingToNestedPropertiesFluentAPIUserControl
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
            ' Data binding for the Title property of nested ViewModel (via MVVMContext FluentAPI)
            Dim fluent = mvvmContext.OfType(Of ViewModel)()
            fluent.SetBinding(editor, Function(e) e.EditValue, Function(x) x.Child.Title)
            ' UI binding for the Report command
            Dim viewModel As ViewModel = mvvmContext.GetViewModel(Of ViewModel)()
            AddHandler commandButton.Click, Sub(s, e) XtraMessageBox.Show(viewModel.GetChildTitleAsHumanReadableString())
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        Public Class ViewModel
            Public Sub New()
                ' Create Nested ViewModel as POCO-ViewModel
                Child = ViewModelSource.Create(Of NestedViewModel)()
            End Sub
            ' Nested ViewModel
            Private privateChild As NestedViewModel
            Public Property Child() As NestedViewModel
                Get
                    Return privateChild
                End Get
                Private Set(ByVal value As NestedViewModel)
                    privateChild = value
                End Set
            End Property
            ' Just a method for readability
            Public Function GetChildTitleAsHumanReadableString() As String
                If Child.Title Is Nothing Then
                    Return "Child.Title is (Null)"
                End If
                If Child.Title.Length = 0 Then
                    Return "Child.Title is (Empty)"
                End If
                If String.IsNullOrWhiteSpace(Child.Title) Then
                    Return "Child.Title is (WhiteSpace)"
                End If
                Return "Child.Title = " & Child.Title
            End Function
        End Class
        Public Class NestedViewModel
            Public Overridable Property Title() As String
        End Class
    	End Class
End Namespace