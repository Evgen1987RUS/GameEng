using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEng.src
{
    public class GameConfiguration
    {
        Dictionary<string, dynamic> config;
        string? _filepath;

        public string? Filepath
        {
            get { return _filepath; }
            set { _filepath = value; }
        }
        
        public Dictionary<string, dynamic> Config 
        {
            get { return config; } 
            set { config = value; }
        }

        public GameConfiguration() 
        {
            // TODO: fill all necessary variables, without relying on the .config file
        }
        
        public GameConfiguration(string filepath) 
        {
            _filepath = filepath;
            if (filepath != null)
            {
                // TODO: fetch config from the filepath;
            }
        }
    }
}
