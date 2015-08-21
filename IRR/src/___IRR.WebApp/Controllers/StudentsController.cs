using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using Homework31.WebApp.Models;
using MongoDB.Bson;
using System.Linq.Expressions;

namespace Homework31.WebApp.Controllers
{


    public class StudentsController : Controller
    {

        public async Task<ActionResult> Index()
        {
          
            var filter = new BsonDocument();
            var SchoolContext = new IRRContext();

            // XXX WORK HERE
            // fetch a news
            var objList = await SchoolContext.Students.Find<Student>(filter).ToListAsync();


            return View("Index", objList);
        }
        public async Task<ActionResult> lowestScores()
        {

            //var filter = new BsonDocument();
            
            //var filter = Builders<Student>.Filter.AnyEq("scores.type", "homework");
            //
            var filter = Builders<Student>.Filter.ElemMatch(
                student => student.scores, score => score.type.Contains("homework"));
            var sort = Builders<Student>.Sort.Ascending(student =>student.Id);
            var SchoolContext = new IRRContext();
            var studentsAndHighestScore = new List<Student>();
            // XXX WORK HERE
            // fetch a news
            var objList = await SchoolContext.Students.Find(filter).Sort(sort).ToListAsync();
            var newstudents = new List<Student>();
            foreach (var currentStudent in objList)
            {
                var lowestscore = currentStudent.scores.First(s => s.type== "homework");
                var newstudent = new Student(currentStudent);
                foreach (var currentscore in currentStudent.scores)
                {
                    if (currentscore.type == "homework" && lowestscore.score > currentscore.score)
                        lowestscore = currentscore;
                }
                newstudent.scores.Add(lowestscore);
                newstudents.Add(newstudent);
                var filterStudent = Builders<Student>.Filter.Eq(s=> s.Id, currentStudent.Id);
                var update = Builders<Student>.Update.Pull(s => s.scores,lowestscore);
                
                //var Studentfilter = Builders<Student>.Filter.Eq( s=> s.Id, newstudent.Id);
                //var update = Builders<Score>.Update.PullAll("scores", newstudent.scores);
                var result = await SchoolContext.Students.UpdateOneAsync(filterStudent, update);


            }
            
            return View("lowestScores", newstudents);
        }
    }
}