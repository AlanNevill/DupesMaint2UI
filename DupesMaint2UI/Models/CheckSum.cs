using System;
using System.IO;

namespace DupesMaint2UI
{

    public partial class CheckSum
    {
        public int Id { get; set; }

        public string SHA { get; set; }

        public string Folder { get; set; }

        public string TheFileName { get; set; }

        public string FileExt { get; set; }

        public int FileSize { get; set; }

        public DateTime FileCreateDt { get; set; }

        public int TimerMs { get; set; }

        public string Notes { get; set; }

        public DateTime CreateDateTime { get; set; }

        public string SCreateDateTime { get; set; }

        public string FullName()
        {
            return (string)Path.Combine(Folder, TheFileName);
        }

    }
}
