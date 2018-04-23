Imports DevExpress.MVVM
Imports DevExpress.MVVM.DataAnnotations
Imports DevExpress.MVVM.POCO
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms

Namespace DxSamplePOCODependencies
    Partial Public Class SimpleDependenciesUserControl
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
            mvvmContext.ViewModelType = GetType(MultViewModel)
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
        '' POCO View Model provides out-of-the-box support of the OnXXXChanging/OnXXXChanged callbacks.
        '' 
        Public Class MultViewModel
            Public Sub New()
                Operand1 = 2
                Operand2 = 3
            End Sub
            Public Overridable Property Operand1() As Integer
            Public Overridable Property Operand2() As Integer
            Public Overridable Property Result() As Integer
            Public Overridable Property ResultText() As String
            ' OnChanged callback will be created for the Operand1 property from this method.
            Protected Sub OnOperand1Changed()
                ' Result depends on Operand1
                UpdateResult()
            End Sub
            ' OnChanged callback will be created for the Operand2 property from this method.
            Protected Sub OnOperand2Changed()
                ' Result depends on Operand2
                UpdateResult()
            End Sub
            ' OnChanged callback will be created for the Result property from this method.
            Protected Sub OnResultChanged()
                ' ResultText depends on Result
                UpdateResultText()
            End Sub
            Private Sub UpdateResult()
                Result = Operand1 * Operand2
            End Sub
            Private Sub UpdateResultText()
                ResultText = String.Format("The result of operands multiplication is: {0:n0}", Result)
            End Sub
        End Class
    	End Class
End Namespace