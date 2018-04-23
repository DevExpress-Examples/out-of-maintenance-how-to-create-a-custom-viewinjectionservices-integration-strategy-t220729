Imports DevExpress.Mvvm.UI.ViewInjection
Imports DevExpress.Xpf.Bars
Imports DevExpress.Xpf.Ribbon
Imports DXCustomStrategySample.ViewModel
Imports System
Imports System.Collections.Specialized
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls

Namespace DXCustomStrategySample.Common
	Public Class RibbonControlWrapper
		Implements IItemsControlWrapper(Of RibbonControl)

         
        Private _Target As RibbonControl
		Public WriteOnly Property Target() As RibbonControl Implements DevExpress.Mvvm.UI.ViewInjection.ITargetWrapper(Of RibbonControl).Target
            Set
                _Target = value
            End Set
        End Property
		Private _ItemsSource As Object
		Public Property ItemsSource() As Object Implements IItemsControlWrapper(Of RibbonControl).ItemsSource
			Get
				Return _ItemsSource
			End Get
			Set(ByVal value As Object)
				If _ItemsSource IsNot value Then
					If _ItemsSource IsNot Nothing Then
						RemoveHandler DirectCast(_ItemsSource, INotifyCollectionChanged).CollectionChanged, AddressOf RibbonControlWrapper_CollectionChanged
					End If
					_ItemsSource = value
					AddHandler DirectCast(_ItemsSource, INotifyCollectionChanged).CollectionChanged, AddressOf RibbonControlWrapper_CollectionChanged
				End If
			End Set
		End Property

		Private Sub RibbonControlWrapper_CollectionChanged(ByVal sender As Object, ByVal e As System.Collections.Specialized.NotifyCollectionChangedEventArgs)
			If e.Action = NotifyCollectionChangedAction.Add Then
				For Each vm As RibbonItemViewModel In e.NewItems
					Dim category = _Target.Categories.FirstOrDefault(Function(c) String.Equals(c.Name, vm.Category) OrElse String.Equals(c.Caption, vm.Category))
					If category Is Nothing Then
						category = New RibbonPageCategory() With {.Name = vm.Category.Replace(" ", ""), .Caption = vm.Category}
						_Target.Categories.Add(category)
					End If
					Dim page = category.Pages.FirstOrDefault(Function(p) String.Equals(p.Name, vm.Page) OrElse String.Equals(p.Caption, vm.Page))
					If page Is Nothing Then
						page = New RibbonPage() With {.Name = vm.Page.Replace(" ", ""), .Caption = vm.Page}
						category.Pages.Add(page)
					End If
					Dim group = page.Groups.FirstOrDefault(Function(g) String.Equals(g.Name, vm.Group) OrElse String.Equals(g.Caption, vm.Group))
					If group Is Nothing Then
						group = New RibbonPageGroup() With {.Name = vm.Group.Replace(" ", ""), .Caption = vm.Group}
						page.Groups.Add(group)

					End If
					group.Items.Add(New BarButtonItem() With {.Content = vm.Content, .Glyph = vm.Glyph})
				Next vm
			End If
		End Sub

		Public Overridable Property ItemTemplate() As DataTemplate Implements IItemsControlWrapper(Of RibbonControl).ItemTemplate
		Public Overridable Property ItemTemplateSelector() As DataTemplateSelector Implements IItemsControlWrapper(Of RibbonControl).ItemTemplateSelector
	End Class
End Namespace
