using DevExpress.Mvvm;
using DevExpress.Mvvm.UI.ModuleInjection;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.Ribbon;
using DXCustomStrategySample.Common;
using DXCustomStrategySample.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DXCustomStrategySample {
    public partial class App : Application {
        private void Application_Startup(object sender, StartupEventArgs e) {            
            StrategyManager.Default.RegisterStrategy<RibbonControl, ItemsControlStrategy<RibbonControl, RibbonControlWrapper>>();
            InitModules();
            DevExpress.Xpf.Core.ApplicationThemeHelper.UpdateApplicationThemeName();
        }
        private void InitModules() {
            ViewInjectionManager.Default.Inject(
                Regions.Main,
                null,
                () => RibbonItemViewModel.Create(
                    "Default PageCategory", 
                    "Default Page", 
                    "Default PageGroup", 
                    "New BarButtonItem #1",
                    GetDXImageSourceByName("New_16x16.png")
                ),
                String.Empty
            );
            ViewInjectionManager.Default.Inject(
                Regions.Main,
                null,
                () => RibbonItemViewModel.Create(
                    "Default PageCategory", 
                    "Default Page", 
                    "Custom PageGroup", 
                    "New BarButtonItem #2",
                    GetDXImageSourceByName("New_16x16.png")
                ),
                String.Empty
            );
            ViewInjectionManager.Default.Inject(
                Regions.Main,
                null,
                () => RibbonItemViewModel.Create(
                    "Default PageCategory", 
                    "Custom Page", 
                    "Custom PageGroup", 
                    "New BarButtonItem #3",
                    GetDXImageSourceByName("New_16x16.png")
                ),
                String.Empty
            );
            ViewInjectionManager.Default.Inject(
                Regions.Main,
                null,
                () => RibbonItemViewModel.Create(
                    "Custom PageCategory", 
                    "Custom Page", 
                    "Custom PageGroup", 
                    "New BarButtonItem #4",
                    GetDXImageSourceByName("New_16x16.png")
                ),
                String.Empty
            );
        }

        ImageSource GetDXImageSourceByName(string imageName) {
            DXImageInfo imageInfo = (DXImageInfo)new DXImageConverter().ConvertFromString(imageName);
            return new BitmapImage(imageInfo.MakeUri());
        }
    }
}
