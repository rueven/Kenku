using Kenku.Models.Interfaces;
using Kenku.Services.Interfaces;

namespace Kenku.WinformApplication.Extensions
{
    internal static class DropDownExtensions
    {
        public static void BindTextToSpeechServices(this ComboBox comboBox, IReadOnlyList<ITextToSpeechService> textToSpeechServices, ITextToSpeechService? defaultValue = null) => comboBox
            .BindDataItem(textToSpeechServices, x => x.Name, defaultValue);

        public static void BindPersonalities(this ComboBox comboBox, IReadOnlyList<IReadOnlyPersonality> personalities, IReadOnlyPersonality? defaultValue = null) => comboBox
            .BindDataItem(personalities, x => x.Name, defaultValue);

        private static void BindDataItem<T>(this ComboBox comboBox, IReadOnlyList<T> items, Func<T, string> nameSelector, T? defaultValue = null)
            where T : class
        {
            comboBox
                .SuspendLayout();
            var selectedValue = defaultValue ?? comboBox
                .SelectedItem as T;
            comboBox
                .Items
                .Clear();
            foreach (var item in items.OrderBy(nameSelector))
            {
                comboBox
                    .Items
                    .Add(item);
            }
            if (items.Contains(selectedValue))
            {
                comboBox.SelectedItem = selectedValue;
            }
            comboBox
                .ResumeLayout();
        }
    }
}