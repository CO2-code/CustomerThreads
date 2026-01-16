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

        // ✅ NEW: date device was received
        public DateTime? DateReceived { get; set; }

        // Finished date (only when finished)
        public DateTime? FinishedAt { get; set; }

        // ✅ NEW: device state
        public string State { get; set; } = "In Progress"; // or "Finished"

        // Price
        public decimal Price { get; set; }

        // Device-specific notes
        public List<DeviceNote> Notes { get; set; } = new List<DeviceNote>();

        public override string ToString()
        {
            string stateText = State ?? "In Progress";

            string finishedText = FinishedAt.HasValue
                ? FinishedAt.Value.ToString("dd-MM-yyyy")
                : "-";

            string receivedText = DateReceived.HasValue
                ? DateReceived.Value.ToString("dd-MM-yyyy")
                : "-";

            return $"{Name} | {stateText} | Recv: {receivedText} | Price: {Price:0.00}";
        }
    }
}