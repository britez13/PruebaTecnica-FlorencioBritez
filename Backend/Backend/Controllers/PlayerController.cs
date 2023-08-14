using Backend.DAL;
using Backend.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace Backend.Controllers
{
    public class PlayerController : ApiController
    {

        private PlayerDbContext _player;

        public PlayerController()
        {
            _player = new PlayerDbContext();
        }

        
        // GET api/player/{name}
        //public string Get(string name
        public HttpResponseMessage Get(string name)
        {
            try
            {
                var player = _player.Players.FirstOrDefault(p => p.Name == name);
                if (player == null)
                {
                    var errorResponse = new
                    {
                        Message = "Jugador no existe en la base de datos"
                    };

                    return Request.CreateResponse(HttpStatusCode.NotFound, errorResponse);
                }

                var response = new { player };
                return Request.CreateResponse(HttpStatusCode.OK, response);
                
            }
            catch (Exception e)
            {
               
                var errorResponse = new
                {
                    Message = e.Message

                };

                return Request.CreateResponse(HttpStatusCode.InternalServerError, errorResponse);
            }
           
        }

        // POST api/player
        //public Player Post([FromBody] Player value)
        public HttpResponseMessage Post([FromBody] Player playerReq)
        {
            try
            {
                var player = _player.Players.FirstOrDefault(p => p.Name == playerReq.Name);
                if (player == null)
                {
                    var newPlayer = _player.Players.Add(playerReq);
                    _player.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.Created, newPlayer);
                }

                player.Balance = playerReq.Balance;
                _player.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, player);
                
            }
            catch (Exception e)
            {
                var errorResponse = new
                {
                    Message = e.Message
                };

                return Request.CreateResponse(HttpStatusCode.InternalServerError, errorResponse);
            }
        }


    }
}