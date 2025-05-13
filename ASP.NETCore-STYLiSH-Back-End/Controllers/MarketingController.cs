using Microsoft.AspNetCore.Mvc;
using ASP.NETCore_STYLiSH_Back_End.Data;
using ASP.NETCore_STYLiSH_Back_End.Models;
using Microsoft.EntityFrameworkCore;
using STYLiSH.Types;

namespace ASP.NETCore_STYLiSH_Back_End.Controllers;

[ApiController]
[Route("api/1.0/marketing")]
public class MarketingController(StylishContext context) : ControllerBase
{
    private readonly StylishContext _context = context;

    [HttpGet("campaigns", Name = "GetCampaigns")]
    public async Task<ActionResult<MarketingCampaigns>> GetCampaigns()
    {
        #region campaigns
        Campaign[] _campaign = await _context.Campaigns.ToArrayAsync();

        List<CarouselDetails> _data = new();

        for (int i = 0; i < _campaign.Length; i++)
        {
            _data.Add(new CarouselDetails { id = i, product_id = _campaign[i].ProductId, picture = _campaign[i].Picture!, story = _campaign[i].Story! });
        }

        return Ok(new MarketingCampaigns() { data = _data.ToArray() });
        #endregion

    }
}