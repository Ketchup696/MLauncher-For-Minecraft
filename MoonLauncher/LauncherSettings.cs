using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static MoonLauncher.StaticRequests;

namespace MoonLauncher
{
    public class LauncherSettings
    {
        public int AllocatedMemoryGB { get; set; } = 4;
        public string LastNickname { get; set; } = "";
        public string LastVersion { get; set; } = "";
        public string GameDir { get; set; } = "";
        public string LastGameDir { get; set; } = "";
        public BindingList<string> SavedNicknames { get; set; } = new BindingList<string> {defaultNickname};
    }
}
