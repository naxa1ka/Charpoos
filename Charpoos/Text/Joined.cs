using System.Collections.Generic;
using System.Linq;

namespace Charpoos
{
    public class Joined : TextEnvelope
    {
        public Joined(string separator, IEnumerable<IText> texts)
            : this(new TextOfString(separator), texts) { }

        public Joined(ISymbol separator, IEnumerable<IText> texts)
            : this(new TextOfSymbol(separator), texts) { }
        
        public Joined(IText separator, params IText[] texts)
            : this(separator, texts.AsEnumerable()) { }

        public Joined(string separator, IEnumerable<string> texts)
            : this(separator, texts.Select(str => new TextOfString(str))) { }

        public Joined(IText separator, IEnumerable<IText> texts)
            : base(new TextOf(string.Join(separator.AsString(), texts.Select(text => text.AsString()))))
        { }
    }
}
