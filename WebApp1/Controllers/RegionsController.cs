using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
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
        private readonly ILogger<RegionsController> logger;

        public RegionsController(WalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper, ILogger<RegionsController> logger)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }


        // GET - api/Regions
        [HttpGet]
        //[Authorize(Roles = "reader, writer")]
        public async Task<IActionResult> GetAllAsync()
        {
            try {
                logger.LogInformation("Getting all regions method invoked");

                var regions = await regionRepository.GetAllAsync();

                logger.LogInformation($"regions got from database: {JsonSerializer.Serialize(regions)}");

                //Mapping Domain Models to DTOs with auto mapper
                var regionDTOs = mapper.Map<List<RegionDTO>>(regions);

                    return Ok(regionDTOs);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while getting all regions");
                return StatusCode(500, "Internal server error");
            }
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