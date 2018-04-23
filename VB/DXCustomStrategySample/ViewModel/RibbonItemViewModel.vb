Imports DevExpress.Mvvm.POCO
Imports System.Windows.Media

Namespace DXCustomStrategySample.ViewModel

	Public Class RibbonItemViewModel
		Private privateCategory As String
		Public Overridable Property Category() As String
			Get
				Return privateCategory
			End Get
			Protected Set(ByVal value As String)
				privateCategory = value
			End Set
		End Property
		Private privatePage As String
		Public Overridable Property Page() As String
			Get
				Return privatePage
			End Get
			Protected Set(ByVal value As String)
				privatePage = value
			End Set
		End Property
		Private privateGroup As String
		Public Overridable Property Group() As String
			Get
				Return privateGroup
			End Get
			Protected Set(ByVal value As String)
				privateGroup = value
			End Set
		End Property
		Private privateContent As String
		Public Overridable Property Content() As String
			Get
				Return privateContent
			End Get
			Protected Set(ByVal value As String)
				privateContent = value
			End Set
		End Property
		Private privateGlyph As ImageSource
		Public Overridable Property Glyph() As ImageSource
			Get
				Return privateGlyph
			End Get
			Protected Set(ByVal value As ImageSource)
				privateGlyph = value
			End Set
		End Property

		Protected Sub New()
		End Sub

		Public Shared Function Create(ByVal category As String, ByVal page As String, ByVal group As String, ByVal content As String, ByVal image As ImageSource) As RibbonItemViewModel
			Dim vm = ViewModelSource.Create(Function() New RibbonItemViewModel())
			vm.Category = category
			vm.Page = page
			vm.Group = group
			vm.Content = content
			vm.Glyph = image
			Return vm
		End Function
	End Class
End Namespace
