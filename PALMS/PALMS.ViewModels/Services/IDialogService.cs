using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PALMS.ViewModels.Services
{
    public interface IDialogService
    {
        /// <summary>
        /// Show dialog.
        /// </summary>
        /// <param name="windowDialogViewModel">The view model of the window.</param>
        /// <returns>The dialog result.</returns>
        bool ShowDialog(IWindowDialogViewModel windowDialogViewModel);

        /// <summary>
        /// Show question dialog.
        /// </summary>
        /// <param name="questionMessage"></param>
        /// <returns></returns>
        bool ShowQuestionDialog(string questionMessage);

        /// <summary>
        /// Show error dialog.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        bool ShowErrorDialog(string errorMessage);
    }
}
