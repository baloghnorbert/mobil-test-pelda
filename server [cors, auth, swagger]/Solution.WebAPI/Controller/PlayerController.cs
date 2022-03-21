using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Solution.Core.Interfaces.IServices;
using Solution.Core.Models;
using Solution.Core.Models.Entities;
using Solution.Core.Models.Requests;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace Solution.WebAPI.Controller
{
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        [Route("/api/player/get-all")]
        [SwaggerOperation(OperationId = "getAll")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<Player>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<List<Player>> GetAll()
        {
            ServiceResponse<List<Player>> request = await _playerService.GetAllAsync();

            if(request.HasError)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.Object;
        }

        [HttpGet]
        [Route("/api/player/get/{id}")]
        [SwaggerOperation(OperationId = "get")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Player))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<Player> Get([FromRoute][Required] int id)
        {
            ServiceResponse<Player> request = await _playerService.GetAsync(id);

            if (request.HasError)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.Object;
        }

        [HttpGet]
        [Route("/api/player/page/{page}")]
        [SwaggerOperation(OperationId = "page")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<Player>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<List<Player>> Page([FromRoute][Required] int page = 0)
        {
            ServiceResponse<List<Player>> request = await _playerService.PageAsync(page);

            if (request.HasError)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.Object;
        }

        [HttpDelete]
        [Route("/api/player/delete/{id}")]
        [SwaggerOperation(OperationId = "delete")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<bool> Delete([FromRoute][Required] int id)
        {
            ServiceResponse request = await _playerService.DeleteAsync(id);

            if (request.HasError)
            {
                throw new Exception(request.ErrorMessage);
            }

            return true;
        }

        [HttpPost]
        [Route("/api/player/create")]
        [SwaggerOperation(OperationId = "create")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Player))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<Player> Create([FromBody][Required] PlayerRequest requestParam)
        {
            ServiceResponse<Player> request = await _playerService.CreateAsync(requestParam);

            if (request.HasError)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.Object;
        }

        [HttpPut]
        [Route("/api/player/update")]
        [SwaggerOperation(OperationId = "update")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Player))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<Player> Update([FromBody][Required] Player requestParam)
        {
            ServiceResponse<Player> request = await _playerService.UpdateAsync(requestParam);

            if (request.HasError)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.Object;
        }
    }
}
