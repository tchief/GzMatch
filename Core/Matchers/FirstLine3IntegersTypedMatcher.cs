using System;
using System.Collections.Generic;

namespace GzMatcher.Core
{
    // TODO: Consider feature of creating such matchers from app.config
    public class FirstLine3IntegersTypedMatcher : FirtsLineTypedMatcher
    {
        private readonly List<Type> _types = new List<Type> { typeof(int), typeof(int), typeof(int) };
        public override string Name { get { return "FirstLine3IntegersTyped"; } }
        public override List<Type> Types { get { return _types; } }
    }
}
