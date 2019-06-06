using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppA.EnumClass
{
    public class Volume : Enumeration
    {
        private Volume() { throw new Exception(""); }
        private Volume(int value, string displayName) : base(value, displayName) { }


        public static readonly Volume Low = new Volume(1, nameof(Low).ToLowerInvariant());
        public static readonly Volume Medium = new Volume(2, nameof(Medium).ToLowerInvariant());
        public static readonly Volume High = new Volume(3, nameof(High).ToLowerInvariant());


        public static IEnumerable<Volume> List() =>
            new[] { Low, Medium, High };

        public static Volume From(int value)
        {
            var state = List().SingleOrDefault(s => s.Value == value);

            if (state == null)
            {
                throw new Exception($"Possible values for Volume: {String.Join(",", List().Select(s => s.Value))}");
            }

            return state;
        }

        public static Volume FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.DisplayName, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new Exception($"Possible values for Volume: {String.Join(",", List().Select(s => s.DisplayName))}");
            }

            return state;
        }
    }
}
