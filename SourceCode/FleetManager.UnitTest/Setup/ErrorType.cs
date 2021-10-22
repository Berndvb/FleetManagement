using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.UnitTest.Integration.Setup
{
    public class ErrorType : ValueObject
    {
        #region Properties

        public string Value { get; }

        #endregion

        #region Constructors

        private ErrorType(string value)
        {
            Value = value;
        }

        #endregion

        public static implicit operator string(ErrorType key)
        {
            return key.Value;
        }

        public static explicit operator ErrorType(string key)
        {
            return new ErrorType(key);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
