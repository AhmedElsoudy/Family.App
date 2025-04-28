using Family.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.Core.Specifications.PersonSpecifications
{
    public class PersonWithDetailsSpecification : BaseSpecification<Person>
    {
        public PersonWithDetailsSpecification(int personId)
            : base(x => x.Id == personId)
        {
            AddInclude(x => x.Notifications);
            AddInclude(x => x.Branch);
            AddInclude(x => x.Clan);
        }

        public PersonWithDetailsSpecification(int branchId, bool filterByBranch)
            : base(x => x.BranchId == branchId)
        {
            AddInclude(x => x.Notifications);
        }
    }
}
