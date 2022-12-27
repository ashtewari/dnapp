using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dnapp.Models;
using System.Net;
using System.Net.Sockets;

namespace dnapp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> IndexAsync()
    {
        var hostName = Dns.GetHostName();
        var ip = Dns.GetHostEntry(hostName).AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
        var ips = await Dns.GetHostAddressesAsync(hostName);

        return View(new IndexModel() { HostName = hostName, IpAddress = ip.ToString() });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
