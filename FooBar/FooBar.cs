using System;
using System.Collections.Generic;
using System.Text;

namespace FooBar
{
    class FooBar
    {
        /// <summary>
        /// Name of this object
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Other names that this object can be called
        /// </summary>
        public List<string> AlternativeNames { get; set; }

        /// <summary>
        /// The Id of the object
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The type of this object
        /// </summary>
        public FizzType Type { get; set; }
    }
}
