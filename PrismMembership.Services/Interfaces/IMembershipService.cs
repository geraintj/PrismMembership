using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismMembership.Data;

namespace PrismMembership.Services
{
    public interface IMembershipService
    {
        IEnumerable<Membership> GetAllMemberships();
        IEnumerable<Membership> SearchMemberships(string surname);
        Membership GetMembership(string fId);
    }
}
