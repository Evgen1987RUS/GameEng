using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace GameEng.lib.Engine.BasicClasses
{
    public class EventSystem
    {
        Dictionary<string, List<Action>> _events = new();

        public Dictionary<string, List<Action>> Events
        {
            get { return _events; }
            set { _events = value; }
        }

        public EventSystem() { }

        public void Add(string name)
        {
            Events.Add(name, new List<Action>());
        }

        public void Remove(string name)
        {
            Events.Remove(name);
        }

        public void Handle(string name, Action method)
        {
            Events[name].Add(method);
        }

        public void RemoveHandled(string name, Action method)
        {
            Events[name].Remove(method);
        }

        public void Trigger(string name)
        { 
            for (int i = 0; i < Events[name].Count; i++) 
            {
                Events[name][i]();
            }
        }

        public List<Action> GetHandled(string name)
            => Events[name];

        public List<Action> this[string name]
        {
            get { return GetHandled(name); }
        }
    }
}
