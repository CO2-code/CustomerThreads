using System;

namespace CustomerThreads
{
    public class DeviceNote
    {
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public override string ToString()
        {
            // Example: 10:20 22-04-2026
            return $"{CreatedAt:HH:mm dd-MM-yyyy} - {Text}";
        }
    }
}