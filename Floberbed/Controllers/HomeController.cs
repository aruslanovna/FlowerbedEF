
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Floberbed.Models;
using Microsoft.EntityFrameworkCore;
using Infrastructure;

namespace Floberbed.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FlowerbedDbContext _unitOfWork;
        

        public HomeController(ILogger<HomeController> logger, FlowerbedDbContext context)
        {
            _unitOfWork = context;
            _logger = logger;
        }

      
      
    }
}
