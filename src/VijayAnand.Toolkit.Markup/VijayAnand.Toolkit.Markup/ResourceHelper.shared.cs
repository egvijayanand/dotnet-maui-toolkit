﻿using System.Reflection;

namespace VijayAnand.Toolkit.Markup
{
    public static class ResourceHelper
    {
        public static T? AppResource<T>(string key, T defaultValue = default)
        {
            if (Application.Current?.Resources.TryGetValue(key, out var value) is true)
            {
                return (value is T resource) ? resource : defaultValue;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(key), $"StaticResource not found for key {key}");
            }
        }

        public static Brush? AppBrush(string resourceKey) => AppResource<Brush>(resourceKey);

#if NET6_0_OR_GREATER
        public static Color? AppColor(string resourceKey) => AppResource<Color>(resourceKey);
#else
        public static Color AppColor(string resourceKey) => AppResource<Color>(resourceKey, Color.Default);
#endif

        public static double? AppDouble(string resourceKey) => AppResource<double>(resourceKey);

        public static IValueConverter? AppConverter(string resourceKey) => AppResource<IValueConverter>(resourceKey);

        public static string? AppString(string resourceKey) => AppResource<string>(resourceKey);

        public static Style? AppStyle(string resourceKey) => AppResource<Style>(resourceKey);

        public static DataTemplate? AppTemplate(string resourceKey) => AppResource<DataTemplate>(resourceKey);

        public static object AppResource(string key)
        {
            if (Application.Current?.Resources.TryGetValue(key, out var value) is true)
            {
                return value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(key), $"StaticResource not found for key {key}");
            }
        }

        public static StyleSheet GetStyleSheet(string resourcePath, Assembly assembly)
        {
            if (string.IsNullOrWhiteSpace(resourcePath))
            {
                throw new ArgumentNullException(nameof(resourcePath));
            }

            if (assembly is null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            if (!Uri.TryCreate(resourcePath, UriKind.Relative, out var _))
            {
                throw new ArgumentException($"Not a well formed {resourcePath}. Check the path again.", nameof(resourcePath));
            }

            var assemblyName = assembly.GetName().Name;

            string resourceId;

            resourcePath = resourcePath.Replace('\\', '/');

            if (resourcePath.StartsWith("/"))
            {
                resourceId = $"{assemblyName}{resourcePath}".Replace('/', '.');
            }
            else
            {
                resourceId = $"{assemblyName}.{resourcePath}".Replace('/', '.');
            }

            try
            {
                using var stream = assembly.GetManifestResourceStream(resourceId);

                if (stream is not null)
                {
                    using var reader = new StreamReader(stream);
                    return StyleSheet.FromReader(reader);
                }
                else
                {
                    throw new Exception($"Unable to get the resource from {resourcePath}.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static T GetXamlResource<T>(string resourcePath, Assembly assembly)
        {
            if (string.IsNullOrWhiteSpace(resourcePath))
            {
                throw new ArgumentNullException(nameof(resourcePath));
            }

            if (assembly is null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            if (!Uri.TryCreate(resourcePath, UriKind.Relative, out var _))
            {
                throw new ArgumentException($"Not a well formed {resourcePath}. Check the path again.", nameof(resourcePath));
            }

            try
            {
                var customAttr = assembly.GetCustomAttributes<XamlResourceIdAttribute>().FirstOrDefault(attr => attr.Path == resourcePath);

                if (customAttr is not null)
                {
                    var instance = Activator.CreateInstance(customAttr.Type);
                    return instance is T obj ? obj : throw new Exception($"Resource available at {resourcePath} is not of type {typeof(T).FullName}.");
                }
                else
                {
                    throw new Exception($"Resource not found at {resourcePath}.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ResourceDictionary GetXamlResourceDictionary(string resourcePath, Assembly assembly)
            => GetXamlResource<ResourceDictionary>(resourcePath, assembly);
    }
}
