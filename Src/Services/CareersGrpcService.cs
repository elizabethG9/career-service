using CareersProto;
using Grpc.Core;

public class CareersGrpcService : CareerService.CareerServiceBase
{
    private readonly CareersService _careersService;
    public CareersGrpcService(CareersService careersService)
    {
        _careersService = careersService;
    }

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