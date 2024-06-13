    using Api_Rest.Models;
using Api_Rest.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Api_Rest.Controllers
{
    [Route("/Group")]
    [ApiController]
    [Authorize]
    public class GroupController : ControllerBase
    {
        // Déclaration du repository pour les groupes
        private readonly IGroupRepository _groupRepository;

        public GroupController(IGroupRepository classRepository)
        {
            _groupRepository = classRepository;
        }

        // Route pour récupérer tous les groupes
        [Route("/GetAllGroup")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                // Appel du repository pour récupérer tous les groupes
                var groups = _groupRepository.GetAll();
                return Ok(groups); // Retourne une réponse avec le code 200 OK et la liste des groupes
            }
            catch (Exception ex)
            {
                // En cas d'erreur, retourne une réponse avec le code 500 Internal Server Error
                return StatusCode(500, "Une erreur interne s'est produite.");
            }
        }

        // Route pour récupérer un groupe par son ID
        [Route("/GetByIdGroup/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                // Appel du repository pour récupérer un groupe par son ID
                var group = _groupRepository.GetById(id);

                if (group == null)
                {
                    return NotFound(); // Si le groupe n'est pas trouvé, retourne une réponse avec le code 404 Not Found
                }

                return Ok(group); // Retourne une réponse avec le code 200 OK et le groupe trouvé
            }
            catch (Exception ex)
            {
                // En cas d'erreur, retourne une réponse avec le code 500 Internal Server Error
                return StatusCode(500, "Une erreur interne s'est produite.");
            }
        }

        // Route pour récupérer l'id d'un groupe
        [Route("/GetGroupIdWithGroupeInfo")]
        [HttpPost]
        public IActionResult GetGroupIdWithGroupeInfo([FromBody] RequestGroup requestGroup)
        {
            try
            {
                // Appelle une méthode du repository pour obtenir l'ID du groupe en fonction des paramètres fournis.
                var id = _groupRepository.GetGroupId(requestGroup.Cycle, requestGroup.Section, requestGroup.SubSection);

                // Vérifie si l'ID a été trouvé.
                if (id != null)
                {
                    // Si oui, retourne une réponse HTTP 200 OK avec l'ID en tant que contenu.
                    return Ok(id);
                }

                // Si l'ID n'a pas été trouvé, retourne une réponse HTTP 404 Not Found.
                return NotFound();
            }
            catch (Exception ex)
            {
                // En cas d'erreur interne, logge l'exception et retourne une réponse HTTP 500 Internal Server Error.
                return StatusCode(500, "Une erreur interne s'est produite.");
            }
        }


        // Route pour ajouter un groupe
        [Route("/AddGroup")]
        [HttpPost]
        public IActionResult AddGroup([FromBody] Group group)
        {
            try
            {
                // Appel du repository pour ajouter un groupe
                _groupRepository.Add(group);
                return CreatedAtAction(nameof(GetById), new { id = group.Id }, group); // Retourne une réponse avec le code 201 Created et le groupe ajouté
            }
            catch (Exception ex)
            {
                // En cas d'erreur, retourne une réponse avec le code 500 Internal Server Error
                return StatusCode(500, "Une erreur interne s'est produite.");
            }
        }

        // Route pour mettre à jour un groupe par son ID
        [Route("/UpdateGroup/{id}")]
        [HttpPut]
        public IActionResult UpdateGroup(int id, [FromBody] Group group)
        {
            try
            {
                if (id != group.Id)
                {
                    return BadRequest(); // Si l'ID dans le chemin ne correspond pas à l'ID du groupe, retourne une réponse avec le code 400 Bad Request
                }

                // Appel du repository pour mettre à jour le groupe
                _groupRepository.Update(group);
                return NoContent(); // Retourne une réponse avec le code 204 No Content
            }
            catch (Exception ex)
            {
                // En cas d'erreur, retourne une réponse avec le code 500 Internal Server Error
                return StatusCode(500, "Une erreur interne s'est produite.");
            }
        }

        // Route pour supprimer un groupe par son ID
        [Route("/DeleteGroup/{id}")]
        [HttpDelete]
        public IActionResult DeleteGroup(int id)
        {
            try
            {
                // Appel du repository pour supprimer le groupe
                _groupRepository.Delete(id);
                return NoContent(); // Retourne une réponse avec le code 204 No Content
            }
            catch (Exception ex)
            {
                // En cas d'erreur, retourne une réponse avec le code 500 Internal Server Error
                return StatusCode(500, "Une erreur interne s'est produite.");
            }
        }

    }

    public class RequestGroup
    {
        public string Cycle { get; set; }
        public string Section { get; set; }
        public string SubSection { get; set; }
    }
}
