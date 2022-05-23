// External namespaces
#if NETSTANDARD2_0_OR_GREATER
global using Xamarin.Forms;
global using Xamarin.Forms.StyleSheets;
global using Xamarin.CommunityToolkit.Markup;
global using static Xamarin.Forms.Color;
global using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;
#elif NET6_0_OR_GREATER
global using Microsoft.Maui;
global using Microsoft.Maui.Controls;
global using Microsoft.Maui.Controls.StyleSheets;
global using Microsoft.Maui.Graphics;
global using Microsoft.Maui.Hosting;
global using CommunityToolkit.Maui.Markup;
global using static Microsoft.Maui.Graphics.Colors;
global using static CommunityToolkit.Maui.Markup.GridRowsColumns;
#endif

// System namespaces
global using System;
global using System.Collections.Generic;
global using System.Globalization;
global using System.Linq;
global using System.Text;
global using System.Text.RegularExpressions;
global using System.Threading.Tasks;