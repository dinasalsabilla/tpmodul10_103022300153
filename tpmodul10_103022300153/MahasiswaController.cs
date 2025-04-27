using Microsoft.AspNetCore.Mvc;

namespace tpmodul10_103022300153
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Dina Salsabilla", NIM = "103022300153" },
            new Mahasiswa { Nama = "Rahmah Aisyah", NIM = "103022300014" },
            new Mahasiswa { Nama = "Muhammad Fauzan", NIM = "103022300065" },
            new Mahasiswa { Nama = "Dewanta Rahma Satria", NIM = "103022300071" },
            new Mahasiswa { Nama = "Dina Salsabilla", NIM = "103022300153" },
            new Mahasiswa { Nama = "Dhea Sri Noor Septianiz", NIM = "103022300072" },
        };

        // GET api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> Get()
        {
            return Ok(mahasiswaList);
        }

        // GET api/mahasiswa/{index}
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> Get(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
            {
                return NotFound("Mahasiswa dengan index tersebut tidak ditemukan.");
            }
            return Ok(mahasiswaList[index]);
        }

        // POST api/mahasiswa
        [HttpPost]
        public ActionResult Post([FromBody] Mahasiswa mahasiswa)
        {
            if (mahasiswa == null)
            {
                return BadRequest("Data mahasiswa tidak valid.");
            }
            mahasiswaList.Add(mahasiswa);
            return CreatedAtAction(nameof(Get), new { index = mahasiswaList.Count - 1 }, mahasiswa);
        }

        // DELETE api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
            {
                return NotFound("Mahasiswa dengan index tersebut tidak ditemukan.");
            }
            mahasiswaList.RemoveAt(index);
            return NoContent();
        }
    }
}
