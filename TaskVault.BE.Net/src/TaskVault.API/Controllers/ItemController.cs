using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using TaskVault.Infrastructure.Services;

namespace Architecture.Web;

[ApiController]
[Route("api/Items")]
public sealed class ItemController : ODataController
{
    private readonly IMediator _mediator;
    private readonly IMyHttpClientService _httpClientService;


    public ItemController(IMediator mediator, IMyHttpClientService httpClientService)
    {
        _mediator = mediator;
        _httpClientService = httpClientService;

    }

    [HttpPost]
    public IActionResult Add(AddItemRequest request) => _mediator.HandleAsync<AddItemRequest, long>(request).ApiResult();

    [HttpDelete("{id:long}")]
    public IActionResult Delete(long id) => _mediator.HandleAsync(new DeleteItemRequest(id)).ApiResult();


    [HttpGet("{id:long}")]
    public IActionResult Get(long id) => _mediator.HandleAsync<GetItemRequest, ItemModel>(new GetItemRequest(id)).ApiResult();

    [HttpGet("{id:long}/details")]
    public async Task<IActionResult> GetDetails(long id)
    {
        var item = await _mediator.HandleAsync<GetItemRequest, ItemModel>(new GetItemRequest(id));
        //TODO: check value

        try
        {
            string apiUrl = "/lorem";

            string response = await _httpClientService.GetApiResponseAsync(apiUrl);

            item.Value.Details = response;
        }
        catch (Exception e)
        {
            // TODO: add logging here
            Console.WriteLine(e);
        }


        return item.ApiResult();
    }


    [HttpGet("grid")]
    public IActionResult Grid([FromQuery] GridItemRequest request) => _mediator.HandleAsync<GridItemRequest, Grid<ItemModel>>(request).ApiResult();

    [HttpGet]
    [EnableQuery]
    public async Task<IActionResult> List() => (await _mediator.HandleAsync<ListItemRequest, IEnumerable<ItemModel>>(new ListItemRequest())).ApiResult();


    [HttpPut("{id:long}")]
    public IActionResult Update(long id, UpdateItemRequest request)
    {
        request.Id = id;

        return _mediator.HandleAsync(request).ApiResult();
    }
}
