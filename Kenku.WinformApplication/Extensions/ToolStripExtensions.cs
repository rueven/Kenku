using Kenku.Services.Interfaces;

namespace Kenku.WinformApplication.Extensions
{
    internal static class ToolStripExtensions
    {
        public static ToolStripMenuItem AddToolStripMenuItem(this MenuStrip menuStrip, string name)
        {
            var output = new ToolStripMenuItem(name);
            menuStrip.Items.Add(output);
            return output;
        }

        public static ToolStripMenuItem AddClickableMenuItem(this ToolStripMenuItem toolStripMenuItem, string name, EventHandler handler)
        {
            var output = new ToolStripMenuItem(name);
            output.Click += handler;
            toolStripMenuItem.DropDownItems.Add(output);
            return toolStripMenuItem;
        }

        public static ToolStripMenuItem AddDataBoundToolStripDropDownButton<T>(this ToolStripMenuItem toolStripMenuItem, string name, IReadOnlyList<T> items, Action<T> onItemSelectionChanged, T? defaultValue = null)
            where T : class, INamedService
        {
            var newdropDown = new ToolStripDropDownButton(name);
            toolStripMenuItem
                .DropDownItems
                .Add(newdropDown);
            foreach (var item in items)
            {
                var node = new ToolStripButton(item.Name);
                newdropDown
                    .DropDownItems
                    .Add(node);
                node.Tag = () => onItemSelectionChanged?.Invoke(item);
                if (item.Equals(defaultValue))
                {
                    node.Checked = true;
                }
                node.Click += Node_Click;
            }
            return toolStripMenuItem;
        }

        private static void Node_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripButton clickedControl)
            {
                var parent = clickedControl
                    .GetCurrentParent();
                foreach (var item in parent!.Items)
                {
                    if (item is ToolStripButton control)
                    {
                        control.Checked = control == clickedControl;
                    }
                }
                if (clickedControl.Tag is Action action)
                {
                    action?.Invoke();
                }
            }
        }

        public static ToolStripMenuItem AddDropDownButtons(this ToolStripMenuItem toolStripMenuItem, string name, params (string Text, Action OnClick)[] items)
        {
            var newdropDown = new ToolStripDropDownButton(name);
            toolStripMenuItem
                .DropDownItems
                .Add(newdropDown);
            foreach (var item in items)
            {
                var node = new ToolStripButton(item.Text);
                newdropDown
                    .DropDownItems
                    .Add(node);
                node.Tag = item.OnClick;
                node.Click += Tuple_Click;
            }
            return toolStripMenuItem;
        }

        private static void Tuple_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripButton clickedControl && clickedControl.Tag is Action action)
            {
                action();
            }
        }
    }
}