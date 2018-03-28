using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.Authorization.Web.Model
{
    public class SubmitResult
    {
        public bool Succeed { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
