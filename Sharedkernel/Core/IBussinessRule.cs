namespace Sharedkernel.Core
{
    public interface IBussinessRule
    {
        bool IsValid();

        string Message { get; }

    }
}
