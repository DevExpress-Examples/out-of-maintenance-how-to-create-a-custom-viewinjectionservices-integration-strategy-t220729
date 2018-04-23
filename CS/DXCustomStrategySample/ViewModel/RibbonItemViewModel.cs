using DevExpress.Mvvm.POCO;
using System.Windows.Media;

namespace DXCustomStrategySample.ViewModel {
    
    public class RibbonItemViewModel {
        public virtual string Category { get; protected set; }
        public virtual string Page { get; protected set; }
        public virtual string Group { get; protected set; }
        public virtual string Content { get; protected set; }
        public virtual ImageSource Glyph { get; protected set; }

        protected RibbonItemViewModel() { }

        public static RibbonItemViewModel Create(string category, string page, string group, string content, ImageSource image) {
            var vm = ViewModelSource.Create(() => new RibbonItemViewModel());
            vm.Category = category;
            vm.Page = page;
            vm.Group = group;
            vm.Content = content;
            vm.Glyph = image;
            return vm;
        }
    }
}
