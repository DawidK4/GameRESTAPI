using Kolos2.Contexts;
using Kolos2.Exceptions;
using Kolos2.Models;
using Kolos2.RequestModels;
using Kolos2.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Services;

public interface ICharacterService
{
    Task<GetCharacterWithBackpackSlotsModel> GetCharactersWithTitlesAndBackpackDataAsync(int characterId);
    Task<IEnumerable<GetBackpackModel>> AddBackpackDataAsync(int characterId, AddItemsToTheEquipmentRequestModel data);
}

public class CharacterService(DatabaseContext context) : ICharacterService
{
    public async Task<GetCharacterWithBackpackSlotsModel> GetCharactersWithTitlesAndBackpackDataAsync(int characterId)
    {
        var backpacks = await context.BackpackSlots
            .Where(b => b.FK_character == characterId)
            .Select(b => new GetBackpackSlotsModel
            {
                slotId = b.PK,
                itemName = b.Item.name,
                itemWeight = b.Item.weig
            }).ToListAsync();

        var titles = await context.CharactersTitles
            .Where(t => t.FKCharact == characterId)
            .Select(t => new GetTitleModel
            {
                title = t.Title.nam,
                aquiredAt = t.AquireAt.ToString()
            }).ToListAsync();

        var character = await context.Characters
            .Where(c => c.PK == characterId)
            .Select(c => new GetCharacterWithBackpackSlotsModel
            {
                firstName = c.FirstName,
                lastName = c.LastName,
                currentWeight = c.CurrentWeig,
                maxWeight = c.MaxWeight,
                money = c.Money,
                backpackSlots = backpacks,
                titles = titles
            }).FirstOrDefaultAsync();

        if (character is null)
        {
            throw new NotFoundException($"There is no character with id:{characterId} in the database!");
        }

        return character;
    }
    
    public async Task<IEnumerable<GetBackpackModel>> AddBackpackDataAsync(int characterId, AddItemsToTheEquipmentRequestModel data)
    {
        var items = await context.Items
            .Where(i => data.itemKeys.Contains(i.PK))
            .ToListAsync();

        if (items.Count != data.itemKeys.Count())
        {
            throw new NotFoundException("One or more items not found.");
        }
        
        var character = await context.Characters
            .Where(c => c.PK == characterId)
            .FirstOrDefaultAsync();
        
        if (character == null)
        {
            throw new KeyNotFoundException("Character not found.");
        }
        
        var totalWeightToAdd = items.Sum(i => i.weig);
        if (character.CurrentWeig + totalWeightToAdd > character.MaxWeight)
        {
            throw new InvalidOperationException("Character does not have enough weight capacity.");
        }
        
        var addedItems = new List<GetBackpackModel>();

        foreach (var item in items)
        {
            var backpackSlot = new BackpackSlots
            {
                FK_character = characterId,
                FK_item = item.PK
            };

            context.BackpackSlots.Add(backpackSlot);
            await context.SaveChangesAsync();

            addedItems.Add(new GetBackpackModel
            {
                slotId = backpackSlot.PK,
                itemId = item.PK,
                characterId = characterId
            });

            character.CurrentWeig += item.weig;
            context.Characters.Update(character);
            await context.SaveChangesAsync();
        }

        return addedItems;
    }
}