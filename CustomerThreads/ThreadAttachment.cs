using System;

namespace CustomerThreads
{
    public class ThreadAttachment
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }   // stored path
        public DateTime AddedAt { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"{FileName} ({AddedAt:yyyy-MM-dd HH:mm})";
        }
    }
}