using static Stock.Core.IUseCaseRequest;

namespace Stock.Core
{
    public interface IUseCaseRequestHandler<in TUseCaseRequest, out TUseCaseResponse> where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
    {
        Task<bool> Handle(TUseCaseRequest message, IOutputPort<TUseCaseResponse> outputPort);
    }

    public interface IUseCaseRequestHandler<out TUseCaseResponse>
    {
        Task<bool> Handle(IOutputPort<TUseCaseResponse> outputPort);
    }
}
