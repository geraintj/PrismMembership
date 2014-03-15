﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismMembership.Data;

namespace PrismMembership.Services
{
    [Export]
    public class MemberService : IMemberService
    {
        private IRepo<Member> _memberRepo;

        [ImportingConstructor]
        public MemberService(IRepo<Member> memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _memberRepo.All();
        }

        public IEnumerable<Member> GetMembersForMembership(string fId)
        {
            return _memberRepo.Query(m => m.FID == fId);
        }

        public Member GetMember(string fId, string pId)
        {
            return _memberRepo.Single(m => m.FID == fId && m.PID == pId);
        }
    }
}