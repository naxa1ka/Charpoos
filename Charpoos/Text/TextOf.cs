using System;

namespace Charpoos
{
    public class TextOf : IText
    {
        private readonly Lazy<string> _text;

        public TextOf(string text) : this(new Lazy<string>(()=>text))
        {
        }

        public TextOf(Func<string> text) : this(new Lazy<string>(text))
        {
        }

        public TextOf(Lazy<string> text) 
        {
            _text = text;
        }

        public string AsString() => _text.Value;

        public override string ToString() => AsString();
    }
}