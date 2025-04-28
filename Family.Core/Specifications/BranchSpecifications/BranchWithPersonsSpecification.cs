using Family.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.Core.Specifications.BranchSpecifications
{
    public class BranchWithPersonsSpecification : BaseSpecification<Branch>
    {
        public BranchWithPersonsSpecification(int branchId)
            : base(x => x.Id == branchId)
        {
            AddInclude(x => x.Persons);
        }

        public BranchWithPersonsSpecification(int clanId, bool filterByClan)
            : base(x => x.ClanId == clanId)
        {
            AddInclude(x => x.Persons);
        }
    }
}
