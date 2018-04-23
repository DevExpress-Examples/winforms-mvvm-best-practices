Imports DevExpress.MVVM
Imports DevExpress.MVVM.DataAnnotations
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms

Namespace DxSamplePOCODependencies
    Partial Public Class PropertyChangedNotificationsUserControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Public Sub New() 
            InitializeComponent()
            Dim mvvmContext As New MVVMContext()
            mvvmContext.ContainerControl = Me
        
            Dim editor1 As New TextEdit()
            editor1.Dock = DockStyle.Top
            editor1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            editor1.Properties.Mask.EditMask = "n0"
            editor1.Properties.Mask.UseMaskAsDisplayFormat = True
        
            Dim editor2 As New TextEdit()
            editor2.Dock = DockStyle.Top
            editor2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            editor2.Properties.Mask.EditMask = "n0"
            editor2.Properties.Mask.UseMaskAsDisplayFormat = True
        
            Dim resultLabel As New LabelControl()
            resultLabel.Dock = DockStyle.Top
            resultLabel.AutoSizeMode = LabelAutoSizeMode.Vertical
        
            resultLabel.Parent = Me
            editor1.Parent = Me
            editor2.Parent = Me

            ' Set type of POCO-ViewModel
            mvvmContext.ViewModelType = GetType(SumViewModel)
            ' Data binding for the operands
            mvvmContext.SetBinding(editor1, Function(e) e.EditValue, "Operand1")
            mvvmContext.SetBinding(editor2, Function(e) e.EditValue, "Operand2")
            ' Data binding for the result
            mvvmContext.SetBinding(resultLabel, Function(l) l.Text, "ResultText")
        End Sub
         Private Sub OnDisposing()
            Dim context = MVVMContext.FromControl(Me)
            If context IsNot Nothing Then
                context.Dispose()
            End If
        End Sub
        '' 
        '' POCO View Model supports attributes and extension-methods for different purposes.
        '' 
        Public Class SumViewModel
            Public Sub New()
                Operand1 = 2
                Operand2 = 2
            End Sub
            ' using the BindableProperty attribute
            <BindableProperty(OnPropertyChangedMethodName:="NotifyResultAndResultTextChanged")>
            Public Overridable Property Operand1() As Integer
            ' using the BindableProperty attribute
            <BindableProperty(OnPropertyChangedMethodName:="NotifyResultAndResultTextChanged")>
            Public Overridable Property Operand2() As Integer
            ' We will raise change-notification for this property manually
            Public ReadOnly Property Result() As Integer
                Get
                    Return Operand1 + Operand2
                End Get
            End Property
            ' We will raise change-notification for this property manually
            Public ReadOnly Property ResultText() As String
                Get
                    Return String.Format("The result of operands summarization is: {0:n0}", Result)
                End Get
            End Property
            Protected Sub NotifyResultAndResultTextChanged()
                Me.RaisePropertyChanged(Function(x) x.Result) ' change-notification for the Result
                Me.RaisePropertyChanged(Function(x) x.ResultText) ' change-notification for the ResultText
            End Sub
        End Class
    	End Class
End Namespace