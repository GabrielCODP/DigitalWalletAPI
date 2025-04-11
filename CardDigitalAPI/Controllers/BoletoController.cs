using AutoMapper;
using CardDigitalAPI.DTOS.BoletoDTOs;
using CardDigitalAPI.Models;
using CardDigitalAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CardDigitalAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BoletoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoletoResponseDTO>>> GetBoletos()
        {
            var boletos = await _unitOfWork.BoletoRepository.GetAllAsync();

            if (boletos is null)
            {
                return NotFound("Boletos não encontrado");
            }

            var boletosDtos = _mapper.Map<IEnumerable<BoletoResponseDTO>>(boletos);

            return Ok(boletosDtos);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterBoleto")]
        public async Task<ActionResult<BoletoResponseDTO>> GetBoleto(int id)
        {
            var boleto = await _unitOfWork.BoletoRepository.GetAsync(b => b.BoletoId == id);

            if (boleto is null)
            {
                return NotFound("Boleto não encontrado");
            }

            var boletoDtoResponse = _mapper.Map<BoletoResponseDTO>(boleto);

            return Ok(boletoDtoResponse);
        }

        [HttpPost]
        public async Task<ActionResult<BoletoResponseDTO>> PostBoleto(BoletoCreateDTO boletoCreateDTO)
        {
            var paymentId = await _unitOfWork.PaymentRepository.GetAsync(p => p.PaymentId == boletoCreateDTO.PaymentId);

            if (paymentId is null)
            {
                return NotFound("Payment não existe, boleto não pode ser gerado");
            }
            if (paymentId.BoletoId != null)
            {
                return BadRequest("Este pagamento já possui um boleto associado.");
            }
            if (paymentId.CardId != null)
            {
                return BadRequest("Este pagamento já possui um boleto associado.");
            }

            var boletoDtoCreate = _mapper.Map<Boleto>(boletoCreateDTO);

            var boletoCriado = _unitOfWork.BoletoRepository.Create(boletoDtoCreate);
            await _unitOfWork.CommitAsync();

            paymentId.Type = "Boleto";
            paymentId.BoletoId = boletoCriado.BoletoId;

            await _unitOfWork.CommitAsync();

            var boletoCriadoDtoResponse = _mapper.Map<BoletoResponseDTO>(boletoCriado);
            return new CreatedAtRouteResult("ObterBoleto", new { id = boletoCriadoDtoResponse.BoletoId }, boletoCriadoDtoResponse);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult<BoletoResponseDTO>> DeleteBoleto(int id)
        {
            var boleto = await _unitOfWork.BoletoRepository.GetAsync(b => b.BoletoId == id);

            if (boleto is null)
            {
                return NotFound("Boleto não encontrado");
            }

            var boletoDeletado = _unitOfWork.BoletoRepository.Delete(boleto);
            await _unitOfWork.CommitAsync();

            var boletoDeletadoDto = _mapper.Map<BoletoResponseDTO>(boletoDeletado);

            return boletoDeletadoDto;
        }
    }
}
