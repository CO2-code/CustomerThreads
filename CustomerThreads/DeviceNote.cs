using System;

namespace CustomerThreads
{
    public class DeviceNote
    {
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public override string ToString()
        {
            string created = CreatedAt.ToString("yyyy-MM-dd HH:mm");
            return $"{Text} (Created: {created})";
        }
    }
}