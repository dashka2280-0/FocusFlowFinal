using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusFlowFinal
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Создаем необходимые папки
            CreateRequiredFolders();

            // Запускаем главную форму
            Application.Run(new MainForm());
        }

        static void CreateRequiredFolders()
        {
            try
            {
                // Основные папки
                string[] folders =
                {
                    "Themes",
                    "Themes\\Rain",
                    "Themes\\Forest",
                    "Themes\\Fireplace",
                    "Themes\\Cafe",
                    "Themes\\Space",
                    "Themes\\City",
                    "Themes\\Ocean",
                    "Themes\\Library",
                    "Themes\\Custom"
                };

                foreach (var folder in folders)
                {
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                        Console.WriteLine($"Создана папка: {folder}");
                    }
                }

                // Создаем инструкцию
                CreateReadmeFile();

                // Информируем пользователя
                ShowWelcomeMessage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка создания папок: {ex.Message}",
                    "FocusFlow", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        static void CreateReadmeFile()
        {
            string readmePath = Path.Combine("Themes", "README.txt");
            if (!File.Exists(readmePath))
            {
                string readmeContent = @"Как добавить тему в FocusFlow:

1. Создайте папку в Themes\ с названием темы (например: Rain)
2. Добавьте в неё файлы:
   - audio.mp3 (звук, обязательно)
   - video.mp4 (видеофон, опционально)
   - preview.jpg или preview.png (изображение превью, опционально)

Пример для темы 'Дождь':
   Themes\Rain\audio.mp3    (звук дождя)
   Themes\Rain\video.mp4    (видео дождя)
   Themes\Rain\preview.jpg  (картинка с дождем)

3. Форматы файлов:
   - Видео: MP4, AVI, MOV, MKV
   - Аудио: MP3, WAV
   - Изображение: JPG, PNG, BMP

4. Или используйте кнопку 'Создать свою тему' в программе.

Приятного использования FocusFlow!";

                File.WriteAllText(readmePath, readmeContent);
            }
        }

        static void ShowWelcomeMessage()
        {
            // Показываем сообщение только при первом запуске
            string configFile = "first_run.cfg";
            if (!File.Exists(configFile))
            {
                MessageBox.Show(
                    "Добро пожаловать в FocusFlow!\n\n" +
                    "Программа создала папки для тем в:\n" +
                    Directory.GetCurrentDirectory() + "\\Themes\\\n\n" +
                    "Чтобы добавить тему:\n" +
                    "1. Зайдите в папку Themes\\\n" +
                    "2. Создайте папку с названием темы\n" +
                    "3. Добавьте audio.mp3 и video.mp4\n\n" +
                    "Или используйте кнопку 'Создать свою тему' в программе.",
                    "FocusFlow - Первый запуск",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                File.WriteAllText(configFile, "first_run_completed");
            }
        }
    }
}
