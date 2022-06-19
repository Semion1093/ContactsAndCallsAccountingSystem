using AutoMapper;
using ContactsAndCallsAccountingSystem.BLL.Interfaces;
using ContactsAndCallsAccountingSystem.BLL.Models;
using ContactsAndCallsAccountingSystem.API.InputModels;
using ContactsAndCallsAccountingSystem.API.OutputModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ContactsAndCallsAccountingSystem.Controllers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IMapper _mapper;

        public ProfilesController(IProfileService profileService, IMapper mapper)
        {
            _profileService = profileService;
            _mapper = mapper;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add new profile")]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        public async Task<ActionResult> AddProfile([FromBody] ProfileInputModel profile)
        {
            await _profileService.AddProfile(_mapper.Map<ProfileModel>(profile));

            return StatusCode(201);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update profile")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "NotFound")]
        public async Task<ActionResult> UpdateProfile([FromBody] ProfileUpdateModel profile)
        {
            var profileModel = _mapper.Map<ProfileModel>(profile);
            await _profileService.UpdateProfile(profileModel);

            return NoContent();
        }

        [HttpDelete("{phoneNumber}")]
        [SwaggerOperation(Summary = "Delete profile")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "NotFound")]
        public async Task<ActionResult> DeleteProfile(string phoneNumber)
        {
            await _profileService.DeleteProfile(phoneNumber);

            return NoContent();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all profiles")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<List<ProfileOutputModel>>> GetAllProfiles()
        {
            var profiles = _mapper.Map<List<ProfileOutputModel>>(await _profileService.GetAllProfiles());

            return profiles;
        }
    }
}
