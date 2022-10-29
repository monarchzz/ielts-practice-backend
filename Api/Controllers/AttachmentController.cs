using Api.Dtos.Attachment;
using Application.Attachments.Commands.AudioUpload;
using Application.Attachments.Commands.ImageUpload;
using Application.Attachments.Common;
using Application.Attachments.Queries.GetAttachment;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
public class AttachmentController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AttachmentController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("upload/image")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateImageAttachment([FromForm] CreateAttachmentDto dto)
    {
        var command = new ImageUploadCommand()
        {
            File = dto.File,
        };
        var result = await _mediator.Send(command);
        return result.Match(success => CreatedAtRoute(nameof(GetAttachmentById), new { id = success.Id }, null),
            Problem);
    }

    [HttpPost("upload/audio")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAudioAttachment([FromForm] CreateAttachmentDto dto)
    {
        var command = new AudioUploadCommand()
        {
            File = dto.File,
        };
        var result = await _mediator.Send(command);
        return result.Match(success => CreatedAtRoute(nameof(GetAttachmentById), new { id = success.Id }, null),
            Problem);
    }

    [HttpGet("{id:guid}", Name = nameof(GetAttachmentById))]
    [ProducesResponseType(typeof(AttachmentDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAttachmentById(Guid id)
    {
        var query = new GetAttachmentQuery()
        {
            Id = id
        };
        var attachmentResult = await _mediator.Send(query);

        return attachmentResult.Match(
            success => Ok(_mapper.Map<AttachmentResult>(success)),
            Problem);
    }
}