using System;
using System.Collections.Generic;

namespace TotalStat
{
    public partial class RedactorWindow
    {
        public class DayShiftValidator
        {
            private Dictionary<object, Func<DateTime>> _map = new Dictionary<object, Func<DateTime>>(3);
            public DayShiftValidator()
            {
                _map.Add(Localize.DayToday, () => DateTime.Today);
                _map.Add(Localize.DayTomorrow, () => DateTime.Today.DayOfWeek == DayOfWeek.Friday
                    ? DateTime.Today.AddDays(3)
                    : DateTime.Today.AddDays(1));
                _map.Add(Localize.DayYesterday, () => DateTime.Today.DayOfWeek == DayOfWeek.Monday
                   ? DateTime.Today.AddDays(-3)
                   : DateTime.Today.AddDays(-1));
            }
            public DayShiftValidator(object today, object tomorrow, object yesterday)
            {
                _map.Add(today, () => DateTime.Today);
                _map.Add(tomorrow, () => DateTime.Today.DayOfWeek == DayOfWeek.Friday
                    ? DateTime.Today.AddDays(3)
                    : DateTime.Today.AddDays(1));
                _map.Add(yesterday, () => DateTime.Today.DayOfWeek == DayOfWeek.Monday
                   ? DateTime.Today.AddDays(-3)
                   : DateTime.Today.AddDays(-1));
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
}
