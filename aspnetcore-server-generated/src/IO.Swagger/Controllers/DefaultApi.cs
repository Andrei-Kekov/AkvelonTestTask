using AkvelonTestTask.DataAccess;
using AkvelonTestTask.Logic;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Attributes;

using Microsoft.AspNetCore.Authorization;
using IO.Swagger.Models;
using AkvelonTestTask.DataAccess;

namespace IO.Swagger.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DefaultApiController : ControllerBase
    {
        private IProjectLogic _logic;   // Only for test purposes. Use DI instead.

        public DefaultApiController(IProjectLogic logic) : base()
        {
            if (logic is null)
            {
                throw new ArgumentNullException();
            }

            _logic = logic;
        }

        /// <summary>
        /// Add a new project
        /// </summary>
        /// <param name="body">New project data</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid input</response>
        [HttpPost]
        [Route("/project")]
        [ValidateModelState]
        [SwaggerOperation("AddProject")]
        [SwaggerResponse(statusCode: 200, type: typeof(Project), description: "Successful operation")]
        public virtual IActionResult AddProject([FromBody]Project body)
        {
            try
            {
                _logic.AddProject(body);
            }
            catch (ArgumentNullException)
            {
                return StatusCode(400);
            }
            catch
            {
                return StatusCode(500);
            }

            return StatusCode(200);

            string exampleJson = null;
            exampleJson = "{\n  \"statusId\" : 2,\n  \"name\" : \"Dinner\",\n  \"completionDate\" : \"2000-01-23T04:56:07.000+00:00\",\n  \"priority\" : 200,\n  \"startDate\" : \"2000-01-23T04:56:07.000+00:00\"\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Project>(exampleJson)
            : default(Project);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Add a new task to a project
        /// </summary>
        /// <param name="body">New task data</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid input</response>
        [HttpPost]
        [Route("/task")]
        [ValidateModelState]
        [SwaggerOperation("AddTask")]
        [SwaggerResponse(statusCode: 200, type: typeof(Task), description: "Successful operation")]
        public virtual IActionResult AddTask([FromBody]Task body)
        {
            try
            {
                _logic.AddTask(body);
            }
            catch (ArgumentNullException)
            {
                return StatusCode(400);
            }
            catch (KeyNotFoundException)
            {
                return StatusCode(400);
            }
            catch
            {
                return StatusCode(500);
            }

            return StatusCode(200);

            string exampleJson = null;
            exampleJson = "{\n  \"statusId\" : 2,\n  \"name\" : \"Cut the potatoes\",\n  \"description\" : \"Peel the potatoes, then cut them into slices\",\n  \"id\" : 65536,\n  \"priority\" : 200,\n  \"projectId\" : 42\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<Task>(exampleJson)
                        : default(Task);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Delete the project with {projectId}
        /// </summary>
        /// <param name="projectId">ID of project to delete</param>
        /// <response code="200">Successful operation</response>
        /// <response code="404">Project ID not found</response>
        [HttpDelete]
        [Route("/project/{projectId}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteProject")]
        public virtual IActionResult DeleteProject([FromRoute][Required]int? projectId)
        {
            try
            {
                return _logic.DeleteProject(projectId.Value) ? StatusCode(200) : StatusCode(404);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// View all existing projects
        /// </summary>
        /// <response code="200">Successful operation</response>
        [HttpGet]
        [Route("/project")]
        [ValidateModelState]
        [SwaggerOperation("GetProjects")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Project>), description: "Successful operation")]
        public virtual IActionResult GetProjects()
        {
            try
            {
                return new ObjectResult(_logic.GetProjects());
            }
            catch
            {
                return StatusCode(500);
            }

            string exampleJson = null;
            exampleJson = "[ {\n  \"statusId\" : 2,\n  \"name\" : \"Dinner\",\n  \"completionDate\" : \"2000-01-23T04:56:07.000+00:00\",\n  \"id\" : 42,\n  \"priority\" : 200,\n  \"startDate\" : \"2000-01-23T04:56:07.000+00:00\"\n}, {\n  \"statusId\" : 2,\n  \"name\" : \"Dinner\",\n  \"completionDate\" : \"2000-01-23T04:56:07.000+00:00\",\n  \"id\" : 42,\n  \"priority\" : 200,\n  \"startDate\" : \"2000-01-23T04:56:07.000+00:00\"\n} ]";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<List<Project>>(exampleJson)
                        : default(List<Project>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// View all tasks for a project
        /// </summary>
        /// <param name="projectId">ID of project to view tasks</param>
        /// <response code="200">Successful operation</response>
        /// <response code="404">Project ID not found</response>
        [HttpGet]
        [Route("/project/{projectId}/tasks")]
        [ValidateModelState]
        [SwaggerOperation("GetTasks")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Task>), description: "Successful operation")]
        public virtual IActionResult GetTasks([FromRoute][Required]int? projectId)
        { 
            try
            {
                return new ObjectResult(_logic.GetTasks(projectId.Value));
            }
            catch (KeyNotFoundException)
            {
                return StatusCode(404);
            }
            catch
            {
                return StatusCode(500);
            }

            string exampleJson = null;
            exampleJson = "[ {\n  \"statusId\" : 2,\n  \"name\" : \"Cut the potatoes\",\n  \"description\" : \"Peel the potatoes, then cut them into slices\",\n  \"id\" : 65536,\n  \"priority\" : 200,\n  \"projectId\" : 42\n}, {\n  \"statusId\" : 2,\n  \"name\" : \"Cut the potatoes\",\n  \"description\" : \"Peel the potatoes, then cut them into slices\",\n  \"id\" : 65536,\n  \"priority\" : 200,\n  \"projectId\" : 42\n} ]";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<List<Task>>(exampleJson)
                        : default(List<Task>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Delete the task with {taskId}
        /// </summary>
        /// <param name="taskId">ID of task to delete</param>
        /// <response code="200">Successful operation</response>
        /// <response code="404">Task ID not found</response>
        [HttpDelete]
        [Route("/task/{taskId}")]
        [ValidateModelState]
        [SwaggerOperation("TaskTaskIdDelete")]
        public virtual IActionResult TaskTaskIdDelete([FromRoute][Required]int? taskId)
        { 
            try
            {
                return _logic.DeleteTask(taskId.Value) ? StatusCode(200) : StatusCode(404);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Update an existing project
        /// </summary>
        /// <param name="body">New project data</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid input</response>
        /// <response code="404">Project ID not found</response>
        [HttpPut]
        [Route("/project")]
        [ValidateModelState]
        [SwaggerOperation("UpdateProject")]
        public virtual IActionResult UpdateProject([FromBody]Project body)
        { 
            try
            {
                _logic.UpdateProject(body);
                return StatusCode(200);
            }
            catch (ArgumentNullException)
            {
                return StatusCode(400);
            }
            catch (ArgumentException)
            {
                return StatusCode(400);
            }
            catch (KeyNotFoundException)
            {
                return StatusCode(404);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Update an existing task
        /// </summary>
        /// <param name="body">New task data</param>
        /// <response code="200">Successful operation</response>
        /// <response code="404">Project ID or Task ID not found</response>
        /// <response code="405">Invalid input</response>
        [HttpPut]
        [Route("/task")]
        [ValidateModelState]
        [SwaggerOperation("UpdateTask")]
        public virtual IActionResult UpdateTask([FromBody]Task body)
        {
            try
            {
                _logic.UpdateTask(body);
                return StatusCode(200);
            }
            catch (ArgumentNullException)
            {
                return StatusCode(400);
            }
            catch (ArgumentException)
            {
                return StatusCode(400);
            }
            catch (KeyNotFoundException)
            {
                return StatusCode(404);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
