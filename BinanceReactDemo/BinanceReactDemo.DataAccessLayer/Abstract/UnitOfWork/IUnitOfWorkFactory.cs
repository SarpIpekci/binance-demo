namespace BinanceReactDemo.DataAccessLayer.Abstract.UnitOfWork
{
    /// <summary>
    /// IUnit Of Work Factory
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
