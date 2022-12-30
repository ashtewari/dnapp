﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dnapp.Models;
using System.Net;
using System.Net.Sockets;
using System.Net.Http.Headers;
using System.Text.Json;

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

    public async Task<IActionResult> Colors()
    {        
        using var client = new HttpClient();
        client.BaseAddress = new Uri("http://172.17.0.1:1080/");
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = await client.GetAsync("api/colors"); 
        response.EnsureSuccessStatusCode(); 
        var content = await response.Content.ReadAsStringAsync(); 
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var colors = JsonSerializer.Deserialize<IEnumerable<ColorModel>>(content, options);
        return View(colors);
    }    

    public IActionResult About()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
