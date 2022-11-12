using Microsoft.AspNetCore.Mvc;
using Lab1_1;
using repository;
using System.Net;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class StorehouseController : Controller
    {
        private readonly ILogger<StorehouseController> _logger;

        private readonly IPImportedRepository _pimportedRepository;

        public StorehouseController(ILogger<StorehouseController> logger, IPImportedRepository pimportedRepository)
        {
            _logger = logger;
            _pimportedRepository= pimportedRepository;
        }

        [HttpPost("PostProductImported/{description},{id},{price_purchase},{phoneNumber},{tax}", Name = "PostProductImported")]
        public ActionResult<ProductImported> PostProductImported(string description, int id, float price_purchase, float tax)
        {
            _pimportedRepository.BeginTransaction();
            var pimported = _pimportedRepository.CreatePImported(description, id, price_purchase, tax);
            _pimportedRepository.CommitTransaction();
            if (pimported == null)
            {
                _logger.LogError($"{nameof(StorehouseController.PostProductImported)} -> cannot create ProductImported");
                return NotFound();
            }
            return pimported;
        }

        [HttpGet("GetPImported", Name = "GetPImported")]
        public ActionResult<IEnumerable<ProductImported>> GetPImported()
        {
            _pimportedRepository.BeginTransaction();
            var pimported = _pimportedRepository.GetPImported();
            _pimportedRepository.CommitTransaction();
            if (pimported == null)
            {
                _logger.LogError($"{nameof(StorehouseController.GetPImported)} -> ProductImported not found");
                return NotFound();
            }
            return pimported;
        }

        [HttpGet("GetPImported/{id}", Name = "GetPImported")]
        public ActionResult<ProductImported> GetPImported(int id)
        {
            _pimportedRepository.BeginTransaction();
            var pimported = _pimportedRepository.GetPImported(id);
            _pimportedRepository.CommitTransaction();
            if (pimported == null)
            {
                _logger.LogError($"{nameof(StorehouseController.GetPImported)} -> pimported not found");
                return NotFound();
            }
            return pimported;
        }

    }
}