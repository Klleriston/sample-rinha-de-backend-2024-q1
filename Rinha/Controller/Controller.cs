using Microsoft.AspNetCore.Mvc;
using RINHABACKEND.Data;
using RINHABACKEND.Model;
using RINHABACKEND.Services;

[ApiController]
[Route("clientes")]
public class ClienteController : ControllerBase
{
    private readonly Databasecontext _db;
    private readonly Service _contaService;

    public ClienteController(Databasecontext db, Service contaservice)
    {
        _db = db;
        _contaService = contaservice;
    }

    [HttpGet]
    [Route("{id}/extrato")]
    public IActionResult GetSaldo(int id)
    {
        if (id <= 0)
        {
            return NotFound("ID do cliente inválido.");
        }

        Saldo saldo = _contaService.GetSaldo(id);

        if (saldo == null)
        {
            return NotFound("Cliente não encontrado.");
        }

        var json = new
        {
            saldo = new
            {
                total = saldo.Total,
                data_extrato = saldo.Data_extrato,
                limite = saldo.limite
            },
            ultimas_transacoes = saldo.Transacao
        };

        return Ok(json);
    }

    [HttpPost]
    [Route("{id}/transacoes")]
    public IActionResult PostTransacao(int id, [FromBody] Transacao transacao)
    {
        if (id <= 0)
        {
            return NotFound("ID do cliente inválido.");
        }

        Saldo saldo = _contaService.CriarTransacao(id, transacao);

        return Ok(new { limite = saldo.limite, saldo = saldo.Total });
    }
}
