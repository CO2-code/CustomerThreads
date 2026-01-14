using System;
using System.Collections.Generic;

namespace CustomerThreads
{
    public class DeviceItem
    {
        public string Name { get; set; }

        // When the device was added to the job
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // When the device was finished (optional)
        public DateTime? FinishedAt { get; set; }

        public decimal Price { get; set; }

        // ✅ Device-specific notes ONLY
        public List<DeviceNote> Notes { get; set; } = new List<DeviceNote>();

        public override string ToString()
        {
            string created = CreatedAt.ToString("yyyy-MM-dd");

            string finished = FinishedAt.HasValue
                ? FinishedAt.Value.ToString("yyyy-MM-dd")
                : "In progress";

            return $"{Name} | {Price:0.00} | Created: {created} | Finished: {finished} | Notes: {Notes.Count}";
        }
    }
}