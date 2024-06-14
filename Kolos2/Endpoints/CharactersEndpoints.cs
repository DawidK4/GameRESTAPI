using Kolos2.Exceptions;
using Kolos2.RequestModels;
using Kolos2.Services;

namespace Kolos2.Endpoints;

public static class CharactersEndpoints
{
    public static void RegisterCharactersEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/characters");

        group.MapGet("{id:int}", async (int id, ICharacterService service) =>
        {
            try
            {
                return Results.Ok(await service.GetCharactersWithTitlesAndBackpackDataAsync(id));
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        group.MapPost("{id:int}/backpackslots", async (int id, AddItemsToTheEquipmentRequestModel data, ICharacterService service) =>
        {
            try
            {
                var result = await service.AddBackpackDataAsync(id, data);
                return Results.Ok(result);
            }
            catch (KeyNotFoundException e)
            {
                return Results.NotFound(new { Message = e.Message });
            }
            catch (InvalidOperationException e)
            {
                return Results.BadRequest(new { Message = e.Message });
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(new { Message = e.Message });
            }

        });
    }
}