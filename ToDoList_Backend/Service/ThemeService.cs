using System.Runtime;
using System.Threading.Tasks;
using to_do_list.Models;
using ToDoList_Backend.Models;

namespace ToDoList_Backend.Service
{
    public class ThemeService
    {
        private readonly UserPreferencesModel _theme = new();

        public UserPreferencesModel GetTheme() => _theme;

        public void ChangeTheme()
        {
            _theme.IsDarkMode = !_theme.IsDarkMode;
        }
        public void ChangeLanguage()
        {
            _theme.Language = !_theme.Language;
        }
    }
}
