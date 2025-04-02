using AutoMapper;
using CardDigitalAPI.Context;
using CardDigitalAPI.DTOS.ClientDTOs;
using CardDigitalAPI.Filters;
using CardDigitalAPI.Models;
using CardDigitalAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardDigitalAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientController(IUnitOfWork uof, IMapper mapper)
        {
            _unitOfWork = uof;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientResponseDTO>>> GetClients()
        {
            var clients = await _unitOfWork.ClientRepository.GetAllAsync();

            if (clients == null)
            {
                return NotFound("Clients não encontrado...");
            }

            var clientsResponseDTO = _mapper.Map<IEnumerable<ClientResponseDTO>>(clients);
            return Ok(clientsResponseDTO);

        }

        [HttpGet("{id:int:min(1)}", Name = "ObterClient")]
        public async Task<ActionResult<ClientResponseDTO>> GetClient(int id)
        {
            var client = await _unitOfWork.ClientRepository.GetAsync(c => c.ClientId == id);

            if (client == null)
            {
                return NotFound("Client não encontrado...");
            }

            var clientResponseDTO = _mapper.Map<ClientResponseDTO>(client);

            return Ok(clientResponseDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ClientResponseDTO>> PostClient(ClientCreateDTO clientCreateDTO)
        {
            if (clientCreateDTO is null)
            {
                return BadRequest("Client não pode ser vazio");
            }

            var clientCreate = _mapper.Map<Client>(clientCreateDTO);

            var clientCriado = _unitOfWork.ClientRepository.Create(clientCreate);
            await _unitOfWork.CommitAsync();

            var retornaClientCriado = _mapper.Map<ClientResponseDTO>(clientCriado);

            return new CreatedAtRouteResult("ObterClient",
                new { id = retornaClientCriado.ClientId }, retornaClientCriado);

        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<ClientResponseDTO>> PutClient(int id, ClientUpdateRequestDTO clientUpdateDto)
        {
            if (id != clientUpdateDto.ClientId)
            {
                return BadRequest("Id diferentes");
            }

            var buscarClient = await _unitOfWork.ClientRepository.GetAsync(c => c.ClientId == id);

            if (buscarClient is null)
            {
                return NotFound("Client não encontrada");
            }

            var clientDto = _mapper.Map<Client>(clientUpdateDto);

            var clientAtualizado = _unitOfWork.ClientRepository.Update(clientDto);
            await _unitOfWork.CommitAsync();

            var retornaClientAtualizadoDto = _mapper.Map<ClientResponseDTO>(clientAtualizado);

            return Ok(retornaClientAtualizadoDto);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult<ClientResponseDTO>> DeleteClient(int id)
        {
            var client = await _unitOfWork.ClientRepository.GetAsync(c => c.ClientId == id);

            if (client == null)
            {
                return NotFound("Client não encontrado...");
            }

            var clientDeletado = _unitOfWork.ClientRepository.Delete(client);
            await _unitOfWork.CommitAsync();

            var clientDeletadoDto = _mapper.Map<ClientResponseDTO>(clientDeletado);
            return Ok(clientDeletadoDto);


        }
    }
}
