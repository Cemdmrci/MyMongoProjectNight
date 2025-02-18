using MyMongoProjectNight.Dtos.DepartmentDtos;

namespace MyMongoProjectNight.Services.DepartmentServices
{
    public interface IDepartmentService
    {
        Task<List<ResultDepartmentDto>> GetAllDepartmentAsync();
        Task CreateDepartmentasync(CreateDepartmentDto createDepartmentDto);
        Task UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto);
        Task DeleteDepartmentAsync(string DepartmentId);
        Task<GetByIdDepartmentDto> GetByIdDepartmentAsync(string DepartmentId);
    }
}

