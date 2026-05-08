using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonLauncher
{
    internal static class _﻿StaticRequests
    {
        internal const string defaultNickname = "Player";
        internal const string launcherName = "Minecraft Moon Launcher";
        internal static readonly string launcherVersion = Version.TryParse(Application.ProductVersion.Split('+')[0], out var v) ? v.ToString(3) : "?.?.?";
        internal static readonly string defaultGameDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft");
    }
}