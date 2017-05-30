
namespace WebPresence.Core.Controls.Bindings.Interfaces
{
    public interface IAncestorBindingBuilder<M, A> : IBindingBuilder<M>
    {
        IBindingBuilder<A> Back();
    }
}
