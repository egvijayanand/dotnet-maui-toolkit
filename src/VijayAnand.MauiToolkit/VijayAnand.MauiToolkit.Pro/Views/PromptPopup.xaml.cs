using CommunityToolkit.Maui.Core;
using Microsoft.Maui;

namespace VijayAnand.MauiToolkit.Pro.Views
{
    public partial class PromptPopup : Popup
    {
        public PromptPopup(string title, string message, string accept = "OK", string cancel = "Cancel", string? placeholder = null, int maxLength = -1, Keyboard? keyboard = null, string initialValue = "")
        {
            InitializeComponent();
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
            btnAccept.Style = AppResource<Style>("PrimaryAction");
            btnCancel.Style = AppResource<Style>("SecondaryAction");
        }

        private void OnAcceptClicked(object sender, EventArgs e) => Close(txtPrompt.Text);

        private void OnCancelClicked(object sender, EventArgs e) => Close();

        private void OnPopupOpened(object sender, PopupOpenedEventArgs e) => txtPrompt.Focus();
    }
}
