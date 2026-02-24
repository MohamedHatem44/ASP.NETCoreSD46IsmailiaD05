using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreD05.Controllers
{
    public class StateManagementController : Controller
    {
        /*------------------------------------------------------------------*/
        #region TempData
        //// TempData is used to store data that needs to
        //// persist across a single redirect. It is ideal for passing messages
        //// or small pieces of data between actions.
        //public IActionResult SetTempData()
        //{
        //    TempData["Message"] = "Hello from TempData";
        //    return Content("TempData Saved");
        //}

        //public IActionResult GetTempData1()
        //{
        //    //// Normal Read
        //    //string? message = TempData["Message"]?.ToString();
        //    //return Content(message ?? "No message in TempData 1");

        //    //// Peek Read (does not remove the data from TempData)
        //    //string? message = TempData.Peek("Message")?.ToString();
        //    //return Content(message ?? "No message in TempData 1");

        //    // Keep Read (resets the data in TempData so it can be read again)
        //    string? keepMessage = TempData["Message"]?.ToString();
        //    //TempData.Keep(); // Keep all data in TempData
        //    TempData.Keep("Message"); // Keep only the "Message" key in TempData
        //    return Content(keepMessage ?? "No message in TempData 1");
        //}

        //public IActionResult GetTempData2()
        //{
        //    // Normal Read (removes the data from TempData)
        //    string? message = TempData["Message"]?.ToString();
        //    return Content(message ?? "No message in TempData 2");
        //}
        #endregion
        /*------------------------------------------------------------------*/
        #region Session => Store Session
        //// Valid Until Session Not Expire
        //public IActionResult SetSession()
        //{
        //    HttpContext.Session.SetString("Message", "Hello from Session");
        //    HttpContext.Session.SetInt32("Age", 42);
        //    return Content("Session Saved");
        //}

        //public IActionResult GetSession()
        //{
        //    string? message = HttpContext.Session.GetString("Message");
        //    int? age = HttpContext.Session.GetInt32("Age");
        //    return Content($"Message: {message}, Age: {age}");
        //}
        #endregion
        /*------------------------------------------------------------------*/
        #region Cookies
        //public IActionResult SetCookie()
        //{
        //    CookieOptions cookieOptions = new CookieOptions
        //    {
        //        Expires = DateTimeOffset.UtcNow.AddHours(10),
        //        HttpOnly = true,
        //        IsEssential = true
        //    };

        //    Response.Cookies.Append("Message", "Hello From Cookie", cookieOptions);
        //    Response.Cookies.Append("Age", "30", cookieOptions);
        //    return Content("Cookie Saved");
        //}

        //public IActionResult GetCookie()
        //{
        //    string? message = Request.Cookies["Message"];
        //    string? age = Request.Cookies["Age"];
        //    return Content($"Message: {message}, Age: {age}");
        //}
        #endregion
        /*------------------------------------------------------------------*/
    }
}
