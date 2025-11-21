using System;

namespace AttendanceSystem.Models
{
    public class AdminViewLog
    {
        public int ViewLogId { get; set; } // ✅ Primary Key

        public int VisitorId { get; set; }
        public Visitor? Visitors { get; set; }

        public DateTime ViewedAt { get; set; } = DateTime.Now;

        public ICollection<AttendanceRecord>? AttendanceRecords { get; set; }
        public ICollection<AdminViewLog>? ViewLogs { get; set; }
    }
}