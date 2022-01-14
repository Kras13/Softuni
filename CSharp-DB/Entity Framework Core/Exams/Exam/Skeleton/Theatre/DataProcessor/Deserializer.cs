namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayImportDto[]), xmlRoot);

            PlayImportDto[] playDtos;

            using (StringReader sr = new StringReader(xmlString))
            {
                playDtos = (PlayImportDto[])(xmlSerializer.Deserialize(sr));
            }

            List<Play> playsToSave = new List<Play>();
            var sb = new StringBuilder();

            foreach (var playDto in playDtos)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidTimeSpan =
                    TimeSpan.TryParse(playDto.Duration, CultureInfo.InvariantCulture, out TimeSpan playDuration);

                if (!isValidTimeSpan)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (playDuration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidGenre = Enum.TryParse<Genre>(playDto.Genre, true, out Genre playGenre);

                if (!isValidGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = playDto.Title,
                    Duration = playDuration,
                    Rating = playDto.Rating,
                    Genre = playGenre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };

                playsToSave.Add(play);
                sb.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating));
            }

            context.Plays.AddRange(playsToSave);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CastImportDto[]), xmlRoot);

            CastImportDto[] castDtos;

            using (StringReader sr = new StringReader(xmlString))
            {
                castDtos = (CastImportDto[])(xmlSerializer.Deserialize(sr));
            }

            List<Cast> castsToSave = new List<Cast>();
            var sb = new StringBuilder();

            foreach (var castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool canParseBool = bool.TryParse(castDto.IsMainCharacter.ToLower(), out bool isMainCharacter);

                if (!canParseBool)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = castDto.FullName,
                    PhoneNumber = castDto.PhoneNumber,
                    IsMainCharacter = isMainCharacter,
                    PlayId = castDto.PlayId
                };
                string role = isMainCharacter ? "main" : "lesser";

                castsToSave.Add(cast);
                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, role));
            }

            context.Casts.AddRange(castsToSave);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var sb = new StringBuilder();

            ProjectionsImportDto[] projectionDtos =
                JsonConvert.DeserializeObject<ProjectionsImportDto[]>(jsonString);

            List<Theatre> projections = new List<Theatre>();

            foreach (var projectionDto in projectionDtos)
            {
                if (!IsValid(projectionDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre theatre = new Theatre()
                {
                    Director = projectionDto.Director,
                    Name = projectionDto.Name,
                    NumberOfHalls = projectionDto.NumberOfHalls
                };

                foreach (var importTicketDto in projectionDto.Tickets)
                {
                    if (!IsValid(importTicketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket()
                    {
                        RowNumber = importTicketDto.RowNumber,
                        Price = importTicketDto.Price,
                        TheatreId = theatre.Id,
                        PlayId = importTicketDto.PlayId
                    };

                    theatre.Tickets.Add(ticket);
                }

                projections.Add(theatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(projections);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
