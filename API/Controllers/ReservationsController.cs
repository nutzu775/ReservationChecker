using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using API.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : BaseApiController
    {
        private readonly IReservationRepository _repo;
        public ReservationsController(IReservationRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReservationDto>>> GetReservations()
        {
            var reservations = await _repo.GetReservationsAsync();

            return reservations.Select(reservation => new ReservationDto
            {
                Id = reservation.Id,
                TotalPrice = reservation.TotalPrice,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDto>> GetReservation(int id)
        {
            var reservation = await _repo.GetReservationByIdAsync(id);

            return new ReservationDto
            {
                Id = reservation.Id,
                TotalPrice = reservation.TotalPrice,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate
            };
        }
    }
}