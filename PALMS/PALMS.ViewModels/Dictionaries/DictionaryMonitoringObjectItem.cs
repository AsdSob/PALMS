using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PALMS.ViewModels.Dictionaries
{
    public class DictionaryMonitoringObjectItem : DictionaryItemViewModel<MonitoringObject>
    {
        private string _code;

        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { Set(() => Code, ref _code, value); }
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="entity">The dictionary entity.</param>
        public DictionaryMonitoringObjectItem(MonitoringObject entity) : base(entity)
        {
            Code = OriginalEntity?.Code;
        }
    }
}
