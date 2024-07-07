using System.Collections.Generic;
using System.Linq;

namespace Charpoos
{
    public class Concatenated : TextEnvelope
    {
        public Concatenated(IEnumerable<IText> texts, IEnumerable<IText> text) : this(texts.Concat(text))
        {
        }
        
        public Concatenated(IEnumerable<IText> texts, IText text) : this(texts, new Yield<IText>(text))
        {
        }

        public Concatenated(params string[] text)
            : this(text.Select(x => new TextOfString(x))) { }

        public Concatenated(params IText[] text)
            : this(text.AsEnumerable()) { }

        public Concatenated(IEnumerable<IText> texts)
            : base(new Joined(string.Empty, texts)) { }
    }
}