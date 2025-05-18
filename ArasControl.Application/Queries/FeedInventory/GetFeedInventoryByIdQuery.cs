using ArasControl.Application.DTOs;
using MediatR;

namespace ArasControl.Application.Queries.FeedInventory
{
    public class GetFeedInventoryByIdQuery : IRequest<FeedInventoryDto>
    {
        public Guid Id { get; set; }
        public GetFeedInventoryByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
