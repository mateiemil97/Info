using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ToolboothModels
{
    public class GetToolboothModel
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public bool InUse { get; set; }
    }
}
