using AutoMapper;
using CardDigitalAPI.DTOS.BuyerDTOs;
using CardDigitalAPI.Models;
using CardDigitalAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CardDigitalAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BuyerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyerResponseDTO>>> GetBuyers()
        {
            var buyers = await _unitOfWork.BuyerRepository.GetAllAsync();

            if (buyers is null)
            {
                return NotFound("Buyers não encontrado...");
            }

            var buyerResponseDTO = _mapper.Map<IEnumerable<BuyerResponseDTO>>(buyers);

            return Ok(buyerResponseDTO);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterBuyer")]
        public async Task<ActionResult<BuyerResponseDTO>> GetBuyer(int id)
        {
            var buyer = await _unitOfWork.BuyerRepository.GetAsync(b => b.BuyerId == id);

            if (buyer is null)
            {
                return NotFound("Buyer não encontrado...");
            }

            var buyerResponseDTO = _mapper.Map<BuyerResponseDTO>(buyer);

            return Ok(buyerResponseDTO);
        }

        [HttpPost]
        public async Task<ActionResult<BuyerResponseDTO>> PostBuyer(BuyerCreateDTO buyerCreateDTO)
        {
            if (buyerCreateDTO is null)
            {
                return BadRequest("Buyer não pode ser vazio");
            }

            var buyerCreate = _mapper.Map<Buyer>(buyerCreateDTO);

            var buyerCriado = _unitOfWork.BuyerRepository.Create(buyerCreate);
            await _unitOfWork.CommitAsync();

            var retornarBuyerCriado = _mapper.Map<BuyerResponseDTO>(buyerCriado);

            return new CreatedAtRouteResult("ObterBuyer", new { id = retornarBuyerCriado.BuyerId }, retornarBuyerCriado);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<BuyerResponseDTO>> PutBuyer(int id, BuyerUpdateRequestDTO buyerUpdateRequestDTO)
        {
            if (id != buyerUpdateRequestDTO.BuyerId)
            {
                return BadRequest("Id diferentes");
            }

            var buscarBuyer = await _unitOfWork.BuyerRepository.GetAsync(b => b.BuyerId == id);

            if (buscarBuyer is null)
            {
                return NotFound("Buyer não encontrado...");
            }

            var buyerDTO = _mapper.Map<Buyer>(buyerUpdateRequestDTO);

            var buyerAtualizado = _unitOfWork.BuyerRepository.Update(buyerDTO);
            await _unitOfWork.CommitAsync();

            var retornarBuyerAtualizado = _mapper.Map<BuyerResponseDTO>(buyerAtualizado);

            return Ok(retornarBuyerAtualizado);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult<BuyerResponseDTO>> DeleteBuyer(int id)
        {
            var buyer = await _unitOfWork.BuyerRepository.GetAsync(b => b.BuyerId == id);

            if (buyer is null)
            {
                return NotFound("Buyer não encontrado...");
            }

            var buyerDeletado = _unitOfWork.BuyerRepository.Delete(buyer);
            await _unitOfWork.CommitAsync();

            var buyerDeletadoDTO = _mapper.Map<BuyerResponseDTO>(buyerDeletado);
            return Ok(buyerDeletadoDTO);
        }

    }
}
