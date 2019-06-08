using System;
using System.Collections.Generic;
using System.Linq;
using StatePattern.Model;

namespace StatePattern.Mappings
{
    public static class OrderStateValueFactory
    {
        private static Dictionary<Type, long> _values = new Dictionary<Type, long>();

        static OrderStateValueFactory()
        {
            _values.Add(typeof(DraftState), 1);
            _values.Add(typeof(ConfirmedState), 2);
            _values.Add(typeof(RejectedState), -1);
            _values.Add(typeof(ShippedState), 3);
        }

        public static OrderState GetState(long value)
        {
            var item = _values.FirstOrDefault(a => a.Value == value);
            return Activator.CreateInstance(item.Key) as OrderState;
        }

        public static long GetValueBasedOnType(OrderState state)
        {
            var type = state.GetType();
            return _values[type];
        }
    }
}