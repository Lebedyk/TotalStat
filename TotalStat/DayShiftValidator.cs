using System;
using System.Collections.Generic;

namespace TotalStat
{    
    public class DayShiftValidator
    {
        private Dictionary<object, Func<DateTime>> _map = new Dictionary<object, Func<DateTime>>(4);
        public DayShiftValidator()
        {
            _map.Add(Localize.DayToday, () => DateTime.Today);
            _map.Add(Localize.DayTomorrow, () => DateTime.Today.DayOfWeek == DayOfWeek.Friday
                ? DateTime.Today.AddDays(3)
                : DateTime.Today.AddDays(1));
            _map.Add(Localize.DayYesterday, () => DateTime.Today.DayOfWeek == DayOfWeek.Monday
               ? DateTime.Today.AddDays(-3)
               : DateTime.Today.AddDays(-1));
            _map.Add(Localize.DayBeforeYesterday, () =>
                (DateTime.Today.DayOfWeek == DayOfWeek.Monday) || (DateTime.Today.DayOfWeek == DayOfWeek.Thursday)
                    ? DateTime.Today.AddDays(-4)
                    : DateTime.Today.AddDays(-2)
            );
        }
        public DayShiftValidator(object today, object tomorrow, object yesterday, object beforeYesterday)
        {
            _map.Add(today, () => DateTime.Today);
            _map.Add(tomorrow, () => DateTime.Today.DayOfWeek == DayOfWeek.Friday
                ? DateTime.Today.AddDays(3)
                : DateTime.Today.AddDays(1));
            _map.Add(yesterday, () => DateTime.Today.DayOfWeek == DayOfWeek.Monday
               ? DateTime.Today.AddDays(-3)
               : DateTime.Today.AddDays(-1));
            _map.Add(beforeYesterday, () =>
                (DateTime.Today.DayOfWeek == DayOfWeek.Monday) || (DateTime.Today.DayOfWeek == DayOfWeek.Thursday)
                    ? DateTime.Today.AddDays(-4)
                    : DateTime.Today.AddDays(-2)
            }

        public DateTime GetShift(object day)
        {
            if (!_map.ContainsKey(day))
            {
                //добавить ошибки
                return DateTime.Now;
            }
            return _map[day]();
        }
    }
}
