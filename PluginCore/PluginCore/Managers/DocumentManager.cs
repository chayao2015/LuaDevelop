using System;
using System.IO;
using System.Text;
using PluginCore.Localization;
using ScintillaNet;
using PluginCore;

namespace PluginCore.Managers
{
    public class DocumentManager
    {
        private static Int32 DocumentCount;
        
        static DocumentManager()
        {
            DocumentCount = 1;
        }

        /// <summary>
        /// Creates a new name for new document 
        /// </summary>
        public static String GetNewDocumentName(String extension)
        {
            if (extension == null)
            {
                extension = PluginBase.MainForm.Settings.DefaultFileExtension;
            }

            Int32 count = DocumentCount++;
            if (!extension.StartsWith(".")) extension = "." + extension;
            String untitled = TextHelper.GetString("LuaDevelop.Info.UntitledFileStart");
            return untitled + count + extension;
        }

        /// <summary>
        /// Closes all open files inside the given path
        /// </summary>
        public static void CloseDocuments(String path)
        {
            foreach (ITabbedDocument document in PluginBase.MainForm.Documents)
            {
                if (document.IsEditable)
                {
                    path = Path.GetFullPath(path);
                    Char separator = Path.DirectorySeparatorChar;
                    String filename = Path.GetFullPath(document.FileName);
                    if (filename == path || filename.StartsWith(path + separator))
                    {
                        document.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Renames the found documents based on the specified path
        /// NOTE: Directory paths should be without the last separator
        /// </summary>
        public static void MoveDocuments(String oldPath, String newPath)
        {
            Boolean reactivate = false;
            oldPath = Path.GetFullPath(oldPath);
            newPath = Path.GetFullPath(newPath);
            ITabbedDocument current = PluginBase.MainForm.CurrentDocument;
            foreach (ITabbedDocument document in PluginBase.MainForm.Documents)
            {
                if (document.IsEditable)
                {
                    String filename = Path.GetFullPath(document.FileName);
                    if (filename.StartsWith(oldPath))
                    {
                        TextEvent ce = new TextEvent(EventType.FileClose, document.FileName);
                        EventManager.DispatchEvent(PluginBase.MainForm, ce);
                        document.SciControl.FileName = filename.Replace(oldPath, newPath);
                        TextEvent oe = new TextEvent(EventType.FileOpen, document.FileName);
                        EventManager.DispatchEvent(PluginBase.MainForm, oe);
                        if (current != document)
                        {
                            document.Activate();
                            reactivate = true;
                        }
                        else
                        {
                            TextEvent se = new TextEvent(EventType.FileSwitch, document.FileName);
                            EventManager.DispatchEvent(PluginBase.MainForm, se);
                        }
                    }
                    PluginBase.MainForm.ClearTemporaryFiles(filename);
                    document.RefreshTexts();
                }
            }
            PluginBase.MainForm.RefreshUI();
            if (reactivate) current.Activate();
        }

        /// <summary>
        /// Activates the document specified by document index
        /// </summary>
        public static void ActivateDocument(Int32 index)
        {
            if (index < PluginBase.MainForm.Documents.Length && index >= 0)
            {
                PluginBase.MainForm.Documents[index].Activate();
            }
            else PluginBase.MainForm.Documents[0].Activate();
        }

        /// <summary>
        /// Finds the document by the file name
        /// </summary>
        public static ITabbedDocument FindDocument(String filename)
        {
            Int32 count = PluginBase.MainForm.Documents.Length;
            for (Int32 i = 0; i < count; i++)
            {
                ITabbedDocument current = PluginBase.MainForm.Documents[i];
                if (current.IsEditable && current.FileName == filename)
                {
                    return current;
                }
            }
            return null;
        }

        /// <summary>
        /// Finds the document by the ScintillaControl
        /// </summary>
        public static ITabbedDocument FindDocument(ScintillaControl sci)
        {
            Int32 count = PluginBase.MainForm.Documents.Length;
            for (Int32 i = 0; i < count; i++)
            {
                ITabbedDocument current = PluginBase.MainForm.Documents[i];
                if (current.IsEditable && current.SciControl == sci)
                {
                    return current;
                }
            }
            return null;
        }

    }

}
