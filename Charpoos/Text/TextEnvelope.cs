namespace Charpoos
{
    public abstract class TextEnvelope : IText
    {
        private readonly IText _origin;

        protected TextEnvelope(IText origin)
        {
            _origin = origin;
        }
    
        public string AsString() => _origin.AsString();

        public override string ToString() => AsString();
    }
}