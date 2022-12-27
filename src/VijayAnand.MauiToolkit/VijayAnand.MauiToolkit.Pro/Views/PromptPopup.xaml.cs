using CommunityToolkit.Maui.Core;
using Microsoft.Maui;

namespace VijayAnand.MauiToolkit.Pro.Views
{
    public partial class PromptPopup : Popup
    {
        public PromptPopup(string title, string message, string accept = "OK", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, InputType inputType = InputType.Default, string initialValue = "")
        {
            InitializeComponent();
            lblTitle.Text = title;
            lblMessage.Text = message;
            btnAccept.Text = accept;
            btnCancel.Text = cancel;
            txtPrompt.MaxLength = maxLength == -1 ? int.MaxValue : maxLength;
            txtPrompt.Placeholder = placeholder;
            txtPrompt.Text = initialValue;
            txtPrompt.Keyboard = inputType switch
            {
                InputType.Plain => Keyboard.Plain,
                InputType.Chat => Keyboard.Chat,
                InputType.Decimal => Keyboard.Numeric,
                InputType.Email => Keyboard.Email,
                InputType.Numeric => Keyboard.Numeric,
                InputType.Telephone => Keyboard.Telephone,
                InputType.Text => Keyboard.Text,
                InputType.Url => Keyboard.Url,
                _ => Keyboard.Default
            };

            // Assign actionStyle
            container.Style = AppResource<Style>("DialogStyle");
            btnAccept.Style = AppResource<Style>("PrimaryAction");
            btnCancel.Style = AppResource<Style>("SecondaryAction");
        }

        private void OnAcceptClicked(object sender, EventArgs e) => Close(txtPrompt.Text);

        private void OnCancelClicked(object sender, EventArgs e) => Close();

        private void OnPopupOpened(object sender, PopupOpenedEventArgs e) => txtPrompt.Focus();
    }
}
