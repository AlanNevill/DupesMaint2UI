namespace DupesMaint2UI
{
    using System;

    public partial class DupesAction
    {
        public string TheFileName { get; set; }

        public string DuplicateOf { get; set; }

        public string SHA { get; set; }

        public string FileExt { get; set; }

        public int FileSize { get; set; }

        public DateTime FileCreateDt { get; set; }

        public string OneDriveRemoved { get; set; }

        public string GooglePhotosRemoved { get; set; }
    }
}
