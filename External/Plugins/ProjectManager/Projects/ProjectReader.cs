using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Collections.Generic;

namespace ProjectManager.Projects
{
	public class ProjectReader : XmlTextReader
	{
		Project project;
        protected int version;

		public ProjectReader(string filename, Project project) : base(filename)
		{
            this.project = project;
			WhitespaceHandling = WhitespaceHandling.None;
		}

        protected Project Project { get { return project; } }

		public virtual Project ReadProject()
		{
			MoveToContent();
            ProcessRootNode();

            while (Read())
                ProcessNode(Name);

            Close();
            PostProcess();
			return project;
		}

        protected virtual void PostProcess()
        {
        }

        protected virtual void ProcessRootNode()
        {
            version = 1;
            int.TryParse(GetAttribute("version") ?? "1", out version);
        }

        protected virtual void ProcessNode(string name)
        {
            switch (name)
            {
                case "hiddenPaths": ReadHiddenPaths(); break;
                case "options": ReadProjectOptions(); break;
                case "storage": ReadPluginStorage(); break;
            }
        }

        private void ReadPluginStorage()
        {
            if (IsEmptyElement)
            {
                Read();
                return;
            }

            ReadStartElement("storage");
            while (Name == "entry")
            {
                string key = GetAttribute("key");
                if (IsEmptyElement)
                {
                    Read();
                    continue;
                }

                Read();
                if (key != null) project.storage.Add(key, Value);
                Read();
                ReadEndElement();
            }
            ReadEndElement();
        }

		public void ReadHiddenPaths()
		{
			ReadStartElement("hiddenPaths");
			ReadPaths("hidden",project.HiddenPaths);
			ReadEndElement();
		}

		public void ReadProjectOptions()
		{
			ReadStartElement("options");
			while (Name == "option")
			{
				MoveToFirstAttribute();
				switch (Name)
				{
					case "showHiddenPaths": project.ShowHiddenPaths = BoolValue; break;
                    case "command": project.StartupCommand = Value; break;
                    case "argument": project.StartupArgument = Value; break;
                    case "workingdir": project.WorkingDir = Value; break;
                    case "symbolpath": project.SymbolPath = Value; break;
				}
				Read();
			}
			ReadEndElement();
		}

		public bool BoolValue { get { return Convert.ToBoolean(Value); } }
		public int IntValue { get { return Convert.ToInt32(Value); } }

		public void ReadPaths(string pathNodeName, IAddPaths paths)
		{
			while (Name == pathNodeName)
			{
				paths.Add(OSPath(GetAttribute("path")));
				Read();
			}
		}

		protected string OSPath(string path)
		{
            if (path != null)
            {
                path = path.Replace('/', System.IO.Path.DirectorySeparatorChar);
                path = path.Replace('\\', System.IO.Path.DirectorySeparatorChar);
            }
            return path;
		}
	}
}
