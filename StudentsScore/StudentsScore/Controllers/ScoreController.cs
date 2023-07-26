using AutoMapper;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.ScoreDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace StudentsScore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        ScoreManager scoreManager = new ScoreManager(new EfScoreRepository());
        private readonly IMapper _mapper;

        public ScoreController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Teacher,Student")]
        public IActionResult ScoreList()
        {
            var values = scoreManager.GetList();
            return Ok(values);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Teacher")]
        public IActionResult ScoreAdd(ScoreAddDTO scoreAddDTO)
        {
            Score score = _mapper.Map<Score>(scoreAddDTO);
            scoreManager.Add(score);
            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Teacher,Student")]
        public IActionResult ScoreGetById(int id)
        {
            var score = scoreManager.GetById(id);
            if (score == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(score);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Teacher")]
        public IActionResult ScoreDelete(int id)
        {
            var score = scoreManager.GetById(id);
            if (score == null)
            {
                return NotFound();
            }
            else
            {
                scoreManager.Delete(score);
                return Ok();
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Teacher")]
        public IActionResult ScoreUpdate(ScoreUpdateDTO scoreUpdateDTO)
        {
            Score score = _mapper.Map<Score>(scoreUpdateDTO);
            var scoreValue = scoreManager.GetById(score.Id);
            if (scoreValue == null)
            {
                return NotFound();
            }
            else
            {
                scoreValue.UserId = score.UserId;
                scoreValue.CourseId = score.CourseId;
                scoreValue.UserScore = score.UserScore;
                scoreManager.Update(scoreValue);
                return Ok();
            }
        }
    }
}
