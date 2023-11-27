namespace VijayAnand.MauiToolkit.Pro.Views
{
#if NET8_0_OR_GREATER
    internal partial class AlertPopup : Popup
#else
    public partial class AlertPopup : Popup
#endif
    {
        private readonly bool acceptVisible;

        public AlertPopup(string title, string message, string cancel)
        {
            InitializeComponent();
            lblTitle.Text = title;
            lblMessage.Text = message;
            btnAccept.IsVisible = false;
            btnCancel.Text = cancel;

            // Assign Style
            container.Style = AppResource<Style>("DialogStyle");
            lblTitle.Style = AppResource<Style>("DialogTitle");
            lblMessage.Style = AppResource<Style>("DialogMessage");
            btnCancel.Style = AppResource<Style>("PrimaryAction");
        }

        public AlertPopup(string title, string message, string accept, string cancel)
        {
            InitializeComponent();
            lblTitle.Text = title;
            lblMessage.Text = message;
            btnAccept.Text = accept;
            btnCancel.Text = cancel;
            acceptVisible = !string.IsNullOrWhiteSpace(accept);

            // Assign Style
            container.Style = AppResource<Style>("DialogStyle");
            lblTitle.Style = AppResource<Style>("DialogTitle");
            lblMessage.Style = AppResource<Style>("DialogMessage");
            btnAccept.Style = AppResource<Style>("PrimaryAction");
            btnCancel.Style = AppResource<Style>("SecondaryAction");
        }

        private void OnAcceptClicked(object sender, EventArgs e) => Close(true);

        private void OnCancelClicked(object sender, EventArgs e)
        {
            if (acceptVisible)
            {
                Close(false);
            }
            else
            {
                Close();
            }
        }
    }
}
