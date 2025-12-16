using System;
using System.IO;

namespace FocusFlowFinal
{
    public class ThemeSettings
    {
        public string ThemeName { get; set; }
        public string DisplayName { get; set; }
        public int DurationMinutes { get; set; } = 25;
        public int Volume { get; set; } = 70;
        public bool IsMinimalist { get; set; } = true;
        public bool UseVideo { get; set; } = true;

        public string GetThemePath()
        {
            return Path.Combine("Themes", ThemeName);
        }

        public string GetVideoPath()
        {
            return Path.Combine(GetThemePath(), "video.mp4");
        }

        public string GetAudioPath()
        {
            return Path.Combine(GetThemePath(), "audio.mp3");
        }

        public string GetPreviewPath()
        {
            string jpgPath = Path.Combine(GetThemePath(), "preview.jpg");
            string pngPath = Path.Combine(GetThemePath(), "preview.png");
            string defaultPath = Path.Combine("Themes", "default.jpg");

            if (File.Exists(jpgPath)) return jpgPath;
            if (File.Exists(pngPath)) return pngPath;
            if (File.Exists(defaultPath)) return defaultPath;
            return "";
        }
    }
}