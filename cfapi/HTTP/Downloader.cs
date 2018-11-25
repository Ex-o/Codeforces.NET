using System.Threading.Tasks;

namespace cfapi.HTTP
{
    public class Downloader
    {
        private Session _session;
        public Downloader(Session session)
        {
            _session = session;
        }
        public async Task DownloadSource(long submissionId)
        {

        }
    }
}