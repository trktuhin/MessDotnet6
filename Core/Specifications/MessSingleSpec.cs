using Core.Entities;
using Core.Specifications.SearchParams;

namespace Core.Specifications
{
    public class MessSingleSpec : BaseSpecification<MessInfo>
    {
        // For Search by different params
        public MessSingleSpec(MessSearchParams searchParams)
        : base(x => (string.IsNullOrEmpty(searchParams.OwnerId) || x.OwnerId == searchParams.OwnerId)
        && (string.IsNullOrEmpty(searchParams.Location) || x.Location == searchParams.Location)
        && (string.IsNullOrEmpty(searchParams.MessName) || x.MessName == searchParams.MessName))
        {

        }
        // For Search by Mess Id
        public MessSingleSpec(int id) : base(x => x.Id == id) { }
    }
}