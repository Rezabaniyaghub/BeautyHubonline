using Domain.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BeautyHubonline.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            var list = _appointmentService.GetAll();
            return View(list);
        }


    }
}
