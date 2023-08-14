using Backend.Helper;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;


namespace Backend.Controllers
{
    public class GameController : ApiController
    {



        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        //public void Post([FromBody] HttpRequestMessage request)
        public HttpResponseMessage Post([FromBody] Game request)
        {
            try
            {
                HelperClass helper = new HelperClass();

                Dictionary<int, RouletteData> rouletteData = RouletteData.InitializeRouletteData();

                int randomNumber = helper.RandomNumber();
                var rouletteResult = new { value = "", color = "" };

                if (rouletteData.TryGetValue(randomNumber, out RouletteData number))
                {
                    //Console.WriteLine($"Spinning the roulette... The ball lands on: {number.Value} ({number.Color})");
                    rouletteResult = new { value = number.Value, color = number.Color };
                }

                string pattern = @"[0-9]+";
                Regex regex = new Regex(pattern);

                Match match = regex.Match(request.pick);

                var response = new { result = rouletteResult, betUpdate = 0, isAWin = false }; 

                if(match.Success )
                {
                    if(randomNumber == int.Parse(request.pick))
                    {
                        response = new { result = rouletteResult, betUpdate = request.bet * 3, isAWin = true };
                    }
                    else 
                    {
                        response = new { result = rouletteResult, betUpdate = 0, isAWin = false };
                    }

                } else
                {
                    if (request.pick.ToLower() == "rojo par" || request.pick.ToLower() == "negro par" || request.pick.ToLower() == "rojo impar" || 
                        request.pick.ToLower() == "negro impar")
                    {
                        //
                        string[] words = request.pick.ToLower().Split(' ');

                        // Número es par y coincide con la predicción del jugador
                        if(words[0] == rouletteResult.color && words[1] == "par" && int.Parse(rouletteResult.value) % 2 == 0 )
                        {
                            response = new { result = rouletteResult, betUpdate = request.bet * 2, isAWin = true };
                        }
                        // Número es impar y coincide con la predicción del jugador
                        else if (words[0] == rouletteResult.color && words[1] == "impar" && int.Parse(rouletteResult.value) % 2 != 0)
                        {
                            response = new { result = rouletteResult, betUpdate = request.bet * 2, isAWin = true };
                        }

                        else
                        {
                            response = new { result = rouletteResult, betUpdate = 0, isAWin = false };
                        }
                    }

                    if(request.pick.ToLower() == "rojo" || request.pick.ToLower() == "negro")
                    {
                        if(request.pick.ToLower() == rouletteResult.color)
                        {
                            response = new { result = rouletteResult, betUpdate = request.bet, isAWin = true };
                        }   
                        else
                        {
                            response = new { result = rouletteResult, betUpdate = 0, isAWin = false };
                        }
                    }

                    //response = new Dictionary<string, string>()
                    //{
                    //    { "data", "no es un número" }
                    //};
                }

                // Necesitar trabajar con el resultado. 

                //var response = new { data = rouletteResult };


                // Construct a success response with JSON content
                //return Request.CreateResponse(HttpStatusCode.Created, response);
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
               
            catch (Exception e)
            {
                // Construct an error response with JSON content and an internal server error status code
                var errorResponse = new
                {
                    Message = e.Message

                };

                return Request.CreateResponse(HttpStatusCode.InternalServerError, errorResponse);
            }
}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}