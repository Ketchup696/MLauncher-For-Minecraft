using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonLauncher
{
    internal static class StaticRequests        // Статические запросы. Данные, которые НЕ БУДУТ изменяться в процессе выполнения программы.
    {
        internal const string defaultNickname = "Player";
        internal const string launcherName = "Minecraft Moon Launcher";
        internal static readonly string launcherVersion = Version.TryParse(Application.ProductVersion.Split('+')[0], out var v) ? v.ToString(3) : "0.0.0";
    }
}
