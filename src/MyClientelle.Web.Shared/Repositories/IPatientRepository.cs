namespace ClientelleAPI.Repositories;

using Kampa.MyClientelle.Web.Shared.Dto;
using Kampa.MyClientelle.Web.Shared.Repositories;

public interface IPatientRepository : IRepository<long,CreatePatientDto,GetPatientDto,UpdatePatientDto>
{
}
