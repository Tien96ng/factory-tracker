using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Machine> model = _db.Machines.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine, int engineerId)
    {
      bool matches = _db.EngineerMachine.Any(x => x.EngineerId== engineerId && x.MachineId == machine.MachineId);
      if(!matches)
      {
        _db.Machines.Add(machine);
        _db.SaveChanges();
        if (engineerId != 0)
        {
          _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = engineerId, MachineId = machine.MachineId });
        }
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int machineId)
    {
      var thisMachine = _db.Machines
        .Include(machine => machine.JoinEntities)
        .ThenInclude(join => join.Engineer)
        .FirstOrDefault(machine => machine.MachineId == machineId);

      return View(thisMachine);
    }

    public ActionResult Edit(int machineId)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == machineId);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine, int engineerId)
    {
      if(engineerId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = engineerId, MachineId = machine.MachineId });
      }
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete (int machineId)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == machineId);
      return View(thisMachine);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int machineId)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == machineId);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddDoctor(int machineId)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == machineId);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult AddDoctor(Machine machine, int engineerId)
    {
      bool matches = _db.EngineerMachine.Any(x => x.EngineerId == engineerId && x.MachineId == machine.MachineId);
      if(!matches)
      {
        if(engineerId != 0)
        {
          _db.EngineerMachine.Add(new EngineerMachine() { MachineId = machine.MachineId, EngineerId = engineerId });
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteDoctor(int joinId)
    {
      var joinEntry = _db.EngineerMachine.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}