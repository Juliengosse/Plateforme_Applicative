using Api_Rest.Data;
using Api_Rest.Models;
using Api_Rest.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Api_Rest.Controllers
{
    [Route("/Student")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        // Injection de dépendance pour le repository
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // Route pour récupérer tous les élèves
        [Route("/GetAllStudent")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                // Appel du repository pour récupérer tous les élèves
                var students = _studentRepository.GetAll();
                return Ok(students); // Retourne une réponse avec le code 200 OK et la liste des élèves
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite."); // En cas d'erreur, retourne une réponse avec le code 500 Internal Server Error
            }
        }

        // Route pour récupérer un élève par son ID
        [Route("/GetByIdStudent/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                // Appel du repository pour récupérer un élève par son ID
                var student = _studentRepository.GetById(id);

                if (student == null)
                {
                    return NotFound(); // Si l'élève n'est pas trouvé, retourne une réponse avec le code 404 Not Found
                }

                return Ok(student); // Retourne une réponse avec le code 200 OK et l'élève trouvé
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite."); // En cas d'erreur, retourne une réponse avec le code 500 Internal Server Error
            }
        }

        // Route pour ajouter un élève
        [Route("/AddStudent")]
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            try
            {
                // Appel du repository pour ajouter un élève
                _studentRepository.Add(student);
                return CreatedAtAction(nameof(GetById), new { id = student.Id }, student); // Retourne une réponse avec le code 201 Created et l'élève ajouté
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite."); // En cas d'erreur, retourne une réponse avec le code 500 Internal Server Error
            }
        }

        // Route pour mettre à jour un élève par son ID
        [Route("/UpdateStudent/{id}")]
        [HttpPut]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            try
            {
                if (id != student.Id)
                {
                    return BadRequest(); // Si l'ID dans le chemin ne correspond pas à l'ID de l'élève, retourne une réponse avec le code 400 Bad Request
                }

                // Appel du repository pour mettre à jour l'élève
                _studentRepository.Update(student);
                return NoContent(); // Retourne une réponse avec le code 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite."); // En cas d'erreur, retourne une réponse avec le code 500 Internal Server Error
            }
        }

        // Route pour supprimer un élève par son ID
        [Route("/DeleteStudent/{id}")]
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                // Appel du repository pour supprimer l'élève
                _studentRepository.Delete(id);
                return NoContent(); // Retourne une réponse avec le code 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne s'est produite."); // En cas d'erreur, retourne une réponse avec le code 500 Internal Server Error
            }
        }
    }
}
