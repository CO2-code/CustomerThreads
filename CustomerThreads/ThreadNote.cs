using System;

namespace CustomerThreads
{
    public class ThreadNote
    {
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"{CreatedAt:yyyy-MM-dd HH:mm} - {Text}";
        }
    }
}