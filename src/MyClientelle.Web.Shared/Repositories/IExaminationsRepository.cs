namespace Kampa.MyClientelle.Web.Shared.Repositories;

using Kampa.MyClientelle.Web.Shared.Dto;

public interface IExaminationsRepository : IRepository<long, CreateExaminationsDto, GetExaminationsDto, UpdateExaminationsDto>
{
}