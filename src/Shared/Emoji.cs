// ***************************************************************************************
// MIT LICENCE
// Copyright UNICODE (UNICODE LICENSE V3)
// https://www.unicode.org/license.txt
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using ConsolePlusLibrary.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace ConsolePlusLibrary
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Utility for working with emojis.
    /// </summary>
    /// <remarks>
    /// The flat emoji constants remain in this internal <see cref="Emoji"/> type, while public
    /// group helpers are exposed as top-level classes such as <c>EmojiActivities</c>,
    /// <c>EmojiTravelAndPlaces</c> and <c>EmojiSymbols</c>. Group helper classes are explicitly
    /// marked with <see cref="EmojiGroupAttribute"/>.
    ///
    /// Shortcode resolution (<c>:group/name:</c>) derives valid group names from those attributed
    /// helper classes, keeping markup group validation coherent with the public API surface.
    /// </remarks>
    internal static partial class Emoji
    {
        private static readonly Lazy<IReadOnlyDictionary<string, string>> _emojiLookup = new(CreateEmojiLookup);

        private static readonly HashSet<string> _emojiGroups = CreateGroupSet();

        /// <summary>
        /// Gets the emoji character by its name.
        /// </summary>
        /// <param name="value">
        /// The name of the emoji. A group-qualified form such as <c>activities/balloon</c> is also
        /// accepted: when the prefix before the <c>/</c> matches a known emoji group (derived from
        /// classes marked with <see cref="EmojiGroupAttribute"/>), the remaining name is resolved on
        /// its own; if the prefix is not a known group, the lookup is rejected.
        /// </param>
        /// <returns>
        /// The resolved emoji character; <see cref="string.Empty"/> when the name cannot be resolved
        /// or the group prefix is unknown; or <paramref name="value"/> unchanged when it is
        /// <see langword="null"/> or whitespace.
        /// </returns>
        internal static string GetByName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            var separator = value.IndexOf('/');
            if (separator >= 0)
            {
                if (_emojiGroups.Contains(NormalizeLookup(value[..separator])))
                {
                    // Group-qualified shortcode (e.g. "activities/balloon") with a valid group
                    // prefix: strip the group and resolve the remaining name.
                    value = value[(separator + 1)..];
                }
                else
                {
                    // Unknown group prefix: reject the lookup so the caller can treat it as literal text.
                    return string.Empty;
                }
            }

            var normalized = NormalizeLookup(value);
            return _emojiLookup.Value.TryGetValue(normalized, out var emoji)
                ? emoji
                : string.Empty;
        }

        private static ReadOnlyDictionary<string, string> CreateEmojiLookup()
        {
            IDictionary<string, string> result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var fields = typeof(Emoji).GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (var field in fields)
            {
                if (field.FieldType != typeof(string) || !field.IsLiteral)
                {
                    continue;
                }

                if (field.GetRawConstantValue() is not string emoji || string.IsNullOrEmpty(emoji))
                {
                    continue;
                }

                AddLookup(result, field.Name, emoji);
                AddLookup(result, ToSnakeCase(field.Name), emoji);
            }

            return new ReadOnlyDictionary<string, string>(result);
        }

        private static HashSet<string> CreateGroupSet()
        {
            var set = new HashSet<string>(StringComparer.Ordinal);

            // Source of truth: public group helper classes (EmojiActivities,
            // EmojiTravelAndPlaces, EmojiSmileysAndEmotion, ...).
            // This keeps markup group validation coherent with the public API.
            var types = typeof(Emoji).Assembly.GetTypes();
            foreach (var type in types)
            {
                if (type.Namespace != "ConsolePlusLibrary"
                    || !type.IsClass
                    || !type.IsAbstract
                    || !type.IsSealed)
                {
                    continue;
                }

                const string prefix = "Emoji";
                if (!type.Name.StartsWith(prefix, StringComparison.Ordinal) || type == typeof(Emoji))
                {
                    continue;
                }

                // Explicit source of truth: custom attribute on group helper classes.
                var groupAttr = type.GetCustomAttribute<EmojiGroupAttribute>(inherit: false);
                if (groupAttr is null)
                {
                    continue;
                }

                string groupName = string.IsNullOrWhiteSpace(groupAttr.GroupName)
                    ? type.Name[prefix.Length..]
                    : groupAttr.GroupName;

                if (string.IsNullOrEmpty(groupName))
                {
                    continue;
                }

                // Primary slug from class name (e.g. TravelAndPlaces -> travelandplaces).
                set.Add(NormalizeLookup(groupName));

                // Compatibility alias for previous "&"/"and" based forms.
                // Example: SmileysAndEmotion also accepts SmileysEmotion.
                set.Add(NormalizeLookup(groupName.Replace("And", string.Empty, StringComparison.Ordinal)));

                // Compatibility alias for official Unicode display names that include '&'.
                // Example: "Travel & Places" normalizes to the same prefix accepted in markup.
                set.Add(NormalizeLookup(groupName.Replace("And", " & ", StringComparison.Ordinal)));
            }

            return set;
        }

        private static void AddLookup(IDictionary<string, string> map, string key, string emoji)
        {
            var normalized = NormalizeLookup(key);
            if (!map.ContainsKey(normalized))
            {
                map[normalized] = emoji;
            }
        }

        private static string NormalizeLookup(string value)
        {
            var sb = new StringBuilder(value.Length);
            foreach (var c in value)
            {
                if (char.IsLetterOrDigit(c))
                {
                    sb.Append(char.ToLowerInvariant(c));
                }
            }

            return sb.ToString();
        }

        private static string ToSnakeCase(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var sb = new StringBuilder(value.Length + 8);
            for (var i = 0; i < value.Length; i++)
            {
                var current = value[i];
                if (i > 0 && char.IsUpper(current) && (char.IsLower(value[i - 1]) || char.IsDigit(value[i - 1])))
                {
                    sb.Append('_');
                }

                sb.Append(char.ToLowerInvariant(current));
            }

            return sb.ToString();
        }
    }
}
