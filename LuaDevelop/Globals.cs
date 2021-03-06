using System;
using System.Text;
using System.Collections.Generic;
using LuaDevelop.Settings;
using ScintillaNet;
using PluginCore;

namespace LuaDevelop
{
    public class Globals
    {
        /// <summary>
        /// Quick reference to MainForm 
        /// </summary> 
        public static MainForm MainForm
        {
            get { return MainForm.Instance; }
        }

        /// <summary>
        /// Quick reference to CurrentDocument 
        /// </summary>
        public static ITabbedDocument CurrentDocument 
        {
            get { return MainForm.CurrentDocument; }
        }

        /// <summary>
        /// Quick reference to SciControl 
        /// </summary>
        public static ScintillaControl SciControl
        {
            get { return CurrentDocument.SciControl; }
        }

        /// <summary>
        /// Quick reference to PreviousDocuments 
        /// </summary>
        public static List<String> PreviousDocuments
        {
            get { return Settings.PreviousDocuments; }
        }

        /// <summary>
        /// Quick reference to Settings 
        /// </summary>
        public static SettingObject Settings
        {
            get { return MainForm.AppSettings; }
        }

    }

}
