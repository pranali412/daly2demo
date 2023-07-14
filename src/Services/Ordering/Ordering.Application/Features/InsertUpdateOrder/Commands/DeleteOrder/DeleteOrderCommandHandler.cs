using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Exceptions;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.InsertUpdateOrder.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {

            var OrderToDelete = await _orderRepository.GetByIdAsync(request.Id);

            if (OrderToDelete == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
                //_logger.LogError("Order not exist on database.  ");

            }
            await _orderRepository.DeleteAsync(OrderToDelete);

            //_logger.LogInformation($"Order {OrderToDelete.Id} is successfully deleted. ");

            return Unit.Value;
        }
    }
}
