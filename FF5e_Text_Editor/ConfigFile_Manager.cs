﻿using System;
using System.Collections.Specialized;
using System.Configuration;

namespace FF5e_Text_Editor
{
    internal class ConfigFile_Manager
    {
        private static readonly string CONFIG_KEY_LOST = "The key '{0}' can't be found in the app.config file settigns.";

        public static bool TryGetAppValue(string key, out object value)
        {
            value = ConfigurationManager.AppSettings[key];
            return value != null;
        }

        public static string GetAppValue(string key, string defaultValue)
        {
            return ConfigurationManager.AppSettings[key] ?? defaultValue;
        }

        public static string GetAppValue(string key)
        {
            if (TryGetAppValue(key, out object value))
                return value.ToString();

            throw new System.Exception(string.Format(CONFIG_KEY_LOST, key));
        }

        public static int GetIntAppValue(string key, int defaultValue)
        {
            if (!TryGetAppValue(key, out object value))
                return defaultValue;

            string sValue = value.ToString();
            if (sValue.Contains("x"))
                return Convert.ToInt32(sValue, 16);
            else
                return Int32.Parse(sValue);
        }

        public static bool GetBoolAppValue(string key, bool defaultValue)
        {
            if (!TryGetAppValue(key, out object value))
                return defaultValue;

            string sValue = value.ToString();
            return bool.Parse(sValue);
        }

        public static bool TryGetSecureAppValue(string key, out object value)
        {
            var securedNameValues = ConfigurationManager.GetSection("secureAppSettings") as NameValueCollection;
            value = securedNameValues?[key];

            return value != null;
        }

        public static string GetSecureAppValue(string key)
        {
            if (TryGetSecureAppValue(key, out object value))
                return value.ToString();

            throw new System.Exception(string.Format(CONFIG_KEY_LOST, key));
        }
    }
}