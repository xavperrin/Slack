using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServerSlack.DAO
{
    interface IDataAccess<T, ID>
    {
        

        bool Create(T t);
        T Retrieve(ID id);
        bool Update(T t, ID id);
        bool Delete(ID id);
        List<T> ListAll();

    }
}
