using Kenku.Services.Interfaces;

namespace Kenku.WinformApplication.Extensions
{
    internal static class CheckedListBoxExtensions
    {
        public static void SetAllCheckValue(this CheckedListBox checkedListBox, bool isChecked)
        {
            checkedListBox.SuspendLayout();
            for (var i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox
                    .SetItemChecked(i, isChecked);
            }
            checkedListBox.ResumeLayout();
        }

        public static CheckedListBox DataBindNamedServices<T>(this CheckedListBox checkedBoxList, IReadOnlyList<T> items, bool defaultChecked)
            where T: INamedService
        {
            checkedBoxList.SuspendLayout();
            foreach (var item in items)
            {
                checkedBoxList
                    .Items
                    .Add(new BindableNamedService<T>()
                    {
                        Service = item
                    }, defaultChecked);
            }
            checkedBoxList.ResumeLayout();
            return checkedBoxList;
        }


        public static IReadOnlyList<T> GetCheckedNamedServices<T>(this CheckedListBox checkedListBox)
            where T : INamedService
        {
            var output = new List<T>();
            foreach (var checkedItem in checkedListBox.CheckedItems)
            {
                if (checkedItem is BindableNamedService<T> service)
                {
                    output.Add(service.Service);
                }
            }
            return output;
        }

        private class BindableNamedService<T>
            where T : INamedService
        {
            public string Name => this.Service.Name;
            public required T Service { get; set; }
            public override string ToString() => this.Name;
        }
    }
}