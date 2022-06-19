using AutoMapper;
using ContactsAndCallsAccountingSystem.API.InputModels;
using ContactsAndCallsAccountingSystem.API.OutputModels;
using ContactsAndCallsAccountingSystem.BLL.Interfaces;
using ContactsAndCallsAccountingSystem.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ContactsAndCallsAccountingSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallsController : Controller
    {
        private readonly ICallService _callService;
        private readonly IMapper _mapper;

        public CallsController(ICallService callService, IMapper mapper)
        {
            _callService = callService;
            _mapper = mapper;
        }

        [HttpPost("call")]
        [SwaggerOperation(Summary = "Add new call")]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        public async Task<ActionResult> AddCall([FromBody] CallInputModel call)
        {
            await _callService.AddCall(_mapper.Map<AddCallModel>(call));

            return StatusCode(201);
        }

        [HttpPost("conference")]
        [SwaggerOperation(Summary = "Add new conference")]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        public async Task<ActionResult> AddConference([FromBody] ConferenceInputModel conference)
        {
            await _callService.AddConference(_mapper.Map<AddConferenceModel>(conference));

            return StatusCode(201);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update call")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "NotFound")]
        public async Task<ActionResult> UpdateCall([FromBody] CallUpdateModel call)
        {
            var callModel = _mapper.Map<CallModel>(call);
            await _callService.UpdateCall(callModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete call")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "NotFound")]
        public async Task<ActionResult> DeleteCall(Guid id)
        {
            await _callService.DeleteCall(id);

            return NoContent();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<List<CallOutputModel>>> GetAll()
        {
            var calls = _mapper.Map<List<CallOutputModel>>(await _callService.GetAll());

            return calls;
        }

        [HttpGet("get-calls")]
        [SwaggerOperation(Summary = "Get all calls")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<List<CallOutputModel>>> GetAllCalls()
        {
            var calls = _mapper.Map<List<CallOutputModel>>(await _callService.GetAllCalls());

            return calls;
        }

        [HttpGet("get-conferences")]
        [SwaggerOperation(Summary = "Get all conferences")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<List<CallOutputModel>>> GetAllConferences()
        {
            var calls = _mapper.Map<List<CallOutputModel>>(await _callService.GetAllConferences());

            return calls;
        }
    }
}
