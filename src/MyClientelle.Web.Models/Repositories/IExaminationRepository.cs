namespace Kampa.MyClientelle.Web.Models.Repositories;

using Kampa.MyClientelle.Web.Models.Dto;

public interface IExaminationRepository : IRepository<long, CreateExaminationDto, GetExaminationDto, UpdateExaminationDto>
{
}
