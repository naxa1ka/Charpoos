namespace Charpoos
{
    public class TextOfSymbol  : IText
    {
        private readonly ISymbol _symbol;

        public TextOfSymbol(ISymbol symbol)
        {
            _symbol = symbol;
        }

        public string AsString() => _symbol.AsChar().ToString();

        public override string ToString() => AsString();
    }
}