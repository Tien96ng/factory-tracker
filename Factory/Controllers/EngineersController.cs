using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;
    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Engineer> model = _db.Engineers.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer, int machineId)
    {
      bool matches = _db.EngineerMachine.Any(x => x.EngineerId == engineer.EngineerId && x.MachineId == machineId);
      if(!matches) {
        _db.Engineers.Add(engineer);
        _db.SaveChanges();
        if(machineId != 0)
        {
          _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = engineer.EngineerId, MachineId = machineId });
        }
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int engineerId)
    {
      var thisEngineer = _db.Engineers
        .Include(engineer => engineer.JoinEntities)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(engineer => engineer.EngineerId == engineerId);

      return View(thisEngineer);
    }

    public ActionResult Edit(int engineerId)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == engineerId);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer, int machineId)
    {
      if(machineId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = engineer.EngineerId, MachineId = machineId});
      }

      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Delete(int engineerId)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == engineerId);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int engineerId)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == engineerId);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddPatient(int engineerId)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == engineerId);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddPatient(Engineer engineer, int machineId)
    {
      bool matches = _db.EngineerMachine.Any(x => x.EngineerId == engineer.EngineerId && x.MachineId == machineId);
      if(!matches)
      {
        if(machineId != 0)
        {
          _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = engineer.EngineerId, MachineId = machineId });
        }
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeletePatient(int joinId)
    {
      var joinEntry = _db.EngineerMachine.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}