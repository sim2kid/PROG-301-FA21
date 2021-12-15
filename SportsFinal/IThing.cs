using System;

namespace SportsFinal
{
    public interface IThing
    {
        public string Name { get; }
        public string Description { get; }

        public void NewName(string name);
        public void NewDescription(string description);
    }
}
