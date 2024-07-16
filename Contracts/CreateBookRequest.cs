using MediatR;

namespace VerticalSliceArchitectureCQRSMediatRCarter.Contracts
{
    public class CreateBookRequest/*: IRequest<Unit>*/
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
