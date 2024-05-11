using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Response;

namespace Application.Services.Interfaces
{
    public interface IUserDetailService
    {
        Task<IEnumerable<UserDetailResponse>> GetAllUserDetails(CancellationToken cancellationToken);
    }
}
