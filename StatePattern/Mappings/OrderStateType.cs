using System.Data;
using System.Data.Common;
using NHibernate;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using StatePattern.Model;

namespace StatePattern.Mappings
{
    public class OrderStateType : ImmutableUserType<OrderState>
    {
        public override object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            var statusValue = (long)NHibernateUtil.Int64.NullSafeGet(rs, names[0], session);
            return OrderStateValueFactory.GetState(statusValue);
        }

        public override void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            var state = (OrderState)value;
            var valueToSave = OrderStateValueFactory.GetValueBasedOnType(state);
            NHibernateUtil.Int64.NullSafeSet(cmd, valueToSave, index, session);
        }

        public override SqlType[] SqlTypes => new[] { new SqlType(DbType.Int64) };
    }
}