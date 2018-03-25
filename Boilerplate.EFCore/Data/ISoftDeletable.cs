namespace Boilerplate.EFCore.Data
{
    public interface ISoftDeletable
    {
        bool Deleted { get; set; }
    }
}
