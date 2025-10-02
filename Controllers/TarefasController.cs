using ApiTarefas.Database;
using ApiTarefas.Models;
using ApiTarefas.ModelViews;
using ApiTarefas.Dto;
using Microsoft.AspNetCore.Mvc;
using ApiTarefas.Services;
using ApiTarefas.Models.Erros;

namespace ApiTarefas.Controllers;

[ApiController]
[Route("/tarefas")]
public class TarefasController : ControllerBase
{

    public TarefasController(TarefaService service)
    {
        _service = service;
    }

    private TarefaService _service;

    [HttpGet]
    public IActionResult Index()
    {
        var tarefas = _service.Lista();
        return StatusCode(200, tarefas);
    }

    [HttpPost]
    public IActionResult Create([FromBody] TarefaDto tarefaDto)
    {
        try
        {
            var tarefa = _service.Create(tarefaDto);
            return StatusCode(201, tarefa);

        }
        catch (TarefaErro erro)
        {
            return StatusCode(400, new ErroView { Mensagem = erro.Message });
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] TarefaDto tarefaDto)
    {
        try
        {
            var tarefaDb = _service.Update(id, tarefaDto);
            return StatusCode(201, tarefaDb);
        }
        catch (TarefaErro erro)
        {
            return StatusCode(400, new ErroView { Mensagem = erro.Message });
        }

        
    }

    [HttpGet("{id}")]
    public IActionResult Show([FromRoute] int id)
    {
        try
        {
            var tarefaDb = _service.FindId(id);
            return StatusCode(200, tarefaDb);
        }
        catch (TarefaErro erro)
        {
            return StatusCode(404, new ErroView { Mensagem = erro.Message });
        }
        
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            _service.Delete(id);
            return StatusCode(204);
        }
        catch (TarefaErro erro)
        {
            return StatusCode(400, new ErroView { Mensagem = erro.Message });
        }
        
    }

}
