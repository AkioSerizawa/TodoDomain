using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers;

[ApiController]
[Route("v1/todos")]
public class TodoController : ControllerBase
{
    [Route("")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAll(
        [FromServices] ITodoRepository repository)
    {
        return repository.GetAll("akioserizawa");
    }

    [Route("")]
    [HttpPost]
    public GenericCommandResult Create(
        [FromBody] CreateTodoCommand command,
        [FromServices] TodoHandler handler)
    {
        command.User = "akioserizawa";
        return (GenericCommandResult)handler.Handle(command);
    }
}