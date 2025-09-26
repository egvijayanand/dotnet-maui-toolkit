using CommunityToolkit.Maui.Core;

namespace VijayAnand.MauiToolkit.Pro.Views
{
#if NET8_0_OR_GREATER
    internal partial class PromptPopup : Popup
#else
    public partial class PromptPopup : Popup
#endif
    {
        private readonly Func<string, (bool, string)>? validate;

        public PromptPopup(string title, string message, string accept = "OK", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, Keyboard? keyboard = null, string initialValue = "", Func<string, (bool, string)>? predicate = null)
        {
            InitializeComponent();
            validate = predicate;
            lblTitle.Text = title;
            lblMessage.Text = message;
            btnAccept.Text = accept;
            btnCancel.Text = cancel;
            txtPrompt.MaxLength = maxLength == -1 ? int.MaxValue : maxLength;
            txtPrompt.Placeholder = placeholder;
            txtPrompt.Text = initialValue;
            txtPrompt.Keyboard = keyboard ?? Keyboard.Default;

            // Assign actionStyle
            container.Style = AppResource<Style>("DialogStyle");
            lblTitle.Style = AppResource<Style>("DialogTitle");
            lblMessage.Style = AppResource<Style>("DialogMessage");
            lblError.Style = AppResource<Style>("ErrorLabel");
            btnAccept.Style = AppResource<Style>("PrimaryAction");
            btnCancel.Style = AppResource<Style>("SecondaryAction");
        }

        private void OnAcceptClicked(object sender, EventArgs e)
        {
            lblError.IsVisible = false;
            var result = validate?.Invoke(txtPrompt.Text);

            if (result.HasValue)
            {
                if (result.Value.Item1)
                {
                    Close(txtPrompt.Text);
                }
                else
                {
                    lblError.Text = result.Value.Item2;
                    lblError.IsVisible = true;
                    txtPrompt.Focus();
                }
            }
            else
            {
                Close(txtPrompt.Text);
            }
        }

        private void OnCancelClicked(object sender, EventArgs e) => Close();

        private void OnPopupOpened(object sender, EventArgs e) => txtPrompt.Focus();
    }
}
