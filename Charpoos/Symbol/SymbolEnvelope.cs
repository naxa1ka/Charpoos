namespace Charpoos
{
    public class SymbolEnvelope : ISymbol
    {
        private readonly char _chr;

        public SymbolEnvelope(char @char)
        {
            _chr = @char;
        }

        public char AsChar() => _chr;
        
        public override string ToString() => AsChar().ToString();
    }
}