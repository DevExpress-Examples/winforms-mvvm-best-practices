Imports DevExpress.MVVM
Imports DevExpress.MVVM.DataAnnotations
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms

Namespace DxSampleBindingToLegacyViewModels
    Partial Public Class DataBindingViaMVVMContextUserControl
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

            Dim legacyViewModel = New LegacyViewModel("Legacy ViewModel")
            ' initialize the MVVMContext with the specific ViewModel's instance
            mvvmContext.SetViewModel(GetType(LegacyViewModel), legacyViewModel)
            ' Data binding for the Title property (via MVVMContext API)
            mvvmContext.SetBinding(editor, Function(e) e.EditValue, "Title")
            ' UI binding for the Report command
            AddHandler commandButton.Click, Sub(s, e) XtraMessageBox.Show(legacyViewModel.Title)
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        Public Class LegacyViewModel
            Private titleCore As String
            Public Sub New(ByVal title As String)
                Me.titleCore = title
            End Sub
            Public Overridable Property Title() As String
                Get
                    Return titleCore
                End Get
                Set(ByVal value As String)
                    If titleCore = value Then
                        Return
                    End If
                    titleCore = value
                    OnTitleChanged()
                End Set
            End Property
            Private Sub OnTitleChanged()
                Dim h As EventHandler = TitleChangedEvent
                If h IsNot Nothing Then
                    h(Me, EventArgs.Empty)
                End If
            End Sub
            Public Event TitleChanged As EventHandler
        End Class
    	End Class
End Namespace