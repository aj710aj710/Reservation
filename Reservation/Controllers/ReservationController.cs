using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation.Entity;
using Reservation.Dto;

namespace Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationDbContext dbContext;
        public ReservationController(ReservationDbContext dbcontext)
        {
            this.dbContext = dbcontext;
        }


        [HttpGet]
        public IActionResult GetReservations()
        {
            var reservations = dbContext.Reservations.ToList();
            return Ok(reservations);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IActionResult GetReservationByaId(int id)
        {
            var entity = dbContext.Reservations.FirstOrDefault(p => p.Id==id);
            ReservationDto result = new ReservationDto();
            result.Id = entity.Id;
            return Ok(result);
             
        }


        //[HttpPost]

        //public IActionResutt CreateReservation(ReservationDto dto)
        //// Map dto to entity
        //var entity = new Reservation();
        //entity.ld = e;
        //entity.CustomerName = CustonerNane;
        //entity.RoomNumber = dto.RoomNunber;
        //entity.ChecklnDate= dto.ChecklnDate ;
        //entity.CheckOutDate= dto.CheckOutDate;
        ////Add to table
        //dbContext.Reservation.Add(entity) ;
        //dbContext.SaveChanges( ) ;
        //return Ok();
    }

}



//namespace Reservation.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ReservationsController : ControllerBase
//    {
//        private readonly ReservationDbContext dbContext;

//        public ReservationsController(ReservationDbContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }

       // GET: api/Reservations
//      [HttpGet]
//        public IActionResult GetReservations()
//        {
//            var reservations = dbContext.Reservations.ToList();
//            return Ok(reservations);
//        }

//        // DELETE: api/Reservations/5
//        [HttpDelete("{id}")]
//        public IActionResult DeleteReservation(int id)
//        {
//            var reservation = dbContext.Reservations.Find(id);

//            if (reservation == null)
//            {
//                return NotFound();
//            }

//            dbContext.Reservations.Remove(reservation);
//            dbContext.SaveChanges();

//            return Ok("Reservation deleted successfully");
//        }
//    }
//}