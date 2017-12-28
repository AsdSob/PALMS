using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace PALMS.ViewModels
{
    public abstract class SectionViewModel<T> : ViewModelBase, ISection where T : ViewModelBase
    {
            private string _name;

            public string Name
            {
                get { return _name; }
                set { Set(() => Name, ref _name, value); }
            }
    }

    public interface ISection
    {
        string Name { get; set; }
    }

    public class ClientsSection : SectionViewModel<DataViewModel>
    {

    }

    public class MasterLinensSection : SectionViewModel<MasterLinenViewModel>
    {

    }
}
