namespace Theatre.DataProcessor
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var selectedTheaters = context.Theatres
                .Include(t => t.Tickets)
                .ToArray()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(ti => ti.RowNumber <= 5 && ti.RowNumber >= 1)
                        .Sum(tick => tick.Price),
                    Tickets = t.Tickets
                        .Where(ti => ti.RowNumber >= 1 & ti.RowNumber <= 5)
                        .OrderByDescending(tick => tick.Price)
                        .Select(tick => new
                        {
                            Price = (decimal)decimal.Parse(tick.Price.ToString("f2")),
                            RowNumber = tick.RowNumber
                        })
                        .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(selectedTheaters, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlaysExportDto[]), new XmlRootAttribute("Plays"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(sb);

            List<PlaysExportDto> playsToExport = new List<PlaysExportDto>();

            var plays = context.Plays
                .Where(p => p.Rating <= rating)
                .ToArray()
                .Select(p => new
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                        .Where(a => a.IsMainCharacter)
                        .Select(a => new
                        {
                            FullName = a.FullName,
                            MainCharacter = string.Format($"Plays main character in '{p.Title}'.")
                        })
                        .OrderByDescending(a => a.FullName)
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            foreach (var play in plays)
            {
                List<ActorExportDto> playActors = new List<ActorExportDto>();

                foreach (var actor in play.Actors)
                {
                    playActors.Add(new ActorExportDto()
                    {
                        FullName = actor.FullName,
                        MainCharacter = actor.MainCharacter
                    });
                }

                PlaysExportDto playsExportDto = new PlaysExportDto()
                {
                    Title = play.Title,
                    Duration = play.Duration,
                    Rating = play.Rating,
                    Genre = play.Genre,
                    Actors = playActors.ToArray()
                };

                playsToExport.Add(playsExportDto);
            }

            xmlSerializer.Serialize(sw, playsToExport.ToArray(), namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
