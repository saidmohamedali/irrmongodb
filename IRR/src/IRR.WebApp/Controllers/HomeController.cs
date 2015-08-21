using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using IRRCalulation.WebApp.Models;
using IRRCalulation.WebApp.Models.Home;
using MongoDB.Bson;
using System.Linq.Expressions;

namespace IRRCalulation.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var lContext = new IRRContext();
            
           
            var filter = new BsonDocument();
            var sortIrrDefiniton= Builders<IRRDefinition>.Sort.Descending(p => p.Name);
            var sortFlows= Builders<Flow>.Sort.Descending(p => p.Date);
            var lIRRDefinitions = await lContext.IRRDefinitions.Find(filter).Sort(sortIrrDefiniton).ToListAsync();
            var lFlowsIRRDefinitions = await lContext.Flows.Find(filter).Sort(sortFlows).ToListAsync();
            var model = new IndexModel
            {
                IRRDefinitions = lIRRDefinitions,
                Flows = lFlowsIRRDefinitions
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult NewIRRDefinition()
        {
            return View(new NewIRRDefinitionModel());
        }

        [HttpPost]
        public async Task<ActionResult> NewIRRDefinition(NewIRRDefinitionModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var blogContext = new IRRContext();
            // XXX WORK HERE
            // Insert the post into the posts collection
            var l_irrdef = new IRRDefinition { Name = model.Name, Description = model.Description };

            await blogContext.IRRDefinitions.InsertOneAsync(l_irrdef);
            return RedirectToAction("IRRDefinition", new { id = l_irrdef.Id });
        }

        [HttpGet]
        public async Task<ActionResult> IRRDefinition(string id)
        {
            var lContext = new IRRContext();

            // XXX WORK HERE
            // Find the post with the given identifier
            var irrDefinition = await lContext.IRRDefinitions.Find(x => x.Id == new ObjectId(id)).SingleOrDefaultAsync();
            if (irrDefinition == null)
            {
                return RedirectToAction("Index");
            }

            var model = new IRRDefinitionModel
            {
                IRRDefinition = irrDefinition,

            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Flows()
        {
            var lContext = new IRRContext();
            var filter = new BsonDocument();
            var sortFlows = Builders<Flow>.Sort.Descending(p => p.Date);
            var lFlows= await lContext.Flows.Find(filter).Sort(sortFlows).ToListAsync();
           
            var model = new FlowsModel
            {
                Flows = lFlows

            };

            return View(model);
        }


        [HttpGet]
        public async Task<ActionResult> IRRDefinitions(string allocation = null)
        {
            var blogContext = new IRRContext();

            // XXX WORK HERE
            // Find all the posts with the given tag if it exists.
            // Otherwise, return all the posts.
            // Each of these results should be in descending order.
            string tagfilter = allocation ?? string.Empty;
            var sort = Builders<IRRDefinition>.Sort.Descending(p => p.Name);
            var irrdefs = new List<IRRDefinition>();
            if (!string.IsNullOrEmpty(tagfilter))
            {

                var tagArray = new List<String>();
                tagArray.Add(tagfilter);
               
                var filter = Builders<IRRDefinition>.Filter.Eq("allocation.name", tagArray);
                irrdefs = await blogContext.IRRDefinitions.Find(filter).Sort(sort).ToListAsync();//.Limit(10).ToListAsync();
            }
            else {
                var filter = new BsonDocument();

                irrdefs = await blogContext.IRRDefinitions.Find(filter).Sort(sort).ToListAsync();//.Limit(10).ToListAsync();
               
            }
            return View(irrdefs);


        }

        [HttpPost]
        public async Task<ActionResult> NewAllocation(NewAllocationModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("IRRDefinition", new { id = model.IRRDefinitionId });
            }

            var blogContext = new IRRContext();
            // XXX WORK HERE
            // add a comment to the post identified by model.PostId.
            // you can get the author from "this.User.Identity.Name"
            var lIRRDefinitionId = new ObjectId(model.IRRDefinitionId);
            var lAllocation = new Allocation { Name = model.Name, Description = model.Description };
            var filterIrrDef = Builders<IRRDefinition>.Filter.Eq(s => s.Id, lIRRDefinitionId);
            var update = Builders<IRRDefinition>.Update.Push(s => s.Allocations, lAllocation);


            await blogContext.IRRDefinitions.UpdateOneAsync(filterIrrDef, update);
            
            return RedirectToAction("IRRDefinition", new { id = model.IRRDefinitionId });
        }

      
        [HttpPost]
        public async Task<ActionResult> NewAncestor(NewAncestorModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("IRRDefinition", new { id = model.IRRDefinitionId });
            }

            var lContext = new IRRContext();

            var lIRRDefinitionId = new ObjectId(model.IRRDefinitionId);

            var irrDefinition = await lContext.IRRDefinitions.Find(x => x.Name == model.AncestorName).SingleOrDefaultAsync();
            var AncestorId = irrDefinition.Id;
            var filterIrrDef = Builders<IRRDefinition>.Filter.Eq(s => s.Id, lIRRDefinitionId);
            var update = Builders<IRRDefinition>.Update.Push(s => s.Ancestors, AncestorId);


            await lContext.IRRDefinitions.UpdateOneAsync(filterIrrDef, update);

            return RedirectToAction("IRRDefinition", new { id = model.IRRDefinitionId });
        }

        [HttpPost]
        public async Task<ActionResult> NewFlow(NewFlowModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Flows");
            }

            var lContext = new IRRContext();
            
            var lflow = new Flow {
                Date = model.Date,
                Allocation = model.Allocation,
                Direction = model.Direction,
                Type = model.Type,
                Value = model.Value
            };
        
            await lContext.Flows.InsertOneAsync(lflow);

            return RedirectToAction("Flows");
        }

    }
}