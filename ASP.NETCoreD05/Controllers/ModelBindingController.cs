using ASP.NETCoreD05.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreD05.Controllers
{
    public class ModelBindingController : Controller
    {
        /*------------------------------------------------------------------*/
        // Model Binding is the process of
        // mapping data from HTTP requests to action method
        // parameters in ASP.NET Core MVC. It allows you to
        // work with strongly-typed objects
        // instead of manually parsing request data.
        //public IActionResult Index()
        //{
        //    var age = HttpContext.Request.Query["age"].ToString();
        //    return View();
        //}
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/PrimitiveModelBinding1?id=42
        // ~/ModelBinding/PrimitiveModelBinding1/1
        public IActionResult PrimitiveModelBinding1(int id)
        {
            // id != 0 
            // string != null
            // Guid != Guid.Empty;
            // To Do Check If Found in DB
            return Content($"Received Id: {id}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/PrimitiveModelBinding2?empId=42
        // ~/ModelBinding/PrimitiveModelBinding2/1 XXXXXXXXX
        public IActionResult PrimitiveModelBinding2(int empId)
        {
            return Content($"Received Id: {empId}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/PrimitiveModelBinding3?empId=42
        public IActionResult PrimitiveModelBinding3(int empId, string name)
        {
            return Content($"Received Id: {empId}, Name: {name}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/ArrayModelBinding4?empid=45&colors[1]=red&colors[0]=blue
        // ~/ModelBinding/ArrayModelBinding4?empid=45&colors=red&colors=blue
        public IActionResult ArrayModelBinding4(int empId, string[] colors)
        {
            return Content($"Received Id: {empId}, Colors: {string.Join(", ", colors)}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/CollectionsModelBinding5?phones[ahmed]=12&phones[ali]=456
        public IActionResult CollectionsModelBinding5(Dictionary<string, int> phones)
        {
            return Content($"Received Phones: {string.Join(", ", phones.Select(p => $"{p.Key}: {p.Value}"))}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/ComplexModelBinding5?id=5&name=HR
        public IActionResult ComplexModelBinding5(Department department)
        {
            return Content($"Received Department: {department.Name}, Location: {department.Id}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/ComplexModelBinding6?id=5
        public IActionResult ComplexModelBinding6(Department department)
        {
            return Content($"Received Department: {department.Name}, Location: {department.Id}");
        }
        /*------------------------------------------------------------------*/

        // ~/ModelBinding/ComplexModelBinding7?id=5&name=HR&employees[0].name=Ahmed
        public IActionResult ComplexModelBinding7(Department department)
        {
            return Content($"Received Department: {department.Name}, Location: {department.Id}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/ComplexModelBinding8?id=5&name=HR&employees[0].name=Ahmed
        public IActionResult ComplexModelBinding8([Bind(include:"Id, Name")] Department department)
        {
            return Content($"Received Department: {department.Name}, Location: {department.Id}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/PrimitiveModelBinding9?id=42
        // ~/ModelBinding/PrimitiveModelBinding9/1
        public IActionResult PrimitiveModelBinding9([FromRoute] int id)
        {
            return Content($"Received Id: {id}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/PrimitiveModelBinding10?id=42
        // ~/ModelBinding/PrimitiveModelBinding10/1
        public IActionResult PrimitiveModelBinding10([FromQuery] int id)
        {
            return Content($"Received Id: {id}");
        }
        /*------------------------------------------------------------------*/
    }
}
