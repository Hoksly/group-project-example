namespace WebGroupProject;

using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

[Route("api/[controller]")]
[ApiController]
public class SumController : ControllerBase
{
    // Import the Add function from the C++ shared library
    [DllImport("lib/libadd.so", EntryPoint = "Add", CallingConvention = CallingConvention.Cdecl)]
    public static extern long Add(long a, long b);

    [HttpPost]
    public IActionResult AddNumbers([FromBody] NumbersRequest request)
    {
        long result = Add(request.Number1, request.Number2);
        return Ok(new { Sum = result });
    }
}

public class NumbersRequest
{
    public long Number1 { get; set; }
    public long Number2 { get; set; }
}

