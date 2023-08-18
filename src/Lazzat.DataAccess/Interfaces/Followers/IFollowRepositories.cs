using Lazzat.DataAccess.Commons.Interfaces;
using Lazzat.Domain.Entities.Follower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazzat.DataAccess.Interfaces.Followers;

public interface IFollowRepositories : IRepository<Follow, Follow>, IGetAll<Follow>
{
}
