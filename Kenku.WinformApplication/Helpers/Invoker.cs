namespace Kenku.WinformApplication.Helpers
{
    internal class Invoker
    {
        public CommonDialog InvokeDialog;
        private Thread InvokeThread;
        private DialogResult InvokeResult;

        public Invoker(CommonDialog dialog)
        {
            InvokeDialog = dialog;
            InvokeThread = new Thread(new ThreadStart(this.InvokeMethod));
            InvokeThread.SetApartmentState(ApartmentState.STA);
            InvokeResult = DialogResult.None;
        }

        public DialogResult Invoke()
        {
            this.InvokeThread.Start();
            this.InvokeThread.Join();
            return this.InvokeResult;
        }

        private void InvokeMethod()
        {
            this.InvokeResult = InvokeDialog.ShowDialog();
        }
    }
}