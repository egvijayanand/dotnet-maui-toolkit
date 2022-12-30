using CommunityToolkit.Maui.Core;

namespace VijayAnand.MauiToolkit.Pro.Views
{
    public partial class ActionSheetPopup : Popup
    {
        private readonly Button? btnDefault;

        public ActionSheetPopup(string title, string message, string cancel, string? destruction, string? defaultButton, params string[] buttons)
        {
            var height = 200 + buttons.Length * 60;

            if (!string.IsNullOrEmpty(destruction) && buttons.Any(x => x == destruction))
            {
                height -= 60;
            }

            InitializeComponent();
            Size = new Size(320, height < 260 ? 260 : height);
            BindableLayout.SetItemsSource(actions, buttons.Where(x => x != destruction));

            lblTitle.Text = title;
            lblMessage.Text = message;

            if (Content?.FlowDirection == FlowDirection.RightToLeft)
            {
                btnRight.Text = destruction;
                btnRight.IsVisible = !string.IsNullOrEmpty(destruction);
                btnLeft.Text = cancel;
            }
            else
            {
                btnLeft.Text = destruction;
                btnLeft.IsVisible = !string.IsNullOrEmpty(destruction);
                btnRight.Text = cancel;
            }

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
                    btnDefault = Content?.FlowDirection == FlowDirection.RightToLeft ? btnRight : btnLeft;
                }
            }

            container.Style = AppResource<Style>("DialogStyle");
            lblTitle.Style = AppResource<Style>("DialogTitle");
            lblMessage.Style = AppResource<Style>("DialogMessage");
            btnLeft.Style = AppResource<Style>("DestructiveAction");
            btnRight.Style = AppResource<Style>("SecondaryAction");
        }

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
