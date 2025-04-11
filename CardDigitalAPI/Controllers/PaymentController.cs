using AutoMapper;
using CardDigitalAPI.DTOS.PaymentDTOs;
using CardDigitalAPI.Models;
using CardDigitalAPI.Repositories;
using CardDigitalAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace CardDigitalAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentResponseDTO>>> GetPayments()
        {
            var payments = await _unitOfWork.PaymentRepository.GetAllAsync();

            if (payments is null)
            {
                return NotFound("Payments não encontrado");
            }

            var paymentsDtoResponse = _mapper.Map<IEnumerable<PaymentResponseDTO>>(payments);

            return Ok(paymentsDtoResponse);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterPayment")]
        public async Task<ActionResult<PaymentResponseDTO>> GetPayment(int id)
        {
            var payment = await _unitOfWork.PaymentRepository.GetAsync(p => p.PaymentId == id);
            if (payment is null)
            {
                return NotFound("Payment não encontrado");
            }

            var paymentDtoResposne = _mapper.Map<PaymentResponseDTO>(payment);

            return Ok(paymentDtoResposne);
        }

        [HttpPost]
        public async Task<ActionResult<PaymentResponseDTO>> PostPayment(PaymentCreateDTO paymentCreateDTO)
        {
            if (paymentCreateDTO is null)
            {
                return BadRequest("Payment não pode ser vazio");
            }

            int buyerId = paymentCreateDTO.BuyerId;

            var buscarBuyer = await _unitOfWork.BuyerRepository.GetAsync(b => b.BuyerId == buyerId);

            if (buscarBuyer is null)
            {
                return BadRequest("Buyer não existe para realizar o pagamento");
            }

            var paymentDtoCreate = _mapper.Map<Payment>(paymentCreateDTO);

            var iniciarPayment = _unitOfWork.PaymentRepository.Create(paymentDtoCreate);
            await _unitOfWork.CommitAsync();

            var retornaPaymentCreate = _mapper.Map<PaymentResponseDTO>(iniciarPayment);

            return new CreatedAtRouteResult("ObterPayment", new { id = retornaPaymentCreate.PaymentId }, retornaPaymentCreate);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<PaymentResponseDTO>> PutPayment(int id, PaymentUpdateRequestDTO paymentUpdateRequestDTO)
        {
            if (id != paymentUpdateRequestDTO.PaymentId)
            {
                return BadRequest("Id diferentes");
            }

            var buscarPayment = await _unitOfWork.PaymentRepository.GetAsync(p => p.PaymentId == id);
            if (buscarPayment is null)
            {
                return NotFound("Payment não encontrado...");
            }

            int buyerId = paymentUpdateRequestDTO.BuyerId;
            var buscarBuyer = await _unitOfWork.BuyerRepository.GetAsync(b => b.BuyerId == buyerId);

            if (buscarBuyer is null)
            {
                return BadRequest("Buyer não existe para realizar a atualização");
            }

            var paymentAtualizar = _mapper.Map<Payment>(paymentUpdateRequestDTO);

            var paymentAtualizado = _unitOfWork.PaymentRepository.Update(paymentAtualizar);
            await _unitOfWork.CommitAsync();

            var paymentAtualizadoDto = _mapper.Map<PaymentResponseDTO>(paymentAtualizado);

            return Ok(paymentAtualizadoDto);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult<PaymentResponseDTO>> DeletePayment(int id)
        {
            var payment = await _unitOfWork.PaymentRepository.GetAsync(p => p.PaymentId == id);
            if (payment is null)
            {
                return NotFound("Payment não encontrado");
            }
            var paymentDelete = _unitOfWork.PaymentRepository.Delete(payment);
            await _unitOfWork.CommitAsync();

            var paymentDeleteDTO = _mapper.Map<PaymentResponseDTO>(paymentDelete);

            return Ok(paymentDeleteDTO);
        }

    }
}
