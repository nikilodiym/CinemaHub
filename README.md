# 🎨 Як підключити стилі до проєкту

## 🧩 Варіант 1 — Через `Window.Resources`

```xml
<Window x:Class="CinemaWPF.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="450" Width="800">
    <Window.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <!-- Шлях до файлів стилів -->
                <ResourceDictionary Source="/Resources/Styles/ButtonStyles.xaml" />
                <ResourceDictionary Source="/Resources/Styles/TextStyles.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Window.Resources>

    <Grid>
        <!-- Наш код -->
    </Grid>
</Window>
