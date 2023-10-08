using BinanceReactDemo.API.Models.BinanceHub;

namespace BinanceReactDemo.API.Repostories.FillModal.Interface
{
    /// <summary>
    /// Fill Modal
    /// </summary>
    public interface IGetModal
    {
        /// <summary>
        /// Get Fill Modal
        /// </summary>
        /// <returns>List<BinanceItem></returns>
        public Task<List<BinanceItem>> GetFillModal();
    }
}
