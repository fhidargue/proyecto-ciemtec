using Ciemtec_Api.Entities;

namespace Pattern.IRepository
{
    public interface IRolRepository : IRepository<Rol>
    {

        bool ExistRol(string rolName);

        bool ExistRol(int rolId);

        bool ValidateRolName(int rolId, string name);

        Rol GetRolByName(string name);

    }
}
