using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvestExplorer.Application.Dto;
using InvestExplorer.Application.Dto.Dictionary;
using InvestExplorer.Application.Exceptions;
using InvestExplorer.Application.QueryParameters;
using InvestExplorer.Application.Services.Interfaces;
using InvestExplorer.Domain.Common;
using InvestExplorer.WebApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace InvestExplorer.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;
        private readonly AdditionalQueryParametersUtil _queryParametersUtil;


        public AssetController(IAssetService assetService, IMapper mapper)
        {
            _assetService = assetService;
            _queryParametersUtil = new AdditionalQueryParametersUtil(mapper);
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] AssetQueryParameter queryParameters)
        {
            try
            {
                queryParameters.CheckParameters();
            }
            catch (InvalidAssetQueryParametersException e)
            {
                return BadRequest(e.Message);
            }

            var assets = await _assetService.GetByParameters(queryParameters);

            return _queryParametersUtil.CheckAdditionalQueryParameters(assets, queryParameters);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            var asset = await _assetService.Get(id);
            if (asset == null)
                return NotFound();

            return Ok(asset);
        }

        [HttpGet]
        [Route("GetByIsin")]
        public async Task<IActionResult> GetByIsin([FromQuery] string isin)
        {
            var asset = await _assetService.GetByIsin(isin);
            if (asset == null)
                return NotFound();

            return Ok(asset);
        }
    }
}