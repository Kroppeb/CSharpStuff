using System;
using System.Collections.Generic;
using System.Text;

namespace Kroppeb.Copyable
{
    public interface IDeepCopyable<out T> where T : IDeepCopyable<T>
    {
		T DeepCopy();
    }
}
