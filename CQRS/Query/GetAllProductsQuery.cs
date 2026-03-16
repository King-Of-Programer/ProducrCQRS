using MediatR;
using ProducrCQRS.Models;
using ProducrCQRS.Profiles;

namespace ProducrCQRS.CQRS.Query
{
    public class GetAllProductsQueryRequest() : IRequest<Result<List<ProductViewProfile>>>
    {

    }
    
}
