using Api.Models;
using Api.Repository.Implement.TblFacturaRepository;

namespace Api.Services.TblFacturaService
{
    public class TblFacturaServiceImpl : ITblFacturaService
    {
        private readonly ITblFacturaRepository _tblFacturaRepository;

        public TblFacturaServiceImpl(ITblFacturaRepository tblFacturaRepository)
        {
            _tblFacturaRepository = tblFacturaRepository;
        }

        public IEnumerable<TblFactura> Get()
        {
            return _tblFacturaRepository.GetAll().Result;
        }

        public TblFactura? Get(int id)
        {
            return _tblFacturaRepository.GetById(id).Result;
        }

        public TblFactura? Create(TblFactura tblFactura)
        {
            return _tblFacturaRepository.Create(tblFactura).Result;
        }

    }
}
