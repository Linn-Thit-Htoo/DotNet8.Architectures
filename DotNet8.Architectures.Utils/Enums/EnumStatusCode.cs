using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.Utils.Enums
{
    public enum EnumStatusCode
    {
        None,
        Success = 200,
        Created = 201,
        Accepted = 202,
        BadRequest = 400,
        NotFound = 404,
        Conflict = 409,
        Locked = 423,
        InternalServerError = 500
    }
}
