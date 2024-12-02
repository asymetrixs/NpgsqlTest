using System.ComponentModel.DataAnnotations;

namespace NpgsqlRowVersion.Models;

public class DboTimestamp
{
    public int Id { get; set; }

    public int Col1 { get; set; }

    [Timestamp]
    public uint RowVersion { get; set; }
}
