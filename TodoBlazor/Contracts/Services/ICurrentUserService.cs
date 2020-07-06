using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoBlazor.Contracts.Services
{
    public interface ICurrentUserService
    {
        Guid UserId { get; set; }
    }
}
