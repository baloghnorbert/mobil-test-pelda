using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.Core.Interfaces.IServices;
using Solution.Core.Models;
using Solution.Core.Models.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Solution.WebAPI.Controller
{
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        [Route("/api/postions/get-all")]
        [SwaggerOperation(OperationId = "getAll")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<Position>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<List<Position>> GetAll()
        {
            ServiceResponse<List<Position>> request = await _positionService.GetAllAsync();

            if (request.HasError)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.Object;
        }
    }
}
