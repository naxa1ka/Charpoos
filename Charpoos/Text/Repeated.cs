using System.Linq;

namespace Charpoos
{
    public class Repeated : TextEnvelope
    {
        public Repeated(IText text, int count)
            : base(new Concatenated(Enumerable.Repeat(text, count))) { }
    }
}
