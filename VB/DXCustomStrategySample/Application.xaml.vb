Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.UI.ViewInjection
Imports DevExpress.Xpf.Ribbon
Imports DXCustomStrategySample.Common
Imports DXCustomStrategySample.ViewModel
Imports System
Imports System.Windows
Imports System.Windows.Media.Imaging
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Core.Native

Namespace DXCustomStrategySample
    Partial Public Class App
        Inherits Application

        Private Sub Application_Startup(ByVal sender As Object, ByVal e As StartupEventArgs)
            StrategyManager.Default.RegisterStrategy(Of RibbonControl, ItemsControlStrategy(Of RibbonControl, RibbonControlWrapper))()
            InitModules()
            DevExpress.Xpf.Core.ApplicationThemeHelper.UpdateApplicationThemeName()
        End Sub
        Private Sub InitModules()
            ViewInjectionManager.Default.Inject(Regions.Main, Nothing, Function() RibbonItemViewModel.Create("Default PageCategory", "Default Page", "Default PageGroup", "New BarButtonItem #1", GetDXImageSourceByName("New_16x16.png")), String.Empty)
            ViewInjectionManager.Default.Inject(Regions.Main, Nothing, Function() RibbonItemViewModel.Create("Default PageCategory", "Default Page", "Custom PageGroup", "New BarButtonItem #2", GetDXImageSourceByName("New_16x16.png")), String.Empty)
            ViewInjectionManager.Default.Inject(Regions.Main, Nothing, Function() RibbonItemViewModel.Create("Default PageCategory", "Custom Page", "Custom PageGroup", "New BarButtonItem #3", GetDXImageSourceByName("New_16x16.png")), String.Empty)
            ViewInjectionManager.Default.Inject(Regions.Main, Nothing, Function() RibbonItemViewModel.Create("Custom PageCategory", "Custom Page", "Custom PageGroup", "New BarButtonItem #4", GetDXImageSourceByName("New_16x16.png")), String.Empty)
        End Sub
        Private Function GetDXImageSourceByName(imageName As String) As ImageSource
            Dim imageInfo As DXImageInfo = DirectCast(New DXImageConverter().ConvertFromString(imageName), DXImageInfo)
            Return New BitmapImage(imageInfo.MakeUri())
        End Function
    End Class
End Namespace
