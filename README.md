**Як підключити стилі до проекту**
<Window.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <!-- Шлях до файлу стилів -->
                **<ResourceDictionary Source="/Resources/Styles/ButtonStyles.xaml"/>
                <ResourceDictionary Source="/Resources/Styles/TextStyles.xaml"/>**
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Window.Resources>
    
  <Grid>
        <!-- Наш код -->
  </Grid>
</Window>

Або

**DynamicResource (для динамічної зміни стилів)**
xml:
<Button Style="{DynamicResource CinemaPrimaryButton}" Content="Dynamic Style"/>
csharp:
this.Resources["CinemaPrimaryButton"] = new Style(typeof(Button)) { /* нові параметри */ };
