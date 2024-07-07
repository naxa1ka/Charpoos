namespace Charpoos
{
    public class TextOfString : IText
    {
        private readonly string _text;

        public TextOfString(string text)
        {
            _text = text;
        }

        public string AsString() => _text;

        public override string ToString() => AsString();
    }
}