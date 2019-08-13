using Finkit.ManicTime.Shared.DocumentTracking;
using ManicTime.Client.Tracker.EventTracking.Publishers.ApplicationTracking;

namespace Plugins.Notepad
{
    public class VisualStudioFileRetreiver : IDocumentRetreiver
    {
        public DocumentInfo GetDocument(ApplicationInfo application)
        {

            if (!CheckForProcess(application))
                return null;

            // get the filename
            string filename = GetFilename(application);


            if (filename != null)
                return new DocumentInfo() { DocumentName = filename, DocumentGroupName = filename, DocumentType = DocumentTypes.File };

            return null;
        }

        private bool CheckForProcess(ApplicationInfo application)
        {
            if (application.ProcessName == "notepad")
                return true;

            return false;
        }

        private string GetFilename(ApplicationInfo application)
        {
            // notepad title looks like  'filename - Notepad'. We are only after the first part, 'filename'
            var i = application.WindowTitle.LastIndexOfAny(new []{ '-', '–' });
            if (i > 0)
            {
                return application.WindowTitle.Substring(0, i).Trim();
            }

            return null;
        }
    }
}
