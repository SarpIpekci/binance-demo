using BinanceReactDemo.API.DataTransferObject;
using BinanceReactDemo.API.Models.BinanceHub;

namespace BinanceReactDemo.API.Repostories.FillModal.Interface
{
    public interface IGetModal
    {
        public Task<List<BinanceItem>> GetFillModal();
    }
}
