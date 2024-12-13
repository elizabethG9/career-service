using career_service.Src.Services.Interface;
using CareersProto;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;

public class CareersGrpcService : CareerService.CareerServiceBase
{
    private readonly ICareersService _careersService;
    public CareersGrpcService(ICareersService careersService)
    {
        _careersService = careersService;
    }

    [Authorize]
    public override async Task<CareersResponse> GetAllCareers(Empty request, ServerCallContext context)
    {
        var careers = await _careersService.GetAllCareers();
        var response = new CareersResponse();

        foreach (var career in careers)
        {
            response.Careers.Add(new CareersProto.Career
            {
                Id = career.Id,
                Name = career.Name,
            });
        }
        return response;
    }
}