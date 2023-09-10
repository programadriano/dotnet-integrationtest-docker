using dotnet_integrationtest.Entities;
using dotnet_integrationtest.Infra.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_integrationtest.Controllers;

[ApiController]
[Route("[controller]")]
public class QuoteController : ControllerBase
{

    private readonly ILogger<QuoteController> _logger;
    private readonly QuoteRepository _repository;


    public QuoteController(ILogger<QuoteController> logger, QuoteRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet(Name = "GetQuote")]
    public async Task<IEnumerable<Quote>> Get()
    {
        return await _repository.GetAllQuote();
    }
}

