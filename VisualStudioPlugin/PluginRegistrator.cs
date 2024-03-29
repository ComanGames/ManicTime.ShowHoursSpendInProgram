﻿using Finkit.ManicTime.Shared.Plugins;
using ManicTime.Client.Tracker.EventTracking.Publishers.ApplicationTracking;

namespace Plugins.Notepad
{
    // register the plugin. ManicTime will look for all dlls and load those with Plugin attribute.
    [Plugin]
    public class PluginRegistrator
    {
        public static string Id = "ManicTime.TagSource.SampleTagPlugin";
        public static string HiddenTagLabel = ":samplePlugin";

        public PluginRegistrator(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.RegisterInstance<IDocumentRetreiver>(new VisualStudioFileRetreiver());
            serviceRegistry.RegisterInstance<ITimelineDatabaseServiceProvider>( new MyDataBaseServiceProvider());

        }
    }
}
