using System;
using System.Collections.Generic;

namespace CustomerThreads
{
    public class DeviceItem
    {
        // Required
        public string Name { get; set; }

        // Optional device info
        public string DeviceType { get; set; }     // Laptop, Phone, Console, etc
        public string ModelNumber { get; set; }
        public string SerialNumber { get; set; }

        // Dates
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? FinishedAt { get; set; }

        // Price
        public decimal Price { get; set; }

        // ✅ Device-specific notes ONLY
        public List<DeviceNote> Notes { get; set; } = new List<DeviceNote>();

        public override string ToString()
        {
            string finished = FinishedAt.HasValue
                ? FinishedAt.Value.ToString("dd-MM-yyyy")
                : "In progress";

            return $"{Name} | {Price:0.00} | Finished: {finished} | Notes: {Notes.Count}";
        }
    }
}