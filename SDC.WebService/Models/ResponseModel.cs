using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDC.WebService.Models
{
    public class ResponseModel<T>
    {
        public ResponseModel(T data, StatusInfo status)
        {
            Data = data;
            Status = status;
        }
        public T Data { get; set; }

        public StatusInfo Status { get; set; }
    }
}
