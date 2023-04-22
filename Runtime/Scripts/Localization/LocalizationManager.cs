using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

namespace SperidTopDownFramework.Runtime
{
    public partial class SingletonManager : SingletonBehaviour<SingletonManager>
    {
        public LocalizationManager Localization
        {
            get
            {
                if (IsInitialize)
                {
                    return LocalizationManager.Instance;
                }
                else
                {
                    return null;
                }
            }
        }
    }


    public class LocalizationManager : SingletonBehaviour<LocalizationManager>
    {
        private Locale _defaultLocate;

        public override void Initialize()
        {
            name = "LocalizationManager";
            transform.parent = SingletonManager.Instance.transform;

            LocalizationSettings settings = LocalizationSettings.Instance;
            _defaultLocate = settings.GetSelectedLocale();

            base.Initialize();
        }

        public void ChangeDefaultLocate()
        {
            ChangeLocale(_defaultLocate.Identifier.Code);
        }

        /// <summary>
        /// Change localozation locate if exists.
        /// </summary>
        /// <param name="languageIdentifier">Ex."en" "de" "ja" etc.</param>
        public void ChangeLocale(string languageIdentifier)
        {
            LocalizationSettings settings = LocalizationSettings.Instance;

            LocaleIdentifier localeCode = new LocaleIdentifier(languageIdentifier);
            for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
            {
                Locale aLocale = LocalizationSettings.AvailableLocales.Locales[i];
                LocaleIdentifier anIdentifier = aLocale.Identifier;
                if (anIdentifier == localeCode)
                {
                    settings.SetSelectedLocale(aLocale);
                }
            }
        }

        public string GetCurrentLocateIdentiferCode()
        {
            LocalizationSettings settings = LocalizationSettings.Instance;
            return settings.GetSelectedLocale().Identifier.Code;
        }

        public LocalizedString GetLocalizedString(string table, string entry)
        {
            LocalizedString ls = new LocalizedString();
            ls.SetReference(table, entry);
            return ls;
        }

        public string GetLocalizedStringSync(string targetTableName, string entry)
        {
            return LocalizationSettings.StringDatabase.GetTableEntry(targetTableName, entry).Entry.GetLocalizedString();
        }

        public void GetLocalizedStringAsync(string targetTableName, string key, Action<string> onCompleted)
        {
            StartCoroutine(GetTableAsync(targetTableName, (table) =>
            {
                onCompleted?.Invoke(table.GetEntry(key).GetLocalizedString());
            }));
        }

        private IEnumerator GetTableAsync(string targetTableName, Action<StringTable> onComplete)
        {
            // Get asynchronously
            var handle = LocalizationSettings.StringDatabase.GetTableAsync(targetTableName);

            //Wait until load complete
            while (!handle.IsDone)
            {
                yield return null;
            }

            onComplete?.Invoke(handle.Result);
        }
    }
}
