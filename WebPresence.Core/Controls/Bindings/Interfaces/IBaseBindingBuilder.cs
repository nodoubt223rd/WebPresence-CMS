using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPresence.Core.Controls.Bindings.Interfaces
{
    public interface IBaseBindingBuilder
    {
        IBindingBuilder<N> ToType<N>();
        string BindingPrefix { get; set; }
    }
}
