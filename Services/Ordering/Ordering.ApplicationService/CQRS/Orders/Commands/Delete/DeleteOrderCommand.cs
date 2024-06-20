namespace Ordering.ApplicationService.CQRS.Orders.Commands.Delete
{
    public class DeleteOrderCommand : MediatR.IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteOrderCommand(int id)
        {
            Id = id;
        }
    }
}
