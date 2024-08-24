

using HotelReservation.Application.DTOs;
using HotelReservation.Application.Validators;
using HotelReservation.Core.Entities;
using HotelReservation.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpPost("addRoom")]
    public async Task<IActionResult> AddRoom([FromBody] RoomDto roomDto)
    {
        var validator = new RoomValidator();
        var validationResult = validator.Validate(roomDto);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        Response<string> response = new Response<string>();
        var room = new Room
        {
            Price = roomDto.Price,
            FloorId = roomDto.FloorId,
            Capacity = roomDto.Capacity,
        };

        var result = await _roomService.AddRoomAsync(room);
        if (result == "OK")
        {
            response.Success = true;
            response.Message = "Room successfully added.";
            return Ok(response);
        }
        response.Success = false;
        response.Message = result;
        return StatusCode(500, response);

    }

    [HttpGet("getAllRooms")]
    public async Task<IActionResult> GetAllRooms()
    {
        var rooms = await _roomService.GetAllRoomsAsync();
        return Ok(rooms);
    }

    [HttpPut("updateRoom")]
    public async Task<IActionResult> UpdateRoom([FromBody] RoomDto roomDto)
    {

        var validator = new RoomValidator();
        var validationResult = validator.Validate(roomDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        Response<string> response = new Response<string>();
        var room = new Room
        {
            Id = roomDto.Id,
            Price = roomDto.Price,
            FloorId = roomDto.FloorId,
            Capacity = roomDto.Capacity,
        };
        var result = await _roomService.EditRoomRoomAsync(room);
        if (result == "OK")
        {
            response.Success = true;
            response.Message = "Room successfully updated.";
            return Ok(response);
        }
        response.Success = false;
        response.Message = result;
        return StatusCode(500, response);

    }

    [HttpDelete("deleteRoom/{id}")]
    public async Task<IActionResult> DeleteRoom(Guid id)
    {
        Response<string> response = new Response<string>();
        var result = await _roomService.DeleteRoomAsync(id);
        if (result == "OK")
        {
            response.Success = true;
            response.Message = "Room successfully deleted.";
            return Ok(response);
        }
        response.Success = false;
        response.Message = result;
        return StatusCode(500, response);


    }
}

