namespace Kampa.MyClientelle.Web.Models.Repositories;

using Kampa.MyClientelle.Web.Models.Dto;

public interface IPatientRepository : IRepository<long, CreatePatientDto, GetPatientDto, UpdatePatientDto>
{
}
