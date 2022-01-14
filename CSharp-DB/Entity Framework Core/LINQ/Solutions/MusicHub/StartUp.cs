namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //context.Database.EnsureCreated();
            //Console.WriteLine("Successfully created");
            //context.Database.EnsureDeleted();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            string result = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .ToList()
                .Where(a => a.ProducerId == producerId)
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    ProducerId = a.ProducerId,
                    Name = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        Name = s.Name,
                        Price = s.Price.ToString("f2"),
                        WriterName = s.Writer.Name
                    })
                        .ToList()
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.WriterName)
                        .ToList(),
                    TotalPrice = a.Price.ToString("f2")
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var album in albums)
            {
                //sb.AppendLine($"-AlbumName: {album.Name}");
                //sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                //sb.AppendLine($"-ProducerName: {album.ProducerName}");
                //sb.AppendLine($"-Songs:");

                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                int counter = 1;

                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{counter++}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalPrice}");
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Include(s => s.SongPerformers)
                .ThenInclude(sp => sp.Performer)
                .Include(s => s.Album)
                .ThenInclude(a => a.Producer)
                .Include(s => s.Writer)
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    Name = s.Name,
                    //PerformerFullName = s.SongPerformers.FirstOrDefault(p => p.Performer != null).Performer.FirstName
                    //+ " " + s.SongPerformers.FirstOrDefault(p => p.Performer != null).Performer.LastName,
                    SongPerformer = s.SongPerformers.FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                //.ThenBy(s => s.PerformerFullName)
                .ToList();

            var sb = new StringBuilder();

            for (int i = 0; i < songs.Count(); i++)
            {
                sb.AppendLine($"-Song #{i + 1}");
                sb.AppendLine($"---SongName: {songs[i].Name}");
                sb.AppendLine($"---Writer: {songs[i].WriterName}");

                if (songs[i].SongPerformer != null)
                {
                    sb.AppendLine($"---Performer: {songs[i].SongPerformer.Performer.FirstName + " " + songs[i].SongPerformer.Performer.LastName}");
                }
                else
                {
                    sb.AppendLine("---Performer: ");
                }

                sb.AppendLine($"---AlbumProducer: {songs[i].AlbumProducer.Name}");
                sb.AppendLine($"---Duration: {songs[i].Duration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
