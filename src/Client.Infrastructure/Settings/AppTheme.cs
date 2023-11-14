﻿using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure.Settings
{
    public class AppTheme
    {

        public static MudTheme DefaultTheme = new MudTheme()
        {
            Palette = new PaletteDark()
            {
                Primary = "#1E88E5",
                Success = "#007E33",
                Black = "#27272f",
                Background = "#32333d",
                BackgroundGrey = "#27272f",
                Surface = "#373740",
                DrawerBackground = "#27272f",
                DrawerText = "rgba(255,255,255, 0.50)",
                AppbarBackground = "#373740",
                AppbarText = "rgba(255,255,255, 0.70)",
                TextPrimary = "rgba(255,255,255, 0.70)",
                TextSecondary = "rgba(255,255,255, 0.50)",
                ActionDefault = "#adadb1",
                ActionDisabled = "rgba(255,255,255, 0.26)",
                ActionDisabledBackground = "rgba(255,255,255, 0.12)",
                DrawerIcon = "rgba(255,255,255, 0.50)"
            },
        };
    }
}
