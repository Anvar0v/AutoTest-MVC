using Microsoft.AspNetCore.Mvc;
using Web_App.Models;
using Web_App.Services;

namespace Web_App.Controllers;
public class LoginController : Controller
{
    public IActionResult Index()
    {
        if(HttpContext.Request.Cookies.ContainsKey("UserIndex"))
        {
            var userIndex = int.Parse(HttpContext.Request.Cookies["UserIndex"]);

            //here we are checking weather user with such index exists
            //for example there are 5 people registered and if index of the user is gonna be 6 or 7 ..., that user should be registered
            if (UsersRepository.Users.Count <= userIndex)
            {
                return RedirectToAction("LoginUser");
            }

            var user  = UsersRepository.Users[userIndex];
            ViewBag.Exists = true;
            ViewBag.User = user;
        }
        else
        {
            return RedirectToAction("LoginUser");
        }
        return View();
    }

    public IActionResult RegisterUser(User user)
    {
        UsersRepository.Users.Add(user);
        //here we are getting the index of  user and appending it to the cookies;
        var userIndex = UsersRepository.Users.IndexOf(user);
        HttpContext.Response.Cookies.Append("UserIndex", userIndex.ToString());
        return RedirectToAction("Index");
    }

    public IActionResult LoginUser()
    {
        return View();
    }

    public IActionResult LoginNewUser()
    {
        return View();
    }

    public IActionResult UserSignin(User user)
    {
        if(UsersRepository.Users.Any(u => u.PhoneNumber == user.PhoneNumber))
        {
            var _user = UsersRepository.Users.First(u => u.PhoneNumber == user.PhoneNumber);
            if(user.Password == _user.Password)
            {
                var userIndex = UsersRepository.Users.IndexOf(_user);
                HttpContext.Response.Cookies.Append("UserIndex", userIndex.ToString());
                return RedirectToAction("Index");
            }
        }
        return RedirectToAction("LoginUser");
    }

}