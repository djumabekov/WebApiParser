using Microsoft.AspNetCore.Mvc;
using WebApiParser.Infrastructure.Services;

namespace WebApiParser.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferenceManagerController : ControllerBase
    {
        private readonly ReferencesManagerService _referencesManagerService;
        public ReferenceManagerController(ReferencesManagerService referencesManagerService)
        {
            _referencesManagerService = referencesManagerService;
        }


        [HttpGet]
        public async Task ExtractAllRepositories()
        {
            await _referencesManagerService.ExtractAllReferences();
        }
    }
}
