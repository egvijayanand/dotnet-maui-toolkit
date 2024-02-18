using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace VijayAnand.MauiBlazor.Markup
{
    public static class MauiBlazorExtensions
    {
        /// <summary>Sets the HostPage of the <typeparamref name="TBlazorWebView"/>.</summary>
        /// <typeparam name="TBlazorWebView"><seealso cref="BlazorWebView"/> or its derivative.</typeparam>
        /// <param name="bwv"><typeparamref name="TBlazorWebView"/> instance.</param>
        /// <param name="hostPage">Host page of the <typeparamref name="TBlazorWebView"/>.</param>
        /// <returns>Same instance of <typeparamref name="TBlazorWebView"/> on which this method is invoked.</returns>
        public static TBlazorWebView HostPage<TBlazorWebView>(this TBlazorWebView bwv, string hostPage)
            where TBlazorWebView : BlazorWebView
        {
            bwv.HostPage = hostPage;
            return bwv;
        }

        /// <summary>Configures a <typeparamref name="TBlazorWebView"/></summary>
        /// <typeparam name="TBlazorWebView"><seealso cref="BlazorWebView"/> or its derivative.</typeparam>
        /// <param name="bwv"><typeparamref name="TBlazorWebView"/> instance.</param>
        /// <param name="hostPage">Host page of the <typeparamref name="TBlazorWebView"/>.</param>
        /// <param name="rootComponents">Array of <seealso cref="Tuple{T1, T2, T3}"/> (of type <seealso cref="string"/>, <seealso cref="Type"/>, <seealso cref="IDictionary{TKey, TValue}"/>), a simplified model representing the <seealso cref="RootComponent"/>, to be managed by this <typeparamref name="TBlazorWebView"/> instance.</param>
        /// <returns>Same instance of <typeparamref name="TBlazorWebView"/> on which this method is invoked.</returns>
        public static TBlazorWebView Configure<TBlazorWebView>(this TBlazorWebView bwv,
                                                               string hostPage,
                                                               params (string selector, Type componentType, IDictionary<string, object?>? parameters)[] rootComponents)
            where TBlazorWebView : BlazorWebView
        {
            bwv.HostPage = hostPage;

            foreach (var (selector, componentType, parameters) in rootComponents)
            {
                bwv.RootComponents.Add(new RootComponent()
                {
                    Selector = selector,
                    ComponentType = componentType,
                    Parameters = parameters
                });
            }

            return bwv;
        }

        /// <summary>Configures a <typeparamref name="TBlazorWebView"/></summary>
        /// <typeparam name="TBlazorWebView"><seealso cref="BlazorWebView"/> or its derivative.</typeparam>
        /// <param name="bwv"><typeparamref name="TBlazorWebView"/> instance.</param>
        /// <param name="componentType">Component type.</param>
        /// <returns>Same instance of <typeparamref name="TBlazorWebView"/> on which this method is invoked.</returns>
        public static TBlazorWebView Configure<TBlazorWebView>(this TBlazorWebView bwv, Type componentType)
            where TBlazorWebView : BlazorWebView
        {
            bwv.HostPage = "wwwroot/index.html";

            bwv.RootComponents.Add(new RootComponent()
            {
                Selector = "#app",
                ComponentType = componentType
            });

            return bwv;
        }

#if NET8_0_OR_GREATER
        /// <summary>Sets the StartPath of the <typeparamref name="TBlazorWebView"/>.</summary>
        /// <typeparam name="TBlazorWebView"><seealso cref="BlazorWebView"/> or its derivative.</typeparam>
        /// <param name="bwv"><typeparamref name="TBlazorWebView"/> instance.</param>
        /// <param name="startPath">Start path of the <typeparamref name="TBlazorWebView"/>.</param>
        /// <returns>Same instance of <typeparamref name="TBlazorWebView"/> on which this method is invoked.</returns>
        public static TBlazorWebView StartPath<TBlazorWebView>(this TBlazorWebView bwv, string startPath)
            where TBlazorWebView : BlazorWebView
        {
            bwv.StartPath = startPath;
            return bwv;
        }

        /// <summary>Configures a <typeparamref name="TBlazorWebView"/></summary>
        /// <typeparam name="TBlazorWebView"><seealso cref="BlazorWebView"/> or its derivative.</typeparam>
        /// <param name="bwv"><typeparamref name="TBlazorWebView"/> instance.</param>
        /// <param name="hostPage">Host page of the <typeparamref name="TBlazorWebView"/>.</param>
        /// <param name="startPath">Start path of the <typeparamref name="TBlazorWebView"/>.</param>
        /// <param name="rootComponents">Array of <seealso cref="Tuple{T1, T2, T3}"/> (of type <seealso cref="string"/>, <seealso cref="Type"/>, <seealso cref="IDictionary{TKey, TValue}"/>), a simplified model representing the <seealso cref="RootComponent"/>, to be managed by this <typeparamref name="TBlazorWebView"/> instance.</param>
        /// <returns>Same instance of <typeparamref name="TBlazorWebView"/> on which this method is invoked.</returns>
        public static TBlazorWebView Configure<TBlazorWebView>(this TBlazorWebView bwv,
                                                               string hostPage,
                                                               string startPath,
                                                               params (string selector, Type componentType, IDictionary<string, object?>? parameters)[] rootComponents)
            where TBlazorWebView : BlazorWebView
        {
            bwv.HostPage = hostPage;
            bwv.StartPath = startPath;

            foreach (var (selector, componentType, parameters) in rootComponents)
            {
                bwv.RootComponents.Add(new RootComponent()
                {
                    Selector = selector,
                    ComponentType = componentType,
                    Parameters = parameters
                });
            }

            return bwv;
        }

        /// <summary>Configures a <typeparamref name="TBlazorWebView"/></summary>
        /// <typeparam name="TBlazorWebView"><seealso cref="BlazorWebView"/> or its derivative.</typeparam>
        /// <param name="bwv"><typeparamref name="TBlazorWebView"/> instance.</param>
        /// <param name="componentType">Component type.</param>
        /// <returns>Same instance of <typeparamref name="TBlazorWebView"/> on which this method is invoked.</returns>
        public static TBlazorWebView Configure<TBlazorWebView>(this TBlazorWebView bwv, Type componentType, string startPath = "/")
            where TBlazorWebView : BlazorWebView
        {
            bwv.HostPage = "wwwroot/index.html";
            bwv.StartPath = startPath;

            bwv.RootComponents.Add(new RootComponent()
            {
                Selector = "#app",
                ComponentType = componentType
            });

            return bwv;
        }
#endif
        /// <summary>
        /// Adds the component specified by <typeparamref name="TComponent"/> to the collection specified by
        /// <paramref name="components" /> to be associated with the selector specified by <paramref name="selector"/>
        /// and to be instantiated with the parameters specified by <paramref name="parameters"/>.
        /// </summary>
        /// <typeparam name="TComponent">The component to add to the collection.</typeparam>
        /// <param name="components">The collection to which the component should be added.</param>
        /// <param name="selector">The selector to which the component will be associated.</param>
        /// <param name="parameters">The optional creation parameters for the component.</param>
        public static void Add<TComponent>(this RootComponentsCollection components, string selector, IDictionary<string, object?>? parameters = null)
            where TComponent : IComponent
        {
            components.Add(new RootComponent()
            {
                Selector = selector,
                ComponentType = typeof(TComponent),
                Parameters = parameters
            });
        }

        /// <summary>Sets the component type for the <typeparamref name="TRootComponent"/>.</summary>
        /// <typeparam name="TRootComponent"><seealso cref="RootComponent"/> or its derivative.</typeparam>
        /// <param name="component"><typeparamref name="TRootComponent"/> instance.</param>
        /// <param name="type">Component type of <typeparamref name="TRootComponent"/>.</param>
        /// <returns>Same instance of <typeparamref name="TRootComponent"/> on which this method is invoked.</returns>
        public static TRootComponent ComponentType<TRootComponent>(this TRootComponent component, Type type)
            where TRootComponent : RootComponent
        {
            component.ComponentType = type;
            return component;
        }

        /// <summary>Sets the selector for the <typeparamref name="TRootComponent"/>.</summary>
        /// <typeparam name="TRootComponent"><seealso cref="RootComponent"/> or its derivative.</typeparam>
        /// <param name="component"><typeparamref name="TRootComponent"/> instance.</param>
        /// <param name="selector">Selector of <typeparamref name="TRootComponent"/>, can be any supported CSS selector.</param>
        /// <returns>Same instance of <typeparamref name="TRootComponent"/> on which this method is invoked.</returns>
        public static TRootComponent Selector<TRootComponent>(this TRootComponent component, string selector)
            where TRootComponent : RootComponent
        {
            component.Selector = selector;
            return component;
        }

        /// <summary>Sets the parameters for the <typeparamref name="TRootComponent"/>.</summary>
        /// <typeparam name="TRootComponent"><seealso cref="RootComponent"/> or its derivative.</typeparam>
        /// <param name="component"><typeparamref name="TRootComponent"/> instance.</param>
        /// <param name="parameters">Array of <seealso cref="Tuple{T1, T2}"/> of type <seealso cref="string"/> and <seealso cref="object"/>?, a model representing the key-value pair, to be set as <seealso cref="RootComponent.Parameters"/> of <typeparamref name="TRootComponent"/>.</param>
        /// <returns>Same instance of <typeparamref name="TRootComponent"/> on which this method is invoked.</returns>
        public static TRootComponent Parameters<TRootComponent>(this TRootComponent component, params (string key, object? value)[] parameters)
            where TRootComponent : RootComponent
        {
            var dict = new Dictionary<string, object?>();

            foreach (var (key, value) in parameters)
            {
                dict[key] = value;
            }

            component.Parameters = dict;
            return component;
        }
    }
}
