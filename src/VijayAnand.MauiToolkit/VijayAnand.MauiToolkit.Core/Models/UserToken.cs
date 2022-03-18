using System.Text.Json.Serialization;
using VijayAnand.MauiToolkit.Core.Helpers;

namespace VijayAnand.MauiToolkit.Core.Models
{
    public class UserToken
    {
        /// <summary>Id token</summary>
        [JsonPropertyName(nameof(AuthConstants.IdToken))]
        public string IdToken { get; set; } = string.Empty;

        /// <summary>Access token</summary>
        [JsonPropertyName(nameof(AuthConstants.AccessToken))]
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>Token type</summary>
        [JsonPropertyName(nameof(AuthConstants.TokenType))]
        public string TokenType { get; set; } = string.Empty;

        /// <summary>Expires in</summary>
        [JsonPropertyName(nameof(AuthConstants.ExpiresIn))]
        public int ExpiresIn { get; set; }

        /// <summary>Refresh token</summary>
        [JsonPropertyName(nameof(AuthConstants.RefreshToken))]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
