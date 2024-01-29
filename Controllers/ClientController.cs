using ApiIntelligenceEnergy.DataContext;
using ApiIntelligenceEnergy.Models;
using ApiIntelligenceEnergy.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiIntelligenceEnergy.Controllers;

[ApiController]
[Route("api/client")]
public class ClientController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<ClientModel>>> GetAllClients()
    {
        List<ClientModel> clients = await _context.ClientModel.ToListAsync();

        if (clients == null || clients.Count == 0)
        {
            return NotFound();
        }

        return clients;
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ClientModel>> GetClient(Guid Id)
    {
        var client = await _context.ClientModel.FindAsync(Id);

        if (client == null)
        {
            return NotFound();
        }

        return client;
    }

    [HttpPost]
    public async Task<ActionResult<ClientModel>> PostClient(ClientModel clientModel)
    {
        if (_context.ClientModel.Any(c => c.Cnpj == clientModel.Cnpj))
        {
            return BadRequest("CNPJ já está cadastrado no sistema!");
        }

        if (!await ConsultationWeb.ConsultationCnpj(clientModel.Cnpj.Replace("-", "").Replace("/", "").Replace(".", "")))
        {
            return NotFound($"CNPJ {clientModel.Cnpj} não encontrado na base de dados da Receita Federal.");
        }

        _context.ClientModel.Add(clientModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetClient), new { Id = clientModel.Id }, clientModel);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> PutClient(Guid Id, ClientModel clientModel)
    {
        var existingClient = await _context.ClientModel.FindAsync(Id);

        if (existingClient == null)
        {
            return NotFound("Cliente não está cadastrado no sistema");
        }

        // Propriedades modificáveis
        existingClient.Telefone = clientModel.Telefone;
        existingClient.Uf = clientModel.Uf;
        existingClient.Cidade = clientModel.Cidade;
        existingClient.Bairro = clientModel.Bairro;
        existingClient.Rua = clientModel.Rua;
        existingClient.NEndereco = clientModel.NEndereco;
        existingClient.Cep = clientModel.Cep;

        try
        {
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (DbUpdateException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteClient(Guid Id)
    {
        var client = await _context.ClientModel.FindAsync(Id);

        if (client == null)
        {
            return NotFound();
        }

        _context.ClientModel.Remove(client);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}