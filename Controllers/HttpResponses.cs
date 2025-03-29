using Microsoft.AspNetCore.Mvc;

namespace HelloSioux.API.Controllers
{
  public class HttpResponses
  {
    public static IActionResult OkResponse(object result)
    {
      return new OkObjectResult(result);
    }
    public static IActionResult CreatedResponse(object result, string location)
    {
      return new CreatedResult(location, result);
    }
    public static IActionResult NoContentResponse()
    {
      return new NoContentResult();
    }
    public static IActionResult BadRequestResponse(string message)
    {
      return new BadRequestObjectResult(message);
    }
    public static IActionResult NotFoundResponse(string message)
    {
      return new NotFoundObjectResult(message);
    }
    public static IActionResult UnauthorizedResponse(string message)
    {
      return new UnauthorizedObjectResult(message);
    }
    public static IActionResult ForbiddenResponse(string message)
    {
      return new ForbidResult(message);
    }
    public static IActionResult ConflictResponse(string message)
    {
      return new ConflictObjectResult(message);
    }
    public static IActionResult InternalServerErrorResponse(string message)
    {
      return new ObjectResult(message) { StatusCode = StatusCodes.Status500InternalServerError };
    }
    public static IActionResult UnprocessableEntityResponse(string message)
    {
      return new UnprocessableEntityObjectResult(message);
    }
  }
}