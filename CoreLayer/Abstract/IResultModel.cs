using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Abstract
{
    public interface IResultModel
    {
        public int Code { get; }
        public string Message { get; }
        public object? Data { get; }
    }
}
