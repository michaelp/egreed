using System;

namespace cli
{
    static partial class Program
    {
        private class EventSpecificData
        {
            public string Message { get; internal set; }
            public string FormId { get; internal set; }
            public int SomeInt { get; internal set; }
            public DateTime SomeDate { get; internal set; }
        }
    }
}
