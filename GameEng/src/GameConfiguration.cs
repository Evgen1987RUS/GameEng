﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using GameEng.lib.Exceptions;

namespace GameEng.src
{
    public class GameConfiguration
    {
        Dictionary<string, dynamic> _config = new();

        public Dictionary<string, dynamic> Config
        {
            get { return _config; }
            set { _config = value; }
        }

        public GameConfiguration(string filePath) // preferably relative to this file file path
        {
            ExeConfigurationFileMap configMap = new();
            configMap.ExeConfigFilename = filePath;
            if (filePath == "" || !File.Exists(filePath))
            {
                _config.Add("hfov", 60);
                _config.Add("vfov", 30);
                _config.Add("horizontalBlocks", 20);
                _config.Add("verticalBlocks", 30);
                _config.Add("fps", 30);
                _config.Add("drawDistance", 10000);
                _config.Add("wait", 100);
            }
            else
            {
                var configBuff = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                _config.Add("hfov", int.Parse(configBuff.AppSettings.Settings["hfov"].Value));
                _config.Add("vfov", int.Parse(configBuff.AppSettings.Settings["vfov"].Value));
                _config.Add("horizontalBlocks", int.Parse(configBuff.AppSettings.Settings["horizontalBlocks"].Value));
                _config.Add("verticalBlocks", int.Parse(configBuff.AppSettings.Settings["verticalBlocks"].Value));
                _config.Add("fps", int.Parse(configBuff.AppSettings.Settings["fps"].Value));
                _config.Add("drawDistance", int.Parse(configBuff.AppSettings.Settings["drawDistance"].Value));
                _config.Add("wait", int.Parse(configBuff.AppSettings.Settings["wait"].Value));
            }
        }

        public GameConfiguration()
        {
            _config.Add("hfov", 60);
            _config.Add("vfov", 30);
            _config.Add("horizontalBlocks", 50);
            _config.Add("verticalBlocks", 30);
            _config.Add("fps", 30);
            _config.Add("drawDistance", 20);
            _config.Add("wait", 100);
        }

        public void SetVariable(string name, dynamic value)
        {
            _config[name] = value;
        }

        public dynamic GetVariable(string name)
            => _config[name];

        public void ExecuteFile(string filePath)
        {
            ExeConfigurationFileMap configMap = new();
            configMap.ExeConfigFilename = filePath;
            if (filePath == "" || !File.Exists(filePath))
            {
                _config.Add("hfov", 60);
                _config.Add("vfov", 30);
                _config.Add("horizontalBlocks", 5);
                _config.Add("verticalBlocks", 3);
                _config.Add("fps", 30);
                _config.Add("drawDistance", 20);
                _config.Add("wait", 100);
            }
            else
            {
                var configBuff = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                _config["hfov"] = configBuff.AppSettings.Settings["hfov"].Value;
                _config["vfov"] = configBuff.AppSettings.Settings["vfov"].Value;
                _config["horizontalBlocks"] = configBuff.AppSettings.Settings["horizontalBlocks"].Value;
                _config["verticalBlocks"] = configBuff.AppSettings.Settings["verticalBlocks"].Value;
                _config["fps"] = configBuff.AppSettings.Settings["fps"].Value;
                _config["drawDistance"] = configBuff.AppSettings.Settings["drawDistance"].Value;
                _config["wait"] = configBuff.AppSettings.Settings["wait"].Value;
            }
        }

        public void Save(string filePath)
        {
            if (filePath == "" || !File.Exists(filePath))
            {
                throw new EngineExceptions.InGameExceptions.NoPathFound();
            }

            ExeConfigurationFileMap configMap = new();
            configMap.ExeConfigFilename = filePath;
            var configBuff = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            configBuff.AppSettings.Settings["hfov"].Value = _config["hfov"];
            configBuff.AppSettings.Settings["vfov"].Value = _config["vfov"];
            configBuff.AppSettings.Settings["horizontalBlocks"].Value = _config["horizontalBlocks"];
            configBuff.AppSettings.Settings["verticalBlocks"].Value = _config["verticalBlocks"];
            configBuff.AppSettings.Settings["fps"].Value = _config["fps"];
            configBuff.AppSettings.Settings["drawDistance"].Value = _config["drawDistance"];
            configBuff.AppSettings.Settings["wait"].Value = _config["wait"];
        }

        public dynamic this[string property]
        {
            get { return _config[property]; }
            set { _config[property] = value; }
        }
    }
}
