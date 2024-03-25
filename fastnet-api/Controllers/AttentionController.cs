using fastnet_api.Bll;
using fastnet_api.DBModels;
using fastnet_api.Models.Attention;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fastnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttentionController : ControllerBase
    {
        AttentionBll AttentionB = new();

        [Authorize]
        [HttpGet]
        public ActionResult<List<Attention>> GetAttentions()
        {
            return AttentionB.GetAttentions();
        }

        [Authorize]
        [HttpGet]
        [Route("{attentionId}")]
        public ActionResult<Attention?> GetAttentionById(int attentionId)
        {
            Attention? FindAttention = AttentionB.GetAttentionById(attentionId);

            if (FindAttention == null) {
                return NotFound("attention id invalid");
            }

            return FindAttention;
        }

        [HttpGet]
        [Route("getByClientId/{clientId}")]
        public ActionResult<Attention?> GetAttentionByClientId(int clientId)
        {
            Attention? FindAttention = AttentionB.GetAttentionByClientId(clientId);

            if (FindAttention == null)
            {
                return NotFound("no has attention created or client not exist");
            }

            return FindAttention;
        }

        [HttpPost]
        [Route("newAttention")]
        public ActionResult<int?> NewAttention([FromBody] NewAttentionRequestModel model)
        {
            int? AttentionNew = AttentionB.NewAttention(model);

            if (AttentionNew == null)
            {
                return NotFound("missing attention type, client not exist or client has attention active");
            }

            return AttentionNew;
        }

        [HttpGet]
        [Route("closeAttention/{attentionId}")]
        public ActionResult<int?> RemoveAttention(int attentionId)
        {
           int? AttentionRemoved = AttentionB.RemoveAttention(attentionId);

            if (AttentionRemoved == null)
            {
                return NotFound("attention id invalid");
            }

            return Ok(AttentionRemoved);
        }
    }
}
