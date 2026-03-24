using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class RemoveAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public RemoveAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAddressCommand request)
        {
            var address = await _repository.GetByIdAsync(request.Id);

            if (address != null)
            {
                await _repository.DeleteAsync(address);
            }
        }
    }
}
