using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_crud_cadastro_series.Classes
{
    public abstract class EntidadeBase
    {
        public int Id { get; protected set; }

        public void SetId(int id)
        {
             this.Id = id ;
        }

        public int GetId()
        {
            return this.Id;
        }
    }
}
