using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvestExplorer.Application;
using InvestExplorer.Application.Dto;
using InvestExplorer.Application.Dto.Dictionary;
using InvestExplorer.Application.Exceptions;
using InvestExplorer.Application.QueryParameters;
using InvestExplorer.Application.Services.Interfaces;
using InvestExplorer.Domain.Common;
using InvestExplorer.WebApi.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InvestExplorer.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IssuerController : ControllerBase
    {
        private readonly IIssuerService _issuerService;
        private readonly IIssuerAssetsService _issuerAssetsService;
        private readonly AdditionalQueryParametersUtil _queryParametersUtil;

        public IssuerController(IIssuerService issuerService, IIssuerAssetsService issuerAssetsService, IMapper mapper)
        {
            _issuerService = issuerService;
            _issuerAssetsService = issuerAssetsService;
            _queryParametersUtil = new AdditionalQueryParametersUtil(mapper);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _issuerService.GetAll());
        }

        [HttpGet]
        [Route("Asset")]
        public async Task<IActionResult> GetAsset([FromQuery] IssuerAssetQueryParameters queryParameters)
        {
            try
            {
                queryParameters.CheckParameters();
            }
            catch (InvalidAssetQueryParametersException e)
            {
                return BadRequest(e.Message);
            }

            var assets = await _issuerAssetsService.GetAssets(queryParameters);

            return _queryParametersUtil.CheckAdditionalQueryParameters(assets, queryParameters);
        }
    }
}