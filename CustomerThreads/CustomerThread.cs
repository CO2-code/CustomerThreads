using System;
using System.Collections.Generic;

namespace CustomerThreads
{
    public class CustomerThread
    {
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public List<DeviceItem> Devices { get; set; } = new List<DeviceItem>();
        public string Category { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public decimal Price { get; set; }
        public bool IsArchived { get; set; }
            
        public override string ToString()
        {
                return Title;
        }
        
        public CustomerType CustomerType { get; set; }
        public string CompanyName { get; set; }

        public List<ThreadNote> Notes { get; set; } = new List<ThreadNote>();

        // ---------- Attachments ----------
        public List<ThreadAttachment> Attachments { get; set; } = new List<ThreadAttachment>();

    }
}