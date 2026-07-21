// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the ConsolePlus project under MIT license
// ***************************************************************************************

using System.Text;

namespace ConsolePlusLibrary.Core
{
    /// <summary>
    /// Tokenizes color markup text.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="MarkupColorTokenizer"/> class.
    /// The tokenizer is fault-tolerant: malformed markup is emitted as plain text.
    /// </remarks>
    /// <param name="text">The text to tokenize.</param>
    internal sealed class MarkupColorTokenizer(string text)
    {
        private readonly StringBuffer _reader = new(text ?? string.Empty);
        private readonly StringBuilder _builder = new();

        /// <summary>
        /// Gets the current token.
        /// </summary>
        public MarkupColor? Current { get; private set; }

        /// <summary>
        /// Moves to the next token.
        /// </summary>
        /// <returns><c>true</c> if there is a next token; otherwise, <c>false</c>.</returns>
        public bool MoveNext()
        {
            if (_reader.Eof)
            {
                return false;
            }

            char current = _reader.Peek();
            return current == '[' ? ReadMarkup() : ReadText();
        }

        private bool ReadText()
        {
            int position = _reader.Position;
            _builder.Clear();

            bool encounteredClosing = false;
            while (!_reader.Eof)
            {
                char current = _reader.Read();

                if (current == '[')
                {
                    // Put back '[' so the next ReadMarkup() call can consume it.
                    _reader.Position--;
                    break;
                }

                if (current == ']')
                {
                    if (encounteredClosing)
                    {
                        // ']]' escape: second ']' discarded, first was already appended.
                        encounteredClosing = false;
                        continue;
                    }
                    // First ']': append and flag — next char decides escape vs error.
                    encounteredClosing = true;
                    _builder.Append(current);
                    continue;
                }

                if (encounteredClosing)
                {
                    // Invalid standalone ']' sequence: keep parsing as plain text.
                    encounteredClosing = false;
                }

                _builder.Append(current);
            }

            // Trailing lone ']' is treated as normal text.

            Current = new MarkupColor(MarkupColorKind.Text, _builder.ToString(), position);
            return true;
        }

        private bool ReadMarkup()
        {
            int position = _reader.Position;

            _reader.Read(); // consume '['

            if (_reader.Eof)
            {
                Current = new MarkupColor(MarkupColorKind.Text, "[", position);
                return true;
            }

            // Read the char after '[' with a single Read() instead of Peek()+Read().
            char current = _reader.Read();
            switch (current)
            {
                case '[':
                    // '[[' → escaped '[', emit as literal text.
                    Current = new MarkupColor(MarkupColorKind.Text, "[", position);
                    return true;
                case '/':
                    // '[/' → close tag; must be followed immediately by ']'.
                    if (_reader.Eof)
                    {
                        Current = new MarkupColor(MarkupColorKind.Text, "[/", position);
                        return true;
                    }
                    current = _reader.Read();
                    if (current != ']')
                    {
                        _builder.Clear();
                        _builder.Append("[/");
                        _builder.Append(current);
                        while (!_reader.Eof)
                        {
                            char c = _reader.Peek();
                            if (c == '[')
                            {
                                break;
                            }
                            _builder.Append(_reader.Read());
                        }
                        Current = new MarkupColor(MarkupColorKind.Text, _builder.ToString(), position);
                        return true;
                    }
                    Current = new MarkupColor(MarkupColorKind.Close, string.Empty, position);
                    return true;
            }

            // 'current' is the first char of the open-tag content (already consumed).
            _builder.Clear();
            // Edge case: '[]' — immediately closed with empty content.
            bool foundClose = current == ']';
            if (!foundClose)
            {
                _builder.Append(current);
                // Single Read() per char — no Peek()+switch+Read() overhead.
                while (!_reader.Eof)
                {
                    current = _reader.Read();
                    if (current == ']')
                    {
                        foundClose = true;
                        break;
                    }
                    if (current == '[')
                    {
                        // Malformed open tag: emit as text and let next token handle '['.
                        _reader.Position--;
                        Current = new MarkupColor(MarkupColorKind.Text, $"[{_builder}", position);
                        return true;
                    }
                    _builder.Append(current);
                }
            }

            if (!foundClose)
            {
                Current = new MarkupColor(MarkupColorKind.Text, $"[{_builder}", position);
                return true;
            }

            Current = new MarkupColor(MarkupColorKind.Open, _builder.ToString(), position);
            return true;
        }

        // Direct string indexing eliminates the StringReader wrapper.
        // Peek() and Read() reduce to a single array load
        // or load+increment — trivially inlineable by the JIT.
        private sealed class StringBuffer
        {
            private readonly string _text;
            private readonly int _length;

            public int Position { get; set; }
            public bool Eof => Position >= _length;

            public StringBuffer(string text)
            {
                _text = text ?? string.Empty;
                _length = _text.Length;
            }

            public char Peek() => Eof ? '\0' : _text[Position];

            public char Read() => Eof ? '\0' : _text[Position++];
        }
    }
}
