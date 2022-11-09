using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Data;
using Model;
using Newtonsoft.Json;

namespace Tesicnor_Prueba
{
    public class FixerRequest 
    {
        private readonly FilmContext _context;

        public FixerRequest()
        {
            _context = new FilmContext();
        }

        public  void Execute()
        {
            string apiKey = "731e41f";
            string baseUri = $"http://www.omdbapi.com/?apikey={apiKey}";

            string name = "Harry Potter";
            

            var sb = new StringBuilder(baseUri);
            sb.Append($"&s={name}");
            

            var request = WebRequest.Create(sb.ToString());
            request.Timeout = 1000;
            request.Method = "GET";
            request.ContentType = "application/json";

            string result = string.Empty;

            try
            {
                using (var response = request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();

                            var listFilmsJson = JsonConvert.DeserializeObject<Root>(result);

                            Console.WriteLine(result);

                            
                            foreach(Search Film in listFilmsJson.Search)
                            {
                                Film HarryFilm = new Film(Film.imdbID, Film.Title, Film.Year, new Random().Next(1, 5));

                                _context.Set<Film>().Add(HarryFilm);
                            }
                        }
                    }
                }

               
            }

            catch (WebException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

           
        }
    }
}
