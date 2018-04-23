using DevExpress.Mvvm.UI.ModuleInjection;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Ribbon;
using DXCustomStrategySample.ViewModel;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DXCustomStrategySample.Common {
    public class RibbonControlWrapper : IItemsControlWrapper<RibbonControl> {
        public RibbonControl Target { get; set; }
        private object _ItemsSource;
        public object ItemsSource {
            get {
                return _ItemsSource;
            }
            set {
                if (_ItemsSource != value) {
                    if (_ItemsSource != null)
                        ((INotifyCollectionChanged)_ItemsSource).CollectionChanged -= RibbonControlWrapper_CollectionChanged;
                    _ItemsSource = value;
                    ((INotifyCollectionChanged)_ItemsSource).CollectionChanged += RibbonControlWrapper_CollectionChanged;
                }
            }
        }

        void RibbonControlWrapper_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            if (e.Action == NotifyCollectionChangedAction.Add) {
                foreach (RibbonItemViewModel vm in e.NewItems) {
                    var category = Target.Categories.FirstOrDefault(c => String.Equals(c.Name, vm.Category) || String.Equals(c.Caption, vm.Category));
                    if (category == null) {
                        category = new RibbonPageCategory() { Name = vm.Category.Replace(" ", ""), Caption = vm.Category };
                        Target.Categories.Add(category);
                    }
                    var page = category.Pages.FirstOrDefault(p => String.Equals(p.Name, vm.Page) || String.Equals(p.Caption, vm.Page));
                    if (page == null) {
                        page = new RibbonPage() { Name = vm.Page.Replace(" ", ""), Caption = vm.Page };
                        category.Pages.Add(page);
                    }
                    var group = page.Groups.FirstOrDefault(g => String.Equals(g.Name, vm.Group) || String.Equals(g.Caption, vm.Group));
                    if (group == null) {
                        group = new RibbonPageGroup() { Name = vm.Group.Replace(" ", ""), Caption = vm.Group };
                        page.Groups.Add(group);

                    }
                    group.Items.Add(new BarButtonItem() { Content = vm.Content, Glyph = vm.Glyph });
                }
            }
        }

        public virtual DataTemplate ItemTemplate { get; set; }
        public virtual DataTemplateSelector ItemTemplateSelector { get; set; }
    }
}
