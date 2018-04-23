Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace DxSampleSimpleBehaviors
    Partial Public Class ConfirmationBehaviorSeparateClassUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim mvvmContext As New MVVMContext()
            mvvmContext.ContainerControl = Me
        
            Dim editor As New CheckEdit()
            editor.Dock = DockStyle.Top
            editor.Text = "Please, try to change checked state of this editor"
            editor.Parent = Me
        

            ' UI binding for the EditValueChangingConfirmation behavior
            mvvmContext.AttachBehavior(Of EditValueChangingConfirmation)(editor)
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        Public Class EditValueChangingConfirmation
            Inherits ConfirmationBehavior(Of ChangingEventArgs)
            Public Sub New()
                MyBase.New("EditValueChanging")
            End Sub
            Protected Overrides Function GetConfirmationCaption() As String
                Return "EditValue changing confirmation"
            End Function
            Protected Overrides Function GetConfirmationText() As String
                Return "This editor's EditValue is about to be changed. Are you sure?"
            End Function
        End Class
    	End Class
End Namespace