using Api_Rest.Data;
using Api_Rest.Models;
using Microsoft.AspNetCore.Mvc;
using Api_Rest.Controllers;
using Api_Rest.Repository;
using System.Security.Cryptography;
using NuGet.Protocol.Core.Types;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Rest.Controllers
{
    [Route("/StudentPresence")]
    [ApiController]
    [Authorize]
    public class StudentPresenceController : ControllerBase
    {
        // Déclaration du repository pour les présences d'élèves
        private readonly IStudentPresenceRepository _studentPresenceRepository;

        // Constructeur prenant le repository en paramètre et l'assignant à la variable privée _studentPresenceRepository
        public StudentPresenceController(IStudentPresenceRepository studentPresenceRepository)
        {
            _studentPresenceRepository = studentPresenceRepository;
        }

        // Route pour récupérer toutes les présences d'élèves
        [Route("/GetAllStudentPresence")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                // Appel du repository pour récupérer toutes les présences d'élèves
                var studentPresences = _studentPresenceRepository.GetAll();
                return Ok(studentPresences); // Retourne une réponse avec le code 200 OK et la liste des présences d'élèves
            }
            catch (Exception ex)
            {
                // En cas d'erreur, retourne une réponse avec le code 500 Internal Server Error
                return StatusCode(500, "Une erreur interne s'est produite.");
            }
        }

        // Route pour récupérer une présence d'élève par son ID
        [Route("/GetByIdStudentPresence/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                // Appel du repository pour récupérer une présence d'élève par son ID
                var studentPresence = _studentPresenceRepository.GetById(id);

                if (studentPresence == null)
                {
                    return NotFound(); // Si la présence d'élève n'est pas trouvée, retourne une réponse avec le code 404 Not Found
                }

                return Ok(studentPresence); // Retourne une réponse avec le code 200 OK et la présence d'élève trouvée
            }
            catch (Exception ex)
            {
                // En cas d'erreur, retourne une réponse avec le code 500 Internal Server Error
                return StatusCode(500, "Une erreur interne s'est produite.");
            }
        }

        // Route pour ajouter une présence d'élève
        [Route("/AddStudentPresence")]
        [HttpPost]
        public IActionResult AddStudentPresence([FromBody] StudentPresence studentPresence)
        {
            try
            {
                // Appel du repository pour ajouter une présence d'élève
                _studentPresenceRepository.Add(studentPresence);
                return CreatedAtAction(nameof(GetById), new { id = studentPresence.Id }, studentPresence); // Retourne une réponse avec le code 201 Created et la présence d'élève ajoutée
            }
            catch (Exception ex)
            {
                // En cas d'erreur, retourne une réponse avec le code 500 Internal Server Error
                return StatusCode(500, "Une erreur interne s'est produite.");
            }
        }

        // Route pour mettre à jour une présence d'élève par son ID
        [Route("/UpdateStudentPresence/{id}")]
        [HttpPut]
        public IActionResult UpdateStudentPresence(int id, [FromBody] StudentPresence studentPresence)
        {
            try
            {
                if (id != studentPresence.Id)
                {
                    return BadRequest(); // Si l'ID dans le chemin ne correspond pas à l'ID de la présence d'élève, retourne une réponse avec le code 400 Bad Request
                }

                // Appel du repository pour mettre à jour la présence d'élève
                _studentPresenceRepository.Update(studentPresence);
                return NoContent(); // Retourne une réponse avec le code 204 No Content
            }
            catch (Exception ex)
            {
                // En cas d'erreur, retourne une réponse avec le code 500 Internal Server Error
                return StatusCode(500, "Une erreur interne s'est produite.");
            }
        }

        // Route pour supprimer une présence d'élève par son ID
        [Route("/DeleteStudentPresence/{id}")]
        [HttpDelete]
        public IActionResult DeleteStudentPresence(int id)
        {
            try
            {
                // Appel du repository pour supprimer la présence d'élève
                _studentPresenceRepository.Delete(id);
                return NoContent(); // Retourne une réponse avec le code 204 No Content
            }
            catch (Exception ex)
            {
                // En cas d'erreur, retourne une réponse avec le code 500 Internal Server Error
                return StatusCode(500, "Une erreur interne s'est produite.");
            }
        }

    }
}
