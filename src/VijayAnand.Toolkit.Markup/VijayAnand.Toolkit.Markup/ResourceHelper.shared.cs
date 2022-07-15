using System.Reflection;

namespace VijayAnand.Toolkit.Markup
{
    public static class ResourceHelper
    {
        public static T? AppResource<T>(string key)
        {
            if (Application.Current?.Resources.TryGetValue(key, out var value) is true)
            {
                return (value is T resource) ? resource : default;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(key), $"StaticResource not found for key {key}");
            }
        }

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
                throw new ArgumentException($"Not a well formed '{resourcePath}'. Check the path again.", nameof(resourcePath));
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
                    throw new Exception($"Unable to get the resource from '{resourcePath}'.");
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
                throw new ArgumentException($"Not a well formed '{resourcePath}'. Check the path again.", nameof(resourcePath));
            }

            try
            {
                var customAttr = assembly.GetCustomAttributes<XamlResourceIdAttribute>().FirstOrDefault(attr => attr.Path == resourcePath);

                if (customAttr is not null)
                {
                    var instance = Activator.CreateInstance(customAttr.Type);
                    return instance is T obj ? obj : throw new Exception($"Resource available at '{resourcePath}' is not of type {nameof(T)}.");
                }
                else
                {
                    throw new Exception($"Resource not found at '{resourcePath}'.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}