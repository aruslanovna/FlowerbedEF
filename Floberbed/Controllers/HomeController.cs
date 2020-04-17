
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

        //public async Task<IActionResult> Index()
        //{
        //   var result = _unitOfWork.Plantations.Select(x=>new Task1 { Name = x.Name}).ToList();
        //    return View(result);
        //}

        //public IActionResult PlantationData(int id)
        //{



        //    var data = from p in _unitOfWork.plantationFlowers
        //               join flower in _unitOfWork.Flowers on p.FlowerId equals flower.Id
        //               join plantation in _unitOfWork.Plantations on p.PlantationId equals plantation.Id
        //               select new Task2
        //               {
        //                   Id = p.Id,
        //                   Name = flower.Name,
        //                   Address = plantation.Address,
        //                   Amount = p.Amount

        //               };
            
           
        //    return View(data.ToList());
        //}
        //public IActionResult FlowerDataTask3()
        //{

        //    var data = _unitOfWork.Flowers
        //        .Include(x => x.PlantationFlowers)
        //        .Select(x => new Task3
        //        {
        //            Id=x.Id,
        //            Name=x.Name,
        //            Plantationnumber = x.PlantationFlowers.Count()
        //        }).ToList();


        //    return View(data);
        //}
        //public IActionResult FlowerDataTask4()
        //{
        //    int number = 1000;
        //    var data = _unitOfWork.Flowers
        //        .Include(x => x.PlantationFlowers)
        //        .Select(x => new Task3
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //            Plantationnumber = x.PlantationFlowers.Where(y=>y.Amount>=number).Count()
        //        }).ToList();


        //    return View(data);
        //}
        //public IActionResult SupplyDataTask5()
        //{
        //    //int number = 1000;
        //    //var data = 
        //    //    from flower in _unitOfWork.Flowers
        //    //    join plantationFlower in _unitOfWork.plantationFlowers on flower.Id equals plantationFlower.FlowerId
        //    //    join plantation in _unitOfWork.Plantations on plantationFlower.PlantationId equals plantation.Id
        //    //    join supplyFlower in _unitOfWork.SupplyFlowers on flower.Id equals supplyFlower.FlowerId
        //    //    join supply in _unitOfWork.Supplies on supplyFlower.SupplyId equals supply.Id

        //    //    select new Task5
        //    //    {


        //    //        Id = flower.Id,
        //    //        Name =flower.Name,
        //    //        FlowerAmount = supplyFlower.Amount
        //    //    }
        //    //    group flower by supply.Plantation

        //    //var data = _unitOfWork.Flowers
        //    //    .Include(x=>x.SupplyFlowers)
        //    //    .Include(x => x.PlantationFlowers)

        //    //    .Select(x=> new Task5
        //    //    {
        //    //        Id = x.Id,
        //    //        Name = x.Name,
        //    //        FlowerAmount = x.SupplyFlowers.Amount
        //    //    }




        //    //return View(data.ToList());
        //}
      
    }
}
