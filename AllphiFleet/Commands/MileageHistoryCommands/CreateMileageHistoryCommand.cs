using DTO;
using MediatR;

namespace Commands.MileageHistoryCommands
{
    public class CreateMileageHistoryCommand : IRequest<int>
    {
        public CreateMileageHistoryDTO CreateMileageHistoryDTO { get; set; }
    }
}
