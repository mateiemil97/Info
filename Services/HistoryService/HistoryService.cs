using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Repository;

namespace Services.HistoryService
{
    public class HistoryService : IHistoryService
    {
        private IUnitOfWork _unitOfWork;
        public HistoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool Create(History history)
        {
            history.DateTime = DateTime.UtcNow.ToLocalTime();

            _unitOfWork.History.Create(history);

            var created = _unitOfWork.Save();

            if(!created)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<object> GetMonthlyAverage()
        {
            var average = _unitOfWork.History.GetMonthlyAveragePerLocation();
            return average;
        }
    }
}
