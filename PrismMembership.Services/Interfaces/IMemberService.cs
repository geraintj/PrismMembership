using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PrismMembership.Data;

namespace PrismMembership.Services
{
    public interface IMemberService
    {
        IEnumerable<Member> GetAllMembers();
        IEnumerable<Member> GetMembersForMembership(string fId);
        Member GetMember(string fId, string pId);
    }
}
