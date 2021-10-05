namespace MediatR.Cqrs.Queries
{
    public interface IQuery<out TRes> : IRequest<TRes>
    {
    }

    //public interface IQuery : IRequest<INSERTRESULT>
    //{
    //}
}
