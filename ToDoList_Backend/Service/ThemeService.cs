using System.Runtime;
using System.Threading.Tasks;
using to_do_list.Models;
using ToDoList_Backend.Models;

namespace ToDoList_Backend.Service
{
    public class ThemeService
    {
        private readonly IsDarkModel _theme = new();

        public IsDarkModel GetTheme() => _theme;

        public void ChangeTheme()
        {
            _theme.IsDarkMode = !_theme.IsDarkMode;
        }
    }
}
