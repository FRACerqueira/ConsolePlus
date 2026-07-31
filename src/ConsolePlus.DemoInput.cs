// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System;

namespace ConsolePlusLibrary
{
    public static partial class ConsolePlus
    {
        /// <summary>
        /// Gets or sets a value indicating whether demo mode (scripted keyboard input) is enabled.
        /// Default: <see langword="false"/>. This is a demonstration/diagnostic feature, not a
        /// substitute for real input — when disabled, key reading behaves exactly as before,
        /// even if scripted keys are queued.
        /// </summary>
        public static bool DemoModeEnabled
        {
            get => _consoledrive.DemoModeEnabled;
            set => _consoledrive.DemoModeEnabled = value;
        }

        /// <summary>
        /// Gets a value indicating whether demo mode is currently active, i.e. <see cref="DemoModeEnabled"/>
        /// is <see langword="true"/> and there are scripted keys queued.
        /// </summary>
        public static bool DemoModeActive => _consoledrive.DemoModeActive;

        /// <summary>
        /// Gets a value indicating whether there are scripted keys queued, regardless of <see cref="DemoModeEnabled"/>.
        /// </summary>
        public static bool HasScriptedInput => _consoledrive.HasScriptedInput;

        /// <summary>
        /// Gets or sets the delay, in milliseconds, applied between consumed scripted keys (typing-effect pacing).
        /// </summary>
        public static int ScriptedDelayMs
        {
            get => _consoledrive.ScriptedDelayMs;
            set => _consoledrive.ScriptedDelayMs = value;
        }

        /// <summary>
        /// Enqueues a scripted key press to be consumed when demo mode is active.
        /// </summary>
        /// <param name="key">The key press to enqueue.</param>
        /// <param name="delayMs">The delay, in milliseconds, applied before this key is consumed. When <see langword="null"/>, <see cref="ScriptedDelayMs"/> is used instead.</param>
        public static void EnqueueKey(ConsoleKeyInfo key, int? delayMs = null) => _consoledrive.EnqueueKey(key, delayMs);

        /// <summary>
        /// Enqueues a scripted key press built from a <see cref="ConsoleKey"/> and optional modifiers.
        /// </summary>
        /// <param name="key">The key to enqueue.</param>
        /// <param name="shift">Whether Shift is held.</param>
        /// <param name="alt">Whether Alt is held.</param>
        /// <param name="ctrl">Whether Control is held.</param>
        /// <param name="delayMs">The delay, in milliseconds, applied before this key is consumed. When <see langword="null"/>, <see cref="ScriptedDelayMs"/> is used instead.</param>
        public static void EnqueueKey(ConsoleKey key, bool shift = false, bool alt = false, bool ctrl = false, int? delayMs = null)
            => _consoledrive.EnqueueKey(key, shift, alt, ctrl, delayMs);

        /// <summary>
        /// Enqueues multiple scripted key presses, in order.
        /// </summary>
        /// <param name="keys">The key presses to enqueue.</param>
        public static void EnqueueKeys(params ConsoleKeyInfo[] keys) => _consoledrive.EnqueueKeys(keys);

        /// <summary>
        /// Enqueues multiple scripted key presses, in order, all sharing the same explicit delay.
        /// </summary>
        /// <param name="delayMs">The delay, in milliseconds, applied before each key is consumed.</param>
        /// <param name="keys">The key presses to enqueue.</param>
        public static void EnqueueKeys(int delayMs, params ConsoleKeyInfo[] keys) => _consoledrive.EnqueueKeys(delayMs, keys);

        /// <summary>
        /// Enqueues scripted key presses representing the characters of the specified text, in order.
        /// </summary>
        /// <param name="text">The text to enqueue as key presses.</param>
        /// <param name="delayMs">The delay, in milliseconds, applied before each key is consumed. When <see langword="null"/>, <see cref="ScriptedDelayMs"/> is used instead.</param>
        public static void EnqueueText(string text, int? delayMs = null) => _consoledrive.EnqueueText(text, delayMs);

        /// <summary>
        /// Removes all pending scripted keys from the queue.
        /// </summary>
        public static void ClearScriptedInput() => _consoledrive.ClearScriptedInput();
    }
}
