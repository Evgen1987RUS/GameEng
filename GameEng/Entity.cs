using Engine;
using GameEngNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEng
{
    public class Entity
    {
        CoordinateSystem _coordinateSystem;
        Identifier _identifier = new();
        Dictionary<string, dynamic> _properties = new();

        public Identifier Id { 
            get { return _identifier; } 
            set { _identifier = value; }
        }

        public Dictionary<string, dynamic> Properties 
        { 
            get { return _properties; } 
            set { _properties = value; } 
        }

        public CoordinateSystem CoordinateSyst 
        { 
            get { return _coordinateSystem; } 
            set { _coordinateSystem = value; }
        }

        public Entity(CoordinateSystem coordinateSystem) 
        {
            _coordinateSystem = coordinateSystem;
        }

        public void SetProperty(string property, dynamic value)
            => Properties.Add(property, value);

        public dynamic GetProperty(string property)
        {
            if (Properties.ContainsKey(property))
                return Properties[property];
            else
                throw new EngineExceptions.InEntityExceptions.NoPropertyFound();
        }
        public void RemovePropety(string property)
        {
            if (Properties.ContainsKey(property)) 
                Properties.Remove(property);
            else 
                throw new EngineExceptions.InEntityExceptions.NoPropertyFound();
        }

        public Entity this[string property]
        {
            get { GetProperty(property); return this; }
            set { Properties[property] = value; }
        }


    }
}
