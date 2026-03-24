using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var addresses = await _repository.GetAllAsync();

            return addresses.Select(i => new GetAddressQueryResult
            {
                AddressId = i.AddressId,
                City = i.City,
                Detail = i.Detail,
                District = i.District,
                UserId = i.UserId,
            }).ToList();
        }
    }
}
