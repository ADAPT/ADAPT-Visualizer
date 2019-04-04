/* Copyright (C) 2015-16 AgGateway and ADAPT Contributors
 * Copyright (C) 2015-16 Deere and Company
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
 *
 * Contributors:
 *    Tarak Reddy - initial implementation
 *******************************************************************************/

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.PluginManager;

namespace AgGateway.ADAPT.Visualizer
{
    public class DataProvider
    {
        private PluginFactory _pluginFactory;

        public void Initialize(string pluginsPath)
        {
            _pluginFactory = new PluginFactory(pluginsPath);
        }

        public ObservableCollection<KeyValuePair<string, string>> AvailablePlugins
        {
            get
            {
				if (_pluginFactory == null)
					return new ObservableCollection<KeyValuePair<string, string>>();

				var listOfPlugins = new List<KeyValuePair<string, string>>();
				foreach (var pluginName in PluginFactory.AvailablePlugins)
				{
					var plugin = GetPlugin(pluginName);
					listOfPlugins.Add(new KeyValuePair<string, string>(pluginName, plugin.Version));
				}

				return new ObservableCollection<KeyValuePair<string, string>>(listOfPlugins);
			}
        }

        public PluginFactory PluginFactory
        {
            get { return _pluginFactory; }
        }

        public IList<ApplicationDataModel.ADM.ApplicationDataModel> Import(string datacardPath, string initializeString, ApplicationDataModel.ADM.Properties properties)
        {
			var list = new List<ApplicationDataModel.ADM.ApplicationDataModel>();
			foreach (var availablePlugin in AvailablePlugins)
            {
                var plugin = GetPlugin(availablePlugin.Key);
                InitializePlugin(plugin, initializeString);

                if (plugin.IsDataCardSupported(datacardPath))
                {
	                list.AddRange(plugin.Import(datacardPath, properties));
				}
			}
			if (list.Any())
			{
				return list;
			}
			return null;
		}

        public IPlugin GetPlugin(string pluginName)
        {
            return _pluginFactory.GetPlugin(pluginName);
        }

        public static void Export(IPlugin plugin, 
                                 ApplicationDataModel.ADM.ApplicationDataModel applicationDataModel, 
                                 string initializeString, 
                                 string exportPath, 
                                 ApplicationDataModel.ADM.Properties properties)
        {
            InitializePlugin(plugin, initializeString);

            plugin.Export(applicationDataModel, exportPath, properties);
        }

        private static void InitializePlugin(IPlugin plugin, string initializeString)
        {
            if (!string.IsNullOrEmpty(initializeString))
            {
                plugin.Initialize(initializeString);
            }
        }

        public IList<ApplicationDataModel.ADM.IError> ValidateDataOnCard(string datacardPath, string initializeString)
        {
            foreach (var availablePlugin in AvailablePlugins)
            {
                var plugin = GetPlugin(availablePlugin.Key);
                InitializePlugin(plugin, initializeString);

                if (plugin.IsDataCardSupported(datacardPath))
                {
                    return plugin.ValidateDataOnCard(datacardPath);
                }
            }

            return null;
        }
    }
}