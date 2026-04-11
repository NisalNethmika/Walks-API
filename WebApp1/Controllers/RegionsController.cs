using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Domain;
using WebApp1.CustomActionsFilter;
using WebApp1.Data;
using WebApp1.Models.DTO;
using WebApp1.Repositories;

namespace WebApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly WalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(WalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }


        // GET - api/Regions
        [HttpGet]
        [Authorize(Roles = "reader, writer")]
        public async Task<IActionResult> GetAllAsync()
        {
            var regions = await regionRepository.GetAllAsync();

            //Mapping Domain Models to DTOs with auto mapper
            var regionDTOs = mapper.Map<List<RegionDTO>>(regions);

            return Ok(regionDTOs);
        }


        // GET - api/Regions/{id}
        [HttpGet]
        [Authorize(Roles = "reader, writer")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByIDAsync([FromRoute] Guid id)
        {
            var region = await regionRepository.GetByIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            //Mapping Domain Model to DTO with Auto Mapper
            var regionDTO = mapper.Map<RegionDTO>(region);

            return Ok(regionDTO);
        }



        [HttpPost]
        [Authorize(Roles = "writer")]
        [ValidateModel]
        public async Task<IActionResult> CreateAsync([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            //Mapping DTO to Domain Model
            var region = mapper.Map<Region>(addRegionRequestDTO);

            //Save Domain model to the Database
            region = await regionRepository.CreateAsync(region);

            //Mapping Domain model back to DTO
            var regionDTO = mapper.Map<RegionDTO>(region);

            return CreatedAtAction("GetByID", new { id = region.Id }, regionDTO);
        }


        [HttpPut]
        [Authorize(Roles = "writer")]
        [ValidateModel]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDTO);

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);

            return Ok(regionDTO);
        }


        [HttpDelete]
        [Authorize(Roles = "writer")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}