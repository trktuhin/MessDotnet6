using Core.Entities;
using Core.Specifications.SearchParams;

namespace Core.Specifications
{
    public class MemberSingleSpec : BaseSpecification<Member>
    {
        // For Search by different params
        public MemberSingleSpec(MemberSearchParams memberParams)
        : base(x => (string.IsNullOrEmpty(memberParams.UserId) || x.UserId == memberParams.UserId)
        && (string.IsNullOrEmpty(memberParams.Mobile) || x.UserId == memberParams.Mobile)
        && (string.IsNullOrEmpty(memberParams.Email) || x.UserId == memberParams.Email))
        {

        }
        // For Search by Member Id
        public MemberSingleSpec(int id) : base(x => x.Id == id) { }
    }
}