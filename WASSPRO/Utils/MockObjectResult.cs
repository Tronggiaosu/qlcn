using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCongNo.Utils
{
    // Mock implementation of ObjectResult
    public class MockObjectResult<T> : ObjectResult<T>
    {
        private readonly IEnumerator<T> _dataEnumerator;

        public MockObjectResult(IEnumerable<T> data)
            : base(null, null)
        {
            _dataEnumerator = data.GetEnumerator();
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return _dataEnumerator;
        }
    }
}