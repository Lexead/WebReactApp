using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebReactApp.Server.Models;
using WebReactApp.Server.Repositories.IRepositories;
using WebReactApp.Server.ViewModels;

namespace WebReactApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderCreateDTO orderDto)
        {
            var claimsIdentity = (ClaimsIdentity?)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var order = mapper.Map<Order>(orderDto);
            order.UserId = userId;

            unitOfWork.OrderRepository.Add(order);
            await unitOfWork.Save();

            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var claimsIdentity = (ClaimsIdentity?)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var orders = await unitOfWork.OrderRepository.GetAll(o => o.UserId == userId);
            var ordersDto = mapper.Map<List<OrderViewDTO>>(orders);

            return Ok(ordersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var order = await unitOfWork.OrderRepository.Get(o => o.Id == id);

            if (order == null)
                return NotFound();

            var orderDto = mapper.Map<OrderViewDTO>(order);

            return Ok(orderDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            var order = await unitOfWork.OrderRepository.Get(o => o.Id == id);

            if (order == null)
                return NotFound();

            unitOfWork.OrderRepository.Remove(order);
            await unitOfWork.Save();

            return NoContent();
        }
    }
}
