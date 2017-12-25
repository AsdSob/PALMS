using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PALMS.ViewModels.Dictionaries
{
    public class DictionaryItemViewModel<T> : ViewModelBase where T : NameEntity
    {
        private string _name;

        /// <summary>
        /// Gets or sets the original entity.
        /// </summary>
        public T OriginalEntity { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { Set(() => Name, ref _name, value); }
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="entity">The dictionary entity.</param>
        public DictionaryItemViewModel([NotNull] T entity)
        {
            OriginalEntity = entity;

            Name = OriginalEntity.Name;
        }
    }
}
