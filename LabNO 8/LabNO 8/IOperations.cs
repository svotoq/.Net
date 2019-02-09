using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNO_8
{
    public interface IOperations<T> where T : struct
    {
        CollectionType<T> Add(T obj, int index);
        CollectionType<T> Delete(T obj);
        void Show();
    }
}
