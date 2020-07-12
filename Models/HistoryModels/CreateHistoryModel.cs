using System;
using System.Collections.Generic;
using System.Text;

namespace Models.HistoryModels
{
    public class CreateHistoryModel
    {
        public int ToolboothId { get; set; }
        public int EmployeeId { get; set; }
        public float Value { get; set; }
        public int CategoryId { get; set; }

    }
}
