using CommunityToolkit.Maui.Core;

namespace VijayAnand.MauiToolkit.Pro.Views
{
    public partial class ActionSheetPopup : Popup
    {
        private readonly Button? btnDefault;

        public ActionSheetPopup(string title, string message, string cancel, string? destruction, string? defaultButton, params string[] buttons)
        {
            var height = 200 + buttons.Length * 60;

            if (!string.IsNullOrEmpty(destruction))
            {
                height -= 60;
            }

            DialogSize = new(320, height < 260 ? 260 : height);
            Buttons = buttons.Where(x => x != destruction);

            InitializeComponent();
            BindingContext = this;

            lblTitle.Text = title;
            lblMessage.Text = message;
            btnDestructive.Text = destruction;
            btnDestructive.IsVisible = !string.IsNullOrEmpty(destruction);
            btnCancel.Text = cancel;

            container.Style = AppResource<Style>("DialogStyle");

            var hasDefaultButton = !string.IsNullOrEmpty(defaultButton);
            var actionStyle = AppResource<Style>("Action");

            // Assign Style
            foreach (var item in actions.Children)
            {
                if (item is Button btn)
                {
                    btn.Style = actionStyle;

                    if (hasDefaultButton && btn.Text == defaultButton)
                    {
                        btnDefault = btn;
                        btn.Style = AppResource<Style>("PrimaryAction");
                    }
                }
            }

            if (hasDefaultButton && btnDefault is null)
            {
                if (!string.IsNullOrEmpty(destruction) && destruction == defaultButton)
                {
                    btnDefault = btnDestructive;
                }
            }

            btnDestructive.Style = AppResource<Style>("DestructiveAction");
            btnCancel.Style = AppResource<Style>("SecondaryAction");
        }

        public Size DialogSize { get; }

        public IEnumerable<string> Buttons { get; }

        private void OnClicked(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                Close(btn.Text);
            }
        }

        private void OnPopupOpened(object sender, PopupOpenedEventArgs e) => btnDefault?.Focus();
    }
}
