using ArasControl.Application.DTOs;
using MediatR;

namespace ArasControl.Application.Queries.FeedInventory
{
    public class ListAllFeedInventoriesQuery : IRequest<IEnumerable<FeedInventoryDto>>
    {
    }
}
