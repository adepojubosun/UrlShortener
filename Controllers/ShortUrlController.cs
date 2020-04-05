using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Domain.Repository;
using UrlShortener.Domain.Persistence;
using UrlShortener.Domain.Service;
using Microsoft.Extensions.Configuration;
using UrlShortener.Domain.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UrlShortener.Resources;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("api/url")]
    public class ShortUrlController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUrlShortenerRepository _urlShortenerRepository;
        private readonly IUrlShortenerService _urlShortenerService;

        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public ShortUrlController(IUnitOfWork unitOfWork, IMapper mapper, IUrlShortenerRepository urlShortenerRepository, IUrlShortenerService urlShortenerService,  IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _urlShortenerRepository = urlShortenerRepository;
            _mapper = mapper;
            _urlShortenerService = urlShortenerService;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("retrieve/{uniqueId}")]
        public async Task<IActionResult> Retrieve([FromRoute]string uniqueId)
        {
            //Retrieve Url - Redirect to main url after retrieve from database
            try
            {
                if (uniqueId == null)
                {
                    return BadRequest(new { message = "The Link is either broken or not created." });
                }

                UrlShortenerModel model = await _urlShortenerRepository.GetLongUrlAsync(uniqueId);

                if (model == null)
                {
                    return NotFound();
                }
                await _urlShortenerService.IncrementVisitCount(uniqueId);
                var resResource = _mapper.Map<UrlShortenerModel, UrlShortenerResource>(model);

                return Ok(resResource);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpPost]
        [Route("generate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Generate([FromForm]string longUrl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Create DB row for url, store longUrl, return shorturl
                var validate = _urlShortenerService.ValidateUrl(longUrl);

                if (!validate.success)
                {
                    return BadRequest(new { message = validate.message });
                }

                string baseUrl = _configuration.GetValue<string>("BaseUrl");
                string uniqueId = _urlShortenerService.GenerateUniqueId(longUrl);
                string shortUrl = string.Format($"{baseUrl}/{uniqueId}");
                UrlShortenerModel urlShortenerModel = new UrlShortenerModel
                {
                    LongUrl = longUrl,
                    ShortUrl = shortUrl,
                    CreatedDate = DateTime.UtcNow,
                    ExpiredDate = DateTime.UtcNow.AddYears(1),
                    UniqueId = uniqueId
                };

                UrlShortenerModel newModel = await _urlShortenerRepository.CreateShortUrlAsync(urlShortenerModel);
                if (newModel != null)
                {
                    await _unitOfWork.Complete();
                }

                var returnResource = _mapper.Map<UrlShortenerModel, UrlShortenerResource>(newModel);

                return Ok(returnResource);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
} 