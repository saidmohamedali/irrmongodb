using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Homework31.WebApp.Models
{
    public class IRRDefinition
    {
        //{ "_id" : 2, "name" : "Corliss Zuk", 
        //"scores" : [ { "type" : "exam", "score" : 67.03077096065002 }, { "type" : "quiz", "score" : 6.301851677835235 }, { "type" : "homework", "score" : 20.18160621941858 }, { "score" : 66.28344683278382, "type" : "homework" } ] }

        public Object Id { get; set; }
        public string name { get; set; }
        public ICollection<Allocation> allocations { get; set; }

        public IRRDefinition(Student student, string scoretypetohide= "homework")
        {
            Id = student.Id;
            name = student.name;
            scores = new List<Score>();
            //foreach (var score in student.scores)
            //{
            //    if(score.type == scoretypetohide)
            //        scores.Add(score);
            //}
           
        }
        

    }

   
}