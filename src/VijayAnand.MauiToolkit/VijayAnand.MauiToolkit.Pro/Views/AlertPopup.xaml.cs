namespace VijayAnand.MauiToolkit.Pro.Views
{
    public partial class AlertPopup : Popup
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
