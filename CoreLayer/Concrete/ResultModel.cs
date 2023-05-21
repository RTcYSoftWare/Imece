using CoreLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Concrete
{
    public class ResultModel : IResultModel
    {
        public ResultModel(int Code, string Message, object? Data)
        {
            this.Code = Code;
            this.Message = Message;
            this.Data = Data;
        }

        public int Code { get; }
        public string Message { get; }
        public object? Data { get; }
    }
}
