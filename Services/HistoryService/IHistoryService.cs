using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.HistoryService
{
    public interface IHistoryService
    {
        bool Create(History history);
        IEnumerable<object> GetMonthlyAverage();
    }
}
