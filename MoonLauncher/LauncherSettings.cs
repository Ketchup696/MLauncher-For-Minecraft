using System;
using System.Collections.Generic;
using System.Text;

namespace MoonLauncher
{
    public class LauncherSettings
    {
        public int AllocatedMemoryGB { get; set; } = 4;
        public string LastNickname { get; set; } = "";
        public string LastVersion { get; set; } = "";
        public string GameDir { get; set; } = "";
        public string LastGameDir { get; set; } = "";
        public List<string> SavedNicknames { get; set; } = new();
    }
}
