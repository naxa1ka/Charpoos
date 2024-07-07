using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Charpoos
{
    public class Split : IEnumerable<IText>
    {
        private readonly IEnumerable<IText> _splitText;

        public Split(IText text, ISymbol separator)
            : this(text.AsString().Split(separator.AsChar()).Select(str => new TextOfString(str)))
        { }

        private Split(IEnumerable<IText> splitText)
        {
            _splitText = splitText;
        }

        public IEnumerator<IText> GetEnumerator()
        {
            foreach (var text in _splitText)
            {
                yield return text;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
